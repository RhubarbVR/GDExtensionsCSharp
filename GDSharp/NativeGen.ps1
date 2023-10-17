ClangSharpPInvokeGenerator `
    -c single-file latest-codegen generate-aggressive-inlining exclude-default-remappings generate-guid-member <# configuration for the generator#> `
    -f gdextension_interface.h <# file we want to generate bindings for #>  `
    --traverse gdextension_interface.h `
    -n GodotNative <# namespace of the bindings #> `
    --methodClassName GDExtensionInterface <# class name where to put methods #> `
    --libraryPath godot <# name of the DLL #> `
    -o NativeHeader.cs <# output folder #>

Pause