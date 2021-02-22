import os
import re
import threading
import time

import pandas as pd
import matplotlib.pyplot as plt
import matplotlib.animation as animation
import keyboard

from brunnerdx import *

LENGTH_LINES = 1000

class BrunnerDaemon(BrunnerDx):
    def __init__(self, host, port):
        super().__init__(host, port)
        self.pending_rows = []

    def daemonize(self):
        self.thread = threading.Thread(target=self.loop)
        self.thread.daemon = True
        self.thread.start()

    def read_log(self):
        line = super().read_log()
        splitted = re.split(r'([^-0-9])', line)

        column_names = {
            'X': 'x',
            'L': 'last',
            'C': 'change',
            'V': 'velocity',
            'A': 'acceleration',
            'F': 'force',
        }

        line_dict = {v:None for v in column_names.values()}
        now_reading = 'millis'
        for x in splitted:
            if now_reading:
                line_dict[now_reading] = int(x)
                now_reading = None
            else:
                now_reading = column_names.get(x)

        row = pd.Series(line_dict)
        self.pending_rows.append(row)

    @property
    def df(self):
        if not hasattr(self, '_df'):
            self._df = pd.DataFrame([self.pending_rows[0]]*LENGTH_LINES)

        if self.pending_rows:
            pending_rows = self.pending_rows
            self.pending_rows = []
            self._df = (
              pd.concat([
                      self._df,
                      pd.DataFrame(pending_rows)
                  ], axis=0)
              .tail(LENGTH_LINES)
              .fillna(method='ffill')
            )
        return self._df


if __name__ == '__main__':
    brunnerdx = BrunnerDaemon(HOST, PORT)
    brunnerdx.start()
    # brunnerdx.loop()
    brunnerdx.daemonize()
    time.sleep(5) # give it time to start getting data

    keyboard.on_press_key("c", lambda _:
        brunnerdx.df.to_csv(
            os.path.expandvars(r'%USERPROFILE%\Downloads\brunnerdx.csv'),
            index=False))

    fig = plt.figure(figsize=(15,7))
    what_to_plot = {
        'x': [-32767, 32767],
        'force': [-255, 255],
        'change': [-1500, 1500],
        'velocity': [-100, 100]
    }
    x = list(range(0, LENGTH_LINES))

    axs = []
    lines = []
    for i, (k,limits) in enumerate(what_to_plot.items()):
        ax = fig.add_subplot(4, 1, i+1)
        ax.set_ylim(bottom=0)
        ax.set_ylabel(k)
        ax.set_xlabel('Millis')
        ax.set_ylim(limits)
        axs.append(ax)
        line, = ax.plot(x, brunnerdx.df[k], label='val')
        lines.append(line)

    def update(num):
        for i, (k,limits) in enumerate(what_to_plot.items()):
            lines[i].set_ydata(brunnerdx.df[k])
        return tuple(lines)

    ani = animation.FuncAnimation(fig, update, len(x), interval=20, blit=True)

    plt.legend()
    plt.show()
