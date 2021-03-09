from libs.robust_serial.robust_serial import read_order, write_order, Order, read_i32, write_i16, read_i8
from libs.robust_serial.utils import open_serial_port

import socket
import struct
import time

# CLS2Sim network configuration
HOST = '127.0.0.1'
PORT = 15090
TIMEOUT = 8
# change these numbers for stronger or weaker forces
FORCE_MULTIPLIER = 0.4

import collections

class BrunnerDx():
    def __init__(self, host, port):
        self.host = host
        self.port = port
        self.pos = [0,0,0,0]
        self.force = (0, 0, 0, 0)
        self.semaphore = 10
        self.pos_history = collections.deque(maxlen=100)
        try:
            self.serial_file = open_serial_port(baudrate=115200, timeout=None)
        except Exception as e:
            raise e

    def write_order(self, order):
        if self.semaphore > 0:
            write_order(self.serial_file, order)
            self.semaphore -= 1

    def start(self):
        serial_file = self.serial_file
        is_connected = False
        # Initialize communication with Arduino
        while not is_connected:
            print("Waiting for Arduino...")
            self.write_order(Order.HELLO)
            bytes_array = bytearray(serial_file.read(1))
            if not bytes_array:
                time.sleep(2)
                continue
            byte = bytes_array[0]
            if byte in [Order.HELLO.value, Order.ALREADY_CONNECTED.value]:
                is_connected = True
        self.semaphore = 10
        print("Connected to Arduino")

        # Create a UDP socket
        self.sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
        # Set TTL to 5 to allow jumping over routers
        self.sock.setsockopt(socket.IPPROTO_IP, socket.IP_MULTICAST_TTL, 5)
        # Set socket timeout
        self.sock.settimeout(TIMEOUT)

    @staticmethod
    # accept a number in the range 0.0-1.0 and
    # return a number in the range -32767,32767
    # for axis position
    def translate_brunner_pos(pos):
        return -int((pos-0.5) * 2.0 * 32767)

    @staticmethod
    # accept a force in the range -255,255 and
    # return a force that Brunner understands
    def translate_arduino_force(force):
        return int(force * FORCE_MULTIPLIER)

    # send a request to the Arduino to send us the forces soon
    def request_forces(self):
        self.write_order(Order.FORCES)

    # read the forces the Arduino is sending us right now
    def read_forces(self):
        force_x = self.translate_arduino_force(read_i32(self.serial_file))
        force_y = self.translate_arduino_force(read_i32(self.serial_file))
        self.force = (force_x, force_y, 0, 0)
        return self.force

    # read the log the Arduino is sending us right now
    def read_log(self):
        return self.serial_file.readline().decode('ascii')

    # this will send the current forces to the Brunner base
    # and read back the current position of the joystick
    def sendforces_readposition(self):
        force = self.force
        pos = self.pos
        # notice the opposite order of y,x
        request = struct.pack('<Iiiii', 0xAF, force[1], force[0], force[2], force[3])
        self.sock.sendto(request, (self.host, self.port))
        response, address = self.sock.recvfrom(8192)
        result, pos[1], pos[0], pos[2], pos[3] = struct.unpack('<Iffff', response)
        self.pos_history.append(pos.copy())

    # this will send the current position to the Arduino
    # so it will make the joystick appear in the new position
    def send_position(self):
        if len(self.pos_history) < 2 or self.pos_history[-1][0] != self.pos_history[-2][0] or self.pos_history[-1][1] != self.pos_history[-2][1] :
            x,y = self.pos_history[-1][0], self.pos_history[-1][1]
            self.write_order(Order.POSITION)
            write_i16(self.serial_file, self.translate_brunner_pos(x))
            write_i16(self.serial_file, self.translate_brunner_pos(y))

    # do we have messages from the Arduino
    @property
    def in_waiting(self):
        return self.serial_file.in_waiting

    def loop(self):
        next_update = 0
        while True:
            now = time.time()

            if self.in_waiting:
                try:
                    order = read_order(self.serial_file)
                except ValueError:
                    order = None

                if order == Order.RECEIVED:
                    self.semaphore += 1
                elif order == Order.FORCES:
                    self.read_forces()
                elif order == Order.LOG:
                    log_line = self.read_log()

            if now >= next_update:
                next_update = now + 0.02 # update loop time
                # this communicates with the Brunner base
                self.sendforces_readposition()
                # this communicates with the Arduino device
                self.send_position()
                self.request_forces()


if __name__ == '__main__':
    brunnerdx = BrunnerDx(HOST, PORT)
    brunnerdx.start()
    brunnerdx.loop()
