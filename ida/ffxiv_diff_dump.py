# takes two files file1 and file2 and prints all of the lines that are in file2 but not in file1
# yes, this can be done with standard UNIX tooling, but most of us are on Windows, so
import sys

assert(len(sys.argv) == 3)

def read_file(filename):
    with open(filename) as file:
        lines = file.readlines()
        return [line.rstrip() for line in lines]

[file1, file2] = [set(read_file(f)) for f in sys.argv[1:]]
print('\n'.join(file2 - file1))