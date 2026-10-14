from dataclasses import dataclass

@dataclass
class IndentWriterValue:
    indent_level: int
    line: str

    def __str__(self):
        return " " * (self.indent_level * 2) + self.line

class IndentWriter(object):
    def __init__(self):
        self.indent_level: int = 0
        self.lines: list[IndentWriterValue] = []

    def indent(self):
        self.indent_level += 1
    
    def unindent(self):
        self.indent_level -= 1
        if (self.indent_level < 0):
            self.indent_level = 0

    def append(self, line: str):
        self.lines.append(IndentWriterValue(self.indent_level, line))

    def __iadd__(self, line: str):
        self.append(line)
        return self

    def __str__(self):
        return "\n".join([str(line) for line in self.lines])