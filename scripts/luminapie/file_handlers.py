import os


def get_game_data_folders(root):
    # type: (str) -> str
    for folder in os.listdir(os.path.join(root, "sqpack")):
        if os.path.isdir(os.path.join(root, "sqpack", folder)):
            yield folder


def get_files(path):
    # type: (str) -> list[bytes]
    files: list[bytes] = []
    for dir_path, dir_names, file_names in os.walk(path):
        files.extend(os.path.join(dir_path, file) for file in file_names)

    return files


def get_sqpack_files(root, path):
    # type: (str, str) -> str
    for file in get_files(os.path.join(root, "sqpack", path)):
        ext = file.split(".")[-1]
        if ext.startswith("dat"):
            yield file


def get_sqpack_index(root, path):
    # type: (str, str) -> str
    for file in get_files(os.path.join(root, "sqpack", path)):
        if file.endswith(".index"):
            yield file


def get_sqpack_index2(root, path):
    # type: (str, str) -> str
    for file in get_files(os.path.join(root, "sqpack", path)):
        if file.endswith(".index2"):
            yield file
