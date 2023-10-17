namespace GodotNative
{
    public enum GDExtensionVariantType
    {
        GDEXTENSION_VARIANT_TYPE_NIL,
        GDEXTENSION_VARIANT_TYPE_BOOL,
        GDEXTENSION_VARIANT_TYPE_INT,
        GDEXTENSION_VARIANT_TYPE_FLOAT,
        GDEXTENSION_VARIANT_TYPE_STRING,
        GDEXTENSION_VARIANT_TYPE_VECTOR2,
        GDEXTENSION_VARIANT_TYPE_VECTOR2I,
        GDEXTENSION_VARIANT_TYPE_RECT2,
        GDEXTENSION_VARIANT_TYPE_RECT2I,
        GDEXTENSION_VARIANT_TYPE_VECTOR3,
        GDEXTENSION_VARIANT_TYPE_VECTOR3I,
        GDEXTENSION_VARIANT_TYPE_TRANSFORM2D,
        GDEXTENSION_VARIANT_TYPE_VECTOR4,
        GDEXTENSION_VARIANT_TYPE_VECTOR4I,
        GDEXTENSION_VARIANT_TYPE_PLANE,
        GDEXTENSION_VARIANT_TYPE_QUATERNION,
        GDEXTENSION_VARIANT_TYPE_AABB,
        GDEXTENSION_VARIANT_TYPE_BASIS,
        GDEXTENSION_VARIANT_TYPE_TRANSFORM3D,
        GDEXTENSION_VARIANT_TYPE_PROJECTION,
        GDEXTENSION_VARIANT_TYPE_COLOR,
        GDEXTENSION_VARIANT_TYPE_STRING_NAME,
        GDEXTENSION_VARIANT_TYPE_NODE_PATH,
        GDEXTENSION_VARIANT_TYPE_RID,
        GDEXTENSION_VARIANT_TYPE_OBJECT,
        GDEXTENSION_VARIANT_TYPE_CALLABLE,
        GDEXTENSION_VARIANT_TYPE_SIGNAL,
        GDEXTENSION_VARIANT_TYPE_DICTIONARY,
        GDEXTENSION_VARIANT_TYPE_ARRAY,
        GDEXTENSION_VARIANT_TYPE_PACKED_BYTE_ARRAY,
        GDEXTENSION_VARIANT_TYPE_PACKED_INT32_ARRAY,
        GDEXTENSION_VARIANT_TYPE_PACKED_INT64_ARRAY,
        GDEXTENSION_VARIANT_TYPE_PACKED_FLOAT32_ARRAY,
        GDEXTENSION_VARIANT_TYPE_PACKED_FLOAT64_ARRAY,
        GDEXTENSION_VARIANT_TYPE_PACKED_STRING_ARRAY,
        GDEXTENSION_VARIANT_TYPE_PACKED_VECTOR2_ARRAY,
        GDEXTENSION_VARIANT_TYPE_PACKED_VECTOR3_ARRAY,
        GDEXTENSION_VARIANT_TYPE_PACKED_COLOR_ARRAY,
        GDEXTENSION_VARIANT_TYPE_VARIANT_MAX,
    }

    public enum GDExtensionVariantOperator
    {
        GDEXTENSION_VARIANT_OP_EQUAL,
        GDEXTENSION_VARIANT_OP_NOT_EQUAL,
        GDEXTENSION_VARIANT_OP_LESS,
        GDEXTENSION_VARIANT_OP_LESS_EQUAL,
        GDEXTENSION_VARIANT_OP_GREATER,
        GDEXTENSION_VARIANT_OP_GREATER_EQUAL,
        GDEXTENSION_VARIANT_OP_ADD,
        GDEXTENSION_VARIANT_OP_SUBTRACT,
        GDEXTENSION_VARIANT_OP_MULTIPLY,
        GDEXTENSION_VARIANT_OP_DIVIDE,
        GDEXTENSION_VARIANT_OP_NEGATE,
        GDEXTENSION_VARIANT_OP_POSITIVE,
        GDEXTENSION_VARIANT_OP_MODULE,
        GDEXTENSION_VARIANT_OP_POWER,
        GDEXTENSION_VARIANT_OP_SHIFT_LEFT,
        GDEXTENSION_VARIANT_OP_SHIFT_RIGHT,
        GDEXTENSION_VARIANT_OP_BIT_AND,
        GDEXTENSION_VARIANT_OP_BIT_OR,
        GDEXTENSION_VARIANT_OP_BIT_XOR,
        GDEXTENSION_VARIANT_OP_BIT_NEGATE,
        GDEXTENSION_VARIANT_OP_AND,
        GDEXTENSION_VARIANT_OP_OR,
        GDEXTENSION_VARIANT_OP_XOR,
        GDEXTENSION_VARIANT_OP_NOT,
        GDEXTENSION_VARIANT_OP_IN,
        GDEXTENSION_VARIANT_OP_MAX,
    }

    public enum GDExtensionCallErrorType
    {
        GDEXTENSION_CALL_OK,
        GDEXTENSION_CALL_ERROR_INVALID_METHOD,
        GDEXTENSION_CALL_ERROR_INVALID_ARGUMENT,
        GDEXTENSION_CALL_ERROR_TOO_MANY_ARGUMENTS,
        GDEXTENSION_CALL_ERROR_TOO_FEW_ARGUMENTS,
        GDEXTENSION_CALL_ERROR_INSTANCE_IS_NULL,
        GDEXTENSION_CALL_ERROR_METHOD_NOT_CONST,
    }

    public partial struct GDExtensionCallError
    {
        public GDExtensionCallErrorType error;

        [NativeTypeName("int32_t")]
        public int argument;

        [NativeTypeName("int32_t")]
        public int expected;
    }

    public unsafe partial struct GDExtensionInstanceBindingCallbacks
    {
        [NativeTypeName("GDExtensionInstanceBindingCreateCallback")]
        public delegate* unmanaged[Cdecl]<void*, void*, void*> create_callback;

        [NativeTypeName("GDExtensionInstanceBindingFreeCallback")]
        public delegate* unmanaged[Cdecl]<void*, void*, void*, void> free_callback;

        [NativeTypeName("GDExtensionInstanceBindingReferenceCallback")]
        public delegate* unmanaged[Cdecl]<void*, void*, byte, byte> reference_callback;
    }

    public unsafe partial struct GDExtensionPropertyInfo
    {
        public GDExtensionVariantType type;

        [NativeTypeName("GDExtensionStringNamePtr")]
        public void* name;

        [NativeTypeName("GDExtensionStringNamePtr")]
        public void* class_name;

        [NativeTypeName("uint32_t")]
        public uint hint;

        [NativeTypeName("GDExtensionStringPtr")]
        public void* hint_string;

        [NativeTypeName("uint32_t")]
        public uint usage;
    }

    public unsafe partial struct GDExtensionMethodInfo
    {
        [NativeTypeName("GDExtensionStringNamePtr")]
        public void* name;

        public GDExtensionPropertyInfo return_value;

        [NativeTypeName("uint32_t")]
        public uint flags;

        [NativeTypeName("int32_t")]
        public int id;

        [NativeTypeName("uint32_t")]
        public uint argument_count;

        public GDExtensionPropertyInfo* arguments;

        [NativeTypeName("uint32_t")]
        public uint default_argument_count;

        [NativeTypeName("GDExtensionVariantPtr *")]
        public void** default_arguments;
    }

    public unsafe partial struct GDExtensionClassCreationInfo
    {
        [NativeTypeName("GDExtensionBool")]
        public byte is_virtual;

        [NativeTypeName("GDExtensionBool")]
        public byte is_abstract;

        [NativeTypeName("GDExtensionClassSet")]
        public delegate* unmanaged[Cdecl]<void*, void*, void*, byte> set_func;

        [NativeTypeName("GDExtensionClassGet")]
        public delegate* unmanaged[Cdecl]<void*, void*, void*, byte> get_func;

        [NativeTypeName("GDExtensionClassGetPropertyList")]
        public delegate* unmanaged[Cdecl]<void*, uint*, GDExtensionPropertyInfo*> get_property_list_func;

        [NativeTypeName("GDExtensionClassFreePropertyList")]
        public delegate* unmanaged[Cdecl]<void*, GDExtensionPropertyInfo*, void> free_property_list_func;

        [NativeTypeName("GDExtensionClassPropertyCanRevert")]
        public delegate* unmanaged[Cdecl]<void*, void*, byte> property_can_revert_func;

        [NativeTypeName("GDExtensionClassPropertyGetRevert")]
        public delegate* unmanaged[Cdecl]<void*, void*, void*, byte> property_get_revert_func;

        [NativeTypeName("GDExtensionClassNotification")]
        public delegate* unmanaged[Cdecl]<void*, int, void> notification_func;

        [NativeTypeName("GDExtensionClassToString")]
        public delegate* unmanaged[Cdecl]<void*, byte*, void*, void> to_string_func;

        [NativeTypeName("GDExtensionClassReference")]
        public delegate* unmanaged[Cdecl]<void*, void> reference_func;

        [NativeTypeName("GDExtensionClassUnreference")]
        public delegate* unmanaged[Cdecl]<void*, void> unreference_func;

        [NativeTypeName("GDExtensionClassCreateInstance")]
        public delegate* unmanaged[Cdecl]<void*, void*> create_instance_func;

        [NativeTypeName("GDExtensionClassFreeInstance")]
        public delegate* unmanaged[Cdecl]<void*, void*, void> free_instance_func;

        [NativeTypeName("GDExtensionClassGetVirtual")]
        public delegate* unmanaged[Cdecl]<void*, void*, delegate* unmanaged[Cdecl]<void*, void**, void*, void>> get_virtual_func;

        [NativeTypeName("GDExtensionClassGetRID")]
        public delegate* unmanaged[Cdecl]<void*, ulong> get_rid_func;

        public void* class_userdata;
    }

    public unsafe partial struct GDExtensionClassCreationInfo2
    {
        [NativeTypeName("GDExtensionBool")]
        public byte is_virtual;

        [NativeTypeName("GDExtensionBool")]
        public byte is_abstract;

        [NativeTypeName("GDExtensionBool")]
        public byte is_exposed;

        [NativeTypeName("GDExtensionClassSet")]
        public delegate* unmanaged[Cdecl]<void*, void*, void*, byte> set_func;

        [NativeTypeName("GDExtensionClassGet")]
        public delegate* unmanaged[Cdecl]<void*, void*, void*, byte> get_func;

        [NativeTypeName("GDExtensionClassGetPropertyList")]
        public delegate* unmanaged[Cdecl]<void*, uint*, GDExtensionPropertyInfo*> get_property_list_func;

        [NativeTypeName("GDExtensionClassFreePropertyList")]
        public delegate* unmanaged[Cdecl]<void*, GDExtensionPropertyInfo*, void> free_property_list_func;

        [NativeTypeName("GDExtensionClassPropertyCanRevert")]
        public delegate* unmanaged[Cdecl]<void*, void*, byte> property_can_revert_func;

        [NativeTypeName("GDExtensionClassPropertyGetRevert")]
        public delegate* unmanaged[Cdecl]<void*, void*, void*, byte> property_get_revert_func;

        [NativeTypeName("GDExtensionClassValidateProperty")]
        public delegate* unmanaged[Cdecl]<void*, GDExtensionPropertyInfo*, byte> validate_property_func;

        [NativeTypeName("GDExtensionClassNotification2")]
        public delegate* unmanaged[Cdecl]<void*, int, byte, void> notification_func;

        [NativeTypeName("GDExtensionClassToString")]
        public delegate* unmanaged[Cdecl]<void*, byte*, void*, void> to_string_func;

        [NativeTypeName("GDExtensionClassReference")]
        public delegate* unmanaged[Cdecl]<void*, void> reference_func;

        [NativeTypeName("GDExtensionClassUnreference")]
        public delegate* unmanaged[Cdecl]<void*, void> unreference_func;

        [NativeTypeName("GDExtensionClassCreateInstance")]
        public delegate* unmanaged[Cdecl]<void*, void*> create_instance_func;

        [NativeTypeName("GDExtensionClassFreeInstance")]
        public delegate* unmanaged[Cdecl]<void*, void*, void> free_instance_func;

        [NativeTypeName("GDExtensionClassRecreateInstance")]
        public delegate* unmanaged[Cdecl]<void*, void*, void*> recreate_instance_func;

        [NativeTypeName("GDExtensionClassGetVirtual")]
        public delegate* unmanaged[Cdecl]<void*, void*, delegate* unmanaged[Cdecl]<void*, void**, void*, void>> get_virtual_func;

        [NativeTypeName("GDExtensionClassGetVirtualCallData")]
        public delegate* unmanaged[Cdecl]<void*, void*, void*> get_virtual_call_data_func;

        [NativeTypeName("GDExtensionClassCallVirtualWithData")]
        public delegate* unmanaged[Cdecl]<void*, void*, void*, void**, void*, void> call_virtual_with_data_func;

        [NativeTypeName("GDExtensionClassGetRID")]
        public delegate* unmanaged[Cdecl]<void*, ulong> get_rid_func;

        public void* class_userdata;
    }

    public enum GDExtensionClassMethodFlags
    {
        GDEXTENSION_METHOD_FLAG_NORMAL = 1,
        GDEXTENSION_METHOD_FLAG_EDITOR = 2,
        GDEXTENSION_METHOD_FLAG_CONST = 4,
        GDEXTENSION_METHOD_FLAG_VIRTUAL = 8,
        GDEXTENSION_METHOD_FLAG_VARARG = 16,
        GDEXTENSION_METHOD_FLAG_STATIC = 32,
        GDEXTENSION_METHOD_FLAGS_DEFAULT = GDEXTENSION_METHOD_FLAG_NORMAL,
    }

    public enum GDExtensionClassMethodArgumentMetadata
    {
        GDEXTENSION_METHOD_ARGUMENT_METADATA_NONE,
        GDEXTENSION_METHOD_ARGUMENT_METADATA_INT_IS_INT8,
        GDEXTENSION_METHOD_ARGUMENT_METADATA_INT_IS_INT16,
        GDEXTENSION_METHOD_ARGUMENT_METADATA_INT_IS_INT32,
        GDEXTENSION_METHOD_ARGUMENT_METADATA_INT_IS_INT64,
        GDEXTENSION_METHOD_ARGUMENT_METADATA_INT_IS_UINT8,
        GDEXTENSION_METHOD_ARGUMENT_METADATA_INT_IS_UINT16,
        GDEXTENSION_METHOD_ARGUMENT_METADATA_INT_IS_UINT32,
        GDEXTENSION_METHOD_ARGUMENT_METADATA_INT_IS_UINT64,
        GDEXTENSION_METHOD_ARGUMENT_METADATA_REAL_IS_FLOAT,
        GDEXTENSION_METHOD_ARGUMENT_METADATA_REAL_IS_DOUBLE,
    }

    public unsafe partial struct GDExtensionClassMethodInfo
    {
        [NativeTypeName("GDExtensionStringNamePtr")]
        public void* name;

        public void* method_userdata;

        [NativeTypeName("GDExtensionClassMethodCall")]
        public delegate* unmanaged[Cdecl]<void*, void*, void**, long, void*, GDExtensionCallError*, void> call_func;

        [NativeTypeName("GDExtensionClassMethodPtrCall")]
        public delegate* unmanaged[Cdecl]<void*, void*, void**, void*, void> ptrcall_func;

        [NativeTypeName("uint32_t")]
        public uint method_flags;

        [NativeTypeName("GDExtensionBool")]
        public byte has_return_value;

        public GDExtensionPropertyInfo* return_value_info;

        public GDExtensionClassMethodArgumentMetadata return_value_metadata;

        [NativeTypeName("uint32_t")]
        public uint argument_count;

        public GDExtensionPropertyInfo* arguments_info;

        public GDExtensionClassMethodArgumentMetadata* arguments_metadata;

        [NativeTypeName("uint32_t")]
        public uint default_argument_count;

        [NativeTypeName("GDExtensionVariantPtr *")]
        public void** default_arguments;
    }

    public unsafe partial struct GDExtensionCallableCustomInfo
    {
        public void* callable_userdata;

        public void* token;

        [NativeTypeName("GDExtensionObjectPtr")]
        public void* @object;

        [NativeTypeName("GDExtensionCallableCustomCall")]
        public delegate* unmanaged[Cdecl]<void*, void**, long, void*, GDExtensionCallError*, void> call_func;

        [NativeTypeName("GDExtensionCallableCustomIsValid")]
        public delegate* unmanaged[Cdecl]<void*, byte> is_valid_func;

        [NativeTypeName("GDExtensionCallableCustomFree")]
        public delegate* unmanaged[Cdecl]<void*, void> free_func;

        [NativeTypeName("GDExtensionCallableCustomHash")]
        public delegate* unmanaged[Cdecl]<void*, uint> hash_func;

        [NativeTypeName("GDExtensionCallableCustomEqual")]
        public delegate* unmanaged[Cdecl]<void*, void*, byte> equal_func;

        [NativeTypeName("GDExtensionCallableCustomLessThan")]
        public delegate* unmanaged[Cdecl]<void*, void*, byte> less_than_func;

        [NativeTypeName("GDExtensionCallableCustomToString")]
        public delegate* unmanaged[Cdecl]<void*, byte*, void*, void> to_string_func;
    }

    public unsafe partial struct GDExtensionScriptInstanceInfo
    {
        [NativeTypeName("GDExtensionScriptInstanceSet")]
        public delegate* unmanaged[Cdecl]<void*, void*, void*, byte> set_func;

        [NativeTypeName("GDExtensionScriptInstanceGet")]
        public delegate* unmanaged[Cdecl]<void*, void*, void*, byte> get_func;

        [NativeTypeName("GDExtensionScriptInstanceGetPropertyList")]
        public delegate* unmanaged[Cdecl]<void*, uint*, GDExtensionPropertyInfo*> get_property_list_func;

        [NativeTypeName("GDExtensionScriptInstanceFreePropertyList")]
        public delegate* unmanaged[Cdecl]<void*, GDExtensionPropertyInfo*, void> free_property_list_func;

        [NativeTypeName("GDExtensionScriptInstancePropertyCanRevert")]
        public delegate* unmanaged[Cdecl]<void*, void*, byte> property_can_revert_func;

        [NativeTypeName("GDExtensionScriptInstancePropertyGetRevert")]
        public delegate* unmanaged[Cdecl]<void*, void*, void*, byte> property_get_revert_func;

        [NativeTypeName("GDExtensionScriptInstanceGetOwner")]
        public delegate* unmanaged[Cdecl]<void*, void*> get_owner_func;

        [NativeTypeName("GDExtensionScriptInstanceGetPropertyState")]
        public delegate* unmanaged[Cdecl]<void*, delegate* unmanaged[Cdecl]<void*, void*, void*, void>, void*, void> get_property_state_func;

        [NativeTypeName("GDExtensionScriptInstanceGetMethodList")]
        public delegate* unmanaged[Cdecl]<void*, uint*, GDExtensionMethodInfo*> get_method_list_func;

        [NativeTypeName("GDExtensionScriptInstanceFreeMethodList")]
        public delegate* unmanaged[Cdecl]<void*, GDExtensionMethodInfo*, void> free_method_list_func;

        [NativeTypeName("GDExtensionScriptInstanceGetPropertyType")]
        public delegate* unmanaged[Cdecl]<void*, void*, byte*, GDExtensionVariantType> get_property_type_func;

        [NativeTypeName("GDExtensionScriptInstanceHasMethod")]
        public delegate* unmanaged[Cdecl]<void*, void*, byte> has_method_func;

        [NativeTypeName("GDExtensionScriptInstanceCall")]
        public delegate* unmanaged[Cdecl]<void*, void*, void**, long, void*, GDExtensionCallError*, void> call_func;

        [NativeTypeName("GDExtensionScriptInstanceNotification")]
        public delegate* unmanaged[Cdecl]<void*, int, void> notification_func;

        [NativeTypeName("GDExtensionScriptInstanceToString")]
        public delegate* unmanaged[Cdecl]<void*, byte*, void*, void> to_string_func;

        [NativeTypeName("GDExtensionScriptInstanceRefCountIncremented")]
        public delegate* unmanaged[Cdecl]<void*, void> refcount_incremented_func;

        [NativeTypeName("GDExtensionScriptInstanceRefCountDecremented")]
        public delegate* unmanaged[Cdecl]<void*, byte> refcount_decremented_func;

        [NativeTypeName("GDExtensionScriptInstanceGetScript")]
        public delegate* unmanaged[Cdecl]<void*, void*> get_script_func;

        [NativeTypeName("GDExtensionScriptInstanceIsPlaceholder")]
        public delegate* unmanaged[Cdecl]<void*, byte> is_placeholder_func;

        [NativeTypeName("GDExtensionScriptInstanceSet")]
        public delegate* unmanaged[Cdecl]<void*, void*, void*, byte> set_fallback_func;

        [NativeTypeName("GDExtensionScriptInstanceGet")]
        public delegate* unmanaged[Cdecl]<void*, void*, void*, byte> get_fallback_func;

        [NativeTypeName("GDExtensionScriptInstanceGetLanguage")]
        public delegate* unmanaged[Cdecl]<void*, void*> get_language_func;

        [NativeTypeName("GDExtensionScriptInstanceFree")]
        public delegate* unmanaged[Cdecl]<void*, void> free_func;
    }

    public unsafe partial struct GDExtensionScriptInstanceInfo2
    {
        [NativeTypeName("GDExtensionScriptInstanceSet")]
        public delegate* unmanaged[Cdecl]<void*, void*, void*, byte> set_func;

        [NativeTypeName("GDExtensionScriptInstanceGet")]
        public delegate* unmanaged[Cdecl]<void*, void*, void*, byte> get_func;

        [NativeTypeName("GDExtensionScriptInstanceGetPropertyList")]
        public delegate* unmanaged[Cdecl]<void*, uint*, GDExtensionPropertyInfo*> get_property_list_func;

        [NativeTypeName("GDExtensionScriptInstanceFreePropertyList")]
        public delegate* unmanaged[Cdecl]<void*, GDExtensionPropertyInfo*, void> free_property_list_func;

        [NativeTypeName("GDExtensionScriptInstanceGetClassCategory")]
        public delegate* unmanaged[Cdecl]<void*, GDExtensionPropertyInfo*, byte> get_class_category_func;

        [NativeTypeName("GDExtensionScriptInstancePropertyCanRevert")]
        public delegate* unmanaged[Cdecl]<void*, void*, byte> property_can_revert_func;

        [NativeTypeName("GDExtensionScriptInstancePropertyGetRevert")]
        public delegate* unmanaged[Cdecl]<void*, void*, void*, byte> property_get_revert_func;

        [NativeTypeName("GDExtensionScriptInstanceGetOwner")]
        public delegate* unmanaged[Cdecl]<void*, void*> get_owner_func;

        [NativeTypeName("GDExtensionScriptInstanceGetPropertyState")]
        public delegate* unmanaged[Cdecl]<void*, delegate* unmanaged[Cdecl]<void*, void*, void*, void>, void*, void> get_property_state_func;

        [NativeTypeName("GDExtensionScriptInstanceGetMethodList")]
        public delegate* unmanaged[Cdecl]<void*, uint*, GDExtensionMethodInfo*> get_method_list_func;

        [NativeTypeName("GDExtensionScriptInstanceFreeMethodList")]
        public delegate* unmanaged[Cdecl]<void*, GDExtensionMethodInfo*, void> free_method_list_func;

        [NativeTypeName("GDExtensionScriptInstanceGetPropertyType")]
        public delegate* unmanaged[Cdecl]<void*, void*, byte*, GDExtensionVariantType> get_property_type_func;

        [NativeTypeName("GDExtensionScriptInstanceValidateProperty")]
        public delegate* unmanaged[Cdecl]<void*, GDExtensionPropertyInfo*, byte> validate_property_func;

        [NativeTypeName("GDExtensionScriptInstanceHasMethod")]
        public delegate* unmanaged[Cdecl]<void*, void*, byte> has_method_func;

        [NativeTypeName("GDExtensionScriptInstanceCall")]
        public delegate* unmanaged[Cdecl]<void*, void*, void**, long, void*, GDExtensionCallError*, void> call_func;

        [NativeTypeName("GDExtensionScriptInstanceNotification2")]
        public delegate* unmanaged[Cdecl]<void*, int, byte, void> notification_func;

        [NativeTypeName("GDExtensionScriptInstanceToString")]
        public delegate* unmanaged[Cdecl]<void*, byte*, void*, void> to_string_func;

        [NativeTypeName("GDExtensionScriptInstanceRefCountIncremented")]
        public delegate* unmanaged[Cdecl]<void*, void> refcount_incremented_func;

        [NativeTypeName("GDExtensionScriptInstanceRefCountDecremented")]
        public delegate* unmanaged[Cdecl]<void*, byte> refcount_decremented_func;

        [NativeTypeName("GDExtensionScriptInstanceGetScript")]
        public delegate* unmanaged[Cdecl]<void*, void*> get_script_func;

        [NativeTypeName("GDExtensionScriptInstanceIsPlaceholder")]
        public delegate* unmanaged[Cdecl]<void*, byte> is_placeholder_func;

        [NativeTypeName("GDExtensionScriptInstanceSet")]
        public delegate* unmanaged[Cdecl]<void*, void*, void*, byte> set_fallback_func;

        [NativeTypeName("GDExtensionScriptInstanceGet")]
        public delegate* unmanaged[Cdecl]<void*, void*, void*, byte> get_fallback_func;

        [NativeTypeName("GDExtensionScriptInstanceGetLanguage")]
        public delegate* unmanaged[Cdecl]<void*, void*> get_language_func;

        [NativeTypeName("GDExtensionScriptInstanceFree")]
        public delegate* unmanaged[Cdecl]<void*, void> free_func;
    }

    public enum GDExtensionInitializationLevel
    {
        GDEXTENSION_INITIALIZATION_CORE,
        GDEXTENSION_INITIALIZATION_SERVERS,
        GDEXTENSION_INITIALIZATION_SCENE,
        GDEXTENSION_INITIALIZATION_EDITOR,
        GDEXTENSION_MAX_INITIALIZATION_LEVEL,
    }

    public unsafe partial struct GDExtensionInitialization
    {
        public GDExtensionInitializationLevel minimum_initialization_level;

        public void* userdata;

        [NativeTypeName("void (*)(void *, GDExtensionInitializationLevel)")]
        public delegate* unmanaged[Cdecl]<void*, GDExtensionInitializationLevel, void> initialize;

        [NativeTypeName("void (*)(void *, GDExtensionInitializationLevel)")]
        public delegate* unmanaged[Cdecl]<void*, GDExtensionInitializationLevel, void> deinitialize;
    }

    public unsafe partial struct GDExtensionGodotVersion
    {
        [NativeTypeName("uint32_t")]
        public uint major;

        [NativeTypeName("uint32_t")]
        public uint minor;

        [NativeTypeName("uint32_t")]
        public uint patch;

        [NativeTypeName("const char *")]
        public sbyte* @string;
    }
}
