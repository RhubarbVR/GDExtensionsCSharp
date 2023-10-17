namespace GDSharp {
[Flags]
public enum MethodFlags : long {
	MethodFlagNormal = 1,
	MethodFlagEditor = 2,
	MethodFlagConst = 4,
	MethodFlagVirtual = 8,
	MethodFlagVararg = 16,
	MethodFlagStatic = 32,
	MethodFlagObjectCore = 64,
	MethodFlagsDefault = 1,
}
}
