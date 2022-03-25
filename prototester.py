usagemsg = """
usage: prototester.py [-r] host port sendformat recvformat data0,... dataN

-r          - if this flag is set, send and receive will loop forever.
host        - the host to send the packet to.
port        - the port to send the packet to.
sendformat  - a string defining the format of the data to send.
              each char defines the type of 1 senddata argument.
              see python documentation for struct.pack
              for usable chars and their types.
recvformat  - same as sendformat, but parses the received data.
data0-N     - the data to be parsed and sent to the host

example: prototester.py 127.0.0.1 15090 iiffff iiBBhBBhBBh 0xCC 0x11 1.0 0 0 0

explanation:
send to 127.0.0.1:15090  2x a 4byte signed Integer and 4x a 4byte float.
0xCC and 0x11 are the two integers. decimal numbers can also be used as input.
the 1.0 and the 3 zeroes are the floats. if no dot is used (eg 1.0) the input
will be parsed as integer.

the "BBhBBhBBh" part is used by struct.unpack to parse the incoming raw bytes.
in this case 2 unsigned chars are followed by a signed short.
this is repeated 3 times
"""

import socket
import struct
import sys
import os

def toNiceHex(binaryString):
    hexstr = binaryString.hex()
    niceHex = ' '.join([hexstr[i:i+2] for i in range(0, len(hexstr), 2)])
    return niceHex

def parseData(data):
    nr = data
    isHex = False
    val = None
    
    if data[:2] == "0x":
        isHex = True
        nr = nr[2:]
        
    if isHex:
        nr = int(nr, 16)
    
    if '.' in str(data):
        val = float(nr)
    
    elif '"' in str(data):
        val =nr.strip('"').encode('utf-8')
    else:
        val = int(nr)
    return val

doLoop = False

# parsing arguments
args = sys.argv[1:]
if len(args) < 5:
    print(usagemsg)
    exit()
if args[0][0:2] == "-r":
    args = sys.argv[2:]
    doLoop = True

host = args[0]
port = int(args[1])
sendformat = args[2]
recvformat = args[3]

data = args[4:]
inputs = [parseData(val) for val in data]

# if len(sendformat) != len(inputs):
    # print("number of sendformat chars is different from the number of data arguments")
    # exit()

# preparing data for sending
bytesToSend = struct.pack(sendformat, *inputs)
# bytesToSend = b'\xcf\x00\x00\x00\x01\x00\x00\x00\tSpace Sim'
niceHex = toNiceHex(bytesToSend)
# prepare socket
size = 8192
timeout = 8
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
sock.settimeout(timeout)
sock.bind(('', 0))

while True:
    print("sending {} bytes...".format(len(bytesToSend)))
    print(niceHex)
    #send and get response
    sock.sendto(bytesToSend, (host, port))
    response, address = sock.recvfrom(8192)
    print("received {} bytes.".format(len(response)))
    print(toNiceHex(response))
    # parse result
    result = struct.unpack(recvformat, response)
    print("data: ")
    print(result)
    if not doLoop:
        break
sock.close()
