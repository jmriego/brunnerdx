import serial

ser = serial.Serial('COM21', 9600, serial.EIGHTBITS, serial.PARITY_NONE, serial.STOPBITS_ONE)

msg = input('serial msg: ')
cmd = msg[0]

def ser_write(b):
    print(b)

def main():
    import struct
    ser_write(bytes(cmd, 'ascii'))

    for num in msg[1:].split():
        ser_write(struct.pack(">I", int(num)))

    ser_write(bytes('\n', 'ascii'))

main()
