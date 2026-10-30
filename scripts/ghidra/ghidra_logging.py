"""Forwards stdout and stderr of a script run to Ghidra's log, which saves it to application.log."""

import sys

from ghidra.app.script import GhidraScript
from ghidra.util import Msg

try:
    # what GhidraScript.println wraps its lines in, lets the log filter on script messages
    from ghidra.app.script import ScriptMessage
except ImportError:
    ScriptMessage = str

ORIGINATOR = GhidraScript.class_


class GhidraLogStream(object):
    """Text stream that passes writes on to the stream it replaces and logs each full line."""

    def __init__(self, target, script_name: str, is_stderr: bool, echo: bool):
        self.target = target
        self.script_name = script_name
        self.is_stderr = is_stderr
        self.echo = echo
        self.buffer = ""

    def write(self, text: str) -> int:
        if self.echo:
            self.target.write(text)
        self.buffer += text
        *lines, self.buffer = self.buffer.split("\n")
        for line in lines:
            self.log(line)
        return len(text)

    def flush(self):
        if self.buffer:
            self.log(self.buffer)
            self.buffer = ""
        if self.echo:
            self.target.flush()

    def log(self, line: str):
        line = line.rstrip("\r")
        if not line.strip():
            return
        message = ScriptMessage(f"{self.script_name}> {line}")
        stripped = line.lstrip()
        if self.is_stderr or stripped.startswith("Error"):
            Msg.error(ORIGINATOR, message)
        elif stripped.startswith("Warning"):
            Msg.warn(ORIGINATOR, message)
        else:
            Msg.info(ORIGINATOR, message)

    def isatty(self) -> bool:
        return False

    def __getattr__(self, name):
        return getattr(self.target, name)


class _Redirect(object):
    def __init__(self, monitor, stdout, stderr):
        self.monitor = monitor
        self.stdout = stdout
        self.stderr = stderr
        self.depth = 1


_active: _Redirect | None = None


def start_logging(script_name: str, monitor, headless: bool):
    """Sends stdout and stderr to Ghidra's log until stop_logging.

    Scripts exec'd by another script share its monitor and nest into its redirect.
    """
    global _active
    if _active is not None:
        if _active.monitor is monitor:
            _active.depth += 1
            return
        _restore()

    stdout = GhidraLogStream(sys.stdout, script_name, False, not headless)
    stderr = GhidraLogStream(sys.stderr, script_name, True, not headless)
    _active = _Redirect(monitor, stdout, stderr)
    sys.stdout = stdout
    sys.stderr = stderr


def stop_logging():
    if _active is None:
        return
    _active.depth -= 1
    if _active.depth <= 0:
        _restore()


def _restore():
    global _active
    for stream in (_active.stdout, _active.stderr):
        stream.flush()
    # the script runner may have swapped the streams back already
    if sys.stdout is _active.stdout:
        sys.stdout = _active.stdout.target
    if sys.stderr is _active.stderr:
        sys.stderr = _active.stderr.target
    _active = None
