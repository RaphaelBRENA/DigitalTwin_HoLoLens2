import socket

IP = "0.0.0.0"
PORT = 5005

sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
sock.bind((IP, PORT))

print(f"UDP server listening on {IP}:{PORT}")

while True:
    data, addr = sock.recvfrom(4096)
    code = data.decode('utf-8')
    print(f"Received from {addr}:")
    print(code)
