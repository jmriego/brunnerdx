import socket
import struct
import sys
import os

def toNiceHex(binaryString):
    hexstr = binaryString.hex()
    niceHex = ' '.join([hexstr[i:i+2] for i in range(0, len(hexstr), 2)])
    return niceHex

bytesToSend = b'\xcf\x00\x00\x00\x01\x00\x00\x00\x09Space Sim'
# prepare socket
size = 8192
timeout = 8
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
sock.settimeout(timeout)
sock.bind(('', 0))

print("sending {} bytes...".format(len(bytesToSend)))
print(toNiceHex(bytesToSend))
#send and get response
sock.sendto(bytesToSend, ('localhost', 15090))
response, address = sock.recvfrom(8192)
print("received {} bytes.".format(len(response)))
print(toNiceHex(response))
sock.close()
