class Crc32:
    def __init__(self):
        self.poly = 0xEDB88320
        self.table = [0] * 256 * 16
        for i in range(256):
            res = i
            for j in range(16):
                for k in range(8):
                    if res & 1 == 1:
                        res = self.poly ^ (res >> 1)
                    else:
                        res = res >> 1
                self.table[i + j * 256] = res

    def calc(self, value: bytes):
        start = 0
        size = len(value)
        crc_local = 4294967295 ^ 0
        while size >= 16:
            a = (
                self.table[(3 * 256) + value[start + 12]]
                ^ self.table[(2 * 256) + value[start + 13]]
                ^ self.table[(1 * 256) + value[start + 14]]
                ^ self.table[(0 * 256) + value[start + 15]]
            )
            b = (
                self.table[(7 * 256) + value[start + 8]]
                ^ self.table[(6 * 256) + value[start + 9]]
                ^ self.table[(5 * 256) + value[start + 10]]
                ^ self.table[(4 * 256) + value[start + 11]]
            )
            c = (
                self.table[(11 * 256) + value[start + 4]]
                ^ self.table[(10 * 256) + value[start + 5]]
                ^ self.table[(9 * 256) + value[start + 6]]
                ^ self.table[(8 * 256) + value[start + 7]]
            )
            d = (
                self.table[(15 * 256) + (self.byte(crc_local) ^ value[start])]
                ^ self.table[(14 * 256) + (self.byte(crc_local, 1) ^ value[start + 1])]
                ^ self.table[(13 * 256) + (self.byte(crc_local, 2) ^ value[start + 2])]
                ^ self.table[(12 * 256) + (self.byte(crc_local, 3) ^ value[start + 3])]
            )
            crc_local = d ^ c ^ b ^ a
            start += 16
            size -= 16

        while size > 0:
            crc_local = self.table[(crc_local ^ value[start]) & 0xFF] ^ (crc_local >> 8)
            start += 1
            size -= 1

        return ~(crc_local ^ 4294967295) % (1 << 32)

    def byte(self, number: int, i=0):
        return (number & (0xFF << (i * 8))) >> (i * 8)

    def calc_index(self, path: str):
        path_parts = path.split('/')
        filename = path_parts[-1]
        folder = path.rstrip(filename).rstrip('/')

        foldercrc = self.calc(folder.encode('utf-8'))
        filecrc = self.calc(filename.encode('utf-8'))

        return foldercrc << 32 | filecrc

    def calc_index2(self, path: str):
        return self.calc(path.encode('utf-8'))
