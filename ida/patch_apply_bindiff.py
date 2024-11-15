# usage:
# 1. install bindiff8
# 2. in ida, load *new* exe, wait until autoanalysis/extrapass finishes
# 3. run bindiff, point to *old* idb that had everything imported, then save results (.BinDiff file)
# 4. in both *old* and *new* db, run patch_generate_global_refs script and create old/new globals jsons
# 5. ensure data.yml in current dir corresponds to *old*
# 6. run this script, passing path to BinDiff file, old globals and new globals - it will create data.yml.new to correspond to *new*
import json
import sqlite3
import sys
import re

THRESHOLD_SIMILARITY = 0
THRESHOLD_CONFIDENCE = 0

def load_globals(path):
    res = {}
    with open(path, 'r') as fd:
        for k, v in json.load(fd).items():
            res[int(k)] = (set(v['xrefs']), set(v['functable']))
    return res

def run(bindiff_path, old_globals_path, new_globals_path):
    remap = {}
    with sqlite3.connect(bindiff_path) as db:
        for addr_new, addr_old, similarity, confidence in db.execute('SELECT address1, address2, similarity, confidence FROM function'):
            if similarity >= THRESHOLD_SIMILARITY and confidence >= THRESHOLD_CONFIDENCE:
                remap[addr_old] = addr_new

    old_globals = load_globals(old_globals_path)
    new_globals = load_globals(new_globals_path)

    def calculate_similarity(old, new):
        matches = 0
        for xref in old:
            new_xref = remap.get(xref, 0)
            if new_xref != 0 and new_xref in new:
                matches += 1
        return matches

    def find_new_address(old_addr):
        if old_addr in remap:
            return remap[old_addr]
        if not old_addr in old_globals:
            return 0
        (old_refs, old_ft) = old_globals[old_addr]
        best_new = 0
        best_similarity = 0
        max_similarity = len(old_refs) + len(old_ft)
        good_enough_similarity = max_similarity
        if good_enough_similarity > 10:
            good_enough_similarity = 10 + (good_enough_similarity / 2)
        #if good_enough_similarity > 200:
        #    good_enough_similarity = 200
        for ea, newg in new_globals.items():
            new_refs, new_ft = newg
            similarity = calculate_similarity(old_refs, new_refs) + calculate_similarity(old_ft, new_ft)
            if similarity > best_similarity:
                best_new = ea
                best_similarity = similarity
            if best_similarity >= good_enough_similarity:
                break
        if best_new != 0:
            del new_globals[best_new]
        print(f'{old_addr:X} -> {best_new:X} = {best_similarity} / {max_similarity}')
        return best_new

    matches = 0
    fails = 0
    regex = re.compile('^(.*)0x([0-9a-fA-F]{9})(.*)\n')
    with open('data.yml', 'r') as old:
        with open('data.yml.new', 'w') as new:
            lines = old.readlines()
            cur_line = 0
            for line in lines:
                if line[:5] != '#fail':
                    match = re.fullmatch(regex, line)
                    if match:
                        old_addr = int(match.group(2), 16)
                        new_addr = find_new_address(old_addr)
                        if new_addr != 0:
                            line = f'{match.group(1)}0x{new_addr:X}{match.group(3)}\n'
                            matches = matches + 1
                        else:
                            line = '#fail' + line
                            fails = fails + 1
                new.write(line)
                cur_line += 1
                if (cur_line & 0xFFF) == 0:
                    print(f'Progress: {cur_line} / {len(lines)} ({cur_line / len(lines) * 100})%')
    print(f'done: {matches} matches, {fails} fails')

if len(sys.argv) < 4:
    print(f'usage: {sys.argv[0]} path_to_bindiff path_to_old_globals path_to_new_globals')
else:
    run(sys.argv[1], sys.argv[2], sys.argv[3])
