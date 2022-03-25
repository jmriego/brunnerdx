import socket, select
import struct
import pygame
import argparse

# Create a UDP socket
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
sock.settimeout(0.0)
# IP address of machine running CLS2Sim
# we are emulating it here
sock.bind(('192.168.3.187', 15090))

# Define some colors.
BLACK = pygame.Color('black')
WHITE = pygame.Color('white')

# This is a simple class that will help us print to the screen.
# It has nothing to do with the joysticks, just outputting the
# information.
class TextPrint(object):
    def __init__(self):
        self.reset()
        self.font = pygame.font.Font(None, 20)

    def tprint(self, screen, textString):
        textBitmap = self.font.render(textString, True, BLACK)
        screen.blit(textBitmap, (self.x, self.y))
        self.y += self.line_height

    def reset(self):
        self.x = 10
        self.y = 10
        self.line_height = 15

    def indent(self):
        self.x += 10

    def unindent(self):
        self.x -= 10


def list_joysticks():
    joystick_count = pygame.joystick.get_count()
    # For each joystick:
    for i in range(joystick_count):
      joystick = pygame.joystick.Joystick(i)
      print(joystick.get_name())


def get_joystick(joystick_name):
    joystick_count = pygame.joystick.get_count()

    # For each joystick:
    for i in range(joystick_count):
      joystick = pygame.joystick.Joystick(i)
      if joystick.get_name() == joystick_name:
          return joystick

# -------- Main Program Loop -----------
def main(joystick_name=None):
    pygame.init()
    if joystick_name is None:
        list_joysticks()
        return 0
    else:
        joystick = get_joystick(joystick_name)

    # Set the width and height of the screen (width, height).
    screen = pygame.display.set_mode((500, 200))
    # Loop until the user clicks the close button.
    done = False
    # Used to manage how fast the screen updates.
    clock = pygame.time.Clock()
    # Initialize the joysticks.
    pygame.joystick.init()
    aileron = elevator = 0
    # Get ready to print.
    textPrint = TextPrint()
    size = width, height = 160, 230
    screen = pygame.display.set_mode(size)
    pygame.display.set_caption("Brunner emulator")
    bg = (200, 200, 250, 100)
    red = (255, 0, 0, 100)
    white = (255, 255, 255, 100)
    rect = pygame.Rect(5, 75, 150, 150)

    while not done:

        for event in pygame.event.get(): # User did something.
            if event.type == pygame.QUIT: # If user clicked close.
                done = True # Flag that we are done so we exit this loop.

        screen.fill(WHITE)
        textPrint.reset()

        joystick.init()
        axis0 = joystick.get_axis(0)
        axis1 = joystick.get_axis(1)

        if joystick.get_name() == 'Arduino Micro': # arduino
          textPrint.tprint(screen, "Joystick {}".format(i))
          textPrint.indent()
          textPrint.tprint(screen, "Axis {} value: {:>6.3f}".format(1, axis0))
          textPrint.tprint(screen, "Axis {} value: {:>6.3f}".format(2, axis1))
          response = None
          while True:
              inputready, o, e = select.select([sock],[],[], 0.0)
              if len(inputready)==0:
                  break
              response, address = sock.recvfrom(20)
          if response:
              command = struct.unpack_from('<I', response)[0]
              if command == 0xAF:
                  result, elevator, aileron, rudder, collective = struct.unpack('<Iiiii', response)

        elif joystick.get_name() == 'X52 H.O.T.A.S.': #x52
              sock.sendto(
                  struct.pack('<iffff', 0xAF, axis1/2.0+0.5, axis0/2.0+0.5, 0.0, 0.0),
                  ('192.168.3.167', 15090))

        textPrint.tprint(screen, "Force values: {} , {}".format(aileron, elevator))
        pygame.draw.rect(screen, bg, rect)
        pygame.draw.circle(screen, white, (80,150), 5)
        force_x = int(80+(aileron/16))
        force_y = int(150+(elevator/16))
        pygame.draw.circle(screen, red, (force_x,force_y), 5)

        # ALL CODE TO DRAW SHOULD GO ABOVE THIS COMMENT
        #
        # Go ahead and update the screen with what we've drawn.
        pygame.display.flip()
        # Limit to 20 frames per second.
        clock.tick(20)
    pygame.quit()


if __name__ == '__main__':
    parser = argparse.ArgumentParser(description = 'Emulate CLS2Sim with a different joystick')
    parser.add_argument('joystick', nargs='?', help='which joystick to use as input')
    args = parser.parse_args()
    main(args.joystick)
