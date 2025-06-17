import socket
import random
import time

UDP_IP = "192.168.210.135"
UDP_PORT = 9876

sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

def send_random_numbers():
    print("Starting to send random numbers to Unity.")
    while True:
        value = random.randint(1, 99)
        message = str(value).encode()
        sock.sendto(message, (UDP_IP, UDP_PORT))
        print(f"Sent: {value}")
        time.sleep(1)

if __name__ == "__main__":
    send_random_numbers()
