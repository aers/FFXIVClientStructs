# Runs rename.py and struct_import.py in sequence
# @category __UserScripts
# @menupath Tools.Scripts.ffxiv_full_run
# @runtime PyGhidra

from os import path

try:
    working_directory = path.dirname(path.realpath(__file__))
except NameError:
    working_directory = path.dirname(str(sourceFile))  # noqa

print("Loading rename.py")
exec(open(path.join(working_directory, "rename.py")).read())

print("Loading struct_import.py")
exec(open(path.join(working_directory, "struct_import.py")).read())

analyzeChanges(currentProgram)  # noqa
