import os
import re
import ida_bytes
import ida_segment
import idaapi

SIG_REGEX = re.compile(r'"((?:[A-Fa-f0-9\?]{2}\s)*[A-Fa-f0-9\?]{2}\s{0,})"')
TEXT_SEGMENT = ida_segment.segment_t = ida_segment.get_segm_by_name('.text')

def replace_signatures_in_file(file_path, sigs):
    with open(file_path, 'r') as file:
        content = file.read()

    for old_signature, new_signature in sigs.items():
        content = content.replace(old_signature, new_signature)

    with open(file_path, 'w') as file:
        file.write(content)

def process_directory(directory, sigs):
    for root, dirs, files in os.walk(directory):
        for file in files:
            if file.endswith('.cs'):
                file_path = os.path.join(root, file)
                replace_signatures_in_file(file_path, sigs)

def get_sig_match_count(sig: str) -> bool:
    # Expects a byte array
    fmt_sig = [int(s, 16).to_bytes(1, 'little') if s != '??' else b'\0' for s in sig.split(' ')]
    fmt_sig = b''.join(fmt_sig)

    # Another byte array, 0 = "??" wildcard
    sig_mask = [int(b != '??').to_bytes(1, 'little') for b in sig.split(' ')]
    sig_mask = b''.join(sig_mask)

    result_count = 0
    sig_addr = TEXT_SEGMENT.start_ea  # noqa
    while True:
        sig_addr = idaapi.bin_search(
            sig_addr,
            TEXT_SEGMENT.end_ea,  # noqa
            fmt_sig, sig_mask,
            ida_bytes.BIN_SEARCH_FORWARD,
            ida_bytes.BIN_SEARCH_NOCASE)

        # No more results
        if sig_addr == idaapi.BADADDR:
            break

        # We have a match
        result_count += 1

        # But more than one fails the signature
        if result_count > 1:
            return result_count

        # Starting at the match, returns the same match. So go to the next byte
        sig_addr += 1

    return result_count

def main():
    filename = os.path.join(os.path.dirname(os.path.realpath(__file__)), "benchmark_sig_replacements.txt")
    sigs = {}
    with open(filename, 'r') as file:
        for line in file:
            splitted = line.split('#', 1)
            line = splitted[0].strip()
            if line:
                hex_strings = SIG_REGEX.findall(line)
                if hex_strings and len(hex_strings) == 2 and hex_strings[0] and hex_strings[1]:
                    num_matches = get_sig_match_count(hex_strings[1])
                    if num_matches == 0:
                        print(f"{splitted[1].strip()} not found: {hex_strings[1]}")
                    elif num_matches > 1:
                        print(f"Multiple matches for {splitted[1].strip()}: {hex_strings[1]}")
                    elif num_matches == 1:
                        #print(f"Match found for {splitted[1].strip()}: {hex_strings[1]}")
                        sigs[hex_strings[0]] = hex_strings[1]

    process_directory(os.path.join(os.path.dirname(os.path.realpath(__file__)), "../FFXIVClientStructs"), sigs)
    print("Done! Now don't forget to adjust the offsets! ;)")

if __name__ == "__main__":
    main()
