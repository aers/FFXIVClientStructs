from yaml import load, SafeLoader

try:
    from yaml import CSafeLoader

    # When a host re-imports the yaml package in the same interpreter (e.g. a script host unloading modules between runs),
    # the cached C extension keeps the old node classes and the resolver fails with "tag None", so check it still works
    load("a: 1", CSafeLoader)
    Loader = CSafeLoader
except Exception:
    Loader = SafeLoader
