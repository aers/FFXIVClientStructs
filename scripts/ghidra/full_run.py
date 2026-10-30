# Runs rename.py and struct_import.py in sequence
# @category __UserScripts
# @menupath Tools.Scripts.ffxiv_full_run
# @runtime PyGhidra

import os
import sys

try:
    working_directory = os.path.dirname(os.path.realpath(__file__))
except NameError:
    working_directory = os.path.dirname(str(sourceFile))  # noqa

if working_directory not in sys.path:
    sys.path.append(working_directory)

from ghidra_logging import start_logging, stop_logging

start_logging("full_run.py", monitor, isRunningHeadless())  # noqa

print("Loading rename.py")
exec(open(os.path.join(working_directory, "rename.py")).read())

print("Loading struct_import.py")
exec(open(os.path.join(working_directory, "struct_import.py")).read())

analyzeChanges(currentProgram)  # noqa
stop_logging()
