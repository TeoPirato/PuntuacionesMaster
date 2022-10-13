from random import randint

file = open("stress_test.txt", "w")

for i in range(1000):
    file.write(f"[{i}, {randint(0, 9999999)}]\n")

file.close()