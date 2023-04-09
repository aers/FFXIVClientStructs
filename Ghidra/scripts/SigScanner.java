//Signature Generator for Ghidra
//@author Pohky
//@category __UserScripts
//@keybinding CTRL-ALT-S
//@menupath XivTools.GenerateSig
//@toolbar

import java.time.Duration;
import java.time.Instant;
import java.util.ArrayList;
import java.awt.datatransfer.StringSelection;
import java.awt.Toolkit;
import java.awt.datatransfer.Clipboard;

import ghidra.app.script.GhidraScript;
import ghidra.program.model.lang.*;
import ghidra.program.model.listing.*;
import ghidra.program.model.address.*;

public class SigScanner extends GhidraScript {
	public byte[] TextSectionData;
	
	public int MaxReferences = 1999; // max. amount of references to include in the search, -1 = no limit
	public int MaxResults = -1; // stop after MaxResults unique signatures are found, -1 = no limit
	public int MinSignatureLength = 3; // min. length in bytes a signature should to have
	public int MaxSignatureLength = 256; // max. length in bytes a signature is allowed to have
	public boolean ListAltSignatures = false; // if more than 1 signature with the same lenght was found, list them all
	public boolean CopyResultToClipboard = true;

	@Override
	protected void run() throws Exception {
		var refs = getRefsTo(currentAddress, MaxReferences);
		if (this.getInstructionAt(currentAddress) != null)
			refs.add(0, currentAddress);
		
		var block = currentProgram.getMemory().getBlock(".text");
		TextSectionData = new byte[(int) block.getSize()];
		block.getBytes(block.getStart(), TextSectionData);

		var patternList = new ArrayList<Pattern>(refs.size());

		monitor.initialize(refs.size());
		//writer.println("Scanning " + refs.size() + " possible locations...");

		var startTime = Instant.now();
		if (refs.size() > 24) {
			refs.parallelStream().forEach((address) -> {
				if (monitor.isCancelled())
					return;
				if (MaxResults > 0 && patternList.size() >= MaxResults)
					return;
				try {
					monitor.incrementProgress(1);
					var pat = generateSignatureAt(address);
					if (pat != null)
						patternList.add(pat);
					var time = Duration.between(startTime, Instant.now()).toMillis();
					monitor.setMessage(String.format("Time: %,d ms (Results: %d)", time, patternList.size()));
				} catch (Exception ex) {
					ex.printStackTrace();
					monitor.cancel();
				}
			});
		} else {
			for (var i = 0; i < refs.size() && !monitor.isCancelled(); i++) {
				if (MaxResults > 0 && patternList.size() >= MaxResults)
					return;
				var address = refs.get(i);
				monitor.setProgress(i);
				var time = Duration.between(startTime, Instant.now()).toMillis();
				monitor.setMessage(String.format("Time: %,d ms (Results: %d)", time, patternList.size()));
				var pat = generateSignatureAt(address);
				if (pat != null)
					patternList.add(pat);
			}
		}

		if (patternList.size() == 0) {
			writer.println("Failed. No Unique Signatures Found for " + currentAddress);
			return;
		}

		patternList.sort((a, b) -> {
			if (a.size() > b.size())
				return 1;
			if (a.size() < b.size())
				return -1;
			return 0;
		});

		var sig = patternList.get(0);
		var sym = getSymbolAt(currentAddress);
		if (monitor.isCancelled()) {
			writer.println("Cancelled...");
			writer.println(String.format("Possible Signature for %s (%s)\n%s ", currentAddress, sym, sig.toString()));
		} else {
			writer.println(String.format("Signature for %s (%s)\n%s ", currentAddress, sym, sig.toString()));
			if (CopyResultToClipboard)
				Toolkit.getDefaultToolkit().getSystemClipboard().setContents(new StringSelection(sig.toString()), null);
		}
		if (ListAltSignatures) {
			patternList.removeIf((s) -> {
				return s.size() > sig.size() || s == sig;
			});
			patternList.forEach((s) -> {
				writer.println(String.format("-> %s ", s.toString()));
			});
		}
	}
	
	private ArrayList<Address> getRefsTo(Address addr, int max) {
		var list = new ArrayList<Address>(max);
		if(max == 0) return list;
		for (var ref : currentProgram.getReferenceManager().getReferencesTo(addr)) {
			var address = ref.getFromAddress();
			var insn = getInstructionAt(address);

			if (insn == null)
				continue;
			var type = ref.getReferenceType();
			if ((type.isJump() || type.isData()) && insn.getLength() < 5)
				continue;
			if (type.isConditional())
				continue;
			list.add(address);
			if (max >= 0 && list.size() >= max)
				break;
		}
		return list;
	}

	private Pattern generateSignatureAt(Address startAddress) throws Exception {
		var fn = currentProgram.getFunctionManager().getFunctionContaining(startAddress);
		if (fn == null)
			return null;
		var ins = currentProgram.getListing().getInstructionContaining(startAddress);
		if (ins == null)
			return null;

		var pat = new Pattern(MaxSignatureLength + 15);
		var body = fn.getBody();

		while (body.contains(ins.getAddress()) && !monitor.isCancelled()) {
			pat.add(ins);
			if (pat.size() >= MinSignatureLength) {
				if (pat.isUnique(TextSectionData))
					return pat.trim();
			}
			if (pat.size() == 0 || (MaxSignatureLength > 0 && pat.size() >= MaxSignatureLength))
				break;
			ins = ins.getNext();
		}
		return null;
	}

	private class Pattern extends ArrayList<PatternByte> {
		public Pattern(int capacity) {
			super(capacity);
		}

		public void add(Instruction insn) {
			try {
				addAll(maskInstruction(insn));
			} catch (Exception e) {
				e.printStackTrace();
			}
		}

		public Pattern trim() {
			for (var i = size() - 1; i > 0; i--) {
				if (get(i).IsWildcard)
					remove(i);
				else
					break;
			}
			return this;
		}

		public boolean isUnique(byte[] buffer) {
			var last = size() - 1;
			for (last = size() - 1; last >= 0; last--) {
				if (!get(last).IsWildcard)
					break;
			}
			if (last == 0)
				return false;
			var shiftTable = buildShiftTable(last);
			var offset = 0;
			var maxOffset = buffer.length - last;
			var matches = 0;
			while (offset < maxOffset) {
				for (var pos = last; get(pos).IsWildcard || get(pos).Value == buffer[pos + offset]; pos--) {
					if (pos == 0) {
						matches++;
						break;
					}
				}
				if (matches >= 2)
					return false;
				offset += shiftTable[buffer[offset + last] & 0xFF];
			}
			return true;
		}

		private int[] buildShiftTable(int last) {
			int idx;
			var table = new int[256];
			for (idx = last; idx > 0 && !get(idx).IsWildcard; --idx) {
			}
			var diff = last - idx;
			if (diff == 0)
				diff = 1;
			for (idx = 0; idx <= 255; ++idx)
				table[idx] = diff;
			for (idx = last - diff; idx < last; ++idx)
				table[get(idx).Value & 0xFF] = last - idx;
			return table;
		}

		private ArrayList<PatternByte> maskInstruction(Instruction insn) throws Exception {
			var mask = new byte[insn.getLength()];
			var proto = insn.getPrototype();
			var bytes = insn.getBytes();
			var list = new ArrayList<PatternByte>(bytes.length);

			for (var op = 0; op < insn.getNumOperands(); op++) {
				if (shouldMaskOperand(insn, op)) {
					var opBytes = proto.getOperandValueMask(op).getBytes();
					for (var i = 0; i < mask.length; i++) {
						mask[i] = (byte) (mask[i] | opBytes[i] & 0xFF);
					}
				}
			}

			for (var i = 0; i < bytes.length; i++) {
				var b = new PatternByte();
				if (mask[i] == -1) {
					b.IsWildcard = true;
					b.Value = 0;
				} else {
					b.IsWildcard = false;
					b.Value = bytes[i];
				}
				list.add(b);
			}
			return list;
		}

		private Boolean shouldMaskOperand(Instruction insn, int idx) {
			var optype = insn.getOperandType(idx);
			return (optype & OperandType.DYNAMIC) != 0 ||
					OperandType.isAddress(optype) ||
					OperandType.isScalar(optype);
		}

		@Override
		public String toString() {
			var s = "";
			for (var b : this) {
				if (b.IsWildcard)
					s += "?? ";
				else
					s += String.format("%02X ", b.Value);
			}
			return s.trim();
		}
	}

	private class PatternByte {
		public boolean IsWildcard;
		public byte Value;

		@Override
		public String toString() {
			if (IsWildcard)
				return "??";
			return String.format("%02X", Value);
		}
	}
}