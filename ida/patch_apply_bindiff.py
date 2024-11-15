# usage:
# 1. install bindiff8
# 2. in ida, load *new* exe, wait until autoanalysis/extrapass finishes
# 3. run bindiff, point to *old* idb that had everything imported, then save results (.BinDiff file)
# 4. ensure data.yml in current dir corresponds to *old*
# 5. run this script, passing path to BinDiff file - it will create data.yml.new to correspond to *new*
import sqlite3
import sys
import yaml
import re

def run(bindiff_path):
    remap = {}
    with sqlite3.connect(bindiff_path) as db:
        for addr_new, addr_old in db.execute('SELECT address1, address2 FROM function'):
            remap[addr_old] = addr_new

    regex = re.compile('^(.*)0x([0-9a-fA-F]{9})(.*)\n')
    with open('data.yml', 'r') as old:
        with open('data.yml.new', 'w') as new:
            for line in old.readlines():
                if line[:5] != '#fail':
                    match = re.fullmatch(regex, line)
                    if match:
                        old_addr = int(match.group(2), 16)
                        if old_addr in remap:
                            line = f'{match.group(1)}0x{remap[old_addr]:X}{match.group(3)}\n'
                        else:
                            line = '#fail' + line
                new.write(line)

if len(sys.argv) < 2:
    print(f'usage: {sys.argv[0]} path_to_bindiff')
else:
    run(sys.argv[1])
