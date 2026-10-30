import ida_kernwin
from webbrowser import open

F = ida_kernwin.Form

def build_spec(fields, change_cb):
    pad = max((len(f.get("label", "")) for f in fields), default=0)
    lines = ["STARTITEM 0", "BUTTON YES* Run", "BUTTON CANCEL Cancel"]
    need_first_space = True
    ctrls = {"FormChangeCb": F.FormChangeCb(change_cb)}

    prepend_line = ""
    for fld in fields:
        t, key = fld["type"], fld.get("key")
        label = fld.get("label", "").ljust(pad)
        tip = f"#{fld['tip']}#" if fld.get("tip") else ""

        if t == "space":
            lines.append("")
            if need_first_space:
              need_first_space = False
              lines.append("{FormChangeCb}")
        elif t == "label":
            label_text = fld["text"]
            if "prepend" in fld and fld["prepend"]:
              prepend_line = f"{prepend_line}{label_text}"
            else:
              lines.append(label_text)
        elif t == "folder":
            lines.append(f"{prepend_line}<{tip}{label}:{{{key}}}>")
            ctrls[key] = F.DirInput(swidth=fld.get("width", 60),
                                    value=fld.get("value", ""))
        elif t == "text":
            lines.append(f"{prepend_line}<{tip}{label}:{{{key}}}>")
            ctrls[key] = F.StringInput(swidth=fld.get("width", 30),
                                       value=fld.get("value", ""))
        elif t == "number":
            lines.append(f"{prepend_line}<{tip}{label}:{{{key}}}>")
            ctrls[key] = F.NumericInput(tp=F.FT_DEC, value=fld.get("value", 0))
        elif t == "dropdown":
            lines.append(f"{prepend_line}<{tip}{label}:{{{key}}}>")
            ctrls[key] = F.DropdownListControl(items=fld["items"], readonly=True,
                                               selval=fld.get("selval", 0))
        elif t == "button":
            on_click = fld["on_click"]
            lines.append(f"{prepend_line}<{tip}{label}:{{{key}}}>")
            ctrls[key] = F.ButtonInput(lambda code, fn=on_click: fn())

        elif t in ("checks", "radios"):
            names = []
            items = fld["items"]
            for i, (ikey, ilabel) in enumerate(items):
                name = f"{key}__{ikey}"
                names.append(name)
                last = (i == len(items) - 1)
                if last:
                    end = f">{{{key}}}>" if t == "checks" else f">{{{key}}}>"
                else:
                    end = ">"
                lines.append(f"{prepend_line}<{ilabel}:{{{name}}}{end}")
                ctrls[name] = F.Control() if False else None 
            for n in names:
                ctrls.pop(n, None)
            if t == "checks":
                ctrls[key] = F.ChkGroupControl(tuple(names))
            else:
                ctrls[key] = F.RadGroupControl(tuple(names))
        else:
            raise ValueError(f"Unknown field type: {t}")
        
        if t != "label":
          prepend_line = ""
            
    if need_first_space:
      raise ValueError(f"Did not receive a line of type space")
    
    return "\n".join(lines) + "\n", ctrls

class DynamicForm(F):
    def __init__(self, fields, on_change=None):
        self.fields = fields
        self._on_change_cb = on_change
        template, ctrls = build_spec(fields, self._on_change)
        F.__init__(self, template, ctrls)

    def _on_change(self, fid):
        if self._on_change_cb:
            self._on_change_cb(self, fid)
        return 1

    def results(self):
        """All values keyed by each field's key."""
        out = {}
        for fld in self.fields:
            t, key = fld["type"], fld.get("key")
            if t in ("folder", "text", "number"):
                out[key] = getattr(self, key).value
            elif t == "dropdown":
                v = getattr(self, key).value
                out[key] = fld["items"][v] if isinstance(v, int) else v
            elif t == "checks":
                mask = getattr(self, key).value
                out[key] = {ik: bool(mask & (1 << i))
                            for i, (ik, _) in enumerate(fld["items"])}
            elif t == "radios":
                out[key] = fld["items"][getattr(self, key).value][0]
        return out