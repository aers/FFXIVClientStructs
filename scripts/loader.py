import sys

api_libraries = {"ida": "idaapi", "ghidra": "ghidra"}


def get_selected_api():
    """
    Detect which API is being used by attempting to import libraries.
    """

    for lib in api_libraries:
        try:
            __import__(api_libraries[lib])
            return lib
        except ImportError:
            pass

    raise ImportError(
        "Could not find suitable API library. Are you running this from inside your disassembler?"
    )


def load_script(name):
    """
    Attempt to load a script in the `python` folder.
    """

    api = get_selected_api()
    files_to_try = {"python." + name + "_" + api, "python." + name}

    for file in files_to_try:
        try:
            if file in sys.modules:
                del sys.modules[file]

            return __import__(file)
        except ImportError:
            pass

    raise ImportError("Could not find " + name + " for API " + api)
