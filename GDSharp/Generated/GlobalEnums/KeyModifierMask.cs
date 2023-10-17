namespace GDSharp {
[Flags]
public enum KeyModifierMask : long {
	KeyCodeMask = 8388607,
	KeyModifierMask = 532676608,
	KeyMaskCmdOrCtrl = 16777216,
	KeyMaskShift = 33554432,
	KeyMaskAlt = 67108864,
	KeyMaskMeta = 134217728,
	KeyMaskCtrl = 268435456,
	KeyMaskKpad = 536870912,
	KeyMaskGroupSwitch = 1073741824,
}
}
