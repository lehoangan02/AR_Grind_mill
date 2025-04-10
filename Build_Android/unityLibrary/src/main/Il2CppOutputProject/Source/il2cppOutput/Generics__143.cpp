#include "pch-cpp.hpp"





template <typename T1>
struct InvokerActionInvoker1;
template <typename T1>
struct InvokerActionInvoker1<T1*>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1)
	{
		void* params[1] = { p1 };
		method->invoker_method(methodPtr, method, obj, params, params[0]);
	}
};
template <typename T1, typename T2>
struct InvokerActionInvoker2;
template <typename T1, typename T2>
struct InvokerActionInvoker2<T1, T2*>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1 p1, T2* p2)
	{
		void* params[2] = { &p1, p2 };
		method->invoker_method(methodPtr, method, obj, params, params[1]);
	}
};
template <typename T1, typename T2, typename T3>
struct InvokerActionInvoker3;
template <typename T1, typename T2, typename T3>
struct InvokerActionInvoker3<T1*, T2, T3*>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1, T2 p2, T3* p3)
	{
		void* params[3] = { p1, &p2, p3 };
		method->invoker_method(methodPtr, method, obj, params, params[2]);
	}
};
template <typename R, typename T1, typename T2, typename T3, typename T4>
struct InvokerFuncInvoker4;
template <typename R, typename T1, typename T2, typename T3, typename T4>
struct InvokerFuncInvoker4<R, T1*, T2*, T3*, T4*>
{
	static inline R Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1, T2* p2, T3* p3, T4* p4)
	{
		R ret;
		void* params[4] = { p1, p2, p3, p4 };
		method->invoker_method(methodPtr, method, obj, params, &ret);
		return ret;
	}
};
template <typename R>
struct ConstrainedFuncInvoker0
{
	static inline R Invoke (RuntimeClass* type, const RuntimeMethod* constrainedMethod, void* boxBuffer, void* obj)
	{
		R ret;
		il2cpp_codegen_runtime_constrained_call(type, constrainedMethod, boxBuffer, obj, NULL, &ret);
		return ret;
	}
};
template <typename R, typename T1>
struct ConstrainedFuncInvoker1;
template <typename R, typename T1>
struct ConstrainedFuncInvoker1<R, T1*>
{
	static inline R Invoke (RuntimeClass* type, const RuntimeMethod* constrainedMethod, void* boxBuffer, void* obj, T1* p1)
	{
		R ret;
		void* params[1] = { p1 };
		il2cpp_codegen_runtime_constrained_call(type, constrainedMethod, boxBuffer, obj, params, &ret);
		return ret;
	}
};

struct IEnumerator_1_tC46762DF28C9BF8FE752C6F44A38BC938B7C63F2;
struct IEnumerator_1_t81508BA1795BEFA635A0ABD00A3527125DE40487;
struct IEnumerator_1_t80F674C00482B1AB19D5A993DD22F11AC95A1FA5;
struct IEnumerator_1_tC31A80105AF2F05F8C3C2C0EC8DB84247A490E7C;
struct List_1_t8F0684E22184B81BF891DD99A3E16491E68B58B5;
struct UnsafeParallelHashMapDebuggerTypeProxy_2_t4A34F2944E65F462B1CA05BC595902280B2A97F4;
struct Pair_2U5BU5D_tA93C79DD20E7E202CC93D8B5B7C60A312699AA16;
struct CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB;
struct IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832;
struct StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF;
struct Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3;
struct IDictionary_t6D03155AF1FA9083817AA5B6AD7DEEACC26AB220;
struct IEnumerator_t7B609C2FFA6EB5167D9C62A0C32A21DE2F666DAA;
struct NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8;
struct SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6;
struct String_t;
struct UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926;
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;
struct OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D;
struct SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A;
struct Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127;

IL2CPP_EXTERN_C RuntimeClass* AllocatorManager_tFB15A22029C8159A3DCD4C08935BE57D3E6B3C2C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8_il2cpp_TypeInfo_var;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;


IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
struct List_1_t8F0684E22184B81BF891DD99A3E16491E68B58B5  : public RuntimeObject
{
	Pair_2U5BU5D_tA93C79DD20E7E202CC93D8B5B7C60A312699AA16* ____items;
	int32_t ____size;
	int32_t ____version;
	RuntimeObject* ____syncRoot;
};
struct AllocatorManager_tFB15A22029C8159A3DCD4C08935BE57D3E6B3C2C  : public RuntimeObject
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};
struct NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC 
{
	int32_t ___key;
	int32_t ___NextEntryIndex;
	int32_t ___EntryIndex;
};
struct NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B 
{
	uint32_t ___key;
	int32_t ___NextEntryIndex;
	int32_t ___EntryIndex;
};
typedef Il2CppFullySharedGenericStruct NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51;
typedef Il2CppFullySharedGenericStruct Pair_2_tD9FD7901920962567EFA915194252C62C833F9F6;
typedef Il2CppFullySharedGenericStruct Pair_2_tF8A435CDED15A96555BAB1E37C58429B2FF464A6;
struct ParallelWriter_t725B9E76F960232582498637DEF16962C7959261 
{
	UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___m_Buffer;
	int32_t ___m_ThreadIndex;
};
struct UnsafeParallelHashMapBase_2_tE32A0E6514398F89C1AE8F4A64B3404FD606044F 
{
};
struct UnsafeParallelHashMapBase_2_tBB457536F8C60DEE9AB3B04D227F6FCE63A3A88D 
{
};
struct UnsafeParallelHashMapBase_2_t1BD0CA3528161BCA85DBE75C9AF94C4416025CF9 
{
};
struct UnsafeParallelHashMapBase_2_tB81581C8DF1653B9F1D459135F67A53788D63A3B 
{
};
struct UnsafeParallelHashMapBase_2_t4EE797D67C7F49F863E9976C0A176AFAD26DE32A 
{
};
struct UnsafeParallelHashMapBase_2_t1974D8A21AC8F349CCFED6168093C9FE5AE773C4 
{
};
struct UnsafeParallelHashMapBase_2_tB0C02E0D42773FC6279148955479C9F639550ECC 
{
};
struct UnsafeParallelHashMapBase_2_t71E2732E8CAEDE80F025D72E9D186280FCF68561 
{
};
struct UnsafeParallelHashMapBase_2_tC9A90870EF7154E90FC350CFEC5BAF8C8F35A4C0 
{
};
struct BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770 
{
	uint32_t ___value;
};
struct BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C 
{
	uint32_t ___value;
};
struct BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0 
{
	uint32_t ___value;
};
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	bool ___m_value;
};
struct Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3 
{
	uint8_t ___m_value;
};
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2  : public ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F
{
};
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_marshaled_pinvoke
{
};
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_marshaled_com
{
};
struct GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78 
{
	int32_t ___U3CindexU3Ek__BackingField;
};
struct InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B 
{
	int32_t ___U3CindexU3Ek__BackingField;
};
struct Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C 
{
	int32_t ___m_value;
};
struct Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3 
{
	int64_t ___m_value;
};
struct IntPtr_t 
{
	void* ___m_value;
};
struct UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B 
{
	uint32_t ___m_value;
};
struct UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926 
{
	union
	{
		#pragma pack(push, tp, 1)
		struct
		{
			uint8_t* ___values;
		};
		#pragma pack(pop, tp)
		struct
		{
			uint8_t* ___values_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___keys_OffsetPadding[8];
			uint8_t* ___keys;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___keys_OffsetPadding_forAlignmentOnly[8];
			uint8_t* ___keys_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___next_OffsetPadding[16];
			uint8_t* ___next;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___next_OffsetPadding_forAlignmentOnly[16];
			uint8_t* ___next_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___buckets_OffsetPadding[24];
			uint8_t* ___buckets;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___buckets_OffsetPadding_forAlignmentOnly[24];
			uint8_t* ___buckets_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___keyCapacity_OffsetPadding[32];
			int32_t ___keyCapacity;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___keyCapacity_OffsetPadding_forAlignmentOnly[32];
			int32_t ___keyCapacity_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___bucketCapacityMask_OffsetPadding[36];
			int32_t ___bucketCapacityMask;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___bucketCapacityMask_OffsetPadding_forAlignmentOnly[36];
			int32_t ___bucketCapacityMask_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			char ___allocatedIndexLength_OffsetPadding[40];
			int32_t ___allocatedIndexLength;
		};
		#pragma pack(pop, tp)
		struct
		{
			char ___allocatedIndexLength_OffsetPadding_forAlignmentOnly[40];
			int32_t ___allocatedIndexLength_forAlignmentOnly;
		};
	};
};
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};
struct float4_t89D9A294E7A79BD81BFBDD18654508532958555E 
{
	float ___x;
	float ___y;
	float ___z;
	float ___w;
};
struct AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 
{
	uint16_t ___Index;
	uint16_t ___Version;
};
struct OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D 
{
	bool ___valid;
	int32_t ___lastUsedFrameIndex;
	int32_t ___viewInstanceID;
};
struct OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D_marshaled_pinvoke
{
	int32_t ___valid;
	int32_t ___lastUsedFrameIndex;
	int32_t ___viewInstanceID;
};
struct OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D_marshaled_com
{
	int32_t ___valid;
	int32_t ___lastUsedFrameIndex;
	int32_t ___viewInstanceID;
};
struct Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 
{
	bool ___isActive;
	int32_t ___viewInstanceID;
	int32_t ___planeCount;
	int32_t ___lastUsedFrameIndex;
};
struct Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127_marshaled_pinvoke
{
	int32_t ___isActive;
	int32_t ___viewInstanceID;
	int32_t ___planeCount;
	int32_t ___lastUsedFrameIndex;
};
struct Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127_marshaled_com
{
	int32_t ___isActive;
	int32_t ___viewInstanceID;
	int32_t ___planeCount;
	int32_t ___lastUsedFrameIndex;
};
struct UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA 
{
	OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* ___Ptr;
	int32_t ___m_length;
	int32_t ___m_capacity;
	AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___Allocator;
	int32_t ___padding;
};
struct UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C 
{
	SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* ___Ptr;
	int32_t ___m_length;
	int32_t ___m_capacity;
	AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___Allocator;
	int32_t ___padding;
};
struct UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7 
{
	Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* ___Ptr;
	int32_t ___m_length;
	int32_t ___m_capacity;
	AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___Allocator;
	int32_t ___padding;
};
struct UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271 
{
	UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___m_Buffer;
	AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___m_AllocatorLabel;
};
struct UnsafeParallelHashMap_2_t05EF7F8F2EB540DAE81F93C169AC7E6849413707 
{
	UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___m_Buffer;
	AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___m_AllocatorLabel;
};
struct Allocator_t996642592271AAD9EE688F142741D512C07B5824 
{
	int32_t ___value__;
};
struct BatchDrawCommandFlags_tC502FA322382A3181F0800B1EA5A5654027FE034 
{
	int32_t ___value__;
};
struct Exception_t  : public RuntimeObject
{
	String_t* ____className;
	String_t* ____message;
	RuntimeObject* ____data;
	Exception_t* ____innerException;
	String_t* ____helpURL;
	RuntimeObject* ____stackTrace;
	String_t* ____stackTraceString;
	String_t* ____remoteStackTraceString;
	int32_t ____remoteStackIndex;
	RuntimeObject* ____dynamicMethods;
	int32_t ____HResult;
	String_t* ____source;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces;
	IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832* ___native_trace_ips;
	int32_t ___caught_in_unmanaged;
};
struct Exception_t_marshaled_pinvoke
{
	char* ____className;
	char* ____message;
	RuntimeObject* ____data;
	Exception_t_marshaled_pinvoke* ____innerException;
	char* ____helpURL;
	Il2CppIUnknown* ____stackTrace;
	char* ____stackTraceString;
	char* ____remoteStackTraceString;
	int32_t ____remoteStackIndex;
	Il2CppIUnknown* ____dynamicMethods;
	int32_t ____HResult;
	char* ____source;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces;
	Il2CppSafeArray* ___native_trace_ips;
	int32_t ___caught_in_unmanaged;
};
struct Exception_t_marshaled_com
{
	Il2CppChar* ____className;
	Il2CppChar* ____message;
	RuntimeObject* ____data;
	Exception_t_marshaled_com* ____innerException;
	Il2CppChar* ____helpURL;
	Il2CppIUnknown* ____stackTrace;
	Il2CppChar* ____stackTraceString;
	Il2CppChar* ____remoteStackTraceString;
	int32_t ____remoteStackIndex;
	Il2CppIUnknown* ____dynamicMethods;
	int32_t ____HResult;
	Il2CppChar* ____source;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces;
	Il2CppSafeArray* ___native_trace_ips;
	int32_t ___caught_in_unmanaged;
};
struct MotionVectorGenerationMode_tE87C61556749260EF5429A0F8FE55DAD30EEAFCB 
{
	int32_t ___value__;
};
struct NativeArrayOptions_t3E979EEF4B4840228A7692A97DA07553C6465F1D 
{
	int32_t ___value__;
};
struct ShadowCastingMode_tF30806698B37CF120A1A506BD7549EAF308E7C6D 
{
	int32_t ___value__;
};
struct SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A 
{
	float4_t89D9A294E7A79BD81BFBDD18654508532958555E ___receiverSphereLightSpace;
	float ___cascadeBlendCullingFactor;
};
struct NativeArray_1_t2FF0F1BBD323229A2F9ABD52397EA6EF9B105E09 
{
	void* ___m_Buffer;
	int32_t ___m_Length;
	int32_t ___m_AllocatorLabel;
};
struct NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C 
{
	void* ___m_Buffer;
	int32_t ___m_Length;
	int32_t ___m_AllocatorLabel;
};
struct NativeArray_1_tDB8B8DC66CC8E16ED6D9A8C75D2C1AFC80AC1E18 
{
	void* ___m_Buffer;
	int32_t ___m_Length;
	int32_t ___m_AllocatorLabel;
};
struct NativeArray_1_t0C50A3E7F549E148C8748605A2BC3D9BB1BC80DF 
{
	void* ___m_Buffer;
	int32_t ___m_Length;
	int32_t ___m_AllocatorLabel;
};
struct NativeArray_1_t933EB4C2ED1CCB3C68D5E2EC18C770C2893C8443 
{
	void* ___m_Buffer;
	int32_t ___m_Length;
	int32_t ___m_AllocatorLabel;
};
struct NativeArray_1_tB8D8B86A987B7E27BD621893A826604AA3A66C5C 
{
	void* ___m_Buffer;
	int32_t ___m_Length;
	int32_t ___m_AllocatorLabel;
};
struct UnsafeParallelHashMapDebuggerTypeProxy_2_t4A34F2944E65F462B1CA05BC595902280B2A97F4  : public RuntimeObject
{
	UnsafeParallelHashMap_2_t05EF7F8F2EB540DAE81F93C169AC7E6849413707 ___m_Target;
};
struct RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C 
{
	uint8_t ___layer;
	uint32_t ___renderingLayerMask;
	int32_t ___motionMode;
	int32_t ___shadowCastingMode;
	bool ___staticShadowCaster;
	int32_t ___rendererPriority;
	bool ___supportsIndirect;
};
struct RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C_marshaled_pinvoke
{
	uint8_t ___layer;
	uint32_t ___renderingLayerMask;
	int32_t ___motionMode;
	int32_t ___shadowCastingMode;
	int32_t ___staticShadowCaster;
	int32_t ___rendererPriority;
	int32_t ___supportsIndirect;
};
struct RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C_marshaled_com
{
	uint8_t ___layer;
	uint32_t ___renderingLayerMask;
	int32_t ___motionMode;
	int32_t ___shadowCastingMode;
	int32_t ___staticShadowCaster;
	int32_t ___rendererPriority;
	int32_t ___supportsIndirect;
};
struct SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295  : public Exception_t
{
};
struct NativeKeyValueArrays_2_t6F346645686D9ED3DF9980242A60F6343D9BD346 
{
	NativeArray_1_t2FF0F1BBD323229A2F9ABD52397EA6EF9B105E09 ___Keys;
	NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C ___Values;
};
struct NativeKeyValueArrays_2_t97DEBC72840B73CFCEE6195C4C495C675E96FAF1 
{
	NativeArray_1_tDB8B8DC66CC8E16ED6D9A8C75D2C1AFC80AC1E18 ___Keys;
	NativeArray_1_tDB8B8DC66CC8E16ED6D9A8C75D2C1AFC80AC1E18 ___Values;
};
struct NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727 
{
	RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C ___key;
	int32_t ___NextEntryIndex;
	int32_t ___EntryIndex;
};
struct DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 
{
	BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0 ___meshID;
	int32_t ___submeshIndex;
	BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C ___materialID;
	int32_t ___flags;
	int32_t ___transparentInstanceId;
	uint32_t ___overridenComponents;
	RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C ___range;
	int32_t ___lightmapIndex;
};
struct DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_marshaled_pinvoke
{
	BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0 ___meshID;
	int32_t ___submeshIndex;
	BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C ___materialID;
	int32_t ___flags;
	int32_t ___transparentInstanceId;
	uint32_t ___overridenComponents;
	RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C_marshaled_pinvoke ___range;
	int32_t ___lightmapIndex;
};
struct DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_marshaled_com
{
	BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0 ___meshID;
	int32_t ___submeshIndex;
	BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C ___materialID;
	int32_t ___flags;
	int32_t ___transparentInstanceId;
	uint32_t ___overridenComponents;
	RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C_marshaled_com ___range;
	int32_t ___lightmapIndex;
};
struct NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
};
struct NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A 
{
	DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___key;
	int32_t ___NextEntryIndex;
	int32_t ___EntryIndex;
};
struct List_1_t8F0684E22184B81BF891DD99A3E16491E68B58B5_StaticFields
{
	Pair_2U5BU5D_tA93C79DD20E7E202CC93D8B5B7C60A312699AA16* ___s_emptyArray;
};
struct AllocatorManager_tFB15A22029C8159A3DCD4C08935BE57D3E6B3C2C_StaticFields
{
	AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___Invalid;
	AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___None;
	AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___Temp;
	AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___TempJob;
	AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___Persistent;
	AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___AudioKernel;
	uint16_t ___NumGlobalScratchAllocators;
	uint16_t ___MaxNumGlobalAllocators;
	uint32_t ___GlobalAllocatorBaseIndex;
	uint32_t ___FirstGlobalScratchpadAllocatorIndex;
};
struct BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770_StaticFields
{
	BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770 ___Null;
};
struct BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C_StaticFields
{
	BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C ___Null;
};
struct BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0_StaticFields
{
	BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0 ___Null;
};
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	String_t* ___TrueString;
	String_t* ___FalseString;
};
struct GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78_StaticFields
{
	GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78 ___Invalid;
};
struct InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B_StaticFields
{
	InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B ___Invalid;
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif


IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t UnsafeList_1_get_Length_m2673797C6B1B5ED6A4C644298C555559E56C2682_gshared_inline (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t UnsafeList_1_get_Capacity_mE66A788D02ACCA321ADEC1D5939D6A0CC38E4A59_gshared_inline (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_Resize_m89BDE747429473AE232DB084BC36EF48F3AB388D_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_length, int32_t ___1_options, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_set_Length_m6423940AFC690B5C652FD231D5C2E7836ECE70B1_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_SetCapacity_m01856897AA0378888156C6C865FD2DF003259402_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_capacity, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_set_Capacity_mAB36448D47F99512F264E69A11C23435D531D148_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_value, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D UnsafeList_1_get_Item_mE621D922A067844ECFB3EC3FD5CAF0F18284C825_gshared_inline (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_index, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeList_1_set_Item_m36035574C8D1A1555A348CD8F326A3FB2F57A28B_gshared_inline (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_index, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D ___1_value, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* UnsafeList_1_ElementAt_mDD19B169590525B93B12C98E9AD8209253E9A14B_gshared_inline (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_index, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1__ctor_m78B8DF184E817B787E1312BB4D0201ADE648B464_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_initialCapacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___1_allocator, int32_t ___2_options, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_Dispose_m7B6479F22BFCA86FEE3DEC0A150D235AD33C0C07_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AllocatorManager_Free_TisUnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA_m12AAB43E03ED61A46066096547F98A862672EC89_gshared (AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___0_handle, UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* ___1_pointer, int32_t ___2_items, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool UnsafeList_1_get_IsCreated_m51C65B44C2F88F5642E21BC850480BAEEA7EA65D_gshared_inline (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool UnsafeList_1_get_IsEmpty_m923A6014BAA5DC0E86E533ACE70D5C441A3F37DD_gshared_inline (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AllocatorManager_Free_TisOccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D_m1D8738CAAA65C0C8EE9CEC9F7E1D134982B6EEC1_gshared (AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___0_handle, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* ___1_pointer, int32_t ___2_items, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_Clear_mD1843F62E98923982BE1E628A12286716B6B088D_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_ResizeExact_TisAllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148_m7A38863CD3BF2355094DE46CB04CD7523D63E2B5_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148* ___0_allocator, int32_t ___1_newCapacity, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_ResizeExact_mC34252029ACF4302C3D7CEE4BFAD197FDEF9B63F_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_capacity, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_SetCapacity_TisAllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148_m967AD73DBFD45924CADA85BB4CCFE0F67C073288_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148* ___0_allocator, int32_t ___1_capacity, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_TrimExcess_m1E1A21C4F507B272A2375B26F3572B6CD5940FEC_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeUtility_WriteArrayElement_TisOccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D_mFCD82994FD19F18D338DCAB93FEA4EA811589FC1_gshared_inline (void* ___0_destination, int32_t ___1_index, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D ___2_value, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeList_1_AddNoResize_m4C7CDA5A177C8AAE7272628C31A4981DFC474F33_gshared_inline (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_AddRangeNoResize_m58B18264D9443085CDF9ED97B68B29680BFC3B62_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, void* ___0_ptr, int32_t ___1_count, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_AddRangeNoResize_m53CEB7657BE8E2303312C186BAEF91C9E5CE6409_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA ___0_list, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeList_1_Add_m1821E69B90EE213D7B3B9509F69E635B52C61023_gshared_inline (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_AddRange_m97C70050DCA30C2909EE9DA07B283929020C8D11_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, void* ___0_ptr, int32_t ___1_count, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t UnsafeUtility_SizeOf_TisOccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D_m06F3769E28E215E9E08FE78C81E8E16F99336462_gshared_inline (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_AddReplicate_m924A083227B0EDD370314CD100023B4432F88B94_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* ___0_value, int32_t ___1_count, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_InsertRangeWithBeginEnd_mBDCC51B7FA7F5EFACE0959F2459FE88366220CA6_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_begin, int32_t ___1_end, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_RemoveAtSwapBack_m5846A3BBEB108590536A902E1263230006034835_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_index, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_RemoveRangeSwapBack_mD9731A61259B247E3209E90E4F68CD7F5446C91A_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_index, int32_t ___1_count, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_RemoveAt_mA48E14773A1A1F3D33BFC4F6D907E9CE2F3F5572_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_index, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_RemoveRange_mBDC19D7AC8AAECCEDB16C1F074E25D44CF7BCF48_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_index, int32_t ___1_count, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void* NativeArrayUnsafeUtility_GetUnsafeReadOnlyPtr_TisOccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D_m20BD626E48A9A87C9D0D502474419CE8FF67F7FF_gshared (NativeArray_1_t0C50A3E7F549E148C8748605A2BC3D9BB1BC80DF ___0_nativeArray, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_CopyFrom_mAEFF28DF5C4A27B95A43F4D0425359B898657114_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, NativeArray_1_t0C50A3E7F549E148C8748605A2BC3D9BB1BC80DF* ___0_other, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_CopyFrom_m21D16EB2A77EF551D3EF9DB20BBEE2E38507E1B7_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* ___0_other, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* UnsafeList_1_System_Collections_IEnumerable_GetEnumerator_mECC392B2D508A11712F173B4D1BEC8B9D5DDC9FE_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* UnsafeList_1_System_Collections_Generic_IEnumerableU3CTU3E_GetEnumerator_mF33B0D1056CA3743A4B22D07D84B959D46B0D027_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t UnsafeList_1_get_Length_m30C8B237736009EBD4E69E7D215B9650233D037C_gshared_inline (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t UnsafeList_1_get_Capacity_mD86B514B3119D3E1A021A6CB23BE78590F5E486E_gshared_inline (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_Resize_mF872E9A04824A2B9B2B673782565D043892D31D9_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_length, int32_t ___1_options, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_set_Length_mB77496A4A78A181D3CBFC6AC25BE562DE37F318B_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_SetCapacity_mAD7D5D59FEB13EAF12B15B9FC0BBDEA7546A4563_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_capacity, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_set_Capacity_mB8A4248D3F6458D1D9E98A7BEC320E14BD41D3B7_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_value, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A UnsafeList_1_get_Item_m5047BC7B1C0732A194FACD8C079EC28A64A5F79D_gshared_inline (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_index, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeList_1_set_Item_m2D938DC73BF3B2D244FB9468EBECDFA52B986B7B_gshared_inline (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_index, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A ___1_value, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* UnsafeList_1_ElementAt_m9B7ADAC368CB917E0318285D89CD070BFFC7E2F9_gshared_inline (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_index, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1__ctor_mA5748C7F18591A66AAEA5CEDACA2A12FC57EFAD3_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_initialCapacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___1_allocator, int32_t ___2_options, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_Dispose_m007CA9BE61EF7FB5A88A2E9AFEBD3611A4DEF29C_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AllocatorManager_Free_TisUnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C_m1BCBC66CBB14BBD523F4C3A7F94F5170FC8CE363_gshared (AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___0_handle, UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* ___1_pointer, int32_t ___2_items, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool UnsafeList_1_get_IsCreated_mB1B61C071EA40B095E886B5298E0C3C54ED9A853_gshared_inline (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool UnsafeList_1_get_IsEmpty_mFB3CDB4407674F5F2A7D1859C9FB368CC9077F1A_gshared_inline (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AllocatorManager_Free_TisSplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A_m74C86DFA3B9611772049B4B5336DC3B36C731649_gshared (AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___0_handle, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* ___1_pointer, int32_t ___2_items, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_Clear_mFE93F82A6E8896D8E46E491623D85BE9BC2AE2C3_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_ResizeExact_TisAllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148_mE85365421923BB85B9248CAA9CEB34945B35C737_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148* ___0_allocator, int32_t ___1_newCapacity, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_ResizeExact_m7128F30F2118629FF89940C16F4046F9515FEF6B_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_capacity, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_SetCapacity_TisAllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148_m410651EE83B2047EEB067E0586569B723265B37B_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148* ___0_allocator, int32_t ___1_capacity, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_TrimExcess_m974AE258DEBD1BCDCD20A7E4630CE26296EDF43D_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeUtility_WriteArrayElement_TisSplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A_m4F71D70C126C24C918F9E6237DC37C71726A6CE8_gshared_inline (void* ___0_destination, int32_t ___1_index, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A ___2_value, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeList_1_AddNoResize_mDD1844EF5F4B0A230D4C6141E4A6A3EF83521A5C_gshared_inline (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_AddRangeNoResize_m6C41571D7107A9C270662661CCEEF34BDD32682F_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, void* ___0_ptr, int32_t ___1_count, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_AddRangeNoResize_mD850AF553A2F8263EDE3E1F7A1A886A2C7EAFCD4_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C ___0_list, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeList_1_Add_mE02101A02348C4FE5C69658E032EB2BC5E2B0EC1_gshared_inline (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_AddRange_m290AF2611869D3059792B0EDCF2DEAC70AE35CB6_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, void* ___0_ptr, int32_t ___1_count, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t UnsafeUtility_SizeOf_TisSplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A_m6C96A05E2AC56907C62A2A917FE69A67EB3F72FB_gshared_inline (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_AddReplicate_mA8C22B3C32A081106A17337AA53882D8CA92A49F_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* ___0_value, int32_t ___1_count, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_InsertRangeWithBeginEnd_mC5402628584EC1224906861332995DD894031938_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_begin, int32_t ___1_end, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_RemoveAtSwapBack_mDE564A4CC3B47BF28AF0D1CF99A43A4E84210AAF_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_index, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_RemoveRangeSwapBack_m100F1A29384A20C6513B0D434D60DC7E66828D2F_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_index, int32_t ___1_count, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_RemoveAt_mAE596941D78BA2014C3E3048ABDAEEC7CE5D5227_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_index, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_RemoveRange_m85604203599589C689C82B1071C5629617C4E5C2_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_index, int32_t ___1_count, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void* NativeArrayUnsafeUtility_GetUnsafeReadOnlyPtr_TisSplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A_mEA7A2AAE07DCFD8DAB7122AEC01806A98F3AE6CE_gshared (NativeArray_1_t933EB4C2ED1CCB3C68D5E2EC18C770C2893C8443 ___0_nativeArray, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_CopyFrom_m65DBB0C13CA29FE140BCD0FEB1993C55723C3252_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, NativeArray_1_t933EB4C2ED1CCB3C68D5E2EC18C770C2893C8443* ___0_other, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_CopyFrom_m836376D9E1B104ABFC8471073E2D9A8A65B7B5D3_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* ___0_other, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* UnsafeList_1_System_Collections_IEnumerable_GetEnumerator_mB1A8B4B473D9E1667ADF1B265CA1C7E59274D7AA_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* UnsafeList_1_System_Collections_Generic_IEnumerableU3CTU3E_GetEnumerator_mF2DFB1A66D985398367765F12E3ADB88D01D05C0_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t UnsafeList_1_get_Length_mFE9C02C4C7169AE23DE6BC1B834E0DBC1D03DBB1_gshared_inline (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t UnsafeList_1_get_Capacity_m9C10840F54FD1F0871C1C7E25CE7AF92622DF9AD_gshared_inline (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_Resize_mA8E41BF0D06DD764B65618C554B138588019DCA9_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_length, int32_t ___1_options, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_set_Length_m053843BFA1C2D31E71CC871DE1B08DE91BF01416_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_SetCapacity_mBBADF24575202AD2F6156C29CD6DB788AB15C5C8_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_capacity, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_set_Capacity_mC07B19231AD2F3637381CBAF53723C4BCE13CF40_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_value, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 UnsafeList_1_get_Item_mEFA75FB7304D5FFEA7E3F6226B01453D10013A3B_gshared_inline (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_index, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeList_1_set_Item_m0B5139C9A3714A3C5E0B576AB276E1A0FCA406B9_gshared_inline (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_index, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 ___1_value, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* UnsafeList_1_ElementAt_m43B542F9E0F11A380A8AC0435939688D55836A0D_gshared_inline (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_index, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1__ctor_m5D36D9B673FEB6B6B5DDAA6DBA2D1773B13C0C2D_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_initialCapacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___1_allocator, int32_t ___2_options, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_Dispose_mE60AFFB718C0BD8A36BDF427B8BC76F17D46FF80_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AllocatorManager_Free_TisUnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7_m2ACD46900DC49986AE7EA226E807CF511B3DF9DD_gshared (AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___0_handle, UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* ___1_pointer, int32_t ___2_items, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool UnsafeList_1_get_IsCreated_m4B100662A0B454C46725BE8CEC4A746E61835062_gshared_inline (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool UnsafeList_1_get_IsEmpty_m436BA19BA9C162ACC4DB0819037CBB975135A952_gshared_inline (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AllocatorManager_Free_TisSlot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127_mA83D7FD9125891D2119A7B1F691163E0C357ADA6_gshared (AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___0_handle, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* ___1_pointer, int32_t ___2_items, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_Clear_m7323877F6C7EBAD0F7EE4CAD4E1DF7F7A417BCAF_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_ResizeExact_TisAllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148_mDAF433094E4F5C8022D2D327C78F8213DC96CF97_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148* ___0_allocator, int32_t ___1_newCapacity, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_ResizeExact_mD71C35B2525653A8A0734B25902643471D9934FF_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_capacity, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_SetCapacity_TisAllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148_m6F2A7EE715E1620965BB586860D3D44B3D8F6BA3_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148* ___0_allocator, int32_t ___1_capacity, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_TrimExcess_mE3AF5AF66473695DE2F8698576DE9A28301D871F_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeUtility_WriteArrayElement_TisSlot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127_m4F77AC19B6051E7566C5A3561715FC4CB8D462AF_gshared_inline (void* ___0_destination, int32_t ___1_index, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 ___2_value, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeList_1_AddNoResize_m884048B32C3E428BD16BB73C3162E27F1B3EF326_gshared_inline (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_AddRangeNoResize_mD2A2918E38DFA75F76BF852015F849DAC06AD533_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, void* ___0_ptr, int32_t ___1_count, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_AddRangeNoResize_m8521348DD738300ECE4F77B891B87A9833DA5A7D_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7 ___0_list, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeList_1_Add_m405283315301E592556E27548D759262F9B0C52F_gshared_inline (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_AddRange_mFA03E69A70D0F6E2A7A0E1255D4E8A9DD997902A_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, void* ___0_ptr, int32_t ___1_count, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t UnsafeUtility_SizeOf_TisSlot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127_m9A004D5E211035E85A1BBF1B521142792C4F0A57_gshared_inline (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_AddReplicate_m12CE42900BA193AD08AF2BC7899C808C524A6F52_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* ___0_value, int32_t ___1_count, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_InsertRangeWithBeginEnd_mC123A52689F34B06EF3678FC2FE08792548531AC_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_begin, int32_t ___1_end, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_RemoveAtSwapBack_mB73019BC253FE72CA0B0757417C73E132680B248_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_index, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_RemoveRangeSwapBack_mAF5F28360809AB7A2E68FBA1D993B6F9C43B3564_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_index, int32_t ___1_count, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_RemoveAt_m7E96DC2F31FA5485A37D45BA007E1FC8043D4CF2_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_index, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_RemoveRange_mB4B17E74CEE3C443B6749D3A3B52FC9598401C46_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_index, int32_t ___1_count, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void* NativeArrayUnsafeUtility_GetUnsafeReadOnlyPtr_TisSlot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127_m33C547D554717D3EAFA0EDFB786DE05EA69EAA85_gshared (NativeArray_1_tB8D8B86A987B7E27BD621893A826604AA3A66C5C ___0_nativeArray, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_CopyFrom_mF6E6FAF3CEEB14EF5B4177580034AFDA1CD1A33A_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, NativeArray_1_tB8D8B86A987B7E27BD621893A826604AA3A66C5C* ___0_other, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_CopyFrom_m5C64DE802A570C7DCECE59B4859091A58686F23A_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* ___0_other, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* UnsafeList_1_System_Collections_IEnumerable_GetEnumerator_mBE9931F96650CD707D42AE0625B0B34CD2CA9307_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* UnsafeList_1_System_Collections_Generic_IEnumerableU3CTU3E_GetEnumerator_m6576E2C347279C70D752C163781D0115578818BB_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mC42AE53B9C096C5437713AA40D89EB873678D78F_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___1_key, int32_t* ___2_item, NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A* ___3_it, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapBase_2_AllocEntry_m6564DDE54C96DB6027C802DDB51638722A8B7A9C_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_threadIndex, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeUtility_WriteArrayElement_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_mAC61BCD78DBCF3665AB62CF3F0A9160131582E7C_gshared_inline (void* ___0_destination, int32_t ___1_index, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___2_value, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeUtility_WriteArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m0DD1CC90B2F1EF5041F2F4E1DABB58224229F0D7_gshared_inline (void* ___0_destination, int32_t ___1_index, int32_t ___2_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_FreeEntry_mE62A9F90862B9AF9BF01C07B0A17F0C8F2372D6D_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_idx, int32_t ___2_threadIndex, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapData_ReallocateHashMap_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m74D70D8E65D60A3A3B782011BC925E749F8C29C8_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_newCapacity, int32_t ___2_newBucketCapacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___3_label, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 UnsafeUtility_ReadArrayElement_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_mFD7DBC1199616005466125347027F6201459B40D_gshared_inline (void* ___0_source, int32_t ___1_index, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_mAFEFFB673EC0E6AACC6C9F4ECEBB1ACA52A589B0_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t* ___1_item, NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A* ___2_it, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t UnsafeUtility_ReadArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_mFBA66C06ECEB0A2BC1AAE634B6E6BB436F957084_gshared_inline (void* ___0_source, int32_t ___1_index, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_m97E032CD6E0F90AFEDAFAF6FC9790EAEFAD4D38F_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C* ___2_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___3_it, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapBase_2_AllocEntry_m74EB5C8C921F13820DB035CF8DA58E1FB942A142_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_threadIndex, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeUtility_WriteArrayElement_TisBatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C_m32FE612078445C09645A5FEFCADD35BF1B5497D3_gshared_inline (void* ___0_destination, int32_t ___1_index, BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C ___2_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_FreeEntry_m900571E61B5A7712D4C2358CC8B337805E654A03_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_idx, int32_t ___2_threadIndex, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapData_ReallocateHashMap_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_TisBatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C_m0D3BC53501025D0E6FFB93ADC9A6861B58849FE5_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_newCapacity, int32_t ___2_newBucketCapacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___3_label, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m5D25900ED3545AA3E3F72977EB6F728351B3D361_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C* ___1_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___2_it, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C UnsafeUtility_ReadArrayElement_TisBatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C_mDE41FFE3160D153E47D8D93EF29E4B9C3DB23D20_gshared_inline (void* ___0_source, int32_t ___1_index, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_m0A1550FEB428909B2E587F9AA67DD634D414D678_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0* ___2_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___3_it, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapBase_2_AllocEntry_m8AD3BCA9FB9188688CEFCD9B8C98668A2AB7D334_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_threadIndex, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeUtility_WriteArrayElement_TisBatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0_m0CA08285DF610E216621F21C754D8D5E56428B01_gshared_inline (void* ___0_destination, int32_t ___1_index, BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0 ___2_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_FreeEntry_m68049D0DC47E97C465D43753CAAFAF997DE7804C_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_idx, int32_t ___2_threadIndex, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapData_ReallocateHashMap_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_TisBatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0_m7276C3EA10AA4289184C4478EC7CE69B78E70B2C_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_newCapacity, int32_t ___2_newBucketCapacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___3_label, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_mAC37A0DE4D5678D35DF0C57E71A79D74CB486CAE_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0* ___1_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___2_it, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0 UnsafeUtility_ReadArrayElement_TisBatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0_mD0CAE37D791EB711A170B7F9BDCEAB6ED472C3E3_gshared_inline (void* ___0_source, int32_t ___1_index, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_m6DF4FDD33DF0500B90F89611D3B0EB217FBE80A9_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78* ___2_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___3_it, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapBase_2_AllocEntry_mA6D1BF0531A4B163ED154D98E5AC42EBF6BA5F3D_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_threadIndex, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeUtility_WriteArrayElement_TisGPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78_mFC4E3A09D0F9A76B3DA65553F10F7EF785896EEA_gshared_inline (void* ___0_destination, int32_t ___1_index, GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78 ___2_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_FreeEntry_m8FD2ED9C81D1A54D0D5D33B66435A7B5E8E4C65E_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_idx, int32_t ___2_threadIndex, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapData_ReallocateHashMap_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_TisGPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78_m5EEA3CF56A858CE6C8B93F86EBD5D9E0EC019D09_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_newCapacity, int32_t ___2_newBucketCapacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___3_label, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m3453F1516A7747F6CB50AA7E83EFF9D33D9D1325_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78* ___1_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___2_it, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78 UnsafeUtility_ReadArrayElement_TisGPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78_mF42F014B5AA9C633D3FCAB3FFF26646E54395BD8_gshared_inline (void* ___0_source, int32_t ___1_index, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mA5FCFB37B4C19FD5FF7B0660AAE55181A6A68C1F_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B* ___2_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___3_it, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapBase_2_AllocEntry_mA60C7AAB43656E7611E27393BC6AB7E52163A000_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_threadIndex, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeUtility_WriteArrayElement_TisInstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B_m2D4905CE9CCFB4EF383D04FA0F872F621E08A309_gshared_inline (void* ___0_destination, int32_t ___1_index, InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B ___2_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_FreeEntry_mC0307320846285CEBB98C0EF64D1880A4876EBB6_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_idx, int32_t ___2_threadIndex, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapData_ReallocateHashMap_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_TisInstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B_mD9CA815618E4ED4EC44B7F5D9D7ACF7649BEF9AF_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_newCapacity, int32_t ___2_newBucketCapacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___3_label, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m907C21D03B0B07E416159F61AE6322D367A27C05_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B* ___1_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___2_it, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B UnsafeUtility_ReadArrayElement_TisInstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B_m86FC76E325E9D3B56133BB7A193BAF12B47FBCC1_gshared_inline (void* ___0_source, int32_t ___1_index, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_m8FA051F1386B583A2848E886020D563EE0004112_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, int32_t* ___2_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___3_it, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapBase_2_AllocEntry_m800AD0805A8FEA87F79C267739A0F557ACA44015_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_threadIndex, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_FreeEntry_m8927ACA31388B65E99B4E0301130276415771390_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_idx, int32_t ___2_threadIndex, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapData_ReallocateHashMap_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m526C9313C8BCF707526B309126FFB7502C548A5D_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_newCapacity, int32_t ___2_newBucketCapacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___3_label, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m3A37DD53E6586935E3AAC304D3AB4EF2AFF4A905_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t* ___1_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___2_it, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mA75399BF08E0CCAC328234FD7A71D864467E95C2_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C ___1_key, int32_t* ___2_item, NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727* ___3_it, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapBase_2_AllocEntry_m57B325EFF67BD5485331BD2F287B463A5D8FC9C8_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_threadIndex, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeUtility_WriteArrayElement_TisRangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C_m6E993EC5F50FC82EDD84AF158A50E9FF2BAE2705_gshared_inline (void* ___0_destination, int32_t ___1_index, RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C ___2_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_FreeEntry_m95E0C2203337A917B366551260F10DD9AA00924A_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_idx, int32_t ___2_threadIndex, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapData_ReallocateHashMap_TisRangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m337E81148B331D4822C7412A962A569B8D2ADC59_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_newCapacity, int32_t ___2_newBucketCapacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___3_label, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C UnsafeUtility_ReadArrayElement_TisRangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C_mFDF2C4591B5F4C0AF4424ED681225F9CF100C5BB_gshared_inline (void* ___0_source, int32_t ___1_index, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m92F223FB6B0005A83CA9AC122EEB656E520F55AC_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t* ___1_item, NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727* ___2_it, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mEB3EEF401A3CDD197AC9DE490B9CAA5F3415FBE5_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, uint32_t ___1_key, BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770* ___2_item, NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B* ___3_it, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapBase_2_AllocEntry_m87F60C86A474B557B069D37548567CB2667C42FA_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_threadIndex, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeUtility_WriteArrayElement_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_m839FEB3192BEC0090FBA73A11E371E1A01C13ADF_gshared_inline (void* ___0_destination, int32_t ___1_index, uint32_t ___2_value, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeUtility_WriteArrayElement_TisBatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770_m60CD2C2DE2B559F255B8BEA36B0554E698FF9651_gshared_inline (void* ___0_destination, int32_t ___1_index, BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770 ___2_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_FreeEntry_m8D99BED2AEF823C1F525AF6D51D018736E33922F_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_idx, int32_t ___2_threadIndex, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapData_ReallocateHashMap_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_TisBatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770_mC740151B18F0E9F81E90C5B066A052BAB9F361C4_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_newCapacity, int32_t ___2_newBucketCapacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___3_label, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint32_t UnsafeUtility_ReadArrayElement_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_mDA80BAFF55EA77496672B3B5B3804B55274B7E95_gshared_inline (void* ___0_source, int32_t ___1_index, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m3C59C500D6E8A033EFFAD29EA56E615156D25D1D_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770* ___1_item, NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B* ___2_it, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770 UnsafeUtility_ReadArrayElement_TisBatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770_m80C61348EC8F9D4F73F0AAA4A69A028E6D599DCD_gshared_inline (void* ___0_source, int32_t ___1_index, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NativeKeyValueArrays_2_Dispose_m08B6A4226A0125C6123942BE90703D08153CCE37_gshared (NativeKeyValueArrays_2_t97DEBC72840B73CFCEE6195C4C495C675E96FAF1* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Pair_2__ctor_mCA54688368FE894C9F314471A3DA94A72B709F51_gshared (Pair_2_tF8A435CDED15A96555BAB1E37C58429B2FF464A6* __this, Il2CppFullySharedGenericAny ___0_k, Il2CppFullySharedGenericAny ___1_v, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapData_AllocateHashMap_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m720B963A1A8BA6E3EF6204599F7B1AE86C47B938_gshared (int32_t ___0_length, int32_t ___1_bucketLength, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___2_label, UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926** ___3_outBuf, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMap_2_Clear_mC24DF6084AB7BA5AECAF2DFE3C8D80CD6EEE830C_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMap_2__ctor_mAC8F198D20B98C2819447D8E080EBF2F2714BFFE_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, int32_t ___0_capacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___1_allocator, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool UnsafeParallelHashMap_2_get_IsCreated_m21986D033E89DA3F44B7D0C5B99F57C93E9FBFCC_gshared_inline (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool UnsafeParallelHashMap_2_get_IsEmpty_m2EB3B4B325AAF39DA286FF82FDB26405AE271998_gshared_inline (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMap_2_Count_m3B17849FD6E9AEFC745138B43A5F5924BDA651A6_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMap_2_get_Capacity_m5516D69B8E5C8A61A3B8112E3B0C0DC701FDEF20_gshared_inline (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMap_2_set_Capacity_mD1D227DF7720121254BBE5435F29C5CB94D97831_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, int32_t ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_Clear_mEFDB8CAFDB397D0E8A4279CA11C361A29EC8A4BB_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapBase_2_Remove_mD0A7EC52AF9067A81379B898E9F19FA26F3F4B88_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___1_key, bool ___2_isMultiHashMap, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMap_2_Remove_mE398837783AB4D7D5B1519D6B47F03F029B40A9A_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___0_key, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMap_2_TryGetValue_m6B967A3210A9091B292D0A38D4D8A190E5DC59A6_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___0_key, int32_t* ___1_item, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMap_2_ContainsKey_mFBBB13C3C28724EEB5E77C8EBCF29B6EFEAE9C8C_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___0_key, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_SetValue_mBC2EB4E62A5FAA365C4795E1D7FA3F3ED271F97A_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A* ___1_it, int32_t* ___2_item, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryAdd_m7575B5C2D0CB741CCB79BFF102B543F951D1A91A_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___1_key, int32_t ___2_item, bool ___3_isMultiHashMap, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___4_allocation, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMap_2_set_Item_m78B278F2F9ECFF6DD543068ED4A22897FFEA5017_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___0_key, int32_t ___1_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMap_2_Dispose_m90F628584C865984113787BB0EC79383B00A069C_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NativeArray_1_t2FF0F1BBD323229A2F9ABD52397EA6EF9B105E09 CollectionHelper_CreateNativeArray_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_mAF52A80BBB617F62596D58F8FFD9E3E6AA9DB60F_gshared (int32_t ___0_length, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___1_allocator, int32_t ___2_options, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapData_GetKeyArray_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_m49E855A91D083A54CFF44DEB13335123AD3C4001_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, NativeArray_1_t2FF0F1BBD323229A2F9ABD52397EA6EF9B105E09 ___1_result, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NativeArray_1_t2FF0F1BBD323229A2F9ABD52397EA6EF9B105E09 UnsafeParallelHashMap_2_GetKeyArray_m0790F3B72CBA21D7B667E1A333E76DEAC8678138_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___0_allocator, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C CollectionHelper_CreateNativeArray_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m53D2BC04C5127B3B1163A395E36386918CACFE4B_gshared (int32_t ___0_length, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___1_allocator, int32_t ___2_options, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapData_GetValueArray_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m4769F528CC3AB04D768F83B2A2A016AE29C5F87E_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C ___1_result, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C UnsafeParallelHashMap_2_GetValueArray_m28E06E6A40485B8C1E9CEB5D9AD5DCEB3FD937B7_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___0_allocator, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NativeKeyValueArrays_2__ctor_m5C1BD5C2D8BD4FE03EC32866EEDF2EBECAB7B7F3_gshared (NativeKeyValueArrays_2_t6F346645686D9ED3DF9980242A60F6343D9BD346* __this, int32_t ___0_length, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___1_allocator, int32_t ___2_options, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapData_GetKeyValueArrays_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_mC3C2330139E264EC4EB952292BE242F6511CA8E6_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, NativeKeyValueArrays_2_t6F346645686D9ED3DF9980242A60F6343D9BD346 ___1_result, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NativeKeyValueArrays_2_t6F346645686D9ED3DF9980242A60F6343D9BD346 UnsafeParallelHashMap_2_GetKeyValueArrays_mBAD0B630B8637FBD3415B9CA1EB4912C07A0183A_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___0_allocator, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ParallelWriter_t725B9E76F960232582498637DEF16962C7959261 UnsafeParallelHashMap_2_AsParallelWriter_mBB99B9D2617627AD5097AA220071CE11F5F93C2D_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* UnsafeParallelHashMap_2_System_Collections_Generic_IEnumerableU3CUnity_Collections_LowLevel_Unsafe_KeyValueU3CTKeyU2CTValueU3EU3E_GetEnumerator_m22AAA28BF2A503A1A9ACC7D180DA65A1F2AA0A86_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* UnsafeParallelHashMap_2_System_Collections_IEnumerable_GetEnumerator_m1F6D4EBACBE01E83D9F84CF51098880680AFA3B5_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method) ;

IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline (int32_t ___0_value, const RuntimeMethod* method) ;
inline int32_t UnsafeList_1_get_Length_m2673797C6B1B5ED6A4C644298C555559E56C2682_inline (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, const RuntimeMethod*))UnsafeList_1_get_Length_m2673797C6B1B5ED6A4C644298C555559E56C2682_gshared_inline)(__this, method);
}
inline int32_t UnsafeList_1_get_Capacity_mE66A788D02ACCA321ADEC1D5939D6A0CC38E4A59_inline (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, const RuntimeMethod*))UnsafeList_1_get_Capacity_mE66A788D02ACCA321ADEC1D5939D6A0CC38E4A59_gshared_inline)(__this, method);
}
inline void UnsafeList_1_Resize_m89BDE747429473AE232DB084BC36EF48F3AB388D (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_length, int32_t ___1_options, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, int32_t, int32_t, const RuntimeMethod*))UnsafeList_1_Resize_m89BDE747429473AE232DB084BC36EF48F3AB388D_gshared)(__this, ___0_length, ___1_options, method);
}
inline void UnsafeList_1_set_Length_m6423940AFC690B5C652FD231D5C2E7836ECE70B1 (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_value, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, int32_t, const RuntimeMethod*))UnsafeList_1_set_Length_m6423940AFC690B5C652FD231D5C2E7836ECE70B1_gshared)(__this, ___0_value, method);
}
inline void UnsafeList_1_SetCapacity_m01856897AA0378888156C6C865FD2DF003259402 (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_capacity, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, int32_t, const RuntimeMethod*))UnsafeList_1_SetCapacity_m01856897AA0378888156C6C865FD2DF003259402_gshared)(__this, ___0_capacity, method);
}
inline void UnsafeList_1_set_Capacity_mAB36448D47F99512F264E69A11C23435D531D148 (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_value, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, int32_t, const RuntimeMethod*))UnsafeList_1_set_Capacity_mAB36448D47F99512F264E69A11C23435D531D148_gshared)(__this, ___0_value, method);
}
inline OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D UnsafeList_1_get_Item_mE621D922A067844ECFB3EC3FD5CAF0F18284C825_inline (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_index, const RuntimeMethod* method)
{
	return ((  OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, int32_t, const RuntimeMethod*))UnsafeList_1_get_Item_mE621D922A067844ECFB3EC3FD5CAF0F18284C825_gshared_inline)(__this, ___0_index, method);
}
inline void UnsafeList_1_set_Item_m36035574C8D1A1555A348CD8F326A3FB2F57A28B_inline (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_index, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D ___1_value, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, int32_t, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D, const RuntimeMethod*))UnsafeList_1_set_Item_m36035574C8D1A1555A348CD8F326A3FB2F57A28B_gshared_inline)(__this, ___0_index, ___1_value, method);
}
inline OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* UnsafeList_1_ElementAt_mDD19B169590525B93B12C98E9AD8209253E9A14B_inline (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_index, const RuntimeMethod* method)
{
	return ((  OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, int32_t, const RuntimeMethod*))UnsafeList_1_ElementAt_mDD19B169590525B93B12C98E9AD8209253E9A14B_gshared_inline)(__this, ___0_index, method);
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t math_max_m9083201D37A8ED0157B127B5878D9B7F3A2A40BE_inline (int32_t ___0_x, int32_t ___1_y, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeUtility_MemClear_m6C4377117084A11A667A567BC2F5E606A632A7C1 (void* ___0_destination, int64_t ___1_size, const RuntimeMethod* method) ;
inline void UnsafeList_1__ctor_m78B8DF184E817B787E1312BB4D0201ADE648B464 (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_initialCapacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___1_allocator, int32_t ___2_options, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, int32_t, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148, int32_t, const RuntimeMethod*))UnsafeList_1__ctor_m78B8DF184E817B787E1312BB4D0201ADE648B464_gshared)(__this, ___0_initialCapacity, ___1_allocator, ___2_options, method);
}
inline void UnsafeList_1_Dispose_m7B6479F22BFCA86FEE3DEC0A150D235AD33C0C07 (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, const RuntimeMethod*))UnsafeList_1_Dispose_m7B6479F22BFCA86FEE3DEC0A150D235AD33C0C07_gshared)(__this, method);
}
inline void AllocatorManager_Free_TisUnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA_m12AAB43E03ED61A46066096547F98A862672EC89 (AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___0_handle, UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* ___1_pointer, int32_t ___2_items, const RuntimeMethod* method)
{
	((  void (*) (AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148, UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, int32_t, const RuntimeMethod*))AllocatorManager_Free_TisUnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA_m12AAB43E03ED61A46066096547F98A862672EC89_gshared)(___0_handle, ___1_pointer, ___2_items, method);
}
inline bool UnsafeList_1_get_IsCreated_m51C65B44C2F88F5642E21BC850480BAEEA7EA65D_inline (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, const RuntimeMethod*))UnsafeList_1_get_IsCreated_m51C65B44C2F88F5642E21BC850480BAEEA7EA65D_gshared_inline)(__this, method);
}
inline bool UnsafeList_1_get_IsEmpty_m923A6014BAA5DC0E86E533ACE70D5C441A3F37DD_inline (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, const RuntimeMethod*))UnsafeList_1_get_IsEmpty_m923A6014BAA5DC0E86E533ACE70D5C441A3F37DD_gshared_inline)(__this, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool CollectionHelper_ShouldDeallocate_m505E7EDBA71F02BAF52CC9DCD7C593CDA85D5465 (AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___0_allocator, const RuntimeMethod* method) ;
inline void AllocatorManager_Free_TisOccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D_m1D8738CAAA65C0C8EE9CEC9F7E1D134982B6EEC1 (AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___0_handle, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* ___1_pointer, int32_t ___2_items, const RuntimeMethod* method)
{
	((  void (*) (AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*, int32_t, const RuntimeMethod*))AllocatorManager_Free_TisOccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D_m1D8738CAAA65C0C8EE9CEC9F7E1D134982B6EEC1_gshared)(___0_handle, ___1_pointer, ___2_items, method);
}
inline void UnsafeList_1_Clear_mD1843F62E98923982BE1E628A12286716B6B088D (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, const RuntimeMethod*))UnsafeList_1_Clear_mD1843F62E98923982BE1E628A12286716B6B088D_gshared)(__this, method);
}
inline void UnsafeList_1_ResizeExact_TisAllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148_m7A38863CD3BF2355094DE46CB04CD7523D63E2B5 (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148* ___0_allocator, int32_t ___1_newCapacity, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148*, int32_t, const RuntimeMethod*))UnsafeList_1_ResizeExact_TisAllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148_m7A38863CD3BF2355094DE46CB04CD7523D63E2B5_gshared)(__this, ___0_allocator, ___1_newCapacity, method);
}
inline void UnsafeList_1_ResizeExact_mC34252029ACF4302C3D7CEE4BFAD197FDEF9B63F (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_capacity, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, int32_t, const RuntimeMethod*))UnsafeList_1_ResizeExact_mC34252029ACF4302C3D7CEE4BFAD197FDEF9B63F_gshared)(__this, ___0_capacity, method);
}
inline void UnsafeList_1_SetCapacity_TisAllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148_m967AD73DBFD45924CADA85BB4CCFE0F67C073288 (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148* ___0_allocator, int32_t ___1_capacity, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148*, int32_t, const RuntimeMethod*))UnsafeList_1_SetCapacity_TisAllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148_m967AD73DBFD45924CADA85BB4CCFE0F67C073288_gshared)(__this, ___0_allocator, ___1_capacity, method);
}
inline void UnsafeList_1_TrimExcess_m1E1A21C4F507B272A2375B26F3572B6CD5940FEC (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, const RuntimeMethod*))UnsafeList_1_TrimExcess_m1E1A21C4F507B272A2375B26F3572B6CD5940FEC_gshared)(__this, method);
}
inline void UnsafeUtility_WriteArrayElement_TisOccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D_mFCD82994FD19F18D338DCAB93FEA4EA811589FC1_inline (void* ___0_destination, int32_t ___1_index, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D ___2_value, const RuntimeMethod* method)
{
	((  void (*) (void*, int32_t, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D, const RuntimeMethod*))UnsafeUtility_WriteArrayElement_TisOccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D_mFCD82994FD19F18D338DCAB93FEA4EA811589FC1_gshared_inline)(___0_destination, ___1_index, ___2_value, method);
}
inline void UnsafeList_1_AddNoResize_m4C7CDA5A177C8AAE7272628C31A4981DFC474F33_inline (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D ___0_value, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D, const RuntimeMethod*))UnsafeList_1_AddNoResize_m4C7CDA5A177C8AAE7272628C31A4981DFC474F33_gshared_inline)(__this, ___0_value, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeUtility_MemCpy_m5CEA91ACDADC522E584AE3A2AB2B0B74393A9177 (void* ___0_destination, void* ___1_source, int64_t ___2_size, const RuntimeMethod* method) ;
inline void UnsafeList_1_AddRangeNoResize_m58B18264D9443085CDF9ED97B68B29680BFC3B62 (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, void* ___0_ptr, int32_t ___1_count, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, void*, int32_t, const RuntimeMethod*))UnsafeList_1_AddRangeNoResize_m58B18264D9443085CDF9ED97B68B29680BFC3B62_gshared)(__this, ___0_ptr, ___1_count, method);
}
inline void UnsafeList_1_AddRangeNoResize_m53CEB7657BE8E2303312C186BAEF91C9E5CE6409 (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA ___0_list, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA, const RuntimeMethod*))UnsafeList_1_AddRangeNoResize_m53CEB7657BE8E2303312C186BAEF91C9E5CE6409_gshared)(__this, ___0_list, method);
}
inline void UnsafeList_1_Add_m1821E69B90EE213D7B3B9509F69E635B52C61023_inline (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* ___0_value, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*, const RuntimeMethod*))UnsafeList_1_Add_m1821E69B90EE213D7B3B9509F69E635B52C61023_gshared_inline)(__this, ___0_value, method);
}
inline void UnsafeList_1_AddRange_m97C70050DCA30C2909EE9DA07B283929020C8D11 (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, void* ___0_ptr, int32_t ___1_count, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, void*, int32_t, const RuntimeMethod*))UnsafeList_1_AddRange_m97C70050DCA30C2909EE9DA07B283929020C8D11_gshared)(__this, ___0_ptr, ___1_count, method);
}
inline int32_t UnsafeUtility_SizeOf_TisOccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D_m06F3769E28E215E9E08FE78C81E8E16F99336462_inline (const RuntimeMethod* method)
{
	return ((  int32_t (*) (const RuntimeMethod*))UnsafeUtility_SizeOf_TisOccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D_m06F3769E28E215E9E08FE78C81E8E16F99336462_gshared_inline)(method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeUtility_MemCpyReplicate_m0432429C10859D5BE79799A6E98B44741244287F (void* ___0_destination, void* ___1_source, int32_t ___2_size, int32_t ___3_count, const RuntimeMethod* method) ;
inline void UnsafeList_1_AddReplicate_m924A083227B0EDD370314CD100023B4432F88B94 (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* ___0_value, int32_t ___1_count, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*, int32_t, const RuntimeMethod*))UnsafeList_1_AddReplicate_m924A083227B0EDD370314CD100023B4432F88B94_gshared)(__this, ___0_value, ___1_count, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeUtility_MemMove_m4799FAA9C4BCFA1AEDC6ED01BB9A6DF657C4CEE3 (void* ___0_destination, void* ___1_source, int64_t ___2_size, const RuntimeMethod* method) ;
inline void UnsafeList_1_InsertRangeWithBeginEnd_mBDCC51B7FA7F5EFACE0959F2459FE88366220CA6 (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_begin, int32_t ___1_end, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, int32_t, int32_t, const RuntimeMethod*))UnsafeList_1_InsertRangeWithBeginEnd_mBDCC51B7FA7F5EFACE0959F2459FE88366220CA6_gshared)(__this, ___0_begin, ___1_end, method);
}
inline void UnsafeList_1_RemoveAtSwapBack_m5846A3BBEB108590536A902E1263230006034835 (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_index, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, int32_t, const RuntimeMethod*))UnsafeList_1_RemoveAtSwapBack_m5846A3BBEB108590536A902E1263230006034835_gshared)(__this, ___0_index, method);
}
inline void UnsafeList_1_RemoveRangeSwapBack_mD9731A61259B247E3209E90E4F68CD7F5446C91A (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_index, int32_t ___1_count, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, int32_t, int32_t, const RuntimeMethod*))UnsafeList_1_RemoveRangeSwapBack_mD9731A61259B247E3209E90E4F68CD7F5446C91A_gshared)(__this, ___0_index, ___1_count, method);
}
inline void UnsafeList_1_RemoveAt_mA48E14773A1A1F3D33BFC4F6D907E9CE2F3F5572 (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_index, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, int32_t, const RuntimeMethod*))UnsafeList_1_RemoveAt_mA48E14773A1A1F3D33BFC4F6D907E9CE2F3F5572_gshared)(__this, ___0_index, method);
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t math_min_m02D43DF516544C279AF660EA4731449C82991849_inline (int32_t ___0_x, int32_t ___1_y, const RuntimeMethod* method) ;
inline void UnsafeList_1_RemoveRange_mBDC19D7AC8AAECCEDB16C1F074E25D44CF7BCF48 (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_index, int32_t ___1_count, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, int32_t, int32_t, const RuntimeMethod*))UnsafeList_1_RemoveRange_mBDC19D7AC8AAECCEDB16C1F074E25D44CF7BCF48_gshared)(__this, ___0_index, ___1_count, method);
}
inline void* NativeArrayUnsafeUtility_GetUnsafeReadOnlyPtr_TisOccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D_m20BD626E48A9A87C9D0D502474419CE8FF67F7FF (NativeArray_1_t0C50A3E7F549E148C8748605A2BC3D9BB1BC80DF ___0_nativeArray, const RuntimeMethod* method)
{
	return ((  void* (*) (NativeArray_1_t0C50A3E7F549E148C8748605A2BC3D9BB1BC80DF, const RuntimeMethod*))NativeArrayUnsafeUtility_GetUnsafeReadOnlyPtr_TisOccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D_m20BD626E48A9A87C9D0D502474419CE8FF67F7FF_gshared)(___0_nativeArray, method);
}
inline void UnsafeList_1_CopyFrom_mAEFF28DF5C4A27B95A43F4D0425359B898657114 (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, NativeArray_1_t0C50A3E7F549E148C8748605A2BC3D9BB1BC80DF* ___0_other, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, NativeArray_1_t0C50A3E7F549E148C8748605A2BC3D9BB1BC80DF*, const RuntimeMethod*))UnsafeList_1_CopyFrom_mAEFF28DF5C4A27B95A43F4D0425359B898657114_gshared)(__this, ___0_other, method);
}
inline void UnsafeList_1_CopyFrom_m21D16EB2A77EF551D3EF9DB20BBEE2E38507E1B7 (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* ___0_other, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, const RuntimeMethod*))UnsafeList_1_CopyFrom_m21D16EB2A77EF551D3EF9DB20BBEE2E38507E1B7_gshared)(__this, ___0_other, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NotImplementedException__ctor_mDAB47BC6BD0E342E8F2171E5CABE3E67EA049F1C (NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8* __this, const RuntimeMethod* method) ;
inline RuntimeObject* UnsafeList_1_System_Collections_IEnumerable_GetEnumerator_mECC392B2D508A11712F173B4D1BEC8B9D5DDC9FE (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method)
{
	return ((  RuntimeObject* (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, const RuntimeMethod*))UnsafeList_1_System_Collections_IEnumerable_GetEnumerator_mECC392B2D508A11712F173B4D1BEC8B9D5DDC9FE_gshared)(__this, method);
}
inline RuntimeObject* UnsafeList_1_System_Collections_Generic_IEnumerableU3CTU3E_GetEnumerator_mF33B0D1056CA3743A4B22D07D84B959D46B0D027 (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method)
{
	return ((  RuntimeObject* (*) (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*, const RuntimeMethod*))UnsafeList_1_System_Collections_Generic_IEnumerableU3CTU3E_GetEnumerator_mF33B0D1056CA3743A4B22D07D84B959D46B0D027_gshared)(__this, method);
}
inline int32_t UnsafeList_1_get_Length_m30C8B237736009EBD4E69E7D215B9650233D037C_inline (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, const RuntimeMethod*))UnsafeList_1_get_Length_m30C8B237736009EBD4E69E7D215B9650233D037C_gshared_inline)(__this, method);
}
inline int32_t UnsafeList_1_get_Capacity_mD86B514B3119D3E1A021A6CB23BE78590F5E486E_inline (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, const RuntimeMethod*))UnsafeList_1_get_Capacity_mD86B514B3119D3E1A021A6CB23BE78590F5E486E_gshared_inline)(__this, method);
}
inline void UnsafeList_1_Resize_mF872E9A04824A2B9B2B673782565D043892D31D9 (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_length, int32_t ___1_options, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, int32_t, int32_t, const RuntimeMethod*))UnsafeList_1_Resize_mF872E9A04824A2B9B2B673782565D043892D31D9_gshared)(__this, ___0_length, ___1_options, method);
}
inline void UnsafeList_1_set_Length_mB77496A4A78A181D3CBFC6AC25BE562DE37F318B (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_value, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, int32_t, const RuntimeMethod*))UnsafeList_1_set_Length_mB77496A4A78A181D3CBFC6AC25BE562DE37F318B_gshared)(__this, ___0_value, method);
}
inline void UnsafeList_1_SetCapacity_mAD7D5D59FEB13EAF12B15B9FC0BBDEA7546A4563 (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_capacity, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, int32_t, const RuntimeMethod*))UnsafeList_1_SetCapacity_mAD7D5D59FEB13EAF12B15B9FC0BBDEA7546A4563_gshared)(__this, ___0_capacity, method);
}
inline void UnsafeList_1_set_Capacity_mB8A4248D3F6458D1D9E98A7BEC320E14BD41D3B7 (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_value, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, int32_t, const RuntimeMethod*))UnsafeList_1_set_Capacity_mB8A4248D3F6458D1D9E98A7BEC320E14BD41D3B7_gshared)(__this, ___0_value, method);
}
inline SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A UnsafeList_1_get_Item_m5047BC7B1C0732A194FACD8C079EC28A64A5F79D_inline (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_index, const RuntimeMethod* method)
{
	return ((  SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, int32_t, const RuntimeMethod*))UnsafeList_1_get_Item_m5047BC7B1C0732A194FACD8C079EC28A64A5F79D_gshared_inline)(__this, ___0_index, method);
}
inline void UnsafeList_1_set_Item_m2D938DC73BF3B2D244FB9468EBECDFA52B986B7B_inline (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_index, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A ___1_value, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, int32_t, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A, const RuntimeMethod*))UnsafeList_1_set_Item_m2D938DC73BF3B2D244FB9468EBECDFA52B986B7B_gshared_inline)(__this, ___0_index, ___1_value, method);
}
inline SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* UnsafeList_1_ElementAt_m9B7ADAC368CB917E0318285D89CD070BFFC7E2F9_inline (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_index, const RuntimeMethod* method)
{
	return ((  SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, int32_t, const RuntimeMethod*))UnsafeList_1_ElementAt_m9B7ADAC368CB917E0318285D89CD070BFFC7E2F9_gshared_inline)(__this, ___0_index, method);
}
inline void UnsafeList_1__ctor_mA5748C7F18591A66AAEA5CEDACA2A12FC57EFAD3 (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_initialCapacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___1_allocator, int32_t ___2_options, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, int32_t, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148, int32_t, const RuntimeMethod*))UnsafeList_1__ctor_mA5748C7F18591A66AAEA5CEDACA2A12FC57EFAD3_gshared)(__this, ___0_initialCapacity, ___1_allocator, ___2_options, method);
}
inline void UnsafeList_1_Dispose_m007CA9BE61EF7FB5A88A2E9AFEBD3611A4DEF29C (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, const RuntimeMethod*))UnsafeList_1_Dispose_m007CA9BE61EF7FB5A88A2E9AFEBD3611A4DEF29C_gshared)(__this, method);
}
inline void AllocatorManager_Free_TisUnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C_m1BCBC66CBB14BBD523F4C3A7F94F5170FC8CE363 (AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___0_handle, UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* ___1_pointer, int32_t ___2_items, const RuntimeMethod* method)
{
	((  void (*) (AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148, UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, int32_t, const RuntimeMethod*))AllocatorManager_Free_TisUnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C_m1BCBC66CBB14BBD523F4C3A7F94F5170FC8CE363_gshared)(___0_handle, ___1_pointer, ___2_items, method);
}
inline bool UnsafeList_1_get_IsCreated_mB1B61C071EA40B095E886B5298E0C3C54ED9A853_inline (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, const RuntimeMethod*))UnsafeList_1_get_IsCreated_mB1B61C071EA40B095E886B5298E0C3C54ED9A853_gshared_inline)(__this, method);
}
inline bool UnsafeList_1_get_IsEmpty_mFB3CDB4407674F5F2A7D1859C9FB368CC9077F1A_inline (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, const RuntimeMethod*))UnsafeList_1_get_IsEmpty_mFB3CDB4407674F5F2A7D1859C9FB368CC9077F1A_gshared_inline)(__this, method);
}
inline void AllocatorManager_Free_TisSplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A_m74C86DFA3B9611772049B4B5336DC3B36C731649 (AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___0_handle, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* ___1_pointer, int32_t ___2_items, const RuntimeMethod* method)
{
	((  void (*) (AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*, int32_t, const RuntimeMethod*))AllocatorManager_Free_TisSplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A_m74C86DFA3B9611772049B4B5336DC3B36C731649_gshared)(___0_handle, ___1_pointer, ___2_items, method);
}
inline void UnsafeList_1_Clear_mFE93F82A6E8896D8E46E491623D85BE9BC2AE2C3 (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, const RuntimeMethod*))UnsafeList_1_Clear_mFE93F82A6E8896D8E46E491623D85BE9BC2AE2C3_gshared)(__this, method);
}
inline void UnsafeList_1_ResizeExact_TisAllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148_mE85365421923BB85B9248CAA9CEB34945B35C737 (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148* ___0_allocator, int32_t ___1_newCapacity, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148*, int32_t, const RuntimeMethod*))UnsafeList_1_ResizeExact_TisAllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148_mE85365421923BB85B9248CAA9CEB34945B35C737_gshared)(__this, ___0_allocator, ___1_newCapacity, method);
}
inline void UnsafeList_1_ResizeExact_m7128F30F2118629FF89940C16F4046F9515FEF6B (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_capacity, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, int32_t, const RuntimeMethod*))UnsafeList_1_ResizeExact_m7128F30F2118629FF89940C16F4046F9515FEF6B_gshared)(__this, ___0_capacity, method);
}
inline void UnsafeList_1_SetCapacity_TisAllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148_m410651EE83B2047EEB067E0586569B723265B37B (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148* ___0_allocator, int32_t ___1_capacity, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148*, int32_t, const RuntimeMethod*))UnsafeList_1_SetCapacity_TisAllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148_m410651EE83B2047EEB067E0586569B723265B37B_gshared)(__this, ___0_allocator, ___1_capacity, method);
}
inline void UnsafeList_1_TrimExcess_m974AE258DEBD1BCDCD20A7E4630CE26296EDF43D (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, const RuntimeMethod*))UnsafeList_1_TrimExcess_m974AE258DEBD1BCDCD20A7E4630CE26296EDF43D_gshared)(__this, method);
}
inline void UnsafeUtility_WriteArrayElement_TisSplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A_m4F71D70C126C24C918F9E6237DC37C71726A6CE8_inline (void* ___0_destination, int32_t ___1_index, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A ___2_value, const RuntimeMethod* method)
{
	((  void (*) (void*, int32_t, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A, const RuntimeMethod*))UnsafeUtility_WriteArrayElement_TisSplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A_m4F71D70C126C24C918F9E6237DC37C71726A6CE8_gshared_inline)(___0_destination, ___1_index, ___2_value, method);
}
inline void UnsafeList_1_AddNoResize_mDD1844EF5F4B0A230D4C6141E4A6A3EF83521A5C_inline (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A ___0_value, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A, const RuntimeMethod*))UnsafeList_1_AddNoResize_mDD1844EF5F4B0A230D4C6141E4A6A3EF83521A5C_gshared_inline)(__this, ___0_value, method);
}
inline void UnsafeList_1_AddRangeNoResize_m6C41571D7107A9C270662661CCEEF34BDD32682F (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, void* ___0_ptr, int32_t ___1_count, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, void*, int32_t, const RuntimeMethod*))UnsafeList_1_AddRangeNoResize_m6C41571D7107A9C270662661CCEEF34BDD32682F_gshared)(__this, ___0_ptr, ___1_count, method);
}
inline void UnsafeList_1_AddRangeNoResize_mD850AF553A2F8263EDE3E1F7A1A886A2C7EAFCD4 (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C ___0_list, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C, const RuntimeMethod*))UnsafeList_1_AddRangeNoResize_mD850AF553A2F8263EDE3E1F7A1A886A2C7EAFCD4_gshared)(__this, ___0_list, method);
}
inline void UnsafeList_1_Add_mE02101A02348C4FE5C69658E032EB2BC5E2B0EC1_inline (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* ___0_value, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*, const RuntimeMethod*))UnsafeList_1_Add_mE02101A02348C4FE5C69658E032EB2BC5E2B0EC1_gshared_inline)(__this, ___0_value, method);
}
inline void UnsafeList_1_AddRange_m290AF2611869D3059792B0EDCF2DEAC70AE35CB6 (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, void* ___0_ptr, int32_t ___1_count, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, void*, int32_t, const RuntimeMethod*))UnsafeList_1_AddRange_m290AF2611869D3059792B0EDCF2DEAC70AE35CB6_gshared)(__this, ___0_ptr, ___1_count, method);
}
inline int32_t UnsafeUtility_SizeOf_TisSplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A_m6C96A05E2AC56907C62A2A917FE69A67EB3F72FB_inline (const RuntimeMethod* method)
{
	return ((  int32_t (*) (const RuntimeMethod*))UnsafeUtility_SizeOf_TisSplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A_m6C96A05E2AC56907C62A2A917FE69A67EB3F72FB_gshared_inline)(method);
}
inline void UnsafeList_1_AddReplicate_mA8C22B3C32A081106A17337AA53882D8CA92A49F (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* ___0_value, int32_t ___1_count, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*, int32_t, const RuntimeMethod*))UnsafeList_1_AddReplicate_mA8C22B3C32A081106A17337AA53882D8CA92A49F_gshared)(__this, ___0_value, ___1_count, method);
}
inline void UnsafeList_1_InsertRangeWithBeginEnd_mC5402628584EC1224906861332995DD894031938 (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_begin, int32_t ___1_end, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, int32_t, int32_t, const RuntimeMethod*))UnsafeList_1_InsertRangeWithBeginEnd_mC5402628584EC1224906861332995DD894031938_gshared)(__this, ___0_begin, ___1_end, method);
}
inline void UnsafeList_1_RemoveAtSwapBack_mDE564A4CC3B47BF28AF0D1CF99A43A4E84210AAF (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_index, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, int32_t, const RuntimeMethod*))UnsafeList_1_RemoveAtSwapBack_mDE564A4CC3B47BF28AF0D1CF99A43A4E84210AAF_gshared)(__this, ___0_index, method);
}
inline void UnsafeList_1_RemoveRangeSwapBack_m100F1A29384A20C6513B0D434D60DC7E66828D2F (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_index, int32_t ___1_count, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, int32_t, int32_t, const RuntimeMethod*))UnsafeList_1_RemoveRangeSwapBack_m100F1A29384A20C6513B0D434D60DC7E66828D2F_gshared)(__this, ___0_index, ___1_count, method);
}
inline void UnsafeList_1_RemoveAt_mAE596941D78BA2014C3E3048ABDAEEC7CE5D5227 (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_index, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, int32_t, const RuntimeMethod*))UnsafeList_1_RemoveAt_mAE596941D78BA2014C3E3048ABDAEEC7CE5D5227_gshared)(__this, ___0_index, method);
}
inline void UnsafeList_1_RemoveRange_m85604203599589C689C82B1071C5629617C4E5C2 (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_index, int32_t ___1_count, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, int32_t, int32_t, const RuntimeMethod*))UnsafeList_1_RemoveRange_m85604203599589C689C82B1071C5629617C4E5C2_gshared)(__this, ___0_index, ___1_count, method);
}
inline void* NativeArrayUnsafeUtility_GetUnsafeReadOnlyPtr_TisSplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A_mEA7A2AAE07DCFD8DAB7122AEC01806A98F3AE6CE (NativeArray_1_t933EB4C2ED1CCB3C68D5E2EC18C770C2893C8443 ___0_nativeArray, const RuntimeMethod* method)
{
	return ((  void* (*) (NativeArray_1_t933EB4C2ED1CCB3C68D5E2EC18C770C2893C8443, const RuntimeMethod*))NativeArrayUnsafeUtility_GetUnsafeReadOnlyPtr_TisSplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A_mEA7A2AAE07DCFD8DAB7122AEC01806A98F3AE6CE_gshared)(___0_nativeArray, method);
}
inline void UnsafeList_1_CopyFrom_m65DBB0C13CA29FE140BCD0FEB1993C55723C3252 (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, NativeArray_1_t933EB4C2ED1CCB3C68D5E2EC18C770C2893C8443* ___0_other, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, NativeArray_1_t933EB4C2ED1CCB3C68D5E2EC18C770C2893C8443*, const RuntimeMethod*))UnsafeList_1_CopyFrom_m65DBB0C13CA29FE140BCD0FEB1993C55723C3252_gshared)(__this, ___0_other, method);
}
inline void UnsafeList_1_CopyFrom_m836376D9E1B104ABFC8471073E2D9A8A65B7B5D3 (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* ___0_other, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, const RuntimeMethod*))UnsafeList_1_CopyFrom_m836376D9E1B104ABFC8471073E2D9A8A65B7B5D3_gshared)(__this, ___0_other, method);
}
inline RuntimeObject* UnsafeList_1_System_Collections_IEnumerable_GetEnumerator_mB1A8B4B473D9E1667ADF1B265CA1C7E59274D7AA (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method)
{
	return ((  RuntimeObject* (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, const RuntimeMethod*))UnsafeList_1_System_Collections_IEnumerable_GetEnumerator_mB1A8B4B473D9E1667ADF1B265CA1C7E59274D7AA_gshared)(__this, method);
}
inline RuntimeObject* UnsafeList_1_System_Collections_Generic_IEnumerableU3CTU3E_GetEnumerator_mF2DFB1A66D985398367765F12E3ADB88D01D05C0 (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method)
{
	return ((  RuntimeObject* (*) (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*, const RuntimeMethod*))UnsafeList_1_System_Collections_Generic_IEnumerableU3CTU3E_GetEnumerator_mF2DFB1A66D985398367765F12E3ADB88D01D05C0_gshared)(__this, method);
}
inline int32_t UnsafeList_1_get_Length_mFE9C02C4C7169AE23DE6BC1B834E0DBC1D03DBB1_inline (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, const RuntimeMethod*))UnsafeList_1_get_Length_mFE9C02C4C7169AE23DE6BC1B834E0DBC1D03DBB1_gshared_inline)(__this, method);
}
inline int32_t UnsafeList_1_get_Capacity_m9C10840F54FD1F0871C1C7E25CE7AF92622DF9AD_inline (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, const RuntimeMethod*))UnsafeList_1_get_Capacity_m9C10840F54FD1F0871C1C7E25CE7AF92622DF9AD_gshared_inline)(__this, method);
}
inline void UnsafeList_1_Resize_mA8E41BF0D06DD764B65618C554B138588019DCA9 (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_length, int32_t ___1_options, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, int32_t, int32_t, const RuntimeMethod*))UnsafeList_1_Resize_mA8E41BF0D06DD764B65618C554B138588019DCA9_gshared)(__this, ___0_length, ___1_options, method);
}
inline void UnsafeList_1_set_Length_m053843BFA1C2D31E71CC871DE1B08DE91BF01416 (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_value, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, int32_t, const RuntimeMethod*))UnsafeList_1_set_Length_m053843BFA1C2D31E71CC871DE1B08DE91BF01416_gshared)(__this, ___0_value, method);
}
inline void UnsafeList_1_SetCapacity_mBBADF24575202AD2F6156C29CD6DB788AB15C5C8 (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_capacity, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, int32_t, const RuntimeMethod*))UnsafeList_1_SetCapacity_mBBADF24575202AD2F6156C29CD6DB788AB15C5C8_gshared)(__this, ___0_capacity, method);
}
inline void UnsafeList_1_set_Capacity_mC07B19231AD2F3637381CBAF53723C4BCE13CF40 (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_value, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, int32_t, const RuntimeMethod*))UnsafeList_1_set_Capacity_mC07B19231AD2F3637381CBAF53723C4BCE13CF40_gshared)(__this, ___0_value, method);
}
inline Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 UnsafeList_1_get_Item_mEFA75FB7304D5FFEA7E3F6226B01453D10013A3B_inline (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_index, const RuntimeMethod* method)
{
	return ((  Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, int32_t, const RuntimeMethod*))UnsafeList_1_get_Item_mEFA75FB7304D5FFEA7E3F6226B01453D10013A3B_gshared_inline)(__this, ___0_index, method);
}
inline void UnsafeList_1_set_Item_m0B5139C9A3714A3C5E0B576AB276E1A0FCA406B9_inline (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_index, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 ___1_value, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, int32_t, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127, const RuntimeMethod*))UnsafeList_1_set_Item_m0B5139C9A3714A3C5E0B576AB276E1A0FCA406B9_gshared_inline)(__this, ___0_index, ___1_value, method);
}
inline Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* UnsafeList_1_ElementAt_m43B542F9E0F11A380A8AC0435939688D55836A0D_inline (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_index, const RuntimeMethod* method)
{
	return ((  Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, int32_t, const RuntimeMethod*))UnsafeList_1_ElementAt_m43B542F9E0F11A380A8AC0435939688D55836A0D_gshared_inline)(__this, ___0_index, method);
}
inline void UnsafeList_1__ctor_m5D36D9B673FEB6B6B5DDAA6DBA2D1773B13C0C2D (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_initialCapacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___1_allocator, int32_t ___2_options, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, int32_t, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148, int32_t, const RuntimeMethod*))UnsafeList_1__ctor_m5D36D9B673FEB6B6B5DDAA6DBA2D1773B13C0C2D_gshared)(__this, ___0_initialCapacity, ___1_allocator, ___2_options, method);
}
inline void UnsafeList_1_Dispose_mE60AFFB718C0BD8A36BDF427B8BC76F17D46FF80 (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, const RuntimeMethod*))UnsafeList_1_Dispose_mE60AFFB718C0BD8A36BDF427B8BC76F17D46FF80_gshared)(__this, method);
}
inline void AllocatorManager_Free_TisUnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7_m2ACD46900DC49986AE7EA226E807CF511B3DF9DD (AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___0_handle, UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* ___1_pointer, int32_t ___2_items, const RuntimeMethod* method)
{
	((  void (*) (AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148, UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, int32_t, const RuntimeMethod*))AllocatorManager_Free_TisUnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7_m2ACD46900DC49986AE7EA226E807CF511B3DF9DD_gshared)(___0_handle, ___1_pointer, ___2_items, method);
}
inline bool UnsafeList_1_get_IsCreated_m4B100662A0B454C46725BE8CEC4A746E61835062_inline (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, const RuntimeMethod*))UnsafeList_1_get_IsCreated_m4B100662A0B454C46725BE8CEC4A746E61835062_gshared_inline)(__this, method);
}
inline bool UnsafeList_1_get_IsEmpty_m436BA19BA9C162ACC4DB0819037CBB975135A952_inline (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, const RuntimeMethod*))UnsafeList_1_get_IsEmpty_m436BA19BA9C162ACC4DB0819037CBB975135A952_gshared_inline)(__this, method);
}
inline void AllocatorManager_Free_TisSlot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127_mA83D7FD9125891D2119A7B1F691163E0C357ADA6 (AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___0_handle, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* ___1_pointer, int32_t ___2_items, const RuntimeMethod* method)
{
	((  void (*) (AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*, int32_t, const RuntimeMethod*))AllocatorManager_Free_TisSlot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127_mA83D7FD9125891D2119A7B1F691163E0C357ADA6_gshared)(___0_handle, ___1_pointer, ___2_items, method);
}
inline void UnsafeList_1_Clear_m7323877F6C7EBAD0F7EE4CAD4E1DF7F7A417BCAF (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, const RuntimeMethod*))UnsafeList_1_Clear_m7323877F6C7EBAD0F7EE4CAD4E1DF7F7A417BCAF_gshared)(__this, method);
}
inline void UnsafeList_1_ResizeExact_TisAllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148_mDAF433094E4F5C8022D2D327C78F8213DC96CF97 (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148* ___0_allocator, int32_t ___1_newCapacity, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148*, int32_t, const RuntimeMethod*))UnsafeList_1_ResizeExact_TisAllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148_mDAF433094E4F5C8022D2D327C78F8213DC96CF97_gshared)(__this, ___0_allocator, ___1_newCapacity, method);
}
inline void UnsafeList_1_ResizeExact_mD71C35B2525653A8A0734B25902643471D9934FF (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_capacity, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, int32_t, const RuntimeMethod*))UnsafeList_1_ResizeExact_mD71C35B2525653A8A0734B25902643471D9934FF_gshared)(__this, ___0_capacity, method);
}
inline void UnsafeList_1_SetCapacity_TisAllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148_m6F2A7EE715E1620965BB586860D3D44B3D8F6BA3 (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148* ___0_allocator, int32_t ___1_capacity, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148*, int32_t, const RuntimeMethod*))UnsafeList_1_SetCapacity_TisAllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148_m6F2A7EE715E1620965BB586860D3D44B3D8F6BA3_gshared)(__this, ___0_allocator, ___1_capacity, method);
}
inline void UnsafeList_1_TrimExcess_mE3AF5AF66473695DE2F8698576DE9A28301D871F (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, const RuntimeMethod*))UnsafeList_1_TrimExcess_mE3AF5AF66473695DE2F8698576DE9A28301D871F_gshared)(__this, method);
}
inline void UnsafeUtility_WriteArrayElement_TisSlot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127_m4F77AC19B6051E7566C5A3561715FC4CB8D462AF_inline (void* ___0_destination, int32_t ___1_index, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 ___2_value, const RuntimeMethod* method)
{
	((  void (*) (void*, int32_t, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127, const RuntimeMethod*))UnsafeUtility_WriteArrayElement_TisSlot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127_m4F77AC19B6051E7566C5A3561715FC4CB8D462AF_gshared_inline)(___0_destination, ___1_index, ___2_value, method);
}
inline void UnsafeList_1_AddNoResize_m884048B32C3E428BD16BB73C3162E27F1B3EF326_inline (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 ___0_value, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127, const RuntimeMethod*))UnsafeList_1_AddNoResize_m884048B32C3E428BD16BB73C3162E27F1B3EF326_gshared_inline)(__this, ___0_value, method);
}
inline void UnsafeList_1_AddRangeNoResize_mD2A2918E38DFA75F76BF852015F849DAC06AD533 (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, void* ___0_ptr, int32_t ___1_count, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, void*, int32_t, const RuntimeMethod*))UnsafeList_1_AddRangeNoResize_mD2A2918E38DFA75F76BF852015F849DAC06AD533_gshared)(__this, ___0_ptr, ___1_count, method);
}
inline void UnsafeList_1_AddRangeNoResize_m8521348DD738300ECE4F77B891B87A9833DA5A7D (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7 ___0_list, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7, const RuntimeMethod*))UnsafeList_1_AddRangeNoResize_m8521348DD738300ECE4F77B891B87A9833DA5A7D_gshared)(__this, ___0_list, method);
}
inline void UnsafeList_1_Add_m405283315301E592556E27548D759262F9B0C52F_inline (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* ___0_value, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*, const RuntimeMethod*))UnsafeList_1_Add_m405283315301E592556E27548D759262F9B0C52F_gshared_inline)(__this, ___0_value, method);
}
inline void UnsafeList_1_AddRange_mFA03E69A70D0F6E2A7A0E1255D4E8A9DD997902A (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, void* ___0_ptr, int32_t ___1_count, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, void*, int32_t, const RuntimeMethod*))UnsafeList_1_AddRange_mFA03E69A70D0F6E2A7A0E1255D4E8A9DD997902A_gshared)(__this, ___0_ptr, ___1_count, method);
}
inline int32_t UnsafeUtility_SizeOf_TisSlot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127_m9A004D5E211035E85A1BBF1B521142792C4F0A57_inline (const RuntimeMethod* method)
{
	return ((  int32_t (*) (const RuntimeMethod*))UnsafeUtility_SizeOf_TisSlot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127_m9A004D5E211035E85A1BBF1B521142792C4F0A57_gshared_inline)(method);
}
inline void UnsafeList_1_AddReplicate_m12CE42900BA193AD08AF2BC7899C808C524A6F52 (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* ___0_value, int32_t ___1_count, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*, int32_t, const RuntimeMethod*))UnsafeList_1_AddReplicate_m12CE42900BA193AD08AF2BC7899C808C524A6F52_gshared)(__this, ___0_value, ___1_count, method);
}
inline void UnsafeList_1_InsertRangeWithBeginEnd_mC123A52689F34B06EF3678FC2FE08792548531AC (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_begin, int32_t ___1_end, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, int32_t, int32_t, const RuntimeMethod*))UnsafeList_1_InsertRangeWithBeginEnd_mC123A52689F34B06EF3678FC2FE08792548531AC_gshared)(__this, ___0_begin, ___1_end, method);
}
inline void UnsafeList_1_RemoveAtSwapBack_mB73019BC253FE72CA0B0757417C73E132680B248 (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_index, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, int32_t, const RuntimeMethod*))UnsafeList_1_RemoveAtSwapBack_mB73019BC253FE72CA0B0757417C73E132680B248_gshared)(__this, ___0_index, method);
}
inline void UnsafeList_1_RemoveRangeSwapBack_mAF5F28360809AB7A2E68FBA1D993B6F9C43B3564 (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_index, int32_t ___1_count, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, int32_t, int32_t, const RuntimeMethod*))UnsafeList_1_RemoveRangeSwapBack_mAF5F28360809AB7A2E68FBA1D993B6F9C43B3564_gshared)(__this, ___0_index, ___1_count, method);
}
inline void UnsafeList_1_RemoveAt_m7E96DC2F31FA5485A37D45BA007E1FC8043D4CF2 (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_index, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, int32_t, const RuntimeMethod*))UnsafeList_1_RemoveAt_m7E96DC2F31FA5485A37D45BA007E1FC8043D4CF2_gshared)(__this, ___0_index, method);
}
inline void UnsafeList_1_RemoveRange_mB4B17E74CEE3C443B6749D3A3B52FC9598401C46 (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_index, int32_t ___1_count, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, int32_t, int32_t, const RuntimeMethod*))UnsafeList_1_RemoveRange_mB4B17E74CEE3C443B6749D3A3B52FC9598401C46_gshared)(__this, ___0_index, ___1_count, method);
}
inline void* NativeArrayUnsafeUtility_GetUnsafeReadOnlyPtr_TisSlot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127_m33C547D554717D3EAFA0EDFB786DE05EA69EAA85 (NativeArray_1_tB8D8B86A987B7E27BD621893A826604AA3A66C5C ___0_nativeArray, const RuntimeMethod* method)
{
	return ((  void* (*) (NativeArray_1_tB8D8B86A987B7E27BD621893A826604AA3A66C5C, const RuntimeMethod*))NativeArrayUnsafeUtility_GetUnsafeReadOnlyPtr_TisSlot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127_m33C547D554717D3EAFA0EDFB786DE05EA69EAA85_gshared)(___0_nativeArray, method);
}
inline void UnsafeList_1_CopyFrom_mF6E6FAF3CEEB14EF5B4177580034AFDA1CD1A33A (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, NativeArray_1_tB8D8B86A987B7E27BD621893A826604AA3A66C5C* ___0_other, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, NativeArray_1_tB8D8B86A987B7E27BD621893A826604AA3A66C5C*, const RuntimeMethod*))UnsafeList_1_CopyFrom_mF6E6FAF3CEEB14EF5B4177580034AFDA1CD1A33A_gshared)(__this, ___0_other, method);
}
inline void UnsafeList_1_CopyFrom_m5C64DE802A570C7DCECE59B4859091A58686F23A (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* ___0_other, const RuntimeMethod* method)
{
	((  void (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, const RuntimeMethod*))UnsafeList_1_CopyFrom_m5C64DE802A570C7DCECE59B4859091A58686F23A_gshared)(__this, ___0_other, method);
}
inline RuntimeObject* UnsafeList_1_System_Collections_IEnumerable_GetEnumerator_mBE9931F96650CD707D42AE0625B0B34CD2CA9307 (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method)
{
	return ((  RuntimeObject* (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, const RuntimeMethod*))UnsafeList_1_System_Collections_IEnumerable_GetEnumerator_mBE9931F96650CD707D42AE0625B0B34CD2CA9307_gshared)(__this, method);
}
inline RuntimeObject* UnsafeList_1_System_Collections_Generic_IEnumerableU3CTU3E_GetEnumerator_m6576E2C347279C70D752C163781D0115578818BB (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method)
{
	return ((  RuntimeObject* (*) (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*, const RuntimeMethod*))UnsafeList_1_System_Collections_Generic_IEnumerableU3CTU3E_GetEnumerator_m6576E2C347279C70D752C163781D0115578818BB_gshared)(__this, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeUtility_MemSet_m4CD74CD43260EB2962A46F57E0D93DD5C332FC2B (void* ___0_destination, uint8_t ___1_value, int64_t ___2_size, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t JobsUtility_get_ThreadIndexCount_m88A954344398143540618B35943F863B92465676 (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t* UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5 (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF (int32_t* ___0_location1, int32_t ___1_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Interlocked_Add_m2455208C56EEFD8832AEAD8AF7368A3FEB33A73C (int32_t* ___0_location1, int32_t ___1_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717 (int32_t* ___0_location1, int32_t ___1_value, int32_t ___2_comparand, const RuntimeMethod* method) ;
inline bool UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mC42AE53B9C096C5437713AA40D89EB873678D78F (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___1_key, int32_t* ___2_item, NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A* ___3_it, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94, int32_t*, NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A*, const RuntimeMethod*))UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mC42AE53B9C096C5437713AA40D89EB873678D78F_gshared)(___0_data, ___1_key, ___2_item, ___3_it, method);
}
inline int32_t UnsafeParallelHashMapBase_2_AllocEntry_m6564DDE54C96DB6027C802DDB51638722A8B7A9C (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_threadIndex, const RuntimeMethod* method)
{
	return ((  int32_t (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, const RuntimeMethod*))UnsafeParallelHashMapBase_2_AllocEntry_m6564DDE54C96DB6027C802DDB51638722A8B7A9C_gshared)(___0_data, ___1_threadIndex, method);
}
inline void UnsafeUtility_WriteArrayElement_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_mAC61BCD78DBCF3665AB62CF3F0A9160131582E7C_inline (void* ___0_destination, int32_t ___1_index, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___2_value, const RuntimeMethod* method)
{
	((  void (*) (void*, int32_t, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94, const RuntimeMethod*))UnsafeUtility_WriteArrayElement_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_mAC61BCD78DBCF3665AB62CF3F0A9160131582E7C_gshared_inline)(___0_destination, ___1_index, ___2_value, method);
}
inline void UnsafeUtility_WriteArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m0DD1CC90B2F1EF5041F2F4E1DABB58224229F0D7_inline (void* ___0_destination, int32_t ___1_index, int32_t ___2_value, const RuntimeMethod* method)
{
	((  void (*) (void*, int32_t, int32_t, const RuntimeMethod*))UnsafeUtility_WriteArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m0DD1CC90B2F1EF5041F2F4E1DABB58224229F0D7_gshared_inline)(___0_destination, ___1_index, ___2_value, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t DrawKey_GetHashCode_m6E3C5F3D42D02D8035AA7E7B5501FDBC1551F4E5 (DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94* __this, const RuntimeMethod* method) ;
inline void UnsafeParallelHashMapBase_2_FreeEntry_mE62A9F90862B9AF9BF01C07B0A17F0C8F2372D6D (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_idx, int32_t ___2_threadIndex, const RuntimeMethod* method)
{
	((  void (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, int32_t, const RuntimeMethod*))UnsafeParallelHashMapBase_2_FreeEntry_mE62A9F90862B9AF9BF01C07B0A17F0C8F2372D6D_gshared)(___0_data, ___1_idx, ___2_threadIndex, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapData_GrowCapacity_m7F2FF57E76510A99266830779059C6C202B9EC47 (int32_t ___0_capacity, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapData_GetBucketSize_mEF90FF75EFE70E4B59CD6AF9FDCB3D564A1986A3 (int32_t ___0_capacity, const RuntimeMethod* method) ;
inline void UnsafeParallelHashMapData_ReallocateHashMap_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m74D70D8E65D60A3A3B782011BC925E749F8C29C8 (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_newCapacity, int32_t ___2_newBucketCapacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___3_label, const RuntimeMethod* method)
{
	((  void (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, int32_t, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148, const RuntimeMethod*))UnsafeParallelHashMapData_ReallocateHashMap_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m74D70D8E65D60A3A3B782011BC925E749F8C29C8_gshared)(___0_data, ___1_newCapacity, ___2_newBucketCapacity, ___3_label, method);
}
inline DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 UnsafeUtility_ReadArrayElement_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_mFD7DBC1199616005466125347027F6201459B40D_inline (void* ___0_source, int32_t ___1_index, const RuntimeMethod* method)
{
	return ((  DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 (*) (void*, int32_t, const RuntimeMethod*))UnsafeUtility_ReadArrayElement_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_mFD7DBC1199616005466125347027F6201459B40D_gshared_inline)(___0_source, ___1_index, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool DrawKey_Equals_mBA2838871085C8944B81322DC6E851F4273E8E91 (DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94* __this, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___0_other, const RuntimeMethod* method) ;
inline bool UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_mAFEFFB673EC0E6AACC6C9F4ECEBB1ACA52A589B0 (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t* ___1_item, NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A* ___2_it, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t*, NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A*, const RuntimeMethod*))UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_mAFEFFB673EC0E6AACC6C9F4ECEBB1ACA52A589B0_gshared)(___0_data, ___1_item, ___2_it, method);
}
inline int32_t UnsafeUtility_ReadArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_mFBA66C06ECEB0A2BC1AAE634B6E6BB436F957084_inline (void* ___0_source, int32_t ___1_index, const RuntimeMethod* method)
{
	return ((  int32_t (*) (void*, int32_t, const RuntimeMethod*))UnsafeUtility_ReadArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_mFBA66C06ECEB0A2BC1AAE634B6E6BB436F957084_gshared_inline)(___0_source, ___1_index, method);
}
inline bool UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_m97E032CD6E0F90AFEDAFAF6FC9790EAEFAD4D38F (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C* ___2_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___3_it, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C*, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC*, const RuntimeMethod*))UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_m97E032CD6E0F90AFEDAFAF6FC9790EAEFAD4D38F_gshared)(___0_data, ___1_key, ___2_item, ___3_it, method);
}
inline int32_t UnsafeParallelHashMapBase_2_AllocEntry_m74EB5C8C921F13820DB035CF8DA58E1FB942A142 (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_threadIndex, const RuntimeMethod* method)
{
	return ((  int32_t (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, const RuntimeMethod*))UnsafeParallelHashMapBase_2_AllocEntry_m74EB5C8C921F13820DB035CF8DA58E1FB942A142_gshared)(___0_data, ___1_threadIndex, method);
}
inline void UnsafeUtility_WriteArrayElement_TisBatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C_m32FE612078445C09645A5FEFCADD35BF1B5497D3_inline (void* ___0_destination, int32_t ___1_index, BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C ___2_value, const RuntimeMethod* method)
{
	((  void (*) (void*, int32_t, BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C, const RuntimeMethod*))UnsafeUtility_WriteArrayElement_TisBatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C_m32FE612078445C09645A5FEFCADD35BF1B5497D3_gshared_inline)(___0_destination, ___1_index, ___2_value, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295 (int32_t* __this, const RuntimeMethod* method) ;
inline void UnsafeParallelHashMapBase_2_FreeEntry_m900571E61B5A7712D4C2358CC8B337805E654A03 (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_idx, int32_t ___2_threadIndex, const RuntimeMethod* method)
{
	((  void (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, int32_t, const RuntimeMethod*))UnsafeParallelHashMapBase_2_FreeEntry_m900571E61B5A7712D4C2358CC8B337805E654A03_gshared)(___0_data, ___1_idx, ___2_threadIndex, method);
}
inline void UnsafeParallelHashMapData_ReallocateHashMap_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_TisBatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C_m0D3BC53501025D0E6FFB93ADC9A6861B58849FE5 (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_newCapacity, int32_t ___2_newBucketCapacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___3_label, const RuntimeMethod* method)
{
	((  void (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, int32_t, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148, const RuntimeMethod*))UnsafeParallelHashMapData_ReallocateHashMap_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_TisBatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C_m0D3BC53501025D0E6FFB93ADC9A6861B58849FE5_gshared)(___0_data, ___1_newCapacity, ___2_newBucketCapacity, ___3_label, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Int32_Equals_mC819D19A661B95BE253FB1769FD4D91961D20722 (int32_t* __this, int32_t ___0_obj, const RuntimeMethod* method) ;
inline bool UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m5D25900ED3545AA3E3F72977EB6F728351B3D361 (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C* ___1_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___2_it, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C*, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC*, const RuntimeMethod*))UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m5D25900ED3545AA3E3F72977EB6F728351B3D361_gshared)(___0_data, ___1_item, ___2_it, method);
}
inline BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C UnsafeUtility_ReadArrayElement_TisBatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C_mDE41FFE3160D153E47D8D93EF29E4B9C3DB23D20_inline (void* ___0_source, int32_t ___1_index, const RuntimeMethod* method)
{
	return ((  BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C (*) (void*, int32_t, const RuntimeMethod*))UnsafeUtility_ReadArrayElement_TisBatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C_mDE41FFE3160D153E47D8D93EF29E4B9C3DB23D20_gshared_inline)(___0_source, ___1_index, method);
}
inline bool UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_m0A1550FEB428909B2E587F9AA67DD634D414D678 (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0* ___2_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___3_it, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0*, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC*, const RuntimeMethod*))UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_m0A1550FEB428909B2E587F9AA67DD634D414D678_gshared)(___0_data, ___1_key, ___2_item, ___3_it, method);
}
inline int32_t UnsafeParallelHashMapBase_2_AllocEntry_m8AD3BCA9FB9188688CEFCD9B8C98668A2AB7D334 (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_threadIndex, const RuntimeMethod* method)
{
	return ((  int32_t (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, const RuntimeMethod*))UnsafeParallelHashMapBase_2_AllocEntry_m8AD3BCA9FB9188688CEFCD9B8C98668A2AB7D334_gshared)(___0_data, ___1_threadIndex, method);
}
inline void UnsafeUtility_WriteArrayElement_TisBatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0_m0CA08285DF610E216621F21C754D8D5E56428B01_inline (void* ___0_destination, int32_t ___1_index, BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0 ___2_value, const RuntimeMethod* method)
{
	((  void (*) (void*, int32_t, BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0, const RuntimeMethod*))UnsafeUtility_WriteArrayElement_TisBatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0_m0CA08285DF610E216621F21C754D8D5E56428B01_gshared_inline)(___0_destination, ___1_index, ___2_value, method);
}
inline void UnsafeParallelHashMapBase_2_FreeEntry_m68049D0DC47E97C465D43753CAAFAF997DE7804C (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_idx, int32_t ___2_threadIndex, const RuntimeMethod* method)
{
	((  void (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, int32_t, const RuntimeMethod*))UnsafeParallelHashMapBase_2_FreeEntry_m68049D0DC47E97C465D43753CAAFAF997DE7804C_gshared)(___0_data, ___1_idx, ___2_threadIndex, method);
}
inline void UnsafeParallelHashMapData_ReallocateHashMap_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_TisBatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0_m7276C3EA10AA4289184C4478EC7CE69B78E70B2C (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_newCapacity, int32_t ___2_newBucketCapacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___3_label, const RuntimeMethod* method)
{
	((  void (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, int32_t, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148, const RuntimeMethod*))UnsafeParallelHashMapData_ReallocateHashMap_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_TisBatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0_m7276C3EA10AA4289184C4478EC7CE69B78E70B2C_gshared)(___0_data, ___1_newCapacity, ___2_newBucketCapacity, ___3_label, method);
}
inline bool UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_mAC37A0DE4D5678D35DF0C57E71A79D74CB486CAE (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0* ___1_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___2_it, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0*, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC*, const RuntimeMethod*))UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_mAC37A0DE4D5678D35DF0C57E71A79D74CB486CAE_gshared)(___0_data, ___1_item, ___2_it, method);
}
inline BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0 UnsafeUtility_ReadArrayElement_TisBatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0_mD0CAE37D791EB711A170B7F9BDCEAB6ED472C3E3_inline (void* ___0_source, int32_t ___1_index, const RuntimeMethod* method)
{
	return ((  BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0 (*) (void*, int32_t, const RuntimeMethod*))UnsafeUtility_ReadArrayElement_TisBatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0_mD0CAE37D791EB711A170B7F9BDCEAB6ED472C3E3_gshared_inline)(___0_source, ___1_index, method);
}
inline bool UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_m6DF4FDD33DF0500B90F89611D3B0EB217FBE80A9 (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78* ___2_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___3_it, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78*, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC*, const RuntimeMethod*))UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_m6DF4FDD33DF0500B90F89611D3B0EB217FBE80A9_gshared)(___0_data, ___1_key, ___2_item, ___3_it, method);
}
inline int32_t UnsafeParallelHashMapBase_2_AllocEntry_mA6D1BF0531A4B163ED154D98E5AC42EBF6BA5F3D (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_threadIndex, const RuntimeMethod* method)
{
	return ((  int32_t (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, const RuntimeMethod*))UnsafeParallelHashMapBase_2_AllocEntry_mA6D1BF0531A4B163ED154D98E5AC42EBF6BA5F3D_gshared)(___0_data, ___1_threadIndex, method);
}
inline void UnsafeUtility_WriteArrayElement_TisGPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78_mFC4E3A09D0F9A76B3DA65553F10F7EF785896EEA_inline (void* ___0_destination, int32_t ___1_index, GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78 ___2_value, const RuntimeMethod* method)
{
	((  void (*) (void*, int32_t, GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78, const RuntimeMethod*))UnsafeUtility_WriteArrayElement_TisGPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78_mFC4E3A09D0F9A76B3DA65553F10F7EF785896EEA_gshared_inline)(___0_destination, ___1_index, ___2_value, method);
}
inline void UnsafeParallelHashMapBase_2_FreeEntry_m8FD2ED9C81D1A54D0D5D33B66435A7B5E8E4C65E (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_idx, int32_t ___2_threadIndex, const RuntimeMethod* method)
{
	((  void (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, int32_t, const RuntimeMethod*))UnsafeParallelHashMapBase_2_FreeEntry_m8FD2ED9C81D1A54D0D5D33B66435A7B5E8E4C65E_gshared)(___0_data, ___1_idx, ___2_threadIndex, method);
}
inline void UnsafeParallelHashMapData_ReallocateHashMap_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_TisGPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78_m5EEA3CF56A858CE6C8B93F86EBD5D9E0EC019D09 (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_newCapacity, int32_t ___2_newBucketCapacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___3_label, const RuntimeMethod* method)
{
	((  void (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, int32_t, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148, const RuntimeMethod*))UnsafeParallelHashMapData_ReallocateHashMap_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_TisGPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78_m5EEA3CF56A858CE6C8B93F86EBD5D9E0EC019D09_gshared)(___0_data, ___1_newCapacity, ___2_newBucketCapacity, ___3_label, method);
}
inline bool UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m3453F1516A7747F6CB50AA7E83EFF9D33D9D1325 (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78* ___1_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___2_it, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78*, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC*, const RuntimeMethod*))UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m3453F1516A7747F6CB50AA7E83EFF9D33D9D1325_gshared)(___0_data, ___1_item, ___2_it, method);
}
inline GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78 UnsafeUtility_ReadArrayElement_TisGPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78_mF42F014B5AA9C633D3FCAB3FFF26646E54395BD8_inline (void* ___0_source, int32_t ___1_index, const RuntimeMethod* method)
{
	return ((  GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78 (*) (void*, int32_t, const RuntimeMethod*))UnsafeUtility_ReadArrayElement_TisGPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78_mF42F014B5AA9C633D3FCAB3FFF26646E54395BD8_gshared_inline)(___0_source, ___1_index, method);
}
inline bool UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mA5FCFB37B4C19FD5FF7B0660AAE55181A6A68C1F (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B* ___2_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___3_it, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B*, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC*, const RuntimeMethod*))UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mA5FCFB37B4C19FD5FF7B0660AAE55181A6A68C1F_gshared)(___0_data, ___1_key, ___2_item, ___3_it, method);
}
inline int32_t UnsafeParallelHashMapBase_2_AllocEntry_mA60C7AAB43656E7611E27393BC6AB7E52163A000 (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_threadIndex, const RuntimeMethod* method)
{
	return ((  int32_t (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, const RuntimeMethod*))UnsafeParallelHashMapBase_2_AllocEntry_mA60C7AAB43656E7611E27393BC6AB7E52163A000_gshared)(___0_data, ___1_threadIndex, method);
}
inline void UnsafeUtility_WriteArrayElement_TisInstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B_m2D4905CE9CCFB4EF383D04FA0F872F621E08A309_inline (void* ___0_destination, int32_t ___1_index, InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B ___2_value, const RuntimeMethod* method)
{
	((  void (*) (void*, int32_t, InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B, const RuntimeMethod*))UnsafeUtility_WriteArrayElement_TisInstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B_m2D4905CE9CCFB4EF383D04FA0F872F621E08A309_gshared_inline)(___0_destination, ___1_index, ___2_value, method);
}
inline void UnsafeParallelHashMapBase_2_FreeEntry_mC0307320846285CEBB98C0EF64D1880A4876EBB6 (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_idx, int32_t ___2_threadIndex, const RuntimeMethod* method)
{
	((  void (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, int32_t, const RuntimeMethod*))UnsafeParallelHashMapBase_2_FreeEntry_mC0307320846285CEBB98C0EF64D1880A4876EBB6_gshared)(___0_data, ___1_idx, ___2_threadIndex, method);
}
inline void UnsafeParallelHashMapData_ReallocateHashMap_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_TisInstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B_mD9CA815618E4ED4EC44B7F5D9D7ACF7649BEF9AF (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_newCapacity, int32_t ___2_newBucketCapacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___3_label, const RuntimeMethod* method)
{
	((  void (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, int32_t, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148, const RuntimeMethod*))UnsafeParallelHashMapData_ReallocateHashMap_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_TisInstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B_mD9CA815618E4ED4EC44B7F5D9D7ACF7649BEF9AF_gshared)(___0_data, ___1_newCapacity, ___2_newBucketCapacity, ___3_label, method);
}
inline bool UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m907C21D03B0B07E416159F61AE6322D367A27C05 (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B* ___1_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___2_it, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B*, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC*, const RuntimeMethod*))UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m907C21D03B0B07E416159F61AE6322D367A27C05_gshared)(___0_data, ___1_item, ___2_it, method);
}
inline InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B UnsafeUtility_ReadArrayElement_TisInstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B_m86FC76E325E9D3B56133BB7A193BAF12B47FBCC1_inline (void* ___0_source, int32_t ___1_index, const RuntimeMethod* method)
{
	return ((  InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B (*) (void*, int32_t, const RuntimeMethod*))UnsafeUtility_ReadArrayElement_TisInstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B_m86FC76E325E9D3B56133BB7A193BAF12B47FBCC1_gshared_inline)(___0_source, ___1_index, method);
}
inline bool UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_m8FA051F1386B583A2848E886020D563EE0004112 (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, int32_t* ___2_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___3_it, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, int32_t*, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC*, const RuntimeMethod*))UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_m8FA051F1386B583A2848E886020D563EE0004112_gshared)(___0_data, ___1_key, ___2_item, ___3_it, method);
}
inline int32_t UnsafeParallelHashMapBase_2_AllocEntry_m800AD0805A8FEA87F79C267739A0F557ACA44015 (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_threadIndex, const RuntimeMethod* method)
{
	return ((  int32_t (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, const RuntimeMethod*))UnsafeParallelHashMapBase_2_AllocEntry_m800AD0805A8FEA87F79C267739A0F557ACA44015_gshared)(___0_data, ___1_threadIndex, method);
}
inline void UnsafeParallelHashMapBase_2_FreeEntry_m8927ACA31388B65E99B4E0301130276415771390 (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_idx, int32_t ___2_threadIndex, const RuntimeMethod* method)
{
	((  void (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, int32_t, const RuntimeMethod*))UnsafeParallelHashMapBase_2_FreeEntry_m8927ACA31388B65E99B4E0301130276415771390_gshared)(___0_data, ___1_idx, ___2_threadIndex, method);
}
inline void UnsafeParallelHashMapData_ReallocateHashMap_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m526C9313C8BCF707526B309126FFB7502C548A5D (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_newCapacity, int32_t ___2_newBucketCapacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___3_label, const RuntimeMethod* method)
{
	((  void (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, int32_t, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148, const RuntimeMethod*))UnsafeParallelHashMapData_ReallocateHashMap_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m526C9313C8BCF707526B309126FFB7502C548A5D_gshared)(___0_data, ___1_newCapacity, ___2_newBucketCapacity, ___3_label, method);
}
inline bool UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m3A37DD53E6586935E3AAC304D3AB4EF2AFF4A905 (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t* ___1_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___2_it, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t*, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC*, const RuntimeMethod*))UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m3A37DD53E6586935E3AAC304D3AB4EF2AFF4A905_gshared)(___0_data, ___1_item, ___2_it, method);
}
inline bool UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mA75399BF08E0CCAC328234FD7A71D864467E95C2 (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C ___1_key, int32_t* ___2_item, NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727* ___3_it, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C, int32_t*, NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727*, const RuntimeMethod*))UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mA75399BF08E0CCAC328234FD7A71D864467E95C2_gshared)(___0_data, ___1_key, ___2_item, ___3_it, method);
}
inline int32_t UnsafeParallelHashMapBase_2_AllocEntry_m57B325EFF67BD5485331BD2F287B463A5D8FC9C8 (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_threadIndex, const RuntimeMethod* method)
{
	return ((  int32_t (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, const RuntimeMethod*))UnsafeParallelHashMapBase_2_AllocEntry_m57B325EFF67BD5485331BD2F287B463A5D8FC9C8_gshared)(___0_data, ___1_threadIndex, method);
}
inline void UnsafeUtility_WriteArrayElement_TisRangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C_m6E993EC5F50FC82EDD84AF158A50E9FF2BAE2705_inline (void* ___0_destination, int32_t ___1_index, RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C ___2_value, const RuntimeMethod* method)
{
	((  void (*) (void*, int32_t, RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C, const RuntimeMethod*))UnsafeUtility_WriteArrayElement_TisRangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C_m6E993EC5F50FC82EDD84AF158A50E9FF2BAE2705_gshared_inline)(___0_destination, ___1_index, ___2_value, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t RangeKey_GetHashCode_mC38845B6A1CC657D6F6B1149E7448AA6A3EF3257 (RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C* __this, const RuntimeMethod* method) ;
inline void UnsafeParallelHashMapBase_2_FreeEntry_m95E0C2203337A917B366551260F10DD9AA00924A (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_idx, int32_t ___2_threadIndex, const RuntimeMethod* method)
{
	((  void (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, int32_t, const RuntimeMethod*))UnsafeParallelHashMapBase_2_FreeEntry_m95E0C2203337A917B366551260F10DD9AA00924A_gshared)(___0_data, ___1_idx, ___2_threadIndex, method);
}
inline void UnsafeParallelHashMapData_ReallocateHashMap_TisRangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m337E81148B331D4822C7412A962A569B8D2ADC59 (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_newCapacity, int32_t ___2_newBucketCapacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___3_label, const RuntimeMethod* method)
{
	((  void (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, int32_t, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148, const RuntimeMethod*))UnsafeParallelHashMapData_ReallocateHashMap_TisRangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m337E81148B331D4822C7412A962A569B8D2ADC59_gshared)(___0_data, ___1_newCapacity, ___2_newBucketCapacity, ___3_label, method);
}
inline RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C UnsafeUtility_ReadArrayElement_TisRangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C_mFDF2C4591B5F4C0AF4424ED681225F9CF100C5BB_inline (void* ___0_source, int32_t ___1_index, const RuntimeMethod* method)
{
	return ((  RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C (*) (void*, int32_t, const RuntimeMethod*))UnsafeUtility_ReadArrayElement_TisRangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C_mFDF2C4591B5F4C0AF4424ED681225F9CF100C5BB_gshared_inline)(___0_source, ___1_index, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool RangeKey_Equals_m05E612C122D91758588CEB7529751045E6F09493 (RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C* __this, RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C ___0_other, const RuntimeMethod* method) ;
inline bool UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m92F223FB6B0005A83CA9AC122EEB656E520F55AC (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t* ___1_item, NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727* ___2_it, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t*, NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727*, const RuntimeMethod*))UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m92F223FB6B0005A83CA9AC122EEB656E520F55AC_gshared)(___0_data, ___1_item, ___2_it, method);
}
inline bool UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mEB3EEF401A3CDD197AC9DE490B9CAA5F3415FBE5 (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, uint32_t ___1_key, BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770* ___2_item, NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B* ___3_it, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, uint32_t, BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770*, NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B*, const RuntimeMethod*))UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mEB3EEF401A3CDD197AC9DE490B9CAA5F3415FBE5_gshared)(___0_data, ___1_key, ___2_item, ___3_it, method);
}
inline int32_t UnsafeParallelHashMapBase_2_AllocEntry_m87F60C86A474B557B069D37548567CB2667C42FA (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_threadIndex, const RuntimeMethod* method)
{
	return ((  int32_t (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, const RuntimeMethod*))UnsafeParallelHashMapBase_2_AllocEntry_m87F60C86A474B557B069D37548567CB2667C42FA_gshared)(___0_data, ___1_threadIndex, method);
}
inline void UnsafeUtility_WriteArrayElement_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_m839FEB3192BEC0090FBA73A11E371E1A01C13ADF_inline (void* ___0_destination, int32_t ___1_index, uint32_t ___2_value, const RuntimeMethod* method)
{
	((  void (*) (void*, int32_t, uint32_t, const RuntimeMethod*))UnsafeUtility_WriteArrayElement_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_m839FEB3192BEC0090FBA73A11E371E1A01C13ADF_gshared_inline)(___0_destination, ___1_index, ___2_value, method);
}
inline void UnsafeUtility_WriteArrayElement_TisBatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770_m60CD2C2DE2B559F255B8BEA36B0554E698FF9651_inline (void* ___0_destination, int32_t ___1_index, BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770 ___2_value, const RuntimeMethod* method)
{
	((  void (*) (void*, int32_t, BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770, const RuntimeMethod*))UnsafeUtility_WriteArrayElement_TisBatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770_m60CD2C2DE2B559F255B8BEA36B0554E698FF9651_gshared_inline)(___0_destination, ___1_index, ___2_value, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UInt32_GetHashCode_mB9A03A037C079ADF0E61516BECA1AB05F92266BC (uint32_t* __this, const RuntimeMethod* method) ;
inline void UnsafeParallelHashMapBase_2_FreeEntry_m8D99BED2AEF823C1F525AF6D51D018736E33922F (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_idx, int32_t ___2_threadIndex, const RuntimeMethod* method)
{
	((  void (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, int32_t, const RuntimeMethod*))UnsafeParallelHashMapBase_2_FreeEntry_m8D99BED2AEF823C1F525AF6D51D018736E33922F_gshared)(___0_data, ___1_idx, ___2_threadIndex, method);
}
inline void UnsafeParallelHashMapData_ReallocateHashMap_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_TisBatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770_mC740151B18F0E9F81E90C5B066A052BAB9F361C4 (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_newCapacity, int32_t ___2_newBucketCapacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___3_label, const RuntimeMethod* method)
{
	((  void (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, int32_t, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148, const RuntimeMethod*))UnsafeParallelHashMapData_ReallocateHashMap_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_TisBatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770_mC740151B18F0E9F81E90C5B066A052BAB9F361C4_gshared)(___0_data, ___1_newCapacity, ___2_newBucketCapacity, ___3_label, method);
}
inline uint32_t UnsafeUtility_ReadArrayElement_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_mDA80BAFF55EA77496672B3B5B3804B55274B7E95_inline (void* ___0_source, int32_t ___1_index, const RuntimeMethod* method)
{
	return ((  uint32_t (*) (void*, int32_t, const RuntimeMethod*))UnsafeUtility_ReadArrayElement_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_mDA80BAFF55EA77496672B3B5B3804B55274B7E95_gshared_inline)(___0_source, ___1_index, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UInt32_Equals_m6BE590F34B71E27978E9146437F73A6448BA01A3 (uint32_t* __this, uint32_t ___0_obj, const RuntimeMethod* method) ;
inline bool UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m3C59C500D6E8A033EFFAD29EA56E615156D25D1D (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770* ___1_item, NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B* ___2_it, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770*, NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B*, const RuntimeMethod*))UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m3C59C500D6E8A033EFFAD29EA56E615156D25D1D_gshared)(___0_data, ___1_item, ___2_it, method);
}
inline BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770 UnsafeUtility_ReadArrayElement_TisBatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770_m80C61348EC8F9D4F73F0AAA4A69A028E6D599DCD_inline (void* ___0_source, int32_t ___1_index, const RuntimeMethod* method)
{
	return ((  BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770 (*) (void*, int32_t, const RuntimeMethod*))UnsafeUtility_ReadArrayElement_TisBatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770_m80C61348EC8F9D4F73F0AAA4A69A028E6D599DCD_gshared_inline)(___0_source, ___1_index, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2 (RuntimeObject* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 AllocatorHandle_op_Implicit_mDCF4431F31BB4A09438AE644785C4273F86B2B8D (int32_t ___0_a, const RuntimeMethod* method) ;
inline void NativeKeyValueArrays_2_Dispose_m08B6A4226A0125C6123942BE90703D08153CCE37 (NativeKeyValueArrays_2_t97DEBC72840B73CFCEE6195C4C495C675E96FAF1* __this, const RuntimeMethod* method)
{
	((  void (*) (NativeKeyValueArrays_2_t97DEBC72840B73CFCEE6195C4C495C675E96FAF1*, const RuntimeMethod*))NativeKeyValueArrays_2_Dispose_m08B6A4226A0125C6123942BE90703D08153CCE37_gshared)(__this, method);
}
inline void Pair_2__ctor_m080327976BEF3D9FBA133845A20983F2462E1D6A (Pair_2_tD9FD7901920962567EFA915194252C62C833F9F6* __this, Il2CppFullySharedGenericStruct ___0_k, Il2CppFullySharedGenericStruct ___1_v, const RuntimeMethod* method)
{
	((  void (*) (Pair_2_tF8A435CDED15A96555BAB1E37C58429B2FF464A6*, Il2CppFullySharedGenericAny, Il2CppFullySharedGenericAny, const RuntimeMethod*))Pair_2__ctor_mCA54688368FE894C9F314471A3DA94A72B709F51_gshared)((Pair_2_tF8A435CDED15A96555BAB1E37C58429B2FF464A6*)__this, (Il2CppFullySharedGenericAny)___0_k, (Il2CppFullySharedGenericAny)___1_v, method);
}
inline void UnsafeParallelHashMapData_AllocateHashMap_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m720B963A1A8BA6E3EF6204599F7B1AE86C47B938 (int32_t ___0_length, int32_t ___1_bucketLength, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___2_label, UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926** ___3_outBuf, const RuntimeMethod* method)
{
	((  void (*) (int32_t, int32_t, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148, UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926**, const RuntimeMethod*))UnsafeParallelHashMapData_AllocateHashMap_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m720B963A1A8BA6E3EF6204599F7B1AE86C47B938_gshared)(___0_length, ___1_bucketLength, ___2_label, ___3_outBuf, method);
}
inline void UnsafeParallelHashMap_2_Clear_mC24DF6084AB7BA5AECAF2DFE3C8D80CD6EEE830C (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method)
{
	((  void (*) (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*, const RuntimeMethod*))UnsafeParallelHashMap_2_Clear_mC24DF6084AB7BA5AECAF2DFE3C8D80CD6EEE830C_gshared)(__this, method);
}
inline void UnsafeParallelHashMap_2__ctor_mAC8F198D20B98C2819447D8E080EBF2F2714BFFE (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, int32_t ___0_capacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___1_allocator, const RuntimeMethod* method)
{
	((  void (*) (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*, int32_t, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148, const RuntimeMethod*))UnsafeParallelHashMap_2__ctor_mAC8F198D20B98C2819447D8E080EBF2F2714BFFE_gshared)(__this, ___0_capacity, ___1_allocator, method);
}
inline bool UnsafeParallelHashMap_2_get_IsCreated_m21986D033E89DA3F44B7D0C5B99F57C93E9FBFCC_inline (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*, const RuntimeMethod*))UnsafeParallelHashMap_2_get_IsCreated_m21986D033E89DA3F44B7D0C5B99F57C93E9FBFCC_gshared_inline)(__this, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapData_IsEmpty_m24404CDC35842532023F9D7094DB24BCBD57EC9D (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, const RuntimeMethod* method) ;
inline bool UnsafeParallelHashMap_2_get_IsEmpty_m2EB3B4B325AAF39DA286FF82FDB26405AE271998_inline (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*, const RuntimeMethod*))UnsafeParallelHashMap_2_get_IsEmpty_m2EB3B4B325AAF39DA286FF82FDB26405AE271998_gshared_inline)(__this, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapData_GetCount_mF10300D8E62B36979B41F3CBE396D96721931D7B (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, const RuntimeMethod* method) ;
inline int32_t UnsafeParallelHashMap_2_Count_m3B17849FD6E9AEFC745138B43A5F5924BDA651A6 (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*, const RuntimeMethod*))UnsafeParallelHashMap_2_Count_m3B17849FD6E9AEFC745138B43A5F5924BDA651A6_gshared)(__this, method);
}
inline int32_t UnsafeParallelHashMap_2_get_Capacity_m5516D69B8E5C8A61A3B8112E3B0C0DC701FDEF20_inline (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*, const RuntimeMethod*))UnsafeParallelHashMap_2_get_Capacity_m5516D69B8E5C8A61A3B8112E3B0C0DC701FDEF20_gshared_inline)(__this, method);
}
inline void UnsafeParallelHashMap_2_set_Capacity_mD1D227DF7720121254BBE5435F29C5CB94D97831 (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, int32_t ___0_value, const RuntimeMethod* method)
{
	((  void (*) (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*, int32_t, const RuntimeMethod*))UnsafeParallelHashMap_2_set_Capacity_mD1D227DF7720121254BBE5435F29C5CB94D97831_gshared)(__this, ___0_value, method);
}
inline void UnsafeParallelHashMapBase_2_Clear_mEFDB8CAFDB397D0E8A4279CA11C361A29EC8A4BB (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, const RuntimeMethod* method)
{
	((  void (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, const RuntimeMethod*))UnsafeParallelHashMapBase_2_Clear_mEFDB8CAFDB397D0E8A4279CA11C361A29EC8A4BB_gshared)(___0_data, method);
}
inline int32_t UnsafeParallelHashMapBase_2_Remove_mD0A7EC52AF9067A81379B898E9F19FA26F3F4B88 (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___1_key, bool ___2_isMultiHashMap, const RuntimeMethod* method)
{
	return ((  int32_t (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94, bool, const RuntimeMethod*))UnsafeParallelHashMapBase_2_Remove_mD0A7EC52AF9067A81379B898E9F19FA26F3F4B88_gshared)(___0_data, ___1_key, ___2_isMultiHashMap, method);
}
inline bool UnsafeParallelHashMap_2_Remove_mE398837783AB4D7D5B1519D6B47F03F029B40A9A (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___0_key, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94, const RuntimeMethod*))UnsafeParallelHashMap_2_Remove_mE398837783AB4D7D5B1519D6B47F03F029B40A9A_gshared)(__this, ___0_key, method);
}
inline bool UnsafeParallelHashMap_2_TryGetValue_m6B967A3210A9091B292D0A38D4D8A190E5DC59A6 (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___0_key, int32_t* ___1_item, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94, int32_t*, const RuntimeMethod*))UnsafeParallelHashMap_2_TryGetValue_m6B967A3210A9091B292D0A38D4D8A190E5DC59A6_gshared)(__this, ___0_key, ___1_item, method);
}
inline bool UnsafeParallelHashMap_2_ContainsKey_mFBBB13C3C28724EEB5E77C8EBCF29B6EFEAE9C8C (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___0_key, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94, const RuntimeMethod*))UnsafeParallelHashMap_2_ContainsKey_mFBBB13C3C28724EEB5E77C8EBCF29B6EFEAE9C8C_gshared)(__this, ___0_key, method);
}
inline bool UnsafeParallelHashMapBase_2_SetValue_mBC2EB4E62A5FAA365C4795E1D7FA3F3ED271F97A (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A* ___1_it, int32_t* ___2_item, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A*, int32_t*, const RuntimeMethod*))UnsafeParallelHashMapBase_2_SetValue_mBC2EB4E62A5FAA365C4795E1D7FA3F3ED271F97A_gshared)(___0_data, ___1_it, ___2_item, method);
}
inline bool UnsafeParallelHashMapBase_2_TryAdd_m7575B5C2D0CB741CCB79BFF102B543F951D1A91A (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___1_key, int32_t ___2_item, bool ___3_isMultiHashMap, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___4_allocation, const RuntimeMethod* method)
{
	return ((  bool (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94, int32_t, bool, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148, const RuntimeMethod*))UnsafeParallelHashMapBase_2_TryAdd_m7575B5C2D0CB741CCB79BFF102B543F951D1A91A_gshared)(___0_data, ___1_key, ___2_item, ___3_isMultiHashMap, ___4_allocation, method);
}
inline void UnsafeParallelHashMap_2_set_Item_m78B278F2F9ECFF6DD543068ED4A22897FFEA5017 (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___0_key, int32_t ___1_value, const RuntimeMethod* method)
{
	((  void (*) (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94, int32_t, const RuntimeMethod*))UnsafeParallelHashMap_2_set_Item_m78B278F2F9ECFF6DD543068ED4A22897FFEA5017_gshared)(__this, ___0_key, ___1_value, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapData_DeallocateHashMap_m8D0FEE08B8522A1D05FBFFBBB43CB203304F114F (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___1_allocator, const RuntimeMethod* method) ;
inline void UnsafeParallelHashMap_2_Dispose_m90F628584C865984113787BB0EC79383B00A069C (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method)
{
	((  void (*) (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*, const RuntimeMethod*))UnsafeParallelHashMap_2_Dispose_m90F628584C865984113787BB0EC79383B00A069C_gshared)(__this, method);
}
inline NativeArray_1_t2FF0F1BBD323229A2F9ABD52397EA6EF9B105E09 CollectionHelper_CreateNativeArray_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_mAF52A80BBB617F62596D58F8FFD9E3E6AA9DB60F (int32_t ___0_length, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___1_allocator, int32_t ___2_options, const RuntimeMethod* method)
{
	return ((  NativeArray_1_t2FF0F1BBD323229A2F9ABD52397EA6EF9B105E09 (*) (int32_t, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148, int32_t, const RuntimeMethod*))CollectionHelper_CreateNativeArray_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_mAF52A80BBB617F62596D58F8FFD9E3E6AA9DB60F_gshared)(___0_length, ___1_allocator, ___2_options, method);
}
inline void UnsafeParallelHashMapData_GetKeyArray_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_m49E855A91D083A54CFF44DEB13335123AD3C4001 (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, NativeArray_1_t2FF0F1BBD323229A2F9ABD52397EA6EF9B105E09 ___1_result, const RuntimeMethod* method)
{
	((  void (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, NativeArray_1_t2FF0F1BBD323229A2F9ABD52397EA6EF9B105E09, const RuntimeMethod*))UnsafeParallelHashMapData_GetKeyArray_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_m49E855A91D083A54CFF44DEB13335123AD3C4001_gshared)(___0_data, ___1_result, method);
}
inline NativeArray_1_t2FF0F1BBD323229A2F9ABD52397EA6EF9B105E09 UnsafeParallelHashMap_2_GetKeyArray_m0790F3B72CBA21D7B667E1A333E76DEAC8678138 (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___0_allocator, const RuntimeMethod* method)
{
	return ((  NativeArray_1_t2FF0F1BBD323229A2F9ABD52397EA6EF9B105E09 (*) (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148, const RuntimeMethod*))UnsafeParallelHashMap_2_GetKeyArray_m0790F3B72CBA21D7B667E1A333E76DEAC8678138_gshared)(__this, ___0_allocator, method);
}
inline NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C CollectionHelper_CreateNativeArray_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m53D2BC04C5127B3B1163A395E36386918CACFE4B (int32_t ___0_length, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___1_allocator, int32_t ___2_options, const RuntimeMethod* method)
{
	return ((  NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C (*) (int32_t, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148, int32_t, const RuntimeMethod*))CollectionHelper_CreateNativeArray_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m53D2BC04C5127B3B1163A395E36386918CACFE4B_gshared)(___0_length, ___1_allocator, ___2_options, method);
}
inline void UnsafeParallelHashMapData_GetValueArray_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m4769F528CC3AB04D768F83B2A2A016AE29C5F87E (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C ___1_result, const RuntimeMethod* method)
{
	((  void (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C, const RuntimeMethod*))UnsafeParallelHashMapData_GetValueArray_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m4769F528CC3AB04D768F83B2A2A016AE29C5F87E_gshared)(___0_data, ___1_result, method);
}
inline NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C UnsafeParallelHashMap_2_GetValueArray_m28E06E6A40485B8C1E9CEB5D9AD5DCEB3FD937B7 (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___0_allocator, const RuntimeMethod* method)
{
	return ((  NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C (*) (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148, const RuntimeMethod*))UnsafeParallelHashMap_2_GetValueArray_m28E06E6A40485B8C1E9CEB5D9AD5DCEB3FD937B7_gshared)(__this, ___0_allocator, method);
}
inline void NativeKeyValueArrays_2__ctor_m5C1BD5C2D8BD4FE03EC32866EEDF2EBECAB7B7F3 (NativeKeyValueArrays_2_t6F346645686D9ED3DF9980242A60F6343D9BD346* __this, int32_t ___0_length, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___1_allocator, int32_t ___2_options, const RuntimeMethod* method)
{
	((  void (*) (NativeKeyValueArrays_2_t6F346645686D9ED3DF9980242A60F6343D9BD346*, int32_t, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148, int32_t, const RuntimeMethod*))NativeKeyValueArrays_2__ctor_m5C1BD5C2D8BD4FE03EC32866EEDF2EBECAB7B7F3_gshared)(__this, ___0_length, ___1_allocator, ___2_options, method);
}
inline void UnsafeParallelHashMapData_GetKeyValueArrays_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_mC3C2330139E264EC4EB952292BE242F6511CA8E6 (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, NativeKeyValueArrays_2_t6F346645686D9ED3DF9980242A60F6343D9BD346 ___1_result, const RuntimeMethod* method)
{
	((  void (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, NativeKeyValueArrays_2_t6F346645686D9ED3DF9980242A60F6343D9BD346, const RuntimeMethod*))UnsafeParallelHashMapData_GetKeyValueArrays_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_mC3C2330139E264EC4EB952292BE242F6511CA8E6_gshared)(___0_data, ___1_result, method);
}
inline NativeKeyValueArrays_2_t6F346645686D9ED3DF9980242A60F6343D9BD346 UnsafeParallelHashMap_2_GetKeyValueArrays_mBAD0B630B8637FBD3415B9CA1EB4912C07A0183A (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___0_allocator, const RuntimeMethod* method)
{
	return ((  NativeKeyValueArrays_2_t6F346645686D9ED3DF9980242A60F6343D9BD346 (*) (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148, const RuntimeMethod*))UnsafeParallelHashMap_2_GetKeyValueArrays_mBAD0B630B8637FBD3415B9CA1EB4912C07A0183A_gshared)(__this, ___0_allocator, method);
}
inline ParallelWriter_t725B9E76F960232582498637DEF16962C7959261 UnsafeParallelHashMap_2_AsParallelWriter_mBB99B9D2617627AD5097AA220071CE11F5F93C2D (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method)
{
	return ((  ParallelWriter_t725B9E76F960232582498637DEF16962C7959261 (*) (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*, const RuntimeMethod*))UnsafeParallelHashMap_2_AsParallelWriter_mBB99B9D2617627AD5097AA220071CE11F5F93C2D_gshared)(__this, method);
}
inline RuntimeObject* UnsafeParallelHashMap_2_System_Collections_Generic_IEnumerableU3CUnity_Collections_LowLevel_Unsafe_KeyValueU3CTKeyU2CTValueU3EU3E_GetEnumerator_m22AAA28BF2A503A1A9ACC7D180DA65A1F2AA0A86 (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method)
{
	return ((  RuntimeObject* (*) (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*, const RuntimeMethod*))UnsafeParallelHashMap_2_System_Collections_Generic_IEnumerableU3CUnity_Collections_LowLevel_Unsafe_KeyValueU3CTKeyU2CTValueU3EU3E_GetEnumerator_m22AAA28BF2A503A1A9ACC7D180DA65A1F2AA0A86_gshared)(__this, method);
}
inline RuntimeObject* UnsafeParallelHashMap_2_System_Collections_IEnumerable_GetEnumerator_m1F6D4EBACBE01E83D9F84CF51098880680AFA3B5 (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method)
{
	return ((  RuntimeObject* (*) (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*, const RuntimeMethod*))UnsafeParallelHashMap_2_System_Collections_IEnumerable_GetEnumerator_m1F6D4EBACBE01E83D9F84CF51098880680AFA3B5_gshared)(__this, method);
}
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeList_1_get_Length_m2673797C6B1B5ED6A4C644298C555559E56C2682_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___m_length;
		int32_t L_1;
		L_1 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_0, NULL);
		return L_1;
	}
}
IL2CPP_EXTERN_C  int32_t UnsafeList_1_get_Length_m2673797C6B1B5ED6A4C644298C555559E56C2682_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	int32_t _returnValue;
	_returnValue = UnsafeList_1_get_Length_m2673797C6B1B5ED6A4C644298C555559E56C2682_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_set_Length_m6423940AFC690B5C652FD231D5C2E7836ECE70B1_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_value, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		int32_t L_0 = ___0_value;
		int32_t L_1;
		L_1 = UnsafeList_1_get_Capacity_mE66A788D02ACCA321ADEC1D5939D6A0CC38E4A59_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_0 = (bool)((((int32_t)L_0) > ((int32_t)L_1))? 1 : 0);
		bool L_2 = V_0;
		if (!L_2)
		{
			goto IL_001b;
		}
	}
	{
		int32_t L_3 = ___0_value;
		UnsafeList_1_Resize_m89BDE747429473AE232DB084BC36EF48F3AB388D(__this, L_3, (int32_t)0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 3));
		goto IL_0024;
	}

IL_001b:
	{
		int32_t L_4 = ___0_value;
		__this->___m_length = L_4;
	}

IL_0024:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_set_Length_m6423940AFC690B5C652FD231D5C2E7836ECE70B1_AdjustorThunk (RuntimeObject* __this, int32_t ___0_value, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	UnsafeList_1_set_Length_m6423940AFC690B5C652FD231D5C2E7836ECE70B1(_thisAdjusted, ___0_value, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeList_1_get_Capacity_mE66A788D02ACCA321ADEC1D5939D6A0CC38E4A59_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___m_capacity;
		int32_t L_1;
		L_1 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_0, NULL);
		return L_1;
	}
}
IL2CPP_EXTERN_C  int32_t UnsafeList_1_get_Capacity_mE66A788D02ACCA321ADEC1D5939D6A0CC38E4A59_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	int32_t _returnValue;
	_returnValue = UnsafeList_1_get_Capacity_mE66A788D02ACCA321ADEC1D5939D6A0CC38E4A59_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_set_Capacity_mAB36448D47F99512F264E69A11C23435D531D148_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_value, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___0_value;
		UnsafeList_1_SetCapacity_m01856897AA0378888156C6C865FD2DF003259402(__this, L_0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 4));
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_set_Capacity_mAB36448D47F99512F264E69A11C23435D531D148_AdjustorThunk (RuntimeObject* __this, int32_t ___0_value, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	UnsafeList_1_set_Capacity_mAB36448D47F99512F264E69A11C23435D531D148(_thisAdjusted, ___0_value, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D UnsafeList_1_get_Item_mE621D922A067844ECFB3EC3FD5CAF0F18284C825_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_index, const RuntimeMethod* method) 
{
	OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_0 = __this->___Ptr;
		int32_t L_1 = ___0_index;
		int32_t L_2;
		L_2 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_1, NULL);
		uint32_t L_3 = sizeof(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D);
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D L_4 = (*(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)((OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_2), (int32_t)L_3)))));
		V_0 = L_4;
		goto IL_001e;
	}

IL_001e:
	{
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D L_5 = V_0;
		return L_5;
	}
}
IL2CPP_EXTERN_C  OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D UnsafeList_1_get_Item_mE621D922A067844ECFB3EC3FD5CAF0F18284C825_AdjustorThunk (RuntimeObject* __this, int32_t ___0_index, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D _returnValue;
	_returnValue = UnsafeList_1_get_Item_mE621D922A067844ECFB3EC3FD5CAF0F18284C825_inline(_thisAdjusted, ___0_index, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_set_Item_m36035574C8D1A1555A348CD8F326A3FB2F57A28B_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_index, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D ___1_value, const RuntimeMethod* method) 
{
	{
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_0 = __this->___Ptr;
		int32_t L_1 = ___0_index;
		int32_t L_2;
		L_2 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_1, NULL);
		uint32_t L_3 = sizeof(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D);
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D L_4 = ___1_value;
		*(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)((OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_2), (int32_t)L_3)))) = L_4;
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_set_Item_m36035574C8D1A1555A348CD8F326A3FB2F57A28B_AdjustorThunk (RuntimeObject* __this, int32_t ___0_index, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D ___1_value, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	UnsafeList_1_set_Item_m36035574C8D1A1555A348CD8F326A3FB2F57A28B_inline(_thisAdjusted, ___0_index, ___1_value, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* UnsafeList_1_ElementAt_mDD19B169590525B93B12C98E9AD8209253E9A14B_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_index, const RuntimeMethod* method) 
{
	OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* V_0 = NULL;
	{
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_0 = __this->___Ptr;
		int32_t L_1 = ___0_index;
		int32_t L_2;
		L_2 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_1, NULL);
		uint32_t L_3 = sizeof(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D);
		V_0 = (OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)((OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_2), (int32_t)L_3))));
		goto IL_0019;
	}

IL_0019:
	{
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_4 = V_0;
		return L_4;
	}
}
IL2CPP_EXTERN_C  OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* UnsafeList_1_ElementAt_mDD19B169590525B93B12C98E9AD8209253E9A14B_AdjustorThunk (RuntimeObject* __this, int32_t ___0_index, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* _returnValue;
	_returnValue = UnsafeList_1_ElementAt_mDD19B169590525B93B12C98E9AD8209253E9A14B_inline(_thisAdjusted, ___0_index, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1__ctor_m78B8DF184E817B787E1312BB4D0201ADE648B464_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_initialCapacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___1_allocator, int32_t ___2_options, const RuntimeMethod* method) 
{
	bool V_0 = false;
	int32_t V_1 = 0;
	int32_t G_B3_0 = 0;
	{
		__this->___Ptr = (OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)((uintptr_t)0);
		__this->___m_length = 0;
		__this->___m_capacity = 0;
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_0 = ___1_allocator;
		__this->___Allocator = L_0;
		__this->___padding = 0;
		int32_t L_1 = ___0_initialCapacity;
		int32_t L_2;
		L_2 = math_max_m9083201D37A8ED0157B127B5878D9B7F3A2A40BE_inline(L_1, 1, NULL);
		UnsafeList_1_SetCapacity_m01856897AA0378888156C6C865FD2DF003259402(__this, L_2, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 4));
		int32_t L_3 = ___2_options;
		if ((!(((uint32_t)L_3) == ((uint32_t)1))))
		{
			goto IL_0046;
		}
	}
	{
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_4 = __this->___Ptr;
		G_B3_0 = ((((int32_t)((((intptr_t)L_4) == ((intptr_t)((uintptr_t)0)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0047;
	}

IL_0046:
	{
		G_B3_0 = 0;
	}

IL_0047:
	{
		V_0 = (bool)G_B3_0;
		bool L_5 = V_0;
		if (!L_5)
		{
			goto IL_0069;
		}
	}
	{
		uint32_t L_6 = sizeof(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D);
		V_1 = (int32_t)L_6;
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_7 = __this->___Ptr;
		int32_t L_8;
		L_8 = UnsafeList_1_get_Capacity_mE66A788D02ACCA321ADEC1D5939D6A0CC38E4A59_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_9 = V_1;
		UnsafeUtility_MemClear_m6C4377117084A11A667A567BC2F5E606A632A7C1((void*)L_7, ((int64_t)((int32_t)il2cpp_codegen_multiply(L_8, L_9))), NULL);
	}

IL_0069:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1__ctor_m78B8DF184E817B787E1312BB4D0201ADE648B464_AdjustorThunk (RuntimeObject* __this, int32_t ___0_initialCapacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___1_allocator, int32_t ___2_options, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	UnsafeList_1__ctor_m78B8DF184E817B787E1312BB4D0201ADE648B464(_thisAdjusted, ___0_initialCapacity, ___1_allocator, ___2_options, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_Destroy_m3A15F0A2436181A65C4936FAD007CF375A18E451_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* ___0_listData, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AllocatorManager_tFB15A22029C8159A3DCD4C08935BE57D3E6B3C2C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* L_0 = ___0_listData;
		NullCheck(L_0);
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_1 = L_0->___Allocator;
		V_0 = L_1;
		UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* L_2 = ___0_listData;
		UnsafeList_1_Dispose_m7B6479F22BFCA86FEE3DEC0A150D235AD33C0C07((UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*)L_2, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 11));
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_3 = V_0;
		UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* L_4 = ___0_listData;
		il2cpp_codegen_runtime_class_init_inline(AllocatorManager_tFB15A22029C8159A3DCD4C08935BE57D3E6B3C2C_il2cpp_TypeInfo_var);
		AllocatorManager_Free_TisUnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA_m12AAB43E03ED61A46066096547F98A862672EC89(L_3, L_4, 1, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeList_1_get_IsEmpty_m923A6014BAA5DC0E86E533ACE70D5C441A3F37DD_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method) 
{
	int32_t G_B3_0 = 0;
	{
		bool L_0;
		L_0 = UnsafeList_1_get_IsCreated_m51C65B44C2F88F5642E21BC850480BAEEA7EA65D_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		if (!L_0)
		{
			goto IL_0013;
		}
	}
	{
		int32_t L_1 = __this->___m_length;
		G_B3_0 = ((((int32_t)L_1) == ((int32_t)0))? 1 : 0);
		goto IL_0014;
	}

IL_0013:
	{
		G_B3_0 = 1;
	}

IL_0014:
	{
		return (bool)G_B3_0;
	}
}
IL2CPP_EXTERN_C  bool UnsafeList_1_get_IsEmpty_m923A6014BAA5DC0E86E533ACE70D5C441A3F37DD_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	bool _returnValue;
	_returnValue = UnsafeList_1_get_IsEmpty_m923A6014BAA5DC0E86E533ACE70D5C441A3F37DD_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeList_1_get_IsCreated_m51C65B44C2F88F5642E21BC850480BAEEA7EA65D_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method) 
{
	{
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_0 = __this->___Ptr;
		return (bool)((((int32_t)((((intptr_t)L_0) == ((intptr_t)((uintptr_t)0)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
	}
}
IL2CPP_EXTERN_C  bool UnsafeList_1_get_IsCreated_m51C65B44C2F88F5642E21BC850480BAEEA7EA65D_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	bool _returnValue;
	_returnValue = UnsafeList_1_get_IsCreated_m51C65B44C2F88F5642E21BC850480BAEEA7EA65D_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_Dispose_m7B6479F22BFCA86FEE3DEC0A150D235AD33C0C07_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AllocatorManager_tFB15A22029C8159A3DCD4C08935BE57D3E6B3C2C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	bool V_1 = false;
	{
		bool L_0;
		L_0 = UnsafeList_1_get_IsCreated_m51C65B44C2F88F5642E21BC850480BAEEA7EA65D_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		V_0 = (bool)((((int32_t)L_0) == ((int32_t)0))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0011;
		}
	}
	{
		goto IL_005b;
	}

IL_0011:
	{
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_2 = __this->___Allocator;
		bool L_3;
		L_3 = CollectionHelper_ShouldDeallocate_m505E7EDBA71F02BAF52CC9DCD7C593CDA85D5465(L_2, NULL);
		V_1 = L_3;
		bool L_4 = V_1;
		if (!L_4)
		{
			goto IL_0045;
		}
	}
	{
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_5 = __this->___Allocator;
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_6 = __this->___Ptr;
		int32_t L_7 = __this->___m_capacity;
		il2cpp_codegen_runtime_class_init_inline(AllocatorManager_tFB15A22029C8159A3DCD4C08935BE57D3E6B3C2C_il2cpp_TypeInfo_var);
		AllocatorManager_Free_TisOccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D_m1D8738CAAA65C0C8EE9CEC9F7E1D134982B6EEC1(L_5, L_6, L_7, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 14));
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_8 = ((AllocatorManager_tFB15A22029C8159A3DCD4C08935BE57D3E6B3C2C_StaticFields*)il2cpp_codegen_static_fields_for(AllocatorManager_tFB15A22029C8159A3DCD4C08935BE57D3E6B3C2C_il2cpp_TypeInfo_var))->___Invalid;
		__this->___Allocator = L_8;
	}

IL_0045:
	{
		__this->___Ptr = (OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)((uintptr_t)0);
		__this->___m_length = 0;
		__this->___m_capacity = 0;
	}

IL_005b:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_Dispose_m7B6479F22BFCA86FEE3DEC0A150D235AD33C0C07_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	UnsafeList_1_Dispose_m7B6479F22BFCA86FEE3DEC0A150D235AD33C0C07(_thisAdjusted, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_Clear_mD1843F62E98923982BE1E628A12286716B6B088D_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method) 
{
	{
		__this->___m_length = 0;
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_Clear_mD1843F62E98923982BE1E628A12286716B6B088D_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	UnsafeList_1_Clear_mD1843F62E98923982BE1E628A12286716B6B088D(_thisAdjusted, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_Resize_m89BDE747429473AE232DB084BC36EF48F3AB388D_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_length, int32_t ___1_options, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	bool V_1 = false;
	bool V_2 = false;
	int32_t V_3 = 0;
	uint8_t* V_4 = NULL;
	int32_t V_5 = 0;
	int32_t G_B5_0 = 0;
	{
		int32_t L_0 = __this->___m_length;
		V_0 = L_0;
		int32_t L_1 = ___0_length;
		int32_t L_2;
		L_2 = UnsafeList_1_get_Capacity_mE66A788D02ACCA321ADEC1D5939D6A0CC38E4A59_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_1 = (bool)((((int32_t)L_1) > ((int32_t)L_2))? 1 : 0);
		bool L_3 = V_1;
		if (!L_3)
		{
			goto IL_001f;
		}
	}
	{
		int32_t L_4 = ___0_length;
		UnsafeList_1_SetCapacity_m01856897AA0378888156C6C865FD2DF003259402(__this, L_4, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 4));
	}

IL_001f:
	{
		int32_t L_5 = ___0_length;
		__this->___m_length = L_5;
		int32_t L_6 = ___1_options;
		if ((!(((uint32_t)L_6) == ((uint32_t)1))))
		{
			goto IL_0030;
		}
	}
	{
		int32_t L_7 = V_0;
		int32_t L_8 = ___0_length;
		G_B5_0 = ((((int32_t)L_7) < ((int32_t)L_8))? 1 : 0);
		goto IL_0031;
	}

IL_0030:
	{
		G_B5_0 = 0;
	}

IL_0031:
	{
		V_2 = (bool)G_B5_0;
		bool L_9 = V_2;
		if (!L_9)
		{
			goto IL_005d;
		}
	}
	{
		int32_t L_10 = ___0_length;
		int32_t L_11 = V_0;
		V_3 = ((int32_t)il2cpp_codegen_subtract(L_10, L_11));
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_12 = __this->___Ptr;
		V_4 = (uint8_t*)L_12;
		uint32_t L_13 = sizeof(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D);
		V_5 = (int32_t)L_13;
		uint8_t* L_14 = V_4;
		int32_t L_15 = V_0;
		int32_t L_16 = V_5;
		int32_t L_17 = V_3;
		int32_t L_18 = V_5;
		UnsafeUtility_MemClear_m6C4377117084A11A667A567BC2F5E606A632A7C1((void*)((uint8_t*)il2cpp_codegen_add((intptr_t)L_14, ((int32_t)il2cpp_codegen_multiply(L_15, L_16)))), ((int64_t)((int32_t)il2cpp_codegen_multiply(L_17, L_18))), NULL);
	}

IL_005d:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_Resize_m89BDE747429473AE232DB084BC36EF48F3AB388D_AdjustorThunk (RuntimeObject* __this, int32_t ___0_length, int32_t ___1_options, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	UnsafeList_1_Resize_m89BDE747429473AE232DB084BC36EF48F3AB388D(_thisAdjusted, ___0_length, ___1_options, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_ResizeExact_mC34252029ACF4302C3D7CEE4BFAD197FDEF9B63F_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_capacity, const RuntimeMethod* method) 
{
	{
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148* L_0 = (AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148*)(&__this->___Allocator);
		int32_t L_1 = ___0_capacity;
		UnsafeList_1_ResizeExact_TisAllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148_m7A38863CD3BF2355094DE46CB04CD7523D63E2B5(__this, L_0, L_1, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 16));
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_ResizeExact_mC34252029ACF4302C3D7CEE4BFAD197FDEF9B63F_AdjustorThunk (RuntimeObject* __this, int32_t ___0_capacity, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	UnsafeList_1_ResizeExact_mC34252029ACF4302C3D7CEE4BFAD197FDEF9B63F(_thisAdjusted, ___0_capacity, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_SetCapacity_m01856897AA0378888156C6C865FD2DF003259402_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_capacity, const RuntimeMethod* method) 
{
	{
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148* L_0 = (AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148*)(&__this->___Allocator);
		int32_t L_1 = ___0_capacity;
		UnsafeList_1_SetCapacity_TisAllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148_m967AD73DBFD45924CADA85BB4CCFE0F67C073288(__this, L_0, L_1, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 17));
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_SetCapacity_m01856897AA0378888156C6C865FD2DF003259402_AdjustorThunk (RuntimeObject* __this, int32_t ___0_capacity, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	UnsafeList_1_SetCapacity_m01856897AA0378888156C6C865FD2DF003259402(_thisAdjusted, ___0_capacity, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_TrimExcess_m1E1A21C4F507B272A2375B26F3572B6CD5940FEC_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		int32_t L_0;
		L_0 = UnsafeList_1_get_Capacity_mE66A788D02ACCA321ADEC1D5939D6A0CC38E4A59_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_1 = __this->___m_length;
		V_0 = (bool)((((int32_t)((((int32_t)L_0) == ((int32_t)L_1))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_2 = V_0;
		if (!L_2)
		{
			goto IL_0025;
		}
	}
	{
		int32_t L_3 = __this->___m_length;
		UnsafeList_1_ResizeExact_mC34252029ACF4302C3D7CEE4BFAD197FDEF9B63F(__this, L_3, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 18));
	}

IL_0025:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_TrimExcess_m1E1A21C4F507B272A2375B26F3572B6CD5940FEC_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	UnsafeList_1_TrimExcess_m1E1A21C4F507B272A2375B26F3572B6CD5940FEC(_thisAdjusted, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_AddNoResize_m4C7CDA5A177C8AAE7272628C31A4981DFC474F33_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D ___0_value, const RuntimeMethod* method) 
{
	{
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_0 = __this->___Ptr;
		int32_t L_1 = __this->___m_length;
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D L_2 = ___0_value;
		UnsafeUtility_WriteArrayElement_TisOccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D_mFCD82994FD19F18D338DCAB93FEA4EA811589FC1_inline((void*)L_0, L_1, L_2, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 19));
		int32_t L_3 = __this->___m_length;
		__this->___m_length = ((int32_t)il2cpp_codegen_add(L_3, 1));
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_AddNoResize_m4C7CDA5A177C8AAE7272628C31A4981DFC474F33_AdjustorThunk (RuntimeObject* __this, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D ___0_value, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	UnsafeList_1_AddNoResize_m4C7CDA5A177C8AAE7272628C31A4981DFC474F33_inline(_thisAdjusted, ___0_value, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_AddRangeNoResize_m58B18264D9443085CDF9ED97B68B29680BFC3B62_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, void* ___0_ptr, int32_t ___1_count, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	void* V_1 = NULL;
	{
		uint32_t L_0 = sizeof(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D);
		V_0 = (int32_t)L_0;
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_1 = __this->___Ptr;
		int32_t L_2 = __this->___m_length;
		int32_t L_3 = V_0;
		V_1 = (void*)((OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)il2cpp_codegen_add((intptr_t)L_1, ((int32_t)il2cpp_codegen_multiply(L_2, L_3))));
		void* L_4 = V_1;
		void* L_5 = ___0_ptr;
		int32_t L_6 = ___1_count;
		int32_t L_7 = V_0;
		UnsafeUtility_MemCpy_m5CEA91ACDADC522E584AE3A2AB2B0B74393A9177(L_4, L_5, ((int64_t)((int32_t)il2cpp_codegen_multiply(L_6, L_7))), NULL);
		int32_t L_8 = __this->___m_length;
		int32_t L_9 = ___1_count;
		__this->___m_length = ((int32_t)il2cpp_codegen_add(L_8, L_9));
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_AddRangeNoResize_m58B18264D9443085CDF9ED97B68B29680BFC3B62_AdjustorThunk (RuntimeObject* __this, void* ___0_ptr, int32_t ___1_count, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	UnsafeList_1_AddRangeNoResize_m58B18264D9443085CDF9ED97B68B29680BFC3B62(_thisAdjusted, ___0_ptr, ___1_count, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_AddRangeNoResize_m53CEB7657BE8E2303312C186BAEF91C9E5CE6409_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA ___0_list, const RuntimeMethod* method) 
{
	{
		UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA L_0 = ___0_list;
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_1 = L_0.___Ptr;
		int32_t L_2;
		L_2 = UnsafeList_1_get_Length_m2673797C6B1B5ED6A4C644298C555559E56C2682_inline((&___0_list), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 20));
		int32_t L_3;
		L_3 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_2, NULL);
		UnsafeList_1_AddRangeNoResize_m58B18264D9443085CDF9ED97B68B29680BFC3B62(__this, (void*)L_1, L_3, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 21));
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_AddRangeNoResize_m53CEB7657BE8E2303312C186BAEF91C9E5CE6409_AdjustorThunk (RuntimeObject* __this, UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA ___0_list, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	UnsafeList_1_AddRangeNoResize_m53CEB7657BE8E2303312C186BAEF91C9E5CE6409(_thisAdjusted, ___0_list, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_Add_m1821E69B90EE213D7B3B9509F69E635B52C61023_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* ___0_value, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	bool V_1 = false;
	{
		int32_t L_0 = __this->___m_length;
		V_0 = L_0;
		int32_t L_1 = __this->___m_length;
		int32_t L_2 = __this->___m_capacity;
		V_1 = (bool)((((int32_t)L_1) < ((int32_t)L_2))? 1 : 0);
		bool L_3 = V_1;
		if (!L_3)
		{
			goto IL_0046;
		}
	}
	{
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_4 = __this->___Ptr;
		int32_t L_5 = V_0;
		uint32_t L_6 = sizeof(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D);
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_7 = ___0_value;
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D L_8 = (*(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)L_7);
		*(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)((OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)il2cpp_codegen_add((intptr_t)L_4, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_5), (int32_t)L_6)))) = L_8;
		int32_t L_9 = __this->___m_length;
		__this->___m_length = ((int32_t)il2cpp_codegen_add(L_9, 1));
		goto IL_006c;
	}

IL_0046:
	{
		int32_t L_10 = V_0;
		UnsafeList_1_Resize_m89BDE747429473AE232DB084BC36EF48F3AB388D(__this, ((int32_t)il2cpp_codegen_add(L_10, 1)), (int32_t)0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 3));
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_11 = __this->___Ptr;
		int32_t L_12 = V_0;
		uint32_t L_13 = sizeof(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D);
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_14 = ___0_value;
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D L_15 = (*(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)L_14);
		*(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)((OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)il2cpp_codegen_add((intptr_t)L_11, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_12), (int32_t)L_13)))) = L_15;
	}

IL_006c:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_Add_m1821E69B90EE213D7B3B9509F69E635B52C61023_AdjustorThunk (RuntimeObject* __this, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* ___0_value, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	UnsafeList_1_Add_m1821E69B90EE213D7B3B9509F69E635B52C61023_inline(_thisAdjusted, ___0_value, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_AddRange_m97C70050DCA30C2909EE9DA07B283929020C8D11_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, void* ___0_ptr, int32_t ___1_count, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	void* V_2 = NULL;
	bool V_3 = false;
	{
		int32_t L_0 = __this->___m_length;
		V_0 = L_0;
		int32_t L_1 = __this->___m_length;
		int32_t L_2 = ___1_count;
		int32_t L_3;
		L_3 = UnsafeList_1_get_Capacity_mE66A788D02ACCA321ADEC1D5939D6A0CC38E4A59_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_3 = (bool)((((int32_t)((int32_t)il2cpp_codegen_add(L_1, L_2))) > ((int32_t)L_3))? 1 : 0);
		bool L_4 = V_3;
		if (!L_4)
		{
			goto IL_0030;
		}
	}
	{
		int32_t L_5 = __this->___m_length;
		int32_t L_6 = ___1_count;
		UnsafeList_1_Resize_m89BDE747429473AE232DB084BC36EF48F3AB388D(__this, ((int32_t)il2cpp_codegen_add(L_5, L_6)), (int32_t)0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 3));
		goto IL_0040;
	}

IL_0030:
	{
		int32_t L_7 = __this->___m_length;
		int32_t L_8 = ___1_count;
		__this->___m_length = ((int32_t)il2cpp_codegen_add(L_7, L_8));
	}

IL_0040:
	{
		uint32_t L_9 = sizeof(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D);
		V_1 = (int32_t)L_9;
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_10 = __this->___Ptr;
		int32_t L_11 = V_0;
		int32_t L_12 = V_1;
		V_2 = (void*)((OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)il2cpp_codegen_add((intptr_t)L_10, ((int32_t)il2cpp_codegen_multiply(L_11, L_12))));
		void* L_13 = V_2;
		void* L_14 = ___0_ptr;
		int32_t L_15 = ___1_count;
		int32_t L_16 = V_1;
		UnsafeUtility_MemCpy_m5CEA91ACDADC522E584AE3A2AB2B0B74393A9177(L_13, L_14, ((int64_t)((int32_t)il2cpp_codegen_multiply(L_15, L_16))), NULL);
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_AddRange_m97C70050DCA30C2909EE9DA07B283929020C8D11_AdjustorThunk (RuntimeObject* __this, void* ___0_ptr, int32_t ___1_count, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	UnsafeList_1_AddRange_m97C70050DCA30C2909EE9DA07B283929020C8D11(_thisAdjusted, ___0_ptr, ___1_count, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_AddReplicate_m924A083227B0EDD370314CD100023B4432F88B94_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* ___0_value, int32_t ___1_count, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	bool V_1 = false;
	void* V_2 = NULL;
	OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* V_3 = NULL;
	{
		int32_t L_0 = __this->___m_length;
		V_0 = L_0;
		int32_t L_1 = __this->___m_length;
		int32_t L_2 = ___1_count;
		int32_t L_3;
		L_3 = UnsafeList_1_get_Capacity_mE66A788D02ACCA321ADEC1D5939D6A0CC38E4A59_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_1 = (bool)((((int32_t)((int32_t)il2cpp_codegen_add(L_1, L_2))) > ((int32_t)L_3))? 1 : 0);
		bool L_4 = V_1;
		if (!L_4)
		{
			goto IL_0030;
		}
	}
	{
		int32_t L_5 = __this->___m_length;
		int32_t L_6 = ___1_count;
		UnsafeList_1_Resize_m89BDE747429473AE232DB084BC36EF48F3AB388D(__this, ((int32_t)il2cpp_codegen_add(L_5, L_6)), (int32_t)0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 3));
		goto IL_0040;
	}

IL_0030:
	{
		int32_t L_7 = __this->___m_length;
		int32_t L_8 = ___1_count;
		__this->___m_length = ((int32_t)il2cpp_codegen_add(L_7, L_8));
	}

IL_0040:
	{
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_9 = ___0_value;
		V_3 = L_9;
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_10 = V_3;
		V_2 = (void*)((uintptr_t)L_10);
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_11 = __this->___Ptr;
		int32_t L_12 = V_0;
		uint32_t L_13 = sizeof(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D);
		void* L_14 = V_2;
		int32_t L_15;
		L_15 = UnsafeUtility_SizeOf_TisOccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D_m06F3769E28E215E9E08FE78C81E8E16F99336462_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 22));
		int32_t L_16 = ___1_count;
		UnsafeUtility_MemCpyReplicate_m0432429C10859D5BE79799A6E98B44741244287F((void*)((OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)il2cpp_codegen_add((intptr_t)L_11, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_12), (int32_t)L_13)))), L_14, L_15, L_16, NULL);
		V_3 = (OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)((uintptr_t)0);
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_AddReplicate_m924A083227B0EDD370314CD100023B4432F88B94_AdjustorThunk (RuntimeObject* __this, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* ___0_value, int32_t ___1_count, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	UnsafeList_1_AddReplicate_m924A083227B0EDD370314CD100023B4432F88B94(_thisAdjusted, ___0_value, ___1_count, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_InsertRangeWithBeginEnd_mBDCC51B7FA7F5EFACE0959F2459FE88366220CA6_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_begin, int32_t ___1_end, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	bool V_5 = false;
	bool V_6 = false;
	bool V_7 = false;
	uint8_t* V_8 = NULL;
	uint8_t* V_9 = NULL;
	uint8_t* V_10 = NULL;
	{
		int32_t L_0 = ___0_begin;
		int32_t L_1;
		L_1 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_0, NULL);
		___0_begin = L_1;
		int32_t L_2 = ___1_end;
		int32_t L_3;
		L_3 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_2, NULL);
		___1_end = L_3;
		int32_t L_4 = ___1_end;
		int32_t L_5 = ___0_begin;
		V_0 = ((int32_t)il2cpp_codegen_subtract(L_4, L_5));
		int32_t L_6 = V_0;
		V_5 = (bool)((((int32_t)L_6) < ((int32_t)1))? 1 : 0);
		bool L_7 = V_5;
		if (!L_7)
		{
			goto IL_0025;
		}
	}
	{
		goto IL_00aa;
	}

IL_0025:
	{
		int32_t L_8 = __this->___m_length;
		V_1 = L_8;
		int32_t L_9 = __this->___m_length;
		int32_t L_10 = V_0;
		int32_t L_11;
		L_11 = UnsafeList_1_get_Capacity_mE66A788D02ACCA321ADEC1D5939D6A0CC38E4A59_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_6 = (bool)((((int32_t)((int32_t)il2cpp_codegen_add(L_9, L_10))) > ((int32_t)L_11))? 1 : 0);
		bool L_12 = V_6;
		if (!L_12)
		{
			goto IL_0056;
		}
	}
	{
		int32_t L_13 = __this->___m_length;
		int32_t L_14 = V_0;
		UnsafeList_1_Resize_m89BDE747429473AE232DB084BC36EF48F3AB388D(__this, ((int32_t)il2cpp_codegen_add(L_13, L_14)), (int32_t)0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 3));
		goto IL_0066;
	}

IL_0056:
	{
		int32_t L_15 = __this->___m_length;
		int32_t L_16 = V_0;
		__this->___m_length = ((int32_t)il2cpp_codegen_add(L_15, L_16));
	}

IL_0066:
	{
		int32_t L_17 = V_1;
		int32_t L_18 = ___0_begin;
		V_2 = ((int32_t)il2cpp_codegen_subtract(L_17, L_18));
		int32_t L_19 = V_2;
		V_7 = (bool)((((int32_t)L_19) < ((int32_t)1))? 1 : 0);
		bool L_20 = V_7;
		if (!L_20)
		{
			goto IL_0077;
		}
	}
	{
		goto IL_00aa;
	}

IL_0077:
	{
		uint32_t L_21 = sizeof(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D);
		V_3 = (int32_t)L_21;
		int32_t L_22 = V_2;
		int32_t L_23 = V_3;
		V_4 = ((int32_t)il2cpp_codegen_multiply(L_22, L_23));
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_24 = __this->___Ptr;
		V_8 = (uint8_t*)L_24;
		uint8_t* L_25 = V_8;
		int32_t L_26 = ___1_end;
		int32_t L_27 = V_3;
		V_9 = ((uint8_t*)il2cpp_codegen_add((intptr_t)L_25, ((int32_t)il2cpp_codegen_multiply(L_26, L_27))));
		uint8_t* L_28 = V_8;
		int32_t L_29 = ___0_begin;
		int32_t L_30 = V_3;
		V_10 = ((uint8_t*)il2cpp_codegen_add((intptr_t)L_28, ((int32_t)il2cpp_codegen_multiply(L_29, L_30))));
		uint8_t* L_31 = V_9;
		uint8_t* L_32 = V_10;
		int32_t L_33 = V_4;
		UnsafeUtility_MemMove_m4799FAA9C4BCFA1AEDC6ED01BB9A6DF657C4CEE3((void*)L_31, (void*)L_32, ((int64_t)L_33), NULL);
	}

IL_00aa:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_InsertRangeWithBeginEnd_mBDCC51B7FA7F5EFACE0959F2459FE88366220CA6_AdjustorThunk (RuntimeObject* __this, int32_t ___0_begin, int32_t ___1_end, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	UnsafeList_1_InsertRangeWithBeginEnd_mBDCC51B7FA7F5EFACE0959F2459FE88366220CA6(_thisAdjusted, ___0_begin, ___1_end, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_RemoveAtSwapBack_m5846A3BBEB108590536A902E1263230006034835_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_index, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* V_1 = NULL;
	OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* V_2 = NULL;
	{
		int32_t L_0 = ___0_index;
		int32_t L_1;
		L_1 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_0, NULL);
		___0_index = L_1;
		int32_t L_2 = __this->___m_length;
		V_0 = ((int32_t)il2cpp_codegen_subtract(L_2, 1));
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_3 = __this->___Ptr;
		int32_t L_4 = ___0_index;
		uint32_t L_5 = sizeof(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D);
		V_1 = ((OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)il2cpp_codegen_add((intptr_t)L_3, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_4), (int32_t)L_5))));
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_6 = __this->___Ptr;
		int32_t L_7 = V_0;
		uint32_t L_8 = sizeof(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D);
		V_2 = ((OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)il2cpp_codegen_add((intptr_t)L_6, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_7), (int32_t)L_8))));
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_9 = V_1;
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_10 = V_2;
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D L_11 = (*(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)L_10);
		*(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)L_9 = L_11;
		int32_t L_12 = __this->___m_length;
		__this->___m_length = ((int32_t)il2cpp_codegen_subtract(L_12, 1));
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_RemoveAtSwapBack_m5846A3BBEB108590536A902E1263230006034835_AdjustorThunk (RuntimeObject* __this, int32_t ___0_index, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	UnsafeList_1_RemoveAtSwapBack_m5846A3BBEB108590536A902E1263230006034835(_thisAdjusted, ___0_index, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_RemoveRangeSwapBack_mD9731A61259B247E3209E90E4F68CD7F5446C91A_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_index, int32_t ___1_count, const RuntimeMethod* method) 
{
	bool V_0 = false;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	void* V_3 = NULL;
	void* V_4 = NULL;
	{
		int32_t L_0 = ___0_index;
		int32_t L_1;
		L_1 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_0, NULL);
		___0_index = L_1;
		int32_t L_2 = ___1_count;
		int32_t L_3;
		L_3 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_2, NULL);
		___1_count = L_3;
		int32_t L_4 = ___1_count;
		V_0 = (bool)((((int32_t)L_4) > ((int32_t)0))? 1 : 0);
		bool L_5 = V_0;
		if (!L_5)
		{
			goto IL_006c;
		}
	}
	{
		int32_t L_6 = __this->___m_length;
		int32_t L_7 = ___1_count;
		int32_t L_8 = ___0_index;
		int32_t L_9 = ___1_count;
		int32_t L_10;
		L_10 = math_max_m9083201D37A8ED0157B127B5878D9B7F3A2A40BE_inline(((int32_t)il2cpp_codegen_subtract(L_6, L_7)), ((int32_t)il2cpp_codegen_add(L_8, L_9)), NULL);
		V_1 = L_10;
		uint32_t L_11 = sizeof(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D);
		V_2 = (int32_t)L_11;
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_12 = __this->___Ptr;
		int32_t L_13 = ___0_index;
		int32_t L_14 = V_2;
		V_3 = (void*)((OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)il2cpp_codegen_add((intptr_t)L_12, ((int32_t)il2cpp_codegen_multiply(L_13, L_14))));
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_15 = __this->___Ptr;
		int32_t L_16 = V_1;
		int32_t L_17 = V_2;
		V_4 = (void*)((OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)il2cpp_codegen_add((intptr_t)L_15, ((int32_t)il2cpp_codegen_multiply(L_16, L_17))));
		void* L_18 = V_3;
		void* L_19 = V_4;
		int32_t L_20 = __this->___m_length;
		int32_t L_21 = V_1;
		int32_t L_22 = V_2;
		UnsafeUtility_MemCpy_m5CEA91ACDADC522E584AE3A2AB2B0B74393A9177(L_18, L_19, ((int64_t)((int32_t)il2cpp_codegen_multiply(((int32_t)il2cpp_codegen_subtract(L_20, L_21)), L_22))), NULL);
		int32_t L_23 = __this->___m_length;
		int32_t L_24 = ___1_count;
		__this->___m_length = ((int32_t)il2cpp_codegen_subtract(L_23, L_24));
	}

IL_006c:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_RemoveRangeSwapBack_mD9731A61259B247E3209E90E4F68CD7F5446C91A_AdjustorThunk (RuntimeObject* __this, int32_t ___0_index, int32_t ___1_count, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	UnsafeList_1_RemoveRangeSwapBack_mD9731A61259B247E3209E90E4F68CD7F5446C91A(_thisAdjusted, ___0_index, ___1_count, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_RemoveAt_mA48E14773A1A1F3D33BFC4F6D907E9CE2F3F5572_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_index, const RuntimeMethod* method) 
{
	OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* V_0 = NULL;
	OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* V_1 = NULL;
	int32_t V_2 = 0;
	OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* V_3 = NULL;
	bool V_4 = false;
	{
		int32_t L_0 = ___0_index;
		int32_t L_1;
		L_1 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_0, NULL);
		___0_index = L_1;
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_2 = __this->___Ptr;
		int32_t L_3 = ___0_index;
		uint32_t L_4 = sizeof(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D);
		V_0 = ((OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)il2cpp_codegen_add((intptr_t)L_2, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_3), (int32_t)L_4))));
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_5 = V_0;
		uint32_t L_6 = sizeof(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D);
		V_1 = ((OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)il2cpp_codegen_add((intptr_t)L_5, (int32_t)L_6));
		int32_t L_7 = __this->___m_length;
		__this->___m_length = ((int32_t)il2cpp_codegen_subtract(L_7, 1));
		int32_t L_8 = ___0_index;
		V_2 = L_8;
		goto IL_005d;
	}

IL_0035:
	{
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_9 = V_0;
		V_3 = L_9;
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_10 = V_3;
		uint32_t L_11 = sizeof(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D);
		V_0 = ((OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)il2cpp_codegen_add((intptr_t)L_10, (int32_t)L_11));
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_12 = V_3;
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_13 = V_1;
		V_3 = L_13;
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_14 = V_3;
		uint32_t L_15 = sizeof(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D);
		V_1 = ((OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)il2cpp_codegen_add((intptr_t)L_14, (int32_t)L_15));
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_16 = V_3;
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D L_17 = (*(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)L_16);
		*(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)L_12 = L_17;
		int32_t L_18 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_18, 1));
	}

IL_005d:
	{
		int32_t L_19 = V_2;
		int32_t L_20 = __this->___m_length;
		V_4 = (bool)((((int32_t)L_19) < ((int32_t)L_20))? 1 : 0);
		bool L_21 = V_4;
		if (L_21)
		{
			goto IL_0035;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_RemoveAt_mA48E14773A1A1F3D33BFC4F6D907E9CE2F3F5572_AdjustorThunk (RuntimeObject* __this, int32_t ___0_index, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	UnsafeList_1_RemoveAt_mA48E14773A1A1F3D33BFC4F6D907E9CE2F3F5572(_thisAdjusted, ___0_index, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_RemoveRange_mBDC19D7AC8AAECCEDB16C1F074E25D44CF7BCF48_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_index, int32_t ___1_count, const RuntimeMethod* method) 
{
	bool V_0 = false;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	void* V_3 = NULL;
	void* V_4 = NULL;
	{
		int32_t L_0 = ___0_index;
		int32_t L_1;
		L_1 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_0, NULL);
		___0_index = L_1;
		int32_t L_2 = ___1_count;
		int32_t L_3;
		L_3 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_2, NULL);
		___1_count = L_3;
		int32_t L_4 = ___1_count;
		V_0 = (bool)((((int32_t)L_4) > ((int32_t)0))? 1 : 0);
		bool L_5 = V_0;
		if (!L_5)
		{
			goto IL_006a;
		}
	}
	{
		int32_t L_6 = ___0_index;
		int32_t L_7 = ___1_count;
		int32_t L_8 = __this->___m_length;
		int32_t L_9;
		L_9 = math_min_m02D43DF516544C279AF660EA4731449C82991849_inline(((int32_t)il2cpp_codegen_add(L_6, L_7)), L_8, NULL);
		V_1 = L_9;
		uint32_t L_10 = sizeof(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D);
		V_2 = (int32_t)L_10;
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_11 = __this->___Ptr;
		int32_t L_12 = ___0_index;
		int32_t L_13 = V_2;
		V_3 = (void*)((OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)il2cpp_codegen_add((intptr_t)L_11, ((int32_t)il2cpp_codegen_multiply(L_12, L_13))));
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_14 = __this->___Ptr;
		int32_t L_15 = V_1;
		int32_t L_16 = V_2;
		V_4 = (void*)((OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)il2cpp_codegen_add((intptr_t)L_14, ((int32_t)il2cpp_codegen_multiply(L_15, L_16))));
		void* L_17 = V_3;
		void* L_18 = V_4;
		int32_t L_19 = __this->___m_length;
		int32_t L_20 = V_1;
		int32_t L_21 = V_2;
		UnsafeUtility_MemCpy_m5CEA91ACDADC522E584AE3A2AB2B0B74393A9177(L_17, L_18, ((int64_t)((int32_t)il2cpp_codegen_multiply(((int32_t)il2cpp_codegen_subtract(L_19, L_20)), L_21))), NULL);
		int32_t L_22 = __this->___m_length;
		int32_t L_23 = ___1_count;
		__this->___m_length = ((int32_t)il2cpp_codegen_subtract(L_22, L_23));
	}

IL_006a:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_RemoveRange_mBDC19D7AC8AAECCEDB16C1F074E25D44CF7BCF48_AdjustorThunk (RuntimeObject* __this, int32_t ___0_index, int32_t ___1_count, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	UnsafeList_1_RemoveRange_mBDC19D7AC8AAECCEDB16C1F074E25D44CF7BCF48(_thisAdjusted, ___0_index, ___1_count, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_CopyFrom_mAEFF28DF5C4A27B95A43F4D0425359B898657114_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, NativeArray_1_t0C50A3E7F549E148C8748605A2BC3D9BB1BC80DF* ___0_other, const RuntimeMethod* method) 
{
	NativeArray_1_t0C50A3E7F549E148C8748605A2BC3D9BB1BC80DF V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		NativeArray_1_t0C50A3E7F549E148C8748605A2BC3D9BB1BC80DF* L_0 = ___0_other;
		NativeArray_1_t0C50A3E7F549E148C8748605A2BC3D9BB1BC80DF L_1 = (*(NativeArray_1_t0C50A3E7F549E148C8748605A2BC3D9BB1BC80DF*)L_0);
		V_0 = L_1;
		int32_t L_2;
		L_2 = IL2CPP_NATIVEARRAY_GET_LENGTH(((&V_0))->___m_Length);
		UnsafeList_1_Resize_m89BDE747429473AE232DB084BC36EF48F3AB388D(__this, L_2, (int32_t)0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 3));
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_3 = __this->___Ptr;
		NativeArray_1_t0C50A3E7F549E148C8748605A2BC3D9BB1BC80DF* L_4 = ___0_other;
		NativeArray_1_t0C50A3E7F549E148C8748605A2BC3D9BB1BC80DF L_5 = (*(NativeArray_1_t0C50A3E7F549E148C8748605A2BC3D9BB1BC80DF*)L_4);
		void* L_6;
		L_6 = NativeArrayUnsafeUtility_GetUnsafeReadOnlyPtr_TisOccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D_m20BD626E48A9A87C9D0D502474419CE8FF67F7FF(L_5, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 28));
		int32_t L_7;
		L_7 = UnsafeUtility_SizeOf_TisOccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D_m06F3769E28E215E9E08FE78C81E8E16F99336462_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 22));
		NativeArray_1_t0C50A3E7F549E148C8748605A2BC3D9BB1BC80DF* L_8 = ___0_other;
		NativeArray_1_t0C50A3E7F549E148C8748605A2BC3D9BB1BC80DF L_9 = (*(NativeArray_1_t0C50A3E7F549E148C8748605A2BC3D9BB1BC80DF*)L_8);
		V_0 = L_9;
		int32_t L_10;
		L_10 = IL2CPP_NATIVEARRAY_GET_LENGTH(((&V_0))->___m_Length);
		UnsafeUtility_MemCpy_m5CEA91ACDADC522E584AE3A2AB2B0B74393A9177((void*)L_3, L_6, ((int64_t)((int32_t)il2cpp_codegen_multiply(L_7, L_10))), NULL);
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_CopyFrom_mAEFF28DF5C4A27B95A43F4D0425359B898657114_AdjustorThunk (RuntimeObject* __this, NativeArray_1_t0C50A3E7F549E148C8748605A2BC3D9BB1BC80DF* ___0_other, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	UnsafeList_1_CopyFrom_mAEFF28DF5C4A27B95A43F4D0425359B898657114(_thisAdjusted, ___0_other, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_CopyFrom_m21D16EB2A77EF551D3EF9DB20BBEE2E38507E1B7_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* ___0_other, const RuntimeMethod* method) 
{
	{
		UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* L_0 = ___0_other;
		int32_t L_1;
		L_1 = UnsafeList_1_get_Length_m2673797C6B1B5ED6A4C644298C555559E56C2682_inline(L_0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 20));
		UnsafeList_1_Resize_m89BDE747429473AE232DB084BC36EF48F3AB388D(__this, L_1, (int32_t)0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 3));
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_2 = __this->___Ptr;
		UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* L_3 = ___0_other;
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_4 = L_3->___Ptr;
		int32_t L_5;
		L_5 = UnsafeUtility_SizeOf_TisOccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D_m06F3769E28E215E9E08FE78C81E8E16F99336462_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 22));
		UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* L_6 = ___0_other;
		int32_t L_7;
		L_7 = UnsafeList_1_get_Length_m2673797C6B1B5ED6A4C644298C555559E56C2682_inline(L_6, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 20));
		UnsafeUtility_MemCpy_m5CEA91ACDADC522E584AE3A2AB2B0B74393A9177((void*)L_2, (void*)L_4, ((int64_t)((int32_t)il2cpp_codegen_multiply(L_5, L_7))), NULL);
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_CopyFrom_m21D16EB2A77EF551D3EF9DB20BBEE2E38507E1B7_AdjustorThunk (RuntimeObject* __this, UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* ___0_other, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	UnsafeList_1_CopyFrom_m21D16EB2A77EF551D3EF9DB20BBEE2E38507E1B7(_thisAdjusted, ___0_other, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* UnsafeList_1_System_Collections_IEnumerable_GetEnumerator_mECC392B2D508A11712F173B4D1BEC8B9D5DDC9FE_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method) 
{
	{
		NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8* L_0 = (NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8_il2cpp_TypeInfo_var)));
		NotImplementedException__ctor_mDAB47BC6BD0E342E8F2171E5CABE3E67EA049F1C(L_0, NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_0, method);
	}
}
IL2CPP_EXTERN_C  RuntimeObject* UnsafeList_1_System_Collections_IEnumerable_GetEnumerator_mECC392B2D508A11712F173B4D1BEC8B9D5DDC9FE_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	RuntimeObject* _returnValue;
	_returnValue = UnsafeList_1_System_Collections_IEnumerable_GetEnumerator_mECC392B2D508A11712F173B4D1BEC8B9D5DDC9FE(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* UnsafeList_1_System_Collections_Generic_IEnumerableU3CTU3E_GetEnumerator_mF33B0D1056CA3743A4B22D07D84B959D46B0D027_gshared (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method) 
{
	{
		NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8* L_0 = (NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8_il2cpp_TypeInfo_var)));
		NotImplementedException__ctor_mDAB47BC6BD0E342E8F2171E5CABE3E67EA049F1C(L_0, NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_0, method);
	}
}
IL2CPP_EXTERN_C  RuntimeObject* UnsafeList_1_System_Collections_Generic_IEnumerableU3CTU3E_GetEnumerator_mF33B0D1056CA3743A4B22D07D84B959D46B0D027_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA*>(__this + _offset);
	RuntimeObject* _returnValue;
	_returnValue = UnsafeList_1_System_Collections_Generic_IEnumerableU3CTU3E_GetEnumerator_mF33B0D1056CA3743A4B22D07D84B959D46B0D027(_thisAdjusted, method);
	return _returnValue;
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeList_1_get_Length_m30C8B237736009EBD4E69E7D215B9650233D037C_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___m_length;
		int32_t L_1;
		L_1 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_0, NULL);
		return L_1;
	}
}
IL2CPP_EXTERN_C  int32_t UnsafeList_1_get_Length_m30C8B237736009EBD4E69E7D215B9650233D037C_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	int32_t _returnValue;
	_returnValue = UnsafeList_1_get_Length_m30C8B237736009EBD4E69E7D215B9650233D037C_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_set_Length_mB77496A4A78A181D3CBFC6AC25BE562DE37F318B_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_value, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		int32_t L_0 = ___0_value;
		int32_t L_1;
		L_1 = UnsafeList_1_get_Capacity_mD86B514B3119D3E1A021A6CB23BE78590F5E486E_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_0 = (bool)((((int32_t)L_0) > ((int32_t)L_1))? 1 : 0);
		bool L_2 = V_0;
		if (!L_2)
		{
			goto IL_001b;
		}
	}
	{
		int32_t L_3 = ___0_value;
		UnsafeList_1_Resize_mF872E9A04824A2B9B2B673782565D043892D31D9(__this, L_3, (int32_t)0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 3));
		goto IL_0024;
	}

IL_001b:
	{
		int32_t L_4 = ___0_value;
		__this->___m_length = L_4;
	}

IL_0024:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_set_Length_mB77496A4A78A181D3CBFC6AC25BE562DE37F318B_AdjustorThunk (RuntimeObject* __this, int32_t ___0_value, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	UnsafeList_1_set_Length_mB77496A4A78A181D3CBFC6AC25BE562DE37F318B(_thisAdjusted, ___0_value, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeList_1_get_Capacity_mD86B514B3119D3E1A021A6CB23BE78590F5E486E_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___m_capacity;
		int32_t L_1;
		L_1 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_0, NULL);
		return L_1;
	}
}
IL2CPP_EXTERN_C  int32_t UnsafeList_1_get_Capacity_mD86B514B3119D3E1A021A6CB23BE78590F5E486E_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	int32_t _returnValue;
	_returnValue = UnsafeList_1_get_Capacity_mD86B514B3119D3E1A021A6CB23BE78590F5E486E_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_set_Capacity_mB8A4248D3F6458D1D9E98A7BEC320E14BD41D3B7_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_value, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___0_value;
		UnsafeList_1_SetCapacity_mAD7D5D59FEB13EAF12B15B9FC0BBDEA7546A4563(__this, L_0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 4));
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_set_Capacity_mB8A4248D3F6458D1D9E98A7BEC320E14BD41D3B7_AdjustorThunk (RuntimeObject* __this, int32_t ___0_value, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	UnsafeList_1_set_Capacity_mB8A4248D3F6458D1D9E98A7BEC320E14BD41D3B7(_thisAdjusted, ___0_value, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A UnsafeList_1_get_Item_m5047BC7B1C0732A194FACD8C079EC28A64A5F79D_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_index, const RuntimeMethod* method) 
{
	SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_0 = __this->___Ptr;
		int32_t L_1 = ___0_index;
		int32_t L_2;
		L_2 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_1, NULL);
		uint32_t L_3 = sizeof(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A);
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A L_4 = (*(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)((SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_2), (int32_t)L_3)))));
		V_0 = L_4;
		goto IL_001e;
	}

IL_001e:
	{
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A L_5 = V_0;
		return L_5;
	}
}
IL2CPP_EXTERN_C  SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A UnsafeList_1_get_Item_m5047BC7B1C0732A194FACD8C079EC28A64A5F79D_AdjustorThunk (RuntimeObject* __this, int32_t ___0_index, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A _returnValue;
	_returnValue = UnsafeList_1_get_Item_m5047BC7B1C0732A194FACD8C079EC28A64A5F79D_inline(_thisAdjusted, ___0_index, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_set_Item_m2D938DC73BF3B2D244FB9468EBECDFA52B986B7B_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_index, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A ___1_value, const RuntimeMethod* method) 
{
	{
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_0 = __this->___Ptr;
		int32_t L_1 = ___0_index;
		int32_t L_2;
		L_2 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_1, NULL);
		uint32_t L_3 = sizeof(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A);
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A L_4 = ___1_value;
		*(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)((SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_2), (int32_t)L_3)))) = L_4;
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_set_Item_m2D938DC73BF3B2D244FB9468EBECDFA52B986B7B_AdjustorThunk (RuntimeObject* __this, int32_t ___0_index, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A ___1_value, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	UnsafeList_1_set_Item_m2D938DC73BF3B2D244FB9468EBECDFA52B986B7B_inline(_thisAdjusted, ___0_index, ___1_value, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* UnsafeList_1_ElementAt_m9B7ADAC368CB917E0318285D89CD070BFFC7E2F9_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_index, const RuntimeMethod* method) 
{
	SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* V_0 = NULL;
	{
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_0 = __this->___Ptr;
		int32_t L_1 = ___0_index;
		int32_t L_2;
		L_2 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_1, NULL);
		uint32_t L_3 = sizeof(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A);
		V_0 = (SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)((SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_2), (int32_t)L_3))));
		goto IL_0019;
	}

IL_0019:
	{
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_4 = V_0;
		return L_4;
	}
}
IL2CPP_EXTERN_C  SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* UnsafeList_1_ElementAt_m9B7ADAC368CB917E0318285D89CD070BFFC7E2F9_AdjustorThunk (RuntimeObject* __this, int32_t ___0_index, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* _returnValue;
	_returnValue = UnsafeList_1_ElementAt_m9B7ADAC368CB917E0318285D89CD070BFFC7E2F9_inline(_thisAdjusted, ___0_index, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1__ctor_mA5748C7F18591A66AAEA5CEDACA2A12FC57EFAD3_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_initialCapacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___1_allocator, int32_t ___2_options, const RuntimeMethod* method) 
{
	bool V_0 = false;
	int32_t V_1 = 0;
	int32_t G_B3_0 = 0;
	{
		__this->___Ptr = (SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)((uintptr_t)0);
		__this->___m_length = 0;
		__this->___m_capacity = 0;
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_0 = ___1_allocator;
		__this->___Allocator = L_0;
		__this->___padding = 0;
		int32_t L_1 = ___0_initialCapacity;
		int32_t L_2;
		L_2 = math_max_m9083201D37A8ED0157B127B5878D9B7F3A2A40BE_inline(L_1, 1, NULL);
		UnsafeList_1_SetCapacity_mAD7D5D59FEB13EAF12B15B9FC0BBDEA7546A4563(__this, L_2, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 4));
		int32_t L_3 = ___2_options;
		if ((!(((uint32_t)L_3) == ((uint32_t)1))))
		{
			goto IL_0046;
		}
	}
	{
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_4 = __this->___Ptr;
		G_B3_0 = ((((int32_t)((((intptr_t)L_4) == ((intptr_t)((uintptr_t)0)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0047;
	}

IL_0046:
	{
		G_B3_0 = 0;
	}

IL_0047:
	{
		V_0 = (bool)G_B3_0;
		bool L_5 = V_0;
		if (!L_5)
		{
			goto IL_0069;
		}
	}
	{
		uint32_t L_6 = sizeof(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A);
		V_1 = (int32_t)L_6;
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_7 = __this->___Ptr;
		int32_t L_8;
		L_8 = UnsafeList_1_get_Capacity_mD86B514B3119D3E1A021A6CB23BE78590F5E486E_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_9 = V_1;
		UnsafeUtility_MemClear_m6C4377117084A11A667A567BC2F5E606A632A7C1((void*)L_7, ((int64_t)((int32_t)il2cpp_codegen_multiply(L_8, L_9))), NULL);
	}

IL_0069:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1__ctor_mA5748C7F18591A66AAEA5CEDACA2A12FC57EFAD3_AdjustorThunk (RuntimeObject* __this, int32_t ___0_initialCapacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___1_allocator, int32_t ___2_options, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	UnsafeList_1__ctor_mA5748C7F18591A66AAEA5CEDACA2A12FC57EFAD3(_thisAdjusted, ___0_initialCapacity, ___1_allocator, ___2_options, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_Destroy_mE014B2EFDDE56370811B8402F7EE7160225041BD_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* ___0_listData, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AllocatorManager_tFB15A22029C8159A3DCD4C08935BE57D3E6B3C2C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* L_0 = ___0_listData;
		NullCheck(L_0);
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_1 = L_0->___Allocator;
		V_0 = L_1;
		UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* L_2 = ___0_listData;
		UnsafeList_1_Dispose_m007CA9BE61EF7FB5A88A2E9AFEBD3611A4DEF29C((UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*)L_2, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 11));
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_3 = V_0;
		UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* L_4 = ___0_listData;
		il2cpp_codegen_runtime_class_init_inline(AllocatorManager_tFB15A22029C8159A3DCD4C08935BE57D3E6B3C2C_il2cpp_TypeInfo_var);
		AllocatorManager_Free_TisUnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C_m1BCBC66CBB14BBD523F4C3A7F94F5170FC8CE363(L_3, L_4, 1, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeList_1_get_IsEmpty_mFB3CDB4407674F5F2A7D1859C9FB368CC9077F1A_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method) 
{
	int32_t G_B3_0 = 0;
	{
		bool L_0;
		L_0 = UnsafeList_1_get_IsCreated_mB1B61C071EA40B095E886B5298E0C3C54ED9A853_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		if (!L_0)
		{
			goto IL_0013;
		}
	}
	{
		int32_t L_1 = __this->___m_length;
		G_B3_0 = ((((int32_t)L_1) == ((int32_t)0))? 1 : 0);
		goto IL_0014;
	}

IL_0013:
	{
		G_B3_0 = 1;
	}

IL_0014:
	{
		return (bool)G_B3_0;
	}
}
IL2CPP_EXTERN_C  bool UnsafeList_1_get_IsEmpty_mFB3CDB4407674F5F2A7D1859C9FB368CC9077F1A_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	bool _returnValue;
	_returnValue = UnsafeList_1_get_IsEmpty_mFB3CDB4407674F5F2A7D1859C9FB368CC9077F1A_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeList_1_get_IsCreated_mB1B61C071EA40B095E886B5298E0C3C54ED9A853_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method) 
{
	{
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_0 = __this->___Ptr;
		return (bool)((((int32_t)((((intptr_t)L_0) == ((intptr_t)((uintptr_t)0)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
	}
}
IL2CPP_EXTERN_C  bool UnsafeList_1_get_IsCreated_mB1B61C071EA40B095E886B5298E0C3C54ED9A853_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	bool _returnValue;
	_returnValue = UnsafeList_1_get_IsCreated_mB1B61C071EA40B095E886B5298E0C3C54ED9A853_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_Dispose_m007CA9BE61EF7FB5A88A2E9AFEBD3611A4DEF29C_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AllocatorManager_tFB15A22029C8159A3DCD4C08935BE57D3E6B3C2C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	bool V_1 = false;
	{
		bool L_0;
		L_0 = UnsafeList_1_get_IsCreated_mB1B61C071EA40B095E886B5298E0C3C54ED9A853_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		V_0 = (bool)((((int32_t)L_0) == ((int32_t)0))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0011;
		}
	}
	{
		goto IL_005b;
	}

IL_0011:
	{
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_2 = __this->___Allocator;
		bool L_3;
		L_3 = CollectionHelper_ShouldDeallocate_m505E7EDBA71F02BAF52CC9DCD7C593CDA85D5465(L_2, NULL);
		V_1 = L_3;
		bool L_4 = V_1;
		if (!L_4)
		{
			goto IL_0045;
		}
	}
	{
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_5 = __this->___Allocator;
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_6 = __this->___Ptr;
		int32_t L_7 = __this->___m_capacity;
		il2cpp_codegen_runtime_class_init_inline(AllocatorManager_tFB15A22029C8159A3DCD4C08935BE57D3E6B3C2C_il2cpp_TypeInfo_var);
		AllocatorManager_Free_TisSplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A_m74C86DFA3B9611772049B4B5336DC3B36C731649(L_5, L_6, L_7, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 14));
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_8 = ((AllocatorManager_tFB15A22029C8159A3DCD4C08935BE57D3E6B3C2C_StaticFields*)il2cpp_codegen_static_fields_for(AllocatorManager_tFB15A22029C8159A3DCD4C08935BE57D3E6B3C2C_il2cpp_TypeInfo_var))->___Invalid;
		__this->___Allocator = L_8;
	}

IL_0045:
	{
		__this->___Ptr = (SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)((uintptr_t)0);
		__this->___m_length = 0;
		__this->___m_capacity = 0;
	}

IL_005b:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_Dispose_m007CA9BE61EF7FB5A88A2E9AFEBD3611A4DEF29C_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	UnsafeList_1_Dispose_m007CA9BE61EF7FB5A88A2E9AFEBD3611A4DEF29C(_thisAdjusted, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_Clear_mFE93F82A6E8896D8E46E491623D85BE9BC2AE2C3_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method) 
{
	{
		__this->___m_length = 0;
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_Clear_mFE93F82A6E8896D8E46E491623D85BE9BC2AE2C3_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	UnsafeList_1_Clear_mFE93F82A6E8896D8E46E491623D85BE9BC2AE2C3(_thisAdjusted, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_Resize_mF872E9A04824A2B9B2B673782565D043892D31D9_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_length, int32_t ___1_options, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	bool V_1 = false;
	bool V_2 = false;
	int32_t V_3 = 0;
	uint8_t* V_4 = NULL;
	int32_t V_5 = 0;
	int32_t G_B5_0 = 0;
	{
		int32_t L_0 = __this->___m_length;
		V_0 = L_0;
		int32_t L_1 = ___0_length;
		int32_t L_2;
		L_2 = UnsafeList_1_get_Capacity_mD86B514B3119D3E1A021A6CB23BE78590F5E486E_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_1 = (bool)((((int32_t)L_1) > ((int32_t)L_2))? 1 : 0);
		bool L_3 = V_1;
		if (!L_3)
		{
			goto IL_001f;
		}
	}
	{
		int32_t L_4 = ___0_length;
		UnsafeList_1_SetCapacity_mAD7D5D59FEB13EAF12B15B9FC0BBDEA7546A4563(__this, L_4, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 4));
	}

IL_001f:
	{
		int32_t L_5 = ___0_length;
		__this->___m_length = L_5;
		int32_t L_6 = ___1_options;
		if ((!(((uint32_t)L_6) == ((uint32_t)1))))
		{
			goto IL_0030;
		}
	}
	{
		int32_t L_7 = V_0;
		int32_t L_8 = ___0_length;
		G_B5_0 = ((((int32_t)L_7) < ((int32_t)L_8))? 1 : 0);
		goto IL_0031;
	}

IL_0030:
	{
		G_B5_0 = 0;
	}

IL_0031:
	{
		V_2 = (bool)G_B5_0;
		bool L_9 = V_2;
		if (!L_9)
		{
			goto IL_005d;
		}
	}
	{
		int32_t L_10 = ___0_length;
		int32_t L_11 = V_0;
		V_3 = ((int32_t)il2cpp_codegen_subtract(L_10, L_11));
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_12 = __this->___Ptr;
		V_4 = (uint8_t*)L_12;
		uint32_t L_13 = sizeof(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A);
		V_5 = (int32_t)L_13;
		uint8_t* L_14 = V_4;
		int32_t L_15 = V_0;
		int32_t L_16 = V_5;
		int32_t L_17 = V_3;
		int32_t L_18 = V_5;
		UnsafeUtility_MemClear_m6C4377117084A11A667A567BC2F5E606A632A7C1((void*)((uint8_t*)il2cpp_codegen_add((intptr_t)L_14, ((int32_t)il2cpp_codegen_multiply(L_15, L_16)))), ((int64_t)((int32_t)il2cpp_codegen_multiply(L_17, L_18))), NULL);
	}

IL_005d:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_Resize_mF872E9A04824A2B9B2B673782565D043892D31D9_AdjustorThunk (RuntimeObject* __this, int32_t ___0_length, int32_t ___1_options, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	UnsafeList_1_Resize_mF872E9A04824A2B9B2B673782565D043892D31D9(_thisAdjusted, ___0_length, ___1_options, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_ResizeExact_m7128F30F2118629FF89940C16F4046F9515FEF6B_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_capacity, const RuntimeMethod* method) 
{
	{
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148* L_0 = (AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148*)(&__this->___Allocator);
		int32_t L_1 = ___0_capacity;
		UnsafeList_1_ResizeExact_TisAllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148_mE85365421923BB85B9248CAA9CEB34945B35C737(__this, L_0, L_1, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 16));
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_ResizeExact_m7128F30F2118629FF89940C16F4046F9515FEF6B_AdjustorThunk (RuntimeObject* __this, int32_t ___0_capacity, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	UnsafeList_1_ResizeExact_m7128F30F2118629FF89940C16F4046F9515FEF6B(_thisAdjusted, ___0_capacity, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_SetCapacity_mAD7D5D59FEB13EAF12B15B9FC0BBDEA7546A4563_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_capacity, const RuntimeMethod* method) 
{
	{
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148* L_0 = (AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148*)(&__this->___Allocator);
		int32_t L_1 = ___0_capacity;
		UnsafeList_1_SetCapacity_TisAllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148_m410651EE83B2047EEB067E0586569B723265B37B(__this, L_0, L_1, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 17));
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_SetCapacity_mAD7D5D59FEB13EAF12B15B9FC0BBDEA7546A4563_AdjustorThunk (RuntimeObject* __this, int32_t ___0_capacity, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	UnsafeList_1_SetCapacity_mAD7D5D59FEB13EAF12B15B9FC0BBDEA7546A4563(_thisAdjusted, ___0_capacity, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_TrimExcess_m974AE258DEBD1BCDCD20A7E4630CE26296EDF43D_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		int32_t L_0;
		L_0 = UnsafeList_1_get_Capacity_mD86B514B3119D3E1A021A6CB23BE78590F5E486E_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_1 = __this->___m_length;
		V_0 = (bool)((((int32_t)((((int32_t)L_0) == ((int32_t)L_1))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_2 = V_0;
		if (!L_2)
		{
			goto IL_0025;
		}
	}
	{
		int32_t L_3 = __this->___m_length;
		UnsafeList_1_ResizeExact_m7128F30F2118629FF89940C16F4046F9515FEF6B(__this, L_3, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 18));
	}

IL_0025:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_TrimExcess_m974AE258DEBD1BCDCD20A7E4630CE26296EDF43D_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	UnsafeList_1_TrimExcess_m974AE258DEBD1BCDCD20A7E4630CE26296EDF43D(_thisAdjusted, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_AddNoResize_mDD1844EF5F4B0A230D4C6141E4A6A3EF83521A5C_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A ___0_value, const RuntimeMethod* method) 
{
	{
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_0 = __this->___Ptr;
		int32_t L_1 = __this->___m_length;
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A L_2 = ___0_value;
		UnsafeUtility_WriteArrayElement_TisSplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A_m4F71D70C126C24C918F9E6237DC37C71726A6CE8_inline((void*)L_0, L_1, L_2, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 19));
		int32_t L_3 = __this->___m_length;
		__this->___m_length = ((int32_t)il2cpp_codegen_add(L_3, 1));
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_AddNoResize_mDD1844EF5F4B0A230D4C6141E4A6A3EF83521A5C_AdjustorThunk (RuntimeObject* __this, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A ___0_value, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	UnsafeList_1_AddNoResize_mDD1844EF5F4B0A230D4C6141E4A6A3EF83521A5C_inline(_thisAdjusted, ___0_value, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_AddRangeNoResize_m6C41571D7107A9C270662661CCEEF34BDD32682F_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, void* ___0_ptr, int32_t ___1_count, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	void* V_1 = NULL;
	{
		uint32_t L_0 = sizeof(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A);
		V_0 = (int32_t)L_0;
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_1 = __this->___Ptr;
		int32_t L_2 = __this->___m_length;
		int32_t L_3 = V_0;
		V_1 = (void*)((SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)il2cpp_codegen_add((intptr_t)L_1, ((int32_t)il2cpp_codegen_multiply(L_2, L_3))));
		void* L_4 = V_1;
		void* L_5 = ___0_ptr;
		int32_t L_6 = ___1_count;
		int32_t L_7 = V_0;
		UnsafeUtility_MemCpy_m5CEA91ACDADC522E584AE3A2AB2B0B74393A9177(L_4, L_5, ((int64_t)((int32_t)il2cpp_codegen_multiply(L_6, L_7))), NULL);
		int32_t L_8 = __this->___m_length;
		int32_t L_9 = ___1_count;
		__this->___m_length = ((int32_t)il2cpp_codegen_add(L_8, L_9));
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_AddRangeNoResize_m6C41571D7107A9C270662661CCEEF34BDD32682F_AdjustorThunk (RuntimeObject* __this, void* ___0_ptr, int32_t ___1_count, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	UnsafeList_1_AddRangeNoResize_m6C41571D7107A9C270662661CCEEF34BDD32682F(_thisAdjusted, ___0_ptr, ___1_count, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_AddRangeNoResize_mD850AF553A2F8263EDE3E1F7A1A886A2C7EAFCD4_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C ___0_list, const RuntimeMethod* method) 
{
	{
		UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C L_0 = ___0_list;
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_1 = L_0.___Ptr;
		int32_t L_2;
		L_2 = UnsafeList_1_get_Length_m30C8B237736009EBD4E69E7D215B9650233D037C_inline((&___0_list), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 20));
		int32_t L_3;
		L_3 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_2, NULL);
		UnsafeList_1_AddRangeNoResize_m6C41571D7107A9C270662661CCEEF34BDD32682F(__this, (void*)L_1, L_3, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 21));
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_AddRangeNoResize_mD850AF553A2F8263EDE3E1F7A1A886A2C7EAFCD4_AdjustorThunk (RuntimeObject* __this, UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C ___0_list, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	UnsafeList_1_AddRangeNoResize_mD850AF553A2F8263EDE3E1F7A1A886A2C7EAFCD4(_thisAdjusted, ___0_list, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_Add_mE02101A02348C4FE5C69658E032EB2BC5E2B0EC1_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* ___0_value, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	bool V_1 = false;
	{
		int32_t L_0 = __this->___m_length;
		V_0 = L_0;
		int32_t L_1 = __this->___m_length;
		int32_t L_2 = __this->___m_capacity;
		V_1 = (bool)((((int32_t)L_1) < ((int32_t)L_2))? 1 : 0);
		bool L_3 = V_1;
		if (!L_3)
		{
			goto IL_0046;
		}
	}
	{
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_4 = __this->___Ptr;
		int32_t L_5 = V_0;
		uint32_t L_6 = sizeof(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A);
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_7 = ___0_value;
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A L_8 = (*(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)L_7);
		*(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)((SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)il2cpp_codegen_add((intptr_t)L_4, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_5), (int32_t)L_6)))) = L_8;
		int32_t L_9 = __this->___m_length;
		__this->___m_length = ((int32_t)il2cpp_codegen_add(L_9, 1));
		goto IL_006c;
	}

IL_0046:
	{
		int32_t L_10 = V_0;
		UnsafeList_1_Resize_mF872E9A04824A2B9B2B673782565D043892D31D9(__this, ((int32_t)il2cpp_codegen_add(L_10, 1)), (int32_t)0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 3));
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_11 = __this->___Ptr;
		int32_t L_12 = V_0;
		uint32_t L_13 = sizeof(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A);
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_14 = ___0_value;
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A L_15 = (*(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)L_14);
		*(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)((SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)il2cpp_codegen_add((intptr_t)L_11, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_12), (int32_t)L_13)))) = L_15;
	}

IL_006c:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_Add_mE02101A02348C4FE5C69658E032EB2BC5E2B0EC1_AdjustorThunk (RuntimeObject* __this, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* ___0_value, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	UnsafeList_1_Add_mE02101A02348C4FE5C69658E032EB2BC5E2B0EC1_inline(_thisAdjusted, ___0_value, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_AddRange_m290AF2611869D3059792B0EDCF2DEAC70AE35CB6_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, void* ___0_ptr, int32_t ___1_count, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	void* V_2 = NULL;
	bool V_3 = false;
	{
		int32_t L_0 = __this->___m_length;
		V_0 = L_0;
		int32_t L_1 = __this->___m_length;
		int32_t L_2 = ___1_count;
		int32_t L_3;
		L_3 = UnsafeList_1_get_Capacity_mD86B514B3119D3E1A021A6CB23BE78590F5E486E_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_3 = (bool)((((int32_t)((int32_t)il2cpp_codegen_add(L_1, L_2))) > ((int32_t)L_3))? 1 : 0);
		bool L_4 = V_3;
		if (!L_4)
		{
			goto IL_0030;
		}
	}
	{
		int32_t L_5 = __this->___m_length;
		int32_t L_6 = ___1_count;
		UnsafeList_1_Resize_mF872E9A04824A2B9B2B673782565D043892D31D9(__this, ((int32_t)il2cpp_codegen_add(L_5, L_6)), (int32_t)0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 3));
		goto IL_0040;
	}

IL_0030:
	{
		int32_t L_7 = __this->___m_length;
		int32_t L_8 = ___1_count;
		__this->___m_length = ((int32_t)il2cpp_codegen_add(L_7, L_8));
	}

IL_0040:
	{
		uint32_t L_9 = sizeof(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A);
		V_1 = (int32_t)L_9;
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_10 = __this->___Ptr;
		int32_t L_11 = V_0;
		int32_t L_12 = V_1;
		V_2 = (void*)((SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)il2cpp_codegen_add((intptr_t)L_10, ((int32_t)il2cpp_codegen_multiply(L_11, L_12))));
		void* L_13 = V_2;
		void* L_14 = ___0_ptr;
		int32_t L_15 = ___1_count;
		int32_t L_16 = V_1;
		UnsafeUtility_MemCpy_m5CEA91ACDADC522E584AE3A2AB2B0B74393A9177(L_13, L_14, ((int64_t)((int32_t)il2cpp_codegen_multiply(L_15, L_16))), NULL);
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_AddRange_m290AF2611869D3059792B0EDCF2DEAC70AE35CB6_AdjustorThunk (RuntimeObject* __this, void* ___0_ptr, int32_t ___1_count, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	UnsafeList_1_AddRange_m290AF2611869D3059792B0EDCF2DEAC70AE35CB6(_thisAdjusted, ___0_ptr, ___1_count, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_AddReplicate_mA8C22B3C32A081106A17337AA53882D8CA92A49F_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* ___0_value, int32_t ___1_count, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	bool V_1 = false;
	void* V_2 = NULL;
	SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* V_3 = NULL;
	{
		int32_t L_0 = __this->___m_length;
		V_0 = L_0;
		int32_t L_1 = __this->___m_length;
		int32_t L_2 = ___1_count;
		int32_t L_3;
		L_3 = UnsafeList_1_get_Capacity_mD86B514B3119D3E1A021A6CB23BE78590F5E486E_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_1 = (bool)((((int32_t)((int32_t)il2cpp_codegen_add(L_1, L_2))) > ((int32_t)L_3))? 1 : 0);
		bool L_4 = V_1;
		if (!L_4)
		{
			goto IL_0030;
		}
	}
	{
		int32_t L_5 = __this->___m_length;
		int32_t L_6 = ___1_count;
		UnsafeList_1_Resize_mF872E9A04824A2B9B2B673782565D043892D31D9(__this, ((int32_t)il2cpp_codegen_add(L_5, L_6)), (int32_t)0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 3));
		goto IL_0040;
	}

IL_0030:
	{
		int32_t L_7 = __this->___m_length;
		int32_t L_8 = ___1_count;
		__this->___m_length = ((int32_t)il2cpp_codegen_add(L_7, L_8));
	}

IL_0040:
	{
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_9 = ___0_value;
		V_3 = L_9;
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_10 = V_3;
		V_2 = (void*)((uintptr_t)L_10);
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_11 = __this->___Ptr;
		int32_t L_12 = V_0;
		uint32_t L_13 = sizeof(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A);
		void* L_14 = V_2;
		int32_t L_15;
		L_15 = UnsafeUtility_SizeOf_TisSplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A_m6C96A05E2AC56907C62A2A917FE69A67EB3F72FB_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 22));
		int32_t L_16 = ___1_count;
		UnsafeUtility_MemCpyReplicate_m0432429C10859D5BE79799A6E98B44741244287F((void*)((SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)il2cpp_codegen_add((intptr_t)L_11, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_12), (int32_t)L_13)))), L_14, L_15, L_16, NULL);
		V_3 = (SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)((uintptr_t)0);
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_AddReplicate_mA8C22B3C32A081106A17337AA53882D8CA92A49F_AdjustorThunk (RuntimeObject* __this, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* ___0_value, int32_t ___1_count, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	UnsafeList_1_AddReplicate_mA8C22B3C32A081106A17337AA53882D8CA92A49F(_thisAdjusted, ___0_value, ___1_count, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_InsertRangeWithBeginEnd_mC5402628584EC1224906861332995DD894031938_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_begin, int32_t ___1_end, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	bool V_5 = false;
	bool V_6 = false;
	bool V_7 = false;
	uint8_t* V_8 = NULL;
	uint8_t* V_9 = NULL;
	uint8_t* V_10 = NULL;
	{
		int32_t L_0 = ___0_begin;
		int32_t L_1;
		L_1 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_0, NULL);
		___0_begin = L_1;
		int32_t L_2 = ___1_end;
		int32_t L_3;
		L_3 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_2, NULL);
		___1_end = L_3;
		int32_t L_4 = ___1_end;
		int32_t L_5 = ___0_begin;
		V_0 = ((int32_t)il2cpp_codegen_subtract(L_4, L_5));
		int32_t L_6 = V_0;
		V_5 = (bool)((((int32_t)L_6) < ((int32_t)1))? 1 : 0);
		bool L_7 = V_5;
		if (!L_7)
		{
			goto IL_0025;
		}
	}
	{
		goto IL_00aa;
	}

IL_0025:
	{
		int32_t L_8 = __this->___m_length;
		V_1 = L_8;
		int32_t L_9 = __this->___m_length;
		int32_t L_10 = V_0;
		int32_t L_11;
		L_11 = UnsafeList_1_get_Capacity_mD86B514B3119D3E1A021A6CB23BE78590F5E486E_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_6 = (bool)((((int32_t)((int32_t)il2cpp_codegen_add(L_9, L_10))) > ((int32_t)L_11))? 1 : 0);
		bool L_12 = V_6;
		if (!L_12)
		{
			goto IL_0056;
		}
	}
	{
		int32_t L_13 = __this->___m_length;
		int32_t L_14 = V_0;
		UnsafeList_1_Resize_mF872E9A04824A2B9B2B673782565D043892D31D9(__this, ((int32_t)il2cpp_codegen_add(L_13, L_14)), (int32_t)0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 3));
		goto IL_0066;
	}

IL_0056:
	{
		int32_t L_15 = __this->___m_length;
		int32_t L_16 = V_0;
		__this->___m_length = ((int32_t)il2cpp_codegen_add(L_15, L_16));
	}

IL_0066:
	{
		int32_t L_17 = V_1;
		int32_t L_18 = ___0_begin;
		V_2 = ((int32_t)il2cpp_codegen_subtract(L_17, L_18));
		int32_t L_19 = V_2;
		V_7 = (bool)((((int32_t)L_19) < ((int32_t)1))? 1 : 0);
		bool L_20 = V_7;
		if (!L_20)
		{
			goto IL_0077;
		}
	}
	{
		goto IL_00aa;
	}

IL_0077:
	{
		uint32_t L_21 = sizeof(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A);
		V_3 = (int32_t)L_21;
		int32_t L_22 = V_2;
		int32_t L_23 = V_3;
		V_4 = ((int32_t)il2cpp_codegen_multiply(L_22, L_23));
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_24 = __this->___Ptr;
		V_8 = (uint8_t*)L_24;
		uint8_t* L_25 = V_8;
		int32_t L_26 = ___1_end;
		int32_t L_27 = V_3;
		V_9 = ((uint8_t*)il2cpp_codegen_add((intptr_t)L_25, ((int32_t)il2cpp_codegen_multiply(L_26, L_27))));
		uint8_t* L_28 = V_8;
		int32_t L_29 = ___0_begin;
		int32_t L_30 = V_3;
		V_10 = ((uint8_t*)il2cpp_codegen_add((intptr_t)L_28, ((int32_t)il2cpp_codegen_multiply(L_29, L_30))));
		uint8_t* L_31 = V_9;
		uint8_t* L_32 = V_10;
		int32_t L_33 = V_4;
		UnsafeUtility_MemMove_m4799FAA9C4BCFA1AEDC6ED01BB9A6DF657C4CEE3((void*)L_31, (void*)L_32, ((int64_t)L_33), NULL);
	}

IL_00aa:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_InsertRangeWithBeginEnd_mC5402628584EC1224906861332995DD894031938_AdjustorThunk (RuntimeObject* __this, int32_t ___0_begin, int32_t ___1_end, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	UnsafeList_1_InsertRangeWithBeginEnd_mC5402628584EC1224906861332995DD894031938(_thisAdjusted, ___0_begin, ___1_end, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_RemoveAtSwapBack_mDE564A4CC3B47BF28AF0D1CF99A43A4E84210AAF_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_index, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* V_1 = NULL;
	SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* V_2 = NULL;
	{
		int32_t L_0 = ___0_index;
		int32_t L_1;
		L_1 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_0, NULL);
		___0_index = L_1;
		int32_t L_2 = __this->___m_length;
		V_0 = ((int32_t)il2cpp_codegen_subtract(L_2, 1));
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_3 = __this->___Ptr;
		int32_t L_4 = ___0_index;
		uint32_t L_5 = sizeof(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A);
		V_1 = ((SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)il2cpp_codegen_add((intptr_t)L_3, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_4), (int32_t)L_5))));
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_6 = __this->___Ptr;
		int32_t L_7 = V_0;
		uint32_t L_8 = sizeof(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A);
		V_2 = ((SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)il2cpp_codegen_add((intptr_t)L_6, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_7), (int32_t)L_8))));
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_9 = V_1;
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_10 = V_2;
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A L_11 = (*(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)L_10);
		*(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)L_9 = L_11;
		int32_t L_12 = __this->___m_length;
		__this->___m_length = ((int32_t)il2cpp_codegen_subtract(L_12, 1));
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_RemoveAtSwapBack_mDE564A4CC3B47BF28AF0D1CF99A43A4E84210AAF_AdjustorThunk (RuntimeObject* __this, int32_t ___0_index, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	UnsafeList_1_RemoveAtSwapBack_mDE564A4CC3B47BF28AF0D1CF99A43A4E84210AAF(_thisAdjusted, ___0_index, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_RemoveRangeSwapBack_m100F1A29384A20C6513B0D434D60DC7E66828D2F_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_index, int32_t ___1_count, const RuntimeMethod* method) 
{
	bool V_0 = false;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	void* V_3 = NULL;
	void* V_4 = NULL;
	{
		int32_t L_0 = ___0_index;
		int32_t L_1;
		L_1 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_0, NULL);
		___0_index = L_1;
		int32_t L_2 = ___1_count;
		int32_t L_3;
		L_3 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_2, NULL);
		___1_count = L_3;
		int32_t L_4 = ___1_count;
		V_0 = (bool)((((int32_t)L_4) > ((int32_t)0))? 1 : 0);
		bool L_5 = V_0;
		if (!L_5)
		{
			goto IL_006c;
		}
	}
	{
		int32_t L_6 = __this->___m_length;
		int32_t L_7 = ___1_count;
		int32_t L_8 = ___0_index;
		int32_t L_9 = ___1_count;
		int32_t L_10;
		L_10 = math_max_m9083201D37A8ED0157B127B5878D9B7F3A2A40BE_inline(((int32_t)il2cpp_codegen_subtract(L_6, L_7)), ((int32_t)il2cpp_codegen_add(L_8, L_9)), NULL);
		V_1 = L_10;
		uint32_t L_11 = sizeof(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A);
		V_2 = (int32_t)L_11;
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_12 = __this->___Ptr;
		int32_t L_13 = ___0_index;
		int32_t L_14 = V_2;
		V_3 = (void*)((SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)il2cpp_codegen_add((intptr_t)L_12, ((int32_t)il2cpp_codegen_multiply(L_13, L_14))));
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_15 = __this->___Ptr;
		int32_t L_16 = V_1;
		int32_t L_17 = V_2;
		V_4 = (void*)((SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)il2cpp_codegen_add((intptr_t)L_15, ((int32_t)il2cpp_codegen_multiply(L_16, L_17))));
		void* L_18 = V_3;
		void* L_19 = V_4;
		int32_t L_20 = __this->___m_length;
		int32_t L_21 = V_1;
		int32_t L_22 = V_2;
		UnsafeUtility_MemCpy_m5CEA91ACDADC522E584AE3A2AB2B0B74393A9177(L_18, L_19, ((int64_t)((int32_t)il2cpp_codegen_multiply(((int32_t)il2cpp_codegen_subtract(L_20, L_21)), L_22))), NULL);
		int32_t L_23 = __this->___m_length;
		int32_t L_24 = ___1_count;
		__this->___m_length = ((int32_t)il2cpp_codegen_subtract(L_23, L_24));
	}

IL_006c:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_RemoveRangeSwapBack_m100F1A29384A20C6513B0D434D60DC7E66828D2F_AdjustorThunk (RuntimeObject* __this, int32_t ___0_index, int32_t ___1_count, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	UnsafeList_1_RemoveRangeSwapBack_m100F1A29384A20C6513B0D434D60DC7E66828D2F(_thisAdjusted, ___0_index, ___1_count, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_RemoveAt_mAE596941D78BA2014C3E3048ABDAEEC7CE5D5227_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_index, const RuntimeMethod* method) 
{
	SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* V_0 = NULL;
	SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* V_1 = NULL;
	int32_t V_2 = 0;
	SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* V_3 = NULL;
	bool V_4 = false;
	{
		int32_t L_0 = ___0_index;
		int32_t L_1;
		L_1 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_0, NULL);
		___0_index = L_1;
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_2 = __this->___Ptr;
		int32_t L_3 = ___0_index;
		uint32_t L_4 = sizeof(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A);
		V_0 = ((SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)il2cpp_codegen_add((intptr_t)L_2, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_3), (int32_t)L_4))));
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_5 = V_0;
		uint32_t L_6 = sizeof(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A);
		V_1 = ((SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)il2cpp_codegen_add((intptr_t)L_5, (int32_t)L_6));
		int32_t L_7 = __this->___m_length;
		__this->___m_length = ((int32_t)il2cpp_codegen_subtract(L_7, 1));
		int32_t L_8 = ___0_index;
		V_2 = L_8;
		goto IL_005d;
	}

IL_0035:
	{
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_9 = V_0;
		V_3 = L_9;
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_10 = V_3;
		uint32_t L_11 = sizeof(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A);
		V_0 = ((SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)il2cpp_codegen_add((intptr_t)L_10, (int32_t)L_11));
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_12 = V_3;
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_13 = V_1;
		V_3 = L_13;
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_14 = V_3;
		uint32_t L_15 = sizeof(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A);
		V_1 = ((SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)il2cpp_codegen_add((intptr_t)L_14, (int32_t)L_15));
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_16 = V_3;
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A L_17 = (*(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)L_16);
		*(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)L_12 = L_17;
		int32_t L_18 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_18, 1));
	}

IL_005d:
	{
		int32_t L_19 = V_2;
		int32_t L_20 = __this->___m_length;
		V_4 = (bool)((((int32_t)L_19) < ((int32_t)L_20))? 1 : 0);
		bool L_21 = V_4;
		if (L_21)
		{
			goto IL_0035;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_RemoveAt_mAE596941D78BA2014C3E3048ABDAEEC7CE5D5227_AdjustorThunk (RuntimeObject* __this, int32_t ___0_index, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	UnsafeList_1_RemoveAt_mAE596941D78BA2014C3E3048ABDAEEC7CE5D5227(_thisAdjusted, ___0_index, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_RemoveRange_m85604203599589C689C82B1071C5629617C4E5C2_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_index, int32_t ___1_count, const RuntimeMethod* method) 
{
	bool V_0 = false;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	void* V_3 = NULL;
	void* V_4 = NULL;
	{
		int32_t L_0 = ___0_index;
		int32_t L_1;
		L_1 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_0, NULL);
		___0_index = L_1;
		int32_t L_2 = ___1_count;
		int32_t L_3;
		L_3 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_2, NULL);
		___1_count = L_3;
		int32_t L_4 = ___1_count;
		V_0 = (bool)((((int32_t)L_4) > ((int32_t)0))? 1 : 0);
		bool L_5 = V_0;
		if (!L_5)
		{
			goto IL_006a;
		}
	}
	{
		int32_t L_6 = ___0_index;
		int32_t L_7 = ___1_count;
		int32_t L_8 = __this->___m_length;
		int32_t L_9;
		L_9 = math_min_m02D43DF516544C279AF660EA4731449C82991849_inline(((int32_t)il2cpp_codegen_add(L_6, L_7)), L_8, NULL);
		V_1 = L_9;
		uint32_t L_10 = sizeof(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A);
		V_2 = (int32_t)L_10;
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_11 = __this->___Ptr;
		int32_t L_12 = ___0_index;
		int32_t L_13 = V_2;
		V_3 = (void*)((SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)il2cpp_codegen_add((intptr_t)L_11, ((int32_t)il2cpp_codegen_multiply(L_12, L_13))));
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_14 = __this->___Ptr;
		int32_t L_15 = V_1;
		int32_t L_16 = V_2;
		V_4 = (void*)((SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)il2cpp_codegen_add((intptr_t)L_14, ((int32_t)il2cpp_codegen_multiply(L_15, L_16))));
		void* L_17 = V_3;
		void* L_18 = V_4;
		int32_t L_19 = __this->___m_length;
		int32_t L_20 = V_1;
		int32_t L_21 = V_2;
		UnsafeUtility_MemCpy_m5CEA91ACDADC522E584AE3A2AB2B0B74393A9177(L_17, L_18, ((int64_t)((int32_t)il2cpp_codegen_multiply(((int32_t)il2cpp_codegen_subtract(L_19, L_20)), L_21))), NULL);
		int32_t L_22 = __this->___m_length;
		int32_t L_23 = ___1_count;
		__this->___m_length = ((int32_t)il2cpp_codegen_subtract(L_22, L_23));
	}

IL_006a:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_RemoveRange_m85604203599589C689C82B1071C5629617C4E5C2_AdjustorThunk (RuntimeObject* __this, int32_t ___0_index, int32_t ___1_count, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	UnsafeList_1_RemoveRange_m85604203599589C689C82B1071C5629617C4E5C2(_thisAdjusted, ___0_index, ___1_count, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_CopyFrom_m65DBB0C13CA29FE140BCD0FEB1993C55723C3252_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, NativeArray_1_t933EB4C2ED1CCB3C68D5E2EC18C770C2893C8443* ___0_other, const RuntimeMethod* method) 
{
	NativeArray_1_t933EB4C2ED1CCB3C68D5E2EC18C770C2893C8443 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		NativeArray_1_t933EB4C2ED1CCB3C68D5E2EC18C770C2893C8443* L_0 = ___0_other;
		NativeArray_1_t933EB4C2ED1CCB3C68D5E2EC18C770C2893C8443 L_1 = (*(NativeArray_1_t933EB4C2ED1CCB3C68D5E2EC18C770C2893C8443*)L_0);
		V_0 = L_1;
		int32_t L_2;
		L_2 = IL2CPP_NATIVEARRAY_GET_LENGTH(((&V_0))->___m_Length);
		UnsafeList_1_Resize_mF872E9A04824A2B9B2B673782565D043892D31D9(__this, L_2, (int32_t)0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 3));
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_3 = __this->___Ptr;
		NativeArray_1_t933EB4C2ED1CCB3C68D5E2EC18C770C2893C8443* L_4 = ___0_other;
		NativeArray_1_t933EB4C2ED1CCB3C68D5E2EC18C770C2893C8443 L_5 = (*(NativeArray_1_t933EB4C2ED1CCB3C68D5E2EC18C770C2893C8443*)L_4);
		void* L_6;
		L_6 = NativeArrayUnsafeUtility_GetUnsafeReadOnlyPtr_TisSplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A_mEA7A2AAE07DCFD8DAB7122AEC01806A98F3AE6CE(L_5, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 28));
		int32_t L_7;
		L_7 = UnsafeUtility_SizeOf_TisSplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A_m6C96A05E2AC56907C62A2A917FE69A67EB3F72FB_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 22));
		NativeArray_1_t933EB4C2ED1CCB3C68D5E2EC18C770C2893C8443* L_8 = ___0_other;
		NativeArray_1_t933EB4C2ED1CCB3C68D5E2EC18C770C2893C8443 L_9 = (*(NativeArray_1_t933EB4C2ED1CCB3C68D5E2EC18C770C2893C8443*)L_8);
		V_0 = L_9;
		int32_t L_10;
		L_10 = IL2CPP_NATIVEARRAY_GET_LENGTH(((&V_0))->___m_Length);
		UnsafeUtility_MemCpy_m5CEA91ACDADC522E584AE3A2AB2B0B74393A9177((void*)L_3, L_6, ((int64_t)((int32_t)il2cpp_codegen_multiply(L_7, L_10))), NULL);
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_CopyFrom_m65DBB0C13CA29FE140BCD0FEB1993C55723C3252_AdjustorThunk (RuntimeObject* __this, NativeArray_1_t933EB4C2ED1CCB3C68D5E2EC18C770C2893C8443* ___0_other, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	UnsafeList_1_CopyFrom_m65DBB0C13CA29FE140BCD0FEB1993C55723C3252(_thisAdjusted, ___0_other, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_CopyFrom_m836376D9E1B104ABFC8471073E2D9A8A65B7B5D3_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* ___0_other, const RuntimeMethod* method) 
{
	{
		UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* L_0 = ___0_other;
		int32_t L_1;
		L_1 = UnsafeList_1_get_Length_m30C8B237736009EBD4E69E7D215B9650233D037C_inline(L_0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 20));
		UnsafeList_1_Resize_mF872E9A04824A2B9B2B673782565D043892D31D9(__this, L_1, (int32_t)0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 3));
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_2 = __this->___Ptr;
		UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* L_3 = ___0_other;
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_4 = L_3->___Ptr;
		int32_t L_5;
		L_5 = UnsafeUtility_SizeOf_TisSplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A_m6C96A05E2AC56907C62A2A917FE69A67EB3F72FB_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 22));
		UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* L_6 = ___0_other;
		int32_t L_7;
		L_7 = UnsafeList_1_get_Length_m30C8B237736009EBD4E69E7D215B9650233D037C_inline(L_6, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 20));
		UnsafeUtility_MemCpy_m5CEA91ACDADC522E584AE3A2AB2B0B74393A9177((void*)L_2, (void*)L_4, ((int64_t)((int32_t)il2cpp_codegen_multiply(L_5, L_7))), NULL);
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_CopyFrom_m836376D9E1B104ABFC8471073E2D9A8A65B7B5D3_AdjustorThunk (RuntimeObject* __this, UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* ___0_other, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	UnsafeList_1_CopyFrom_m836376D9E1B104ABFC8471073E2D9A8A65B7B5D3(_thisAdjusted, ___0_other, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* UnsafeList_1_System_Collections_IEnumerable_GetEnumerator_mB1A8B4B473D9E1667ADF1B265CA1C7E59274D7AA_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method) 
{
	{
		NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8* L_0 = (NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8_il2cpp_TypeInfo_var)));
		NotImplementedException__ctor_mDAB47BC6BD0E342E8F2171E5CABE3E67EA049F1C(L_0, NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_0, method);
	}
}
IL2CPP_EXTERN_C  RuntimeObject* UnsafeList_1_System_Collections_IEnumerable_GetEnumerator_mB1A8B4B473D9E1667ADF1B265CA1C7E59274D7AA_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	RuntimeObject* _returnValue;
	_returnValue = UnsafeList_1_System_Collections_IEnumerable_GetEnumerator_mB1A8B4B473D9E1667ADF1B265CA1C7E59274D7AA(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* UnsafeList_1_System_Collections_Generic_IEnumerableU3CTU3E_GetEnumerator_mF2DFB1A66D985398367765F12E3ADB88D01D05C0_gshared (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method) 
{
	{
		NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8* L_0 = (NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8_il2cpp_TypeInfo_var)));
		NotImplementedException__ctor_mDAB47BC6BD0E342E8F2171E5CABE3E67EA049F1C(L_0, NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_0, method);
	}
}
IL2CPP_EXTERN_C  RuntimeObject* UnsafeList_1_System_Collections_Generic_IEnumerableU3CTU3E_GetEnumerator_mF2DFB1A66D985398367765F12E3ADB88D01D05C0_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C*>(__this + _offset);
	RuntimeObject* _returnValue;
	_returnValue = UnsafeList_1_System_Collections_Generic_IEnumerableU3CTU3E_GetEnumerator_mF2DFB1A66D985398367765F12E3ADB88D01D05C0(_thisAdjusted, method);
	return _returnValue;
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeList_1_get_Length_mFE9C02C4C7169AE23DE6BC1B834E0DBC1D03DBB1_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___m_length;
		int32_t L_1;
		L_1 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_0, NULL);
		return L_1;
	}
}
IL2CPP_EXTERN_C  int32_t UnsafeList_1_get_Length_mFE9C02C4C7169AE23DE6BC1B834E0DBC1D03DBB1_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	int32_t _returnValue;
	_returnValue = UnsafeList_1_get_Length_mFE9C02C4C7169AE23DE6BC1B834E0DBC1D03DBB1_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_set_Length_m053843BFA1C2D31E71CC871DE1B08DE91BF01416_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_value, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		int32_t L_0 = ___0_value;
		int32_t L_1;
		L_1 = UnsafeList_1_get_Capacity_m9C10840F54FD1F0871C1C7E25CE7AF92622DF9AD_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_0 = (bool)((((int32_t)L_0) > ((int32_t)L_1))? 1 : 0);
		bool L_2 = V_0;
		if (!L_2)
		{
			goto IL_001b;
		}
	}
	{
		int32_t L_3 = ___0_value;
		UnsafeList_1_Resize_mA8E41BF0D06DD764B65618C554B138588019DCA9(__this, L_3, (int32_t)0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 3));
		goto IL_0024;
	}

IL_001b:
	{
		int32_t L_4 = ___0_value;
		__this->___m_length = L_4;
	}

IL_0024:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_set_Length_m053843BFA1C2D31E71CC871DE1B08DE91BF01416_AdjustorThunk (RuntimeObject* __this, int32_t ___0_value, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	UnsafeList_1_set_Length_m053843BFA1C2D31E71CC871DE1B08DE91BF01416(_thisAdjusted, ___0_value, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeList_1_get_Capacity_m9C10840F54FD1F0871C1C7E25CE7AF92622DF9AD_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___m_capacity;
		int32_t L_1;
		L_1 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_0, NULL);
		return L_1;
	}
}
IL2CPP_EXTERN_C  int32_t UnsafeList_1_get_Capacity_m9C10840F54FD1F0871C1C7E25CE7AF92622DF9AD_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	int32_t _returnValue;
	_returnValue = UnsafeList_1_get_Capacity_m9C10840F54FD1F0871C1C7E25CE7AF92622DF9AD_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_set_Capacity_mC07B19231AD2F3637381CBAF53723C4BCE13CF40_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_value, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___0_value;
		UnsafeList_1_SetCapacity_mBBADF24575202AD2F6156C29CD6DB788AB15C5C8(__this, L_0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 4));
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_set_Capacity_mC07B19231AD2F3637381CBAF53723C4BCE13CF40_AdjustorThunk (RuntimeObject* __this, int32_t ___0_value, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	UnsafeList_1_set_Capacity_mC07B19231AD2F3637381CBAF53723C4BCE13CF40(_thisAdjusted, ___0_value, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 UnsafeList_1_get_Item_mEFA75FB7304D5FFEA7E3F6226B01453D10013A3B_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_index, const RuntimeMethod* method) 
{
	Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_0 = __this->___Ptr;
		int32_t L_1 = ___0_index;
		int32_t L_2;
		L_2 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_1, NULL);
		uint32_t L_3 = sizeof(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127);
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 L_4 = (*(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)((Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_2), (int32_t)L_3)))));
		V_0 = L_4;
		goto IL_001e;
	}

IL_001e:
	{
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 L_5 = V_0;
		return L_5;
	}
}
IL2CPP_EXTERN_C  Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 UnsafeList_1_get_Item_mEFA75FB7304D5FFEA7E3F6226B01453D10013A3B_AdjustorThunk (RuntimeObject* __this, int32_t ___0_index, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 _returnValue;
	_returnValue = UnsafeList_1_get_Item_mEFA75FB7304D5FFEA7E3F6226B01453D10013A3B_inline(_thisAdjusted, ___0_index, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_set_Item_m0B5139C9A3714A3C5E0B576AB276E1A0FCA406B9_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_index, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 ___1_value, const RuntimeMethod* method) 
{
	{
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_0 = __this->___Ptr;
		int32_t L_1 = ___0_index;
		int32_t L_2;
		L_2 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_1, NULL);
		uint32_t L_3 = sizeof(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127);
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 L_4 = ___1_value;
		*(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)((Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_2), (int32_t)L_3)))) = L_4;
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_set_Item_m0B5139C9A3714A3C5E0B576AB276E1A0FCA406B9_AdjustorThunk (RuntimeObject* __this, int32_t ___0_index, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 ___1_value, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	UnsafeList_1_set_Item_m0B5139C9A3714A3C5E0B576AB276E1A0FCA406B9_inline(_thisAdjusted, ___0_index, ___1_value, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* UnsafeList_1_ElementAt_m43B542F9E0F11A380A8AC0435939688D55836A0D_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_index, const RuntimeMethod* method) 
{
	Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* V_0 = NULL;
	{
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_0 = __this->___Ptr;
		int32_t L_1 = ___0_index;
		int32_t L_2;
		L_2 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_1, NULL);
		uint32_t L_3 = sizeof(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127);
		V_0 = (Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)((Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_2), (int32_t)L_3))));
		goto IL_0019;
	}

IL_0019:
	{
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_4 = V_0;
		return L_4;
	}
}
IL2CPP_EXTERN_C  Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* UnsafeList_1_ElementAt_m43B542F9E0F11A380A8AC0435939688D55836A0D_AdjustorThunk (RuntimeObject* __this, int32_t ___0_index, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* _returnValue;
	_returnValue = UnsafeList_1_ElementAt_m43B542F9E0F11A380A8AC0435939688D55836A0D_inline(_thisAdjusted, ___0_index, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1__ctor_m5D36D9B673FEB6B6B5DDAA6DBA2D1773B13C0C2D_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_initialCapacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___1_allocator, int32_t ___2_options, const RuntimeMethod* method) 
{
	bool V_0 = false;
	int32_t V_1 = 0;
	int32_t G_B3_0 = 0;
	{
		__this->___Ptr = (Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)((uintptr_t)0);
		__this->___m_length = 0;
		__this->___m_capacity = 0;
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_0 = ___1_allocator;
		__this->___Allocator = L_0;
		__this->___padding = 0;
		int32_t L_1 = ___0_initialCapacity;
		int32_t L_2;
		L_2 = math_max_m9083201D37A8ED0157B127B5878D9B7F3A2A40BE_inline(L_1, 1, NULL);
		UnsafeList_1_SetCapacity_mBBADF24575202AD2F6156C29CD6DB788AB15C5C8(__this, L_2, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 4));
		int32_t L_3 = ___2_options;
		if ((!(((uint32_t)L_3) == ((uint32_t)1))))
		{
			goto IL_0046;
		}
	}
	{
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_4 = __this->___Ptr;
		G_B3_0 = ((((int32_t)((((intptr_t)L_4) == ((intptr_t)((uintptr_t)0)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0047;
	}

IL_0046:
	{
		G_B3_0 = 0;
	}

IL_0047:
	{
		V_0 = (bool)G_B3_0;
		bool L_5 = V_0;
		if (!L_5)
		{
			goto IL_0069;
		}
	}
	{
		uint32_t L_6 = sizeof(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127);
		V_1 = (int32_t)L_6;
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_7 = __this->___Ptr;
		int32_t L_8;
		L_8 = UnsafeList_1_get_Capacity_m9C10840F54FD1F0871C1C7E25CE7AF92622DF9AD_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_9 = V_1;
		UnsafeUtility_MemClear_m6C4377117084A11A667A567BC2F5E606A632A7C1((void*)L_7, ((int64_t)((int32_t)il2cpp_codegen_multiply(L_8, L_9))), NULL);
	}

IL_0069:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1__ctor_m5D36D9B673FEB6B6B5DDAA6DBA2D1773B13C0C2D_AdjustorThunk (RuntimeObject* __this, int32_t ___0_initialCapacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___1_allocator, int32_t ___2_options, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	UnsafeList_1__ctor_m5D36D9B673FEB6B6B5DDAA6DBA2D1773B13C0C2D(_thisAdjusted, ___0_initialCapacity, ___1_allocator, ___2_options, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_Destroy_m7A3EA8A2752ACE61520F4E4298D3082756CB5B4E_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* ___0_listData, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AllocatorManager_tFB15A22029C8159A3DCD4C08935BE57D3E6B3C2C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* L_0 = ___0_listData;
		NullCheck(L_0);
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_1 = L_0->___Allocator;
		V_0 = L_1;
		UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* L_2 = ___0_listData;
		UnsafeList_1_Dispose_mE60AFFB718C0BD8A36BDF427B8BC76F17D46FF80((UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*)L_2, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 11));
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_3 = V_0;
		UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* L_4 = ___0_listData;
		il2cpp_codegen_runtime_class_init_inline(AllocatorManager_tFB15A22029C8159A3DCD4C08935BE57D3E6B3C2C_il2cpp_TypeInfo_var);
		AllocatorManager_Free_TisUnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7_m2ACD46900DC49986AE7EA226E807CF511B3DF9DD(L_3, L_4, 1, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeList_1_get_IsEmpty_m436BA19BA9C162ACC4DB0819037CBB975135A952_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method) 
{
	int32_t G_B3_0 = 0;
	{
		bool L_0;
		L_0 = UnsafeList_1_get_IsCreated_m4B100662A0B454C46725BE8CEC4A746E61835062_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		if (!L_0)
		{
			goto IL_0013;
		}
	}
	{
		int32_t L_1 = __this->___m_length;
		G_B3_0 = ((((int32_t)L_1) == ((int32_t)0))? 1 : 0);
		goto IL_0014;
	}

IL_0013:
	{
		G_B3_0 = 1;
	}

IL_0014:
	{
		return (bool)G_B3_0;
	}
}
IL2CPP_EXTERN_C  bool UnsafeList_1_get_IsEmpty_m436BA19BA9C162ACC4DB0819037CBB975135A952_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	bool _returnValue;
	_returnValue = UnsafeList_1_get_IsEmpty_m436BA19BA9C162ACC4DB0819037CBB975135A952_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeList_1_get_IsCreated_m4B100662A0B454C46725BE8CEC4A746E61835062_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method) 
{
	{
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_0 = __this->___Ptr;
		return (bool)((((int32_t)((((intptr_t)L_0) == ((intptr_t)((uintptr_t)0)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
	}
}
IL2CPP_EXTERN_C  bool UnsafeList_1_get_IsCreated_m4B100662A0B454C46725BE8CEC4A746E61835062_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	bool _returnValue;
	_returnValue = UnsafeList_1_get_IsCreated_m4B100662A0B454C46725BE8CEC4A746E61835062_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_Dispose_mE60AFFB718C0BD8A36BDF427B8BC76F17D46FF80_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AllocatorManager_tFB15A22029C8159A3DCD4C08935BE57D3E6B3C2C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	bool V_1 = false;
	{
		bool L_0;
		L_0 = UnsafeList_1_get_IsCreated_m4B100662A0B454C46725BE8CEC4A746E61835062_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		V_0 = (bool)((((int32_t)L_0) == ((int32_t)0))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0011;
		}
	}
	{
		goto IL_005b;
	}

IL_0011:
	{
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_2 = __this->___Allocator;
		bool L_3;
		L_3 = CollectionHelper_ShouldDeallocate_m505E7EDBA71F02BAF52CC9DCD7C593CDA85D5465(L_2, NULL);
		V_1 = L_3;
		bool L_4 = V_1;
		if (!L_4)
		{
			goto IL_0045;
		}
	}
	{
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_5 = __this->___Allocator;
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_6 = __this->___Ptr;
		int32_t L_7 = __this->___m_capacity;
		il2cpp_codegen_runtime_class_init_inline(AllocatorManager_tFB15A22029C8159A3DCD4C08935BE57D3E6B3C2C_il2cpp_TypeInfo_var);
		AllocatorManager_Free_TisSlot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127_mA83D7FD9125891D2119A7B1F691163E0C357ADA6(L_5, L_6, L_7, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 14));
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_8 = ((AllocatorManager_tFB15A22029C8159A3DCD4C08935BE57D3E6B3C2C_StaticFields*)il2cpp_codegen_static_fields_for(AllocatorManager_tFB15A22029C8159A3DCD4C08935BE57D3E6B3C2C_il2cpp_TypeInfo_var))->___Invalid;
		__this->___Allocator = L_8;
	}

IL_0045:
	{
		__this->___Ptr = (Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)((uintptr_t)0);
		__this->___m_length = 0;
		__this->___m_capacity = 0;
	}

IL_005b:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_Dispose_mE60AFFB718C0BD8A36BDF427B8BC76F17D46FF80_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	UnsafeList_1_Dispose_mE60AFFB718C0BD8A36BDF427B8BC76F17D46FF80(_thisAdjusted, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_Clear_m7323877F6C7EBAD0F7EE4CAD4E1DF7F7A417BCAF_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method) 
{
	{
		__this->___m_length = 0;
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_Clear_m7323877F6C7EBAD0F7EE4CAD4E1DF7F7A417BCAF_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	UnsafeList_1_Clear_m7323877F6C7EBAD0F7EE4CAD4E1DF7F7A417BCAF(_thisAdjusted, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_Resize_mA8E41BF0D06DD764B65618C554B138588019DCA9_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_length, int32_t ___1_options, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	bool V_1 = false;
	bool V_2 = false;
	int32_t V_3 = 0;
	uint8_t* V_4 = NULL;
	int32_t V_5 = 0;
	int32_t G_B5_0 = 0;
	{
		int32_t L_0 = __this->___m_length;
		V_0 = L_0;
		int32_t L_1 = ___0_length;
		int32_t L_2;
		L_2 = UnsafeList_1_get_Capacity_m9C10840F54FD1F0871C1C7E25CE7AF92622DF9AD_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_1 = (bool)((((int32_t)L_1) > ((int32_t)L_2))? 1 : 0);
		bool L_3 = V_1;
		if (!L_3)
		{
			goto IL_001f;
		}
	}
	{
		int32_t L_4 = ___0_length;
		UnsafeList_1_SetCapacity_mBBADF24575202AD2F6156C29CD6DB788AB15C5C8(__this, L_4, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 4));
	}

IL_001f:
	{
		int32_t L_5 = ___0_length;
		__this->___m_length = L_5;
		int32_t L_6 = ___1_options;
		if ((!(((uint32_t)L_6) == ((uint32_t)1))))
		{
			goto IL_0030;
		}
	}
	{
		int32_t L_7 = V_0;
		int32_t L_8 = ___0_length;
		G_B5_0 = ((((int32_t)L_7) < ((int32_t)L_8))? 1 : 0);
		goto IL_0031;
	}

IL_0030:
	{
		G_B5_0 = 0;
	}

IL_0031:
	{
		V_2 = (bool)G_B5_0;
		bool L_9 = V_2;
		if (!L_9)
		{
			goto IL_005d;
		}
	}
	{
		int32_t L_10 = ___0_length;
		int32_t L_11 = V_0;
		V_3 = ((int32_t)il2cpp_codegen_subtract(L_10, L_11));
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_12 = __this->___Ptr;
		V_4 = (uint8_t*)L_12;
		uint32_t L_13 = sizeof(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127);
		V_5 = (int32_t)L_13;
		uint8_t* L_14 = V_4;
		int32_t L_15 = V_0;
		int32_t L_16 = V_5;
		int32_t L_17 = V_3;
		int32_t L_18 = V_5;
		UnsafeUtility_MemClear_m6C4377117084A11A667A567BC2F5E606A632A7C1((void*)((uint8_t*)il2cpp_codegen_add((intptr_t)L_14, ((int32_t)il2cpp_codegen_multiply(L_15, L_16)))), ((int64_t)((int32_t)il2cpp_codegen_multiply(L_17, L_18))), NULL);
	}

IL_005d:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_Resize_mA8E41BF0D06DD764B65618C554B138588019DCA9_AdjustorThunk (RuntimeObject* __this, int32_t ___0_length, int32_t ___1_options, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	UnsafeList_1_Resize_mA8E41BF0D06DD764B65618C554B138588019DCA9(_thisAdjusted, ___0_length, ___1_options, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_ResizeExact_mD71C35B2525653A8A0734B25902643471D9934FF_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_capacity, const RuntimeMethod* method) 
{
	{
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148* L_0 = (AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148*)(&__this->___Allocator);
		int32_t L_1 = ___0_capacity;
		UnsafeList_1_ResizeExact_TisAllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148_mDAF433094E4F5C8022D2D327C78F8213DC96CF97(__this, L_0, L_1, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 16));
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_ResizeExact_mD71C35B2525653A8A0734B25902643471D9934FF_AdjustorThunk (RuntimeObject* __this, int32_t ___0_capacity, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	UnsafeList_1_ResizeExact_mD71C35B2525653A8A0734B25902643471D9934FF(_thisAdjusted, ___0_capacity, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_SetCapacity_mBBADF24575202AD2F6156C29CD6DB788AB15C5C8_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_capacity, const RuntimeMethod* method) 
{
	{
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148* L_0 = (AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148*)(&__this->___Allocator);
		int32_t L_1 = ___0_capacity;
		UnsafeList_1_SetCapacity_TisAllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148_m6F2A7EE715E1620965BB586860D3D44B3D8F6BA3(__this, L_0, L_1, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 17));
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_SetCapacity_mBBADF24575202AD2F6156C29CD6DB788AB15C5C8_AdjustorThunk (RuntimeObject* __this, int32_t ___0_capacity, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	UnsafeList_1_SetCapacity_mBBADF24575202AD2F6156C29CD6DB788AB15C5C8(_thisAdjusted, ___0_capacity, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_TrimExcess_mE3AF5AF66473695DE2F8698576DE9A28301D871F_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		int32_t L_0;
		L_0 = UnsafeList_1_get_Capacity_m9C10840F54FD1F0871C1C7E25CE7AF92622DF9AD_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		int32_t L_1 = __this->___m_length;
		V_0 = (bool)((((int32_t)((((int32_t)L_0) == ((int32_t)L_1))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_2 = V_0;
		if (!L_2)
		{
			goto IL_0025;
		}
	}
	{
		int32_t L_3 = __this->___m_length;
		UnsafeList_1_ResizeExact_mD71C35B2525653A8A0734B25902643471D9934FF(__this, L_3, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 18));
	}

IL_0025:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_TrimExcess_mE3AF5AF66473695DE2F8698576DE9A28301D871F_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	UnsafeList_1_TrimExcess_mE3AF5AF66473695DE2F8698576DE9A28301D871F(_thisAdjusted, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_AddNoResize_m884048B32C3E428BD16BB73C3162E27F1B3EF326_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 ___0_value, const RuntimeMethod* method) 
{
	{
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_0 = __this->___Ptr;
		int32_t L_1 = __this->___m_length;
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 L_2 = ___0_value;
		UnsafeUtility_WriteArrayElement_TisSlot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127_m4F77AC19B6051E7566C5A3561715FC4CB8D462AF_inline((void*)L_0, L_1, L_2, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 19));
		int32_t L_3 = __this->___m_length;
		__this->___m_length = ((int32_t)il2cpp_codegen_add(L_3, 1));
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_AddNoResize_m884048B32C3E428BD16BB73C3162E27F1B3EF326_AdjustorThunk (RuntimeObject* __this, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 ___0_value, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	UnsafeList_1_AddNoResize_m884048B32C3E428BD16BB73C3162E27F1B3EF326_inline(_thisAdjusted, ___0_value, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_AddRangeNoResize_mD2A2918E38DFA75F76BF852015F849DAC06AD533_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, void* ___0_ptr, int32_t ___1_count, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	void* V_1 = NULL;
	{
		uint32_t L_0 = sizeof(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127);
		V_0 = (int32_t)L_0;
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_1 = __this->___Ptr;
		int32_t L_2 = __this->___m_length;
		int32_t L_3 = V_0;
		V_1 = (void*)((Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)il2cpp_codegen_add((intptr_t)L_1, ((int32_t)il2cpp_codegen_multiply(L_2, L_3))));
		void* L_4 = V_1;
		void* L_5 = ___0_ptr;
		int32_t L_6 = ___1_count;
		int32_t L_7 = V_0;
		UnsafeUtility_MemCpy_m5CEA91ACDADC522E584AE3A2AB2B0B74393A9177(L_4, L_5, ((int64_t)((int32_t)il2cpp_codegen_multiply(L_6, L_7))), NULL);
		int32_t L_8 = __this->___m_length;
		int32_t L_9 = ___1_count;
		__this->___m_length = ((int32_t)il2cpp_codegen_add(L_8, L_9));
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_AddRangeNoResize_mD2A2918E38DFA75F76BF852015F849DAC06AD533_AdjustorThunk (RuntimeObject* __this, void* ___0_ptr, int32_t ___1_count, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	UnsafeList_1_AddRangeNoResize_mD2A2918E38DFA75F76BF852015F849DAC06AD533(_thisAdjusted, ___0_ptr, ___1_count, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_AddRangeNoResize_m8521348DD738300ECE4F77B891B87A9833DA5A7D_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7 ___0_list, const RuntimeMethod* method) 
{
	{
		UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7 L_0 = ___0_list;
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_1 = L_0.___Ptr;
		int32_t L_2;
		L_2 = UnsafeList_1_get_Length_mFE9C02C4C7169AE23DE6BC1B834E0DBC1D03DBB1_inline((&___0_list), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 20));
		int32_t L_3;
		L_3 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_2, NULL);
		UnsafeList_1_AddRangeNoResize_mD2A2918E38DFA75F76BF852015F849DAC06AD533(__this, (void*)L_1, L_3, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 21));
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_AddRangeNoResize_m8521348DD738300ECE4F77B891B87A9833DA5A7D_AdjustorThunk (RuntimeObject* __this, UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7 ___0_list, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	UnsafeList_1_AddRangeNoResize_m8521348DD738300ECE4F77B891B87A9833DA5A7D(_thisAdjusted, ___0_list, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_Add_m405283315301E592556E27548D759262F9B0C52F_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* ___0_value, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	bool V_1 = false;
	{
		int32_t L_0 = __this->___m_length;
		V_0 = L_0;
		int32_t L_1 = __this->___m_length;
		int32_t L_2 = __this->___m_capacity;
		V_1 = (bool)((((int32_t)L_1) < ((int32_t)L_2))? 1 : 0);
		bool L_3 = V_1;
		if (!L_3)
		{
			goto IL_0046;
		}
	}
	{
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_4 = __this->___Ptr;
		int32_t L_5 = V_0;
		uint32_t L_6 = sizeof(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127);
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_7 = ___0_value;
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 L_8 = (*(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)L_7);
		*(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)((Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)il2cpp_codegen_add((intptr_t)L_4, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_5), (int32_t)L_6)))) = L_8;
		int32_t L_9 = __this->___m_length;
		__this->___m_length = ((int32_t)il2cpp_codegen_add(L_9, 1));
		goto IL_006c;
	}

IL_0046:
	{
		int32_t L_10 = V_0;
		UnsafeList_1_Resize_mA8E41BF0D06DD764B65618C554B138588019DCA9(__this, ((int32_t)il2cpp_codegen_add(L_10, 1)), (int32_t)0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 3));
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_11 = __this->___Ptr;
		int32_t L_12 = V_0;
		uint32_t L_13 = sizeof(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127);
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_14 = ___0_value;
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 L_15 = (*(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)L_14);
		*(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)((Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)il2cpp_codegen_add((intptr_t)L_11, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_12), (int32_t)L_13)))) = L_15;
	}

IL_006c:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_Add_m405283315301E592556E27548D759262F9B0C52F_AdjustorThunk (RuntimeObject* __this, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* ___0_value, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	UnsafeList_1_Add_m405283315301E592556E27548D759262F9B0C52F_inline(_thisAdjusted, ___0_value, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_AddRange_mFA03E69A70D0F6E2A7A0E1255D4E8A9DD997902A_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, void* ___0_ptr, int32_t ___1_count, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	void* V_2 = NULL;
	bool V_3 = false;
	{
		int32_t L_0 = __this->___m_length;
		V_0 = L_0;
		int32_t L_1 = __this->___m_length;
		int32_t L_2 = ___1_count;
		int32_t L_3;
		L_3 = UnsafeList_1_get_Capacity_m9C10840F54FD1F0871C1C7E25CE7AF92622DF9AD_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_3 = (bool)((((int32_t)((int32_t)il2cpp_codegen_add(L_1, L_2))) > ((int32_t)L_3))? 1 : 0);
		bool L_4 = V_3;
		if (!L_4)
		{
			goto IL_0030;
		}
	}
	{
		int32_t L_5 = __this->___m_length;
		int32_t L_6 = ___1_count;
		UnsafeList_1_Resize_mA8E41BF0D06DD764B65618C554B138588019DCA9(__this, ((int32_t)il2cpp_codegen_add(L_5, L_6)), (int32_t)0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 3));
		goto IL_0040;
	}

IL_0030:
	{
		int32_t L_7 = __this->___m_length;
		int32_t L_8 = ___1_count;
		__this->___m_length = ((int32_t)il2cpp_codegen_add(L_7, L_8));
	}

IL_0040:
	{
		uint32_t L_9 = sizeof(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127);
		V_1 = (int32_t)L_9;
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_10 = __this->___Ptr;
		int32_t L_11 = V_0;
		int32_t L_12 = V_1;
		V_2 = (void*)((Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)il2cpp_codegen_add((intptr_t)L_10, ((int32_t)il2cpp_codegen_multiply(L_11, L_12))));
		void* L_13 = V_2;
		void* L_14 = ___0_ptr;
		int32_t L_15 = ___1_count;
		int32_t L_16 = V_1;
		UnsafeUtility_MemCpy_m5CEA91ACDADC522E584AE3A2AB2B0B74393A9177(L_13, L_14, ((int64_t)((int32_t)il2cpp_codegen_multiply(L_15, L_16))), NULL);
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_AddRange_mFA03E69A70D0F6E2A7A0E1255D4E8A9DD997902A_AdjustorThunk (RuntimeObject* __this, void* ___0_ptr, int32_t ___1_count, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	UnsafeList_1_AddRange_mFA03E69A70D0F6E2A7A0E1255D4E8A9DD997902A(_thisAdjusted, ___0_ptr, ___1_count, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_AddReplicate_m12CE42900BA193AD08AF2BC7899C808C524A6F52_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* ___0_value, int32_t ___1_count, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	bool V_1 = false;
	void* V_2 = NULL;
	Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* V_3 = NULL;
	{
		int32_t L_0 = __this->___m_length;
		V_0 = L_0;
		int32_t L_1 = __this->___m_length;
		int32_t L_2 = ___1_count;
		int32_t L_3;
		L_3 = UnsafeList_1_get_Capacity_m9C10840F54FD1F0871C1C7E25CE7AF92622DF9AD_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_1 = (bool)((((int32_t)((int32_t)il2cpp_codegen_add(L_1, L_2))) > ((int32_t)L_3))? 1 : 0);
		bool L_4 = V_1;
		if (!L_4)
		{
			goto IL_0030;
		}
	}
	{
		int32_t L_5 = __this->___m_length;
		int32_t L_6 = ___1_count;
		UnsafeList_1_Resize_mA8E41BF0D06DD764B65618C554B138588019DCA9(__this, ((int32_t)il2cpp_codegen_add(L_5, L_6)), (int32_t)0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 3));
		goto IL_0040;
	}

IL_0030:
	{
		int32_t L_7 = __this->___m_length;
		int32_t L_8 = ___1_count;
		__this->___m_length = ((int32_t)il2cpp_codegen_add(L_7, L_8));
	}

IL_0040:
	{
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_9 = ___0_value;
		V_3 = L_9;
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_10 = V_3;
		V_2 = (void*)((uintptr_t)L_10);
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_11 = __this->___Ptr;
		int32_t L_12 = V_0;
		uint32_t L_13 = sizeof(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127);
		void* L_14 = V_2;
		int32_t L_15;
		L_15 = UnsafeUtility_SizeOf_TisSlot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127_m9A004D5E211035E85A1BBF1B521142792C4F0A57_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 22));
		int32_t L_16 = ___1_count;
		UnsafeUtility_MemCpyReplicate_m0432429C10859D5BE79799A6E98B44741244287F((void*)((Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)il2cpp_codegen_add((intptr_t)L_11, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_12), (int32_t)L_13)))), L_14, L_15, L_16, NULL);
		V_3 = (Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)((uintptr_t)0);
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_AddReplicate_m12CE42900BA193AD08AF2BC7899C808C524A6F52_AdjustorThunk (RuntimeObject* __this, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* ___0_value, int32_t ___1_count, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	UnsafeList_1_AddReplicate_m12CE42900BA193AD08AF2BC7899C808C524A6F52(_thisAdjusted, ___0_value, ___1_count, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_InsertRangeWithBeginEnd_mC123A52689F34B06EF3678FC2FE08792548531AC_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_begin, int32_t ___1_end, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	bool V_5 = false;
	bool V_6 = false;
	bool V_7 = false;
	uint8_t* V_8 = NULL;
	uint8_t* V_9 = NULL;
	uint8_t* V_10 = NULL;
	{
		int32_t L_0 = ___0_begin;
		int32_t L_1;
		L_1 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_0, NULL);
		___0_begin = L_1;
		int32_t L_2 = ___1_end;
		int32_t L_3;
		L_3 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_2, NULL);
		___1_end = L_3;
		int32_t L_4 = ___1_end;
		int32_t L_5 = ___0_begin;
		V_0 = ((int32_t)il2cpp_codegen_subtract(L_4, L_5));
		int32_t L_6 = V_0;
		V_5 = (bool)((((int32_t)L_6) < ((int32_t)1))? 1 : 0);
		bool L_7 = V_5;
		if (!L_7)
		{
			goto IL_0025;
		}
	}
	{
		goto IL_00aa;
	}

IL_0025:
	{
		int32_t L_8 = __this->___m_length;
		V_1 = L_8;
		int32_t L_9 = __this->___m_length;
		int32_t L_10 = V_0;
		int32_t L_11;
		L_11 = UnsafeList_1_get_Capacity_m9C10840F54FD1F0871C1C7E25CE7AF92622DF9AD_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_6 = (bool)((((int32_t)((int32_t)il2cpp_codegen_add(L_9, L_10))) > ((int32_t)L_11))? 1 : 0);
		bool L_12 = V_6;
		if (!L_12)
		{
			goto IL_0056;
		}
	}
	{
		int32_t L_13 = __this->___m_length;
		int32_t L_14 = V_0;
		UnsafeList_1_Resize_mA8E41BF0D06DD764B65618C554B138588019DCA9(__this, ((int32_t)il2cpp_codegen_add(L_13, L_14)), (int32_t)0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 3));
		goto IL_0066;
	}

IL_0056:
	{
		int32_t L_15 = __this->___m_length;
		int32_t L_16 = V_0;
		__this->___m_length = ((int32_t)il2cpp_codegen_add(L_15, L_16));
	}

IL_0066:
	{
		int32_t L_17 = V_1;
		int32_t L_18 = ___0_begin;
		V_2 = ((int32_t)il2cpp_codegen_subtract(L_17, L_18));
		int32_t L_19 = V_2;
		V_7 = (bool)((((int32_t)L_19) < ((int32_t)1))? 1 : 0);
		bool L_20 = V_7;
		if (!L_20)
		{
			goto IL_0077;
		}
	}
	{
		goto IL_00aa;
	}

IL_0077:
	{
		uint32_t L_21 = sizeof(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127);
		V_3 = (int32_t)L_21;
		int32_t L_22 = V_2;
		int32_t L_23 = V_3;
		V_4 = ((int32_t)il2cpp_codegen_multiply(L_22, L_23));
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_24 = __this->___Ptr;
		V_8 = (uint8_t*)L_24;
		uint8_t* L_25 = V_8;
		int32_t L_26 = ___1_end;
		int32_t L_27 = V_3;
		V_9 = ((uint8_t*)il2cpp_codegen_add((intptr_t)L_25, ((int32_t)il2cpp_codegen_multiply(L_26, L_27))));
		uint8_t* L_28 = V_8;
		int32_t L_29 = ___0_begin;
		int32_t L_30 = V_3;
		V_10 = ((uint8_t*)il2cpp_codegen_add((intptr_t)L_28, ((int32_t)il2cpp_codegen_multiply(L_29, L_30))));
		uint8_t* L_31 = V_9;
		uint8_t* L_32 = V_10;
		int32_t L_33 = V_4;
		UnsafeUtility_MemMove_m4799FAA9C4BCFA1AEDC6ED01BB9A6DF657C4CEE3((void*)L_31, (void*)L_32, ((int64_t)L_33), NULL);
	}

IL_00aa:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_InsertRangeWithBeginEnd_mC123A52689F34B06EF3678FC2FE08792548531AC_AdjustorThunk (RuntimeObject* __this, int32_t ___0_begin, int32_t ___1_end, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	UnsafeList_1_InsertRangeWithBeginEnd_mC123A52689F34B06EF3678FC2FE08792548531AC(_thisAdjusted, ___0_begin, ___1_end, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_RemoveAtSwapBack_mB73019BC253FE72CA0B0757417C73E132680B248_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_index, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* V_1 = NULL;
	Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* V_2 = NULL;
	{
		int32_t L_0 = ___0_index;
		int32_t L_1;
		L_1 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_0, NULL);
		___0_index = L_1;
		int32_t L_2 = __this->___m_length;
		V_0 = ((int32_t)il2cpp_codegen_subtract(L_2, 1));
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_3 = __this->___Ptr;
		int32_t L_4 = ___0_index;
		uint32_t L_5 = sizeof(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127);
		V_1 = ((Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)il2cpp_codegen_add((intptr_t)L_3, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_4), (int32_t)L_5))));
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_6 = __this->___Ptr;
		int32_t L_7 = V_0;
		uint32_t L_8 = sizeof(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127);
		V_2 = ((Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)il2cpp_codegen_add((intptr_t)L_6, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_7), (int32_t)L_8))));
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_9 = V_1;
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_10 = V_2;
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 L_11 = (*(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)L_10);
		*(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)L_9 = L_11;
		int32_t L_12 = __this->___m_length;
		__this->___m_length = ((int32_t)il2cpp_codegen_subtract(L_12, 1));
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_RemoveAtSwapBack_mB73019BC253FE72CA0B0757417C73E132680B248_AdjustorThunk (RuntimeObject* __this, int32_t ___0_index, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	UnsafeList_1_RemoveAtSwapBack_mB73019BC253FE72CA0B0757417C73E132680B248(_thisAdjusted, ___0_index, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_RemoveRangeSwapBack_mAF5F28360809AB7A2E68FBA1D993B6F9C43B3564_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_index, int32_t ___1_count, const RuntimeMethod* method) 
{
	bool V_0 = false;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	void* V_3 = NULL;
	void* V_4 = NULL;
	{
		int32_t L_0 = ___0_index;
		int32_t L_1;
		L_1 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_0, NULL);
		___0_index = L_1;
		int32_t L_2 = ___1_count;
		int32_t L_3;
		L_3 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_2, NULL);
		___1_count = L_3;
		int32_t L_4 = ___1_count;
		V_0 = (bool)((((int32_t)L_4) > ((int32_t)0))? 1 : 0);
		bool L_5 = V_0;
		if (!L_5)
		{
			goto IL_006c;
		}
	}
	{
		int32_t L_6 = __this->___m_length;
		int32_t L_7 = ___1_count;
		int32_t L_8 = ___0_index;
		int32_t L_9 = ___1_count;
		int32_t L_10;
		L_10 = math_max_m9083201D37A8ED0157B127B5878D9B7F3A2A40BE_inline(((int32_t)il2cpp_codegen_subtract(L_6, L_7)), ((int32_t)il2cpp_codegen_add(L_8, L_9)), NULL);
		V_1 = L_10;
		uint32_t L_11 = sizeof(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127);
		V_2 = (int32_t)L_11;
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_12 = __this->___Ptr;
		int32_t L_13 = ___0_index;
		int32_t L_14 = V_2;
		V_3 = (void*)((Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)il2cpp_codegen_add((intptr_t)L_12, ((int32_t)il2cpp_codegen_multiply(L_13, L_14))));
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_15 = __this->___Ptr;
		int32_t L_16 = V_1;
		int32_t L_17 = V_2;
		V_4 = (void*)((Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)il2cpp_codegen_add((intptr_t)L_15, ((int32_t)il2cpp_codegen_multiply(L_16, L_17))));
		void* L_18 = V_3;
		void* L_19 = V_4;
		int32_t L_20 = __this->___m_length;
		int32_t L_21 = V_1;
		int32_t L_22 = V_2;
		UnsafeUtility_MemCpy_m5CEA91ACDADC522E584AE3A2AB2B0B74393A9177(L_18, L_19, ((int64_t)((int32_t)il2cpp_codegen_multiply(((int32_t)il2cpp_codegen_subtract(L_20, L_21)), L_22))), NULL);
		int32_t L_23 = __this->___m_length;
		int32_t L_24 = ___1_count;
		__this->___m_length = ((int32_t)il2cpp_codegen_subtract(L_23, L_24));
	}

IL_006c:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_RemoveRangeSwapBack_mAF5F28360809AB7A2E68FBA1D993B6F9C43B3564_AdjustorThunk (RuntimeObject* __this, int32_t ___0_index, int32_t ___1_count, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	UnsafeList_1_RemoveRangeSwapBack_mAF5F28360809AB7A2E68FBA1D993B6F9C43B3564(_thisAdjusted, ___0_index, ___1_count, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_RemoveAt_m7E96DC2F31FA5485A37D45BA007E1FC8043D4CF2_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_index, const RuntimeMethod* method) 
{
	Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* V_0 = NULL;
	Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* V_1 = NULL;
	int32_t V_2 = 0;
	Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* V_3 = NULL;
	bool V_4 = false;
	{
		int32_t L_0 = ___0_index;
		int32_t L_1;
		L_1 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_0, NULL);
		___0_index = L_1;
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_2 = __this->___Ptr;
		int32_t L_3 = ___0_index;
		uint32_t L_4 = sizeof(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127);
		V_0 = ((Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)il2cpp_codegen_add((intptr_t)L_2, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_3), (int32_t)L_4))));
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_5 = V_0;
		uint32_t L_6 = sizeof(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127);
		V_1 = ((Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)il2cpp_codegen_add((intptr_t)L_5, (int32_t)L_6));
		int32_t L_7 = __this->___m_length;
		__this->___m_length = ((int32_t)il2cpp_codegen_subtract(L_7, 1));
		int32_t L_8 = ___0_index;
		V_2 = L_8;
		goto IL_005d;
	}

IL_0035:
	{
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_9 = V_0;
		V_3 = L_9;
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_10 = V_3;
		uint32_t L_11 = sizeof(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127);
		V_0 = ((Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)il2cpp_codegen_add((intptr_t)L_10, (int32_t)L_11));
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_12 = V_3;
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_13 = V_1;
		V_3 = L_13;
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_14 = V_3;
		uint32_t L_15 = sizeof(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127);
		V_1 = ((Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)il2cpp_codegen_add((intptr_t)L_14, (int32_t)L_15));
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_16 = V_3;
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 L_17 = (*(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)L_16);
		*(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)L_12 = L_17;
		int32_t L_18 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_18, 1));
	}

IL_005d:
	{
		int32_t L_19 = V_2;
		int32_t L_20 = __this->___m_length;
		V_4 = (bool)((((int32_t)L_19) < ((int32_t)L_20))? 1 : 0);
		bool L_21 = V_4;
		if (L_21)
		{
			goto IL_0035;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_RemoveAt_m7E96DC2F31FA5485A37D45BA007E1FC8043D4CF2_AdjustorThunk (RuntimeObject* __this, int32_t ___0_index, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	UnsafeList_1_RemoveAt_m7E96DC2F31FA5485A37D45BA007E1FC8043D4CF2(_thisAdjusted, ___0_index, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_RemoveRange_mB4B17E74CEE3C443B6749D3A3B52FC9598401C46_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_index, int32_t ___1_count, const RuntimeMethod* method) 
{
	bool V_0 = false;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	void* V_3 = NULL;
	void* V_4 = NULL;
	{
		int32_t L_0 = ___0_index;
		int32_t L_1;
		L_1 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_0, NULL);
		___0_index = L_1;
		int32_t L_2 = ___1_count;
		int32_t L_3;
		L_3 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_2, NULL);
		___1_count = L_3;
		int32_t L_4 = ___1_count;
		V_0 = (bool)((((int32_t)L_4) > ((int32_t)0))? 1 : 0);
		bool L_5 = V_0;
		if (!L_5)
		{
			goto IL_006a;
		}
	}
	{
		int32_t L_6 = ___0_index;
		int32_t L_7 = ___1_count;
		int32_t L_8 = __this->___m_length;
		int32_t L_9;
		L_9 = math_min_m02D43DF516544C279AF660EA4731449C82991849_inline(((int32_t)il2cpp_codegen_add(L_6, L_7)), L_8, NULL);
		V_1 = L_9;
		uint32_t L_10 = sizeof(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127);
		V_2 = (int32_t)L_10;
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_11 = __this->___Ptr;
		int32_t L_12 = ___0_index;
		int32_t L_13 = V_2;
		V_3 = (void*)((Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)il2cpp_codegen_add((intptr_t)L_11, ((int32_t)il2cpp_codegen_multiply(L_12, L_13))));
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_14 = __this->___Ptr;
		int32_t L_15 = V_1;
		int32_t L_16 = V_2;
		V_4 = (void*)((Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)il2cpp_codegen_add((intptr_t)L_14, ((int32_t)il2cpp_codegen_multiply(L_15, L_16))));
		void* L_17 = V_3;
		void* L_18 = V_4;
		int32_t L_19 = __this->___m_length;
		int32_t L_20 = V_1;
		int32_t L_21 = V_2;
		UnsafeUtility_MemCpy_m5CEA91ACDADC522E584AE3A2AB2B0B74393A9177(L_17, L_18, ((int64_t)((int32_t)il2cpp_codegen_multiply(((int32_t)il2cpp_codegen_subtract(L_19, L_20)), L_21))), NULL);
		int32_t L_22 = __this->___m_length;
		int32_t L_23 = ___1_count;
		__this->___m_length = ((int32_t)il2cpp_codegen_subtract(L_22, L_23));
	}

IL_006a:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_RemoveRange_mB4B17E74CEE3C443B6749D3A3B52FC9598401C46_AdjustorThunk (RuntimeObject* __this, int32_t ___0_index, int32_t ___1_count, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	UnsafeList_1_RemoveRange_mB4B17E74CEE3C443B6749D3A3B52FC9598401C46(_thisAdjusted, ___0_index, ___1_count, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_CopyFrom_mF6E6FAF3CEEB14EF5B4177580034AFDA1CD1A33A_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, NativeArray_1_tB8D8B86A987B7E27BD621893A826604AA3A66C5C* ___0_other, const RuntimeMethod* method) 
{
	NativeArray_1_tB8D8B86A987B7E27BD621893A826604AA3A66C5C V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		NativeArray_1_tB8D8B86A987B7E27BD621893A826604AA3A66C5C* L_0 = ___0_other;
		NativeArray_1_tB8D8B86A987B7E27BD621893A826604AA3A66C5C L_1 = (*(NativeArray_1_tB8D8B86A987B7E27BD621893A826604AA3A66C5C*)L_0);
		V_0 = L_1;
		int32_t L_2;
		L_2 = IL2CPP_NATIVEARRAY_GET_LENGTH(((&V_0))->___m_Length);
		UnsafeList_1_Resize_mA8E41BF0D06DD764B65618C554B138588019DCA9(__this, L_2, (int32_t)0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 3));
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_3 = __this->___Ptr;
		NativeArray_1_tB8D8B86A987B7E27BD621893A826604AA3A66C5C* L_4 = ___0_other;
		NativeArray_1_tB8D8B86A987B7E27BD621893A826604AA3A66C5C L_5 = (*(NativeArray_1_tB8D8B86A987B7E27BD621893A826604AA3A66C5C*)L_4);
		void* L_6;
		L_6 = NativeArrayUnsafeUtility_GetUnsafeReadOnlyPtr_TisSlot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127_m33C547D554717D3EAFA0EDFB786DE05EA69EAA85(L_5, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 28));
		int32_t L_7;
		L_7 = UnsafeUtility_SizeOf_TisSlot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127_m9A004D5E211035E85A1BBF1B521142792C4F0A57_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 22));
		NativeArray_1_tB8D8B86A987B7E27BD621893A826604AA3A66C5C* L_8 = ___0_other;
		NativeArray_1_tB8D8B86A987B7E27BD621893A826604AA3A66C5C L_9 = (*(NativeArray_1_tB8D8B86A987B7E27BD621893A826604AA3A66C5C*)L_8);
		V_0 = L_9;
		int32_t L_10;
		L_10 = IL2CPP_NATIVEARRAY_GET_LENGTH(((&V_0))->___m_Length);
		UnsafeUtility_MemCpy_m5CEA91ACDADC522E584AE3A2AB2B0B74393A9177((void*)L_3, L_6, ((int64_t)((int32_t)il2cpp_codegen_multiply(L_7, L_10))), NULL);
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_CopyFrom_mF6E6FAF3CEEB14EF5B4177580034AFDA1CD1A33A_AdjustorThunk (RuntimeObject* __this, NativeArray_1_tB8D8B86A987B7E27BD621893A826604AA3A66C5C* ___0_other, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	UnsafeList_1_CopyFrom_mF6E6FAF3CEEB14EF5B4177580034AFDA1CD1A33A(_thisAdjusted, ___0_other, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeList_1_CopyFrom_m5C64DE802A570C7DCECE59B4859091A58686F23A_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* ___0_other, const RuntimeMethod* method) 
{
	{
		UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* L_0 = ___0_other;
		int32_t L_1;
		L_1 = UnsafeList_1_get_Length_mFE9C02C4C7169AE23DE6BC1B834E0DBC1D03DBB1_inline(L_0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 20));
		UnsafeList_1_Resize_mA8E41BF0D06DD764B65618C554B138588019DCA9(__this, L_1, (int32_t)0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 3));
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_2 = __this->___Ptr;
		UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* L_3 = ___0_other;
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_4 = L_3->___Ptr;
		int32_t L_5;
		L_5 = UnsafeUtility_SizeOf_TisSlot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127_m9A004D5E211035E85A1BBF1B521142792C4F0A57_inline(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 22));
		UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* L_6 = ___0_other;
		int32_t L_7;
		L_7 = UnsafeList_1_get_Length_mFE9C02C4C7169AE23DE6BC1B834E0DBC1D03DBB1_inline(L_6, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 20));
		UnsafeUtility_MemCpy_m5CEA91ACDADC522E584AE3A2AB2B0B74393A9177((void*)L_2, (void*)L_4, ((int64_t)((int32_t)il2cpp_codegen_multiply(L_5, L_7))), NULL);
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeList_1_CopyFrom_m5C64DE802A570C7DCECE59B4859091A58686F23A_AdjustorThunk (RuntimeObject* __this, UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* ___0_other, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	UnsafeList_1_CopyFrom_m5C64DE802A570C7DCECE59B4859091A58686F23A(_thisAdjusted, ___0_other, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* UnsafeList_1_System_Collections_IEnumerable_GetEnumerator_mBE9931F96650CD707D42AE0625B0B34CD2CA9307_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method) 
{
	{
		NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8* L_0 = (NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8_il2cpp_TypeInfo_var)));
		NotImplementedException__ctor_mDAB47BC6BD0E342E8F2171E5CABE3E67EA049F1C(L_0, NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_0, method);
	}
}
IL2CPP_EXTERN_C  RuntimeObject* UnsafeList_1_System_Collections_IEnumerable_GetEnumerator_mBE9931F96650CD707D42AE0625B0B34CD2CA9307_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	RuntimeObject* _returnValue;
	_returnValue = UnsafeList_1_System_Collections_IEnumerable_GetEnumerator_mBE9931F96650CD707D42AE0625B0B34CD2CA9307(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* UnsafeList_1_System_Collections_Generic_IEnumerableU3CTU3E_GetEnumerator_m6576E2C347279C70D752C163781D0115578818BB_gshared (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method) 
{
	{
		NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8* L_0 = (NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8_il2cpp_TypeInfo_var)));
		NotImplementedException__ctor_mDAB47BC6BD0E342E8F2171E5CABE3E67EA049F1C(L_0, NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_0, method);
	}
}
IL2CPP_EXTERN_C  RuntimeObject* UnsafeList_1_System_Collections_Generic_IEnumerableU3CTU3E_GetEnumerator_m6576E2C347279C70D752C163781D0115578818BB_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7*>(__this + _offset);
	RuntimeObject* _returnValue;
	_returnValue = UnsafeList_1_System_Collections_Generic_IEnumerableU3CTU3E_GetEnumerator_m6576E2C347279C70D752C163781D0115578818BB(_thisAdjusted, method);
	return _returnValue;
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_Clear_mEFDB8CAFDB397D0E8A4279CA11C361A29EC8A4BB_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	bool V_2 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___buckets;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		NullCheck(L_2);
		int32_t L_3 = L_2->___bucketCapacityMask;
		UnsafeUtility_MemSet_m4CD74CD43260EB2962A46F57E0D93DD5C332FC2B((void*)L_1, (uint8_t)((int32_t)255), ((int64_t)((int32_t)il2cpp_codegen_multiply(((int32_t)il2cpp_codegen_add(L_3, 1)), 4))), NULL);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = ___0_data;
		NullCheck(L_4);
		uint8_t* L_5 = L_4->___next;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_6 = ___0_data;
		NullCheck(L_6);
		int32_t L_7 = L_6->___keyCapacity;
		UnsafeUtility_MemSet_m4CD74CD43260EB2962A46F57E0D93DD5C332FC2B((void*)L_5, (uint8_t)((int32_t)255), ((int64_t)((int32_t)il2cpp_codegen_multiply(L_7, 4))), NULL);
		int32_t L_8;
		L_8 = JobsUtility_get_ThreadIndexCount_m88A954344398143540618B35943F863B92465676(NULL);
		V_0 = L_8;
		V_1 = 0;
		goto IL_0057;
	}

IL_0041:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_9 = ___0_data;
		int32_t* L_10;
		L_10 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_9, NULL);
		int32_t L_11 = V_1;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_10, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_11, ((int32_t)16)))), 4))))) = (int32_t)(-1);
		int32_t L_12 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_12, 1));
	}

IL_0057:
	{
		int32_t L_13 = V_1;
		int32_t L_14 = V_0;
		V_2 = (bool)((((int32_t)L_13) < ((int32_t)L_14))? 1 : 0);
		bool L_15 = V_2;
		if (L_15)
		{
			goto IL_0041;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_16 = ___0_data;
		NullCheck(L_16);
		L_16->___allocatedIndexLength = 0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapBase_2_AllocEntry_m6564DDE54C96DB6027C802DDB51638722A8B7A9C_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_threadIndex, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t* V_1 = NULL;
	bool V_2 = false;
	bool V_3 = false;
	int32_t V_4 = 0;
	bool V_5 = false;
	bool V_6 = false;
	bool V_7 = false;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	bool V_10 = false;
	int32_t V_11 = 0;
	bool V_12 = false;
	int32_t V_13 = 0;
	bool V_14 = false;
	bool V_15 = false;
	bool V_16 = false;
	bool V_17 = false;
	bool V_18 = false;
	bool V_19 = false;
	bool V_20 = false;
	bool V_21 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___next;
		V_1 = (int32_t*)L_1;
	}

IL_0008:
	{
	}

IL_0009:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		int32_t* L_3;
		L_3 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_2, NULL);
		int32_t L_4 = ___1_threadIndex;
		int32_t L_5;
		L_5 = VolatileRead((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_3, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_4, ((int32_t)16)))), 4)))));
		V_0 = L_5;
		int32_t L_6 = V_0;
		V_2 = (bool)((((int32_t)L_6) == ((int32_t)((int32_t)-3)))? 1 : 0);
		bool L_7 = V_2;
		if (L_7)
		{
			goto IL_0009;
		}
	}
	{
		int32_t L_8 = V_0;
		V_3 = (bool)((((int32_t)L_8) < ((int32_t)0))? 1 : 0);
		bool L_9 = V_3;
		if (!L_9)
		{
			goto IL_021e;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_10 = ___0_data;
		int32_t* L_11;
		L_11 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_10, NULL);
		int32_t L_12 = ___1_threadIndex;
		int32_t L_13;
		L_13 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_11, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_12, ((int32_t)16)))), 4)))), ((int32_t)-2), NULL);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_14 = ___0_data;
		NullCheck(L_14);
		int32_t L_15 = L_14->___allocatedIndexLength;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_16 = ___0_data;
		NullCheck(L_16);
		int32_t L_17 = L_16->___keyCapacity;
		V_6 = (bool)((((int32_t)L_15) < ((int32_t)L_17))? 1 : 0);
		bool L_18 = V_6;
		if (!L_18)
		{
			goto IL_0123;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_19 = ___0_data;
		NullCheck(L_19);
		int32_t* L_20 = (int32_t*)(&L_19->___allocatedIndexLength);
		int32_t L_21;
		L_21 = Interlocked_Add_m2455208C56EEFD8832AEAD8AF7368A3FEB33A73C(L_20, ((int32_t)16), NULL);
		V_0 = ((int32_t)il2cpp_codegen_subtract(L_21, ((int32_t)16)));
		int32_t L_22 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_23 = ___0_data;
		NullCheck(L_23);
		int32_t L_24 = L_23->___keyCapacity;
		V_7 = (bool)((((int32_t)L_22) < ((int32_t)((int32_t)il2cpp_codegen_subtract(L_24, 1))))? 1 : 0);
		bool L_25 = V_7;
		if (!L_25)
		{
			goto IL_00f3;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_26 = ___0_data;
		NullCheck(L_26);
		int32_t L_27 = L_26->___keyCapacity;
		int32_t L_28 = V_0;
		int32_t L_29;
		L_29 = math_min_m02D43DF516544C279AF660EA4731449C82991849_inline(((int32_t)16), ((int32_t)il2cpp_codegen_subtract(L_27, L_28)), NULL);
		V_8 = L_29;
		V_9 = 1;
		goto IL_00b3;
	}

IL_009b:
	{
		int32_t* L_30 = V_1;
		int32_t L_31 = V_0;
		int32_t L_32 = V_9;
		int32_t L_33 = V_0;
		int32_t L_34 = V_9;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_30, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_add(L_31, L_32))), 4))))) = (int32_t)((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_33, L_34)), 1));
		int32_t L_35 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add(L_35, 1));
	}

IL_00b3:
	{
		int32_t L_36 = V_9;
		int32_t L_37 = V_8;
		V_10 = (bool)((((int32_t)L_36) < ((int32_t)L_37))? 1 : 0);
		bool L_38 = V_10;
		if (L_38)
		{
			goto IL_009b;
		}
	}
	{
		int32_t* L_39 = V_1;
		int32_t L_40 = V_0;
		int32_t L_41 = V_8;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_39, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_40, L_41)), 1))), 4))))) = (int32_t)(-1);
		int32_t* L_42 = V_1;
		int32_t L_43 = V_0;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_42, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_43), 4))))) = (int32_t)(-1);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_44 = ___0_data;
		int32_t* L_45;
		L_45 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_44, NULL);
		int32_t L_46 = ___1_threadIndex;
		int32_t L_47 = V_0;
		int32_t L_48;
		L_48 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_45, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_46, ((int32_t)16)))), 4)))), ((int32_t)il2cpp_codegen_add(L_47, 1)), NULL);
		int32_t L_49 = V_0;
		V_11 = L_49;
		goto IL_026c;
	}

IL_00f3:
	{
		int32_t L_50 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_51 = ___0_data;
		NullCheck(L_51);
		int32_t L_52 = L_51->___keyCapacity;
		V_12 = (bool)((((int32_t)L_50) == ((int32_t)((int32_t)il2cpp_codegen_subtract(L_52, 1))))? 1 : 0);
		bool L_53 = V_12;
		if (!L_53)
		{
			goto IL_0122;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_54 = ___0_data;
		int32_t* L_55;
		L_55 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_54, NULL);
		int32_t L_56 = ___1_threadIndex;
		int32_t L_57;
		L_57 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_55, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_56, ((int32_t)16)))), 4)))), (-1), NULL);
		int32_t L_58 = V_0;
		V_11 = L_58;
		goto IL_026c;
	}

IL_0122:
	{
	}

IL_0123:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_59 = ___0_data;
		int32_t* L_60;
		L_60 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_59, NULL);
		int32_t L_61 = ___1_threadIndex;
		int32_t L_62;
		L_62 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_60, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_61, ((int32_t)16)))), 4)))), (-1), NULL);
		int32_t L_63;
		L_63 = JobsUtility_get_ThreadIndexCount_m88A954344398143540618B35943F863B92465676(NULL);
		V_4 = L_63;
		V_5 = (bool)1;
		goto IL_0212;
	}

IL_0147:
	{
		V_5 = (bool)0;
		int32_t L_64 = ___1_threadIndex;
		int32_t L_65 = V_4;
		V_13 = ((int32_t)(((int32_t)il2cpp_codegen_add(L_64, 1))%L_65));
		goto IL_0200;
	}

IL_0158:
	{
	}

IL_0159:
	{
	}

IL_015a:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_66 = ___0_data;
		int32_t* L_67;
		L_67 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_66, NULL);
		int32_t L_68 = V_13;
		int32_t L_69;
		L_69 = VolatileRead((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_67, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_68, ((int32_t)16)))), 4)))));
		V_0 = L_69;
		int32_t L_70 = V_0;
		V_14 = (bool)((((int32_t)L_70) == ((int32_t)((int32_t)-3)))? 1 : 0);
		bool L_71 = V_14;
		if (L_71)
		{
			goto IL_015a;
		}
	}
	{
		int32_t L_72 = V_0;
		V_15 = (bool)((((int32_t)L_72) < ((int32_t)0))? 1 : 0);
		bool L_73 = V_15;
		if (!L_73)
		{
			goto IL_0189;
		}
	}
	{
		goto IL_01ad;
	}

IL_0189:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_74 = ___0_data;
		int32_t* L_75;
		L_75 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_74, NULL);
		int32_t L_76 = V_13;
		int32_t L_77 = V_0;
		int32_t L_78;
		L_78 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_75, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_76, ((int32_t)16)))), 4)))), ((int32_t)-3), L_77, NULL);
		int32_t L_79 = V_0;
		V_16 = (bool)((((int32_t)((((int32_t)L_78) == ((int32_t)L_79))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_80 = V_16;
		if (L_80)
		{
			goto IL_0159;
		}
	}

IL_01ad:
	{
		int32_t L_81 = V_0;
		V_17 = (bool)((((int32_t)L_81) == ((int32_t)((int32_t)-2)))? 1 : 0);
		bool L_82 = V_17;
		if (!L_82)
		{
			goto IL_01bf;
		}
	}
	{
		V_5 = (bool)1;
		goto IL_01f6;
	}

IL_01bf:
	{
		int32_t L_83 = V_0;
		V_18 = (bool)((((int32_t)((((int32_t)L_83) < ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_84 = V_18;
		if (!L_84)
		{
			goto IL_01f6;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_85 = ___0_data;
		int32_t* L_86;
		L_86 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_85, NULL);
		int32_t L_87 = V_13;
		int32_t* L_88 = V_1;
		int32_t L_89 = V_0;
		int32_t L_90 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_88, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_89), 4))))));
		int32_t L_91;
		L_91 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_86, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_87, ((int32_t)16)))), 4)))), L_90, NULL);
		int32_t* L_92 = V_1;
		int32_t L_93 = V_0;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_92, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_93), 4))))) = (int32_t)(-1);
		int32_t L_94 = V_0;
		V_11 = L_94;
		goto IL_026c;
	}

IL_01f6:
	{
		int32_t L_95 = V_13;
		int32_t L_96 = V_4;
		V_13 = ((int32_t)(((int32_t)il2cpp_codegen_add(L_95, 1))%L_96));
	}

IL_0200:
	{
		int32_t L_97 = V_13;
		int32_t L_98 = ___1_threadIndex;
		V_19 = (bool)((((int32_t)((((int32_t)L_97) == ((int32_t)L_98))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_99 = V_19;
		if (L_99)
		{
			goto IL_0158;
		}
	}
	{
	}

IL_0212:
	{
		bool L_100 = V_5;
		V_20 = L_100;
		bool L_101 = V_20;
		if (L_101)
		{
			goto IL_0147;
		}
	}
	{
	}

IL_021e:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_102 = ___0_data;
		int32_t* L_103;
		L_103 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_102, NULL);
		int32_t L_104 = ___1_threadIndex;
		int32_t L_105 = V_0;
		int32_t L_106;
		L_106 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_103, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_104, ((int32_t)16)))), 4)))), ((int32_t)-3), L_105, NULL);
		int32_t L_107 = V_0;
		V_21 = (bool)((((int32_t)((((int32_t)L_106) == ((int32_t)L_107))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_108 = V_21;
		if (L_108)
		{
			goto IL_0008;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_109 = ___0_data;
		int32_t* L_110;
		L_110 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_109, NULL);
		int32_t L_111 = ___1_threadIndex;
		int32_t* L_112 = V_1;
		int32_t L_113 = V_0;
		int32_t L_114 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_112, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_113), 4))))));
		int32_t L_115;
		L_115 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_110, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_111, ((int32_t)16)))), 4)))), L_114, NULL);
		int32_t* L_116 = V_1;
		int32_t L_117 = V_0;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_116, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_117), 4))))) = (int32_t)(-1);
		int32_t L_118 = V_0;
		V_11 = L_118;
		goto IL_026c;
	}

IL_026c:
	{
		int32_t L_119 = V_11;
		return L_119;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_FreeEntry_mE62A9F90862B9AF9BF01C07B0A17F0C8F2372D6D_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_idx, int32_t ___2_threadIndex, const RuntimeMethod* method) 
{
	int32_t* V_0 = NULL;
	int32_t V_1 = 0;
	bool V_2 = false;
	bool V_3 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___next;
		V_0 = (int32_t*)L_1;
		V_1 = (-1);
	}

IL_000a:
	{
	}

IL_000b:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		int32_t* L_3;
		L_3 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_2, NULL);
		int32_t L_4 = ___2_threadIndex;
		int32_t L_5;
		L_5 = VolatileRead((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_3, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_4, ((int32_t)16)))), 4)))));
		V_1 = L_5;
		int32_t L_6 = V_1;
		V_2 = (bool)((((int32_t)L_6) == ((int32_t)((int32_t)-3)))? 1 : 0);
		bool L_7 = V_2;
		if (L_7)
		{
			goto IL_000b;
		}
	}
	{
		int32_t* L_8 = V_0;
		int32_t L_9 = ___1_idx;
		int32_t L_10 = V_1;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_8, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_9), 4))))) = (int32_t)L_10;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_11 = ___0_data;
		int32_t* L_12;
		L_12 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_11, NULL);
		int32_t L_13 = ___2_threadIndex;
		int32_t L_14 = ___1_idx;
		int32_t L_15 = V_1;
		int32_t L_16;
		L_16 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_12, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_13, ((int32_t)16)))), 4)))), L_14, L_15, NULL);
		int32_t L_17 = V_1;
		V_3 = (bool)((((int32_t)((((int32_t)L_16) == ((int32_t)L_17))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_18 = V_3;
		if (L_18)
		{
			goto IL_000a;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryAddAtomic_m8D9EB95A581DE583866F77875CFEBA2DA8CAC3E5_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___1_key, int32_t ___2_item, int32_t ___3_threadIndex, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A V_1;
	memset((&V_1), 0, sizeof(V_1));
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	int32_t* V_4 = NULL;
	bool V_5 = false;
	bool V_6 = false;
	bool V_7 = false;
	int32_t* V_8 = NULL;
	int32_t V_9 = 0;
	bool V_10 = false;
	bool V_11 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 L_1 = ___1_key;
		bool L_2;
		L_2 = UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mC42AE53B9C096C5437713AA40D89EB873678D78F(L_0, L_1, (&V_0), (&V_1), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_5 = L_2;
		bool L_3 = V_5;
		if (!L_3)
		{
			goto IL_001b;
		}
	}
	{
		V_6 = (bool)0;
		goto IL_00da;
	}

IL_001b:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = ___0_data;
		int32_t L_5 = ___3_threadIndex;
		int32_t L_6;
		L_6 = UnsafeParallelHashMapBase_2_AllocEntry_m6564DDE54C96DB6027C802DDB51638722A8B7A9C(L_4, L_5, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		V_2 = L_6;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		uint8_t* L_8 = L_7->___keys;
		int32_t L_9 = V_2;
		DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 L_10 = ___1_key;
		UnsafeUtility_WriteArrayElement_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_mAC61BCD78DBCF3665AB62CF3F0A9160131582E7C_inline((void*)L_8, L_9, L_10, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 6));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_11 = ___0_data;
		NullCheck(L_11);
		uint8_t* L_12 = L_11->___values;
		int32_t L_13 = V_2;
		int32_t L_14 = ___2_item;
		UnsafeUtility_WriteArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m0DD1CC90B2F1EF5041F2F4E1DABB58224229F0D7_inline((void*)L_12, L_13, L_14, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		int32_t L_15;
		L_15 = DrawKey_GetHashCode_m6E3C5F3D42D02D8035AA7E7B5501FDBC1551F4E5((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_16 = ___0_data;
		NullCheck(L_16);
		int32_t L_17 = L_16->___bucketCapacityMask;
		V_3 = ((int32_t)(L_15&L_17));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_18 = ___0_data;
		NullCheck(L_18);
		uint8_t* L_19 = L_18->___buckets;
		V_4 = (int32_t*)L_19;
		int32_t* L_20 = V_4;
		int32_t L_21 = V_3;
		int32_t L_22 = V_2;
		int32_t L_23;
		L_23 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_20, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_21), 4)))), L_22, (-1), NULL);
		V_7 = (bool)((((int32_t)((((int32_t)L_23) == ((int32_t)(-1)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_24 = V_7;
		if (!L_24)
		{
			goto IL_00d5;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_25 = ___0_data;
		NullCheck(L_25);
		uint8_t* L_26 = L_25->___next;
		V_8 = (int32_t*)L_26;
		V_9 = (-1);
	}

IL_0082:
	{
		int32_t* L_27 = V_4;
		int32_t L_28 = V_3;
		int32_t L_29 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_27, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_28), 4))))));
		V_9 = L_29;
		int32_t* L_30 = V_8;
		int32_t L_31 = V_2;
		int32_t L_32 = V_9;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_30, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_31), 4))))) = (int32_t)L_32;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_33 = ___0_data;
		DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 L_34 = ___1_key;
		bool L_35;
		L_35 = UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mC42AE53B9C096C5437713AA40D89EB873678D78F(L_33, L_34, (&V_0), (&V_1), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_10 = L_35;
		bool L_36 = V_10;
		if (!L_36)
		{
			goto IL_00b7;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_37 = ___0_data;
		int32_t L_38 = V_2;
		int32_t L_39 = ___3_threadIndex;
		UnsafeParallelHashMapBase_2_FreeEntry_mE62A9F90862B9AF9BF01C07B0A17F0C8F2372D6D(L_37, L_38, L_39, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 10));
		V_6 = (bool)0;
		goto IL_00da;
	}

IL_00b7:
	{
		int32_t* L_40 = V_4;
		int32_t L_41 = V_3;
		int32_t L_42 = V_2;
		int32_t L_43 = V_9;
		int32_t L_44;
		L_44 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_40, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_41), 4)))), L_42, L_43, NULL);
		int32_t L_45 = V_9;
		V_11 = (bool)((((int32_t)((((int32_t)L_44) == ((int32_t)L_45))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_46 = V_11;
		if (L_46)
		{
			goto IL_0082;
		}
	}
	{
	}

IL_00d5:
	{
		V_6 = (bool)1;
		goto IL_00da;
	}

IL_00da:
	{
		bool L_47 = V_6;
		return L_47;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryAdd_m7575B5C2D0CB741CCB79BFF102B543F951D1A91A_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___1_key, int32_t ___2_item, bool ___3_isMultiHashMap, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___4_allocation, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A V_1;
	memset((&V_1), 0, sizeof(V_1));
	bool V_2 = false;
	int32_t V_3 = 0;
	int32_t* V_4 = NULL;
	int32_t V_5 = 0;
	int32_t* V_6 = NULL;
	bool V_7 = false;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	bool V_10 = false;
	bool V_11 = false;
	bool V_12 = false;
	int32_t V_13 = 0;
	bool V_14 = false;
	int32_t V_15 = 0;
	bool V_16 = false;
	int32_t G_B3_0 = 0;
	int32_t G_B7_0 = 0;
	{
		bool L_0 = ___3_isMultiHashMap;
		if (L_0)
		{
			goto IL_0014;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_1 = ___0_data;
		DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 L_2 = ___1_key;
		bool L_3;
		L_3 = UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mC42AE53B9C096C5437713AA40D89EB873678D78F(L_1, L_2, (&V_0), (&V_1), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		G_B3_0 = ((((int32_t)L_3) == ((int32_t)0))? 1 : 0);
		goto IL_0015;
	}

IL_0014:
	{
		G_B3_0 = 1;
	}

IL_0015:
	{
		V_2 = (bool)G_B3_0;
		bool L_4 = V_2;
		if (!L_4)
		{
			goto IL_0197;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_5 = ___0_data;
		NullCheck(L_5);
		int32_t L_6 = L_5->___allocatedIndexLength;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		int32_t L_8 = L_7->___keyCapacity;
		if ((((int32_t)L_6) < ((int32_t)L_8)))
		{
			goto IL_0037;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_9 = ___0_data;
		int32_t* L_10;
		L_10 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_9, NULL);
		int32_t L_11 = (*(L_10));
		G_B7_0 = ((((int32_t)L_11) < ((int32_t)0))? 1 : 0);
		goto IL_0038;
	}

IL_0037:
	{
		G_B7_0 = 0;
	}

IL_0038:
	{
		V_7 = (bool)G_B7_0;
		bool L_12 = V_7;
		if (!L_12)
		{
			goto IL_00f5;
		}
	}
	{
		int32_t L_13;
		L_13 = JobsUtility_get_ThreadIndexCount_m88A954344398143540618B35943F863B92465676(NULL);
		V_8 = L_13;
		V_9 = 1;
		goto IL_00b7;
	}

IL_004e:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_14 = ___0_data;
		int32_t* L_15;
		L_15 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_14, NULL);
		int32_t L_16 = V_9;
		int32_t L_17 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_15, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_16, ((int32_t)16)))), 4))))));
		V_10 = (bool)((((int32_t)((((int32_t)L_17) < ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_18 = V_10;
		if (!L_18)
		{
			goto IL_00b0;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_19 = ___0_data;
		int32_t* L_20;
		L_20 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_19, NULL);
		int32_t L_21 = V_9;
		int32_t L_22 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_20, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_21, ((int32_t)16)))), 4))))));
		V_3 = L_22;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_23 = ___0_data;
		NullCheck(L_23);
		uint8_t* L_24 = L_23->___next;
		V_4 = (int32_t*)L_24;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_25 = ___0_data;
		int32_t* L_26;
		L_26 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_25, NULL);
		int32_t L_27 = V_9;
		int32_t* L_28 = V_4;
		int32_t L_29 = V_3;
		int32_t L_30 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_28, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_29), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_26, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_27, ((int32_t)16)))), 4))))) = (int32_t)L_30;
		int32_t* L_31 = V_4;
		int32_t L_32 = V_3;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_31, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_32), 4))))) = (int32_t)(-1);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_33 = ___0_data;
		int32_t* L_34;
		L_34 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_33, NULL);
		int32_t L_35 = V_3;
		*((int32_t*)L_34) = (int32_t)L_35;
		goto IL_00c3;
	}

IL_00b0:
	{
		int32_t L_36 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add(L_36, 1));
	}

IL_00b7:
	{
		int32_t L_37 = V_9;
		int32_t L_38 = V_8;
		V_11 = (bool)((((int32_t)L_37) < ((int32_t)L_38))? 1 : 0);
		bool L_39 = V_11;
		if (L_39)
		{
			goto IL_004e;
		}
	}

IL_00c3:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_40 = ___0_data;
		int32_t* L_41;
		L_41 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_40, NULL);
		int32_t L_42 = (*(L_41));
		V_12 = (bool)((((int32_t)L_42) < ((int32_t)0))? 1 : 0);
		bool L_43 = V_12;
		if (!L_43)
		{
			goto IL_00f4;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_44 = ___0_data;
		NullCheck(L_44);
		int32_t L_45 = L_44->___keyCapacity;
		int32_t L_46;
		L_46 = UnsafeParallelHashMapData_GrowCapacity_m7F2FF57E76510A99266830779059C6C202B9EC47(L_45, NULL);
		V_13 = L_46;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_47 = ___0_data;
		int32_t L_48 = V_13;
		int32_t L_49 = V_13;
		int32_t L_50;
		L_50 = UnsafeParallelHashMapData_GetBucketSize_mEF90FF75EFE70E4B59CD6AF9FDCB3D564A1986A3(L_49, NULL);
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_51 = ___4_allocation;
		UnsafeParallelHashMapData_ReallocateHashMap_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m74D70D8E65D60A3A3B782011BC925E749F8C29C8(L_47, L_48, L_50, L_51, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
	}

IL_00f4:
	{
	}

IL_00f5:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_52 = ___0_data;
		int32_t* L_53;
		L_53 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_52, NULL);
		int32_t L_54 = (*(L_53));
		V_3 = L_54;
		int32_t L_55 = V_3;
		V_14 = (bool)((((int32_t)((((int32_t)L_55) < ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_56 = V_14;
		if (!L_56)
		{
			goto IL_0121;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_57 = ___0_data;
		int32_t* L_58;
		L_58 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_57, NULL);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_59 = ___0_data;
		NullCheck(L_59);
		uint8_t* L_60 = L_59->___next;
		int32_t L_61 = V_3;
		int32_t L_62 = *((int32_t*)((uint8_t*)il2cpp_codegen_add((intptr_t)L_60, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_61), 4)))));
		*((int32_t*)L_58) = (int32_t)L_62;
		goto IL_0135;
	}

IL_0121:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_63 = ___0_data;
		NullCheck(L_63);
		int32_t* L_64 = (int32_t*)(&L_63->___allocatedIndexLength);
		int32_t* L_65 = L_64;
		int32_t L_66 = *((int32_t*)L_65);
		V_15 = L_66;
		int32_t L_67 = V_15;
		*((int32_t*)L_65) = (int32_t)((int32_t)il2cpp_codegen_add(L_67, 1));
		int32_t L_68 = V_15;
		V_3 = L_68;
	}

IL_0135:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_69 = ___0_data;
		NullCheck(L_69);
		uint8_t* L_70 = L_69->___keys;
		int32_t L_71 = V_3;
		DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 L_72 = ___1_key;
		UnsafeUtility_WriteArrayElement_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_mAC61BCD78DBCF3665AB62CF3F0A9160131582E7C_inline((void*)L_70, L_71, L_72, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 6));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_73 = ___0_data;
		NullCheck(L_73);
		uint8_t* L_74 = L_73->___values;
		int32_t L_75 = V_3;
		int32_t L_76 = ___2_item;
		UnsafeUtility_WriteArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m0DD1CC90B2F1EF5041F2F4E1DABB58224229F0D7_inline((void*)L_74, L_75, L_76, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		int32_t L_77;
		L_77 = DrawKey_GetHashCode_m6E3C5F3D42D02D8035AA7E7B5501FDBC1551F4E5((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_78 = ___0_data;
		NullCheck(L_78);
		int32_t L_79 = L_78->___bucketCapacityMask;
		V_5 = ((int32_t)(L_77&L_79));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_80 = ___0_data;
		NullCheck(L_80);
		uint8_t* L_81 = L_80->___buckets;
		V_6 = (int32_t*)L_81;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_82 = ___0_data;
		NullCheck(L_82);
		uint8_t* L_83 = L_82->___next;
		V_4 = (int32_t*)L_83;
		int32_t* L_84 = V_4;
		int32_t L_85 = V_3;
		int32_t* L_86 = V_6;
		int32_t L_87 = V_5;
		int32_t L_88 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_86, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_87), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_84, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_85), 4))))) = (int32_t)L_88;
		int32_t* L_89 = V_6;
		int32_t L_90 = V_5;
		int32_t L_91 = V_3;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_89, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_90), 4))))) = (int32_t)L_91;
		V_16 = (bool)1;
		goto IL_019c;
	}

IL_0197:
	{
		V_16 = (bool)0;
		goto IL_019c;
	}

IL_019c:
	{
		bool L_92 = V_16;
		return L_92;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapBase_2_Remove_mD0A7EC52AF9067A81379B898E9F19FA26F3F4B88_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___1_key, bool ___2_isMultiHashMap, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t* V_1 = NULL;
	int32_t* V_2 = NULL;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	bool V_6 = false;
	int32_t V_7 = 0;
	bool V_8 = false;
	DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 V_9;
	memset((&V_9), 0, sizeof(V_9));
	int32_t V_10 = 0;
	bool V_11 = false;
	bool V_12 = false;
	bool V_13 = false;
	int32_t G_B15_0 = 0;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		int32_t L_1 = L_0->___keyCapacity;
		V_6 = (bool)((((int32_t)L_1) == ((int32_t)0))? 1 : 0);
		bool L_2 = V_6;
		if (!L_2)
		{
			goto IL_0019;
		}
	}
	{
		V_7 = 0;
		goto IL_010f;
	}

IL_0019:
	{
		V_0 = 0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_3 = ___0_data;
		NullCheck(L_3);
		uint8_t* L_4 = L_3->___buckets;
		V_1 = (int32_t*)L_4;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_5 = ___0_data;
		NullCheck(L_5);
		uint8_t* L_6 = L_5->___next;
		V_2 = (int32_t*)L_6;
		int32_t L_7;
		L_7 = DrawKey_GetHashCode_m6E3C5F3D42D02D8035AA7E7B5501FDBC1551F4E5((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_8 = ___0_data;
		NullCheck(L_8);
		int32_t L_9 = L_8->___bucketCapacityMask;
		V_3 = ((int32_t)(L_7&L_9));
		V_4 = (-1);
		int32_t* L_10 = V_1;
		int32_t L_11 = V_3;
		int32_t L_12 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_10, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_11), 4))))));
		V_5 = L_12;
		goto IL_00ef;
	}

IL_004f:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_13 = ___0_data;
		NullCheck(L_13);
		uint8_t* L_14 = L_13->___keys;
		int32_t L_15 = V_5;
		DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 L_16;
		L_16 = UnsafeUtility_ReadArrayElement_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_mFD7DBC1199616005466125347027F6201459B40D_inline((void*)L_14, L_15, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		V_9 = L_16;
		DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 L_17 = ___1_key;
		bool L_18;
		L_18 = DrawKey_Equals_mBA2838871085C8944B81322DC6E851F4273E8E91((&V_9), L_17, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 15));
		V_8 = L_18;
		bool L_19 = V_8;
		if (!L_19)
		{
			goto IL_00de;
		}
	}
	{
		int32_t L_20 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add(L_20, 1));
		int32_t L_21 = V_4;
		V_11 = (bool)((((int32_t)L_21) < ((int32_t)0))? 1 : 0);
		bool L_22 = V_11;
		if (!L_22)
		{
			goto IL_0096;
		}
	}
	{
		int32_t* L_23 = V_1;
		int32_t L_24 = V_3;
		int32_t* L_25 = V_2;
		int32_t L_26 = V_5;
		int32_t L_27 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_25, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_26), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_23, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_24), 4))))) = (int32_t)L_27;
		goto IL_00a8;
	}

IL_0096:
	{
		int32_t* L_28 = V_2;
		int32_t L_29 = V_4;
		int32_t* L_30 = V_2;
		int32_t L_31 = V_5;
		int32_t L_32 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_30, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_31), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_28, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_29), 4))))) = (int32_t)L_32;
	}

IL_00a8:
	{
		int32_t* L_33 = V_2;
		int32_t L_34 = V_5;
		int32_t L_35 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_33, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_34), 4))))));
		V_10 = L_35;
		int32_t* L_36 = V_2;
		int32_t L_37 = V_5;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_38 = ___0_data;
		int32_t* L_39;
		L_39 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_38, NULL);
		int32_t L_40 = (*(L_39));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_36, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_37), 4))))) = (int32_t)L_40;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_41 = ___0_data;
		int32_t* L_42;
		L_42 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_41, NULL);
		int32_t L_43 = V_5;
		*((int32_t*)L_42) = (int32_t)L_43;
		int32_t L_44 = V_10;
		V_5 = L_44;
		bool L_45 = ___2_isMultiHashMap;
		V_12 = (bool)((((int32_t)L_45) == ((int32_t)0))? 1 : 0);
		bool L_46 = V_12;
		if (!L_46)
		{
			goto IL_00db;
		}
	}
	{
		goto IL_010a;
	}

IL_00db:
	{
		goto IL_00ee;
	}

IL_00de:
	{
		int32_t L_47 = V_5;
		V_4 = L_47;
		int32_t* L_48 = V_2;
		int32_t L_49 = V_5;
		int32_t L_50 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_48, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_49), 4))))));
		V_5 = L_50;
	}

IL_00ee:
	{
	}

IL_00ef:
	{
		int32_t L_51 = V_5;
		if ((((int32_t)L_51) < ((int32_t)0)))
		{
			goto IL_0100;
		}
	}
	{
		int32_t L_52 = V_5;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_53 = ___0_data;
		NullCheck(L_53);
		int32_t L_54 = L_53->___keyCapacity;
		G_B15_0 = ((((int32_t)L_52) < ((int32_t)L_54))? 1 : 0);
		goto IL_0101;
	}

IL_0100:
	{
		G_B15_0 = 0;
	}

IL_0101:
	{
		V_13 = (bool)G_B15_0;
		bool L_55 = V_13;
		if (L_55)
		{
			goto IL_004f;
		}
	}

IL_010a:
	{
		int32_t L_56 = V_0;
		V_7 = L_56;
		goto IL_010f;
	}

IL_010f:
	{
		int32_t L_57 = V_7;
		return L_57;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_Remove_m3529B4E5F4C1537D4D08A03731FF1A6AE4220388_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A ___1_it, const RuntimeMethod* method) 
{
	int32_t* V_0 = NULL;
	int32_t* V_1 = NULL;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	bool V_4 = false;
	bool V_5 = false;
	bool V_6 = false;
	int32_t G_B7_0 = 0;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___buckets;
		V_0 = (int32_t*)L_1;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		NullCheck(L_2);
		uint8_t* L_3 = L_2->___next;
		V_1 = (int32_t*)L_3;
		DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94* L_4 = (DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94*)(&(&___1_it)->___key);
		int32_t L_5;
		L_5 = DrawKey_GetHashCode_m6E3C5F3D42D02D8035AA7E7B5501FDBC1551F4E5(L_4, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_6 = ___0_data;
		NullCheck(L_6);
		int32_t L_7 = L_6->___bucketCapacityMask;
		V_2 = ((int32_t)(L_5&L_7));
		int32_t* L_8 = V_0;
		int32_t L_9 = V_2;
		int32_t L_10 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_8, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_9), 4))))));
		V_3 = L_10;
		int32_t L_11 = V_3;
		NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A L_12 = ___1_it;
		int32_t L_13 = L_12.___EntryIndex;
		V_4 = (bool)((((int32_t)L_11) == ((int32_t)L_13))? 1 : 0);
		bool L_14 = V_4;
		if (!L_14)
		{
			goto IL_0052;
		}
	}
	{
		int32_t* L_15 = V_0;
		int32_t L_16 = V_2;
		int32_t* L_17 = V_1;
		int32_t L_18 = V_3;
		int32_t L_19 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_17, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_18), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_15, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_16), 4))))) = (int32_t)L_19;
		goto IL_009e;
	}

IL_0052:
	{
		goto IL_005f;
	}

IL_0055:
	{
		int32_t* L_20 = V_1;
		int32_t L_21 = V_3;
		int32_t L_22 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_20, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_21), 4))))));
		V_3 = L_22;
	}

IL_005f:
	{
		int32_t L_23 = V_3;
		if ((((int32_t)L_23) < ((int32_t)0)))
		{
			goto IL_0077;
		}
	}
	{
		int32_t* L_24 = V_1;
		int32_t L_25 = V_3;
		int32_t L_26 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_24, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_25), 4))))));
		NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A L_27 = ___1_it;
		int32_t L_28 = L_27.___EntryIndex;
		G_B7_0 = ((((int32_t)((((int32_t)L_26) == ((int32_t)L_28))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0078;
	}

IL_0077:
	{
		G_B7_0 = 0;
	}

IL_0078:
	{
		V_5 = (bool)G_B7_0;
		bool L_29 = V_5;
		if (L_29)
		{
			goto IL_0055;
		}
	}
	{
		int32_t L_30 = V_3;
		V_6 = (bool)((((int32_t)L_30) < ((int32_t)0))? 1 : 0);
		bool L_31 = V_6;
		if (!L_31)
		{
			goto IL_008a;
		}
	}
	{
	}

IL_008a:
	{
		int32_t* L_32 = V_1;
		int32_t L_33 = V_3;
		int32_t* L_34 = V_1;
		NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A L_35 = ___1_it;
		int32_t L_36 = L_35.___EntryIndex;
		int32_t L_37 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_34, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_36), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_32, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_33), 4))))) = (int32_t)L_37;
	}

IL_009e:
	{
		int32_t* L_38 = V_1;
		NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A L_39 = ___1_it;
		int32_t L_40 = L_39.___EntryIndex;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_41 = ___0_data;
		int32_t* L_42;
		L_42 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_41, NULL);
		int32_t L_43 = (*(L_42));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_38, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_40), 4))))) = (int32_t)L_43;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_44 = ___0_data;
		int32_t* L_45;
		L_45 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_44, NULL);
		NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A L_46 = ___1_it;
		int32_t L_47 = L_46.___EntryIndex;
		*((int32_t*)L_45) = (int32_t)L_47;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mC42AE53B9C096C5437713AA40D89EB873678D78F_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___1_key, int32_t* ___2_item, NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A* ___3_it, const RuntimeMethod* method) 
{
	int32_t* V_0 = NULL;
	int32_t V_1 = 0;
	bool V_2 = false;
	int32_t V_3 = 0;
	bool V_4 = false;
	{
		NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A* L_0 = ___3_it;
		DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 L_1 = ___1_key;
		L_0->___key = L_1;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		NullCheck(L_2);
		int32_t L_3 = L_2->___allocatedIndexLength;
		V_2 = (bool)((((int32_t)((((int32_t)L_3) > ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_4 = V_2;
		if (!L_4)
		{
			goto IL_0035;
		}
	}
	{
		NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A* L_5 = ___3_it;
		NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A* L_6 = ___3_it;
		int32_t L_7 = (-1);
		V_3 = L_7;
		L_6->___NextEntryIndex = L_7;
		int32_t L_8 = V_3;
		L_5->___EntryIndex = L_8;
		int32_t* L_9 = ___2_item;
		il2cpp_codegen_initobj(L_9, sizeof(int32_t));
		V_4 = (bool)0;
		goto IL_0073;
	}

IL_0035:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_10 = ___0_data;
		NullCheck(L_10);
		uint8_t* L_11 = L_10->___buckets;
		V_0 = (int32_t*)L_11;
		int32_t L_12;
		L_12 = DrawKey_GetHashCode_m6E3C5F3D42D02D8035AA7E7B5501FDBC1551F4E5((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_13 = ___0_data;
		NullCheck(L_13);
		int32_t L_14 = L_13->___bucketCapacityMask;
		V_1 = ((int32_t)(L_12&L_14));
		NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A* L_15 = ___3_it;
		NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A* L_16 = ___3_it;
		int32_t* L_17 = V_0;
		int32_t L_18 = V_1;
		int32_t L_19 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_17, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_18), 4))))));
		int32_t L_20 = L_19;
		V_3 = L_20;
		L_16->___NextEntryIndex = L_20;
		int32_t L_21 = V_3;
		L_15->___EntryIndex = L_21;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_22 = ___0_data;
		int32_t* L_23 = ___2_item;
		NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A* L_24 = ___3_it;
		bool L_25;
		L_25 = UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_mAFEFFB673EC0E6AACC6C9F4ECEBB1ACA52A589B0(L_22, L_23, L_24, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 16));
		V_4 = L_25;
		goto IL_0073;
	}

IL_0073:
	{
		bool L_26 = V_4;
		return L_26;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_mAFEFFB673EC0E6AACC6C9F4ECEBB1ACA52A589B0_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t* ___1_item, NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A* ___2_it, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t* V_1 = NULL;
	bool V_2 = false;
	bool V_3 = false;
	bool V_4 = false;
	bool V_5 = false;
	DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 V_6;
	memset((&V_6), 0, sizeof(V_6));
	int32_t G_B3_0 = 0;
	int32_t G_B9_0 = 0;
	{
		NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A* L_0 = ___2_it;
		int32_t L_1 = L_0->___NextEntryIndex;
		V_0 = L_1;
		NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A* L_2 = ___2_it;
		L_2->___NextEntryIndex = (-1);
		NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A* L_3 = ___2_it;
		L_3->___EntryIndex = (-1);
		int32_t* L_4 = ___1_item;
		il2cpp_codegen_initobj(L_4, sizeof(int32_t));
		int32_t L_5 = V_0;
		if ((((int32_t)L_5) < ((int32_t)0)))
		{
			goto IL_002f;
		}
	}
	{
		int32_t L_6 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		int32_t L_8 = L_7->___keyCapacity;
		G_B3_0 = ((((int32_t)((((int32_t)L_6) < ((int32_t)L_8))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0030;
	}

IL_002f:
	{
		G_B3_0 = 1;
	}

IL_0030:
	{
		V_2 = (bool)G_B3_0;
		bool L_9 = V_2;
		if (!L_9)
		{
			goto IL_003c;
		}
	}
	{
		V_3 = (bool)0;
		goto IL_00c1;
	}

IL_003c:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_10 = ___0_data;
		NullCheck(L_10);
		uint8_t* L_11 = L_10->___next;
		V_1 = (int32_t*)L_11;
		goto IL_006d;
	}

IL_0045:
	{
		int32_t* L_12 = V_1;
		int32_t L_13 = V_0;
		int32_t L_14 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_12, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_13), 4))))));
		V_0 = L_14;
		int32_t L_15 = V_0;
		if ((((int32_t)L_15) < ((int32_t)0)))
		{
			goto IL_0060;
		}
	}
	{
		int32_t L_16 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_17 = ___0_data;
		NullCheck(L_17);
		int32_t L_18 = L_17->___keyCapacity;
		G_B9_0 = ((((int32_t)((((int32_t)L_16) < ((int32_t)L_18))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0061;
	}

IL_0060:
	{
		G_B9_0 = 1;
	}

IL_0061:
	{
		V_4 = (bool)G_B9_0;
		bool L_19 = V_4;
		if (!L_19)
		{
			goto IL_006c;
		}
	}
	{
		V_3 = (bool)0;
		goto IL_00c1;
	}

IL_006c:
	{
	}

IL_006d:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_20 = ___0_data;
		NullCheck(L_20);
		uint8_t* L_21 = L_20->___keys;
		int32_t L_22 = V_0;
		DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 L_23;
		L_23 = UnsafeUtility_ReadArrayElement_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_mFD7DBC1199616005466125347027F6201459B40D_inline((void*)L_21, L_22, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		V_6 = L_23;
		NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A* L_24 = ___2_it;
		DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 L_25 = L_24->___key;
		bool L_26;
		L_26 = DrawKey_Equals_mBA2838871085C8944B81322DC6E851F4273E8E91((&V_6), L_25, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 15));
		V_5 = (bool)((((int32_t)L_26) == ((int32_t)0))? 1 : 0);
		bool L_27 = V_5;
		if (L_27)
		{
			goto IL_0045;
		}
	}
	{
		NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A* L_28 = ___2_it;
		int32_t* L_29 = V_1;
		int32_t L_30 = V_0;
		int32_t L_31 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_29, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_30), 4))))));
		L_28->___NextEntryIndex = L_31;
		NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A* L_32 = ___2_it;
		int32_t L_33 = V_0;
		L_32->___EntryIndex = L_33;
		int32_t* L_34 = ___1_item;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_35 = ___0_data;
		NullCheck(L_35);
		uint8_t* L_36 = L_35->___values;
		int32_t L_37 = V_0;
		int32_t L_38;
		L_38 = UnsafeUtility_ReadArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_mFBA66C06ECEB0A2BC1AAE634B6E6BB436F957084_inline((void*)L_36, L_37, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 17));
		*(int32_t*)L_34 = L_38;
		V_3 = (bool)1;
		goto IL_00c1;
	}

IL_00c1:
	{
		bool L_39 = V_3;
		return L_39;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_SetValue_mBC2EB4E62A5FAA365C4795E1D7FA3F3ED271F97A_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A* ___1_it, int32_t* ___2_item, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	bool V_1 = false;
	bool V_2 = false;
	int32_t G_B3_0 = 0;
	{
		NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A* L_0 = ___1_it;
		int32_t L_1 = L_0->___EntryIndex;
		V_0 = L_1;
		int32_t L_2 = V_0;
		if ((((int32_t)L_2) < ((int32_t)0)))
		{
			goto IL_001a;
		}
	}
	{
		int32_t L_3 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = ___0_data;
		NullCheck(L_4);
		int32_t L_5 = L_4->___keyCapacity;
		G_B3_0 = ((((int32_t)((((int32_t)L_3) < ((int32_t)L_5))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_001b;
	}

IL_001a:
	{
		G_B3_0 = 1;
	}

IL_001b:
	{
		V_1 = (bool)G_B3_0;
		bool L_6 = V_1;
		if (!L_6)
		{
			goto IL_0024;
		}
	}
	{
		V_2 = (bool)0;
		goto IL_003b;
	}

IL_0024:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		uint8_t* L_8 = L_7->___values;
		int32_t L_9 = V_0;
		int32_t* L_10 = ___2_item;
		int32_t L_11 = (*(int32_t*)L_10);
		UnsafeUtility_WriteArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m0DD1CC90B2F1EF5041F2F4E1DABB58224229F0D7_inline((void*)L_8, L_9, L_11, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		V_2 = (bool)1;
		goto IL_003b;
	}

IL_003b:
	{
		bool L_12 = V_2;
		return L_12;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_Clear_m9D697346792B01D5704CE90A823D958CB4FC2AA9_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	bool V_2 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___buckets;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		NullCheck(L_2);
		int32_t L_3 = L_2->___bucketCapacityMask;
		UnsafeUtility_MemSet_m4CD74CD43260EB2962A46F57E0D93DD5C332FC2B((void*)L_1, (uint8_t)((int32_t)255), ((int64_t)((int32_t)il2cpp_codegen_multiply(((int32_t)il2cpp_codegen_add(L_3, 1)), 4))), NULL);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = ___0_data;
		NullCheck(L_4);
		uint8_t* L_5 = L_4->___next;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_6 = ___0_data;
		NullCheck(L_6);
		int32_t L_7 = L_6->___keyCapacity;
		UnsafeUtility_MemSet_m4CD74CD43260EB2962A46F57E0D93DD5C332FC2B((void*)L_5, (uint8_t)((int32_t)255), ((int64_t)((int32_t)il2cpp_codegen_multiply(L_7, 4))), NULL);
		int32_t L_8;
		L_8 = JobsUtility_get_ThreadIndexCount_m88A954344398143540618B35943F863B92465676(NULL);
		V_0 = L_8;
		V_1 = 0;
		goto IL_0057;
	}

IL_0041:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_9 = ___0_data;
		int32_t* L_10;
		L_10 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_9, NULL);
		int32_t L_11 = V_1;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_10, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_11, ((int32_t)16)))), 4))))) = (int32_t)(-1);
		int32_t L_12 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_12, 1));
	}

IL_0057:
	{
		int32_t L_13 = V_1;
		int32_t L_14 = V_0;
		V_2 = (bool)((((int32_t)L_13) < ((int32_t)L_14))? 1 : 0);
		bool L_15 = V_2;
		if (L_15)
		{
			goto IL_0041;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_16 = ___0_data;
		NullCheck(L_16);
		L_16->___allocatedIndexLength = 0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapBase_2_AllocEntry_m74EB5C8C921F13820DB035CF8DA58E1FB942A142_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_threadIndex, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t* V_1 = NULL;
	bool V_2 = false;
	bool V_3 = false;
	int32_t V_4 = 0;
	bool V_5 = false;
	bool V_6 = false;
	bool V_7 = false;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	bool V_10 = false;
	int32_t V_11 = 0;
	bool V_12 = false;
	int32_t V_13 = 0;
	bool V_14 = false;
	bool V_15 = false;
	bool V_16 = false;
	bool V_17 = false;
	bool V_18 = false;
	bool V_19 = false;
	bool V_20 = false;
	bool V_21 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___next;
		V_1 = (int32_t*)L_1;
	}

IL_0008:
	{
	}

IL_0009:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		int32_t* L_3;
		L_3 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_2, NULL);
		int32_t L_4 = ___1_threadIndex;
		int32_t L_5;
		L_5 = VolatileRead((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_3, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_4, ((int32_t)16)))), 4)))));
		V_0 = L_5;
		int32_t L_6 = V_0;
		V_2 = (bool)((((int32_t)L_6) == ((int32_t)((int32_t)-3)))? 1 : 0);
		bool L_7 = V_2;
		if (L_7)
		{
			goto IL_0009;
		}
	}
	{
		int32_t L_8 = V_0;
		V_3 = (bool)((((int32_t)L_8) < ((int32_t)0))? 1 : 0);
		bool L_9 = V_3;
		if (!L_9)
		{
			goto IL_021e;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_10 = ___0_data;
		int32_t* L_11;
		L_11 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_10, NULL);
		int32_t L_12 = ___1_threadIndex;
		int32_t L_13;
		L_13 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_11, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_12, ((int32_t)16)))), 4)))), ((int32_t)-2), NULL);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_14 = ___0_data;
		NullCheck(L_14);
		int32_t L_15 = L_14->___allocatedIndexLength;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_16 = ___0_data;
		NullCheck(L_16);
		int32_t L_17 = L_16->___keyCapacity;
		V_6 = (bool)((((int32_t)L_15) < ((int32_t)L_17))? 1 : 0);
		bool L_18 = V_6;
		if (!L_18)
		{
			goto IL_0123;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_19 = ___0_data;
		NullCheck(L_19);
		int32_t* L_20 = (int32_t*)(&L_19->___allocatedIndexLength);
		int32_t L_21;
		L_21 = Interlocked_Add_m2455208C56EEFD8832AEAD8AF7368A3FEB33A73C(L_20, ((int32_t)16), NULL);
		V_0 = ((int32_t)il2cpp_codegen_subtract(L_21, ((int32_t)16)));
		int32_t L_22 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_23 = ___0_data;
		NullCheck(L_23);
		int32_t L_24 = L_23->___keyCapacity;
		V_7 = (bool)((((int32_t)L_22) < ((int32_t)((int32_t)il2cpp_codegen_subtract(L_24, 1))))? 1 : 0);
		bool L_25 = V_7;
		if (!L_25)
		{
			goto IL_00f3;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_26 = ___0_data;
		NullCheck(L_26);
		int32_t L_27 = L_26->___keyCapacity;
		int32_t L_28 = V_0;
		int32_t L_29;
		L_29 = math_min_m02D43DF516544C279AF660EA4731449C82991849_inline(((int32_t)16), ((int32_t)il2cpp_codegen_subtract(L_27, L_28)), NULL);
		V_8 = L_29;
		V_9 = 1;
		goto IL_00b3;
	}

IL_009b:
	{
		int32_t* L_30 = V_1;
		int32_t L_31 = V_0;
		int32_t L_32 = V_9;
		int32_t L_33 = V_0;
		int32_t L_34 = V_9;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_30, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_add(L_31, L_32))), 4))))) = (int32_t)((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_33, L_34)), 1));
		int32_t L_35 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add(L_35, 1));
	}

IL_00b3:
	{
		int32_t L_36 = V_9;
		int32_t L_37 = V_8;
		V_10 = (bool)((((int32_t)L_36) < ((int32_t)L_37))? 1 : 0);
		bool L_38 = V_10;
		if (L_38)
		{
			goto IL_009b;
		}
	}
	{
		int32_t* L_39 = V_1;
		int32_t L_40 = V_0;
		int32_t L_41 = V_8;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_39, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_40, L_41)), 1))), 4))))) = (int32_t)(-1);
		int32_t* L_42 = V_1;
		int32_t L_43 = V_0;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_42, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_43), 4))))) = (int32_t)(-1);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_44 = ___0_data;
		int32_t* L_45;
		L_45 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_44, NULL);
		int32_t L_46 = ___1_threadIndex;
		int32_t L_47 = V_0;
		int32_t L_48;
		L_48 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_45, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_46, ((int32_t)16)))), 4)))), ((int32_t)il2cpp_codegen_add(L_47, 1)), NULL);
		int32_t L_49 = V_0;
		V_11 = L_49;
		goto IL_026c;
	}

IL_00f3:
	{
		int32_t L_50 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_51 = ___0_data;
		NullCheck(L_51);
		int32_t L_52 = L_51->___keyCapacity;
		V_12 = (bool)((((int32_t)L_50) == ((int32_t)((int32_t)il2cpp_codegen_subtract(L_52, 1))))? 1 : 0);
		bool L_53 = V_12;
		if (!L_53)
		{
			goto IL_0122;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_54 = ___0_data;
		int32_t* L_55;
		L_55 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_54, NULL);
		int32_t L_56 = ___1_threadIndex;
		int32_t L_57;
		L_57 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_55, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_56, ((int32_t)16)))), 4)))), (-1), NULL);
		int32_t L_58 = V_0;
		V_11 = L_58;
		goto IL_026c;
	}

IL_0122:
	{
	}

IL_0123:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_59 = ___0_data;
		int32_t* L_60;
		L_60 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_59, NULL);
		int32_t L_61 = ___1_threadIndex;
		int32_t L_62;
		L_62 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_60, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_61, ((int32_t)16)))), 4)))), (-1), NULL);
		int32_t L_63;
		L_63 = JobsUtility_get_ThreadIndexCount_m88A954344398143540618B35943F863B92465676(NULL);
		V_4 = L_63;
		V_5 = (bool)1;
		goto IL_0212;
	}

IL_0147:
	{
		V_5 = (bool)0;
		int32_t L_64 = ___1_threadIndex;
		int32_t L_65 = V_4;
		V_13 = ((int32_t)(((int32_t)il2cpp_codegen_add(L_64, 1))%L_65));
		goto IL_0200;
	}

IL_0158:
	{
	}

IL_0159:
	{
	}

IL_015a:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_66 = ___0_data;
		int32_t* L_67;
		L_67 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_66, NULL);
		int32_t L_68 = V_13;
		int32_t L_69;
		L_69 = VolatileRead((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_67, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_68, ((int32_t)16)))), 4)))));
		V_0 = L_69;
		int32_t L_70 = V_0;
		V_14 = (bool)((((int32_t)L_70) == ((int32_t)((int32_t)-3)))? 1 : 0);
		bool L_71 = V_14;
		if (L_71)
		{
			goto IL_015a;
		}
	}
	{
		int32_t L_72 = V_0;
		V_15 = (bool)((((int32_t)L_72) < ((int32_t)0))? 1 : 0);
		bool L_73 = V_15;
		if (!L_73)
		{
			goto IL_0189;
		}
	}
	{
		goto IL_01ad;
	}

IL_0189:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_74 = ___0_data;
		int32_t* L_75;
		L_75 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_74, NULL);
		int32_t L_76 = V_13;
		int32_t L_77 = V_0;
		int32_t L_78;
		L_78 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_75, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_76, ((int32_t)16)))), 4)))), ((int32_t)-3), L_77, NULL);
		int32_t L_79 = V_0;
		V_16 = (bool)((((int32_t)((((int32_t)L_78) == ((int32_t)L_79))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_80 = V_16;
		if (L_80)
		{
			goto IL_0159;
		}
	}

IL_01ad:
	{
		int32_t L_81 = V_0;
		V_17 = (bool)((((int32_t)L_81) == ((int32_t)((int32_t)-2)))? 1 : 0);
		bool L_82 = V_17;
		if (!L_82)
		{
			goto IL_01bf;
		}
	}
	{
		V_5 = (bool)1;
		goto IL_01f6;
	}

IL_01bf:
	{
		int32_t L_83 = V_0;
		V_18 = (bool)((((int32_t)((((int32_t)L_83) < ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_84 = V_18;
		if (!L_84)
		{
			goto IL_01f6;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_85 = ___0_data;
		int32_t* L_86;
		L_86 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_85, NULL);
		int32_t L_87 = V_13;
		int32_t* L_88 = V_1;
		int32_t L_89 = V_0;
		int32_t L_90 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_88, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_89), 4))))));
		int32_t L_91;
		L_91 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_86, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_87, ((int32_t)16)))), 4)))), L_90, NULL);
		int32_t* L_92 = V_1;
		int32_t L_93 = V_0;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_92, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_93), 4))))) = (int32_t)(-1);
		int32_t L_94 = V_0;
		V_11 = L_94;
		goto IL_026c;
	}

IL_01f6:
	{
		int32_t L_95 = V_13;
		int32_t L_96 = V_4;
		V_13 = ((int32_t)(((int32_t)il2cpp_codegen_add(L_95, 1))%L_96));
	}

IL_0200:
	{
		int32_t L_97 = V_13;
		int32_t L_98 = ___1_threadIndex;
		V_19 = (bool)((((int32_t)((((int32_t)L_97) == ((int32_t)L_98))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_99 = V_19;
		if (L_99)
		{
			goto IL_0158;
		}
	}
	{
	}

IL_0212:
	{
		bool L_100 = V_5;
		V_20 = L_100;
		bool L_101 = V_20;
		if (L_101)
		{
			goto IL_0147;
		}
	}
	{
	}

IL_021e:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_102 = ___0_data;
		int32_t* L_103;
		L_103 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_102, NULL);
		int32_t L_104 = ___1_threadIndex;
		int32_t L_105 = V_0;
		int32_t L_106;
		L_106 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_103, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_104, ((int32_t)16)))), 4)))), ((int32_t)-3), L_105, NULL);
		int32_t L_107 = V_0;
		V_21 = (bool)((((int32_t)((((int32_t)L_106) == ((int32_t)L_107))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_108 = V_21;
		if (L_108)
		{
			goto IL_0008;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_109 = ___0_data;
		int32_t* L_110;
		L_110 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_109, NULL);
		int32_t L_111 = ___1_threadIndex;
		int32_t* L_112 = V_1;
		int32_t L_113 = V_0;
		int32_t L_114 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_112, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_113), 4))))));
		int32_t L_115;
		L_115 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_110, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_111, ((int32_t)16)))), 4)))), L_114, NULL);
		int32_t* L_116 = V_1;
		int32_t L_117 = V_0;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_116, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_117), 4))))) = (int32_t)(-1);
		int32_t L_118 = V_0;
		V_11 = L_118;
		goto IL_026c;
	}

IL_026c:
	{
		int32_t L_119 = V_11;
		return L_119;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_FreeEntry_m900571E61B5A7712D4C2358CC8B337805E654A03_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_idx, int32_t ___2_threadIndex, const RuntimeMethod* method) 
{
	int32_t* V_0 = NULL;
	int32_t V_1 = 0;
	bool V_2 = false;
	bool V_3 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___next;
		V_0 = (int32_t*)L_1;
		V_1 = (-1);
	}

IL_000a:
	{
	}

IL_000b:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		int32_t* L_3;
		L_3 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_2, NULL);
		int32_t L_4 = ___2_threadIndex;
		int32_t L_5;
		L_5 = VolatileRead((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_3, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_4, ((int32_t)16)))), 4)))));
		V_1 = L_5;
		int32_t L_6 = V_1;
		V_2 = (bool)((((int32_t)L_6) == ((int32_t)((int32_t)-3)))? 1 : 0);
		bool L_7 = V_2;
		if (L_7)
		{
			goto IL_000b;
		}
	}
	{
		int32_t* L_8 = V_0;
		int32_t L_9 = ___1_idx;
		int32_t L_10 = V_1;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_8, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_9), 4))))) = (int32_t)L_10;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_11 = ___0_data;
		int32_t* L_12;
		L_12 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_11, NULL);
		int32_t L_13 = ___2_threadIndex;
		int32_t L_14 = ___1_idx;
		int32_t L_15 = V_1;
		int32_t L_16;
		L_16 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_12, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_13, ((int32_t)16)))), 4)))), L_14, L_15, NULL);
		int32_t L_17 = V_1;
		V_3 = (bool)((((int32_t)((((int32_t)L_16) == ((int32_t)L_17))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_18 = V_3;
		if (L_18)
		{
			goto IL_000a;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryAddAtomic_m6897C1560907A37A2D866473770A8B4A7EF24FCE_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C ___2_item, int32_t ___3_threadIndex, const RuntimeMethod* method) 
{
	BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C V_0;
	memset((&V_0), 0, sizeof(V_0));
	NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC V_1;
	memset((&V_1), 0, sizeof(V_1));
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	int32_t* V_4 = NULL;
	bool V_5 = false;
	bool V_6 = false;
	bool V_7 = false;
	int32_t* V_8 = NULL;
	int32_t V_9 = 0;
	bool V_10 = false;
	bool V_11 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		int32_t L_1 = ___1_key;
		bool L_2;
		L_2 = UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_m97E032CD6E0F90AFEDAFAF6FC9790EAEFAD4D38F(L_0, L_1, (&V_0), (&V_1), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_5 = L_2;
		bool L_3 = V_5;
		if (!L_3)
		{
			goto IL_001b;
		}
	}
	{
		V_6 = (bool)0;
		goto IL_00da;
	}

IL_001b:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = ___0_data;
		int32_t L_5 = ___3_threadIndex;
		int32_t L_6;
		L_6 = UnsafeParallelHashMapBase_2_AllocEntry_m74EB5C8C921F13820DB035CF8DA58E1FB942A142(L_4, L_5, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		V_2 = L_6;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		uint8_t* L_8 = L_7->___keys;
		int32_t L_9 = V_2;
		int32_t L_10 = ___1_key;
		UnsafeUtility_WriteArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m0DD1CC90B2F1EF5041F2F4E1DABB58224229F0D7_inline((void*)L_8, L_9, L_10, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 6));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_11 = ___0_data;
		NullCheck(L_11);
		uint8_t* L_12 = L_11->___values;
		int32_t L_13 = V_2;
		BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C L_14 = ___2_item;
		UnsafeUtility_WriteArrayElement_TisBatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C_m32FE612078445C09645A5FEFCADD35BF1B5497D3_inline((void*)L_12, L_13, L_14, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		int32_t L_15;
		L_15 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_16 = ___0_data;
		NullCheck(L_16);
		int32_t L_17 = L_16->___bucketCapacityMask;
		V_3 = ((int32_t)(L_15&L_17));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_18 = ___0_data;
		NullCheck(L_18);
		uint8_t* L_19 = L_18->___buckets;
		V_4 = (int32_t*)L_19;
		int32_t* L_20 = V_4;
		int32_t L_21 = V_3;
		int32_t L_22 = V_2;
		int32_t L_23;
		L_23 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_20, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_21), 4)))), L_22, (-1), NULL);
		V_7 = (bool)((((int32_t)((((int32_t)L_23) == ((int32_t)(-1)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_24 = V_7;
		if (!L_24)
		{
			goto IL_00d5;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_25 = ___0_data;
		NullCheck(L_25);
		uint8_t* L_26 = L_25->___next;
		V_8 = (int32_t*)L_26;
		V_9 = (-1);
	}

IL_0082:
	{
		int32_t* L_27 = V_4;
		int32_t L_28 = V_3;
		int32_t L_29 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_27, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_28), 4))))));
		V_9 = L_29;
		int32_t* L_30 = V_8;
		int32_t L_31 = V_2;
		int32_t L_32 = V_9;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_30, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_31), 4))))) = (int32_t)L_32;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_33 = ___0_data;
		int32_t L_34 = ___1_key;
		bool L_35;
		L_35 = UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_m97E032CD6E0F90AFEDAFAF6FC9790EAEFAD4D38F(L_33, L_34, (&V_0), (&V_1), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_10 = L_35;
		bool L_36 = V_10;
		if (!L_36)
		{
			goto IL_00b7;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_37 = ___0_data;
		int32_t L_38 = V_2;
		int32_t L_39 = ___3_threadIndex;
		UnsafeParallelHashMapBase_2_FreeEntry_m900571E61B5A7712D4C2358CC8B337805E654A03(L_37, L_38, L_39, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 10));
		V_6 = (bool)0;
		goto IL_00da;
	}

IL_00b7:
	{
		int32_t* L_40 = V_4;
		int32_t L_41 = V_3;
		int32_t L_42 = V_2;
		int32_t L_43 = V_9;
		int32_t L_44;
		L_44 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_40, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_41), 4)))), L_42, L_43, NULL);
		int32_t L_45 = V_9;
		V_11 = (bool)((((int32_t)((((int32_t)L_44) == ((int32_t)L_45))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_46 = V_11;
		if (L_46)
		{
			goto IL_0082;
		}
	}
	{
	}

IL_00d5:
	{
		V_6 = (bool)1;
		goto IL_00da;
	}

IL_00da:
	{
		bool L_47 = V_6;
		return L_47;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryAdd_mD4B7FE3FC4BD3B5C3A16E35F17A9D92A6E69E4A7_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C ___2_item, bool ___3_isMultiHashMap, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___4_allocation, const RuntimeMethod* method) 
{
	BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C V_0;
	memset((&V_0), 0, sizeof(V_0));
	NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC V_1;
	memset((&V_1), 0, sizeof(V_1));
	bool V_2 = false;
	int32_t V_3 = 0;
	int32_t* V_4 = NULL;
	int32_t V_5 = 0;
	int32_t* V_6 = NULL;
	bool V_7 = false;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	bool V_10 = false;
	bool V_11 = false;
	bool V_12 = false;
	int32_t V_13 = 0;
	bool V_14 = false;
	int32_t V_15 = 0;
	bool V_16 = false;
	int32_t G_B3_0 = 0;
	int32_t G_B7_0 = 0;
	{
		bool L_0 = ___3_isMultiHashMap;
		if (L_0)
		{
			goto IL_0014;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_1 = ___0_data;
		int32_t L_2 = ___1_key;
		bool L_3;
		L_3 = UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_m97E032CD6E0F90AFEDAFAF6FC9790EAEFAD4D38F(L_1, L_2, (&V_0), (&V_1), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		G_B3_0 = ((((int32_t)L_3) == ((int32_t)0))? 1 : 0);
		goto IL_0015;
	}

IL_0014:
	{
		G_B3_0 = 1;
	}

IL_0015:
	{
		V_2 = (bool)G_B3_0;
		bool L_4 = V_2;
		if (!L_4)
		{
			goto IL_0197;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_5 = ___0_data;
		NullCheck(L_5);
		int32_t L_6 = L_5->___allocatedIndexLength;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		int32_t L_8 = L_7->___keyCapacity;
		if ((((int32_t)L_6) < ((int32_t)L_8)))
		{
			goto IL_0037;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_9 = ___0_data;
		int32_t* L_10;
		L_10 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_9, NULL);
		int32_t L_11 = (*(L_10));
		G_B7_0 = ((((int32_t)L_11) < ((int32_t)0))? 1 : 0);
		goto IL_0038;
	}

IL_0037:
	{
		G_B7_0 = 0;
	}

IL_0038:
	{
		V_7 = (bool)G_B7_0;
		bool L_12 = V_7;
		if (!L_12)
		{
			goto IL_00f5;
		}
	}
	{
		int32_t L_13;
		L_13 = JobsUtility_get_ThreadIndexCount_m88A954344398143540618B35943F863B92465676(NULL);
		V_8 = L_13;
		V_9 = 1;
		goto IL_00b7;
	}

IL_004e:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_14 = ___0_data;
		int32_t* L_15;
		L_15 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_14, NULL);
		int32_t L_16 = V_9;
		int32_t L_17 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_15, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_16, ((int32_t)16)))), 4))))));
		V_10 = (bool)((((int32_t)((((int32_t)L_17) < ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_18 = V_10;
		if (!L_18)
		{
			goto IL_00b0;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_19 = ___0_data;
		int32_t* L_20;
		L_20 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_19, NULL);
		int32_t L_21 = V_9;
		int32_t L_22 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_20, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_21, ((int32_t)16)))), 4))))));
		V_3 = L_22;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_23 = ___0_data;
		NullCheck(L_23);
		uint8_t* L_24 = L_23->___next;
		V_4 = (int32_t*)L_24;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_25 = ___0_data;
		int32_t* L_26;
		L_26 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_25, NULL);
		int32_t L_27 = V_9;
		int32_t* L_28 = V_4;
		int32_t L_29 = V_3;
		int32_t L_30 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_28, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_29), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_26, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_27, ((int32_t)16)))), 4))))) = (int32_t)L_30;
		int32_t* L_31 = V_4;
		int32_t L_32 = V_3;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_31, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_32), 4))))) = (int32_t)(-1);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_33 = ___0_data;
		int32_t* L_34;
		L_34 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_33, NULL);
		int32_t L_35 = V_3;
		*((int32_t*)L_34) = (int32_t)L_35;
		goto IL_00c3;
	}

IL_00b0:
	{
		int32_t L_36 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add(L_36, 1));
	}

IL_00b7:
	{
		int32_t L_37 = V_9;
		int32_t L_38 = V_8;
		V_11 = (bool)((((int32_t)L_37) < ((int32_t)L_38))? 1 : 0);
		bool L_39 = V_11;
		if (L_39)
		{
			goto IL_004e;
		}
	}

IL_00c3:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_40 = ___0_data;
		int32_t* L_41;
		L_41 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_40, NULL);
		int32_t L_42 = (*(L_41));
		V_12 = (bool)((((int32_t)L_42) < ((int32_t)0))? 1 : 0);
		bool L_43 = V_12;
		if (!L_43)
		{
			goto IL_00f4;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_44 = ___0_data;
		NullCheck(L_44);
		int32_t L_45 = L_44->___keyCapacity;
		int32_t L_46;
		L_46 = UnsafeParallelHashMapData_GrowCapacity_m7F2FF57E76510A99266830779059C6C202B9EC47(L_45, NULL);
		V_13 = L_46;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_47 = ___0_data;
		int32_t L_48 = V_13;
		int32_t L_49 = V_13;
		int32_t L_50;
		L_50 = UnsafeParallelHashMapData_GetBucketSize_mEF90FF75EFE70E4B59CD6AF9FDCB3D564A1986A3(L_49, NULL);
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_51 = ___4_allocation;
		UnsafeParallelHashMapData_ReallocateHashMap_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_TisBatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C_m0D3BC53501025D0E6FFB93ADC9A6861B58849FE5(L_47, L_48, L_50, L_51, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
	}

IL_00f4:
	{
	}

IL_00f5:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_52 = ___0_data;
		int32_t* L_53;
		L_53 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_52, NULL);
		int32_t L_54 = (*(L_53));
		V_3 = L_54;
		int32_t L_55 = V_3;
		V_14 = (bool)((((int32_t)((((int32_t)L_55) < ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_56 = V_14;
		if (!L_56)
		{
			goto IL_0121;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_57 = ___0_data;
		int32_t* L_58;
		L_58 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_57, NULL);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_59 = ___0_data;
		NullCheck(L_59);
		uint8_t* L_60 = L_59->___next;
		int32_t L_61 = V_3;
		int32_t L_62 = *((int32_t*)((uint8_t*)il2cpp_codegen_add((intptr_t)L_60, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_61), 4)))));
		*((int32_t*)L_58) = (int32_t)L_62;
		goto IL_0135;
	}

IL_0121:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_63 = ___0_data;
		NullCheck(L_63);
		int32_t* L_64 = (int32_t*)(&L_63->___allocatedIndexLength);
		int32_t* L_65 = L_64;
		int32_t L_66 = *((int32_t*)L_65);
		V_15 = L_66;
		int32_t L_67 = V_15;
		*((int32_t*)L_65) = (int32_t)((int32_t)il2cpp_codegen_add(L_67, 1));
		int32_t L_68 = V_15;
		V_3 = L_68;
	}

IL_0135:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_69 = ___0_data;
		NullCheck(L_69);
		uint8_t* L_70 = L_69->___keys;
		int32_t L_71 = V_3;
		int32_t L_72 = ___1_key;
		UnsafeUtility_WriteArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m0DD1CC90B2F1EF5041F2F4E1DABB58224229F0D7_inline((void*)L_70, L_71, L_72, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 6));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_73 = ___0_data;
		NullCheck(L_73);
		uint8_t* L_74 = L_73->___values;
		int32_t L_75 = V_3;
		BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C L_76 = ___2_item;
		UnsafeUtility_WriteArrayElement_TisBatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C_m32FE612078445C09645A5FEFCADD35BF1B5497D3_inline((void*)L_74, L_75, L_76, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		int32_t L_77;
		L_77 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_78 = ___0_data;
		NullCheck(L_78);
		int32_t L_79 = L_78->___bucketCapacityMask;
		V_5 = ((int32_t)(L_77&L_79));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_80 = ___0_data;
		NullCheck(L_80);
		uint8_t* L_81 = L_80->___buckets;
		V_6 = (int32_t*)L_81;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_82 = ___0_data;
		NullCheck(L_82);
		uint8_t* L_83 = L_82->___next;
		V_4 = (int32_t*)L_83;
		int32_t* L_84 = V_4;
		int32_t L_85 = V_3;
		int32_t* L_86 = V_6;
		int32_t L_87 = V_5;
		int32_t L_88 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_86, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_87), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_84, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_85), 4))))) = (int32_t)L_88;
		int32_t* L_89 = V_6;
		int32_t L_90 = V_5;
		int32_t L_91 = V_3;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_89, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_90), 4))))) = (int32_t)L_91;
		V_16 = (bool)1;
		goto IL_019c;
	}

IL_0197:
	{
		V_16 = (bool)0;
		goto IL_019c;
	}

IL_019c:
	{
		bool L_92 = V_16;
		return L_92;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapBase_2_Remove_m9A211EEBC2C5B395D439BCDD639ACAC22834AE20_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, bool ___2_isMultiHashMap, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t* V_1 = NULL;
	int32_t* V_2 = NULL;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	bool V_6 = false;
	int32_t V_7 = 0;
	bool V_8 = false;
	int32_t V_9 = 0;
	int32_t V_10 = 0;
	bool V_11 = false;
	bool V_12 = false;
	bool V_13 = false;
	int32_t G_B15_0 = 0;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		int32_t L_1 = L_0->___keyCapacity;
		V_6 = (bool)((((int32_t)L_1) == ((int32_t)0))? 1 : 0);
		bool L_2 = V_6;
		if (!L_2)
		{
			goto IL_0019;
		}
	}
	{
		V_7 = 0;
		goto IL_010f;
	}

IL_0019:
	{
		V_0 = 0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_3 = ___0_data;
		NullCheck(L_3);
		uint8_t* L_4 = L_3->___buckets;
		V_1 = (int32_t*)L_4;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_5 = ___0_data;
		NullCheck(L_5);
		uint8_t* L_6 = L_5->___next;
		V_2 = (int32_t*)L_6;
		int32_t L_7;
		L_7 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_8 = ___0_data;
		NullCheck(L_8);
		int32_t L_9 = L_8->___bucketCapacityMask;
		V_3 = ((int32_t)(L_7&L_9));
		V_4 = (-1);
		int32_t* L_10 = V_1;
		int32_t L_11 = V_3;
		int32_t L_12 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_10, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_11), 4))))));
		V_5 = L_12;
		goto IL_00ef;
	}

IL_004f:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_13 = ___0_data;
		NullCheck(L_13);
		uint8_t* L_14 = L_13->___keys;
		int32_t L_15 = V_5;
		int32_t L_16;
		L_16 = UnsafeUtility_ReadArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_mFBA66C06ECEB0A2BC1AAE634B6E6BB436F957084_inline((void*)L_14, L_15, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		V_9 = L_16;
		int32_t L_17 = ___1_key;
		bool L_18;
		L_18 = Int32_Equals_mC819D19A661B95BE253FB1769FD4D91961D20722((&V_9), L_17, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 15));
		V_8 = L_18;
		bool L_19 = V_8;
		if (!L_19)
		{
			goto IL_00de;
		}
	}
	{
		int32_t L_20 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add(L_20, 1));
		int32_t L_21 = V_4;
		V_11 = (bool)((((int32_t)L_21) < ((int32_t)0))? 1 : 0);
		bool L_22 = V_11;
		if (!L_22)
		{
			goto IL_0096;
		}
	}
	{
		int32_t* L_23 = V_1;
		int32_t L_24 = V_3;
		int32_t* L_25 = V_2;
		int32_t L_26 = V_5;
		int32_t L_27 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_25, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_26), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_23, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_24), 4))))) = (int32_t)L_27;
		goto IL_00a8;
	}

IL_0096:
	{
		int32_t* L_28 = V_2;
		int32_t L_29 = V_4;
		int32_t* L_30 = V_2;
		int32_t L_31 = V_5;
		int32_t L_32 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_30, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_31), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_28, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_29), 4))))) = (int32_t)L_32;
	}

IL_00a8:
	{
		int32_t* L_33 = V_2;
		int32_t L_34 = V_5;
		int32_t L_35 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_33, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_34), 4))))));
		V_10 = L_35;
		int32_t* L_36 = V_2;
		int32_t L_37 = V_5;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_38 = ___0_data;
		int32_t* L_39;
		L_39 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_38, NULL);
		int32_t L_40 = (*(L_39));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_36, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_37), 4))))) = (int32_t)L_40;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_41 = ___0_data;
		int32_t* L_42;
		L_42 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_41, NULL);
		int32_t L_43 = V_5;
		*((int32_t*)L_42) = (int32_t)L_43;
		int32_t L_44 = V_10;
		V_5 = L_44;
		bool L_45 = ___2_isMultiHashMap;
		V_12 = (bool)((((int32_t)L_45) == ((int32_t)0))? 1 : 0);
		bool L_46 = V_12;
		if (!L_46)
		{
			goto IL_00db;
		}
	}
	{
		goto IL_010a;
	}

IL_00db:
	{
		goto IL_00ee;
	}

IL_00de:
	{
		int32_t L_47 = V_5;
		V_4 = L_47;
		int32_t* L_48 = V_2;
		int32_t L_49 = V_5;
		int32_t L_50 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_48, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_49), 4))))));
		V_5 = L_50;
	}

IL_00ee:
	{
	}

IL_00ef:
	{
		int32_t L_51 = V_5;
		if ((((int32_t)L_51) < ((int32_t)0)))
		{
			goto IL_0100;
		}
	}
	{
		int32_t L_52 = V_5;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_53 = ___0_data;
		NullCheck(L_53);
		int32_t L_54 = L_53->___keyCapacity;
		G_B15_0 = ((((int32_t)L_52) < ((int32_t)L_54))? 1 : 0);
		goto IL_0101;
	}

IL_0100:
	{
		G_B15_0 = 0;
	}

IL_0101:
	{
		V_13 = (bool)G_B15_0;
		bool L_55 = V_13;
		if (L_55)
		{
			goto IL_004f;
		}
	}

IL_010a:
	{
		int32_t L_56 = V_0;
		V_7 = L_56;
		goto IL_010f;
	}

IL_010f:
	{
		int32_t L_57 = V_7;
		return L_57;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_Remove_m1A32DF0ED7D694F6249ED62CBD83A5E1329C7AF3_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC ___1_it, const RuntimeMethod* method) 
{
	int32_t* V_0 = NULL;
	int32_t* V_1 = NULL;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	bool V_4 = false;
	bool V_5 = false;
	bool V_6 = false;
	int32_t G_B7_0 = 0;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___buckets;
		V_0 = (int32_t*)L_1;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		NullCheck(L_2);
		uint8_t* L_3 = L_2->___next;
		V_1 = (int32_t*)L_3;
		int32_t* L_4 = (int32_t*)(&(&___1_it)->___key);
		int32_t L_5;
		L_5 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295(L_4, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_6 = ___0_data;
		NullCheck(L_6);
		int32_t L_7 = L_6->___bucketCapacityMask;
		V_2 = ((int32_t)(L_5&L_7));
		int32_t* L_8 = V_0;
		int32_t L_9 = V_2;
		int32_t L_10 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_8, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_9), 4))))));
		V_3 = L_10;
		int32_t L_11 = V_3;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC L_12 = ___1_it;
		int32_t L_13 = L_12.___EntryIndex;
		V_4 = (bool)((((int32_t)L_11) == ((int32_t)L_13))? 1 : 0);
		bool L_14 = V_4;
		if (!L_14)
		{
			goto IL_0052;
		}
	}
	{
		int32_t* L_15 = V_0;
		int32_t L_16 = V_2;
		int32_t* L_17 = V_1;
		int32_t L_18 = V_3;
		int32_t L_19 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_17, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_18), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_15, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_16), 4))))) = (int32_t)L_19;
		goto IL_009e;
	}

IL_0052:
	{
		goto IL_005f;
	}

IL_0055:
	{
		int32_t* L_20 = V_1;
		int32_t L_21 = V_3;
		int32_t L_22 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_20, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_21), 4))))));
		V_3 = L_22;
	}

IL_005f:
	{
		int32_t L_23 = V_3;
		if ((((int32_t)L_23) < ((int32_t)0)))
		{
			goto IL_0077;
		}
	}
	{
		int32_t* L_24 = V_1;
		int32_t L_25 = V_3;
		int32_t L_26 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_24, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_25), 4))))));
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC L_27 = ___1_it;
		int32_t L_28 = L_27.___EntryIndex;
		G_B7_0 = ((((int32_t)((((int32_t)L_26) == ((int32_t)L_28))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0078;
	}

IL_0077:
	{
		G_B7_0 = 0;
	}

IL_0078:
	{
		V_5 = (bool)G_B7_0;
		bool L_29 = V_5;
		if (L_29)
		{
			goto IL_0055;
		}
	}
	{
		int32_t L_30 = V_3;
		V_6 = (bool)((((int32_t)L_30) < ((int32_t)0))? 1 : 0);
		bool L_31 = V_6;
		if (!L_31)
		{
			goto IL_008a;
		}
	}
	{
	}

IL_008a:
	{
		int32_t* L_32 = V_1;
		int32_t L_33 = V_3;
		int32_t* L_34 = V_1;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC L_35 = ___1_it;
		int32_t L_36 = L_35.___EntryIndex;
		int32_t L_37 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_34, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_36), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_32, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_33), 4))))) = (int32_t)L_37;
	}

IL_009e:
	{
		int32_t* L_38 = V_1;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC L_39 = ___1_it;
		int32_t L_40 = L_39.___EntryIndex;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_41 = ___0_data;
		int32_t* L_42;
		L_42 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_41, NULL);
		int32_t L_43 = (*(L_42));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_38, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_40), 4))))) = (int32_t)L_43;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_44 = ___0_data;
		int32_t* L_45;
		L_45 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_44, NULL);
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC L_46 = ___1_it;
		int32_t L_47 = L_46.___EntryIndex;
		*((int32_t*)L_45) = (int32_t)L_47;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_m97E032CD6E0F90AFEDAFAF6FC9790EAEFAD4D38F_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C* ___2_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___3_it, const RuntimeMethod* method) 
{
	int32_t* V_0 = NULL;
	int32_t V_1 = 0;
	bool V_2 = false;
	int32_t V_3 = 0;
	bool V_4 = false;
	{
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_0 = ___3_it;
		int32_t L_1 = ___1_key;
		L_0->___key = L_1;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		NullCheck(L_2);
		int32_t L_3 = L_2->___allocatedIndexLength;
		V_2 = (bool)((((int32_t)((((int32_t)L_3) > ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_4 = V_2;
		if (!L_4)
		{
			goto IL_0035;
		}
	}
	{
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_5 = ___3_it;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_6 = ___3_it;
		int32_t L_7 = (-1);
		V_3 = L_7;
		L_6->___NextEntryIndex = L_7;
		int32_t L_8 = V_3;
		L_5->___EntryIndex = L_8;
		BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C* L_9 = ___2_item;
		il2cpp_codegen_initobj(L_9, sizeof(BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C));
		V_4 = (bool)0;
		goto IL_0073;
	}

IL_0035:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_10 = ___0_data;
		NullCheck(L_10);
		uint8_t* L_11 = L_10->___buckets;
		V_0 = (int32_t*)L_11;
		int32_t L_12;
		L_12 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_13 = ___0_data;
		NullCheck(L_13);
		int32_t L_14 = L_13->___bucketCapacityMask;
		V_1 = ((int32_t)(L_12&L_14));
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_15 = ___3_it;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_16 = ___3_it;
		int32_t* L_17 = V_0;
		int32_t L_18 = V_1;
		int32_t L_19 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_17, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_18), 4))))));
		int32_t L_20 = L_19;
		V_3 = L_20;
		L_16->___NextEntryIndex = L_20;
		int32_t L_21 = V_3;
		L_15->___EntryIndex = L_21;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_22 = ___0_data;
		BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C* L_23 = ___2_item;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_24 = ___3_it;
		bool L_25;
		L_25 = UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m5D25900ED3545AA3E3F72977EB6F728351B3D361(L_22, L_23, L_24, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 16));
		V_4 = L_25;
		goto IL_0073;
	}

IL_0073:
	{
		bool L_26 = V_4;
		return L_26;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m5D25900ED3545AA3E3F72977EB6F728351B3D361_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C* ___1_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___2_it, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t* V_1 = NULL;
	bool V_2 = false;
	bool V_3 = false;
	bool V_4 = false;
	bool V_5 = false;
	int32_t V_6 = 0;
	int32_t G_B3_0 = 0;
	int32_t G_B9_0 = 0;
	{
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_0 = ___2_it;
		int32_t L_1 = L_0->___NextEntryIndex;
		V_0 = L_1;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_2 = ___2_it;
		L_2->___NextEntryIndex = (-1);
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_3 = ___2_it;
		L_3->___EntryIndex = (-1);
		BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C* L_4 = ___1_item;
		il2cpp_codegen_initobj(L_4, sizeof(BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C));
		int32_t L_5 = V_0;
		if ((((int32_t)L_5) < ((int32_t)0)))
		{
			goto IL_002f;
		}
	}
	{
		int32_t L_6 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		int32_t L_8 = L_7->___keyCapacity;
		G_B3_0 = ((((int32_t)((((int32_t)L_6) < ((int32_t)L_8))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0030;
	}

IL_002f:
	{
		G_B3_0 = 1;
	}

IL_0030:
	{
		V_2 = (bool)G_B3_0;
		bool L_9 = V_2;
		if (!L_9)
		{
			goto IL_003c;
		}
	}
	{
		V_3 = (bool)0;
		goto IL_00c1;
	}

IL_003c:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_10 = ___0_data;
		NullCheck(L_10);
		uint8_t* L_11 = L_10->___next;
		V_1 = (int32_t*)L_11;
		goto IL_006d;
	}

IL_0045:
	{
		int32_t* L_12 = V_1;
		int32_t L_13 = V_0;
		int32_t L_14 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_12, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_13), 4))))));
		V_0 = L_14;
		int32_t L_15 = V_0;
		if ((((int32_t)L_15) < ((int32_t)0)))
		{
			goto IL_0060;
		}
	}
	{
		int32_t L_16 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_17 = ___0_data;
		NullCheck(L_17);
		int32_t L_18 = L_17->___keyCapacity;
		G_B9_0 = ((((int32_t)((((int32_t)L_16) < ((int32_t)L_18))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0061;
	}

IL_0060:
	{
		G_B9_0 = 1;
	}

IL_0061:
	{
		V_4 = (bool)G_B9_0;
		bool L_19 = V_4;
		if (!L_19)
		{
			goto IL_006c;
		}
	}
	{
		V_3 = (bool)0;
		goto IL_00c1;
	}

IL_006c:
	{
	}

IL_006d:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_20 = ___0_data;
		NullCheck(L_20);
		uint8_t* L_21 = L_20->___keys;
		int32_t L_22 = V_0;
		int32_t L_23;
		L_23 = UnsafeUtility_ReadArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_mFBA66C06ECEB0A2BC1AAE634B6E6BB436F957084_inline((void*)L_21, L_22, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		V_6 = L_23;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_24 = ___2_it;
		int32_t L_25 = L_24->___key;
		bool L_26;
		L_26 = Int32_Equals_mC819D19A661B95BE253FB1769FD4D91961D20722((&V_6), L_25, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 15));
		V_5 = (bool)((((int32_t)L_26) == ((int32_t)0))? 1 : 0);
		bool L_27 = V_5;
		if (L_27)
		{
			goto IL_0045;
		}
	}
	{
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_28 = ___2_it;
		int32_t* L_29 = V_1;
		int32_t L_30 = V_0;
		int32_t L_31 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_29, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_30), 4))))));
		L_28->___NextEntryIndex = L_31;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_32 = ___2_it;
		int32_t L_33 = V_0;
		L_32->___EntryIndex = L_33;
		BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C* L_34 = ___1_item;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_35 = ___0_data;
		NullCheck(L_35);
		uint8_t* L_36 = L_35->___values;
		int32_t L_37 = V_0;
		BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C L_38;
		L_38 = UnsafeUtility_ReadArrayElement_TisBatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C_mDE41FFE3160D153E47D8D93EF29E4B9C3DB23D20_inline((void*)L_36, L_37, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 17));
		*(BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C*)L_34 = L_38;
		V_3 = (bool)1;
		goto IL_00c1;
	}

IL_00c1:
	{
		bool L_39 = V_3;
		return L_39;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_SetValue_mB3E7DD8B2C317D36964E58651BDB743A541BE1E5_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___1_it, BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C* ___2_item, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	bool V_1 = false;
	bool V_2 = false;
	int32_t G_B3_0 = 0;
	{
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_0 = ___1_it;
		int32_t L_1 = L_0->___EntryIndex;
		V_0 = L_1;
		int32_t L_2 = V_0;
		if ((((int32_t)L_2) < ((int32_t)0)))
		{
			goto IL_001a;
		}
	}
	{
		int32_t L_3 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = ___0_data;
		NullCheck(L_4);
		int32_t L_5 = L_4->___keyCapacity;
		G_B3_0 = ((((int32_t)((((int32_t)L_3) < ((int32_t)L_5))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_001b;
	}

IL_001a:
	{
		G_B3_0 = 1;
	}

IL_001b:
	{
		V_1 = (bool)G_B3_0;
		bool L_6 = V_1;
		if (!L_6)
		{
			goto IL_0024;
		}
	}
	{
		V_2 = (bool)0;
		goto IL_003b;
	}

IL_0024:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		uint8_t* L_8 = L_7->___values;
		int32_t L_9 = V_0;
		BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C* L_10 = ___2_item;
		BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C L_11 = (*(BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C*)L_10);
		UnsafeUtility_WriteArrayElement_TisBatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C_m32FE612078445C09645A5FEFCADD35BF1B5497D3_inline((void*)L_8, L_9, L_11, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		V_2 = (bool)1;
		goto IL_003b;
	}

IL_003b:
	{
		bool L_12 = V_2;
		return L_12;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_Clear_m001273171056567D90F65A94742C26DB58F8B4DB_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	bool V_2 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___buckets;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		NullCheck(L_2);
		int32_t L_3 = L_2->___bucketCapacityMask;
		UnsafeUtility_MemSet_m4CD74CD43260EB2962A46F57E0D93DD5C332FC2B((void*)L_1, (uint8_t)((int32_t)255), ((int64_t)((int32_t)il2cpp_codegen_multiply(((int32_t)il2cpp_codegen_add(L_3, 1)), 4))), NULL);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = ___0_data;
		NullCheck(L_4);
		uint8_t* L_5 = L_4->___next;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_6 = ___0_data;
		NullCheck(L_6);
		int32_t L_7 = L_6->___keyCapacity;
		UnsafeUtility_MemSet_m4CD74CD43260EB2962A46F57E0D93DD5C332FC2B((void*)L_5, (uint8_t)((int32_t)255), ((int64_t)((int32_t)il2cpp_codegen_multiply(L_7, 4))), NULL);
		int32_t L_8;
		L_8 = JobsUtility_get_ThreadIndexCount_m88A954344398143540618B35943F863B92465676(NULL);
		V_0 = L_8;
		V_1 = 0;
		goto IL_0057;
	}

IL_0041:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_9 = ___0_data;
		int32_t* L_10;
		L_10 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_9, NULL);
		int32_t L_11 = V_1;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_10, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_11, ((int32_t)16)))), 4))))) = (int32_t)(-1);
		int32_t L_12 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_12, 1));
	}

IL_0057:
	{
		int32_t L_13 = V_1;
		int32_t L_14 = V_0;
		V_2 = (bool)((((int32_t)L_13) < ((int32_t)L_14))? 1 : 0);
		bool L_15 = V_2;
		if (L_15)
		{
			goto IL_0041;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_16 = ___0_data;
		NullCheck(L_16);
		L_16->___allocatedIndexLength = 0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapBase_2_AllocEntry_m8AD3BCA9FB9188688CEFCD9B8C98668A2AB7D334_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_threadIndex, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t* V_1 = NULL;
	bool V_2 = false;
	bool V_3 = false;
	int32_t V_4 = 0;
	bool V_5 = false;
	bool V_6 = false;
	bool V_7 = false;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	bool V_10 = false;
	int32_t V_11 = 0;
	bool V_12 = false;
	int32_t V_13 = 0;
	bool V_14 = false;
	bool V_15 = false;
	bool V_16 = false;
	bool V_17 = false;
	bool V_18 = false;
	bool V_19 = false;
	bool V_20 = false;
	bool V_21 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___next;
		V_1 = (int32_t*)L_1;
	}

IL_0008:
	{
	}

IL_0009:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		int32_t* L_3;
		L_3 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_2, NULL);
		int32_t L_4 = ___1_threadIndex;
		int32_t L_5;
		L_5 = VolatileRead((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_3, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_4, ((int32_t)16)))), 4)))));
		V_0 = L_5;
		int32_t L_6 = V_0;
		V_2 = (bool)((((int32_t)L_6) == ((int32_t)((int32_t)-3)))? 1 : 0);
		bool L_7 = V_2;
		if (L_7)
		{
			goto IL_0009;
		}
	}
	{
		int32_t L_8 = V_0;
		V_3 = (bool)((((int32_t)L_8) < ((int32_t)0))? 1 : 0);
		bool L_9 = V_3;
		if (!L_9)
		{
			goto IL_021e;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_10 = ___0_data;
		int32_t* L_11;
		L_11 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_10, NULL);
		int32_t L_12 = ___1_threadIndex;
		int32_t L_13;
		L_13 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_11, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_12, ((int32_t)16)))), 4)))), ((int32_t)-2), NULL);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_14 = ___0_data;
		NullCheck(L_14);
		int32_t L_15 = L_14->___allocatedIndexLength;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_16 = ___0_data;
		NullCheck(L_16);
		int32_t L_17 = L_16->___keyCapacity;
		V_6 = (bool)((((int32_t)L_15) < ((int32_t)L_17))? 1 : 0);
		bool L_18 = V_6;
		if (!L_18)
		{
			goto IL_0123;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_19 = ___0_data;
		NullCheck(L_19);
		int32_t* L_20 = (int32_t*)(&L_19->___allocatedIndexLength);
		int32_t L_21;
		L_21 = Interlocked_Add_m2455208C56EEFD8832AEAD8AF7368A3FEB33A73C(L_20, ((int32_t)16), NULL);
		V_0 = ((int32_t)il2cpp_codegen_subtract(L_21, ((int32_t)16)));
		int32_t L_22 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_23 = ___0_data;
		NullCheck(L_23);
		int32_t L_24 = L_23->___keyCapacity;
		V_7 = (bool)((((int32_t)L_22) < ((int32_t)((int32_t)il2cpp_codegen_subtract(L_24, 1))))? 1 : 0);
		bool L_25 = V_7;
		if (!L_25)
		{
			goto IL_00f3;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_26 = ___0_data;
		NullCheck(L_26);
		int32_t L_27 = L_26->___keyCapacity;
		int32_t L_28 = V_0;
		int32_t L_29;
		L_29 = math_min_m02D43DF516544C279AF660EA4731449C82991849_inline(((int32_t)16), ((int32_t)il2cpp_codegen_subtract(L_27, L_28)), NULL);
		V_8 = L_29;
		V_9 = 1;
		goto IL_00b3;
	}

IL_009b:
	{
		int32_t* L_30 = V_1;
		int32_t L_31 = V_0;
		int32_t L_32 = V_9;
		int32_t L_33 = V_0;
		int32_t L_34 = V_9;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_30, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_add(L_31, L_32))), 4))))) = (int32_t)((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_33, L_34)), 1));
		int32_t L_35 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add(L_35, 1));
	}

IL_00b3:
	{
		int32_t L_36 = V_9;
		int32_t L_37 = V_8;
		V_10 = (bool)((((int32_t)L_36) < ((int32_t)L_37))? 1 : 0);
		bool L_38 = V_10;
		if (L_38)
		{
			goto IL_009b;
		}
	}
	{
		int32_t* L_39 = V_1;
		int32_t L_40 = V_0;
		int32_t L_41 = V_8;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_39, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_40, L_41)), 1))), 4))))) = (int32_t)(-1);
		int32_t* L_42 = V_1;
		int32_t L_43 = V_0;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_42, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_43), 4))))) = (int32_t)(-1);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_44 = ___0_data;
		int32_t* L_45;
		L_45 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_44, NULL);
		int32_t L_46 = ___1_threadIndex;
		int32_t L_47 = V_0;
		int32_t L_48;
		L_48 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_45, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_46, ((int32_t)16)))), 4)))), ((int32_t)il2cpp_codegen_add(L_47, 1)), NULL);
		int32_t L_49 = V_0;
		V_11 = L_49;
		goto IL_026c;
	}

IL_00f3:
	{
		int32_t L_50 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_51 = ___0_data;
		NullCheck(L_51);
		int32_t L_52 = L_51->___keyCapacity;
		V_12 = (bool)((((int32_t)L_50) == ((int32_t)((int32_t)il2cpp_codegen_subtract(L_52, 1))))? 1 : 0);
		bool L_53 = V_12;
		if (!L_53)
		{
			goto IL_0122;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_54 = ___0_data;
		int32_t* L_55;
		L_55 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_54, NULL);
		int32_t L_56 = ___1_threadIndex;
		int32_t L_57;
		L_57 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_55, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_56, ((int32_t)16)))), 4)))), (-1), NULL);
		int32_t L_58 = V_0;
		V_11 = L_58;
		goto IL_026c;
	}

IL_0122:
	{
	}

IL_0123:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_59 = ___0_data;
		int32_t* L_60;
		L_60 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_59, NULL);
		int32_t L_61 = ___1_threadIndex;
		int32_t L_62;
		L_62 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_60, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_61, ((int32_t)16)))), 4)))), (-1), NULL);
		int32_t L_63;
		L_63 = JobsUtility_get_ThreadIndexCount_m88A954344398143540618B35943F863B92465676(NULL);
		V_4 = L_63;
		V_5 = (bool)1;
		goto IL_0212;
	}

IL_0147:
	{
		V_5 = (bool)0;
		int32_t L_64 = ___1_threadIndex;
		int32_t L_65 = V_4;
		V_13 = ((int32_t)(((int32_t)il2cpp_codegen_add(L_64, 1))%L_65));
		goto IL_0200;
	}

IL_0158:
	{
	}

IL_0159:
	{
	}

IL_015a:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_66 = ___0_data;
		int32_t* L_67;
		L_67 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_66, NULL);
		int32_t L_68 = V_13;
		int32_t L_69;
		L_69 = VolatileRead((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_67, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_68, ((int32_t)16)))), 4)))));
		V_0 = L_69;
		int32_t L_70 = V_0;
		V_14 = (bool)((((int32_t)L_70) == ((int32_t)((int32_t)-3)))? 1 : 0);
		bool L_71 = V_14;
		if (L_71)
		{
			goto IL_015a;
		}
	}
	{
		int32_t L_72 = V_0;
		V_15 = (bool)((((int32_t)L_72) < ((int32_t)0))? 1 : 0);
		bool L_73 = V_15;
		if (!L_73)
		{
			goto IL_0189;
		}
	}
	{
		goto IL_01ad;
	}

IL_0189:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_74 = ___0_data;
		int32_t* L_75;
		L_75 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_74, NULL);
		int32_t L_76 = V_13;
		int32_t L_77 = V_0;
		int32_t L_78;
		L_78 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_75, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_76, ((int32_t)16)))), 4)))), ((int32_t)-3), L_77, NULL);
		int32_t L_79 = V_0;
		V_16 = (bool)((((int32_t)((((int32_t)L_78) == ((int32_t)L_79))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_80 = V_16;
		if (L_80)
		{
			goto IL_0159;
		}
	}

IL_01ad:
	{
		int32_t L_81 = V_0;
		V_17 = (bool)((((int32_t)L_81) == ((int32_t)((int32_t)-2)))? 1 : 0);
		bool L_82 = V_17;
		if (!L_82)
		{
			goto IL_01bf;
		}
	}
	{
		V_5 = (bool)1;
		goto IL_01f6;
	}

IL_01bf:
	{
		int32_t L_83 = V_0;
		V_18 = (bool)((((int32_t)((((int32_t)L_83) < ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_84 = V_18;
		if (!L_84)
		{
			goto IL_01f6;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_85 = ___0_data;
		int32_t* L_86;
		L_86 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_85, NULL);
		int32_t L_87 = V_13;
		int32_t* L_88 = V_1;
		int32_t L_89 = V_0;
		int32_t L_90 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_88, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_89), 4))))));
		int32_t L_91;
		L_91 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_86, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_87, ((int32_t)16)))), 4)))), L_90, NULL);
		int32_t* L_92 = V_1;
		int32_t L_93 = V_0;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_92, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_93), 4))))) = (int32_t)(-1);
		int32_t L_94 = V_0;
		V_11 = L_94;
		goto IL_026c;
	}

IL_01f6:
	{
		int32_t L_95 = V_13;
		int32_t L_96 = V_4;
		V_13 = ((int32_t)(((int32_t)il2cpp_codegen_add(L_95, 1))%L_96));
	}

IL_0200:
	{
		int32_t L_97 = V_13;
		int32_t L_98 = ___1_threadIndex;
		V_19 = (bool)((((int32_t)((((int32_t)L_97) == ((int32_t)L_98))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_99 = V_19;
		if (L_99)
		{
			goto IL_0158;
		}
	}
	{
	}

IL_0212:
	{
		bool L_100 = V_5;
		V_20 = L_100;
		bool L_101 = V_20;
		if (L_101)
		{
			goto IL_0147;
		}
	}
	{
	}

IL_021e:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_102 = ___0_data;
		int32_t* L_103;
		L_103 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_102, NULL);
		int32_t L_104 = ___1_threadIndex;
		int32_t L_105 = V_0;
		int32_t L_106;
		L_106 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_103, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_104, ((int32_t)16)))), 4)))), ((int32_t)-3), L_105, NULL);
		int32_t L_107 = V_0;
		V_21 = (bool)((((int32_t)((((int32_t)L_106) == ((int32_t)L_107))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_108 = V_21;
		if (L_108)
		{
			goto IL_0008;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_109 = ___0_data;
		int32_t* L_110;
		L_110 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_109, NULL);
		int32_t L_111 = ___1_threadIndex;
		int32_t* L_112 = V_1;
		int32_t L_113 = V_0;
		int32_t L_114 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_112, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_113), 4))))));
		int32_t L_115;
		L_115 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_110, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_111, ((int32_t)16)))), 4)))), L_114, NULL);
		int32_t* L_116 = V_1;
		int32_t L_117 = V_0;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_116, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_117), 4))))) = (int32_t)(-1);
		int32_t L_118 = V_0;
		V_11 = L_118;
		goto IL_026c;
	}

IL_026c:
	{
		int32_t L_119 = V_11;
		return L_119;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_FreeEntry_m68049D0DC47E97C465D43753CAAFAF997DE7804C_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_idx, int32_t ___2_threadIndex, const RuntimeMethod* method) 
{
	int32_t* V_0 = NULL;
	int32_t V_1 = 0;
	bool V_2 = false;
	bool V_3 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___next;
		V_0 = (int32_t*)L_1;
		V_1 = (-1);
	}

IL_000a:
	{
	}

IL_000b:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		int32_t* L_3;
		L_3 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_2, NULL);
		int32_t L_4 = ___2_threadIndex;
		int32_t L_5;
		L_5 = VolatileRead((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_3, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_4, ((int32_t)16)))), 4)))));
		V_1 = L_5;
		int32_t L_6 = V_1;
		V_2 = (bool)((((int32_t)L_6) == ((int32_t)((int32_t)-3)))? 1 : 0);
		bool L_7 = V_2;
		if (L_7)
		{
			goto IL_000b;
		}
	}
	{
		int32_t* L_8 = V_0;
		int32_t L_9 = ___1_idx;
		int32_t L_10 = V_1;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_8, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_9), 4))))) = (int32_t)L_10;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_11 = ___0_data;
		int32_t* L_12;
		L_12 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_11, NULL);
		int32_t L_13 = ___2_threadIndex;
		int32_t L_14 = ___1_idx;
		int32_t L_15 = V_1;
		int32_t L_16;
		L_16 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_12, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_13, ((int32_t)16)))), 4)))), L_14, L_15, NULL);
		int32_t L_17 = V_1;
		V_3 = (bool)((((int32_t)((((int32_t)L_16) == ((int32_t)L_17))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_18 = V_3;
		if (L_18)
		{
			goto IL_000a;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryAddAtomic_m9CA9E7EEB3BF9AB42EA2D5B3B510F8B6617FB163_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0 ___2_item, int32_t ___3_threadIndex, const RuntimeMethod* method) 
{
	BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0 V_0;
	memset((&V_0), 0, sizeof(V_0));
	NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC V_1;
	memset((&V_1), 0, sizeof(V_1));
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	int32_t* V_4 = NULL;
	bool V_5 = false;
	bool V_6 = false;
	bool V_7 = false;
	int32_t* V_8 = NULL;
	int32_t V_9 = 0;
	bool V_10 = false;
	bool V_11 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		int32_t L_1 = ___1_key;
		bool L_2;
		L_2 = UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_m0A1550FEB428909B2E587F9AA67DD634D414D678(L_0, L_1, (&V_0), (&V_1), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_5 = L_2;
		bool L_3 = V_5;
		if (!L_3)
		{
			goto IL_001b;
		}
	}
	{
		V_6 = (bool)0;
		goto IL_00da;
	}

IL_001b:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = ___0_data;
		int32_t L_5 = ___3_threadIndex;
		int32_t L_6;
		L_6 = UnsafeParallelHashMapBase_2_AllocEntry_m8AD3BCA9FB9188688CEFCD9B8C98668A2AB7D334(L_4, L_5, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		V_2 = L_6;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		uint8_t* L_8 = L_7->___keys;
		int32_t L_9 = V_2;
		int32_t L_10 = ___1_key;
		UnsafeUtility_WriteArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m0DD1CC90B2F1EF5041F2F4E1DABB58224229F0D7_inline((void*)L_8, L_9, L_10, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 6));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_11 = ___0_data;
		NullCheck(L_11);
		uint8_t* L_12 = L_11->___values;
		int32_t L_13 = V_2;
		BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0 L_14 = ___2_item;
		UnsafeUtility_WriteArrayElement_TisBatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0_m0CA08285DF610E216621F21C754D8D5E56428B01_inline((void*)L_12, L_13, L_14, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		int32_t L_15;
		L_15 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_16 = ___0_data;
		NullCheck(L_16);
		int32_t L_17 = L_16->___bucketCapacityMask;
		V_3 = ((int32_t)(L_15&L_17));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_18 = ___0_data;
		NullCheck(L_18);
		uint8_t* L_19 = L_18->___buckets;
		V_4 = (int32_t*)L_19;
		int32_t* L_20 = V_4;
		int32_t L_21 = V_3;
		int32_t L_22 = V_2;
		int32_t L_23;
		L_23 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_20, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_21), 4)))), L_22, (-1), NULL);
		V_7 = (bool)((((int32_t)((((int32_t)L_23) == ((int32_t)(-1)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_24 = V_7;
		if (!L_24)
		{
			goto IL_00d5;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_25 = ___0_data;
		NullCheck(L_25);
		uint8_t* L_26 = L_25->___next;
		V_8 = (int32_t*)L_26;
		V_9 = (-1);
	}

IL_0082:
	{
		int32_t* L_27 = V_4;
		int32_t L_28 = V_3;
		int32_t L_29 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_27, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_28), 4))))));
		V_9 = L_29;
		int32_t* L_30 = V_8;
		int32_t L_31 = V_2;
		int32_t L_32 = V_9;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_30, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_31), 4))))) = (int32_t)L_32;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_33 = ___0_data;
		int32_t L_34 = ___1_key;
		bool L_35;
		L_35 = UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_m0A1550FEB428909B2E587F9AA67DD634D414D678(L_33, L_34, (&V_0), (&V_1), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_10 = L_35;
		bool L_36 = V_10;
		if (!L_36)
		{
			goto IL_00b7;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_37 = ___0_data;
		int32_t L_38 = V_2;
		int32_t L_39 = ___3_threadIndex;
		UnsafeParallelHashMapBase_2_FreeEntry_m68049D0DC47E97C465D43753CAAFAF997DE7804C(L_37, L_38, L_39, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 10));
		V_6 = (bool)0;
		goto IL_00da;
	}

IL_00b7:
	{
		int32_t* L_40 = V_4;
		int32_t L_41 = V_3;
		int32_t L_42 = V_2;
		int32_t L_43 = V_9;
		int32_t L_44;
		L_44 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_40, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_41), 4)))), L_42, L_43, NULL);
		int32_t L_45 = V_9;
		V_11 = (bool)((((int32_t)((((int32_t)L_44) == ((int32_t)L_45))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_46 = V_11;
		if (L_46)
		{
			goto IL_0082;
		}
	}
	{
	}

IL_00d5:
	{
		V_6 = (bool)1;
		goto IL_00da;
	}

IL_00da:
	{
		bool L_47 = V_6;
		return L_47;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryAdd_m4849AB2C4383F884449A7D99D188F392790E619A_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0 ___2_item, bool ___3_isMultiHashMap, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___4_allocation, const RuntimeMethod* method) 
{
	BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0 V_0;
	memset((&V_0), 0, sizeof(V_0));
	NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC V_1;
	memset((&V_1), 0, sizeof(V_1));
	bool V_2 = false;
	int32_t V_3 = 0;
	int32_t* V_4 = NULL;
	int32_t V_5 = 0;
	int32_t* V_6 = NULL;
	bool V_7 = false;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	bool V_10 = false;
	bool V_11 = false;
	bool V_12 = false;
	int32_t V_13 = 0;
	bool V_14 = false;
	int32_t V_15 = 0;
	bool V_16 = false;
	int32_t G_B3_0 = 0;
	int32_t G_B7_0 = 0;
	{
		bool L_0 = ___3_isMultiHashMap;
		if (L_0)
		{
			goto IL_0014;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_1 = ___0_data;
		int32_t L_2 = ___1_key;
		bool L_3;
		L_3 = UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_m0A1550FEB428909B2E587F9AA67DD634D414D678(L_1, L_2, (&V_0), (&V_1), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		G_B3_0 = ((((int32_t)L_3) == ((int32_t)0))? 1 : 0);
		goto IL_0015;
	}

IL_0014:
	{
		G_B3_0 = 1;
	}

IL_0015:
	{
		V_2 = (bool)G_B3_0;
		bool L_4 = V_2;
		if (!L_4)
		{
			goto IL_0197;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_5 = ___0_data;
		NullCheck(L_5);
		int32_t L_6 = L_5->___allocatedIndexLength;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		int32_t L_8 = L_7->___keyCapacity;
		if ((((int32_t)L_6) < ((int32_t)L_8)))
		{
			goto IL_0037;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_9 = ___0_data;
		int32_t* L_10;
		L_10 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_9, NULL);
		int32_t L_11 = (*(L_10));
		G_B7_0 = ((((int32_t)L_11) < ((int32_t)0))? 1 : 0);
		goto IL_0038;
	}

IL_0037:
	{
		G_B7_0 = 0;
	}

IL_0038:
	{
		V_7 = (bool)G_B7_0;
		bool L_12 = V_7;
		if (!L_12)
		{
			goto IL_00f5;
		}
	}
	{
		int32_t L_13;
		L_13 = JobsUtility_get_ThreadIndexCount_m88A954344398143540618B35943F863B92465676(NULL);
		V_8 = L_13;
		V_9 = 1;
		goto IL_00b7;
	}

IL_004e:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_14 = ___0_data;
		int32_t* L_15;
		L_15 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_14, NULL);
		int32_t L_16 = V_9;
		int32_t L_17 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_15, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_16, ((int32_t)16)))), 4))))));
		V_10 = (bool)((((int32_t)((((int32_t)L_17) < ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_18 = V_10;
		if (!L_18)
		{
			goto IL_00b0;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_19 = ___0_data;
		int32_t* L_20;
		L_20 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_19, NULL);
		int32_t L_21 = V_9;
		int32_t L_22 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_20, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_21, ((int32_t)16)))), 4))))));
		V_3 = L_22;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_23 = ___0_data;
		NullCheck(L_23);
		uint8_t* L_24 = L_23->___next;
		V_4 = (int32_t*)L_24;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_25 = ___0_data;
		int32_t* L_26;
		L_26 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_25, NULL);
		int32_t L_27 = V_9;
		int32_t* L_28 = V_4;
		int32_t L_29 = V_3;
		int32_t L_30 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_28, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_29), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_26, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_27, ((int32_t)16)))), 4))))) = (int32_t)L_30;
		int32_t* L_31 = V_4;
		int32_t L_32 = V_3;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_31, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_32), 4))))) = (int32_t)(-1);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_33 = ___0_data;
		int32_t* L_34;
		L_34 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_33, NULL);
		int32_t L_35 = V_3;
		*((int32_t*)L_34) = (int32_t)L_35;
		goto IL_00c3;
	}

IL_00b0:
	{
		int32_t L_36 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add(L_36, 1));
	}

IL_00b7:
	{
		int32_t L_37 = V_9;
		int32_t L_38 = V_8;
		V_11 = (bool)((((int32_t)L_37) < ((int32_t)L_38))? 1 : 0);
		bool L_39 = V_11;
		if (L_39)
		{
			goto IL_004e;
		}
	}

IL_00c3:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_40 = ___0_data;
		int32_t* L_41;
		L_41 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_40, NULL);
		int32_t L_42 = (*(L_41));
		V_12 = (bool)((((int32_t)L_42) < ((int32_t)0))? 1 : 0);
		bool L_43 = V_12;
		if (!L_43)
		{
			goto IL_00f4;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_44 = ___0_data;
		NullCheck(L_44);
		int32_t L_45 = L_44->___keyCapacity;
		int32_t L_46;
		L_46 = UnsafeParallelHashMapData_GrowCapacity_m7F2FF57E76510A99266830779059C6C202B9EC47(L_45, NULL);
		V_13 = L_46;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_47 = ___0_data;
		int32_t L_48 = V_13;
		int32_t L_49 = V_13;
		int32_t L_50;
		L_50 = UnsafeParallelHashMapData_GetBucketSize_mEF90FF75EFE70E4B59CD6AF9FDCB3D564A1986A3(L_49, NULL);
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_51 = ___4_allocation;
		UnsafeParallelHashMapData_ReallocateHashMap_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_TisBatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0_m7276C3EA10AA4289184C4478EC7CE69B78E70B2C(L_47, L_48, L_50, L_51, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
	}

IL_00f4:
	{
	}

IL_00f5:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_52 = ___0_data;
		int32_t* L_53;
		L_53 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_52, NULL);
		int32_t L_54 = (*(L_53));
		V_3 = L_54;
		int32_t L_55 = V_3;
		V_14 = (bool)((((int32_t)((((int32_t)L_55) < ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_56 = V_14;
		if (!L_56)
		{
			goto IL_0121;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_57 = ___0_data;
		int32_t* L_58;
		L_58 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_57, NULL);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_59 = ___0_data;
		NullCheck(L_59);
		uint8_t* L_60 = L_59->___next;
		int32_t L_61 = V_3;
		int32_t L_62 = *((int32_t*)((uint8_t*)il2cpp_codegen_add((intptr_t)L_60, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_61), 4)))));
		*((int32_t*)L_58) = (int32_t)L_62;
		goto IL_0135;
	}

IL_0121:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_63 = ___0_data;
		NullCheck(L_63);
		int32_t* L_64 = (int32_t*)(&L_63->___allocatedIndexLength);
		int32_t* L_65 = L_64;
		int32_t L_66 = *((int32_t*)L_65);
		V_15 = L_66;
		int32_t L_67 = V_15;
		*((int32_t*)L_65) = (int32_t)((int32_t)il2cpp_codegen_add(L_67, 1));
		int32_t L_68 = V_15;
		V_3 = L_68;
	}

IL_0135:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_69 = ___0_data;
		NullCheck(L_69);
		uint8_t* L_70 = L_69->___keys;
		int32_t L_71 = V_3;
		int32_t L_72 = ___1_key;
		UnsafeUtility_WriteArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m0DD1CC90B2F1EF5041F2F4E1DABB58224229F0D7_inline((void*)L_70, L_71, L_72, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 6));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_73 = ___0_data;
		NullCheck(L_73);
		uint8_t* L_74 = L_73->___values;
		int32_t L_75 = V_3;
		BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0 L_76 = ___2_item;
		UnsafeUtility_WriteArrayElement_TisBatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0_m0CA08285DF610E216621F21C754D8D5E56428B01_inline((void*)L_74, L_75, L_76, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		int32_t L_77;
		L_77 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_78 = ___0_data;
		NullCheck(L_78);
		int32_t L_79 = L_78->___bucketCapacityMask;
		V_5 = ((int32_t)(L_77&L_79));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_80 = ___0_data;
		NullCheck(L_80);
		uint8_t* L_81 = L_80->___buckets;
		V_6 = (int32_t*)L_81;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_82 = ___0_data;
		NullCheck(L_82);
		uint8_t* L_83 = L_82->___next;
		V_4 = (int32_t*)L_83;
		int32_t* L_84 = V_4;
		int32_t L_85 = V_3;
		int32_t* L_86 = V_6;
		int32_t L_87 = V_5;
		int32_t L_88 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_86, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_87), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_84, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_85), 4))))) = (int32_t)L_88;
		int32_t* L_89 = V_6;
		int32_t L_90 = V_5;
		int32_t L_91 = V_3;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_89, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_90), 4))))) = (int32_t)L_91;
		V_16 = (bool)1;
		goto IL_019c;
	}

IL_0197:
	{
		V_16 = (bool)0;
		goto IL_019c;
	}

IL_019c:
	{
		bool L_92 = V_16;
		return L_92;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapBase_2_Remove_m494397DB04F39E75798DB2AB0FFA134A7D2D72A8_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, bool ___2_isMultiHashMap, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t* V_1 = NULL;
	int32_t* V_2 = NULL;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	bool V_6 = false;
	int32_t V_7 = 0;
	bool V_8 = false;
	int32_t V_9 = 0;
	int32_t V_10 = 0;
	bool V_11 = false;
	bool V_12 = false;
	bool V_13 = false;
	int32_t G_B15_0 = 0;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		int32_t L_1 = L_0->___keyCapacity;
		V_6 = (bool)((((int32_t)L_1) == ((int32_t)0))? 1 : 0);
		bool L_2 = V_6;
		if (!L_2)
		{
			goto IL_0019;
		}
	}
	{
		V_7 = 0;
		goto IL_010f;
	}

IL_0019:
	{
		V_0 = 0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_3 = ___0_data;
		NullCheck(L_3);
		uint8_t* L_4 = L_3->___buckets;
		V_1 = (int32_t*)L_4;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_5 = ___0_data;
		NullCheck(L_5);
		uint8_t* L_6 = L_5->___next;
		V_2 = (int32_t*)L_6;
		int32_t L_7;
		L_7 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_8 = ___0_data;
		NullCheck(L_8);
		int32_t L_9 = L_8->___bucketCapacityMask;
		V_3 = ((int32_t)(L_7&L_9));
		V_4 = (-1);
		int32_t* L_10 = V_1;
		int32_t L_11 = V_3;
		int32_t L_12 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_10, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_11), 4))))));
		V_5 = L_12;
		goto IL_00ef;
	}

IL_004f:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_13 = ___0_data;
		NullCheck(L_13);
		uint8_t* L_14 = L_13->___keys;
		int32_t L_15 = V_5;
		int32_t L_16;
		L_16 = UnsafeUtility_ReadArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_mFBA66C06ECEB0A2BC1AAE634B6E6BB436F957084_inline((void*)L_14, L_15, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		V_9 = L_16;
		int32_t L_17 = ___1_key;
		bool L_18;
		L_18 = Int32_Equals_mC819D19A661B95BE253FB1769FD4D91961D20722((&V_9), L_17, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 15));
		V_8 = L_18;
		bool L_19 = V_8;
		if (!L_19)
		{
			goto IL_00de;
		}
	}
	{
		int32_t L_20 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add(L_20, 1));
		int32_t L_21 = V_4;
		V_11 = (bool)((((int32_t)L_21) < ((int32_t)0))? 1 : 0);
		bool L_22 = V_11;
		if (!L_22)
		{
			goto IL_0096;
		}
	}
	{
		int32_t* L_23 = V_1;
		int32_t L_24 = V_3;
		int32_t* L_25 = V_2;
		int32_t L_26 = V_5;
		int32_t L_27 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_25, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_26), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_23, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_24), 4))))) = (int32_t)L_27;
		goto IL_00a8;
	}

IL_0096:
	{
		int32_t* L_28 = V_2;
		int32_t L_29 = V_4;
		int32_t* L_30 = V_2;
		int32_t L_31 = V_5;
		int32_t L_32 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_30, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_31), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_28, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_29), 4))))) = (int32_t)L_32;
	}

IL_00a8:
	{
		int32_t* L_33 = V_2;
		int32_t L_34 = V_5;
		int32_t L_35 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_33, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_34), 4))))));
		V_10 = L_35;
		int32_t* L_36 = V_2;
		int32_t L_37 = V_5;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_38 = ___0_data;
		int32_t* L_39;
		L_39 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_38, NULL);
		int32_t L_40 = (*(L_39));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_36, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_37), 4))))) = (int32_t)L_40;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_41 = ___0_data;
		int32_t* L_42;
		L_42 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_41, NULL);
		int32_t L_43 = V_5;
		*((int32_t*)L_42) = (int32_t)L_43;
		int32_t L_44 = V_10;
		V_5 = L_44;
		bool L_45 = ___2_isMultiHashMap;
		V_12 = (bool)((((int32_t)L_45) == ((int32_t)0))? 1 : 0);
		bool L_46 = V_12;
		if (!L_46)
		{
			goto IL_00db;
		}
	}
	{
		goto IL_010a;
	}

IL_00db:
	{
		goto IL_00ee;
	}

IL_00de:
	{
		int32_t L_47 = V_5;
		V_4 = L_47;
		int32_t* L_48 = V_2;
		int32_t L_49 = V_5;
		int32_t L_50 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_48, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_49), 4))))));
		V_5 = L_50;
	}

IL_00ee:
	{
	}

IL_00ef:
	{
		int32_t L_51 = V_5;
		if ((((int32_t)L_51) < ((int32_t)0)))
		{
			goto IL_0100;
		}
	}
	{
		int32_t L_52 = V_5;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_53 = ___0_data;
		NullCheck(L_53);
		int32_t L_54 = L_53->___keyCapacity;
		G_B15_0 = ((((int32_t)L_52) < ((int32_t)L_54))? 1 : 0);
		goto IL_0101;
	}

IL_0100:
	{
		G_B15_0 = 0;
	}

IL_0101:
	{
		V_13 = (bool)G_B15_0;
		bool L_55 = V_13;
		if (L_55)
		{
			goto IL_004f;
		}
	}

IL_010a:
	{
		int32_t L_56 = V_0;
		V_7 = L_56;
		goto IL_010f;
	}

IL_010f:
	{
		int32_t L_57 = V_7;
		return L_57;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_Remove_m9EA3CAE57EFD8BBDCE9D46B0CD3E4889FEFDE6FB_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC ___1_it, const RuntimeMethod* method) 
{
	int32_t* V_0 = NULL;
	int32_t* V_1 = NULL;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	bool V_4 = false;
	bool V_5 = false;
	bool V_6 = false;
	int32_t G_B7_0 = 0;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___buckets;
		V_0 = (int32_t*)L_1;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		NullCheck(L_2);
		uint8_t* L_3 = L_2->___next;
		V_1 = (int32_t*)L_3;
		int32_t* L_4 = (int32_t*)(&(&___1_it)->___key);
		int32_t L_5;
		L_5 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295(L_4, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_6 = ___0_data;
		NullCheck(L_6);
		int32_t L_7 = L_6->___bucketCapacityMask;
		V_2 = ((int32_t)(L_5&L_7));
		int32_t* L_8 = V_0;
		int32_t L_9 = V_2;
		int32_t L_10 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_8, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_9), 4))))));
		V_3 = L_10;
		int32_t L_11 = V_3;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC L_12 = ___1_it;
		int32_t L_13 = L_12.___EntryIndex;
		V_4 = (bool)((((int32_t)L_11) == ((int32_t)L_13))? 1 : 0);
		bool L_14 = V_4;
		if (!L_14)
		{
			goto IL_0052;
		}
	}
	{
		int32_t* L_15 = V_0;
		int32_t L_16 = V_2;
		int32_t* L_17 = V_1;
		int32_t L_18 = V_3;
		int32_t L_19 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_17, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_18), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_15, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_16), 4))))) = (int32_t)L_19;
		goto IL_009e;
	}

IL_0052:
	{
		goto IL_005f;
	}

IL_0055:
	{
		int32_t* L_20 = V_1;
		int32_t L_21 = V_3;
		int32_t L_22 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_20, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_21), 4))))));
		V_3 = L_22;
	}

IL_005f:
	{
		int32_t L_23 = V_3;
		if ((((int32_t)L_23) < ((int32_t)0)))
		{
			goto IL_0077;
		}
	}
	{
		int32_t* L_24 = V_1;
		int32_t L_25 = V_3;
		int32_t L_26 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_24, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_25), 4))))));
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC L_27 = ___1_it;
		int32_t L_28 = L_27.___EntryIndex;
		G_B7_0 = ((((int32_t)((((int32_t)L_26) == ((int32_t)L_28))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0078;
	}

IL_0077:
	{
		G_B7_0 = 0;
	}

IL_0078:
	{
		V_5 = (bool)G_B7_0;
		bool L_29 = V_5;
		if (L_29)
		{
			goto IL_0055;
		}
	}
	{
		int32_t L_30 = V_3;
		V_6 = (bool)((((int32_t)L_30) < ((int32_t)0))? 1 : 0);
		bool L_31 = V_6;
		if (!L_31)
		{
			goto IL_008a;
		}
	}
	{
	}

IL_008a:
	{
		int32_t* L_32 = V_1;
		int32_t L_33 = V_3;
		int32_t* L_34 = V_1;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC L_35 = ___1_it;
		int32_t L_36 = L_35.___EntryIndex;
		int32_t L_37 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_34, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_36), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_32, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_33), 4))))) = (int32_t)L_37;
	}

IL_009e:
	{
		int32_t* L_38 = V_1;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC L_39 = ___1_it;
		int32_t L_40 = L_39.___EntryIndex;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_41 = ___0_data;
		int32_t* L_42;
		L_42 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_41, NULL);
		int32_t L_43 = (*(L_42));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_38, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_40), 4))))) = (int32_t)L_43;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_44 = ___0_data;
		int32_t* L_45;
		L_45 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_44, NULL);
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC L_46 = ___1_it;
		int32_t L_47 = L_46.___EntryIndex;
		*((int32_t*)L_45) = (int32_t)L_47;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_m0A1550FEB428909B2E587F9AA67DD634D414D678_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0* ___2_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___3_it, const RuntimeMethod* method) 
{
	int32_t* V_0 = NULL;
	int32_t V_1 = 0;
	bool V_2 = false;
	int32_t V_3 = 0;
	bool V_4 = false;
	{
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_0 = ___3_it;
		int32_t L_1 = ___1_key;
		L_0->___key = L_1;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		NullCheck(L_2);
		int32_t L_3 = L_2->___allocatedIndexLength;
		V_2 = (bool)((((int32_t)((((int32_t)L_3) > ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_4 = V_2;
		if (!L_4)
		{
			goto IL_0035;
		}
	}
	{
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_5 = ___3_it;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_6 = ___3_it;
		int32_t L_7 = (-1);
		V_3 = L_7;
		L_6->___NextEntryIndex = L_7;
		int32_t L_8 = V_3;
		L_5->___EntryIndex = L_8;
		BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0* L_9 = ___2_item;
		il2cpp_codegen_initobj(L_9, sizeof(BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0));
		V_4 = (bool)0;
		goto IL_0073;
	}

IL_0035:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_10 = ___0_data;
		NullCheck(L_10);
		uint8_t* L_11 = L_10->___buckets;
		V_0 = (int32_t*)L_11;
		int32_t L_12;
		L_12 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_13 = ___0_data;
		NullCheck(L_13);
		int32_t L_14 = L_13->___bucketCapacityMask;
		V_1 = ((int32_t)(L_12&L_14));
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_15 = ___3_it;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_16 = ___3_it;
		int32_t* L_17 = V_0;
		int32_t L_18 = V_1;
		int32_t L_19 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_17, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_18), 4))))));
		int32_t L_20 = L_19;
		V_3 = L_20;
		L_16->___NextEntryIndex = L_20;
		int32_t L_21 = V_3;
		L_15->___EntryIndex = L_21;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_22 = ___0_data;
		BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0* L_23 = ___2_item;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_24 = ___3_it;
		bool L_25;
		L_25 = UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_mAC37A0DE4D5678D35DF0C57E71A79D74CB486CAE(L_22, L_23, L_24, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 16));
		V_4 = L_25;
		goto IL_0073;
	}

IL_0073:
	{
		bool L_26 = V_4;
		return L_26;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_mAC37A0DE4D5678D35DF0C57E71A79D74CB486CAE_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0* ___1_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___2_it, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t* V_1 = NULL;
	bool V_2 = false;
	bool V_3 = false;
	bool V_4 = false;
	bool V_5 = false;
	int32_t V_6 = 0;
	int32_t G_B3_0 = 0;
	int32_t G_B9_0 = 0;
	{
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_0 = ___2_it;
		int32_t L_1 = L_0->___NextEntryIndex;
		V_0 = L_1;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_2 = ___2_it;
		L_2->___NextEntryIndex = (-1);
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_3 = ___2_it;
		L_3->___EntryIndex = (-1);
		BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0* L_4 = ___1_item;
		il2cpp_codegen_initobj(L_4, sizeof(BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0));
		int32_t L_5 = V_0;
		if ((((int32_t)L_5) < ((int32_t)0)))
		{
			goto IL_002f;
		}
	}
	{
		int32_t L_6 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		int32_t L_8 = L_7->___keyCapacity;
		G_B3_0 = ((((int32_t)((((int32_t)L_6) < ((int32_t)L_8))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0030;
	}

IL_002f:
	{
		G_B3_0 = 1;
	}

IL_0030:
	{
		V_2 = (bool)G_B3_0;
		bool L_9 = V_2;
		if (!L_9)
		{
			goto IL_003c;
		}
	}
	{
		V_3 = (bool)0;
		goto IL_00c1;
	}

IL_003c:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_10 = ___0_data;
		NullCheck(L_10);
		uint8_t* L_11 = L_10->___next;
		V_1 = (int32_t*)L_11;
		goto IL_006d;
	}

IL_0045:
	{
		int32_t* L_12 = V_1;
		int32_t L_13 = V_0;
		int32_t L_14 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_12, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_13), 4))))));
		V_0 = L_14;
		int32_t L_15 = V_0;
		if ((((int32_t)L_15) < ((int32_t)0)))
		{
			goto IL_0060;
		}
	}
	{
		int32_t L_16 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_17 = ___0_data;
		NullCheck(L_17);
		int32_t L_18 = L_17->___keyCapacity;
		G_B9_0 = ((((int32_t)((((int32_t)L_16) < ((int32_t)L_18))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0061;
	}

IL_0060:
	{
		G_B9_0 = 1;
	}

IL_0061:
	{
		V_4 = (bool)G_B9_0;
		bool L_19 = V_4;
		if (!L_19)
		{
			goto IL_006c;
		}
	}
	{
		V_3 = (bool)0;
		goto IL_00c1;
	}

IL_006c:
	{
	}

IL_006d:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_20 = ___0_data;
		NullCheck(L_20);
		uint8_t* L_21 = L_20->___keys;
		int32_t L_22 = V_0;
		int32_t L_23;
		L_23 = UnsafeUtility_ReadArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_mFBA66C06ECEB0A2BC1AAE634B6E6BB436F957084_inline((void*)L_21, L_22, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		V_6 = L_23;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_24 = ___2_it;
		int32_t L_25 = L_24->___key;
		bool L_26;
		L_26 = Int32_Equals_mC819D19A661B95BE253FB1769FD4D91961D20722((&V_6), L_25, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 15));
		V_5 = (bool)((((int32_t)L_26) == ((int32_t)0))? 1 : 0);
		bool L_27 = V_5;
		if (L_27)
		{
			goto IL_0045;
		}
	}
	{
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_28 = ___2_it;
		int32_t* L_29 = V_1;
		int32_t L_30 = V_0;
		int32_t L_31 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_29, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_30), 4))))));
		L_28->___NextEntryIndex = L_31;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_32 = ___2_it;
		int32_t L_33 = V_0;
		L_32->___EntryIndex = L_33;
		BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0* L_34 = ___1_item;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_35 = ___0_data;
		NullCheck(L_35);
		uint8_t* L_36 = L_35->___values;
		int32_t L_37 = V_0;
		BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0 L_38;
		L_38 = UnsafeUtility_ReadArrayElement_TisBatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0_mD0CAE37D791EB711A170B7F9BDCEAB6ED472C3E3_inline((void*)L_36, L_37, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 17));
		*(BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0*)L_34 = L_38;
		V_3 = (bool)1;
		goto IL_00c1;
	}

IL_00c1:
	{
		bool L_39 = V_3;
		return L_39;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_SetValue_m46272B735CECDC1EBF0556FC8443F8D1C77BD881_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___1_it, BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0* ___2_item, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	bool V_1 = false;
	bool V_2 = false;
	int32_t G_B3_0 = 0;
	{
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_0 = ___1_it;
		int32_t L_1 = L_0->___EntryIndex;
		V_0 = L_1;
		int32_t L_2 = V_0;
		if ((((int32_t)L_2) < ((int32_t)0)))
		{
			goto IL_001a;
		}
	}
	{
		int32_t L_3 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = ___0_data;
		NullCheck(L_4);
		int32_t L_5 = L_4->___keyCapacity;
		G_B3_0 = ((((int32_t)((((int32_t)L_3) < ((int32_t)L_5))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_001b;
	}

IL_001a:
	{
		G_B3_0 = 1;
	}

IL_001b:
	{
		V_1 = (bool)G_B3_0;
		bool L_6 = V_1;
		if (!L_6)
		{
			goto IL_0024;
		}
	}
	{
		V_2 = (bool)0;
		goto IL_003b;
	}

IL_0024:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		uint8_t* L_8 = L_7->___values;
		int32_t L_9 = V_0;
		BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0* L_10 = ___2_item;
		BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0 L_11 = (*(BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0*)L_10);
		UnsafeUtility_WriteArrayElement_TisBatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0_m0CA08285DF610E216621F21C754D8D5E56428B01_inline((void*)L_8, L_9, L_11, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		V_2 = (bool)1;
		goto IL_003b;
	}

IL_003b:
	{
		bool L_12 = V_2;
		return L_12;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_Clear_m197BCFCF26F8E531B55F40781262127A4EC5CB6D_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	bool V_2 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___buckets;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		NullCheck(L_2);
		int32_t L_3 = L_2->___bucketCapacityMask;
		UnsafeUtility_MemSet_m4CD74CD43260EB2962A46F57E0D93DD5C332FC2B((void*)L_1, (uint8_t)((int32_t)255), ((int64_t)((int32_t)il2cpp_codegen_multiply(((int32_t)il2cpp_codegen_add(L_3, 1)), 4))), NULL);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = ___0_data;
		NullCheck(L_4);
		uint8_t* L_5 = L_4->___next;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_6 = ___0_data;
		NullCheck(L_6);
		int32_t L_7 = L_6->___keyCapacity;
		UnsafeUtility_MemSet_m4CD74CD43260EB2962A46F57E0D93DD5C332FC2B((void*)L_5, (uint8_t)((int32_t)255), ((int64_t)((int32_t)il2cpp_codegen_multiply(L_7, 4))), NULL);
		int32_t L_8;
		L_8 = JobsUtility_get_ThreadIndexCount_m88A954344398143540618B35943F863B92465676(NULL);
		V_0 = L_8;
		V_1 = 0;
		goto IL_0057;
	}

IL_0041:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_9 = ___0_data;
		int32_t* L_10;
		L_10 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_9, NULL);
		int32_t L_11 = V_1;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_10, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_11, ((int32_t)16)))), 4))))) = (int32_t)(-1);
		int32_t L_12 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_12, 1));
	}

IL_0057:
	{
		int32_t L_13 = V_1;
		int32_t L_14 = V_0;
		V_2 = (bool)((((int32_t)L_13) < ((int32_t)L_14))? 1 : 0);
		bool L_15 = V_2;
		if (L_15)
		{
			goto IL_0041;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_16 = ___0_data;
		NullCheck(L_16);
		L_16->___allocatedIndexLength = 0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapBase_2_AllocEntry_mA6D1BF0531A4B163ED154D98E5AC42EBF6BA5F3D_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_threadIndex, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t* V_1 = NULL;
	bool V_2 = false;
	bool V_3 = false;
	int32_t V_4 = 0;
	bool V_5 = false;
	bool V_6 = false;
	bool V_7 = false;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	bool V_10 = false;
	int32_t V_11 = 0;
	bool V_12 = false;
	int32_t V_13 = 0;
	bool V_14 = false;
	bool V_15 = false;
	bool V_16 = false;
	bool V_17 = false;
	bool V_18 = false;
	bool V_19 = false;
	bool V_20 = false;
	bool V_21 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___next;
		V_1 = (int32_t*)L_1;
	}

IL_0008:
	{
	}

IL_0009:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		int32_t* L_3;
		L_3 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_2, NULL);
		int32_t L_4 = ___1_threadIndex;
		int32_t L_5;
		L_5 = VolatileRead((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_3, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_4, ((int32_t)16)))), 4)))));
		V_0 = L_5;
		int32_t L_6 = V_0;
		V_2 = (bool)((((int32_t)L_6) == ((int32_t)((int32_t)-3)))? 1 : 0);
		bool L_7 = V_2;
		if (L_7)
		{
			goto IL_0009;
		}
	}
	{
		int32_t L_8 = V_0;
		V_3 = (bool)((((int32_t)L_8) < ((int32_t)0))? 1 : 0);
		bool L_9 = V_3;
		if (!L_9)
		{
			goto IL_021e;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_10 = ___0_data;
		int32_t* L_11;
		L_11 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_10, NULL);
		int32_t L_12 = ___1_threadIndex;
		int32_t L_13;
		L_13 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_11, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_12, ((int32_t)16)))), 4)))), ((int32_t)-2), NULL);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_14 = ___0_data;
		NullCheck(L_14);
		int32_t L_15 = L_14->___allocatedIndexLength;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_16 = ___0_data;
		NullCheck(L_16);
		int32_t L_17 = L_16->___keyCapacity;
		V_6 = (bool)((((int32_t)L_15) < ((int32_t)L_17))? 1 : 0);
		bool L_18 = V_6;
		if (!L_18)
		{
			goto IL_0123;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_19 = ___0_data;
		NullCheck(L_19);
		int32_t* L_20 = (int32_t*)(&L_19->___allocatedIndexLength);
		int32_t L_21;
		L_21 = Interlocked_Add_m2455208C56EEFD8832AEAD8AF7368A3FEB33A73C(L_20, ((int32_t)16), NULL);
		V_0 = ((int32_t)il2cpp_codegen_subtract(L_21, ((int32_t)16)));
		int32_t L_22 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_23 = ___0_data;
		NullCheck(L_23);
		int32_t L_24 = L_23->___keyCapacity;
		V_7 = (bool)((((int32_t)L_22) < ((int32_t)((int32_t)il2cpp_codegen_subtract(L_24, 1))))? 1 : 0);
		bool L_25 = V_7;
		if (!L_25)
		{
			goto IL_00f3;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_26 = ___0_data;
		NullCheck(L_26);
		int32_t L_27 = L_26->___keyCapacity;
		int32_t L_28 = V_0;
		int32_t L_29;
		L_29 = math_min_m02D43DF516544C279AF660EA4731449C82991849_inline(((int32_t)16), ((int32_t)il2cpp_codegen_subtract(L_27, L_28)), NULL);
		V_8 = L_29;
		V_9 = 1;
		goto IL_00b3;
	}

IL_009b:
	{
		int32_t* L_30 = V_1;
		int32_t L_31 = V_0;
		int32_t L_32 = V_9;
		int32_t L_33 = V_0;
		int32_t L_34 = V_9;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_30, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_add(L_31, L_32))), 4))))) = (int32_t)((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_33, L_34)), 1));
		int32_t L_35 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add(L_35, 1));
	}

IL_00b3:
	{
		int32_t L_36 = V_9;
		int32_t L_37 = V_8;
		V_10 = (bool)((((int32_t)L_36) < ((int32_t)L_37))? 1 : 0);
		bool L_38 = V_10;
		if (L_38)
		{
			goto IL_009b;
		}
	}
	{
		int32_t* L_39 = V_1;
		int32_t L_40 = V_0;
		int32_t L_41 = V_8;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_39, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_40, L_41)), 1))), 4))))) = (int32_t)(-1);
		int32_t* L_42 = V_1;
		int32_t L_43 = V_0;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_42, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_43), 4))))) = (int32_t)(-1);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_44 = ___0_data;
		int32_t* L_45;
		L_45 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_44, NULL);
		int32_t L_46 = ___1_threadIndex;
		int32_t L_47 = V_0;
		int32_t L_48;
		L_48 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_45, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_46, ((int32_t)16)))), 4)))), ((int32_t)il2cpp_codegen_add(L_47, 1)), NULL);
		int32_t L_49 = V_0;
		V_11 = L_49;
		goto IL_026c;
	}

IL_00f3:
	{
		int32_t L_50 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_51 = ___0_data;
		NullCheck(L_51);
		int32_t L_52 = L_51->___keyCapacity;
		V_12 = (bool)((((int32_t)L_50) == ((int32_t)((int32_t)il2cpp_codegen_subtract(L_52, 1))))? 1 : 0);
		bool L_53 = V_12;
		if (!L_53)
		{
			goto IL_0122;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_54 = ___0_data;
		int32_t* L_55;
		L_55 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_54, NULL);
		int32_t L_56 = ___1_threadIndex;
		int32_t L_57;
		L_57 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_55, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_56, ((int32_t)16)))), 4)))), (-1), NULL);
		int32_t L_58 = V_0;
		V_11 = L_58;
		goto IL_026c;
	}

IL_0122:
	{
	}

IL_0123:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_59 = ___0_data;
		int32_t* L_60;
		L_60 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_59, NULL);
		int32_t L_61 = ___1_threadIndex;
		int32_t L_62;
		L_62 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_60, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_61, ((int32_t)16)))), 4)))), (-1), NULL);
		int32_t L_63;
		L_63 = JobsUtility_get_ThreadIndexCount_m88A954344398143540618B35943F863B92465676(NULL);
		V_4 = L_63;
		V_5 = (bool)1;
		goto IL_0212;
	}

IL_0147:
	{
		V_5 = (bool)0;
		int32_t L_64 = ___1_threadIndex;
		int32_t L_65 = V_4;
		V_13 = ((int32_t)(((int32_t)il2cpp_codegen_add(L_64, 1))%L_65));
		goto IL_0200;
	}

IL_0158:
	{
	}

IL_0159:
	{
	}

IL_015a:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_66 = ___0_data;
		int32_t* L_67;
		L_67 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_66, NULL);
		int32_t L_68 = V_13;
		int32_t L_69;
		L_69 = VolatileRead((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_67, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_68, ((int32_t)16)))), 4)))));
		V_0 = L_69;
		int32_t L_70 = V_0;
		V_14 = (bool)((((int32_t)L_70) == ((int32_t)((int32_t)-3)))? 1 : 0);
		bool L_71 = V_14;
		if (L_71)
		{
			goto IL_015a;
		}
	}
	{
		int32_t L_72 = V_0;
		V_15 = (bool)((((int32_t)L_72) < ((int32_t)0))? 1 : 0);
		bool L_73 = V_15;
		if (!L_73)
		{
			goto IL_0189;
		}
	}
	{
		goto IL_01ad;
	}

IL_0189:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_74 = ___0_data;
		int32_t* L_75;
		L_75 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_74, NULL);
		int32_t L_76 = V_13;
		int32_t L_77 = V_0;
		int32_t L_78;
		L_78 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_75, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_76, ((int32_t)16)))), 4)))), ((int32_t)-3), L_77, NULL);
		int32_t L_79 = V_0;
		V_16 = (bool)((((int32_t)((((int32_t)L_78) == ((int32_t)L_79))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_80 = V_16;
		if (L_80)
		{
			goto IL_0159;
		}
	}

IL_01ad:
	{
		int32_t L_81 = V_0;
		V_17 = (bool)((((int32_t)L_81) == ((int32_t)((int32_t)-2)))? 1 : 0);
		bool L_82 = V_17;
		if (!L_82)
		{
			goto IL_01bf;
		}
	}
	{
		V_5 = (bool)1;
		goto IL_01f6;
	}

IL_01bf:
	{
		int32_t L_83 = V_0;
		V_18 = (bool)((((int32_t)((((int32_t)L_83) < ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_84 = V_18;
		if (!L_84)
		{
			goto IL_01f6;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_85 = ___0_data;
		int32_t* L_86;
		L_86 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_85, NULL);
		int32_t L_87 = V_13;
		int32_t* L_88 = V_1;
		int32_t L_89 = V_0;
		int32_t L_90 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_88, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_89), 4))))));
		int32_t L_91;
		L_91 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_86, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_87, ((int32_t)16)))), 4)))), L_90, NULL);
		int32_t* L_92 = V_1;
		int32_t L_93 = V_0;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_92, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_93), 4))))) = (int32_t)(-1);
		int32_t L_94 = V_0;
		V_11 = L_94;
		goto IL_026c;
	}

IL_01f6:
	{
		int32_t L_95 = V_13;
		int32_t L_96 = V_4;
		V_13 = ((int32_t)(((int32_t)il2cpp_codegen_add(L_95, 1))%L_96));
	}

IL_0200:
	{
		int32_t L_97 = V_13;
		int32_t L_98 = ___1_threadIndex;
		V_19 = (bool)((((int32_t)((((int32_t)L_97) == ((int32_t)L_98))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_99 = V_19;
		if (L_99)
		{
			goto IL_0158;
		}
	}
	{
	}

IL_0212:
	{
		bool L_100 = V_5;
		V_20 = L_100;
		bool L_101 = V_20;
		if (L_101)
		{
			goto IL_0147;
		}
	}
	{
	}

IL_021e:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_102 = ___0_data;
		int32_t* L_103;
		L_103 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_102, NULL);
		int32_t L_104 = ___1_threadIndex;
		int32_t L_105 = V_0;
		int32_t L_106;
		L_106 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_103, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_104, ((int32_t)16)))), 4)))), ((int32_t)-3), L_105, NULL);
		int32_t L_107 = V_0;
		V_21 = (bool)((((int32_t)((((int32_t)L_106) == ((int32_t)L_107))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_108 = V_21;
		if (L_108)
		{
			goto IL_0008;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_109 = ___0_data;
		int32_t* L_110;
		L_110 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_109, NULL);
		int32_t L_111 = ___1_threadIndex;
		int32_t* L_112 = V_1;
		int32_t L_113 = V_0;
		int32_t L_114 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_112, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_113), 4))))));
		int32_t L_115;
		L_115 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_110, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_111, ((int32_t)16)))), 4)))), L_114, NULL);
		int32_t* L_116 = V_1;
		int32_t L_117 = V_0;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_116, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_117), 4))))) = (int32_t)(-1);
		int32_t L_118 = V_0;
		V_11 = L_118;
		goto IL_026c;
	}

IL_026c:
	{
		int32_t L_119 = V_11;
		return L_119;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_FreeEntry_m8FD2ED9C81D1A54D0D5D33B66435A7B5E8E4C65E_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_idx, int32_t ___2_threadIndex, const RuntimeMethod* method) 
{
	int32_t* V_0 = NULL;
	int32_t V_1 = 0;
	bool V_2 = false;
	bool V_3 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___next;
		V_0 = (int32_t*)L_1;
		V_1 = (-1);
	}

IL_000a:
	{
	}

IL_000b:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		int32_t* L_3;
		L_3 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_2, NULL);
		int32_t L_4 = ___2_threadIndex;
		int32_t L_5;
		L_5 = VolatileRead((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_3, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_4, ((int32_t)16)))), 4)))));
		V_1 = L_5;
		int32_t L_6 = V_1;
		V_2 = (bool)((((int32_t)L_6) == ((int32_t)((int32_t)-3)))? 1 : 0);
		bool L_7 = V_2;
		if (L_7)
		{
			goto IL_000b;
		}
	}
	{
		int32_t* L_8 = V_0;
		int32_t L_9 = ___1_idx;
		int32_t L_10 = V_1;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_8, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_9), 4))))) = (int32_t)L_10;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_11 = ___0_data;
		int32_t* L_12;
		L_12 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_11, NULL);
		int32_t L_13 = ___2_threadIndex;
		int32_t L_14 = ___1_idx;
		int32_t L_15 = V_1;
		int32_t L_16;
		L_16 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_12, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_13, ((int32_t)16)))), 4)))), L_14, L_15, NULL);
		int32_t L_17 = V_1;
		V_3 = (bool)((((int32_t)((((int32_t)L_16) == ((int32_t)L_17))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_18 = V_3;
		if (L_18)
		{
			goto IL_000a;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryAddAtomic_m688210F8BD254EA96317F8DEB56C694FAD69AAAF_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78 ___2_item, int32_t ___3_threadIndex, const RuntimeMethod* method) 
{
	GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78 V_0;
	memset((&V_0), 0, sizeof(V_0));
	NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC V_1;
	memset((&V_1), 0, sizeof(V_1));
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	int32_t* V_4 = NULL;
	bool V_5 = false;
	bool V_6 = false;
	bool V_7 = false;
	int32_t* V_8 = NULL;
	int32_t V_9 = 0;
	bool V_10 = false;
	bool V_11 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		int32_t L_1 = ___1_key;
		bool L_2;
		L_2 = UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_m6DF4FDD33DF0500B90F89611D3B0EB217FBE80A9(L_0, L_1, (&V_0), (&V_1), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_5 = L_2;
		bool L_3 = V_5;
		if (!L_3)
		{
			goto IL_001b;
		}
	}
	{
		V_6 = (bool)0;
		goto IL_00da;
	}

IL_001b:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = ___0_data;
		int32_t L_5 = ___3_threadIndex;
		int32_t L_6;
		L_6 = UnsafeParallelHashMapBase_2_AllocEntry_mA6D1BF0531A4B163ED154D98E5AC42EBF6BA5F3D(L_4, L_5, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		V_2 = L_6;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		uint8_t* L_8 = L_7->___keys;
		int32_t L_9 = V_2;
		int32_t L_10 = ___1_key;
		UnsafeUtility_WriteArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m0DD1CC90B2F1EF5041F2F4E1DABB58224229F0D7_inline((void*)L_8, L_9, L_10, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 6));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_11 = ___0_data;
		NullCheck(L_11);
		uint8_t* L_12 = L_11->___values;
		int32_t L_13 = V_2;
		GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78 L_14 = ___2_item;
		UnsafeUtility_WriteArrayElement_TisGPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78_mFC4E3A09D0F9A76B3DA65553F10F7EF785896EEA_inline((void*)L_12, L_13, L_14, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		int32_t L_15;
		L_15 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_16 = ___0_data;
		NullCheck(L_16);
		int32_t L_17 = L_16->___bucketCapacityMask;
		V_3 = ((int32_t)(L_15&L_17));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_18 = ___0_data;
		NullCheck(L_18);
		uint8_t* L_19 = L_18->___buckets;
		V_4 = (int32_t*)L_19;
		int32_t* L_20 = V_4;
		int32_t L_21 = V_3;
		int32_t L_22 = V_2;
		int32_t L_23;
		L_23 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_20, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_21), 4)))), L_22, (-1), NULL);
		V_7 = (bool)((((int32_t)((((int32_t)L_23) == ((int32_t)(-1)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_24 = V_7;
		if (!L_24)
		{
			goto IL_00d5;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_25 = ___0_data;
		NullCheck(L_25);
		uint8_t* L_26 = L_25->___next;
		V_8 = (int32_t*)L_26;
		V_9 = (-1);
	}

IL_0082:
	{
		int32_t* L_27 = V_4;
		int32_t L_28 = V_3;
		int32_t L_29 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_27, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_28), 4))))));
		V_9 = L_29;
		int32_t* L_30 = V_8;
		int32_t L_31 = V_2;
		int32_t L_32 = V_9;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_30, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_31), 4))))) = (int32_t)L_32;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_33 = ___0_data;
		int32_t L_34 = ___1_key;
		bool L_35;
		L_35 = UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_m6DF4FDD33DF0500B90F89611D3B0EB217FBE80A9(L_33, L_34, (&V_0), (&V_1), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_10 = L_35;
		bool L_36 = V_10;
		if (!L_36)
		{
			goto IL_00b7;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_37 = ___0_data;
		int32_t L_38 = V_2;
		int32_t L_39 = ___3_threadIndex;
		UnsafeParallelHashMapBase_2_FreeEntry_m8FD2ED9C81D1A54D0D5D33B66435A7B5E8E4C65E(L_37, L_38, L_39, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 10));
		V_6 = (bool)0;
		goto IL_00da;
	}

IL_00b7:
	{
		int32_t* L_40 = V_4;
		int32_t L_41 = V_3;
		int32_t L_42 = V_2;
		int32_t L_43 = V_9;
		int32_t L_44;
		L_44 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_40, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_41), 4)))), L_42, L_43, NULL);
		int32_t L_45 = V_9;
		V_11 = (bool)((((int32_t)((((int32_t)L_44) == ((int32_t)L_45))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_46 = V_11;
		if (L_46)
		{
			goto IL_0082;
		}
	}
	{
	}

IL_00d5:
	{
		V_6 = (bool)1;
		goto IL_00da;
	}

IL_00da:
	{
		bool L_47 = V_6;
		return L_47;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryAdd_mB973BB372093CBC6DB660DD13230590FAE34FD26_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78 ___2_item, bool ___3_isMultiHashMap, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___4_allocation, const RuntimeMethod* method) 
{
	GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78 V_0;
	memset((&V_0), 0, sizeof(V_0));
	NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC V_1;
	memset((&V_1), 0, sizeof(V_1));
	bool V_2 = false;
	int32_t V_3 = 0;
	int32_t* V_4 = NULL;
	int32_t V_5 = 0;
	int32_t* V_6 = NULL;
	bool V_7 = false;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	bool V_10 = false;
	bool V_11 = false;
	bool V_12 = false;
	int32_t V_13 = 0;
	bool V_14 = false;
	int32_t V_15 = 0;
	bool V_16 = false;
	int32_t G_B3_0 = 0;
	int32_t G_B7_0 = 0;
	{
		bool L_0 = ___3_isMultiHashMap;
		if (L_0)
		{
			goto IL_0014;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_1 = ___0_data;
		int32_t L_2 = ___1_key;
		bool L_3;
		L_3 = UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_m6DF4FDD33DF0500B90F89611D3B0EB217FBE80A9(L_1, L_2, (&V_0), (&V_1), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		G_B3_0 = ((((int32_t)L_3) == ((int32_t)0))? 1 : 0);
		goto IL_0015;
	}

IL_0014:
	{
		G_B3_0 = 1;
	}

IL_0015:
	{
		V_2 = (bool)G_B3_0;
		bool L_4 = V_2;
		if (!L_4)
		{
			goto IL_0197;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_5 = ___0_data;
		NullCheck(L_5);
		int32_t L_6 = L_5->___allocatedIndexLength;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		int32_t L_8 = L_7->___keyCapacity;
		if ((((int32_t)L_6) < ((int32_t)L_8)))
		{
			goto IL_0037;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_9 = ___0_data;
		int32_t* L_10;
		L_10 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_9, NULL);
		int32_t L_11 = (*(L_10));
		G_B7_0 = ((((int32_t)L_11) < ((int32_t)0))? 1 : 0);
		goto IL_0038;
	}

IL_0037:
	{
		G_B7_0 = 0;
	}

IL_0038:
	{
		V_7 = (bool)G_B7_0;
		bool L_12 = V_7;
		if (!L_12)
		{
			goto IL_00f5;
		}
	}
	{
		int32_t L_13;
		L_13 = JobsUtility_get_ThreadIndexCount_m88A954344398143540618B35943F863B92465676(NULL);
		V_8 = L_13;
		V_9 = 1;
		goto IL_00b7;
	}

IL_004e:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_14 = ___0_data;
		int32_t* L_15;
		L_15 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_14, NULL);
		int32_t L_16 = V_9;
		int32_t L_17 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_15, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_16, ((int32_t)16)))), 4))))));
		V_10 = (bool)((((int32_t)((((int32_t)L_17) < ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_18 = V_10;
		if (!L_18)
		{
			goto IL_00b0;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_19 = ___0_data;
		int32_t* L_20;
		L_20 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_19, NULL);
		int32_t L_21 = V_9;
		int32_t L_22 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_20, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_21, ((int32_t)16)))), 4))))));
		V_3 = L_22;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_23 = ___0_data;
		NullCheck(L_23);
		uint8_t* L_24 = L_23->___next;
		V_4 = (int32_t*)L_24;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_25 = ___0_data;
		int32_t* L_26;
		L_26 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_25, NULL);
		int32_t L_27 = V_9;
		int32_t* L_28 = V_4;
		int32_t L_29 = V_3;
		int32_t L_30 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_28, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_29), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_26, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_27, ((int32_t)16)))), 4))))) = (int32_t)L_30;
		int32_t* L_31 = V_4;
		int32_t L_32 = V_3;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_31, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_32), 4))))) = (int32_t)(-1);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_33 = ___0_data;
		int32_t* L_34;
		L_34 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_33, NULL);
		int32_t L_35 = V_3;
		*((int32_t*)L_34) = (int32_t)L_35;
		goto IL_00c3;
	}

IL_00b0:
	{
		int32_t L_36 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add(L_36, 1));
	}

IL_00b7:
	{
		int32_t L_37 = V_9;
		int32_t L_38 = V_8;
		V_11 = (bool)((((int32_t)L_37) < ((int32_t)L_38))? 1 : 0);
		bool L_39 = V_11;
		if (L_39)
		{
			goto IL_004e;
		}
	}

IL_00c3:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_40 = ___0_data;
		int32_t* L_41;
		L_41 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_40, NULL);
		int32_t L_42 = (*(L_41));
		V_12 = (bool)((((int32_t)L_42) < ((int32_t)0))? 1 : 0);
		bool L_43 = V_12;
		if (!L_43)
		{
			goto IL_00f4;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_44 = ___0_data;
		NullCheck(L_44);
		int32_t L_45 = L_44->___keyCapacity;
		int32_t L_46;
		L_46 = UnsafeParallelHashMapData_GrowCapacity_m7F2FF57E76510A99266830779059C6C202B9EC47(L_45, NULL);
		V_13 = L_46;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_47 = ___0_data;
		int32_t L_48 = V_13;
		int32_t L_49 = V_13;
		int32_t L_50;
		L_50 = UnsafeParallelHashMapData_GetBucketSize_mEF90FF75EFE70E4B59CD6AF9FDCB3D564A1986A3(L_49, NULL);
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_51 = ___4_allocation;
		UnsafeParallelHashMapData_ReallocateHashMap_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_TisGPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78_m5EEA3CF56A858CE6C8B93F86EBD5D9E0EC019D09(L_47, L_48, L_50, L_51, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
	}

IL_00f4:
	{
	}

IL_00f5:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_52 = ___0_data;
		int32_t* L_53;
		L_53 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_52, NULL);
		int32_t L_54 = (*(L_53));
		V_3 = L_54;
		int32_t L_55 = V_3;
		V_14 = (bool)((((int32_t)((((int32_t)L_55) < ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_56 = V_14;
		if (!L_56)
		{
			goto IL_0121;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_57 = ___0_data;
		int32_t* L_58;
		L_58 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_57, NULL);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_59 = ___0_data;
		NullCheck(L_59);
		uint8_t* L_60 = L_59->___next;
		int32_t L_61 = V_3;
		int32_t L_62 = *((int32_t*)((uint8_t*)il2cpp_codegen_add((intptr_t)L_60, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_61), 4)))));
		*((int32_t*)L_58) = (int32_t)L_62;
		goto IL_0135;
	}

IL_0121:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_63 = ___0_data;
		NullCheck(L_63);
		int32_t* L_64 = (int32_t*)(&L_63->___allocatedIndexLength);
		int32_t* L_65 = L_64;
		int32_t L_66 = *((int32_t*)L_65);
		V_15 = L_66;
		int32_t L_67 = V_15;
		*((int32_t*)L_65) = (int32_t)((int32_t)il2cpp_codegen_add(L_67, 1));
		int32_t L_68 = V_15;
		V_3 = L_68;
	}

IL_0135:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_69 = ___0_data;
		NullCheck(L_69);
		uint8_t* L_70 = L_69->___keys;
		int32_t L_71 = V_3;
		int32_t L_72 = ___1_key;
		UnsafeUtility_WriteArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m0DD1CC90B2F1EF5041F2F4E1DABB58224229F0D7_inline((void*)L_70, L_71, L_72, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 6));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_73 = ___0_data;
		NullCheck(L_73);
		uint8_t* L_74 = L_73->___values;
		int32_t L_75 = V_3;
		GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78 L_76 = ___2_item;
		UnsafeUtility_WriteArrayElement_TisGPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78_mFC4E3A09D0F9A76B3DA65553F10F7EF785896EEA_inline((void*)L_74, L_75, L_76, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		int32_t L_77;
		L_77 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_78 = ___0_data;
		NullCheck(L_78);
		int32_t L_79 = L_78->___bucketCapacityMask;
		V_5 = ((int32_t)(L_77&L_79));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_80 = ___0_data;
		NullCheck(L_80);
		uint8_t* L_81 = L_80->___buckets;
		V_6 = (int32_t*)L_81;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_82 = ___0_data;
		NullCheck(L_82);
		uint8_t* L_83 = L_82->___next;
		V_4 = (int32_t*)L_83;
		int32_t* L_84 = V_4;
		int32_t L_85 = V_3;
		int32_t* L_86 = V_6;
		int32_t L_87 = V_5;
		int32_t L_88 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_86, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_87), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_84, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_85), 4))))) = (int32_t)L_88;
		int32_t* L_89 = V_6;
		int32_t L_90 = V_5;
		int32_t L_91 = V_3;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_89, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_90), 4))))) = (int32_t)L_91;
		V_16 = (bool)1;
		goto IL_019c;
	}

IL_0197:
	{
		V_16 = (bool)0;
		goto IL_019c;
	}

IL_019c:
	{
		bool L_92 = V_16;
		return L_92;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapBase_2_Remove_mCE6DF4C8905ACBAE7E5D421ED244EAC9A7EC740C_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, bool ___2_isMultiHashMap, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t* V_1 = NULL;
	int32_t* V_2 = NULL;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	bool V_6 = false;
	int32_t V_7 = 0;
	bool V_8 = false;
	int32_t V_9 = 0;
	int32_t V_10 = 0;
	bool V_11 = false;
	bool V_12 = false;
	bool V_13 = false;
	int32_t G_B15_0 = 0;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		int32_t L_1 = L_0->___keyCapacity;
		V_6 = (bool)((((int32_t)L_1) == ((int32_t)0))? 1 : 0);
		bool L_2 = V_6;
		if (!L_2)
		{
			goto IL_0019;
		}
	}
	{
		V_7 = 0;
		goto IL_010f;
	}

IL_0019:
	{
		V_0 = 0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_3 = ___0_data;
		NullCheck(L_3);
		uint8_t* L_4 = L_3->___buckets;
		V_1 = (int32_t*)L_4;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_5 = ___0_data;
		NullCheck(L_5);
		uint8_t* L_6 = L_5->___next;
		V_2 = (int32_t*)L_6;
		int32_t L_7;
		L_7 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_8 = ___0_data;
		NullCheck(L_8);
		int32_t L_9 = L_8->___bucketCapacityMask;
		V_3 = ((int32_t)(L_7&L_9));
		V_4 = (-1);
		int32_t* L_10 = V_1;
		int32_t L_11 = V_3;
		int32_t L_12 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_10, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_11), 4))))));
		V_5 = L_12;
		goto IL_00ef;
	}

IL_004f:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_13 = ___0_data;
		NullCheck(L_13);
		uint8_t* L_14 = L_13->___keys;
		int32_t L_15 = V_5;
		int32_t L_16;
		L_16 = UnsafeUtility_ReadArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_mFBA66C06ECEB0A2BC1AAE634B6E6BB436F957084_inline((void*)L_14, L_15, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		V_9 = L_16;
		int32_t L_17 = ___1_key;
		bool L_18;
		L_18 = Int32_Equals_mC819D19A661B95BE253FB1769FD4D91961D20722((&V_9), L_17, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 15));
		V_8 = L_18;
		bool L_19 = V_8;
		if (!L_19)
		{
			goto IL_00de;
		}
	}
	{
		int32_t L_20 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add(L_20, 1));
		int32_t L_21 = V_4;
		V_11 = (bool)((((int32_t)L_21) < ((int32_t)0))? 1 : 0);
		bool L_22 = V_11;
		if (!L_22)
		{
			goto IL_0096;
		}
	}
	{
		int32_t* L_23 = V_1;
		int32_t L_24 = V_3;
		int32_t* L_25 = V_2;
		int32_t L_26 = V_5;
		int32_t L_27 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_25, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_26), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_23, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_24), 4))))) = (int32_t)L_27;
		goto IL_00a8;
	}

IL_0096:
	{
		int32_t* L_28 = V_2;
		int32_t L_29 = V_4;
		int32_t* L_30 = V_2;
		int32_t L_31 = V_5;
		int32_t L_32 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_30, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_31), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_28, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_29), 4))))) = (int32_t)L_32;
	}

IL_00a8:
	{
		int32_t* L_33 = V_2;
		int32_t L_34 = V_5;
		int32_t L_35 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_33, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_34), 4))))));
		V_10 = L_35;
		int32_t* L_36 = V_2;
		int32_t L_37 = V_5;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_38 = ___0_data;
		int32_t* L_39;
		L_39 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_38, NULL);
		int32_t L_40 = (*(L_39));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_36, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_37), 4))))) = (int32_t)L_40;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_41 = ___0_data;
		int32_t* L_42;
		L_42 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_41, NULL);
		int32_t L_43 = V_5;
		*((int32_t*)L_42) = (int32_t)L_43;
		int32_t L_44 = V_10;
		V_5 = L_44;
		bool L_45 = ___2_isMultiHashMap;
		V_12 = (bool)((((int32_t)L_45) == ((int32_t)0))? 1 : 0);
		bool L_46 = V_12;
		if (!L_46)
		{
			goto IL_00db;
		}
	}
	{
		goto IL_010a;
	}

IL_00db:
	{
		goto IL_00ee;
	}

IL_00de:
	{
		int32_t L_47 = V_5;
		V_4 = L_47;
		int32_t* L_48 = V_2;
		int32_t L_49 = V_5;
		int32_t L_50 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_48, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_49), 4))))));
		V_5 = L_50;
	}

IL_00ee:
	{
	}

IL_00ef:
	{
		int32_t L_51 = V_5;
		if ((((int32_t)L_51) < ((int32_t)0)))
		{
			goto IL_0100;
		}
	}
	{
		int32_t L_52 = V_5;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_53 = ___0_data;
		NullCheck(L_53);
		int32_t L_54 = L_53->___keyCapacity;
		G_B15_0 = ((((int32_t)L_52) < ((int32_t)L_54))? 1 : 0);
		goto IL_0101;
	}

IL_0100:
	{
		G_B15_0 = 0;
	}

IL_0101:
	{
		V_13 = (bool)G_B15_0;
		bool L_55 = V_13;
		if (L_55)
		{
			goto IL_004f;
		}
	}

IL_010a:
	{
		int32_t L_56 = V_0;
		V_7 = L_56;
		goto IL_010f;
	}

IL_010f:
	{
		int32_t L_57 = V_7;
		return L_57;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_Remove_m6F63F3D7CF1CCBA256CF8FFF827834E8F6CDC53C_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC ___1_it, const RuntimeMethod* method) 
{
	int32_t* V_0 = NULL;
	int32_t* V_1 = NULL;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	bool V_4 = false;
	bool V_5 = false;
	bool V_6 = false;
	int32_t G_B7_0 = 0;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___buckets;
		V_0 = (int32_t*)L_1;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		NullCheck(L_2);
		uint8_t* L_3 = L_2->___next;
		V_1 = (int32_t*)L_3;
		int32_t* L_4 = (int32_t*)(&(&___1_it)->___key);
		int32_t L_5;
		L_5 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295(L_4, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_6 = ___0_data;
		NullCheck(L_6);
		int32_t L_7 = L_6->___bucketCapacityMask;
		V_2 = ((int32_t)(L_5&L_7));
		int32_t* L_8 = V_0;
		int32_t L_9 = V_2;
		int32_t L_10 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_8, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_9), 4))))));
		V_3 = L_10;
		int32_t L_11 = V_3;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC L_12 = ___1_it;
		int32_t L_13 = L_12.___EntryIndex;
		V_4 = (bool)((((int32_t)L_11) == ((int32_t)L_13))? 1 : 0);
		bool L_14 = V_4;
		if (!L_14)
		{
			goto IL_0052;
		}
	}
	{
		int32_t* L_15 = V_0;
		int32_t L_16 = V_2;
		int32_t* L_17 = V_1;
		int32_t L_18 = V_3;
		int32_t L_19 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_17, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_18), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_15, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_16), 4))))) = (int32_t)L_19;
		goto IL_009e;
	}

IL_0052:
	{
		goto IL_005f;
	}

IL_0055:
	{
		int32_t* L_20 = V_1;
		int32_t L_21 = V_3;
		int32_t L_22 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_20, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_21), 4))))));
		V_3 = L_22;
	}

IL_005f:
	{
		int32_t L_23 = V_3;
		if ((((int32_t)L_23) < ((int32_t)0)))
		{
			goto IL_0077;
		}
	}
	{
		int32_t* L_24 = V_1;
		int32_t L_25 = V_3;
		int32_t L_26 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_24, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_25), 4))))));
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC L_27 = ___1_it;
		int32_t L_28 = L_27.___EntryIndex;
		G_B7_0 = ((((int32_t)((((int32_t)L_26) == ((int32_t)L_28))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0078;
	}

IL_0077:
	{
		G_B7_0 = 0;
	}

IL_0078:
	{
		V_5 = (bool)G_B7_0;
		bool L_29 = V_5;
		if (L_29)
		{
			goto IL_0055;
		}
	}
	{
		int32_t L_30 = V_3;
		V_6 = (bool)((((int32_t)L_30) < ((int32_t)0))? 1 : 0);
		bool L_31 = V_6;
		if (!L_31)
		{
			goto IL_008a;
		}
	}
	{
	}

IL_008a:
	{
		int32_t* L_32 = V_1;
		int32_t L_33 = V_3;
		int32_t* L_34 = V_1;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC L_35 = ___1_it;
		int32_t L_36 = L_35.___EntryIndex;
		int32_t L_37 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_34, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_36), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_32, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_33), 4))))) = (int32_t)L_37;
	}

IL_009e:
	{
		int32_t* L_38 = V_1;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC L_39 = ___1_it;
		int32_t L_40 = L_39.___EntryIndex;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_41 = ___0_data;
		int32_t* L_42;
		L_42 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_41, NULL);
		int32_t L_43 = (*(L_42));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_38, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_40), 4))))) = (int32_t)L_43;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_44 = ___0_data;
		int32_t* L_45;
		L_45 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_44, NULL);
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC L_46 = ___1_it;
		int32_t L_47 = L_46.___EntryIndex;
		*((int32_t*)L_45) = (int32_t)L_47;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_m6DF4FDD33DF0500B90F89611D3B0EB217FBE80A9_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78* ___2_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___3_it, const RuntimeMethod* method) 
{
	int32_t* V_0 = NULL;
	int32_t V_1 = 0;
	bool V_2 = false;
	int32_t V_3 = 0;
	bool V_4 = false;
	{
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_0 = ___3_it;
		int32_t L_1 = ___1_key;
		L_0->___key = L_1;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		NullCheck(L_2);
		int32_t L_3 = L_2->___allocatedIndexLength;
		V_2 = (bool)((((int32_t)((((int32_t)L_3) > ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_4 = V_2;
		if (!L_4)
		{
			goto IL_0035;
		}
	}
	{
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_5 = ___3_it;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_6 = ___3_it;
		int32_t L_7 = (-1);
		V_3 = L_7;
		L_6->___NextEntryIndex = L_7;
		int32_t L_8 = V_3;
		L_5->___EntryIndex = L_8;
		GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78* L_9 = ___2_item;
		il2cpp_codegen_initobj(L_9, sizeof(GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78));
		V_4 = (bool)0;
		goto IL_0073;
	}

IL_0035:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_10 = ___0_data;
		NullCheck(L_10);
		uint8_t* L_11 = L_10->___buckets;
		V_0 = (int32_t*)L_11;
		int32_t L_12;
		L_12 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_13 = ___0_data;
		NullCheck(L_13);
		int32_t L_14 = L_13->___bucketCapacityMask;
		V_1 = ((int32_t)(L_12&L_14));
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_15 = ___3_it;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_16 = ___3_it;
		int32_t* L_17 = V_0;
		int32_t L_18 = V_1;
		int32_t L_19 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_17, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_18), 4))))));
		int32_t L_20 = L_19;
		V_3 = L_20;
		L_16->___NextEntryIndex = L_20;
		int32_t L_21 = V_3;
		L_15->___EntryIndex = L_21;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_22 = ___0_data;
		GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78* L_23 = ___2_item;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_24 = ___3_it;
		bool L_25;
		L_25 = UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m3453F1516A7747F6CB50AA7E83EFF9D33D9D1325(L_22, L_23, L_24, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 16));
		V_4 = L_25;
		goto IL_0073;
	}

IL_0073:
	{
		bool L_26 = V_4;
		return L_26;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m3453F1516A7747F6CB50AA7E83EFF9D33D9D1325_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78* ___1_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___2_it, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t* V_1 = NULL;
	bool V_2 = false;
	bool V_3 = false;
	bool V_4 = false;
	bool V_5 = false;
	int32_t V_6 = 0;
	int32_t G_B3_0 = 0;
	int32_t G_B9_0 = 0;
	{
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_0 = ___2_it;
		int32_t L_1 = L_0->___NextEntryIndex;
		V_0 = L_1;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_2 = ___2_it;
		L_2->___NextEntryIndex = (-1);
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_3 = ___2_it;
		L_3->___EntryIndex = (-1);
		GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78* L_4 = ___1_item;
		il2cpp_codegen_initobj(L_4, sizeof(GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78));
		int32_t L_5 = V_0;
		if ((((int32_t)L_5) < ((int32_t)0)))
		{
			goto IL_002f;
		}
	}
	{
		int32_t L_6 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		int32_t L_8 = L_7->___keyCapacity;
		G_B3_0 = ((((int32_t)((((int32_t)L_6) < ((int32_t)L_8))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0030;
	}

IL_002f:
	{
		G_B3_0 = 1;
	}

IL_0030:
	{
		V_2 = (bool)G_B3_0;
		bool L_9 = V_2;
		if (!L_9)
		{
			goto IL_003c;
		}
	}
	{
		V_3 = (bool)0;
		goto IL_00c1;
	}

IL_003c:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_10 = ___0_data;
		NullCheck(L_10);
		uint8_t* L_11 = L_10->___next;
		V_1 = (int32_t*)L_11;
		goto IL_006d;
	}

IL_0045:
	{
		int32_t* L_12 = V_1;
		int32_t L_13 = V_0;
		int32_t L_14 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_12, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_13), 4))))));
		V_0 = L_14;
		int32_t L_15 = V_0;
		if ((((int32_t)L_15) < ((int32_t)0)))
		{
			goto IL_0060;
		}
	}
	{
		int32_t L_16 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_17 = ___0_data;
		NullCheck(L_17);
		int32_t L_18 = L_17->___keyCapacity;
		G_B9_0 = ((((int32_t)((((int32_t)L_16) < ((int32_t)L_18))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0061;
	}

IL_0060:
	{
		G_B9_0 = 1;
	}

IL_0061:
	{
		V_4 = (bool)G_B9_0;
		bool L_19 = V_4;
		if (!L_19)
		{
			goto IL_006c;
		}
	}
	{
		V_3 = (bool)0;
		goto IL_00c1;
	}

IL_006c:
	{
	}

IL_006d:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_20 = ___0_data;
		NullCheck(L_20);
		uint8_t* L_21 = L_20->___keys;
		int32_t L_22 = V_0;
		int32_t L_23;
		L_23 = UnsafeUtility_ReadArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_mFBA66C06ECEB0A2BC1AAE634B6E6BB436F957084_inline((void*)L_21, L_22, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		V_6 = L_23;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_24 = ___2_it;
		int32_t L_25 = L_24->___key;
		bool L_26;
		L_26 = Int32_Equals_mC819D19A661B95BE253FB1769FD4D91961D20722((&V_6), L_25, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 15));
		V_5 = (bool)((((int32_t)L_26) == ((int32_t)0))? 1 : 0);
		bool L_27 = V_5;
		if (L_27)
		{
			goto IL_0045;
		}
	}
	{
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_28 = ___2_it;
		int32_t* L_29 = V_1;
		int32_t L_30 = V_0;
		int32_t L_31 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_29, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_30), 4))))));
		L_28->___NextEntryIndex = L_31;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_32 = ___2_it;
		int32_t L_33 = V_0;
		L_32->___EntryIndex = L_33;
		GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78* L_34 = ___1_item;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_35 = ___0_data;
		NullCheck(L_35);
		uint8_t* L_36 = L_35->___values;
		int32_t L_37 = V_0;
		GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78 L_38;
		L_38 = UnsafeUtility_ReadArrayElement_TisGPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78_mF42F014B5AA9C633D3FCAB3FFF26646E54395BD8_inline((void*)L_36, L_37, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 17));
		*(GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78*)L_34 = L_38;
		V_3 = (bool)1;
		goto IL_00c1;
	}

IL_00c1:
	{
		bool L_39 = V_3;
		return L_39;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_SetValue_m68DD649D2380023901CC831016DEA16A5B288282_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___1_it, GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78* ___2_item, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	bool V_1 = false;
	bool V_2 = false;
	int32_t G_B3_0 = 0;
	{
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_0 = ___1_it;
		int32_t L_1 = L_0->___EntryIndex;
		V_0 = L_1;
		int32_t L_2 = V_0;
		if ((((int32_t)L_2) < ((int32_t)0)))
		{
			goto IL_001a;
		}
	}
	{
		int32_t L_3 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = ___0_data;
		NullCheck(L_4);
		int32_t L_5 = L_4->___keyCapacity;
		G_B3_0 = ((((int32_t)((((int32_t)L_3) < ((int32_t)L_5))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_001b;
	}

IL_001a:
	{
		G_B3_0 = 1;
	}

IL_001b:
	{
		V_1 = (bool)G_B3_0;
		bool L_6 = V_1;
		if (!L_6)
		{
			goto IL_0024;
		}
	}
	{
		V_2 = (bool)0;
		goto IL_003b;
	}

IL_0024:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		uint8_t* L_8 = L_7->___values;
		int32_t L_9 = V_0;
		GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78* L_10 = ___2_item;
		GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78 L_11 = (*(GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78*)L_10);
		UnsafeUtility_WriteArrayElement_TisGPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78_mFC4E3A09D0F9A76B3DA65553F10F7EF785896EEA_inline((void*)L_8, L_9, L_11, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		V_2 = (bool)1;
		goto IL_003b;
	}

IL_003b:
	{
		bool L_12 = V_2;
		return L_12;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_Clear_m79A95CE9116B5691078AA0912B3D07D7D08F65A9_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	bool V_2 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___buckets;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		NullCheck(L_2);
		int32_t L_3 = L_2->___bucketCapacityMask;
		UnsafeUtility_MemSet_m4CD74CD43260EB2962A46F57E0D93DD5C332FC2B((void*)L_1, (uint8_t)((int32_t)255), ((int64_t)((int32_t)il2cpp_codegen_multiply(((int32_t)il2cpp_codegen_add(L_3, 1)), 4))), NULL);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = ___0_data;
		NullCheck(L_4);
		uint8_t* L_5 = L_4->___next;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_6 = ___0_data;
		NullCheck(L_6);
		int32_t L_7 = L_6->___keyCapacity;
		UnsafeUtility_MemSet_m4CD74CD43260EB2962A46F57E0D93DD5C332FC2B((void*)L_5, (uint8_t)((int32_t)255), ((int64_t)((int32_t)il2cpp_codegen_multiply(L_7, 4))), NULL);
		int32_t L_8;
		L_8 = JobsUtility_get_ThreadIndexCount_m88A954344398143540618B35943F863B92465676(NULL);
		V_0 = L_8;
		V_1 = 0;
		goto IL_0057;
	}

IL_0041:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_9 = ___0_data;
		int32_t* L_10;
		L_10 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_9, NULL);
		int32_t L_11 = V_1;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_10, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_11, ((int32_t)16)))), 4))))) = (int32_t)(-1);
		int32_t L_12 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_12, 1));
	}

IL_0057:
	{
		int32_t L_13 = V_1;
		int32_t L_14 = V_0;
		V_2 = (bool)((((int32_t)L_13) < ((int32_t)L_14))? 1 : 0);
		bool L_15 = V_2;
		if (L_15)
		{
			goto IL_0041;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_16 = ___0_data;
		NullCheck(L_16);
		L_16->___allocatedIndexLength = 0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapBase_2_AllocEntry_mA60C7AAB43656E7611E27393BC6AB7E52163A000_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_threadIndex, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t* V_1 = NULL;
	bool V_2 = false;
	bool V_3 = false;
	int32_t V_4 = 0;
	bool V_5 = false;
	bool V_6 = false;
	bool V_7 = false;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	bool V_10 = false;
	int32_t V_11 = 0;
	bool V_12 = false;
	int32_t V_13 = 0;
	bool V_14 = false;
	bool V_15 = false;
	bool V_16 = false;
	bool V_17 = false;
	bool V_18 = false;
	bool V_19 = false;
	bool V_20 = false;
	bool V_21 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___next;
		V_1 = (int32_t*)L_1;
	}

IL_0008:
	{
	}

IL_0009:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		int32_t* L_3;
		L_3 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_2, NULL);
		int32_t L_4 = ___1_threadIndex;
		int32_t L_5;
		L_5 = VolatileRead((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_3, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_4, ((int32_t)16)))), 4)))));
		V_0 = L_5;
		int32_t L_6 = V_0;
		V_2 = (bool)((((int32_t)L_6) == ((int32_t)((int32_t)-3)))? 1 : 0);
		bool L_7 = V_2;
		if (L_7)
		{
			goto IL_0009;
		}
	}
	{
		int32_t L_8 = V_0;
		V_3 = (bool)((((int32_t)L_8) < ((int32_t)0))? 1 : 0);
		bool L_9 = V_3;
		if (!L_9)
		{
			goto IL_021e;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_10 = ___0_data;
		int32_t* L_11;
		L_11 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_10, NULL);
		int32_t L_12 = ___1_threadIndex;
		int32_t L_13;
		L_13 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_11, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_12, ((int32_t)16)))), 4)))), ((int32_t)-2), NULL);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_14 = ___0_data;
		NullCheck(L_14);
		int32_t L_15 = L_14->___allocatedIndexLength;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_16 = ___0_data;
		NullCheck(L_16);
		int32_t L_17 = L_16->___keyCapacity;
		V_6 = (bool)((((int32_t)L_15) < ((int32_t)L_17))? 1 : 0);
		bool L_18 = V_6;
		if (!L_18)
		{
			goto IL_0123;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_19 = ___0_data;
		NullCheck(L_19);
		int32_t* L_20 = (int32_t*)(&L_19->___allocatedIndexLength);
		int32_t L_21;
		L_21 = Interlocked_Add_m2455208C56EEFD8832AEAD8AF7368A3FEB33A73C(L_20, ((int32_t)16), NULL);
		V_0 = ((int32_t)il2cpp_codegen_subtract(L_21, ((int32_t)16)));
		int32_t L_22 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_23 = ___0_data;
		NullCheck(L_23);
		int32_t L_24 = L_23->___keyCapacity;
		V_7 = (bool)((((int32_t)L_22) < ((int32_t)((int32_t)il2cpp_codegen_subtract(L_24, 1))))? 1 : 0);
		bool L_25 = V_7;
		if (!L_25)
		{
			goto IL_00f3;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_26 = ___0_data;
		NullCheck(L_26);
		int32_t L_27 = L_26->___keyCapacity;
		int32_t L_28 = V_0;
		int32_t L_29;
		L_29 = math_min_m02D43DF516544C279AF660EA4731449C82991849_inline(((int32_t)16), ((int32_t)il2cpp_codegen_subtract(L_27, L_28)), NULL);
		V_8 = L_29;
		V_9 = 1;
		goto IL_00b3;
	}

IL_009b:
	{
		int32_t* L_30 = V_1;
		int32_t L_31 = V_0;
		int32_t L_32 = V_9;
		int32_t L_33 = V_0;
		int32_t L_34 = V_9;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_30, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_add(L_31, L_32))), 4))))) = (int32_t)((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_33, L_34)), 1));
		int32_t L_35 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add(L_35, 1));
	}

IL_00b3:
	{
		int32_t L_36 = V_9;
		int32_t L_37 = V_8;
		V_10 = (bool)((((int32_t)L_36) < ((int32_t)L_37))? 1 : 0);
		bool L_38 = V_10;
		if (L_38)
		{
			goto IL_009b;
		}
	}
	{
		int32_t* L_39 = V_1;
		int32_t L_40 = V_0;
		int32_t L_41 = V_8;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_39, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_40, L_41)), 1))), 4))))) = (int32_t)(-1);
		int32_t* L_42 = V_1;
		int32_t L_43 = V_0;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_42, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_43), 4))))) = (int32_t)(-1);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_44 = ___0_data;
		int32_t* L_45;
		L_45 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_44, NULL);
		int32_t L_46 = ___1_threadIndex;
		int32_t L_47 = V_0;
		int32_t L_48;
		L_48 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_45, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_46, ((int32_t)16)))), 4)))), ((int32_t)il2cpp_codegen_add(L_47, 1)), NULL);
		int32_t L_49 = V_0;
		V_11 = L_49;
		goto IL_026c;
	}

IL_00f3:
	{
		int32_t L_50 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_51 = ___0_data;
		NullCheck(L_51);
		int32_t L_52 = L_51->___keyCapacity;
		V_12 = (bool)((((int32_t)L_50) == ((int32_t)((int32_t)il2cpp_codegen_subtract(L_52, 1))))? 1 : 0);
		bool L_53 = V_12;
		if (!L_53)
		{
			goto IL_0122;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_54 = ___0_data;
		int32_t* L_55;
		L_55 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_54, NULL);
		int32_t L_56 = ___1_threadIndex;
		int32_t L_57;
		L_57 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_55, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_56, ((int32_t)16)))), 4)))), (-1), NULL);
		int32_t L_58 = V_0;
		V_11 = L_58;
		goto IL_026c;
	}

IL_0122:
	{
	}

IL_0123:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_59 = ___0_data;
		int32_t* L_60;
		L_60 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_59, NULL);
		int32_t L_61 = ___1_threadIndex;
		int32_t L_62;
		L_62 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_60, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_61, ((int32_t)16)))), 4)))), (-1), NULL);
		int32_t L_63;
		L_63 = JobsUtility_get_ThreadIndexCount_m88A954344398143540618B35943F863B92465676(NULL);
		V_4 = L_63;
		V_5 = (bool)1;
		goto IL_0212;
	}

IL_0147:
	{
		V_5 = (bool)0;
		int32_t L_64 = ___1_threadIndex;
		int32_t L_65 = V_4;
		V_13 = ((int32_t)(((int32_t)il2cpp_codegen_add(L_64, 1))%L_65));
		goto IL_0200;
	}

IL_0158:
	{
	}

IL_0159:
	{
	}

IL_015a:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_66 = ___0_data;
		int32_t* L_67;
		L_67 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_66, NULL);
		int32_t L_68 = V_13;
		int32_t L_69;
		L_69 = VolatileRead((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_67, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_68, ((int32_t)16)))), 4)))));
		V_0 = L_69;
		int32_t L_70 = V_0;
		V_14 = (bool)((((int32_t)L_70) == ((int32_t)((int32_t)-3)))? 1 : 0);
		bool L_71 = V_14;
		if (L_71)
		{
			goto IL_015a;
		}
	}
	{
		int32_t L_72 = V_0;
		V_15 = (bool)((((int32_t)L_72) < ((int32_t)0))? 1 : 0);
		bool L_73 = V_15;
		if (!L_73)
		{
			goto IL_0189;
		}
	}
	{
		goto IL_01ad;
	}

IL_0189:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_74 = ___0_data;
		int32_t* L_75;
		L_75 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_74, NULL);
		int32_t L_76 = V_13;
		int32_t L_77 = V_0;
		int32_t L_78;
		L_78 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_75, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_76, ((int32_t)16)))), 4)))), ((int32_t)-3), L_77, NULL);
		int32_t L_79 = V_0;
		V_16 = (bool)((((int32_t)((((int32_t)L_78) == ((int32_t)L_79))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_80 = V_16;
		if (L_80)
		{
			goto IL_0159;
		}
	}

IL_01ad:
	{
		int32_t L_81 = V_0;
		V_17 = (bool)((((int32_t)L_81) == ((int32_t)((int32_t)-2)))? 1 : 0);
		bool L_82 = V_17;
		if (!L_82)
		{
			goto IL_01bf;
		}
	}
	{
		V_5 = (bool)1;
		goto IL_01f6;
	}

IL_01bf:
	{
		int32_t L_83 = V_0;
		V_18 = (bool)((((int32_t)((((int32_t)L_83) < ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_84 = V_18;
		if (!L_84)
		{
			goto IL_01f6;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_85 = ___0_data;
		int32_t* L_86;
		L_86 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_85, NULL);
		int32_t L_87 = V_13;
		int32_t* L_88 = V_1;
		int32_t L_89 = V_0;
		int32_t L_90 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_88, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_89), 4))))));
		int32_t L_91;
		L_91 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_86, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_87, ((int32_t)16)))), 4)))), L_90, NULL);
		int32_t* L_92 = V_1;
		int32_t L_93 = V_0;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_92, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_93), 4))))) = (int32_t)(-1);
		int32_t L_94 = V_0;
		V_11 = L_94;
		goto IL_026c;
	}

IL_01f6:
	{
		int32_t L_95 = V_13;
		int32_t L_96 = V_4;
		V_13 = ((int32_t)(((int32_t)il2cpp_codegen_add(L_95, 1))%L_96));
	}

IL_0200:
	{
		int32_t L_97 = V_13;
		int32_t L_98 = ___1_threadIndex;
		V_19 = (bool)((((int32_t)((((int32_t)L_97) == ((int32_t)L_98))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_99 = V_19;
		if (L_99)
		{
			goto IL_0158;
		}
	}
	{
	}

IL_0212:
	{
		bool L_100 = V_5;
		V_20 = L_100;
		bool L_101 = V_20;
		if (L_101)
		{
			goto IL_0147;
		}
	}
	{
	}

IL_021e:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_102 = ___0_data;
		int32_t* L_103;
		L_103 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_102, NULL);
		int32_t L_104 = ___1_threadIndex;
		int32_t L_105 = V_0;
		int32_t L_106;
		L_106 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_103, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_104, ((int32_t)16)))), 4)))), ((int32_t)-3), L_105, NULL);
		int32_t L_107 = V_0;
		V_21 = (bool)((((int32_t)((((int32_t)L_106) == ((int32_t)L_107))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_108 = V_21;
		if (L_108)
		{
			goto IL_0008;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_109 = ___0_data;
		int32_t* L_110;
		L_110 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_109, NULL);
		int32_t L_111 = ___1_threadIndex;
		int32_t* L_112 = V_1;
		int32_t L_113 = V_0;
		int32_t L_114 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_112, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_113), 4))))));
		int32_t L_115;
		L_115 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_110, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_111, ((int32_t)16)))), 4)))), L_114, NULL);
		int32_t* L_116 = V_1;
		int32_t L_117 = V_0;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_116, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_117), 4))))) = (int32_t)(-1);
		int32_t L_118 = V_0;
		V_11 = L_118;
		goto IL_026c;
	}

IL_026c:
	{
		int32_t L_119 = V_11;
		return L_119;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_FreeEntry_mC0307320846285CEBB98C0EF64D1880A4876EBB6_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_idx, int32_t ___2_threadIndex, const RuntimeMethod* method) 
{
	int32_t* V_0 = NULL;
	int32_t V_1 = 0;
	bool V_2 = false;
	bool V_3 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___next;
		V_0 = (int32_t*)L_1;
		V_1 = (-1);
	}

IL_000a:
	{
	}

IL_000b:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		int32_t* L_3;
		L_3 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_2, NULL);
		int32_t L_4 = ___2_threadIndex;
		int32_t L_5;
		L_5 = VolatileRead((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_3, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_4, ((int32_t)16)))), 4)))));
		V_1 = L_5;
		int32_t L_6 = V_1;
		V_2 = (bool)((((int32_t)L_6) == ((int32_t)((int32_t)-3)))? 1 : 0);
		bool L_7 = V_2;
		if (L_7)
		{
			goto IL_000b;
		}
	}
	{
		int32_t* L_8 = V_0;
		int32_t L_9 = ___1_idx;
		int32_t L_10 = V_1;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_8, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_9), 4))))) = (int32_t)L_10;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_11 = ___0_data;
		int32_t* L_12;
		L_12 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_11, NULL);
		int32_t L_13 = ___2_threadIndex;
		int32_t L_14 = ___1_idx;
		int32_t L_15 = V_1;
		int32_t L_16;
		L_16 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_12, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_13, ((int32_t)16)))), 4)))), L_14, L_15, NULL);
		int32_t L_17 = V_1;
		V_3 = (bool)((((int32_t)((((int32_t)L_16) == ((int32_t)L_17))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_18 = V_3;
		if (L_18)
		{
			goto IL_000a;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryAddAtomic_m0E59C749F5C3995145CFD54DB36FDAA9B1378C6D_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B ___2_item, int32_t ___3_threadIndex, const RuntimeMethod* method) 
{
	InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B V_0;
	memset((&V_0), 0, sizeof(V_0));
	NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC V_1;
	memset((&V_1), 0, sizeof(V_1));
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	int32_t* V_4 = NULL;
	bool V_5 = false;
	bool V_6 = false;
	bool V_7 = false;
	int32_t* V_8 = NULL;
	int32_t V_9 = 0;
	bool V_10 = false;
	bool V_11 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		int32_t L_1 = ___1_key;
		bool L_2;
		L_2 = UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mA5FCFB37B4C19FD5FF7B0660AAE55181A6A68C1F(L_0, L_1, (&V_0), (&V_1), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_5 = L_2;
		bool L_3 = V_5;
		if (!L_3)
		{
			goto IL_001b;
		}
	}
	{
		V_6 = (bool)0;
		goto IL_00da;
	}

IL_001b:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = ___0_data;
		int32_t L_5 = ___3_threadIndex;
		int32_t L_6;
		L_6 = UnsafeParallelHashMapBase_2_AllocEntry_mA60C7AAB43656E7611E27393BC6AB7E52163A000(L_4, L_5, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		V_2 = L_6;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		uint8_t* L_8 = L_7->___keys;
		int32_t L_9 = V_2;
		int32_t L_10 = ___1_key;
		UnsafeUtility_WriteArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m0DD1CC90B2F1EF5041F2F4E1DABB58224229F0D7_inline((void*)L_8, L_9, L_10, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 6));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_11 = ___0_data;
		NullCheck(L_11);
		uint8_t* L_12 = L_11->___values;
		int32_t L_13 = V_2;
		InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B L_14 = ___2_item;
		UnsafeUtility_WriteArrayElement_TisInstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B_m2D4905CE9CCFB4EF383D04FA0F872F621E08A309_inline((void*)L_12, L_13, L_14, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		int32_t L_15;
		L_15 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_16 = ___0_data;
		NullCheck(L_16);
		int32_t L_17 = L_16->___bucketCapacityMask;
		V_3 = ((int32_t)(L_15&L_17));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_18 = ___0_data;
		NullCheck(L_18);
		uint8_t* L_19 = L_18->___buckets;
		V_4 = (int32_t*)L_19;
		int32_t* L_20 = V_4;
		int32_t L_21 = V_3;
		int32_t L_22 = V_2;
		int32_t L_23;
		L_23 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_20, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_21), 4)))), L_22, (-1), NULL);
		V_7 = (bool)((((int32_t)((((int32_t)L_23) == ((int32_t)(-1)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_24 = V_7;
		if (!L_24)
		{
			goto IL_00d5;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_25 = ___0_data;
		NullCheck(L_25);
		uint8_t* L_26 = L_25->___next;
		V_8 = (int32_t*)L_26;
		V_9 = (-1);
	}

IL_0082:
	{
		int32_t* L_27 = V_4;
		int32_t L_28 = V_3;
		int32_t L_29 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_27, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_28), 4))))));
		V_9 = L_29;
		int32_t* L_30 = V_8;
		int32_t L_31 = V_2;
		int32_t L_32 = V_9;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_30, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_31), 4))))) = (int32_t)L_32;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_33 = ___0_data;
		int32_t L_34 = ___1_key;
		bool L_35;
		L_35 = UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mA5FCFB37B4C19FD5FF7B0660AAE55181A6A68C1F(L_33, L_34, (&V_0), (&V_1), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_10 = L_35;
		bool L_36 = V_10;
		if (!L_36)
		{
			goto IL_00b7;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_37 = ___0_data;
		int32_t L_38 = V_2;
		int32_t L_39 = ___3_threadIndex;
		UnsafeParallelHashMapBase_2_FreeEntry_mC0307320846285CEBB98C0EF64D1880A4876EBB6(L_37, L_38, L_39, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 10));
		V_6 = (bool)0;
		goto IL_00da;
	}

IL_00b7:
	{
		int32_t* L_40 = V_4;
		int32_t L_41 = V_3;
		int32_t L_42 = V_2;
		int32_t L_43 = V_9;
		int32_t L_44;
		L_44 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_40, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_41), 4)))), L_42, L_43, NULL);
		int32_t L_45 = V_9;
		V_11 = (bool)((((int32_t)((((int32_t)L_44) == ((int32_t)L_45))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_46 = V_11;
		if (L_46)
		{
			goto IL_0082;
		}
	}
	{
	}

IL_00d5:
	{
		V_6 = (bool)1;
		goto IL_00da;
	}

IL_00da:
	{
		bool L_47 = V_6;
		return L_47;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryAdd_m450B8516C47AE46DC2F9EBD35EA5DCDE2FE8268E_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B ___2_item, bool ___3_isMultiHashMap, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___4_allocation, const RuntimeMethod* method) 
{
	InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B V_0;
	memset((&V_0), 0, sizeof(V_0));
	NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC V_1;
	memset((&V_1), 0, sizeof(V_1));
	bool V_2 = false;
	int32_t V_3 = 0;
	int32_t* V_4 = NULL;
	int32_t V_5 = 0;
	int32_t* V_6 = NULL;
	bool V_7 = false;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	bool V_10 = false;
	bool V_11 = false;
	bool V_12 = false;
	int32_t V_13 = 0;
	bool V_14 = false;
	int32_t V_15 = 0;
	bool V_16 = false;
	int32_t G_B3_0 = 0;
	int32_t G_B7_0 = 0;
	{
		bool L_0 = ___3_isMultiHashMap;
		if (L_0)
		{
			goto IL_0014;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_1 = ___0_data;
		int32_t L_2 = ___1_key;
		bool L_3;
		L_3 = UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mA5FCFB37B4C19FD5FF7B0660AAE55181A6A68C1F(L_1, L_2, (&V_0), (&V_1), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		G_B3_0 = ((((int32_t)L_3) == ((int32_t)0))? 1 : 0);
		goto IL_0015;
	}

IL_0014:
	{
		G_B3_0 = 1;
	}

IL_0015:
	{
		V_2 = (bool)G_B3_0;
		bool L_4 = V_2;
		if (!L_4)
		{
			goto IL_0197;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_5 = ___0_data;
		NullCheck(L_5);
		int32_t L_6 = L_5->___allocatedIndexLength;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		int32_t L_8 = L_7->___keyCapacity;
		if ((((int32_t)L_6) < ((int32_t)L_8)))
		{
			goto IL_0037;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_9 = ___0_data;
		int32_t* L_10;
		L_10 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_9, NULL);
		int32_t L_11 = (*(L_10));
		G_B7_0 = ((((int32_t)L_11) < ((int32_t)0))? 1 : 0);
		goto IL_0038;
	}

IL_0037:
	{
		G_B7_0 = 0;
	}

IL_0038:
	{
		V_7 = (bool)G_B7_0;
		bool L_12 = V_7;
		if (!L_12)
		{
			goto IL_00f5;
		}
	}
	{
		int32_t L_13;
		L_13 = JobsUtility_get_ThreadIndexCount_m88A954344398143540618B35943F863B92465676(NULL);
		V_8 = L_13;
		V_9 = 1;
		goto IL_00b7;
	}

IL_004e:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_14 = ___0_data;
		int32_t* L_15;
		L_15 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_14, NULL);
		int32_t L_16 = V_9;
		int32_t L_17 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_15, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_16, ((int32_t)16)))), 4))))));
		V_10 = (bool)((((int32_t)((((int32_t)L_17) < ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_18 = V_10;
		if (!L_18)
		{
			goto IL_00b0;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_19 = ___0_data;
		int32_t* L_20;
		L_20 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_19, NULL);
		int32_t L_21 = V_9;
		int32_t L_22 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_20, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_21, ((int32_t)16)))), 4))))));
		V_3 = L_22;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_23 = ___0_data;
		NullCheck(L_23);
		uint8_t* L_24 = L_23->___next;
		V_4 = (int32_t*)L_24;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_25 = ___0_data;
		int32_t* L_26;
		L_26 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_25, NULL);
		int32_t L_27 = V_9;
		int32_t* L_28 = V_4;
		int32_t L_29 = V_3;
		int32_t L_30 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_28, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_29), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_26, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_27, ((int32_t)16)))), 4))))) = (int32_t)L_30;
		int32_t* L_31 = V_4;
		int32_t L_32 = V_3;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_31, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_32), 4))))) = (int32_t)(-1);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_33 = ___0_data;
		int32_t* L_34;
		L_34 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_33, NULL);
		int32_t L_35 = V_3;
		*((int32_t*)L_34) = (int32_t)L_35;
		goto IL_00c3;
	}

IL_00b0:
	{
		int32_t L_36 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add(L_36, 1));
	}

IL_00b7:
	{
		int32_t L_37 = V_9;
		int32_t L_38 = V_8;
		V_11 = (bool)((((int32_t)L_37) < ((int32_t)L_38))? 1 : 0);
		bool L_39 = V_11;
		if (L_39)
		{
			goto IL_004e;
		}
	}

IL_00c3:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_40 = ___0_data;
		int32_t* L_41;
		L_41 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_40, NULL);
		int32_t L_42 = (*(L_41));
		V_12 = (bool)((((int32_t)L_42) < ((int32_t)0))? 1 : 0);
		bool L_43 = V_12;
		if (!L_43)
		{
			goto IL_00f4;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_44 = ___0_data;
		NullCheck(L_44);
		int32_t L_45 = L_44->___keyCapacity;
		int32_t L_46;
		L_46 = UnsafeParallelHashMapData_GrowCapacity_m7F2FF57E76510A99266830779059C6C202B9EC47(L_45, NULL);
		V_13 = L_46;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_47 = ___0_data;
		int32_t L_48 = V_13;
		int32_t L_49 = V_13;
		int32_t L_50;
		L_50 = UnsafeParallelHashMapData_GetBucketSize_mEF90FF75EFE70E4B59CD6AF9FDCB3D564A1986A3(L_49, NULL);
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_51 = ___4_allocation;
		UnsafeParallelHashMapData_ReallocateHashMap_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_TisInstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B_mD9CA815618E4ED4EC44B7F5D9D7ACF7649BEF9AF(L_47, L_48, L_50, L_51, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
	}

IL_00f4:
	{
	}

IL_00f5:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_52 = ___0_data;
		int32_t* L_53;
		L_53 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_52, NULL);
		int32_t L_54 = (*(L_53));
		V_3 = L_54;
		int32_t L_55 = V_3;
		V_14 = (bool)((((int32_t)((((int32_t)L_55) < ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_56 = V_14;
		if (!L_56)
		{
			goto IL_0121;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_57 = ___0_data;
		int32_t* L_58;
		L_58 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_57, NULL);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_59 = ___0_data;
		NullCheck(L_59);
		uint8_t* L_60 = L_59->___next;
		int32_t L_61 = V_3;
		int32_t L_62 = *((int32_t*)((uint8_t*)il2cpp_codegen_add((intptr_t)L_60, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_61), 4)))));
		*((int32_t*)L_58) = (int32_t)L_62;
		goto IL_0135;
	}

IL_0121:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_63 = ___0_data;
		NullCheck(L_63);
		int32_t* L_64 = (int32_t*)(&L_63->___allocatedIndexLength);
		int32_t* L_65 = L_64;
		int32_t L_66 = *((int32_t*)L_65);
		V_15 = L_66;
		int32_t L_67 = V_15;
		*((int32_t*)L_65) = (int32_t)((int32_t)il2cpp_codegen_add(L_67, 1));
		int32_t L_68 = V_15;
		V_3 = L_68;
	}

IL_0135:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_69 = ___0_data;
		NullCheck(L_69);
		uint8_t* L_70 = L_69->___keys;
		int32_t L_71 = V_3;
		int32_t L_72 = ___1_key;
		UnsafeUtility_WriteArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m0DD1CC90B2F1EF5041F2F4E1DABB58224229F0D7_inline((void*)L_70, L_71, L_72, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 6));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_73 = ___0_data;
		NullCheck(L_73);
		uint8_t* L_74 = L_73->___values;
		int32_t L_75 = V_3;
		InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B L_76 = ___2_item;
		UnsafeUtility_WriteArrayElement_TisInstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B_m2D4905CE9CCFB4EF383D04FA0F872F621E08A309_inline((void*)L_74, L_75, L_76, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		int32_t L_77;
		L_77 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_78 = ___0_data;
		NullCheck(L_78);
		int32_t L_79 = L_78->___bucketCapacityMask;
		V_5 = ((int32_t)(L_77&L_79));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_80 = ___0_data;
		NullCheck(L_80);
		uint8_t* L_81 = L_80->___buckets;
		V_6 = (int32_t*)L_81;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_82 = ___0_data;
		NullCheck(L_82);
		uint8_t* L_83 = L_82->___next;
		V_4 = (int32_t*)L_83;
		int32_t* L_84 = V_4;
		int32_t L_85 = V_3;
		int32_t* L_86 = V_6;
		int32_t L_87 = V_5;
		int32_t L_88 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_86, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_87), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_84, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_85), 4))))) = (int32_t)L_88;
		int32_t* L_89 = V_6;
		int32_t L_90 = V_5;
		int32_t L_91 = V_3;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_89, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_90), 4))))) = (int32_t)L_91;
		V_16 = (bool)1;
		goto IL_019c;
	}

IL_0197:
	{
		V_16 = (bool)0;
		goto IL_019c;
	}

IL_019c:
	{
		bool L_92 = V_16;
		return L_92;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapBase_2_Remove_m5D6AEA333632082B84439F9086EDF7DC99347A25_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, bool ___2_isMultiHashMap, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t* V_1 = NULL;
	int32_t* V_2 = NULL;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	bool V_6 = false;
	int32_t V_7 = 0;
	bool V_8 = false;
	int32_t V_9 = 0;
	int32_t V_10 = 0;
	bool V_11 = false;
	bool V_12 = false;
	bool V_13 = false;
	int32_t G_B15_0 = 0;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		int32_t L_1 = L_0->___keyCapacity;
		V_6 = (bool)((((int32_t)L_1) == ((int32_t)0))? 1 : 0);
		bool L_2 = V_6;
		if (!L_2)
		{
			goto IL_0019;
		}
	}
	{
		V_7 = 0;
		goto IL_010f;
	}

IL_0019:
	{
		V_0 = 0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_3 = ___0_data;
		NullCheck(L_3);
		uint8_t* L_4 = L_3->___buckets;
		V_1 = (int32_t*)L_4;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_5 = ___0_data;
		NullCheck(L_5);
		uint8_t* L_6 = L_5->___next;
		V_2 = (int32_t*)L_6;
		int32_t L_7;
		L_7 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_8 = ___0_data;
		NullCheck(L_8);
		int32_t L_9 = L_8->___bucketCapacityMask;
		V_3 = ((int32_t)(L_7&L_9));
		V_4 = (-1);
		int32_t* L_10 = V_1;
		int32_t L_11 = V_3;
		int32_t L_12 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_10, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_11), 4))))));
		V_5 = L_12;
		goto IL_00ef;
	}

IL_004f:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_13 = ___0_data;
		NullCheck(L_13);
		uint8_t* L_14 = L_13->___keys;
		int32_t L_15 = V_5;
		int32_t L_16;
		L_16 = UnsafeUtility_ReadArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_mFBA66C06ECEB0A2BC1AAE634B6E6BB436F957084_inline((void*)L_14, L_15, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		V_9 = L_16;
		int32_t L_17 = ___1_key;
		bool L_18;
		L_18 = Int32_Equals_mC819D19A661B95BE253FB1769FD4D91961D20722((&V_9), L_17, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 15));
		V_8 = L_18;
		bool L_19 = V_8;
		if (!L_19)
		{
			goto IL_00de;
		}
	}
	{
		int32_t L_20 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add(L_20, 1));
		int32_t L_21 = V_4;
		V_11 = (bool)((((int32_t)L_21) < ((int32_t)0))? 1 : 0);
		bool L_22 = V_11;
		if (!L_22)
		{
			goto IL_0096;
		}
	}
	{
		int32_t* L_23 = V_1;
		int32_t L_24 = V_3;
		int32_t* L_25 = V_2;
		int32_t L_26 = V_5;
		int32_t L_27 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_25, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_26), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_23, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_24), 4))))) = (int32_t)L_27;
		goto IL_00a8;
	}

IL_0096:
	{
		int32_t* L_28 = V_2;
		int32_t L_29 = V_4;
		int32_t* L_30 = V_2;
		int32_t L_31 = V_5;
		int32_t L_32 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_30, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_31), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_28, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_29), 4))))) = (int32_t)L_32;
	}

IL_00a8:
	{
		int32_t* L_33 = V_2;
		int32_t L_34 = V_5;
		int32_t L_35 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_33, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_34), 4))))));
		V_10 = L_35;
		int32_t* L_36 = V_2;
		int32_t L_37 = V_5;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_38 = ___0_data;
		int32_t* L_39;
		L_39 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_38, NULL);
		int32_t L_40 = (*(L_39));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_36, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_37), 4))))) = (int32_t)L_40;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_41 = ___0_data;
		int32_t* L_42;
		L_42 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_41, NULL);
		int32_t L_43 = V_5;
		*((int32_t*)L_42) = (int32_t)L_43;
		int32_t L_44 = V_10;
		V_5 = L_44;
		bool L_45 = ___2_isMultiHashMap;
		V_12 = (bool)((((int32_t)L_45) == ((int32_t)0))? 1 : 0);
		bool L_46 = V_12;
		if (!L_46)
		{
			goto IL_00db;
		}
	}
	{
		goto IL_010a;
	}

IL_00db:
	{
		goto IL_00ee;
	}

IL_00de:
	{
		int32_t L_47 = V_5;
		V_4 = L_47;
		int32_t* L_48 = V_2;
		int32_t L_49 = V_5;
		int32_t L_50 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_48, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_49), 4))))));
		V_5 = L_50;
	}

IL_00ee:
	{
	}

IL_00ef:
	{
		int32_t L_51 = V_5;
		if ((((int32_t)L_51) < ((int32_t)0)))
		{
			goto IL_0100;
		}
	}
	{
		int32_t L_52 = V_5;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_53 = ___0_data;
		NullCheck(L_53);
		int32_t L_54 = L_53->___keyCapacity;
		G_B15_0 = ((((int32_t)L_52) < ((int32_t)L_54))? 1 : 0);
		goto IL_0101;
	}

IL_0100:
	{
		G_B15_0 = 0;
	}

IL_0101:
	{
		V_13 = (bool)G_B15_0;
		bool L_55 = V_13;
		if (L_55)
		{
			goto IL_004f;
		}
	}

IL_010a:
	{
		int32_t L_56 = V_0;
		V_7 = L_56;
		goto IL_010f;
	}

IL_010f:
	{
		int32_t L_57 = V_7;
		return L_57;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_Remove_m4EA4A3FEF1A7229781E9C677F5F5D71A120B2C65_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC ___1_it, const RuntimeMethod* method) 
{
	int32_t* V_0 = NULL;
	int32_t* V_1 = NULL;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	bool V_4 = false;
	bool V_5 = false;
	bool V_6 = false;
	int32_t G_B7_0 = 0;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___buckets;
		V_0 = (int32_t*)L_1;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		NullCheck(L_2);
		uint8_t* L_3 = L_2->___next;
		V_1 = (int32_t*)L_3;
		int32_t* L_4 = (int32_t*)(&(&___1_it)->___key);
		int32_t L_5;
		L_5 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295(L_4, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_6 = ___0_data;
		NullCheck(L_6);
		int32_t L_7 = L_6->___bucketCapacityMask;
		V_2 = ((int32_t)(L_5&L_7));
		int32_t* L_8 = V_0;
		int32_t L_9 = V_2;
		int32_t L_10 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_8, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_9), 4))))));
		V_3 = L_10;
		int32_t L_11 = V_3;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC L_12 = ___1_it;
		int32_t L_13 = L_12.___EntryIndex;
		V_4 = (bool)((((int32_t)L_11) == ((int32_t)L_13))? 1 : 0);
		bool L_14 = V_4;
		if (!L_14)
		{
			goto IL_0052;
		}
	}
	{
		int32_t* L_15 = V_0;
		int32_t L_16 = V_2;
		int32_t* L_17 = V_1;
		int32_t L_18 = V_3;
		int32_t L_19 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_17, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_18), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_15, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_16), 4))))) = (int32_t)L_19;
		goto IL_009e;
	}

IL_0052:
	{
		goto IL_005f;
	}

IL_0055:
	{
		int32_t* L_20 = V_1;
		int32_t L_21 = V_3;
		int32_t L_22 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_20, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_21), 4))))));
		V_3 = L_22;
	}

IL_005f:
	{
		int32_t L_23 = V_3;
		if ((((int32_t)L_23) < ((int32_t)0)))
		{
			goto IL_0077;
		}
	}
	{
		int32_t* L_24 = V_1;
		int32_t L_25 = V_3;
		int32_t L_26 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_24, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_25), 4))))));
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC L_27 = ___1_it;
		int32_t L_28 = L_27.___EntryIndex;
		G_B7_0 = ((((int32_t)((((int32_t)L_26) == ((int32_t)L_28))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0078;
	}

IL_0077:
	{
		G_B7_0 = 0;
	}

IL_0078:
	{
		V_5 = (bool)G_B7_0;
		bool L_29 = V_5;
		if (L_29)
		{
			goto IL_0055;
		}
	}
	{
		int32_t L_30 = V_3;
		V_6 = (bool)((((int32_t)L_30) < ((int32_t)0))? 1 : 0);
		bool L_31 = V_6;
		if (!L_31)
		{
			goto IL_008a;
		}
	}
	{
	}

IL_008a:
	{
		int32_t* L_32 = V_1;
		int32_t L_33 = V_3;
		int32_t* L_34 = V_1;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC L_35 = ___1_it;
		int32_t L_36 = L_35.___EntryIndex;
		int32_t L_37 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_34, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_36), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_32, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_33), 4))))) = (int32_t)L_37;
	}

IL_009e:
	{
		int32_t* L_38 = V_1;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC L_39 = ___1_it;
		int32_t L_40 = L_39.___EntryIndex;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_41 = ___0_data;
		int32_t* L_42;
		L_42 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_41, NULL);
		int32_t L_43 = (*(L_42));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_38, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_40), 4))))) = (int32_t)L_43;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_44 = ___0_data;
		int32_t* L_45;
		L_45 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_44, NULL);
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC L_46 = ___1_it;
		int32_t L_47 = L_46.___EntryIndex;
		*((int32_t*)L_45) = (int32_t)L_47;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mA5FCFB37B4C19FD5FF7B0660AAE55181A6A68C1F_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B* ___2_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___3_it, const RuntimeMethod* method) 
{
	int32_t* V_0 = NULL;
	int32_t V_1 = 0;
	bool V_2 = false;
	int32_t V_3 = 0;
	bool V_4 = false;
	{
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_0 = ___3_it;
		int32_t L_1 = ___1_key;
		L_0->___key = L_1;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		NullCheck(L_2);
		int32_t L_3 = L_2->___allocatedIndexLength;
		V_2 = (bool)((((int32_t)((((int32_t)L_3) > ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_4 = V_2;
		if (!L_4)
		{
			goto IL_0035;
		}
	}
	{
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_5 = ___3_it;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_6 = ___3_it;
		int32_t L_7 = (-1);
		V_3 = L_7;
		L_6->___NextEntryIndex = L_7;
		int32_t L_8 = V_3;
		L_5->___EntryIndex = L_8;
		InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B* L_9 = ___2_item;
		il2cpp_codegen_initobj(L_9, sizeof(InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B));
		V_4 = (bool)0;
		goto IL_0073;
	}

IL_0035:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_10 = ___0_data;
		NullCheck(L_10);
		uint8_t* L_11 = L_10->___buckets;
		V_0 = (int32_t*)L_11;
		int32_t L_12;
		L_12 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_13 = ___0_data;
		NullCheck(L_13);
		int32_t L_14 = L_13->___bucketCapacityMask;
		V_1 = ((int32_t)(L_12&L_14));
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_15 = ___3_it;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_16 = ___3_it;
		int32_t* L_17 = V_0;
		int32_t L_18 = V_1;
		int32_t L_19 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_17, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_18), 4))))));
		int32_t L_20 = L_19;
		V_3 = L_20;
		L_16->___NextEntryIndex = L_20;
		int32_t L_21 = V_3;
		L_15->___EntryIndex = L_21;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_22 = ___0_data;
		InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B* L_23 = ___2_item;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_24 = ___3_it;
		bool L_25;
		L_25 = UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m907C21D03B0B07E416159F61AE6322D367A27C05(L_22, L_23, L_24, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 16));
		V_4 = L_25;
		goto IL_0073;
	}

IL_0073:
	{
		bool L_26 = V_4;
		return L_26;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m907C21D03B0B07E416159F61AE6322D367A27C05_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B* ___1_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___2_it, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t* V_1 = NULL;
	bool V_2 = false;
	bool V_3 = false;
	bool V_4 = false;
	bool V_5 = false;
	int32_t V_6 = 0;
	int32_t G_B3_0 = 0;
	int32_t G_B9_0 = 0;
	{
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_0 = ___2_it;
		int32_t L_1 = L_0->___NextEntryIndex;
		V_0 = L_1;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_2 = ___2_it;
		L_2->___NextEntryIndex = (-1);
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_3 = ___2_it;
		L_3->___EntryIndex = (-1);
		InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B* L_4 = ___1_item;
		il2cpp_codegen_initobj(L_4, sizeof(InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B));
		int32_t L_5 = V_0;
		if ((((int32_t)L_5) < ((int32_t)0)))
		{
			goto IL_002f;
		}
	}
	{
		int32_t L_6 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		int32_t L_8 = L_7->___keyCapacity;
		G_B3_0 = ((((int32_t)((((int32_t)L_6) < ((int32_t)L_8))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0030;
	}

IL_002f:
	{
		G_B3_0 = 1;
	}

IL_0030:
	{
		V_2 = (bool)G_B3_0;
		bool L_9 = V_2;
		if (!L_9)
		{
			goto IL_003c;
		}
	}
	{
		V_3 = (bool)0;
		goto IL_00c1;
	}

IL_003c:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_10 = ___0_data;
		NullCheck(L_10);
		uint8_t* L_11 = L_10->___next;
		V_1 = (int32_t*)L_11;
		goto IL_006d;
	}

IL_0045:
	{
		int32_t* L_12 = V_1;
		int32_t L_13 = V_0;
		int32_t L_14 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_12, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_13), 4))))));
		V_0 = L_14;
		int32_t L_15 = V_0;
		if ((((int32_t)L_15) < ((int32_t)0)))
		{
			goto IL_0060;
		}
	}
	{
		int32_t L_16 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_17 = ___0_data;
		NullCheck(L_17);
		int32_t L_18 = L_17->___keyCapacity;
		G_B9_0 = ((((int32_t)((((int32_t)L_16) < ((int32_t)L_18))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0061;
	}

IL_0060:
	{
		G_B9_0 = 1;
	}

IL_0061:
	{
		V_4 = (bool)G_B9_0;
		bool L_19 = V_4;
		if (!L_19)
		{
			goto IL_006c;
		}
	}
	{
		V_3 = (bool)0;
		goto IL_00c1;
	}

IL_006c:
	{
	}

IL_006d:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_20 = ___0_data;
		NullCheck(L_20);
		uint8_t* L_21 = L_20->___keys;
		int32_t L_22 = V_0;
		int32_t L_23;
		L_23 = UnsafeUtility_ReadArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_mFBA66C06ECEB0A2BC1AAE634B6E6BB436F957084_inline((void*)L_21, L_22, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		V_6 = L_23;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_24 = ___2_it;
		int32_t L_25 = L_24->___key;
		bool L_26;
		L_26 = Int32_Equals_mC819D19A661B95BE253FB1769FD4D91961D20722((&V_6), L_25, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 15));
		V_5 = (bool)((((int32_t)L_26) == ((int32_t)0))? 1 : 0);
		bool L_27 = V_5;
		if (L_27)
		{
			goto IL_0045;
		}
	}
	{
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_28 = ___2_it;
		int32_t* L_29 = V_1;
		int32_t L_30 = V_0;
		int32_t L_31 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_29, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_30), 4))))));
		L_28->___NextEntryIndex = L_31;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_32 = ___2_it;
		int32_t L_33 = V_0;
		L_32->___EntryIndex = L_33;
		InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B* L_34 = ___1_item;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_35 = ___0_data;
		NullCheck(L_35);
		uint8_t* L_36 = L_35->___values;
		int32_t L_37 = V_0;
		InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B L_38;
		L_38 = UnsafeUtility_ReadArrayElement_TisInstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B_m86FC76E325E9D3B56133BB7A193BAF12B47FBCC1_inline((void*)L_36, L_37, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 17));
		*(InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B*)L_34 = L_38;
		V_3 = (bool)1;
		goto IL_00c1;
	}

IL_00c1:
	{
		bool L_39 = V_3;
		return L_39;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_SetValue_m8F11784964EF3E22F8574119728AAEE91BD22524_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___1_it, InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B* ___2_item, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	bool V_1 = false;
	bool V_2 = false;
	int32_t G_B3_0 = 0;
	{
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_0 = ___1_it;
		int32_t L_1 = L_0->___EntryIndex;
		V_0 = L_1;
		int32_t L_2 = V_0;
		if ((((int32_t)L_2) < ((int32_t)0)))
		{
			goto IL_001a;
		}
	}
	{
		int32_t L_3 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = ___0_data;
		NullCheck(L_4);
		int32_t L_5 = L_4->___keyCapacity;
		G_B3_0 = ((((int32_t)((((int32_t)L_3) < ((int32_t)L_5))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_001b;
	}

IL_001a:
	{
		G_B3_0 = 1;
	}

IL_001b:
	{
		V_1 = (bool)G_B3_0;
		bool L_6 = V_1;
		if (!L_6)
		{
			goto IL_0024;
		}
	}
	{
		V_2 = (bool)0;
		goto IL_003b;
	}

IL_0024:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		uint8_t* L_8 = L_7->___values;
		int32_t L_9 = V_0;
		InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B* L_10 = ___2_item;
		InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B L_11 = (*(InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B*)L_10);
		UnsafeUtility_WriteArrayElement_TisInstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B_m2D4905CE9CCFB4EF383D04FA0F872F621E08A309_inline((void*)L_8, L_9, L_11, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		V_2 = (bool)1;
		goto IL_003b;
	}

IL_003b:
	{
		bool L_12 = V_2;
		return L_12;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_Clear_mEF3A98FABCE256A22409653F694F4C72E3DDB4DC_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	bool V_2 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___buckets;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		NullCheck(L_2);
		int32_t L_3 = L_2->___bucketCapacityMask;
		UnsafeUtility_MemSet_m4CD74CD43260EB2962A46F57E0D93DD5C332FC2B((void*)L_1, (uint8_t)((int32_t)255), ((int64_t)((int32_t)il2cpp_codegen_multiply(((int32_t)il2cpp_codegen_add(L_3, 1)), 4))), NULL);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = ___0_data;
		NullCheck(L_4);
		uint8_t* L_5 = L_4->___next;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_6 = ___0_data;
		NullCheck(L_6);
		int32_t L_7 = L_6->___keyCapacity;
		UnsafeUtility_MemSet_m4CD74CD43260EB2962A46F57E0D93DD5C332FC2B((void*)L_5, (uint8_t)((int32_t)255), ((int64_t)((int32_t)il2cpp_codegen_multiply(L_7, 4))), NULL);
		int32_t L_8;
		L_8 = JobsUtility_get_ThreadIndexCount_m88A954344398143540618B35943F863B92465676(NULL);
		V_0 = L_8;
		V_1 = 0;
		goto IL_0057;
	}

IL_0041:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_9 = ___0_data;
		int32_t* L_10;
		L_10 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_9, NULL);
		int32_t L_11 = V_1;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_10, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_11, ((int32_t)16)))), 4))))) = (int32_t)(-1);
		int32_t L_12 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_12, 1));
	}

IL_0057:
	{
		int32_t L_13 = V_1;
		int32_t L_14 = V_0;
		V_2 = (bool)((((int32_t)L_13) < ((int32_t)L_14))? 1 : 0);
		bool L_15 = V_2;
		if (L_15)
		{
			goto IL_0041;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_16 = ___0_data;
		NullCheck(L_16);
		L_16->___allocatedIndexLength = 0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapBase_2_AllocEntry_m800AD0805A8FEA87F79C267739A0F557ACA44015_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_threadIndex, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t* V_1 = NULL;
	bool V_2 = false;
	bool V_3 = false;
	int32_t V_4 = 0;
	bool V_5 = false;
	bool V_6 = false;
	bool V_7 = false;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	bool V_10 = false;
	int32_t V_11 = 0;
	bool V_12 = false;
	int32_t V_13 = 0;
	bool V_14 = false;
	bool V_15 = false;
	bool V_16 = false;
	bool V_17 = false;
	bool V_18 = false;
	bool V_19 = false;
	bool V_20 = false;
	bool V_21 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___next;
		V_1 = (int32_t*)L_1;
	}

IL_0008:
	{
	}

IL_0009:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		int32_t* L_3;
		L_3 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_2, NULL);
		int32_t L_4 = ___1_threadIndex;
		int32_t L_5;
		L_5 = VolatileRead((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_3, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_4, ((int32_t)16)))), 4)))));
		V_0 = L_5;
		int32_t L_6 = V_0;
		V_2 = (bool)((((int32_t)L_6) == ((int32_t)((int32_t)-3)))? 1 : 0);
		bool L_7 = V_2;
		if (L_7)
		{
			goto IL_0009;
		}
	}
	{
		int32_t L_8 = V_0;
		V_3 = (bool)((((int32_t)L_8) < ((int32_t)0))? 1 : 0);
		bool L_9 = V_3;
		if (!L_9)
		{
			goto IL_021e;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_10 = ___0_data;
		int32_t* L_11;
		L_11 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_10, NULL);
		int32_t L_12 = ___1_threadIndex;
		int32_t L_13;
		L_13 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_11, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_12, ((int32_t)16)))), 4)))), ((int32_t)-2), NULL);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_14 = ___0_data;
		NullCheck(L_14);
		int32_t L_15 = L_14->___allocatedIndexLength;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_16 = ___0_data;
		NullCheck(L_16);
		int32_t L_17 = L_16->___keyCapacity;
		V_6 = (bool)((((int32_t)L_15) < ((int32_t)L_17))? 1 : 0);
		bool L_18 = V_6;
		if (!L_18)
		{
			goto IL_0123;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_19 = ___0_data;
		NullCheck(L_19);
		int32_t* L_20 = (int32_t*)(&L_19->___allocatedIndexLength);
		int32_t L_21;
		L_21 = Interlocked_Add_m2455208C56EEFD8832AEAD8AF7368A3FEB33A73C(L_20, ((int32_t)16), NULL);
		V_0 = ((int32_t)il2cpp_codegen_subtract(L_21, ((int32_t)16)));
		int32_t L_22 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_23 = ___0_data;
		NullCheck(L_23);
		int32_t L_24 = L_23->___keyCapacity;
		V_7 = (bool)((((int32_t)L_22) < ((int32_t)((int32_t)il2cpp_codegen_subtract(L_24, 1))))? 1 : 0);
		bool L_25 = V_7;
		if (!L_25)
		{
			goto IL_00f3;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_26 = ___0_data;
		NullCheck(L_26);
		int32_t L_27 = L_26->___keyCapacity;
		int32_t L_28 = V_0;
		int32_t L_29;
		L_29 = math_min_m02D43DF516544C279AF660EA4731449C82991849_inline(((int32_t)16), ((int32_t)il2cpp_codegen_subtract(L_27, L_28)), NULL);
		V_8 = L_29;
		V_9 = 1;
		goto IL_00b3;
	}

IL_009b:
	{
		int32_t* L_30 = V_1;
		int32_t L_31 = V_0;
		int32_t L_32 = V_9;
		int32_t L_33 = V_0;
		int32_t L_34 = V_9;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_30, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_add(L_31, L_32))), 4))))) = (int32_t)((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_33, L_34)), 1));
		int32_t L_35 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add(L_35, 1));
	}

IL_00b3:
	{
		int32_t L_36 = V_9;
		int32_t L_37 = V_8;
		V_10 = (bool)((((int32_t)L_36) < ((int32_t)L_37))? 1 : 0);
		bool L_38 = V_10;
		if (L_38)
		{
			goto IL_009b;
		}
	}
	{
		int32_t* L_39 = V_1;
		int32_t L_40 = V_0;
		int32_t L_41 = V_8;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_39, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_40, L_41)), 1))), 4))))) = (int32_t)(-1);
		int32_t* L_42 = V_1;
		int32_t L_43 = V_0;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_42, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_43), 4))))) = (int32_t)(-1);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_44 = ___0_data;
		int32_t* L_45;
		L_45 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_44, NULL);
		int32_t L_46 = ___1_threadIndex;
		int32_t L_47 = V_0;
		int32_t L_48;
		L_48 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_45, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_46, ((int32_t)16)))), 4)))), ((int32_t)il2cpp_codegen_add(L_47, 1)), NULL);
		int32_t L_49 = V_0;
		V_11 = L_49;
		goto IL_026c;
	}

IL_00f3:
	{
		int32_t L_50 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_51 = ___0_data;
		NullCheck(L_51);
		int32_t L_52 = L_51->___keyCapacity;
		V_12 = (bool)((((int32_t)L_50) == ((int32_t)((int32_t)il2cpp_codegen_subtract(L_52, 1))))? 1 : 0);
		bool L_53 = V_12;
		if (!L_53)
		{
			goto IL_0122;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_54 = ___0_data;
		int32_t* L_55;
		L_55 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_54, NULL);
		int32_t L_56 = ___1_threadIndex;
		int32_t L_57;
		L_57 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_55, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_56, ((int32_t)16)))), 4)))), (-1), NULL);
		int32_t L_58 = V_0;
		V_11 = L_58;
		goto IL_026c;
	}

IL_0122:
	{
	}

IL_0123:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_59 = ___0_data;
		int32_t* L_60;
		L_60 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_59, NULL);
		int32_t L_61 = ___1_threadIndex;
		int32_t L_62;
		L_62 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_60, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_61, ((int32_t)16)))), 4)))), (-1), NULL);
		int32_t L_63;
		L_63 = JobsUtility_get_ThreadIndexCount_m88A954344398143540618B35943F863B92465676(NULL);
		V_4 = L_63;
		V_5 = (bool)1;
		goto IL_0212;
	}

IL_0147:
	{
		V_5 = (bool)0;
		int32_t L_64 = ___1_threadIndex;
		int32_t L_65 = V_4;
		V_13 = ((int32_t)(((int32_t)il2cpp_codegen_add(L_64, 1))%L_65));
		goto IL_0200;
	}

IL_0158:
	{
	}

IL_0159:
	{
	}

IL_015a:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_66 = ___0_data;
		int32_t* L_67;
		L_67 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_66, NULL);
		int32_t L_68 = V_13;
		int32_t L_69;
		L_69 = VolatileRead((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_67, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_68, ((int32_t)16)))), 4)))));
		V_0 = L_69;
		int32_t L_70 = V_0;
		V_14 = (bool)((((int32_t)L_70) == ((int32_t)((int32_t)-3)))? 1 : 0);
		bool L_71 = V_14;
		if (L_71)
		{
			goto IL_015a;
		}
	}
	{
		int32_t L_72 = V_0;
		V_15 = (bool)((((int32_t)L_72) < ((int32_t)0))? 1 : 0);
		bool L_73 = V_15;
		if (!L_73)
		{
			goto IL_0189;
		}
	}
	{
		goto IL_01ad;
	}

IL_0189:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_74 = ___0_data;
		int32_t* L_75;
		L_75 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_74, NULL);
		int32_t L_76 = V_13;
		int32_t L_77 = V_0;
		int32_t L_78;
		L_78 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_75, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_76, ((int32_t)16)))), 4)))), ((int32_t)-3), L_77, NULL);
		int32_t L_79 = V_0;
		V_16 = (bool)((((int32_t)((((int32_t)L_78) == ((int32_t)L_79))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_80 = V_16;
		if (L_80)
		{
			goto IL_0159;
		}
	}

IL_01ad:
	{
		int32_t L_81 = V_0;
		V_17 = (bool)((((int32_t)L_81) == ((int32_t)((int32_t)-2)))? 1 : 0);
		bool L_82 = V_17;
		if (!L_82)
		{
			goto IL_01bf;
		}
	}
	{
		V_5 = (bool)1;
		goto IL_01f6;
	}

IL_01bf:
	{
		int32_t L_83 = V_0;
		V_18 = (bool)((((int32_t)((((int32_t)L_83) < ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_84 = V_18;
		if (!L_84)
		{
			goto IL_01f6;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_85 = ___0_data;
		int32_t* L_86;
		L_86 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_85, NULL);
		int32_t L_87 = V_13;
		int32_t* L_88 = V_1;
		int32_t L_89 = V_0;
		int32_t L_90 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_88, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_89), 4))))));
		int32_t L_91;
		L_91 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_86, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_87, ((int32_t)16)))), 4)))), L_90, NULL);
		int32_t* L_92 = V_1;
		int32_t L_93 = V_0;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_92, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_93), 4))))) = (int32_t)(-1);
		int32_t L_94 = V_0;
		V_11 = L_94;
		goto IL_026c;
	}

IL_01f6:
	{
		int32_t L_95 = V_13;
		int32_t L_96 = V_4;
		V_13 = ((int32_t)(((int32_t)il2cpp_codegen_add(L_95, 1))%L_96));
	}

IL_0200:
	{
		int32_t L_97 = V_13;
		int32_t L_98 = ___1_threadIndex;
		V_19 = (bool)((((int32_t)((((int32_t)L_97) == ((int32_t)L_98))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_99 = V_19;
		if (L_99)
		{
			goto IL_0158;
		}
	}
	{
	}

IL_0212:
	{
		bool L_100 = V_5;
		V_20 = L_100;
		bool L_101 = V_20;
		if (L_101)
		{
			goto IL_0147;
		}
	}
	{
	}

IL_021e:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_102 = ___0_data;
		int32_t* L_103;
		L_103 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_102, NULL);
		int32_t L_104 = ___1_threadIndex;
		int32_t L_105 = V_0;
		int32_t L_106;
		L_106 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_103, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_104, ((int32_t)16)))), 4)))), ((int32_t)-3), L_105, NULL);
		int32_t L_107 = V_0;
		V_21 = (bool)((((int32_t)((((int32_t)L_106) == ((int32_t)L_107))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_108 = V_21;
		if (L_108)
		{
			goto IL_0008;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_109 = ___0_data;
		int32_t* L_110;
		L_110 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_109, NULL);
		int32_t L_111 = ___1_threadIndex;
		int32_t* L_112 = V_1;
		int32_t L_113 = V_0;
		int32_t L_114 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_112, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_113), 4))))));
		int32_t L_115;
		L_115 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_110, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_111, ((int32_t)16)))), 4)))), L_114, NULL);
		int32_t* L_116 = V_1;
		int32_t L_117 = V_0;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_116, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_117), 4))))) = (int32_t)(-1);
		int32_t L_118 = V_0;
		V_11 = L_118;
		goto IL_026c;
	}

IL_026c:
	{
		int32_t L_119 = V_11;
		return L_119;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_FreeEntry_m8927ACA31388B65E99B4E0301130276415771390_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_idx, int32_t ___2_threadIndex, const RuntimeMethod* method) 
{
	int32_t* V_0 = NULL;
	int32_t V_1 = 0;
	bool V_2 = false;
	bool V_3 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___next;
		V_0 = (int32_t*)L_1;
		V_1 = (-1);
	}

IL_000a:
	{
	}

IL_000b:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		int32_t* L_3;
		L_3 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_2, NULL);
		int32_t L_4 = ___2_threadIndex;
		int32_t L_5;
		L_5 = VolatileRead((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_3, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_4, ((int32_t)16)))), 4)))));
		V_1 = L_5;
		int32_t L_6 = V_1;
		V_2 = (bool)((((int32_t)L_6) == ((int32_t)((int32_t)-3)))? 1 : 0);
		bool L_7 = V_2;
		if (L_7)
		{
			goto IL_000b;
		}
	}
	{
		int32_t* L_8 = V_0;
		int32_t L_9 = ___1_idx;
		int32_t L_10 = V_1;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_8, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_9), 4))))) = (int32_t)L_10;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_11 = ___0_data;
		int32_t* L_12;
		L_12 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_11, NULL);
		int32_t L_13 = ___2_threadIndex;
		int32_t L_14 = ___1_idx;
		int32_t L_15 = V_1;
		int32_t L_16;
		L_16 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_12, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_13, ((int32_t)16)))), 4)))), L_14, L_15, NULL);
		int32_t L_17 = V_1;
		V_3 = (bool)((((int32_t)((((int32_t)L_16) == ((int32_t)L_17))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_18 = V_3;
		if (L_18)
		{
			goto IL_000a;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryAddAtomic_m8C100557ED4970593FAA5F277523DE937111A595_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, int32_t ___2_item, int32_t ___3_threadIndex, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC V_1;
	memset((&V_1), 0, sizeof(V_1));
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	int32_t* V_4 = NULL;
	bool V_5 = false;
	bool V_6 = false;
	bool V_7 = false;
	int32_t* V_8 = NULL;
	int32_t V_9 = 0;
	bool V_10 = false;
	bool V_11 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		int32_t L_1 = ___1_key;
		bool L_2;
		L_2 = UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_m8FA051F1386B583A2848E886020D563EE0004112(L_0, L_1, (&V_0), (&V_1), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_5 = L_2;
		bool L_3 = V_5;
		if (!L_3)
		{
			goto IL_001b;
		}
	}
	{
		V_6 = (bool)0;
		goto IL_00da;
	}

IL_001b:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = ___0_data;
		int32_t L_5 = ___3_threadIndex;
		int32_t L_6;
		L_6 = UnsafeParallelHashMapBase_2_AllocEntry_m800AD0805A8FEA87F79C267739A0F557ACA44015(L_4, L_5, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		V_2 = L_6;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		uint8_t* L_8 = L_7->___keys;
		int32_t L_9 = V_2;
		int32_t L_10 = ___1_key;
		UnsafeUtility_WriteArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m0DD1CC90B2F1EF5041F2F4E1DABB58224229F0D7_inline((void*)L_8, L_9, L_10, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 6));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_11 = ___0_data;
		NullCheck(L_11);
		uint8_t* L_12 = L_11->___values;
		int32_t L_13 = V_2;
		int32_t L_14 = ___2_item;
		UnsafeUtility_WriteArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m0DD1CC90B2F1EF5041F2F4E1DABB58224229F0D7_inline((void*)L_12, L_13, L_14, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		int32_t L_15;
		L_15 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_16 = ___0_data;
		NullCheck(L_16);
		int32_t L_17 = L_16->___bucketCapacityMask;
		V_3 = ((int32_t)(L_15&L_17));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_18 = ___0_data;
		NullCheck(L_18);
		uint8_t* L_19 = L_18->___buckets;
		V_4 = (int32_t*)L_19;
		int32_t* L_20 = V_4;
		int32_t L_21 = V_3;
		int32_t L_22 = V_2;
		int32_t L_23;
		L_23 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_20, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_21), 4)))), L_22, (-1), NULL);
		V_7 = (bool)((((int32_t)((((int32_t)L_23) == ((int32_t)(-1)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_24 = V_7;
		if (!L_24)
		{
			goto IL_00d5;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_25 = ___0_data;
		NullCheck(L_25);
		uint8_t* L_26 = L_25->___next;
		V_8 = (int32_t*)L_26;
		V_9 = (-1);
	}

IL_0082:
	{
		int32_t* L_27 = V_4;
		int32_t L_28 = V_3;
		int32_t L_29 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_27, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_28), 4))))));
		V_9 = L_29;
		int32_t* L_30 = V_8;
		int32_t L_31 = V_2;
		int32_t L_32 = V_9;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_30, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_31), 4))))) = (int32_t)L_32;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_33 = ___0_data;
		int32_t L_34 = ___1_key;
		bool L_35;
		L_35 = UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_m8FA051F1386B583A2848E886020D563EE0004112(L_33, L_34, (&V_0), (&V_1), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_10 = L_35;
		bool L_36 = V_10;
		if (!L_36)
		{
			goto IL_00b7;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_37 = ___0_data;
		int32_t L_38 = V_2;
		int32_t L_39 = ___3_threadIndex;
		UnsafeParallelHashMapBase_2_FreeEntry_m8927ACA31388B65E99B4E0301130276415771390(L_37, L_38, L_39, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 10));
		V_6 = (bool)0;
		goto IL_00da;
	}

IL_00b7:
	{
		int32_t* L_40 = V_4;
		int32_t L_41 = V_3;
		int32_t L_42 = V_2;
		int32_t L_43 = V_9;
		int32_t L_44;
		L_44 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_40, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_41), 4)))), L_42, L_43, NULL);
		int32_t L_45 = V_9;
		V_11 = (bool)((((int32_t)((((int32_t)L_44) == ((int32_t)L_45))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_46 = V_11;
		if (L_46)
		{
			goto IL_0082;
		}
	}
	{
	}

IL_00d5:
	{
		V_6 = (bool)1;
		goto IL_00da;
	}

IL_00da:
	{
		bool L_47 = V_6;
		return L_47;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryAdd_mAAF058F1A428D8780337B9CF2695CE9338966DCC_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, int32_t ___2_item, bool ___3_isMultiHashMap, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___4_allocation, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC V_1;
	memset((&V_1), 0, sizeof(V_1));
	bool V_2 = false;
	int32_t V_3 = 0;
	int32_t* V_4 = NULL;
	int32_t V_5 = 0;
	int32_t* V_6 = NULL;
	bool V_7 = false;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	bool V_10 = false;
	bool V_11 = false;
	bool V_12 = false;
	int32_t V_13 = 0;
	bool V_14 = false;
	int32_t V_15 = 0;
	bool V_16 = false;
	int32_t G_B3_0 = 0;
	int32_t G_B7_0 = 0;
	{
		bool L_0 = ___3_isMultiHashMap;
		if (L_0)
		{
			goto IL_0014;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_1 = ___0_data;
		int32_t L_2 = ___1_key;
		bool L_3;
		L_3 = UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_m8FA051F1386B583A2848E886020D563EE0004112(L_1, L_2, (&V_0), (&V_1), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		G_B3_0 = ((((int32_t)L_3) == ((int32_t)0))? 1 : 0);
		goto IL_0015;
	}

IL_0014:
	{
		G_B3_0 = 1;
	}

IL_0015:
	{
		V_2 = (bool)G_B3_0;
		bool L_4 = V_2;
		if (!L_4)
		{
			goto IL_0197;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_5 = ___0_data;
		NullCheck(L_5);
		int32_t L_6 = L_5->___allocatedIndexLength;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		int32_t L_8 = L_7->___keyCapacity;
		if ((((int32_t)L_6) < ((int32_t)L_8)))
		{
			goto IL_0037;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_9 = ___0_data;
		int32_t* L_10;
		L_10 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_9, NULL);
		int32_t L_11 = (*(L_10));
		G_B7_0 = ((((int32_t)L_11) < ((int32_t)0))? 1 : 0);
		goto IL_0038;
	}

IL_0037:
	{
		G_B7_0 = 0;
	}

IL_0038:
	{
		V_7 = (bool)G_B7_0;
		bool L_12 = V_7;
		if (!L_12)
		{
			goto IL_00f5;
		}
	}
	{
		int32_t L_13;
		L_13 = JobsUtility_get_ThreadIndexCount_m88A954344398143540618B35943F863B92465676(NULL);
		V_8 = L_13;
		V_9 = 1;
		goto IL_00b7;
	}

IL_004e:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_14 = ___0_data;
		int32_t* L_15;
		L_15 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_14, NULL);
		int32_t L_16 = V_9;
		int32_t L_17 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_15, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_16, ((int32_t)16)))), 4))))));
		V_10 = (bool)((((int32_t)((((int32_t)L_17) < ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_18 = V_10;
		if (!L_18)
		{
			goto IL_00b0;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_19 = ___0_data;
		int32_t* L_20;
		L_20 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_19, NULL);
		int32_t L_21 = V_9;
		int32_t L_22 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_20, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_21, ((int32_t)16)))), 4))))));
		V_3 = L_22;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_23 = ___0_data;
		NullCheck(L_23);
		uint8_t* L_24 = L_23->___next;
		V_4 = (int32_t*)L_24;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_25 = ___0_data;
		int32_t* L_26;
		L_26 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_25, NULL);
		int32_t L_27 = V_9;
		int32_t* L_28 = V_4;
		int32_t L_29 = V_3;
		int32_t L_30 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_28, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_29), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_26, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_27, ((int32_t)16)))), 4))))) = (int32_t)L_30;
		int32_t* L_31 = V_4;
		int32_t L_32 = V_3;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_31, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_32), 4))))) = (int32_t)(-1);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_33 = ___0_data;
		int32_t* L_34;
		L_34 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_33, NULL);
		int32_t L_35 = V_3;
		*((int32_t*)L_34) = (int32_t)L_35;
		goto IL_00c3;
	}

IL_00b0:
	{
		int32_t L_36 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add(L_36, 1));
	}

IL_00b7:
	{
		int32_t L_37 = V_9;
		int32_t L_38 = V_8;
		V_11 = (bool)((((int32_t)L_37) < ((int32_t)L_38))? 1 : 0);
		bool L_39 = V_11;
		if (L_39)
		{
			goto IL_004e;
		}
	}

IL_00c3:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_40 = ___0_data;
		int32_t* L_41;
		L_41 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_40, NULL);
		int32_t L_42 = (*(L_41));
		V_12 = (bool)((((int32_t)L_42) < ((int32_t)0))? 1 : 0);
		bool L_43 = V_12;
		if (!L_43)
		{
			goto IL_00f4;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_44 = ___0_data;
		NullCheck(L_44);
		int32_t L_45 = L_44->___keyCapacity;
		int32_t L_46;
		L_46 = UnsafeParallelHashMapData_GrowCapacity_m7F2FF57E76510A99266830779059C6C202B9EC47(L_45, NULL);
		V_13 = L_46;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_47 = ___0_data;
		int32_t L_48 = V_13;
		int32_t L_49 = V_13;
		int32_t L_50;
		L_50 = UnsafeParallelHashMapData_GetBucketSize_mEF90FF75EFE70E4B59CD6AF9FDCB3D564A1986A3(L_49, NULL);
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_51 = ___4_allocation;
		UnsafeParallelHashMapData_ReallocateHashMap_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m526C9313C8BCF707526B309126FFB7502C548A5D(L_47, L_48, L_50, L_51, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
	}

IL_00f4:
	{
	}

IL_00f5:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_52 = ___0_data;
		int32_t* L_53;
		L_53 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_52, NULL);
		int32_t L_54 = (*(L_53));
		V_3 = L_54;
		int32_t L_55 = V_3;
		V_14 = (bool)((((int32_t)((((int32_t)L_55) < ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_56 = V_14;
		if (!L_56)
		{
			goto IL_0121;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_57 = ___0_data;
		int32_t* L_58;
		L_58 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_57, NULL);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_59 = ___0_data;
		NullCheck(L_59);
		uint8_t* L_60 = L_59->___next;
		int32_t L_61 = V_3;
		int32_t L_62 = *((int32_t*)((uint8_t*)il2cpp_codegen_add((intptr_t)L_60, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_61), 4)))));
		*((int32_t*)L_58) = (int32_t)L_62;
		goto IL_0135;
	}

IL_0121:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_63 = ___0_data;
		NullCheck(L_63);
		int32_t* L_64 = (int32_t*)(&L_63->___allocatedIndexLength);
		int32_t* L_65 = L_64;
		int32_t L_66 = *((int32_t*)L_65);
		V_15 = L_66;
		int32_t L_67 = V_15;
		*((int32_t*)L_65) = (int32_t)((int32_t)il2cpp_codegen_add(L_67, 1));
		int32_t L_68 = V_15;
		V_3 = L_68;
	}

IL_0135:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_69 = ___0_data;
		NullCheck(L_69);
		uint8_t* L_70 = L_69->___keys;
		int32_t L_71 = V_3;
		int32_t L_72 = ___1_key;
		UnsafeUtility_WriteArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m0DD1CC90B2F1EF5041F2F4E1DABB58224229F0D7_inline((void*)L_70, L_71, L_72, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 6));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_73 = ___0_data;
		NullCheck(L_73);
		uint8_t* L_74 = L_73->___values;
		int32_t L_75 = V_3;
		int32_t L_76 = ___2_item;
		UnsafeUtility_WriteArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m0DD1CC90B2F1EF5041F2F4E1DABB58224229F0D7_inline((void*)L_74, L_75, L_76, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		int32_t L_77;
		L_77 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_78 = ___0_data;
		NullCheck(L_78);
		int32_t L_79 = L_78->___bucketCapacityMask;
		V_5 = ((int32_t)(L_77&L_79));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_80 = ___0_data;
		NullCheck(L_80);
		uint8_t* L_81 = L_80->___buckets;
		V_6 = (int32_t*)L_81;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_82 = ___0_data;
		NullCheck(L_82);
		uint8_t* L_83 = L_82->___next;
		V_4 = (int32_t*)L_83;
		int32_t* L_84 = V_4;
		int32_t L_85 = V_3;
		int32_t* L_86 = V_6;
		int32_t L_87 = V_5;
		int32_t L_88 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_86, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_87), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_84, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_85), 4))))) = (int32_t)L_88;
		int32_t* L_89 = V_6;
		int32_t L_90 = V_5;
		int32_t L_91 = V_3;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_89, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_90), 4))))) = (int32_t)L_91;
		V_16 = (bool)1;
		goto IL_019c;
	}

IL_0197:
	{
		V_16 = (bool)0;
		goto IL_019c;
	}

IL_019c:
	{
		bool L_92 = V_16;
		return L_92;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapBase_2_Remove_m2FA6AF21EE9FA483A21E8B68CEB5BE800461C16A_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, bool ___2_isMultiHashMap, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t* V_1 = NULL;
	int32_t* V_2 = NULL;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	bool V_6 = false;
	int32_t V_7 = 0;
	bool V_8 = false;
	int32_t V_9 = 0;
	int32_t V_10 = 0;
	bool V_11 = false;
	bool V_12 = false;
	bool V_13 = false;
	int32_t G_B15_0 = 0;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		int32_t L_1 = L_0->___keyCapacity;
		V_6 = (bool)((((int32_t)L_1) == ((int32_t)0))? 1 : 0);
		bool L_2 = V_6;
		if (!L_2)
		{
			goto IL_0019;
		}
	}
	{
		V_7 = 0;
		goto IL_010f;
	}

IL_0019:
	{
		V_0 = 0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_3 = ___0_data;
		NullCheck(L_3);
		uint8_t* L_4 = L_3->___buckets;
		V_1 = (int32_t*)L_4;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_5 = ___0_data;
		NullCheck(L_5);
		uint8_t* L_6 = L_5->___next;
		V_2 = (int32_t*)L_6;
		int32_t L_7;
		L_7 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_8 = ___0_data;
		NullCheck(L_8);
		int32_t L_9 = L_8->___bucketCapacityMask;
		V_3 = ((int32_t)(L_7&L_9));
		V_4 = (-1);
		int32_t* L_10 = V_1;
		int32_t L_11 = V_3;
		int32_t L_12 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_10, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_11), 4))))));
		V_5 = L_12;
		goto IL_00ef;
	}

IL_004f:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_13 = ___0_data;
		NullCheck(L_13);
		uint8_t* L_14 = L_13->___keys;
		int32_t L_15 = V_5;
		int32_t L_16;
		L_16 = UnsafeUtility_ReadArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_mFBA66C06ECEB0A2BC1AAE634B6E6BB436F957084_inline((void*)L_14, L_15, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		V_9 = L_16;
		int32_t L_17 = ___1_key;
		bool L_18;
		L_18 = Int32_Equals_mC819D19A661B95BE253FB1769FD4D91961D20722((&V_9), L_17, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 15));
		V_8 = L_18;
		bool L_19 = V_8;
		if (!L_19)
		{
			goto IL_00de;
		}
	}
	{
		int32_t L_20 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add(L_20, 1));
		int32_t L_21 = V_4;
		V_11 = (bool)((((int32_t)L_21) < ((int32_t)0))? 1 : 0);
		bool L_22 = V_11;
		if (!L_22)
		{
			goto IL_0096;
		}
	}
	{
		int32_t* L_23 = V_1;
		int32_t L_24 = V_3;
		int32_t* L_25 = V_2;
		int32_t L_26 = V_5;
		int32_t L_27 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_25, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_26), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_23, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_24), 4))))) = (int32_t)L_27;
		goto IL_00a8;
	}

IL_0096:
	{
		int32_t* L_28 = V_2;
		int32_t L_29 = V_4;
		int32_t* L_30 = V_2;
		int32_t L_31 = V_5;
		int32_t L_32 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_30, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_31), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_28, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_29), 4))))) = (int32_t)L_32;
	}

IL_00a8:
	{
		int32_t* L_33 = V_2;
		int32_t L_34 = V_5;
		int32_t L_35 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_33, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_34), 4))))));
		V_10 = L_35;
		int32_t* L_36 = V_2;
		int32_t L_37 = V_5;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_38 = ___0_data;
		int32_t* L_39;
		L_39 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_38, NULL);
		int32_t L_40 = (*(L_39));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_36, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_37), 4))))) = (int32_t)L_40;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_41 = ___0_data;
		int32_t* L_42;
		L_42 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_41, NULL);
		int32_t L_43 = V_5;
		*((int32_t*)L_42) = (int32_t)L_43;
		int32_t L_44 = V_10;
		V_5 = L_44;
		bool L_45 = ___2_isMultiHashMap;
		V_12 = (bool)((((int32_t)L_45) == ((int32_t)0))? 1 : 0);
		bool L_46 = V_12;
		if (!L_46)
		{
			goto IL_00db;
		}
	}
	{
		goto IL_010a;
	}

IL_00db:
	{
		goto IL_00ee;
	}

IL_00de:
	{
		int32_t L_47 = V_5;
		V_4 = L_47;
		int32_t* L_48 = V_2;
		int32_t L_49 = V_5;
		int32_t L_50 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_48, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_49), 4))))));
		V_5 = L_50;
	}

IL_00ee:
	{
	}

IL_00ef:
	{
		int32_t L_51 = V_5;
		if ((((int32_t)L_51) < ((int32_t)0)))
		{
			goto IL_0100;
		}
	}
	{
		int32_t L_52 = V_5;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_53 = ___0_data;
		NullCheck(L_53);
		int32_t L_54 = L_53->___keyCapacity;
		G_B15_0 = ((((int32_t)L_52) < ((int32_t)L_54))? 1 : 0);
		goto IL_0101;
	}

IL_0100:
	{
		G_B15_0 = 0;
	}

IL_0101:
	{
		V_13 = (bool)G_B15_0;
		bool L_55 = V_13;
		if (L_55)
		{
			goto IL_004f;
		}
	}

IL_010a:
	{
		int32_t L_56 = V_0;
		V_7 = L_56;
		goto IL_010f;
	}

IL_010f:
	{
		int32_t L_57 = V_7;
		return L_57;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_Remove_m54C8F3E22FCD1BD6648FDE077BB6829BE5EB8AB1_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC ___1_it, const RuntimeMethod* method) 
{
	int32_t* V_0 = NULL;
	int32_t* V_1 = NULL;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	bool V_4 = false;
	bool V_5 = false;
	bool V_6 = false;
	int32_t G_B7_0 = 0;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___buckets;
		V_0 = (int32_t*)L_1;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		NullCheck(L_2);
		uint8_t* L_3 = L_2->___next;
		V_1 = (int32_t*)L_3;
		int32_t* L_4 = (int32_t*)(&(&___1_it)->___key);
		int32_t L_5;
		L_5 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295(L_4, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_6 = ___0_data;
		NullCheck(L_6);
		int32_t L_7 = L_6->___bucketCapacityMask;
		V_2 = ((int32_t)(L_5&L_7));
		int32_t* L_8 = V_0;
		int32_t L_9 = V_2;
		int32_t L_10 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_8, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_9), 4))))));
		V_3 = L_10;
		int32_t L_11 = V_3;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC L_12 = ___1_it;
		int32_t L_13 = L_12.___EntryIndex;
		V_4 = (bool)((((int32_t)L_11) == ((int32_t)L_13))? 1 : 0);
		bool L_14 = V_4;
		if (!L_14)
		{
			goto IL_0052;
		}
	}
	{
		int32_t* L_15 = V_0;
		int32_t L_16 = V_2;
		int32_t* L_17 = V_1;
		int32_t L_18 = V_3;
		int32_t L_19 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_17, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_18), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_15, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_16), 4))))) = (int32_t)L_19;
		goto IL_009e;
	}

IL_0052:
	{
		goto IL_005f;
	}

IL_0055:
	{
		int32_t* L_20 = V_1;
		int32_t L_21 = V_3;
		int32_t L_22 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_20, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_21), 4))))));
		V_3 = L_22;
	}

IL_005f:
	{
		int32_t L_23 = V_3;
		if ((((int32_t)L_23) < ((int32_t)0)))
		{
			goto IL_0077;
		}
	}
	{
		int32_t* L_24 = V_1;
		int32_t L_25 = V_3;
		int32_t L_26 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_24, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_25), 4))))));
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC L_27 = ___1_it;
		int32_t L_28 = L_27.___EntryIndex;
		G_B7_0 = ((((int32_t)((((int32_t)L_26) == ((int32_t)L_28))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0078;
	}

IL_0077:
	{
		G_B7_0 = 0;
	}

IL_0078:
	{
		V_5 = (bool)G_B7_0;
		bool L_29 = V_5;
		if (L_29)
		{
			goto IL_0055;
		}
	}
	{
		int32_t L_30 = V_3;
		V_6 = (bool)((((int32_t)L_30) < ((int32_t)0))? 1 : 0);
		bool L_31 = V_6;
		if (!L_31)
		{
			goto IL_008a;
		}
	}
	{
	}

IL_008a:
	{
		int32_t* L_32 = V_1;
		int32_t L_33 = V_3;
		int32_t* L_34 = V_1;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC L_35 = ___1_it;
		int32_t L_36 = L_35.___EntryIndex;
		int32_t L_37 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_34, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_36), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_32, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_33), 4))))) = (int32_t)L_37;
	}

IL_009e:
	{
		int32_t* L_38 = V_1;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC L_39 = ___1_it;
		int32_t L_40 = L_39.___EntryIndex;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_41 = ___0_data;
		int32_t* L_42;
		L_42 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_41, NULL);
		int32_t L_43 = (*(L_42));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_38, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_40), 4))))) = (int32_t)L_43;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_44 = ___0_data;
		int32_t* L_45;
		L_45 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_44, NULL);
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC L_46 = ___1_it;
		int32_t L_47 = L_46.___EntryIndex;
		*((int32_t*)L_45) = (int32_t)L_47;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_m8FA051F1386B583A2848E886020D563EE0004112_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_key, int32_t* ___2_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___3_it, const RuntimeMethod* method) 
{
	int32_t* V_0 = NULL;
	int32_t V_1 = 0;
	bool V_2 = false;
	int32_t V_3 = 0;
	bool V_4 = false;
	{
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_0 = ___3_it;
		int32_t L_1 = ___1_key;
		L_0->___key = L_1;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		NullCheck(L_2);
		int32_t L_3 = L_2->___allocatedIndexLength;
		V_2 = (bool)((((int32_t)((((int32_t)L_3) > ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_4 = V_2;
		if (!L_4)
		{
			goto IL_0035;
		}
	}
	{
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_5 = ___3_it;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_6 = ___3_it;
		int32_t L_7 = (-1);
		V_3 = L_7;
		L_6->___NextEntryIndex = L_7;
		int32_t L_8 = V_3;
		L_5->___EntryIndex = L_8;
		int32_t* L_9 = ___2_item;
		il2cpp_codegen_initobj(L_9, sizeof(int32_t));
		V_4 = (bool)0;
		goto IL_0073;
	}

IL_0035:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_10 = ___0_data;
		NullCheck(L_10);
		uint8_t* L_11 = L_10->___buckets;
		V_0 = (int32_t*)L_11;
		int32_t L_12;
		L_12 = Int32_GetHashCode_m253D60FF7527A483E91004B7A2366F13E225E295((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_13 = ___0_data;
		NullCheck(L_13);
		int32_t L_14 = L_13->___bucketCapacityMask;
		V_1 = ((int32_t)(L_12&L_14));
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_15 = ___3_it;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_16 = ___3_it;
		int32_t* L_17 = V_0;
		int32_t L_18 = V_1;
		int32_t L_19 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_17, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_18), 4))))));
		int32_t L_20 = L_19;
		V_3 = L_20;
		L_16->___NextEntryIndex = L_20;
		int32_t L_21 = V_3;
		L_15->___EntryIndex = L_21;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_22 = ___0_data;
		int32_t* L_23 = ___2_item;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_24 = ___3_it;
		bool L_25;
		L_25 = UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m3A37DD53E6586935E3AAC304D3AB4EF2AFF4A905(L_22, L_23, L_24, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 16));
		V_4 = L_25;
		goto IL_0073;
	}

IL_0073:
	{
		bool L_26 = V_4;
		return L_26;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m3A37DD53E6586935E3AAC304D3AB4EF2AFF4A905_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t* ___1_item, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___2_it, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t* V_1 = NULL;
	bool V_2 = false;
	bool V_3 = false;
	bool V_4 = false;
	bool V_5 = false;
	int32_t V_6 = 0;
	int32_t G_B3_0 = 0;
	int32_t G_B9_0 = 0;
	{
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_0 = ___2_it;
		int32_t L_1 = L_0->___NextEntryIndex;
		V_0 = L_1;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_2 = ___2_it;
		L_2->___NextEntryIndex = (-1);
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_3 = ___2_it;
		L_3->___EntryIndex = (-1);
		int32_t* L_4 = ___1_item;
		il2cpp_codegen_initobj(L_4, sizeof(int32_t));
		int32_t L_5 = V_0;
		if ((((int32_t)L_5) < ((int32_t)0)))
		{
			goto IL_002f;
		}
	}
	{
		int32_t L_6 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		int32_t L_8 = L_7->___keyCapacity;
		G_B3_0 = ((((int32_t)((((int32_t)L_6) < ((int32_t)L_8))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0030;
	}

IL_002f:
	{
		G_B3_0 = 1;
	}

IL_0030:
	{
		V_2 = (bool)G_B3_0;
		bool L_9 = V_2;
		if (!L_9)
		{
			goto IL_003c;
		}
	}
	{
		V_3 = (bool)0;
		goto IL_00c1;
	}

IL_003c:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_10 = ___0_data;
		NullCheck(L_10);
		uint8_t* L_11 = L_10->___next;
		V_1 = (int32_t*)L_11;
		goto IL_006d;
	}

IL_0045:
	{
		int32_t* L_12 = V_1;
		int32_t L_13 = V_0;
		int32_t L_14 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_12, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_13), 4))))));
		V_0 = L_14;
		int32_t L_15 = V_0;
		if ((((int32_t)L_15) < ((int32_t)0)))
		{
			goto IL_0060;
		}
	}
	{
		int32_t L_16 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_17 = ___0_data;
		NullCheck(L_17);
		int32_t L_18 = L_17->___keyCapacity;
		G_B9_0 = ((((int32_t)((((int32_t)L_16) < ((int32_t)L_18))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0061;
	}

IL_0060:
	{
		G_B9_0 = 1;
	}

IL_0061:
	{
		V_4 = (bool)G_B9_0;
		bool L_19 = V_4;
		if (!L_19)
		{
			goto IL_006c;
		}
	}
	{
		V_3 = (bool)0;
		goto IL_00c1;
	}

IL_006c:
	{
	}

IL_006d:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_20 = ___0_data;
		NullCheck(L_20);
		uint8_t* L_21 = L_20->___keys;
		int32_t L_22 = V_0;
		int32_t L_23;
		L_23 = UnsafeUtility_ReadArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_mFBA66C06ECEB0A2BC1AAE634B6E6BB436F957084_inline((void*)L_21, L_22, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		V_6 = L_23;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_24 = ___2_it;
		int32_t L_25 = L_24->___key;
		bool L_26;
		L_26 = Int32_Equals_mC819D19A661B95BE253FB1769FD4D91961D20722((&V_6), L_25, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 15));
		V_5 = (bool)((((int32_t)L_26) == ((int32_t)0))? 1 : 0);
		bool L_27 = V_5;
		if (L_27)
		{
			goto IL_0045;
		}
	}
	{
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_28 = ___2_it;
		int32_t* L_29 = V_1;
		int32_t L_30 = V_0;
		int32_t L_31 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_29, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_30), 4))))));
		L_28->___NextEntryIndex = L_31;
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_32 = ___2_it;
		int32_t L_33 = V_0;
		L_32->___EntryIndex = L_33;
		int32_t* L_34 = ___1_item;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_35 = ___0_data;
		NullCheck(L_35);
		uint8_t* L_36 = L_35->___values;
		int32_t L_37 = V_0;
		int32_t L_38;
		L_38 = UnsafeUtility_ReadArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_mFBA66C06ECEB0A2BC1AAE634B6E6BB436F957084_inline((void*)L_36, L_37, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 17));
		*(int32_t*)L_34 = L_38;
		V_3 = (bool)1;
		goto IL_00c1;
	}

IL_00c1:
	{
		bool L_39 = V_3;
		return L_39;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_SetValue_m10BCBE8DA6067B78364AB1CB739C84E9E6A2B4EE_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* ___1_it, int32_t* ___2_item, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	bool V_1 = false;
	bool V_2 = false;
	int32_t G_B3_0 = 0;
	{
		NativeParallelMultiHashMapIterator_1_t093370576CC8384110748B67FAF3066D23472ABC* L_0 = ___1_it;
		int32_t L_1 = L_0->___EntryIndex;
		V_0 = L_1;
		int32_t L_2 = V_0;
		if ((((int32_t)L_2) < ((int32_t)0)))
		{
			goto IL_001a;
		}
	}
	{
		int32_t L_3 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = ___0_data;
		NullCheck(L_4);
		int32_t L_5 = L_4->___keyCapacity;
		G_B3_0 = ((((int32_t)((((int32_t)L_3) < ((int32_t)L_5))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_001b;
	}

IL_001a:
	{
		G_B3_0 = 1;
	}

IL_001b:
	{
		V_1 = (bool)G_B3_0;
		bool L_6 = V_1;
		if (!L_6)
		{
			goto IL_0024;
		}
	}
	{
		V_2 = (bool)0;
		goto IL_003b;
	}

IL_0024:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		uint8_t* L_8 = L_7->___values;
		int32_t L_9 = V_0;
		int32_t* L_10 = ___2_item;
		int32_t L_11 = (*(int32_t*)L_10);
		UnsafeUtility_WriteArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m0DD1CC90B2F1EF5041F2F4E1DABB58224229F0D7_inline((void*)L_8, L_9, L_11, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		V_2 = (bool)1;
		goto IL_003b;
	}

IL_003b:
	{
		bool L_12 = V_2;
		return L_12;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_Clear_m076E14A8C3CB4EED234BF7E788152BB9A6F22D82_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	bool V_2 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___buckets;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		NullCheck(L_2);
		int32_t L_3 = L_2->___bucketCapacityMask;
		UnsafeUtility_MemSet_m4CD74CD43260EB2962A46F57E0D93DD5C332FC2B((void*)L_1, (uint8_t)((int32_t)255), ((int64_t)((int32_t)il2cpp_codegen_multiply(((int32_t)il2cpp_codegen_add(L_3, 1)), 4))), NULL);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = ___0_data;
		NullCheck(L_4);
		uint8_t* L_5 = L_4->___next;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_6 = ___0_data;
		NullCheck(L_6);
		int32_t L_7 = L_6->___keyCapacity;
		UnsafeUtility_MemSet_m4CD74CD43260EB2962A46F57E0D93DD5C332FC2B((void*)L_5, (uint8_t)((int32_t)255), ((int64_t)((int32_t)il2cpp_codegen_multiply(L_7, 4))), NULL);
		int32_t L_8;
		L_8 = JobsUtility_get_ThreadIndexCount_m88A954344398143540618B35943F863B92465676(NULL);
		V_0 = L_8;
		V_1 = 0;
		goto IL_0057;
	}

IL_0041:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_9 = ___0_data;
		int32_t* L_10;
		L_10 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_9, NULL);
		int32_t L_11 = V_1;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_10, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_11, ((int32_t)16)))), 4))))) = (int32_t)(-1);
		int32_t L_12 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_12, 1));
	}

IL_0057:
	{
		int32_t L_13 = V_1;
		int32_t L_14 = V_0;
		V_2 = (bool)((((int32_t)L_13) < ((int32_t)L_14))? 1 : 0);
		bool L_15 = V_2;
		if (L_15)
		{
			goto IL_0041;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_16 = ___0_data;
		NullCheck(L_16);
		L_16->___allocatedIndexLength = 0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapBase_2_AllocEntry_m57B325EFF67BD5485331BD2F287B463A5D8FC9C8_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_threadIndex, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t* V_1 = NULL;
	bool V_2 = false;
	bool V_3 = false;
	int32_t V_4 = 0;
	bool V_5 = false;
	bool V_6 = false;
	bool V_7 = false;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	bool V_10 = false;
	int32_t V_11 = 0;
	bool V_12 = false;
	int32_t V_13 = 0;
	bool V_14 = false;
	bool V_15 = false;
	bool V_16 = false;
	bool V_17 = false;
	bool V_18 = false;
	bool V_19 = false;
	bool V_20 = false;
	bool V_21 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___next;
		V_1 = (int32_t*)L_1;
	}

IL_0008:
	{
	}

IL_0009:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		int32_t* L_3;
		L_3 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_2, NULL);
		int32_t L_4 = ___1_threadIndex;
		int32_t L_5;
		L_5 = VolatileRead((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_3, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_4, ((int32_t)16)))), 4)))));
		V_0 = L_5;
		int32_t L_6 = V_0;
		V_2 = (bool)((((int32_t)L_6) == ((int32_t)((int32_t)-3)))? 1 : 0);
		bool L_7 = V_2;
		if (L_7)
		{
			goto IL_0009;
		}
	}
	{
		int32_t L_8 = V_0;
		V_3 = (bool)((((int32_t)L_8) < ((int32_t)0))? 1 : 0);
		bool L_9 = V_3;
		if (!L_9)
		{
			goto IL_021e;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_10 = ___0_data;
		int32_t* L_11;
		L_11 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_10, NULL);
		int32_t L_12 = ___1_threadIndex;
		int32_t L_13;
		L_13 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_11, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_12, ((int32_t)16)))), 4)))), ((int32_t)-2), NULL);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_14 = ___0_data;
		NullCheck(L_14);
		int32_t L_15 = L_14->___allocatedIndexLength;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_16 = ___0_data;
		NullCheck(L_16);
		int32_t L_17 = L_16->___keyCapacity;
		V_6 = (bool)((((int32_t)L_15) < ((int32_t)L_17))? 1 : 0);
		bool L_18 = V_6;
		if (!L_18)
		{
			goto IL_0123;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_19 = ___0_data;
		NullCheck(L_19);
		int32_t* L_20 = (int32_t*)(&L_19->___allocatedIndexLength);
		int32_t L_21;
		L_21 = Interlocked_Add_m2455208C56EEFD8832AEAD8AF7368A3FEB33A73C(L_20, ((int32_t)16), NULL);
		V_0 = ((int32_t)il2cpp_codegen_subtract(L_21, ((int32_t)16)));
		int32_t L_22 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_23 = ___0_data;
		NullCheck(L_23);
		int32_t L_24 = L_23->___keyCapacity;
		V_7 = (bool)((((int32_t)L_22) < ((int32_t)((int32_t)il2cpp_codegen_subtract(L_24, 1))))? 1 : 0);
		bool L_25 = V_7;
		if (!L_25)
		{
			goto IL_00f3;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_26 = ___0_data;
		NullCheck(L_26);
		int32_t L_27 = L_26->___keyCapacity;
		int32_t L_28 = V_0;
		int32_t L_29;
		L_29 = math_min_m02D43DF516544C279AF660EA4731449C82991849_inline(((int32_t)16), ((int32_t)il2cpp_codegen_subtract(L_27, L_28)), NULL);
		V_8 = L_29;
		V_9 = 1;
		goto IL_00b3;
	}

IL_009b:
	{
		int32_t* L_30 = V_1;
		int32_t L_31 = V_0;
		int32_t L_32 = V_9;
		int32_t L_33 = V_0;
		int32_t L_34 = V_9;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_30, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_add(L_31, L_32))), 4))))) = (int32_t)((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_33, L_34)), 1));
		int32_t L_35 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add(L_35, 1));
	}

IL_00b3:
	{
		int32_t L_36 = V_9;
		int32_t L_37 = V_8;
		V_10 = (bool)((((int32_t)L_36) < ((int32_t)L_37))? 1 : 0);
		bool L_38 = V_10;
		if (L_38)
		{
			goto IL_009b;
		}
	}
	{
		int32_t* L_39 = V_1;
		int32_t L_40 = V_0;
		int32_t L_41 = V_8;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_39, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_40, L_41)), 1))), 4))))) = (int32_t)(-1);
		int32_t* L_42 = V_1;
		int32_t L_43 = V_0;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_42, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_43), 4))))) = (int32_t)(-1);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_44 = ___0_data;
		int32_t* L_45;
		L_45 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_44, NULL);
		int32_t L_46 = ___1_threadIndex;
		int32_t L_47 = V_0;
		int32_t L_48;
		L_48 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_45, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_46, ((int32_t)16)))), 4)))), ((int32_t)il2cpp_codegen_add(L_47, 1)), NULL);
		int32_t L_49 = V_0;
		V_11 = L_49;
		goto IL_026c;
	}

IL_00f3:
	{
		int32_t L_50 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_51 = ___0_data;
		NullCheck(L_51);
		int32_t L_52 = L_51->___keyCapacity;
		V_12 = (bool)((((int32_t)L_50) == ((int32_t)((int32_t)il2cpp_codegen_subtract(L_52, 1))))? 1 : 0);
		bool L_53 = V_12;
		if (!L_53)
		{
			goto IL_0122;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_54 = ___0_data;
		int32_t* L_55;
		L_55 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_54, NULL);
		int32_t L_56 = ___1_threadIndex;
		int32_t L_57;
		L_57 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_55, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_56, ((int32_t)16)))), 4)))), (-1), NULL);
		int32_t L_58 = V_0;
		V_11 = L_58;
		goto IL_026c;
	}

IL_0122:
	{
	}

IL_0123:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_59 = ___0_data;
		int32_t* L_60;
		L_60 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_59, NULL);
		int32_t L_61 = ___1_threadIndex;
		int32_t L_62;
		L_62 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_60, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_61, ((int32_t)16)))), 4)))), (-1), NULL);
		int32_t L_63;
		L_63 = JobsUtility_get_ThreadIndexCount_m88A954344398143540618B35943F863B92465676(NULL);
		V_4 = L_63;
		V_5 = (bool)1;
		goto IL_0212;
	}

IL_0147:
	{
		V_5 = (bool)0;
		int32_t L_64 = ___1_threadIndex;
		int32_t L_65 = V_4;
		V_13 = ((int32_t)(((int32_t)il2cpp_codegen_add(L_64, 1))%L_65));
		goto IL_0200;
	}

IL_0158:
	{
	}

IL_0159:
	{
	}

IL_015a:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_66 = ___0_data;
		int32_t* L_67;
		L_67 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_66, NULL);
		int32_t L_68 = V_13;
		int32_t L_69;
		L_69 = VolatileRead((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_67, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_68, ((int32_t)16)))), 4)))));
		V_0 = L_69;
		int32_t L_70 = V_0;
		V_14 = (bool)((((int32_t)L_70) == ((int32_t)((int32_t)-3)))? 1 : 0);
		bool L_71 = V_14;
		if (L_71)
		{
			goto IL_015a;
		}
	}
	{
		int32_t L_72 = V_0;
		V_15 = (bool)((((int32_t)L_72) < ((int32_t)0))? 1 : 0);
		bool L_73 = V_15;
		if (!L_73)
		{
			goto IL_0189;
		}
	}
	{
		goto IL_01ad;
	}

IL_0189:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_74 = ___0_data;
		int32_t* L_75;
		L_75 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_74, NULL);
		int32_t L_76 = V_13;
		int32_t L_77 = V_0;
		int32_t L_78;
		L_78 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_75, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_76, ((int32_t)16)))), 4)))), ((int32_t)-3), L_77, NULL);
		int32_t L_79 = V_0;
		V_16 = (bool)((((int32_t)((((int32_t)L_78) == ((int32_t)L_79))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_80 = V_16;
		if (L_80)
		{
			goto IL_0159;
		}
	}

IL_01ad:
	{
		int32_t L_81 = V_0;
		V_17 = (bool)((((int32_t)L_81) == ((int32_t)((int32_t)-2)))? 1 : 0);
		bool L_82 = V_17;
		if (!L_82)
		{
			goto IL_01bf;
		}
	}
	{
		V_5 = (bool)1;
		goto IL_01f6;
	}

IL_01bf:
	{
		int32_t L_83 = V_0;
		V_18 = (bool)((((int32_t)((((int32_t)L_83) < ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_84 = V_18;
		if (!L_84)
		{
			goto IL_01f6;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_85 = ___0_data;
		int32_t* L_86;
		L_86 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_85, NULL);
		int32_t L_87 = V_13;
		int32_t* L_88 = V_1;
		int32_t L_89 = V_0;
		int32_t L_90 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_88, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_89), 4))))));
		int32_t L_91;
		L_91 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_86, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_87, ((int32_t)16)))), 4)))), L_90, NULL);
		int32_t* L_92 = V_1;
		int32_t L_93 = V_0;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_92, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_93), 4))))) = (int32_t)(-1);
		int32_t L_94 = V_0;
		V_11 = L_94;
		goto IL_026c;
	}

IL_01f6:
	{
		int32_t L_95 = V_13;
		int32_t L_96 = V_4;
		V_13 = ((int32_t)(((int32_t)il2cpp_codegen_add(L_95, 1))%L_96));
	}

IL_0200:
	{
		int32_t L_97 = V_13;
		int32_t L_98 = ___1_threadIndex;
		V_19 = (bool)((((int32_t)((((int32_t)L_97) == ((int32_t)L_98))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_99 = V_19;
		if (L_99)
		{
			goto IL_0158;
		}
	}
	{
	}

IL_0212:
	{
		bool L_100 = V_5;
		V_20 = L_100;
		bool L_101 = V_20;
		if (L_101)
		{
			goto IL_0147;
		}
	}
	{
	}

IL_021e:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_102 = ___0_data;
		int32_t* L_103;
		L_103 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_102, NULL);
		int32_t L_104 = ___1_threadIndex;
		int32_t L_105 = V_0;
		int32_t L_106;
		L_106 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_103, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_104, ((int32_t)16)))), 4)))), ((int32_t)-3), L_105, NULL);
		int32_t L_107 = V_0;
		V_21 = (bool)((((int32_t)((((int32_t)L_106) == ((int32_t)L_107))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_108 = V_21;
		if (L_108)
		{
			goto IL_0008;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_109 = ___0_data;
		int32_t* L_110;
		L_110 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_109, NULL);
		int32_t L_111 = ___1_threadIndex;
		int32_t* L_112 = V_1;
		int32_t L_113 = V_0;
		int32_t L_114 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_112, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_113), 4))))));
		int32_t L_115;
		L_115 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_110, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_111, ((int32_t)16)))), 4)))), L_114, NULL);
		int32_t* L_116 = V_1;
		int32_t L_117 = V_0;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_116, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_117), 4))))) = (int32_t)(-1);
		int32_t L_118 = V_0;
		V_11 = L_118;
		goto IL_026c;
	}

IL_026c:
	{
		int32_t L_119 = V_11;
		return L_119;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_FreeEntry_m95E0C2203337A917B366551260F10DD9AA00924A_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_idx, int32_t ___2_threadIndex, const RuntimeMethod* method) 
{
	int32_t* V_0 = NULL;
	int32_t V_1 = 0;
	bool V_2 = false;
	bool V_3 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___next;
		V_0 = (int32_t*)L_1;
		V_1 = (-1);
	}

IL_000a:
	{
	}

IL_000b:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		int32_t* L_3;
		L_3 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_2, NULL);
		int32_t L_4 = ___2_threadIndex;
		int32_t L_5;
		L_5 = VolatileRead((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_3, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_4, ((int32_t)16)))), 4)))));
		V_1 = L_5;
		int32_t L_6 = V_1;
		V_2 = (bool)((((int32_t)L_6) == ((int32_t)((int32_t)-3)))? 1 : 0);
		bool L_7 = V_2;
		if (L_7)
		{
			goto IL_000b;
		}
	}
	{
		int32_t* L_8 = V_0;
		int32_t L_9 = ___1_idx;
		int32_t L_10 = V_1;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_8, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_9), 4))))) = (int32_t)L_10;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_11 = ___0_data;
		int32_t* L_12;
		L_12 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_11, NULL);
		int32_t L_13 = ___2_threadIndex;
		int32_t L_14 = ___1_idx;
		int32_t L_15 = V_1;
		int32_t L_16;
		L_16 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_12, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_13, ((int32_t)16)))), 4)))), L_14, L_15, NULL);
		int32_t L_17 = V_1;
		V_3 = (bool)((((int32_t)((((int32_t)L_16) == ((int32_t)L_17))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_18 = V_3;
		if (L_18)
		{
			goto IL_000a;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryAddAtomic_m8B2F4B364F6D97AA02F42B29C9CD5942FF7E2094_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C ___1_key, int32_t ___2_item, int32_t ___3_threadIndex, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727 V_1;
	memset((&V_1), 0, sizeof(V_1));
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	int32_t* V_4 = NULL;
	bool V_5 = false;
	bool V_6 = false;
	bool V_7 = false;
	int32_t* V_8 = NULL;
	int32_t V_9 = 0;
	bool V_10 = false;
	bool V_11 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C L_1 = ___1_key;
		bool L_2;
		L_2 = UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mA75399BF08E0CCAC328234FD7A71D864467E95C2(L_0, L_1, (&V_0), (&V_1), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_5 = L_2;
		bool L_3 = V_5;
		if (!L_3)
		{
			goto IL_001b;
		}
	}
	{
		V_6 = (bool)0;
		goto IL_00da;
	}

IL_001b:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = ___0_data;
		int32_t L_5 = ___3_threadIndex;
		int32_t L_6;
		L_6 = UnsafeParallelHashMapBase_2_AllocEntry_m57B325EFF67BD5485331BD2F287B463A5D8FC9C8(L_4, L_5, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		V_2 = L_6;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		uint8_t* L_8 = L_7->___keys;
		int32_t L_9 = V_2;
		RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C L_10 = ___1_key;
		UnsafeUtility_WriteArrayElement_TisRangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C_m6E993EC5F50FC82EDD84AF158A50E9FF2BAE2705_inline((void*)L_8, L_9, L_10, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 6));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_11 = ___0_data;
		NullCheck(L_11);
		uint8_t* L_12 = L_11->___values;
		int32_t L_13 = V_2;
		int32_t L_14 = ___2_item;
		UnsafeUtility_WriteArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m0DD1CC90B2F1EF5041F2F4E1DABB58224229F0D7_inline((void*)L_12, L_13, L_14, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		int32_t L_15;
		L_15 = RangeKey_GetHashCode_mC38845B6A1CC657D6F6B1149E7448AA6A3EF3257((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_16 = ___0_data;
		NullCheck(L_16);
		int32_t L_17 = L_16->___bucketCapacityMask;
		V_3 = ((int32_t)(L_15&L_17));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_18 = ___0_data;
		NullCheck(L_18);
		uint8_t* L_19 = L_18->___buckets;
		V_4 = (int32_t*)L_19;
		int32_t* L_20 = V_4;
		int32_t L_21 = V_3;
		int32_t L_22 = V_2;
		int32_t L_23;
		L_23 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_20, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_21), 4)))), L_22, (-1), NULL);
		V_7 = (bool)((((int32_t)((((int32_t)L_23) == ((int32_t)(-1)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_24 = V_7;
		if (!L_24)
		{
			goto IL_00d5;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_25 = ___0_data;
		NullCheck(L_25);
		uint8_t* L_26 = L_25->___next;
		V_8 = (int32_t*)L_26;
		V_9 = (-1);
	}

IL_0082:
	{
		int32_t* L_27 = V_4;
		int32_t L_28 = V_3;
		int32_t L_29 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_27, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_28), 4))))));
		V_9 = L_29;
		int32_t* L_30 = V_8;
		int32_t L_31 = V_2;
		int32_t L_32 = V_9;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_30, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_31), 4))))) = (int32_t)L_32;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_33 = ___0_data;
		RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C L_34 = ___1_key;
		bool L_35;
		L_35 = UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mA75399BF08E0CCAC328234FD7A71D864467E95C2(L_33, L_34, (&V_0), (&V_1), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_10 = L_35;
		bool L_36 = V_10;
		if (!L_36)
		{
			goto IL_00b7;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_37 = ___0_data;
		int32_t L_38 = V_2;
		int32_t L_39 = ___3_threadIndex;
		UnsafeParallelHashMapBase_2_FreeEntry_m95E0C2203337A917B366551260F10DD9AA00924A(L_37, L_38, L_39, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 10));
		V_6 = (bool)0;
		goto IL_00da;
	}

IL_00b7:
	{
		int32_t* L_40 = V_4;
		int32_t L_41 = V_3;
		int32_t L_42 = V_2;
		int32_t L_43 = V_9;
		int32_t L_44;
		L_44 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_40, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_41), 4)))), L_42, L_43, NULL);
		int32_t L_45 = V_9;
		V_11 = (bool)((((int32_t)((((int32_t)L_44) == ((int32_t)L_45))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_46 = V_11;
		if (L_46)
		{
			goto IL_0082;
		}
	}
	{
	}

IL_00d5:
	{
		V_6 = (bool)1;
		goto IL_00da;
	}

IL_00da:
	{
		bool L_47 = V_6;
		return L_47;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryAdd_m68F426016D2195FB3CAC3B543D8F67C733031A7A_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C ___1_key, int32_t ___2_item, bool ___3_isMultiHashMap, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___4_allocation, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727 V_1;
	memset((&V_1), 0, sizeof(V_1));
	bool V_2 = false;
	int32_t V_3 = 0;
	int32_t* V_4 = NULL;
	int32_t V_5 = 0;
	int32_t* V_6 = NULL;
	bool V_7 = false;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	bool V_10 = false;
	bool V_11 = false;
	bool V_12 = false;
	int32_t V_13 = 0;
	bool V_14 = false;
	int32_t V_15 = 0;
	bool V_16 = false;
	int32_t G_B3_0 = 0;
	int32_t G_B7_0 = 0;
	{
		bool L_0 = ___3_isMultiHashMap;
		if (L_0)
		{
			goto IL_0014;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_1 = ___0_data;
		RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C L_2 = ___1_key;
		bool L_3;
		L_3 = UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mA75399BF08E0CCAC328234FD7A71D864467E95C2(L_1, L_2, (&V_0), (&V_1), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		G_B3_0 = ((((int32_t)L_3) == ((int32_t)0))? 1 : 0);
		goto IL_0015;
	}

IL_0014:
	{
		G_B3_0 = 1;
	}

IL_0015:
	{
		V_2 = (bool)G_B3_0;
		bool L_4 = V_2;
		if (!L_4)
		{
			goto IL_0197;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_5 = ___0_data;
		NullCheck(L_5);
		int32_t L_6 = L_5->___allocatedIndexLength;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		int32_t L_8 = L_7->___keyCapacity;
		if ((((int32_t)L_6) < ((int32_t)L_8)))
		{
			goto IL_0037;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_9 = ___0_data;
		int32_t* L_10;
		L_10 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_9, NULL);
		int32_t L_11 = (*(L_10));
		G_B7_0 = ((((int32_t)L_11) < ((int32_t)0))? 1 : 0);
		goto IL_0038;
	}

IL_0037:
	{
		G_B7_0 = 0;
	}

IL_0038:
	{
		V_7 = (bool)G_B7_0;
		bool L_12 = V_7;
		if (!L_12)
		{
			goto IL_00f5;
		}
	}
	{
		int32_t L_13;
		L_13 = JobsUtility_get_ThreadIndexCount_m88A954344398143540618B35943F863B92465676(NULL);
		V_8 = L_13;
		V_9 = 1;
		goto IL_00b7;
	}

IL_004e:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_14 = ___0_data;
		int32_t* L_15;
		L_15 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_14, NULL);
		int32_t L_16 = V_9;
		int32_t L_17 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_15, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_16, ((int32_t)16)))), 4))))));
		V_10 = (bool)((((int32_t)((((int32_t)L_17) < ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_18 = V_10;
		if (!L_18)
		{
			goto IL_00b0;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_19 = ___0_data;
		int32_t* L_20;
		L_20 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_19, NULL);
		int32_t L_21 = V_9;
		int32_t L_22 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_20, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_21, ((int32_t)16)))), 4))))));
		V_3 = L_22;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_23 = ___0_data;
		NullCheck(L_23);
		uint8_t* L_24 = L_23->___next;
		V_4 = (int32_t*)L_24;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_25 = ___0_data;
		int32_t* L_26;
		L_26 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_25, NULL);
		int32_t L_27 = V_9;
		int32_t* L_28 = V_4;
		int32_t L_29 = V_3;
		int32_t L_30 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_28, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_29), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_26, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_27, ((int32_t)16)))), 4))))) = (int32_t)L_30;
		int32_t* L_31 = V_4;
		int32_t L_32 = V_3;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_31, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_32), 4))))) = (int32_t)(-1);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_33 = ___0_data;
		int32_t* L_34;
		L_34 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_33, NULL);
		int32_t L_35 = V_3;
		*((int32_t*)L_34) = (int32_t)L_35;
		goto IL_00c3;
	}

IL_00b0:
	{
		int32_t L_36 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add(L_36, 1));
	}

IL_00b7:
	{
		int32_t L_37 = V_9;
		int32_t L_38 = V_8;
		V_11 = (bool)((((int32_t)L_37) < ((int32_t)L_38))? 1 : 0);
		bool L_39 = V_11;
		if (L_39)
		{
			goto IL_004e;
		}
	}

IL_00c3:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_40 = ___0_data;
		int32_t* L_41;
		L_41 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_40, NULL);
		int32_t L_42 = (*(L_41));
		V_12 = (bool)((((int32_t)L_42) < ((int32_t)0))? 1 : 0);
		bool L_43 = V_12;
		if (!L_43)
		{
			goto IL_00f4;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_44 = ___0_data;
		NullCheck(L_44);
		int32_t L_45 = L_44->___keyCapacity;
		int32_t L_46;
		L_46 = UnsafeParallelHashMapData_GrowCapacity_m7F2FF57E76510A99266830779059C6C202B9EC47(L_45, NULL);
		V_13 = L_46;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_47 = ___0_data;
		int32_t L_48 = V_13;
		int32_t L_49 = V_13;
		int32_t L_50;
		L_50 = UnsafeParallelHashMapData_GetBucketSize_mEF90FF75EFE70E4B59CD6AF9FDCB3D564A1986A3(L_49, NULL);
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_51 = ___4_allocation;
		UnsafeParallelHashMapData_ReallocateHashMap_TisRangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m337E81148B331D4822C7412A962A569B8D2ADC59(L_47, L_48, L_50, L_51, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
	}

IL_00f4:
	{
	}

IL_00f5:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_52 = ___0_data;
		int32_t* L_53;
		L_53 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_52, NULL);
		int32_t L_54 = (*(L_53));
		V_3 = L_54;
		int32_t L_55 = V_3;
		V_14 = (bool)((((int32_t)((((int32_t)L_55) < ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_56 = V_14;
		if (!L_56)
		{
			goto IL_0121;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_57 = ___0_data;
		int32_t* L_58;
		L_58 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_57, NULL);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_59 = ___0_data;
		NullCheck(L_59);
		uint8_t* L_60 = L_59->___next;
		int32_t L_61 = V_3;
		int32_t L_62 = *((int32_t*)((uint8_t*)il2cpp_codegen_add((intptr_t)L_60, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_61), 4)))));
		*((int32_t*)L_58) = (int32_t)L_62;
		goto IL_0135;
	}

IL_0121:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_63 = ___0_data;
		NullCheck(L_63);
		int32_t* L_64 = (int32_t*)(&L_63->___allocatedIndexLength);
		int32_t* L_65 = L_64;
		int32_t L_66 = *((int32_t*)L_65);
		V_15 = L_66;
		int32_t L_67 = V_15;
		*((int32_t*)L_65) = (int32_t)((int32_t)il2cpp_codegen_add(L_67, 1));
		int32_t L_68 = V_15;
		V_3 = L_68;
	}

IL_0135:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_69 = ___0_data;
		NullCheck(L_69);
		uint8_t* L_70 = L_69->___keys;
		int32_t L_71 = V_3;
		RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C L_72 = ___1_key;
		UnsafeUtility_WriteArrayElement_TisRangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C_m6E993EC5F50FC82EDD84AF158A50E9FF2BAE2705_inline((void*)L_70, L_71, L_72, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 6));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_73 = ___0_data;
		NullCheck(L_73);
		uint8_t* L_74 = L_73->___values;
		int32_t L_75 = V_3;
		int32_t L_76 = ___2_item;
		UnsafeUtility_WriteArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m0DD1CC90B2F1EF5041F2F4E1DABB58224229F0D7_inline((void*)L_74, L_75, L_76, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		int32_t L_77;
		L_77 = RangeKey_GetHashCode_mC38845B6A1CC657D6F6B1149E7448AA6A3EF3257((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_78 = ___0_data;
		NullCheck(L_78);
		int32_t L_79 = L_78->___bucketCapacityMask;
		V_5 = ((int32_t)(L_77&L_79));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_80 = ___0_data;
		NullCheck(L_80);
		uint8_t* L_81 = L_80->___buckets;
		V_6 = (int32_t*)L_81;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_82 = ___0_data;
		NullCheck(L_82);
		uint8_t* L_83 = L_82->___next;
		V_4 = (int32_t*)L_83;
		int32_t* L_84 = V_4;
		int32_t L_85 = V_3;
		int32_t* L_86 = V_6;
		int32_t L_87 = V_5;
		int32_t L_88 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_86, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_87), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_84, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_85), 4))))) = (int32_t)L_88;
		int32_t* L_89 = V_6;
		int32_t L_90 = V_5;
		int32_t L_91 = V_3;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_89, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_90), 4))))) = (int32_t)L_91;
		V_16 = (bool)1;
		goto IL_019c;
	}

IL_0197:
	{
		V_16 = (bool)0;
		goto IL_019c;
	}

IL_019c:
	{
		bool L_92 = V_16;
		return L_92;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapBase_2_Remove_m84E20B60B35803AAAE1A64D7E170477EDB1DEB10_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C ___1_key, bool ___2_isMultiHashMap, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t* V_1 = NULL;
	int32_t* V_2 = NULL;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	bool V_6 = false;
	int32_t V_7 = 0;
	bool V_8 = false;
	RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C V_9;
	memset((&V_9), 0, sizeof(V_9));
	int32_t V_10 = 0;
	bool V_11 = false;
	bool V_12 = false;
	bool V_13 = false;
	int32_t G_B15_0 = 0;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		int32_t L_1 = L_0->___keyCapacity;
		V_6 = (bool)((((int32_t)L_1) == ((int32_t)0))? 1 : 0);
		bool L_2 = V_6;
		if (!L_2)
		{
			goto IL_0019;
		}
	}
	{
		V_7 = 0;
		goto IL_010f;
	}

IL_0019:
	{
		V_0 = 0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_3 = ___0_data;
		NullCheck(L_3);
		uint8_t* L_4 = L_3->___buckets;
		V_1 = (int32_t*)L_4;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_5 = ___0_data;
		NullCheck(L_5);
		uint8_t* L_6 = L_5->___next;
		V_2 = (int32_t*)L_6;
		int32_t L_7;
		L_7 = RangeKey_GetHashCode_mC38845B6A1CC657D6F6B1149E7448AA6A3EF3257((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_8 = ___0_data;
		NullCheck(L_8);
		int32_t L_9 = L_8->___bucketCapacityMask;
		V_3 = ((int32_t)(L_7&L_9));
		V_4 = (-1);
		int32_t* L_10 = V_1;
		int32_t L_11 = V_3;
		int32_t L_12 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_10, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_11), 4))))));
		V_5 = L_12;
		goto IL_00ef;
	}

IL_004f:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_13 = ___0_data;
		NullCheck(L_13);
		uint8_t* L_14 = L_13->___keys;
		int32_t L_15 = V_5;
		RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C L_16;
		L_16 = UnsafeUtility_ReadArrayElement_TisRangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C_mFDF2C4591B5F4C0AF4424ED681225F9CF100C5BB_inline((void*)L_14, L_15, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		V_9 = L_16;
		RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C L_17 = ___1_key;
		bool L_18;
		L_18 = RangeKey_Equals_m05E612C122D91758588CEB7529751045E6F09493((&V_9), L_17, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 15));
		V_8 = L_18;
		bool L_19 = V_8;
		if (!L_19)
		{
			goto IL_00de;
		}
	}
	{
		int32_t L_20 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add(L_20, 1));
		int32_t L_21 = V_4;
		V_11 = (bool)((((int32_t)L_21) < ((int32_t)0))? 1 : 0);
		bool L_22 = V_11;
		if (!L_22)
		{
			goto IL_0096;
		}
	}
	{
		int32_t* L_23 = V_1;
		int32_t L_24 = V_3;
		int32_t* L_25 = V_2;
		int32_t L_26 = V_5;
		int32_t L_27 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_25, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_26), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_23, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_24), 4))))) = (int32_t)L_27;
		goto IL_00a8;
	}

IL_0096:
	{
		int32_t* L_28 = V_2;
		int32_t L_29 = V_4;
		int32_t* L_30 = V_2;
		int32_t L_31 = V_5;
		int32_t L_32 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_30, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_31), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_28, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_29), 4))))) = (int32_t)L_32;
	}

IL_00a8:
	{
		int32_t* L_33 = V_2;
		int32_t L_34 = V_5;
		int32_t L_35 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_33, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_34), 4))))));
		V_10 = L_35;
		int32_t* L_36 = V_2;
		int32_t L_37 = V_5;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_38 = ___0_data;
		int32_t* L_39;
		L_39 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_38, NULL);
		int32_t L_40 = (*(L_39));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_36, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_37), 4))))) = (int32_t)L_40;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_41 = ___0_data;
		int32_t* L_42;
		L_42 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_41, NULL);
		int32_t L_43 = V_5;
		*((int32_t*)L_42) = (int32_t)L_43;
		int32_t L_44 = V_10;
		V_5 = L_44;
		bool L_45 = ___2_isMultiHashMap;
		V_12 = (bool)((((int32_t)L_45) == ((int32_t)0))? 1 : 0);
		bool L_46 = V_12;
		if (!L_46)
		{
			goto IL_00db;
		}
	}
	{
		goto IL_010a;
	}

IL_00db:
	{
		goto IL_00ee;
	}

IL_00de:
	{
		int32_t L_47 = V_5;
		V_4 = L_47;
		int32_t* L_48 = V_2;
		int32_t L_49 = V_5;
		int32_t L_50 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_48, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_49), 4))))));
		V_5 = L_50;
	}

IL_00ee:
	{
	}

IL_00ef:
	{
		int32_t L_51 = V_5;
		if ((((int32_t)L_51) < ((int32_t)0)))
		{
			goto IL_0100;
		}
	}
	{
		int32_t L_52 = V_5;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_53 = ___0_data;
		NullCheck(L_53);
		int32_t L_54 = L_53->___keyCapacity;
		G_B15_0 = ((((int32_t)L_52) < ((int32_t)L_54))? 1 : 0);
		goto IL_0101;
	}

IL_0100:
	{
		G_B15_0 = 0;
	}

IL_0101:
	{
		V_13 = (bool)G_B15_0;
		bool L_55 = V_13;
		if (L_55)
		{
			goto IL_004f;
		}
	}

IL_010a:
	{
		int32_t L_56 = V_0;
		V_7 = L_56;
		goto IL_010f;
	}

IL_010f:
	{
		int32_t L_57 = V_7;
		return L_57;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_Remove_m984EF7E144684AA2009D90721D61BE05A46AFD09_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727 ___1_it, const RuntimeMethod* method) 
{
	int32_t* V_0 = NULL;
	int32_t* V_1 = NULL;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	bool V_4 = false;
	bool V_5 = false;
	bool V_6 = false;
	int32_t G_B7_0 = 0;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___buckets;
		V_0 = (int32_t*)L_1;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		NullCheck(L_2);
		uint8_t* L_3 = L_2->___next;
		V_1 = (int32_t*)L_3;
		RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C* L_4 = (RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C*)(&(&___1_it)->___key);
		int32_t L_5;
		L_5 = RangeKey_GetHashCode_mC38845B6A1CC657D6F6B1149E7448AA6A3EF3257(L_4, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_6 = ___0_data;
		NullCheck(L_6);
		int32_t L_7 = L_6->___bucketCapacityMask;
		V_2 = ((int32_t)(L_5&L_7));
		int32_t* L_8 = V_0;
		int32_t L_9 = V_2;
		int32_t L_10 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_8, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_9), 4))))));
		V_3 = L_10;
		int32_t L_11 = V_3;
		NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727 L_12 = ___1_it;
		int32_t L_13 = L_12.___EntryIndex;
		V_4 = (bool)((((int32_t)L_11) == ((int32_t)L_13))? 1 : 0);
		bool L_14 = V_4;
		if (!L_14)
		{
			goto IL_0052;
		}
	}
	{
		int32_t* L_15 = V_0;
		int32_t L_16 = V_2;
		int32_t* L_17 = V_1;
		int32_t L_18 = V_3;
		int32_t L_19 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_17, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_18), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_15, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_16), 4))))) = (int32_t)L_19;
		goto IL_009e;
	}

IL_0052:
	{
		goto IL_005f;
	}

IL_0055:
	{
		int32_t* L_20 = V_1;
		int32_t L_21 = V_3;
		int32_t L_22 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_20, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_21), 4))))));
		V_3 = L_22;
	}

IL_005f:
	{
		int32_t L_23 = V_3;
		if ((((int32_t)L_23) < ((int32_t)0)))
		{
			goto IL_0077;
		}
	}
	{
		int32_t* L_24 = V_1;
		int32_t L_25 = V_3;
		int32_t L_26 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_24, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_25), 4))))));
		NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727 L_27 = ___1_it;
		int32_t L_28 = L_27.___EntryIndex;
		G_B7_0 = ((((int32_t)((((int32_t)L_26) == ((int32_t)L_28))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0078;
	}

IL_0077:
	{
		G_B7_0 = 0;
	}

IL_0078:
	{
		V_5 = (bool)G_B7_0;
		bool L_29 = V_5;
		if (L_29)
		{
			goto IL_0055;
		}
	}
	{
		int32_t L_30 = V_3;
		V_6 = (bool)((((int32_t)L_30) < ((int32_t)0))? 1 : 0);
		bool L_31 = V_6;
		if (!L_31)
		{
			goto IL_008a;
		}
	}
	{
	}

IL_008a:
	{
		int32_t* L_32 = V_1;
		int32_t L_33 = V_3;
		int32_t* L_34 = V_1;
		NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727 L_35 = ___1_it;
		int32_t L_36 = L_35.___EntryIndex;
		int32_t L_37 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_34, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_36), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_32, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_33), 4))))) = (int32_t)L_37;
	}

IL_009e:
	{
		int32_t* L_38 = V_1;
		NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727 L_39 = ___1_it;
		int32_t L_40 = L_39.___EntryIndex;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_41 = ___0_data;
		int32_t* L_42;
		L_42 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_41, NULL);
		int32_t L_43 = (*(L_42));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_38, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_40), 4))))) = (int32_t)L_43;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_44 = ___0_data;
		int32_t* L_45;
		L_45 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_44, NULL);
		NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727 L_46 = ___1_it;
		int32_t L_47 = L_46.___EntryIndex;
		*((int32_t*)L_45) = (int32_t)L_47;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mA75399BF08E0CCAC328234FD7A71D864467E95C2_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C ___1_key, int32_t* ___2_item, NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727* ___3_it, const RuntimeMethod* method) 
{
	int32_t* V_0 = NULL;
	int32_t V_1 = 0;
	bool V_2 = false;
	int32_t V_3 = 0;
	bool V_4 = false;
	{
		NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727* L_0 = ___3_it;
		RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C L_1 = ___1_key;
		L_0->___key = L_1;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		NullCheck(L_2);
		int32_t L_3 = L_2->___allocatedIndexLength;
		V_2 = (bool)((((int32_t)((((int32_t)L_3) > ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_4 = V_2;
		if (!L_4)
		{
			goto IL_0035;
		}
	}
	{
		NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727* L_5 = ___3_it;
		NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727* L_6 = ___3_it;
		int32_t L_7 = (-1);
		V_3 = L_7;
		L_6->___NextEntryIndex = L_7;
		int32_t L_8 = V_3;
		L_5->___EntryIndex = L_8;
		int32_t* L_9 = ___2_item;
		il2cpp_codegen_initobj(L_9, sizeof(int32_t));
		V_4 = (bool)0;
		goto IL_0073;
	}

IL_0035:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_10 = ___0_data;
		NullCheck(L_10);
		uint8_t* L_11 = L_10->___buckets;
		V_0 = (int32_t*)L_11;
		int32_t L_12;
		L_12 = RangeKey_GetHashCode_mC38845B6A1CC657D6F6B1149E7448AA6A3EF3257((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_13 = ___0_data;
		NullCheck(L_13);
		int32_t L_14 = L_13->___bucketCapacityMask;
		V_1 = ((int32_t)(L_12&L_14));
		NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727* L_15 = ___3_it;
		NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727* L_16 = ___3_it;
		int32_t* L_17 = V_0;
		int32_t L_18 = V_1;
		int32_t L_19 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_17, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_18), 4))))));
		int32_t L_20 = L_19;
		V_3 = L_20;
		L_16->___NextEntryIndex = L_20;
		int32_t L_21 = V_3;
		L_15->___EntryIndex = L_21;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_22 = ___0_data;
		int32_t* L_23 = ___2_item;
		NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727* L_24 = ___3_it;
		bool L_25;
		L_25 = UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m92F223FB6B0005A83CA9AC122EEB656E520F55AC(L_22, L_23, L_24, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 16));
		V_4 = L_25;
		goto IL_0073;
	}

IL_0073:
	{
		bool L_26 = V_4;
		return L_26;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m92F223FB6B0005A83CA9AC122EEB656E520F55AC_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t* ___1_item, NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727* ___2_it, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t* V_1 = NULL;
	bool V_2 = false;
	bool V_3 = false;
	bool V_4 = false;
	bool V_5 = false;
	RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C V_6;
	memset((&V_6), 0, sizeof(V_6));
	int32_t G_B3_0 = 0;
	int32_t G_B9_0 = 0;
	{
		NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727* L_0 = ___2_it;
		int32_t L_1 = L_0->___NextEntryIndex;
		V_0 = L_1;
		NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727* L_2 = ___2_it;
		L_2->___NextEntryIndex = (-1);
		NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727* L_3 = ___2_it;
		L_3->___EntryIndex = (-1);
		int32_t* L_4 = ___1_item;
		il2cpp_codegen_initobj(L_4, sizeof(int32_t));
		int32_t L_5 = V_0;
		if ((((int32_t)L_5) < ((int32_t)0)))
		{
			goto IL_002f;
		}
	}
	{
		int32_t L_6 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		int32_t L_8 = L_7->___keyCapacity;
		G_B3_0 = ((((int32_t)((((int32_t)L_6) < ((int32_t)L_8))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0030;
	}

IL_002f:
	{
		G_B3_0 = 1;
	}

IL_0030:
	{
		V_2 = (bool)G_B3_0;
		bool L_9 = V_2;
		if (!L_9)
		{
			goto IL_003c;
		}
	}
	{
		V_3 = (bool)0;
		goto IL_00c1;
	}

IL_003c:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_10 = ___0_data;
		NullCheck(L_10);
		uint8_t* L_11 = L_10->___next;
		V_1 = (int32_t*)L_11;
		goto IL_006d;
	}

IL_0045:
	{
		int32_t* L_12 = V_1;
		int32_t L_13 = V_0;
		int32_t L_14 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_12, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_13), 4))))));
		V_0 = L_14;
		int32_t L_15 = V_0;
		if ((((int32_t)L_15) < ((int32_t)0)))
		{
			goto IL_0060;
		}
	}
	{
		int32_t L_16 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_17 = ___0_data;
		NullCheck(L_17);
		int32_t L_18 = L_17->___keyCapacity;
		G_B9_0 = ((((int32_t)((((int32_t)L_16) < ((int32_t)L_18))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0061;
	}

IL_0060:
	{
		G_B9_0 = 1;
	}

IL_0061:
	{
		V_4 = (bool)G_B9_0;
		bool L_19 = V_4;
		if (!L_19)
		{
			goto IL_006c;
		}
	}
	{
		V_3 = (bool)0;
		goto IL_00c1;
	}

IL_006c:
	{
	}

IL_006d:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_20 = ___0_data;
		NullCheck(L_20);
		uint8_t* L_21 = L_20->___keys;
		int32_t L_22 = V_0;
		RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C L_23;
		L_23 = UnsafeUtility_ReadArrayElement_TisRangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C_mFDF2C4591B5F4C0AF4424ED681225F9CF100C5BB_inline((void*)L_21, L_22, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		V_6 = L_23;
		NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727* L_24 = ___2_it;
		RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C L_25 = L_24->___key;
		bool L_26;
		L_26 = RangeKey_Equals_m05E612C122D91758588CEB7529751045E6F09493((&V_6), L_25, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 15));
		V_5 = (bool)((((int32_t)L_26) == ((int32_t)0))? 1 : 0);
		bool L_27 = V_5;
		if (L_27)
		{
			goto IL_0045;
		}
	}
	{
		NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727* L_28 = ___2_it;
		int32_t* L_29 = V_1;
		int32_t L_30 = V_0;
		int32_t L_31 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_29, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_30), 4))))));
		L_28->___NextEntryIndex = L_31;
		NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727* L_32 = ___2_it;
		int32_t L_33 = V_0;
		L_32->___EntryIndex = L_33;
		int32_t* L_34 = ___1_item;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_35 = ___0_data;
		NullCheck(L_35);
		uint8_t* L_36 = L_35->___values;
		int32_t L_37 = V_0;
		int32_t L_38;
		L_38 = UnsafeUtility_ReadArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_mFBA66C06ECEB0A2BC1AAE634B6E6BB436F957084_inline((void*)L_36, L_37, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 17));
		*(int32_t*)L_34 = L_38;
		V_3 = (bool)1;
		goto IL_00c1;
	}

IL_00c1:
	{
		bool L_39 = V_3;
		return L_39;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_SetValue_m0EC4D0EEAFA0FED1FD26DDC65F7A85F8E250F64D_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727* ___1_it, int32_t* ___2_item, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	bool V_1 = false;
	bool V_2 = false;
	int32_t G_B3_0 = 0;
	{
		NativeParallelMultiHashMapIterator_1_tB30276FCEC93EFAF7FCBE919A5B6BC9CE3EE3727* L_0 = ___1_it;
		int32_t L_1 = L_0->___EntryIndex;
		V_0 = L_1;
		int32_t L_2 = V_0;
		if ((((int32_t)L_2) < ((int32_t)0)))
		{
			goto IL_001a;
		}
	}
	{
		int32_t L_3 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = ___0_data;
		NullCheck(L_4);
		int32_t L_5 = L_4->___keyCapacity;
		G_B3_0 = ((((int32_t)((((int32_t)L_3) < ((int32_t)L_5))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_001b;
	}

IL_001a:
	{
		G_B3_0 = 1;
	}

IL_001b:
	{
		V_1 = (bool)G_B3_0;
		bool L_6 = V_1;
		if (!L_6)
		{
			goto IL_0024;
		}
	}
	{
		V_2 = (bool)0;
		goto IL_003b;
	}

IL_0024:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		uint8_t* L_8 = L_7->___values;
		int32_t L_9 = V_0;
		int32_t* L_10 = ___2_item;
		int32_t L_11 = (*(int32_t*)L_10);
		UnsafeUtility_WriteArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m0DD1CC90B2F1EF5041F2F4E1DABB58224229F0D7_inline((void*)L_8, L_9, L_11, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		V_2 = (bool)1;
		goto IL_003b;
	}

IL_003b:
	{
		bool L_12 = V_2;
		return L_12;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_Clear_m6111762F9DF12CED5C2FD1961B340676409BFF0E_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	bool V_2 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___buckets;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		NullCheck(L_2);
		int32_t L_3 = L_2->___bucketCapacityMask;
		UnsafeUtility_MemSet_m4CD74CD43260EB2962A46F57E0D93DD5C332FC2B((void*)L_1, (uint8_t)((int32_t)255), ((int64_t)((int32_t)il2cpp_codegen_multiply(((int32_t)il2cpp_codegen_add(L_3, 1)), 4))), NULL);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = ___0_data;
		NullCheck(L_4);
		uint8_t* L_5 = L_4->___next;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_6 = ___0_data;
		NullCheck(L_6);
		int32_t L_7 = L_6->___keyCapacity;
		UnsafeUtility_MemSet_m4CD74CD43260EB2962A46F57E0D93DD5C332FC2B((void*)L_5, (uint8_t)((int32_t)255), ((int64_t)((int32_t)il2cpp_codegen_multiply(L_7, 4))), NULL);
		int32_t L_8;
		L_8 = JobsUtility_get_ThreadIndexCount_m88A954344398143540618B35943F863B92465676(NULL);
		V_0 = L_8;
		V_1 = 0;
		goto IL_0057;
	}

IL_0041:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_9 = ___0_data;
		int32_t* L_10;
		L_10 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_9, NULL);
		int32_t L_11 = V_1;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_10, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_11, ((int32_t)16)))), 4))))) = (int32_t)(-1);
		int32_t L_12 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_12, 1));
	}

IL_0057:
	{
		int32_t L_13 = V_1;
		int32_t L_14 = V_0;
		V_2 = (bool)((((int32_t)L_13) < ((int32_t)L_14))? 1 : 0);
		bool L_15 = V_2;
		if (L_15)
		{
			goto IL_0041;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_16 = ___0_data;
		NullCheck(L_16);
		L_16->___allocatedIndexLength = 0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapBase_2_AllocEntry_m87F60C86A474B557B069D37548567CB2667C42FA_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_threadIndex, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t* V_1 = NULL;
	bool V_2 = false;
	bool V_3 = false;
	int32_t V_4 = 0;
	bool V_5 = false;
	bool V_6 = false;
	bool V_7 = false;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	bool V_10 = false;
	int32_t V_11 = 0;
	bool V_12 = false;
	int32_t V_13 = 0;
	bool V_14 = false;
	bool V_15 = false;
	bool V_16 = false;
	bool V_17 = false;
	bool V_18 = false;
	bool V_19 = false;
	bool V_20 = false;
	bool V_21 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___next;
		V_1 = (int32_t*)L_1;
	}

IL_0008:
	{
	}

IL_0009:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		int32_t* L_3;
		L_3 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_2, NULL);
		int32_t L_4 = ___1_threadIndex;
		int32_t L_5;
		L_5 = VolatileRead((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_3, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_4, ((int32_t)16)))), 4)))));
		V_0 = L_5;
		int32_t L_6 = V_0;
		V_2 = (bool)((((int32_t)L_6) == ((int32_t)((int32_t)-3)))? 1 : 0);
		bool L_7 = V_2;
		if (L_7)
		{
			goto IL_0009;
		}
	}
	{
		int32_t L_8 = V_0;
		V_3 = (bool)((((int32_t)L_8) < ((int32_t)0))? 1 : 0);
		bool L_9 = V_3;
		if (!L_9)
		{
			goto IL_021e;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_10 = ___0_data;
		int32_t* L_11;
		L_11 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_10, NULL);
		int32_t L_12 = ___1_threadIndex;
		int32_t L_13;
		L_13 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_11, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_12, ((int32_t)16)))), 4)))), ((int32_t)-2), NULL);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_14 = ___0_data;
		NullCheck(L_14);
		int32_t L_15 = L_14->___allocatedIndexLength;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_16 = ___0_data;
		NullCheck(L_16);
		int32_t L_17 = L_16->___keyCapacity;
		V_6 = (bool)((((int32_t)L_15) < ((int32_t)L_17))? 1 : 0);
		bool L_18 = V_6;
		if (!L_18)
		{
			goto IL_0123;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_19 = ___0_data;
		NullCheck(L_19);
		int32_t* L_20 = (int32_t*)(&L_19->___allocatedIndexLength);
		int32_t L_21;
		L_21 = Interlocked_Add_m2455208C56EEFD8832AEAD8AF7368A3FEB33A73C(L_20, ((int32_t)16), NULL);
		V_0 = ((int32_t)il2cpp_codegen_subtract(L_21, ((int32_t)16)));
		int32_t L_22 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_23 = ___0_data;
		NullCheck(L_23);
		int32_t L_24 = L_23->___keyCapacity;
		V_7 = (bool)((((int32_t)L_22) < ((int32_t)((int32_t)il2cpp_codegen_subtract(L_24, 1))))? 1 : 0);
		bool L_25 = V_7;
		if (!L_25)
		{
			goto IL_00f3;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_26 = ___0_data;
		NullCheck(L_26);
		int32_t L_27 = L_26->___keyCapacity;
		int32_t L_28 = V_0;
		int32_t L_29;
		L_29 = math_min_m02D43DF516544C279AF660EA4731449C82991849_inline(((int32_t)16), ((int32_t)il2cpp_codegen_subtract(L_27, L_28)), NULL);
		V_8 = L_29;
		V_9 = 1;
		goto IL_00b3;
	}

IL_009b:
	{
		int32_t* L_30 = V_1;
		int32_t L_31 = V_0;
		int32_t L_32 = V_9;
		int32_t L_33 = V_0;
		int32_t L_34 = V_9;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_30, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_add(L_31, L_32))), 4))))) = (int32_t)((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_33, L_34)), 1));
		int32_t L_35 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add(L_35, 1));
	}

IL_00b3:
	{
		int32_t L_36 = V_9;
		int32_t L_37 = V_8;
		V_10 = (bool)((((int32_t)L_36) < ((int32_t)L_37))? 1 : 0);
		bool L_38 = V_10;
		if (L_38)
		{
			goto IL_009b;
		}
	}
	{
		int32_t* L_39 = V_1;
		int32_t L_40 = V_0;
		int32_t L_41 = V_8;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_39, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_40, L_41)), 1))), 4))))) = (int32_t)(-1);
		int32_t* L_42 = V_1;
		int32_t L_43 = V_0;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_42, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_43), 4))))) = (int32_t)(-1);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_44 = ___0_data;
		int32_t* L_45;
		L_45 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_44, NULL);
		int32_t L_46 = ___1_threadIndex;
		int32_t L_47 = V_0;
		int32_t L_48;
		L_48 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_45, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_46, ((int32_t)16)))), 4)))), ((int32_t)il2cpp_codegen_add(L_47, 1)), NULL);
		int32_t L_49 = V_0;
		V_11 = L_49;
		goto IL_026c;
	}

IL_00f3:
	{
		int32_t L_50 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_51 = ___0_data;
		NullCheck(L_51);
		int32_t L_52 = L_51->___keyCapacity;
		V_12 = (bool)((((int32_t)L_50) == ((int32_t)((int32_t)il2cpp_codegen_subtract(L_52, 1))))? 1 : 0);
		bool L_53 = V_12;
		if (!L_53)
		{
			goto IL_0122;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_54 = ___0_data;
		int32_t* L_55;
		L_55 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_54, NULL);
		int32_t L_56 = ___1_threadIndex;
		int32_t L_57;
		L_57 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_55, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_56, ((int32_t)16)))), 4)))), (-1), NULL);
		int32_t L_58 = V_0;
		V_11 = L_58;
		goto IL_026c;
	}

IL_0122:
	{
	}

IL_0123:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_59 = ___0_data;
		int32_t* L_60;
		L_60 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_59, NULL);
		int32_t L_61 = ___1_threadIndex;
		int32_t L_62;
		L_62 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_60, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_61, ((int32_t)16)))), 4)))), (-1), NULL);
		int32_t L_63;
		L_63 = JobsUtility_get_ThreadIndexCount_m88A954344398143540618B35943F863B92465676(NULL);
		V_4 = L_63;
		V_5 = (bool)1;
		goto IL_0212;
	}

IL_0147:
	{
		V_5 = (bool)0;
		int32_t L_64 = ___1_threadIndex;
		int32_t L_65 = V_4;
		V_13 = ((int32_t)(((int32_t)il2cpp_codegen_add(L_64, 1))%L_65));
		goto IL_0200;
	}

IL_0158:
	{
	}

IL_0159:
	{
	}

IL_015a:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_66 = ___0_data;
		int32_t* L_67;
		L_67 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_66, NULL);
		int32_t L_68 = V_13;
		int32_t L_69;
		L_69 = VolatileRead((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_67, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_68, ((int32_t)16)))), 4)))));
		V_0 = L_69;
		int32_t L_70 = V_0;
		V_14 = (bool)((((int32_t)L_70) == ((int32_t)((int32_t)-3)))? 1 : 0);
		bool L_71 = V_14;
		if (L_71)
		{
			goto IL_015a;
		}
	}
	{
		int32_t L_72 = V_0;
		V_15 = (bool)((((int32_t)L_72) < ((int32_t)0))? 1 : 0);
		bool L_73 = V_15;
		if (!L_73)
		{
			goto IL_0189;
		}
	}
	{
		goto IL_01ad;
	}

IL_0189:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_74 = ___0_data;
		int32_t* L_75;
		L_75 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_74, NULL);
		int32_t L_76 = V_13;
		int32_t L_77 = V_0;
		int32_t L_78;
		L_78 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_75, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_76, ((int32_t)16)))), 4)))), ((int32_t)-3), L_77, NULL);
		int32_t L_79 = V_0;
		V_16 = (bool)((((int32_t)((((int32_t)L_78) == ((int32_t)L_79))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_80 = V_16;
		if (L_80)
		{
			goto IL_0159;
		}
	}

IL_01ad:
	{
		int32_t L_81 = V_0;
		V_17 = (bool)((((int32_t)L_81) == ((int32_t)((int32_t)-2)))? 1 : 0);
		bool L_82 = V_17;
		if (!L_82)
		{
			goto IL_01bf;
		}
	}
	{
		V_5 = (bool)1;
		goto IL_01f6;
	}

IL_01bf:
	{
		int32_t L_83 = V_0;
		V_18 = (bool)((((int32_t)((((int32_t)L_83) < ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_84 = V_18;
		if (!L_84)
		{
			goto IL_01f6;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_85 = ___0_data;
		int32_t* L_86;
		L_86 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_85, NULL);
		int32_t L_87 = V_13;
		int32_t* L_88 = V_1;
		int32_t L_89 = V_0;
		int32_t L_90 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_88, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_89), 4))))));
		int32_t L_91;
		L_91 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_86, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_87, ((int32_t)16)))), 4)))), L_90, NULL);
		int32_t* L_92 = V_1;
		int32_t L_93 = V_0;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_92, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_93), 4))))) = (int32_t)(-1);
		int32_t L_94 = V_0;
		V_11 = L_94;
		goto IL_026c;
	}

IL_01f6:
	{
		int32_t L_95 = V_13;
		int32_t L_96 = V_4;
		V_13 = ((int32_t)(((int32_t)il2cpp_codegen_add(L_95, 1))%L_96));
	}

IL_0200:
	{
		int32_t L_97 = V_13;
		int32_t L_98 = ___1_threadIndex;
		V_19 = (bool)((((int32_t)((((int32_t)L_97) == ((int32_t)L_98))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_99 = V_19;
		if (L_99)
		{
			goto IL_0158;
		}
	}
	{
	}

IL_0212:
	{
		bool L_100 = V_5;
		V_20 = L_100;
		bool L_101 = V_20;
		if (L_101)
		{
			goto IL_0147;
		}
	}
	{
	}

IL_021e:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_102 = ___0_data;
		int32_t* L_103;
		L_103 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_102, NULL);
		int32_t L_104 = ___1_threadIndex;
		int32_t L_105 = V_0;
		int32_t L_106;
		L_106 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_103, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_104, ((int32_t)16)))), 4)))), ((int32_t)-3), L_105, NULL);
		int32_t L_107 = V_0;
		V_21 = (bool)((((int32_t)((((int32_t)L_106) == ((int32_t)L_107))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_108 = V_21;
		if (L_108)
		{
			goto IL_0008;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_109 = ___0_data;
		int32_t* L_110;
		L_110 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_109, NULL);
		int32_t L_111 = ___1_threadIndex;
		int32_t* L_112 = V_1;
		int32_t L_113 = V_0;
		int32_t L_114 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_112, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_113), 4))))));
		int32_t L_115;
		L_115 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_110, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_111, ((int32_t)16)))), 4)))), L_114, NULL);
		int32_t* L_116 = V_1;
		int32_t L_117 = V_0;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_116, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_117), 4))))) = (int32_t)(-1);
		int32_t L_118 = V_0;
		V_11 = L_118;
		goto IL_026c;
	}

IL_026c:
	{
		int32_t L_119 = V_11;
		return L_119;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_FreeEntry_m8D99BED2AEF823C1F525AF6D51D018736E33922F_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_idx, int32_t ___2_threadIndex, const RuntimeMethod* method) 
{
	int32_t* V_0 = NULL;
	int32_t V_1 = 0;
	bool V_2 = false;
	bool V_3 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___next;
		V_0 = (int32_t*)L_1;
		V_1 = (-1);
	}

IL_000a:
	{
	}

IL_000b:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		int32_t* L_3;
		L_3 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_2, NULL);
		int32_t L_4 = ___2_threadIndex;
		int32_t L_5;
		L_5 = VolatileRead((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_3, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_4, ((int32_t)16)))), 4)))));
		V_1 = L_5;
		int32_t L_6 = V_1;
		V_2 = (bool)((((int32_t)L_6) == ((int32_t)((int32_t)-3)))? 1 : 0);
		bool L_7 = V_2;
		if (L_7)
		{
			goto IL_000b;
		}
	}
	{
		int32_t* L_8 = V_0;
		int32_t L_9 = ___1_idx;
		int32_t L_10 = V_1;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_8, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_9), 4))))) = (int32_t)L_10;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_11 = ___0_data;
		int32_t* L_12;
		L_12 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_11, NULL);
		int32_t L_13 = ___2_threadIndex;
		int32_t L_14 = ___1_idx;
		int32_t L_15 = V_1;
		int32_t L_16;
		L_16 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_12, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_13, ((int32_t)16)))), 4)))), L_14, L_15, NULL);
		int32_t L_17 = V_1;
		V_3 = (bool)((((int32_t)((((int32_t)L_16) == ((int32_t)L_17))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_18 = V_3;
		if (L_18)
		{
			goto IL_000a;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryAddAtomic_m6F8189F7B1BB735D6A415B2178B5549363D3DF5F_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, uint32_t ___1_key, BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770 ___2_item, int32_t ___3_threadIndex, const RuntimeMethod* method) 
{
	BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770 V_0;
	memset((&V_0), 0, sizeof(V_0));
	NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B V_1;
	memset((&V_1), 0, sizeof(V_1));
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	int32_t* V_4 = NULL;
	bool V_5 = false;
	bool V_6 = false;
	bool V_7 = false;
	int32_t* V_8 = NULL;
	int32_t V_9 = 0;
	bool V_10 = false;
	bool V_11 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		uint32_t L_1 = ___1_key;
		bool L_2;
		L_2 = UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mEB3EEF401A3CDD197AC9DE490B9CAA5F3415FBE5(L_0, L_1, (&V_0), (&V_1), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_5 = L_2;
		bool L_3 = V_5;
		if (!L_3)
		{
			goto IL_001b;
		}
	}
	{
		V_6 = (bool)0;
		goto IL_00da;
	}

IL_001b:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = ___0_data;
		int32_t L_5 = ___3_threadIndex;
		int32_t L_6;
		L_6 = UnsafeParallelHashMapBase_2_AllocEntry_m87F60C86A474B557B069D37548567CB2667C42FA(L_4, L_5, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		V_2 = L_6;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		uint8_t* L_8 = L_7->___keys;
		int32_t L_9 = V_2;
		uint32_t L_10 = ___1_key;
		UnsafeUtility_WriteArrayElement_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_m839FEB3192BEC0090FBA73A11E371E1A01C13ADF_inline((void*)L_8, L_9, L_10, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 6));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_11 = ___0_data;
		NullCheck(L_11);
		uint8_t* L_12 = L_11->___values;
		int32_t L_13 = V_2;
		BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770 L_14 = ___2_item;
		UnsafeUtility_WriteArrayElement_TisBatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770_m60CD2C2DE2B559F255B8BEA36B0554E698FF9651_inline((void*)L_12, L_13, L_14, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		int32_t L_15;
		L_15 = UInt32_GetHashCode_mB9A03A037C079ADF0E61516BECA1AB05F92266BC((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_16 = ___0_data;
		NullCheck(L_16);
		int32_t L_17 = L_16->___bucketCapacityMask;
		V_3 = ((int32_t)(L_15&L_17));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_18 = ___0_data;
		NullCheck(L_18);
		uint8_t* L_19 = L_18->___buckets;
		V_4 = (int32_t*)L_19;
		int32_t* L_20 = V_4;
		int32_t L_21 = V_3;
		int32_t L_22 = V_2;
		int32_t L_23;
		L_23 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_20, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_21), 4)))), L_22, (-1), NULL);
		V_7 = (bool)((((int32_t)((((int32_t)L_23) == ((int32_t)(-1)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_24 = V_7;
		if (!L_24)
		{
			goto IL_00d5;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_25 = ___0_data;
		NullCheck(L_25);
		uint8_t* L_26 = L_25->___next;
		V_8 = (int32_t*)L_26;
		V_9 = (-1);
	}

IL_0082:
	{
		int32_t* L_27 = V_4;
		int32_t L_28 = V_3;
		int32_t L_29 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_27, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_28), 4))))));
		V_9 = L_29;
		int32_t* L_30 = V_8;
		int32_t L_31 = V_2;
		int32_t L_32 = V_9;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_30, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_31), 4))))) = (int32_t)L_32;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_33 = ___0_data;
		uint32_t L_34 = ___1_key;
		bool L_35;
		L_35 = UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mEB3EEF401A3CDD197AC9DE490B9CAA5F3415FBE5(L_33, L_34, (&V_0), (&V_1), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		V_10 = L_35;
		bool L_36 = V_10;
		if (!L_36)
		{
			goto IL_00b7;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_37 = ___0_data;
		int32_t L_38 = V_2;
		int32_t L_39 = ___3_threadIndex;
		UnsafeParallelHashMapBase_2_FreeEntry_m8D99BED2AEF823C1F525AF6D51D018736E33922F(L_37, L_38, L_39, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 10));
		V_6 = (bool)0;
		goto IL_00da;
	}

IL_00b7:
	{
		int32_t* L_40 = V_4;
		int32_t L_41 = V_3;
		int32_t L_42 = V_2;
		int32_t L_43 = V_9;
		int32_t L_44;
		L_44 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_40, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_41), 4)))), L_42, L_43, NULL);
		int32_t L_45 = V_9;
		V_11 = (bool)((((int32_t)((((int32_t)L_44) == ((int32_t)L_45))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_46 = V_11;
		if (L_46)
		{
			goto IL_0082;
		}
	}
	{
	}

IL_00d5:
	{
		V_6 = (bool)1;
		goto IL_00da;
	}

IL_00da:
	{
		bool L_47 = V_6;
		return L_47;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryAdd_mB28BD55CA55523FDBE164F76B61971032DD40858_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, uint32_t ___1_key, BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770 ___2_item, bool ___3_isMultiHashMap, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___4_allocation, const RuntimeMethod* method) 
{
	BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770 V_0;
	memset((&V_0), 0, sizeof(V_0));
	NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B V_1;
	memset((&V_1), 0, sizeof(V_1));
	bool V_2 = false;
	int32_t V_3 = 0;
	int32_t* V_4 = NULL;
	int32_t V_5 = 0;
	int32_t* V_6 = NULL;
	bool V_7 = false;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	bool V_10 = false;
	bool V_11 = false;
	bool V_12 = false;
	int32_t V_13 = 0;
	bool V_14 = false;
	int32_t V_15 = 0;
	bool V_16 = false;
	int32_t G_B3_0 = 0;
	int32_t G_B7_0 = 0;
	{
		bool L_0 = ___3_isMultiHashMap;
		if (L_0)
		{
			goto IL_0014;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_1 = ___0_data;
		uint32_t L_2 = ___1_key;
		bool L_3;
		L_3 = UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mEB3EEF401A3CDD197AC9DE490B9CAA5F3415FBE5(L_1, L_2, (&V_0), (&V_1), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		G_B3_0 = ((((int32_t)L_3) == ((int32_t)0))? 1 : 0);
		goto IL_0015;
	}

IL_0014:
	{
		G_B3_0 = 1;
	}

IL_0015:
	{
		V_2 = (bool)G_B3_0;
		bool L_4 = V_2;
		if (!L_4)
		{
			goto IL_0197;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_5 = ___0_data;
		NullCheck(L_5);
		int32_t L_6 = L_5->___allocatedIndexLength;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		int32_t L_8 = L_7->___keyCapacity;
		if ((((int32_t)L_6) < ((int32_t)L_8)))
		{
			goto IL_0037;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_9 = ___0_data;
		int32_t* L_10;
		L_10 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_9, NULL);
		int32_t L_11 = (*(L_10));
		G_B7_0 = ((((int32_t)L_11) < ((int32_t)0))? 1 : 0);
		goto IL_0038;
	}

IL_0037:
	{
		G_B7_0 = 0;
	}

IL_0038:
	{
		V_7 = (bool)G_B7_0;
		bool L_12 = V_7;
		if (!L_12)
		{
			goto IL_00f5;
		}
	}
	{
		int32_t L_13;
		L_13 = JobsUtility_get_ThreadIndexCount_m88A954344398143540618B35943F863B92465676(NULL);
		V_8 = L_13;
		V_9 = 1;
		goto IL_00b7;
	}

IL_004e:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_14 = ___0_data;
		int32_t* L_15;
		L_15 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_14, NULL);
		int32_t L_16 = V_9;
		int32_t L_17 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_15, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_16, ((int32_t)16)))), 4))))));
		V_10 = (bool)((((int32_t)((((int32_t)L_17) < ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_18 = V_10;
		if (!L_18)
		{
			goto IL_00b0;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_19 = ___0_data;
		int32_t* L_20;
		L_20 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_19, NULL);
		int32_t L_21 = V_9;
		int32_t L_22 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_20, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_21, ((int32_t)16)))), 4))))));
		V_3 = L_22;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_23 = ___0_data;
		NullCheck(L_23);
		uint8_t* L_24 = L_23->___next;
		V_4 = (int32_t*)L_24;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_25 = ___0_data;
		int32_t* L_26;
		L_26 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_25, NULL);
		int32_t L_27 = V_9;
		int32_t* L_28 = V_4;
		int32_t L_29 = V_3;
		int32_t L_30 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_28, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_29), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_26, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_27, ((int32_t)16)))), 4))))) = (int32_t)L_30;
		int32_t* L_31 = V_4;
		int32_t L_32 = V_3;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_31, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_32), 4))))) = (int32_t)(-1);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_33 = ___0_data;
		int32_t* L_34;
		L_34 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_33, NULL);
		int32_t L_35 = V_3;
		*((int32_t*)L_34) = (int32_t)L_35;
		goto IL_00c3;
	}

IL_00b0:
	{
		int32_t L_36 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add(L_36, 1));
	}

IL_00b7:
	{
		int32_t L_37 = V_9;
		int32_t L_38 = V_8;
		V_11 = (bool)((((int32_t)L_37) < ((int32_t)L_38))? 1 : 0);
		bool L_39 = V_11;
		if (L_39)
		{
			goto IL_004e;
		}
	}

IL_00c3:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_40 = ___0_data;
		int32_t* L_41;
		L_41 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_40, NULL);
		int32_t L_42 = (*(L_41));
		V_12 = (bool)((((int32_t)L_42) < ((int32_t)0))? 1 : 0);
		bool L_43 = V_12;
		if (!L_43)
		{
			goto IL_00f4;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_44 = ___0_data;
		NullCheck(L_44);
		int32_t L_45 = L_44->___keyCapacity;
		int32_t L_46;
		L_46 = UnsafeParallelHashMapData_GrowCapacity_m7F2FF57E76510A99266830779059C6C202B9EC47(L_45, NULL);
		V_13 = L_46;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_47 = ___0_data;
		int32_t L_48 = V_13;
		int32_t L_49 = V_13;
		int32_t L_50;
		L_50 = UnsafeParallelHashMapData_GetBucketSize_mEF90FF75EFE70E4B59CD6AF9FDCB3D564A1986A3(L_49, NULL);
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_51 = ___4_allocation;
		UnsafeParallelHashMapData_ReallocateHashMap_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_TisBatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770_mC740151B18F0E9F81E90C5B066A052BAB9F361C4(L_47, L_48, L_50, L_51, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
	}

IL_00f4:
	{
	}

IL_00f5:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_52 = ___0_data;
		int32_t* L_53;
		L_53 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_52, NULL);
		int32_t L_54 = (*(L_53));
		V_3 = L_54;
		int32_t L_55 = V_3;
		V_14 = (bool)((((int32_t)((((int32_t)L_55) < ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_56 = V_14;
		if (!L_56)
		{
			goto IL_0121;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_57 = ___0_data;
		int32_t* L_58;
		L_58 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_57, NULL);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_59 = ___0_data;
		NullCheck(L_59);
		uint8_t* L_60 = L_59->___next;
		int32_t L_61 = V_3;
		int32_t L_62 = *((int32_t*)((uint8_t*)il2cpp_codegen_add((intptr_t)L_60, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_61), 4)))));
		*((int32_t*)L_58) = (int32_t)L_62;
		goto IL_0135;
	}

IL_0121:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_63 = ___0_data;
		NullCheck(L_63);
		int32_t* L_64 = (int32_t*)(&L_63->___allocatedIndexLength);
		int32_t* L_65 = L_64;
		int32_t L_66 = *((int32_t*)L_65);
		V_15 = L_66;
		int32_t L_67 = V_15;
		*((int32_t*)L_65) = (int32_t)((int32_t)il2cpp_codegen_add(L_67, 1));
		int32_t L_68 = V_15;
		V_3 = L_68;
	}

IL_0135:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_69 = ___0_data;
		NullCheck(L_69);
		uint8_t* L_70 = L_69->___keys;
		int32_t L_71 = V_3;
		uint32_t L_72 = ___1_key;
		UnsafeUtility_WriteArrayElement_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_m839FEB3192BEC0090FBA73A11E371E1A01C13ADF_inline((void*)L_70, L_71, L_72, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 6));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_73 = ___0_data;
		NullCheck(L_73);
		uint8_t* L_74 = L_73->___values;
		int32_t L_75 = V_3;
		BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770 L_76 = ___2_item;
		UnsafeUtility_WriteArrayElement_TisBatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770_m60CD2C2DE2B559F255B8BEA36B0554E698FF9651_inline((void*)L_74, L_75, L_76, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		int32_t L_77;
		L_77 = UInt32_GetHashCode_mB9A03A037C079ADF0E61516BECA1AB05F92266BC((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_78 = ___0_data;
		NullCheck(L_78);
		int32_t L_79 = L_78->___bucketCapacityMask;
		V_5 = ((int32_t)(L_77&L_79));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_80 = ___0_data;
		NullCheck(L_80);
		uint8_t* L_81 = L_80->___buckets;
		V_6 = (int32_t*)L_81;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_82 = ___0_data;
		NullCheck(L_82);
		uint8_t* L_83 = L_82->___next;
		V_4 = (int32_t*)L_83;
		int32_t* L_84 = V_4;
		int32_t L_85 = V_3;
		int32_t* L_86 = V_6;
		int32_t L_87 = V_5;
		int32_t L_88 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_86, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_87), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_84, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_85), 4))))) = (int32_t)L_88;
		int32_t* L_89 = V_6;
		int32_t L_90 = V_5;
		int32_t L_91 = V_3;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_89, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_90), 4))))) = (int32_t)L_91;
		V_16 = (bool)1;
		goto IL_019c;
	}

IL_0197:
	{
		V_16 = (bool)0;
		goto IL_019c;
	}

IL_019c:
	{
		bool L_92 = V_16;
		return L_92;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapBase_2_Remove_mBBA5DDB2402B59D3790793E8834261C6BAD875D8_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, uint32_t ___1_key, bool ___2_isMultiHashMap, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t* V_1 = NULL;
	int32_t* V_2 = NULL;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	bool V_6 = false;
	int32_t V_7 = 0;
	bool V_8 = false;
	uint32_t V_9 = 0;
	int32_t V_10 = 0;
	bool V_11 = false;
	bool V_12 = false;
	bool V_13 = false;
	int32_t G_B15_0 = 0;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		int32_t L_1 = L_0->___keyCapacity;
		V_6 = (bool)((((int32_t)L_1) == ((int32_t)0))? 1 : 0);
		bool L_2 = V_6;
		if (!L_2)
		{
			goto IL_0019;
		}
	}
	{
		V_7 = 0;
		goto IL_010f;
	}

IL_0019:
	{
		V_0 = 0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_3 = ___0_data;
		NullCheck(L_3);
		uint8_t* L_4 = L_3->___buckets;
		V_1 = (int32_t*)L_4;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_5 = ___0_data;
		NullCheck(L_5);
		uint8_t* L_6 = L_5->___next;
		V_2 = (int32_t*)L_6;
		int32_t L_7;
		L_7 = UInt32_GetHashCode_mB9A03A037C079ADF0E61516BECA1AB05F92266BC((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_8 = ___0_data;
		NullCheck(L_8);
		int32_t L_9 = L_8->___bucketCapacityMask;
		V_3 = ((int32_t)(L_7&L_9));
		V_4 = (-1);
		int32_t* L_10 = V_1;
		int32_t L_11 = V_3;
		int32_t L_12 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_10, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_11), 4))))));
		V_5 = L_12;
		goto IL_00ef;
	}

IL_004f:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_13 = ___0_data;
		NullCheck(L_13);
		uint8_t* L_14 = L_13->___keys;
		int32_t L_15 = V_5;
		uint32_t L_16;
		L_16 = UnsafeUtility_ReadArrayElement_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_mDA80BAFF55EA77496672B3B5B3804B55274B7E95_inline((void*)L_14, L_15, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		V_9 = L_16;
		uint32_t L_17 = ___1_key;
		bool L_18;
		L_18 = UInt32_Equals_m6BE590F34B71E27978E9146437F73A6448BA01A3((&V_9), L_17, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 15));
		V_8 = L_18;
		bool L_19 = V_8;
		if (!L_19)
		{
			goto IL_00de;
		}
	}
	{
		int32_t L_20 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add(L_20, 1));
		int32_t L_21 = V_4;
		V_11 = (bool)((((int32_t)L_21) < ((int32_t)0))? 1 : 0);
		bool L_22 = V_11;
		if (!L_22)
		{
			goto IL_0096;
		}
	}
	{
		int32_t* L_23 = V_1;
		int32_t L_24 = V_3;
		int32_t* L_25 = V_2;
		int32_t L_26 = V_5;
		int32_t L_27 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_25, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_26), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_23, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_24), 4))))) = (int32_t)L_27;
		goto IL_00a8;
	}

IL_0096:
	{
		int32_t* L_28 = V_2;
		int32_t L_29 = V_4;
		int32_t* L_30 = V_2;
		int32_t L_31 = V_5;
		int32_t L_32 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_30, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_31), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_28, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_29), 4))))) = (int32_t)L_32;
	}

IL_00a8:
	{
		int32_t* L_33 = V_2;
		int32_t L_34 = V_5;
		int32_t L_35 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_33, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_34), 4))))));
		V_10 = L_35;
		int32_t* L_36 = V_2;
		int32_t L_37 = V_5;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_38 = ___0_data;
		int32_t* L_39;
		L_39 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_38, NULL);
		int32_t L_40 = (*(L_39));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_36, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_37), 4))))) = (int32_t)L_40;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_41 = ___0_data;
		int32_t* L_42;
		L_42 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_41, NULL);
		int32_t L_43 = V_5;
		*((int32_t*)L_42) = (int32_t)L_43;
		int32_t L_44 = V_10;
		V_5 = L_44;
		bool L_45 = ___2_isMultiHashMap;
		V_12 = (bool)((((int32_t)L_45) == ((int32_t)0))? 1 : 0);
		bool L_46 = V_12;
		if (!L_46)
		{
			goto IL_00db;
		}
	}
	{
		goto IL_010a;
	}

IL_00db:
	{
		goto IL_00ee;
	}

IL_00de:
	{
		int32_t L_47 = V_5;
		V_4 = L_47;
		int32_t* L_48 = V_2;
		int32_t L_49 = V_5;
		int32_t L_50 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_48, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_49), 4))))));
		V_5 = L_50;
	}

IL_00ee:
	{
	}

IL_00ef:
	{
		int32_t L_51 = V_5;
		if ((((int32_t)L_51) < ((int32_t)0)))
		{
			goto IL_0100;
		}
	}
	{
		int32_t L_52 = V_5;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_53 = ___0_data;
		NullCheck(L_53);
		int32_t L_54 = L_53->___keyCapacity;
		G_B15_0 = ((((int32_t)L_52) < ((int32_t)L_54))? 1 : 0);
		goto IL_0101;
	}

IL_0100:
	{
		G_B15_0 = 0;
	}

IL_0101:
	{
		V_13 = (bool)G_B15_0;
		bool L_55 = V_13;
		if (L_55)
		{
			goto IL_004f;
		}
	}

IL_010a:
	{
		int32_t L_56 = V_0;
		V_7 = L_56;
		goto IL_010f;
	}

IL_010f:
	{
		int32_t L_57 = V_7;
		return L_57;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_Remove_mC4CBF0F01465E8FDE0330757D4F54389C5C09D4F_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B ___1_it, const RuntimeMethod* method) 
{
	int32_t* V_0 = NULL;
	int32_t* V_1 = NULL;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	bool V_4 = false;
	bool V_5 = false;
	bool V_6 = false;
	int32_t G_B7_0 = 0;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___buckets;
		V_0 = (int32_t*)L_1;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		NullCheck(L_2);
		uint8_t* L_3 = L_2->___next;
		V_1 = (int32_t*)L_3;
		uint32_t* L_4 = (uint32_t*)(&(&___1_it)->___key);
		int32_t L_5;
		L_5 = UInt32_GetHashCode_mB9A03A037C079ADF0E61516BECA1AB05F92266BC(L_4, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_6 = ___0_data;
		NullCheck(L_6);
		int32_t L_7 = L_6->___bucketCapacityMask;
		V_2 = ((int32_t)(L_5&L_7));
		int32_t* L_8 = V_0;
		int32_t L_9 = V_2;
		int32_t L_10 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_8, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_9), 4))))));
		V_3 = L_10;
		int32_t L_11 = V_3;
		NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B L_12 = ___1_it;
		int32_t L_13 = L_12.___EntryIndex;
		V_4 = (bool)((((int32_t)L_11) == ((int32_t)L_13))? 1 : 0);
		bool L_14 = V_4;
		if (!L_14)
		{
			goto IL_0052;
		}
	}
	{
		int32_t* L_15 = V_0;
		int32_t L_16 = V_2;
		int32_t* L_17 = V_1;
		int32_t L_18 = V_3;
		int32_t L_19 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_17, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_18), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_15, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_16), 4))))) = (int32_t)L_19;
		goto IL_009e;
	}

IL_0052:
	{
		goto IL_005f;
	}

IL_0055:
	{
		int32_t* L_20 = V_1;
		int32_t L_21 = V_3;
		int32_t L_22 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_20, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_21), 4))))));
		V_3 = L_22;
	}

IL_005f:
	{
		int32_t L_23 = V_3;
		if ((((int32_t)L_23) < ((int32_t)0)))
		{
			goto IL_0077;
		}
	}
	{
		int32_t* L_24 = V_1;
		int32_t L_25 = V_3;
		int32_t L_26 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_24, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_25), 4))))));
		NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B L_27 = ___1_it;
		int32_t L_28 = L_27.___EntryIndex;
		G_B7_0 = ((((int32_t)((((int32_t)L_26) == ((int32_t)L_28))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0078;
	}

IL_0077:
	{
		G_B7_0 = 0;
	}

IL_0078:
	{
		V_5 = (bool)G_B7_0;
		bool L_29 = V_5;
		if (L_29)
		{
			goto IL_0055;
		}
	}
	{
		int32_t L_30 = V_3;
		V_6 = (bool)((((int32_t)L_30) < ((int32_t)0))? 1 : 0);
		bool L_31 = V_6;
		if (!L_31)
		{
			goto IL_008a;
		}
	}
	{
	}

IL_008a:
	{
		int32_t* L_32 = V_1;
		int32_t L_33 = V_3;
		int32_t* L_34 = V_1;
		NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B L_35 = ___1_it;
		int32_t L_36 = L_35.___EntryIndex;
		int32_t L_37 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_34, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_36), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_32, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_33), 4))))) = (int32_t)L_37;
	}

IL_009e:
	{
		int32_t* L_38 = V_1;
		NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B L_39 = ___1_it;
		int32_t L_40 = L_39.___EntryIndex;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_41 = ___0_data;
		int32_t* L_42;
		L_42 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_41, NULL);
		int32_t L_43 = (*(L_42));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_38, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_40), 4))))) = (int32_t)L_43;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_44 = ___0_data;
		int32_t* L_45;
		L_45 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_44, NULL);
		NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B L_46 = ___1_it;
		int32_t L_47 = L_46.___EntryIndex;
		*((int32_t*)L_45) = (int32_t)L_47;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mEB3EEF401A3CDD197AC9DE490B9CAA5F3415FBE5_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, uint32_t ___1_key, BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770* ___2_item, NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B* ___3_it, const RuntimeMethod* method) 
{
	int32_t* V_0 = NULL;
	int32_t V_1 = 0;
	bool V_2 = false;
	int32_t V_3 = 0;
	bool V_4 = false;
	{
		NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B* L_0 = ___3_it;
		uint32_t L_1 = ___1_key;
		L_0->___key = L_1;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		NullCheck(L_2);
		int32_t L_3 = L_2->___allocatedIndexLength;
		V_2 = (bool)((((int32_t)((((int32_t)L_3) > ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_4 = V_2;
		if (!L_4)
		{
			goto IL_0035;
		}
	}
	{
		NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B* L_5 = ___3_it;
		NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B* L_6 = ___3_it;
		int32_t L_7 = (-1);
		V_3 = L_7;
		L_6->___NextEntryIndex = L_7;
		int32_t L_8 = V_3;
		L_5->___EntryIndex = L_8;
		BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770* L_9 = ___2_item;
		il2cpp_codegen_initobj(L_9, sizeof(BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770));
		V_4 = (bool)0;
		goto IL_0073;
	}

IL_0035:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_10 = ___0_data;
		NullCheck(L_10);
		uint8_t* L_11 = L_10->___buckets;
		V_0 = (int32_t*)L_11;
		int32_t L_12;
		L_12 = UInt32_GetHashCode_mB9A03A037C079ADF0E61516BECA1AB05F92266BC((&___1_key), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_13 = ___0_data;
		NullCheck(L_13);
		int32_t L_14 = L_13->___bucketCapacityMask;
		V_1 = ((int32_t)(L_12&L_14));
		NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B* L_15 = ___3_it;
		NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B* L_16 = ___3_it;
		int32_t* L_17 = V_0;
		int32_t L_18 = V_1;
		int32_t L_19 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_17, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_18), 4))))));
		int32_t L_20 = L_19;
		V_3 = L_20;
		L_16->___NextEntryIndex = L_20;
		int32_t L_21 = V_3;
		L_15->___EntryIndex = L_21;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_22 = ___0_data;
		BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770* L_23 = ___2_item;
		NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B* L_24 = ___3_it;
		bool L_25;
		L_25 = UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m3C59C500D6E8A033EFFAD29EA56E615156D25D1D(L_22, L_23, L_24, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 16));
		V_4 = L_25;
		goto IL_0073;
	}

IL_0073:
	{
		bool L_26 = V_4;
		return L_26;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m3C59C500D6E8A033EFFAD29EA56E615156D25D1D_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770* ___1_item, NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B* ___2_it, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t* V_1 = NULL;
	bool V_2 = false;
	bool V_3 = false;
	bool V_4 = false;
	bool V_5 = false;
	uint32_t V_6 = 0;
	int32_t G_B3_0 = 0;
	int32_t G_B9_0 = 0;
	{
		NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B* L_0 = ___2_it;
		int32_t L_1 = L_0->___NextEntryIndex;
		V_0 = L_1;
		NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B* L_2 = ___2_it;
		L_2->___NextEntryIndex = (-1);
		NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B* L_3 = ___2_it;
		L_3->___EntryIndex = (-1);
		BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770* L_4 = ___1_item;
		il2cpp_codegen_initobj(L_4, sizeof(BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770));
		int32_t L_5 = V_0;
		if ((((int32_t)L_5) < ((int32_t)0)))
		{
			goto IL_002f;
		}
	}
	{
		int32_t L_6 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		int32_t L_8 = L_7->___keyCapacity;
		G_B3_0 = ((((int32_t)((((int32_t)L_6) < ((int32_t)L_8))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0030;
	}

IL_002f:
	{
		G_B3_0 = 1;
	}

IL_0030:
	{
		V_2 = (bool)G_B3_0;
		bool L_9 = V_2;
		if (!L_9)
		{
			goto IL_003c;
		}
	}
	{
		V_3 = (bool)0;
		goto IL_00c1;
	}

IL_003c:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_10 = ___0_data;
		NullCheck(L_10);
		uint8_t* L_11 = L_10->___next;
		V_1 = (int32_t*)L_11;
		goto IL_006d;
	}

IL_0045:
	{
		int32_t* L_12 = V_1;
		int32_t L_13 = V_0;
		int32_t L_14 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_12, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_13), 4))))));
		V_0 = L_14;
		int32_t L_15 = V_0;
		if ((((int32_t)L_15) < ((int32_t)0)))
		{
			goto IL_0060;
		}
	}
	{
		int32_t L_16 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_17 = ___0_data;
		NullCheck(L_17);
		int32_t L_18 = L_17->___keyCapacity;
		G_B9_0 = ((((int32_t)((((int32_t)L_16) < ((int32_t)L_18))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0061;
	}

IL_0060:
	{
		G_B9_0 = 1;
	}

IL_0061:
	{
		V_4 = (bool)G_B9_0;
		bool L_19 = V_4;
		if (!L_19)
		{
			goto IL_006c;
		}
	}
	{
		V_3 = (bool)0;
		goto IL_00c1;
	}

IL_006c:
	{
	}

IL_006d:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_20 = ___0_data;
		NullCheck(L_20);
		uint8_t* L_21 = L_20->___keys;
		int32_t L_22 = V_0;
		uint32_t L_23;
		L_23 = UnsafeUtility_ReadArrayElement_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_mDA80BAFF55EA77496672B3B5B3804B55274B7E95_inline((void*)L_21, L_22, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		V_6 = L_23;
		NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B* L_24 = ___2_it;
		uint32_t L_25 = L_24->___key;
		bool L_26;
		L_26 = UInt32_Equals_m6BE590F34B71E27978E9146437F73A6448BA01A3((&V_6), L_25, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 15));
		V_5 = (bool)((((int32_t)L_26) == ((int32_t)0))? 1 : 0);
		bool L_27 = V_5;
		if (L_27)
		{
			goto IL_0045;
		}
	}
	{
		NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B* L_28 = ___2_it;
		int32_t* L_29 = V_1;
		int32_t L_30 = V_0;
		int32_t L_31 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_29, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_30), 4))))));
		L_28->___NextEntryIndex = L_31;
		NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B* L_32 = ___2_it;
		int32_t L_33 = V_0;
		L_32->___EntryIndex = L_33;
		BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770* L_34 = ___1_item;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_35 = ___0_data;
		NullCheck(L_35);
		uint8_t* L_36 = L_35->___values;
		int32_t L_37 = V_0;
		BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770 L_38;
		L_38 = UnsafeUtility_ReadArrayElement_TisBatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770_m80C61348EC8F9D4F73F0AAA4A69A028E6D599DCD_inline((void*)L_36, L_37, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 17));
		*(BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770*)L_34 = L_38;
		V_3 = (bool)1;
		goto IL_00c1;
	}

IL_00c1:
	{
		bool L_39 = V_3;
		return L_39;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_SetValue_m27DB9701BD4DACF3D9F720EA077801FB3BA61418_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B* ___1_it, BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770* ___2_item, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	bool V_1 = false;
	bool V_2 = false;
	int32_t G_B3_0 = 0;
	{
		NativeParallelMultiHashMapIterator_1_t7577BB442A6835D9DE603273045F89F60636187B* L_0 = ___1_it;
		int32_t L_1 = L_0->___EntryIndex;
		V_0 = L_1;
		int32_t L_2 = V_0;
		if ((((int32_t)L_2) < ((int32_t)0)))
		{
			goto IL_001a;
		}
	}
	{
		int32_t L_3 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = ___0_data;
		NullCheck(L_4);
		int32_t L_5 = L_4->___keyCapacity;
		G_B3_0 = ((((int32_t)((((int32_t)L_3) < ((int32_t)L_5))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_001b;
	}

IL_001a:
	{
		G_B3_0 = 1;
	}

IL_001b:
	{
		V_1 = (bool)G_B3_0;
		bool L_6 = V_1;
		if (!L_6)
		{
			goto IL_0024;
		}
	}
	{
		V_2 = (bool)0;
		goto IL_003b;
	}

IL_0024:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		uint8_t* L_8 = L_7->___values;
		int32_t L_9 = V_0;
		BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770* L_10 = ___2_item;
		BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770 L_11 = (*(BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770*)L_10);
		UnsafeUtility_WriteArrayElement_TisBatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770_m60CD2C2DE2B559F255B8BEA36B0554E698FF9651_inline((void*)L_8, L_9, L_11, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8));
		V_2 = (bool)1;
		goto IL_003b;
	}

IL_003b:
	{
		bool L_12 = V_2;
		return L_12;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_Clear_m6EE55875D60EFEB4879AF8FF0E362DCC68B50EBB_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	bool V_2 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___buckets;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		NullCheck(L_2);
		int32_t L_3 = L_2->___bucketCapacityMask;
		UnsafeUtility_MemSet_m4CD74CD43260EB2962A46F57E0D93DD5C332FC2B((void*)L_1, (uint8_t)((int32_t)255), ((int64_t)((int32_t)il2cpp_codegen_multiply(((int32_t)il2cpp_codegen_add(L_3, 1)), 4))), NULL);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = ___0_data;
		NullCheck(L_4);
		uint8_t* L_5 = L_4->___next;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_6 = ___0_data;
		NullCheck(L_6);
		int32_t L_7 = L_6->___keyCapacity;
		UnsafeUtility_MemSet_m4CD74CD43260EB2962A46F57E0D93DD5C332FC2B((void*)L_5, (uint8_t)((int32_t)255), ((int64_t)((int32_t)il2cpp_codegen_multiply(L_7, 4))), NULL);
		int32_t L_8;
		L_8 = JobsUtility_get_ThreadIndexCount_m88A954344398143540618B35943F863B92465676(NULL);
		V_0 = L_8;
		V_1 = 0;
		goto IL_0057;
	}

IL_0041:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_9 = ___0_data;
		int32_t* L_10;
		L_10 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_9, NULL);
		int32_t L_11 = V_1;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_10, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_11, ((int32_t)16)))), 4))))) = (int32_t)(-1);
		int32_t L_12 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_12, 1));
	}

IL_0057:
	{
		int32_t L_13 = V_1;
		int32_t L_14 = V_0;
		V_2 = (bool)((((int32_t)L_13) < ((int32_t)L_14))? 1 : 0);
		bool L_15 = V_2;
		if (L_15)
		{
			goto IL_0041;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_16 = ___0_data;
		NullCheck(L_16);
		L_16->___allocatedIndexLength = 0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapBase_2_AllocEntry_m3E2610CA343A7226FECF5B6CE365718FC66DF071_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_threadIndex, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t* V_1 = NULL;
	bool V_2 = false;
	bool V_3 = false;
	int32_t V_4 = 0;
	bool V_5 = false;
	bool V_6 = false;
	bool V_7 = false;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	bool V_10 = false;
	int32_t V_11 = 0;
	bool V_12 = false;
	int32_t V_13 = 0;
	bool V_14 = false;
	bool V_15 = false;
	bool V_16 = false;
	bool V_17 = false;
	bool V_18 = false;
	bool V_19 = false;
	bool V_20 = false;
	bool V_21 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___next;
		V_1 = (int32_t*)L_1;
	}

IL_0008:
	{
	}

IL_0009:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		int32_t* L_3;
		L_3 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_2, NULL);
		int32_t L_4 = ___1_threadIndex;
		int32_t L_5;
		L_5 = VolatileRead((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_3, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_4, ((int32_t)16)))), 4)))));
		V_0 = L_5;
		int32_t L_6 = V_0;
		V_2 = (bool)((((int32_t)L_6) == ((int32_t)((int32_t)-3)))? 1 : 0);
		bool L_7 = V_2;
		if (L_7)
		{
			goto IL_0009;
		}
	}
	{
		int32_t L_8 = V_0;
		V_3 = (bool)((((int32_t)L_8) < ((int32_t)0))? 1 : 0);
		bool L_9 = V_3;
		if (!L_9)
		{
			goto IL_021e;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_10 = ___0_data;
		int32_t* L_11;
		L_11 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_10, NULL);
		int32_t L_12 = ___1_threadIndex;
		int32_t L_13;
		L_13 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_11, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_12, ((int32_t)16)))), 4)))), ((int32_t)-2), NULL);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_14 = ___0_data;
		NullCheck(L_14);
		int32_t L_15 = L_14->___allocatedIndexLength;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_16 = ___0_data;
		NullCheck(L_16);
		int32_t L_17 = L_16->___keyCapacity;
		V_6 = (bool)((((int32_t)L_15) < ((int32_t)L_17))? 1 : 0);
		bool L_18 = V_6;
		if (!L_18)
		{
			goto IL_0123;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_19 = ___0_data;
		NullCheck(L_19);
		int32_t* L_20 = (int32_t*)(&L_19->___allocatedIndexLength);
		int32_t L_21;
		L_21 = Interlocked_Add_m2455208C56EEFD8832AEAD8AF7368A3FEB33A73C(L_20, ((int32_t)16), NULL);
		V_0 = ((int32_t)il2cpp_codegen_subtract(L_21, ((int32_t)16)));
		int32_t L_22 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_23 = ___0_data;
		NullCheck(L_23);
		int32_t L_24 = L_23->___keyCapacity;
		V_7 = (bool)((((int32_t)L_22) < ((int32_t)((int32_t)il2cpp_codegen_subtract(L_24, 1))))? 1 : 0);
		bool L_25 = V_7;
		if (!L_25)
		{
			goto IL_00f3;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_26 = ___0_data;
		NullCheck(L_26);
		int32_t L_27 = L_26->___keyCapacity;
		int32_t L_28 = V_0;
		int32_t L_29;
		L_29 = math_min_m02D43DF516544C279AF660EA4731449C82991849_inline(((int32_t)16), ((int32_t)il2cpp_codegen_subtract(L_27, L_28)), NULL);
		V_8 = L_29;
		V_9 = 1;
		goto IL_00b3;
	}

IL_009b:
	{
		int32_t* L_30 = V_1;
		int32_t L_31 = V_0;
		int32_t L_32 = V_9;
		int32_t L_33 = V_0;
		int32_t L_34 = V_9;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_30, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_add(L_31, L_32))), 4))))) = (int32_t)((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_33, L_34)), 1));
		int32_t L_35 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add(L_35, 1));
	}

IL_00b3:
	{
		int32_t L_36 = V_9;
		int32_t L_37 = V_8;
		V_10 = (bool)((((int32_t)L_36) < ((int32_t)L_37))? 1 : 0);
		bool L_38 = V_10;
		if (L_38)
		{
			goto IL_009b;
		}
	}
	{
		int32_t* L_39 = V_1;
		int32_t L_40 = V_0;
		int32_t L_41 = V_8;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_39, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_40, L_41)), 1))), 4))))) = (int32_t)(-1);
		int32_t* L_42 = V_1;
		int32_t L_43 = V_0;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_42, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_43), 4))))) = (int32_t)(-1);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_44 = ___0_data;
		int32_t* L_45;
		L_45 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_44, NULL);
		int32_t L_46 = ___1_threadIndex;
		int32_t L_47 = V_0;
		int32_t L_48;
		L_48 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_45, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_46, ((int32_t)16)))), 4)))), ((int32_t)il2cpp_codegen_add(L_47, 1)), NULL);
		int32_t L_49 = V_0;
		V_11 = L_49;
		goto IL_026c;
	}

IL_00f3:
	{
		int32_t L_50 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_51 = ___0_data;
		NullCheck(L_51);
		int32_t L_52 = L_51->___keyCapacity;
		V_12 = (bool)((((int32_t)L_50) == ((int32_t)((int32_t)il2cpp_codegen_subtract(L_52, 1))))? 1 : 0);
		bool L_53 = V_12;
		if (!L_53)
		{
			goto IL_0122;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_54 = ___0_data;
		int32_t* L_55;
		L_55 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_54, NULL);
		int32_t L_56 = ___1_threadIndex;
		int32_t L_57;
		L_57 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_55, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_56, ((int32_t)16)))), 4)))), (-1), NULL);
		int32_t L_58 = V_0;
		V_11 = L_58;
		goto IL_026c;
	}

IL_0122:
	{
	}

IL_0123:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_59 = ___0_data;
		int32_t* L_60;
		L_60 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_59, NULL);
		int32_t L_61 = ___1_threadIndex;
		int32_t L_62;
		L_62 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_60, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_61, ((int32_t)16)))), 4)))), (-1), NULL);
		int32_t L_63;
		L_63 = JobsUtility_get_ThreadIndexCount_m88A954344398143540618B35943F863B92465676(NULL);
		V_4 = L_63;
		V_5 = (bool)1;
		goto IL_0212;
	}

IL_0147:
	{
		V_5 = (bool)0;
		int32_t L_64 = ___1_threadIndex;
		int32_t L_65 = V_4;
		V_13 = ((int32_t)(((int32_t)il2cpp_codegen_add(L_64, 1))%L_65));
		goto IL_0200;
	}

IL_0158:
	{
	}

IL_0159:
	{
	}

IL_015a:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_66 = ___0_data;
		int32_t* L_67;
		L_67 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_66, NULL);
		int32_t L_68 = V_13;
		int32_t L_69;
		L_69 = VolatileRead((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_67, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_68, ((int32_t)16)))), 4)))));
		V_0 = L_69;
		int32_t L_70 = V_0;
		V_14 = (bool)((((int32_t)L_70) == ((int32_t)((int32_t)-3)))? 1 : 0);
		bool L_71 = V_14;
		if (L_71)
		{
			goto IL_015a;
		}
	}
	{
		int32_t L_72 = V_0;
		V_15 = (bool)((((int32_t)L_72) < ((int32_t)0))? 1 : 0);
		bool L_73 = V_15;
		if (!L_73)
		{
			goto IL_0189;
		}
	}
	{
		goto IL_01ad;
	}

IL_0189:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_74 = ___0_data;
		int32_t* L_75;
		L_75 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_74, NULL);
		int32_t L_76 = V_13;
		int32_t L_77 = V_0;
		int32_t L_78;
		L_78 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_75, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_76, ((int32_t)16)))), 4)))), ((int32_t)-3), L_77, NULL);
		int32_t L_79 = V_0;
		V_16 = (bool)((((int32_t)((((int32_t)L_78) == ((int32_t)L_79))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_80 = V_16;
		if (L_80)
		{
			goto IL_0159;
		}
	}

IL_01ad:
	{
		int32_t L_81 = V_0;
		V_17 = (bool)((((int32_t)L_81) == ((int32_t)((int32_t)-2)))? 1 : 0);
		bool L_82 = V_17;
		if (!L_82)
		{
			goto IL_01bf;
		}
	}
	{
		V_5 = (bool)1;
		goto IL_01f6;
	}

IL_01bf:
	{
		int32_t L_83 = V_0;
		V_18 = (bool)((((int32_t)((((int32_t)L_83) < ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_84 = V_18;
		if (!L_84)
		{
			goto IL_01f6;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_85 = ___0_data;
		int32_t* L_86;
		L_86 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_85, NULL);
		int32_t L_87 = V_13;
		int32_t* L_88 = V_1;
		int32_t L_89 = V_0;
		int32_t L_90 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_88, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_89), 4))))));
		int32_t L_91;
		L_91 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_86, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_87, ((int32_t)16)))), 4)))), L_90, NULL);
		int32_t* L_92 = V_1;
		int32_t L_93 = V_0;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_92, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_93), 4))))) = (int32_t)(-1);
		int32_t L_94 = V_0;
		V_11 = L_94;
		goto IL_026c;
	}

IL_01f6:
	{
		int32_t L_95 = V_13;
		int32_t L_96 = V_4;
		V_13 = ((int32_t)(((int32_t)il2cpp_codegen_add(L_95, 1))%L_96));
	}

IL_0200:
	{
		int32_t L_97 = V_13;
		int32_t L_98 = ___1_threadIndex;
		V_19 = (bool)((((int32_t)((((int32_t)L_97) == ((int32_t)L_98))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_99 = V_19;
		if (L_99)
		{
			goto IL_0158;
		}
	}
	{
	}

IL_0212:
	{
		bool L_100 = V_5;
		V_20 = L_100;
		bool L_101 = V_20;
		if (L_101)
		{
			goto IL_0147;
		}
	}
	{
	}

IL_021e:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_102 = ___0_data;
		int32_t* L_103;
		L_103 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_102, NULL);
		int32_t L_104 = ___1_threadIndex;
		int32_t L_105 = V_0;
		int32_t L_106;
		L_106 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_103, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_104, ((int32_t)16)))), 4)))), ((int32_t)-3), L_105, NULL);
		int32_t L_107 = V_0;
		V_21 = (bool)((((int32_t)((((int32_t)L_106) == ((int32_t)L_107))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_108 = V_21;
		if (L_108)
		{
			goto IL_0008;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_109 = ___0_data;
		int32_t* L_110;
		L_110 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_109, NULL);
		int32_t L_111 = ___1_threadIndex;
		int32_t* L_112 = V_1;
		int32_t L_113 = V_0;
		int32_t L_114 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_112, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_113), 4))))));
		int32_t L_115;
		L_115 = Interlocked_Exchange_m5810F59A9EF49D8003BA76D95398854254A091DF((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_110, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_111, ((int32_t)16)))), 4)))), L_114, NULL);
		int32_t* L_116 = V_1;
		int32_t L_117 = V_0;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_116, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_117), 4))))) = (int32_t)(-1);
		int32_t L_118 = V_0;
		V_11 = L_118;
		goto IL_026c;
	}

IL_026c:
	{
		int32_t L_119 = V_11;
		return L_119;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_FreeEntry_mCFD0DA8ADF441A1780C2CAE61417C094BF86B93E_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, int32_t ___1_idx, int32_t ___2_threadIndex, const RuntimeMethod* method) 
{
	int32_t* V_0 = NULL;
	int32_t V_1 = 0;
	bool V_2 = false;
	bool V_3 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___next;
		V_0 = (int32_t*)L_1;
		V_1 = (-1);
	}

IL_000a:
	{
	}

IL_000b:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		int32_t* L_3;
		L_3 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_2, NULL);
		int32_t L_4 = ___2_threadIndex;
		int32_t L_5;
		L_5 = VolatileRead((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_3, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_4, ((int32_t)16)))), 4)))));
		V_1 = L_5;
		int32_t L_6 = V_1;
		V_2 = (bool)((((int32_t)L_6) == ((int32_t)((int32_t)-3)))? 1 : 0);
		bool L_7 = V_2;
		if (L_7)
		{
			goto IL_000b;
		}
	}
	{
		int32_t* L_8 = V_0;
		int32_t L_9 = ___1_idx;
		int32_t L_10 = V_1;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_8, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_9), 4))))) = (int32_t)L_10;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_11 = ___0_data;
		int32_t* L_12;
		L_12 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_11, NULL);
		int32_t L_13 = ___2_threadIndex;
		int32_t L_14 = ___1_idx;
		int32_t L_15 = V_1;
		int32_t L_16;
		L_16 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_12, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_13, ((int32_t)16)))), 4)))), L_14, L_15, NULL);
		int32_t L_17 = V_1;
		V_3 = (bool)((((int32_t)((((int32_t)L_16) == ((int32_t)L_17))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_18 = V_3;
		if (L_18)
		{
			goto IL_000a;
		}
	}
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryAddAtomic_mCAE3A74A5AB042537557D83CCB3C4B27F509B19C_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, Il2CppFullySharedGenericStruct ___1_key, Il2CppFullySharedGenericStruct ___2_item, int32_t ___3_threadIndex, const RuntimeMethod* method) 
{
	const uint32_t SizeOf_TValue_tB7B830249365402E1E7E370540F98F1B5A6B1DEC = il2cpp_codegen_sizeof(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 7));
	const uint32_t SizeOf_NativeParallelMultiHashMapIterator_1_t8F8F521BA2FCBBCF9E4F521446265362C11BF3B8 = il2cpp_codegen_sizeof(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 11));
	const uint32_t SizeOf_TKey_t693D3BBF62B067F3D91C53F42FC97AB9D4C1FE69 = il2cpp_codegen_sizeof(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 0));
	void* L_15 = alloca(Il2CppFakeBoxBuffer::SizeNeededFor(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 0)));
	const Il2CppFullySharedGenericStruct L_1 = alloca(SizeOf_TKey_t693D3BBF62B067F3D91C53F42FC97AB9D4C1FE69);
	const Il2CppFullySharedGenericStruct L_10 = L_1;
	const Il2CppFullySharedGenericStruct L_35 = L_1;
	const Il2CppFullySharedGenericStruct L_14 = alloca(SizeOf_TValue_tB7B830249365402E1E7E370540F98F1B5A6B1DEC);
	Il2CppFullySharedGenericStruct V_0 = alloca(SizeOf_TValue_tB7B830249365402E1E7E370540F98F1B5A6B1DEC);
	memset(V_0, 0, SizeOf_TValue_tB7B830249365402E1E7E370540F98F1B5A6B1DEC);
	NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51 V_1 = alloca(SizeOf_NativeParallelMultiHashMapIterator_1_t8F8F521BA2FCBBCF9E4F521446265362C11BF3B8);
	memset(V_1, 0, SizeOf_NativeParallelMultiHashMapIterator_1_t8F8F521BA2FCBBCF9E4F521446265362C11BF3B8);
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	int32_t* V_4 = NULL;
	bool V_5 = false;
	bool V_6 = false;
	bool V_7 = false;
	int32_t* V_8 = NULL;
	int32_t V_9 = 0;
	bool V_10 = false;
	bool V_11 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		il2cpp_codegen_memcpy(L_1, ___1_key, SizeOf_TKey_t693D3BBF62B067F3D91C53F42FC97AB9D4C1FE69);
		bool L_2;
		L_2 = InvokerFuncInvoker4< bool, UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, Il2CppFullySharedGenericStruct, Il2CppFullySharedGenericStruct*, NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1), NULL, L_0, L_1, (Il2CppFullySharedGenericStruct*)V_0, (NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51*)V_1);
		V_5 = L_2;
		bool L_3 = V_5;
		if (!L_3)
		{
			goto IL_001b;
		}
	}
	{
		V_6 = (bool)0;
		goto IL_00da;
	}

IL_001b:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = ___0_data;
		int32_t L_5 = ___3_threadIndex;
		int32_t L_6;
		L_6 = ((  int32_t (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5)))(L_4, L_5, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		V_2 = L_6;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		uint8_t* L_8 = L_7->___keys;
		int32_t L_9 = V_2;
		il2cpp_codegen_memcpy(L_10, ___1_key, SizeOf_TKey_t693D3BBF62B067F3D91C53F42FC97AB9D4C1FE69);
		InvokerActionInvoker3< void*, int32_t, Il2CppFullySharedGenericStruct >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 6)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 6), NULL, (void*)L_8, L_9, L_10);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_11 = ___0_data;
		NullCheck(L_11);
		uint8_t* L_12 = L_11->___values;
		int32_t L_13 = V_2;
		il2cpp_codegen_memcpy(L_14, ___2_item, SizeOf_TValue_tB7B830249365402E1E7E370540F98F1B5A6B1DEC);
		InvokerActionInvoker3< void*, int32_t, Il2CppFullySharedGenericStruct >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), NULL, (void*)L_12, L_13, L_14);
		int32_t L_16;
		L_16 = ConstrainedFuncInvoker0< int32_t >::Invoke(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 0), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9), L_15, (void*)(Il2CppFullySharedGenericStruct*)___1_key);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_17 = ___0_data;
		NullCheck(L_17);
		int32_t L_18 = L_17->___bucketCapacityMask;
		V_3 = ((int32_t)(L_16&L_18));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_19 = ___0_data;
		NullCheck(L_19);
		uint8_t* L_20 = L_19->___buckets;
		V_4 = (int32_t*)L_20;
		int32_t* L_21 = V_4;
		int32_t L_22 = V_3;
		int32_t L_23 = V_2;
		int32_t L_24;
		L_24 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_21, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_22), 4)))), L_23, (-1), NULL);
		V_7 = (bool)((((int32_t)((((int32_t)L_24) == ((int32_t)(-1)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_25 = V_7;
		if (!L_25)
		{
			goto IL_00d5;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_26 = ___0_data;
		NullCheck(L_26);
		uint8_t* L_27 = L_26->___next;
		V_8 = (int32_t*)L_27;
		V_9 = (-1);
	}

IL_0082:
	{
		int32_t* L_28 = V_4;
		int32_t L_29 = V_3;
		int32_t L_30 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_28, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_29), 4))))));
		V_9 = L_30;
		int32_t* L_31 = V_8;
		int32_t L_32 = V_2;
		int32_t L_33 = V_9;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_31, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_32), 4))))) = (int32_t)L_33;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_34 = ___0_data;
		il2cpp_codegen_memcpy(L_35, ___1_key, SizeOf_TKey_t693D3BBF62B067F3D91C53F42FC97AB9D4C1FE69);
		bool L_36;
		L_36 = InvokerFuncInvoker4< bool, UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, Il2CppFullySharedGenericStruct, Il2CppFullySharedGenericStruct*, NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1), NULL, L_34, L_35, (Il2CppFullySharedGenericStruct*)V_0, (NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51*)V_1);
		V_10 = L_36;
		bool L_37 = V_10;
		if (!L_37)
		{
			goto IL_00b7;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_38 = ___0_data;
		int32_t L_39 = V_2;
		int32_t L_40 = ___3_threadIndex;
		((  void (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, int32_t, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 10)))(L_38, L_39, L_40, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 10));
		V_6 = (bool)0;
		goto IL_00da;
	}

IL_00b7:
	{
		int32_t* L_41 = V_4;
		int32_t L_42 = V_3;
		int32_t L_43 = V_2;
		int32_t L_44 = V_9;
		int32_t L_45;
		L_45 = Interlocked_CompareExchange_mB06E8737D3DA41F9FFBC38A6D0583D515EFB5717((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_41, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_42), 4)))), L_43, L_44, NULL);
		int32_t L_46 = V_9;
		V_11 = (bool)((((int32_t)((((int32_t)L_45) == ((int32_t)L_46))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_47 = V_11;
		if (L_47)
		{
			goto IL_0082;
		}
	}
	{
	}

IL_00d5:
	{
		V_6 = (bool)1;
		goto IL_00da;
	}

IL_00da:
	{
		bool L_48 = V_6;
		return L_48;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryAdd_m6F349BA91ED50CB53221A30136FCD2F0D0A2922B_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, Il2CppFullySharedGenericStruct ___1_key, Il2CppFullySharedGenericStruct ___2_item, bool ___3_isMultiHashMap, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___4_allocation, const RuntimeMethod* method) 
{
	const uint32_t SizeOf_TValue_tB7B830249365402E1E7E370540F98F1B5A6B1DEC = il2cpp_codegen_sizeof(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 7));
	const uint32_t SizeOf_NativeParallelMultiHashMapIterator_1_t8F8F521BA2FCBBCF9E4F521446265362C11BF3B8 = il2cpp_codegen_sizeof(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 11));
	const uint32_t SizeOf_TKey_t693D3BBF62B067F3D91C53F42FC97AB9D4C1FE69 = il2cpp_codegen_sizeof(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 0));
	void* L_77 = alloca(Il2CppFakeBoxBuffer::SizeNeededFor(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 0)));
	const Il2CppFullySharedGenericStruct L_2 = alloca(SizeOf_TKey_t693D3BBF62B067F3D91C53F42FC97AB9D4C1FE69);
	const Il2CppFullySharedGenericStruct L_72 = L_2;
	const Il2CppFullySharedGenericStruct L_76 = alloca(SizeOf_TValue_tB7B830249365402E1E7E370540F98F1B5A6B1DEC);
	Il2CppFullySharedGenericStruct V_0 = alloca(SizeOf_TValue_tB7B830249365402E1E7E370540F98F1B5A6B1DEC);
	memset(V_0, 0, SizeOf_TValue_tB7B830249365402E1E7E370540F98F1B5A6B1DEC);
	NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51 V_1 = alloca(SizeOf_NativeParallelMultiHashMapIterator_1_t8F8F521BA2FCBBCF9E4F521446265362C11BF3B8);
	memset(V_1, 0, SizeOf_NativeParallelMultiHashMapIterator_1_t8F8F521BA2FCBBCF9E4F521446265362C11BF3B8);
	bool V_2 = false;
	int32_t V_3 = 0;
	int32_t* V_4 = NULL;
	int32_t V_5 = 0;
	int32_t* V_6 = NULL;
	bool V_7 = false;
	int32_t V_8 = 0;
	int32_t V_9 = 0;
	bool V_10 = false;
	bool V_11 = false;
	bool V_12 = false;
	int32_t V_13 = 0;
	bool V_14 = false;
	int32_t V_15 = 0;
	bool V_16 = false;
	int32_t G_B3_0 = 0;
	int32_t G_B7_0 = 0;
	{
		bool L_0 = ___3_isMultiHashMap;
		if (L_0)
		{
			goto IL_0014;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_1 = ___0_data;
		il2cpp_codegen_memcpy(L_2, ___1_key, SizeOf_TKey_t693D3BBF62B067F3D91C53F42FC97AB9D4C1FE69);
		bool L_3;
		L_3 = InvokerFuncInvoker4< bool, UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, Il2CppFullySharedGenericStruct, Il2CppFullySharedGenericStruct*, NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1), NULL, L_1, L_2, (Il2CppFullySharedGenericStruct*)V_0, (NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51*)V_1);
		G_B3_0 = ((((int32_t)L_3) == ((int32_t)0))? 1 : 0);
		goto IL_0015;
	}

IL_0014:
	{
		G_B3_0 = 1;
	}

IL_0015:
	{
		V_2 = (bool)G_B3_0;
		bool L_4 = V_2;
		if (!L_4)
		{
			goto IL_0197;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_5 = ___0_data;
		NullCheck(L_5);
		int32_t L_6 = L_5->___allocatedIndexLength;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		int32_t L_8 = L_7->___keyCapacity;
		if ((((int32_t)L_6) < ((int32_t)L_8)))
		{
			goto IL_0037;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_9 = ___0_data;
		int32_t* L_10;
		L_10 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_9, NULL);
		int32_t L_11 = (*(L_10));
		G_B7_0 = ((((int32_t)L_11) < ((int32_t)0))? 1 : 0);
		goto IL_0038;
	}

IL_0037:
	{
		G_B7_0 = 0;
	}

IL_0038:
	{
		V_7 = (bool)G_B7_0;
		bool L_12 = V_7;
		if (!L_12)
		{
			goto IL_00f5;
		}
	}
	{
		int32_t L_13;
		L_13 = JobsUtility_get_ThreadIndexCount_m88A954344398143540618B35943F863B92465676(NULL);
		V_8 = L_13;
		V_9 = 1;
		goto IL_00b7;
	}

IL_004e:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_14 = ___0_data;
		int32_t* L_15;
		L_15 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_14, NULL);
		int32_t L_16 = V_9;
		int32_t L_17 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_15, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_16, ((int32_t)16)))), 4))))));
		V_10 = (bool)((((int32_t)((((int32_t)L_17) < ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_18 = V_10;
		if (!L_18)
		{
			goto IL_00b0;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_19 = ___0_data;
		int32_t* L_20;
		L_20 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_19, NULL);
		int32_t L_21 = V_9;
		int32_t L_22 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_20, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_21, ((int32_t)16)))), 4))))));
		V_3 = L_22;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_23 = ___0_data;
		NullCheck(L_23);
		uint8_t* L_24 = L_23->___next;
		V_4 = (int32_t*)L_24;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_25 = ___0_data;
		int32_t* L_26;
		L_26 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_25, NULL);
		int32_t L_27 = V_9;
		int32_t* L_28 = V_4;
		int32_t L_29 = V_3;
		int32_t L_30 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_28, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_29), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_26, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)((int32_t)il2cpp_codegen_multiply(L_27, ((int32_t)16)))), 4))))) = (int32_t)L_30;
		int32_t* L_31 = V_4;
		int32_t L_32 = V_3;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_31, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_32), 4))))) = (int32_t)(-1);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_33 = ___0_data;
		int32_t* L_34;
		L_34 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_33, NULL);
		int32_t L_35 = V_3;
		*((int32_t*)L_34) = (int32_t)L_35;
		goto IL_00c3;
	}

IL_00b0:
	{
		int32_t L_36 = V_9;
		V_9 = ((int32_t)il2cpp_codegen_add(L_36, 1));
	}

IL_00b7:
	{
		int32_t L_37 = V_9;
		int32_t L_38 = V_8;
		V_11 = (bool)((((int32_t)L_37) < ((int32_t)L_38))? 1 : 0);
		bool L_39 = V_11;
		if (L_39)
		{
			goto IL_004e;
		}
	}

IL_00c3:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_40 = ___0_data;
		int32_t* L_41;
		L_41 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_40, NULL);
		int32_t L_42 = (*(L_41));
		V_12 = (bool)((((int32_t)L_42) < ((int32_t)0))? 1 : 0);
		bool L_43 = V_12;
		if (!L_43)
		{
			goto IL_00f4;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_44 = ___0_data;
		NullCheck(L_44);
		int32_t L_45 = L_44->___keyCapacity;
		int32_t L_46;
		L_46 = UnsafeParallelHashMapData_GrowCapacity_m7F2FF57E76510A99266830779059C6C202B9EC47(L_45, NULL);
		V_13 = L_46;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_47 = ___0_data;
		int32_t L_48 = V_13;
		int32_t L_49 = V_13;
		int32_t L_50;
		L_50 = UnsafeParallelHashMapData_GetBucketSize_mEF90FF75EFE70E4B59CD6AF9FDCB3D564A1986A3(L_49, NULL);
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_51 = ___4_allocation;
		((  void (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, int32_t, int32_t, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12)))(L_47, L_48, L_50, L_51, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 12));
	}

IL_00f4:
	{
	}

IL_00f5:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_52 = ___0_data;
		int32_t* L_53;
		L_53 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_52, NULL);
		int32_t L_54 = (*(L_53));
		V_3 = L_54;
		int32_t L_55 = V_3;
		V_14 = (bool)((((int32_t)((((int32_t)L_55) < ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_56 = V_14;
		if (!L_56)
		{
			goto IL_0121;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_57 = ___0_data;
		int32_t* L_58;
		L_58 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_57, NULL);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_59 = ___0_data;
		NullCheck(L_59);
		uint8_t* L_60 = L_59->___next;
		int32_t L_61 = V_3;
		int32_t L_62 = *((int32_t*)((uint8_t*)il2cpp_codegen_add((intptr_t)L_60, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_61), 4)))));
		*((int32_t*)L_58) = (int32_t)L_62;
		goto IL_0135;
	}

IL_0121:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_63 = ___0_data;
		NullCheck(L_63);
		int32_t* L_64 = (int32_t*)(&L_63->___allocatedIndexLength);
		int32_t* L_65 = L_64;
		int32_t L_66 = *((int32_t*)L_65);
		V_15 = L_66;
		int32_t L_67 = V_15;
		*((int32_t*)L_65) = (int32_t)((int32_t)il2cpp_codegen_add(L_67, 1));
		int32_t L_68 = V_15;
		V_3 = L_68;
	}

IL_0135:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_69 = ___0_data;
		NullCheck(L_69);
		uint8_t* L_70 = L_69->___keys;
		int32_t L_71 = V_3;
		il2cpp_codegen_memcpy(L_72, ___1_key, SizeOf_TKey_t693D3BBF62B067F3D91C53F42FC97AB9D4C1FE69);
		InvokerActionInvoker3< void*, int32_t, Il2CppFullySharedGenericStruct >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 6)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 6), NULL, (void*)L_70, L_71, L_72);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_73 = ___0_data;
		NullCheck(L_73);
		uint8_t* L_74 = L_73->___values;
		int32_t L_75 = V_3;
		il2cpp_codegen_memcpy(L_76, ___2_item, SizeOf_TValue_tB7B830249365402E1E7E370540F98F1B5A6B1DEC);
		InvokerActionInvoker3< void*, int32_t, Il2CppFullySharedGenericStruct >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), NULL, (void*)L_74, L_75, L_76);
		int32_t L_78;
		L_78 = ConstrainedFuncInvoker0< int32_t >::Invoke(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 0), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9), L_77, (void*)(Il2CppFullySharedGenericStruct*)___1_key);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_79 = ___0_data;
		NullCheck(L_79);
		int32_t L_80 = L_79->___bucketCapacityMask;
		V_5 = ((int32_t)(L_78&L_80));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_81 = ___0_data;
		NullCheck(L_81);
		uint8_t* L_82 = L_81->___buckets;
		V_6 = (int32_t*)L_82;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_83 = ___0_data;
		NullCheck(L_83);
		uint8_t* L_84 = L_83->___next;
		V_4 = (int32_t*)L_84;
		int32_t* L_85 = V_4;
		int32_t L_86 = V_3;
		int32_t* L_87 = V_6;
		int32_t L_88 = V_5;
		int32_t L_89 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_87, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_88), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_85, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_86), 4))))) = (int32_t)L_89;
		int32_t* L_90 = V_6;
		int32_t L_91 = V_5;
		int32_t L_92 = V_3;
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_90, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_91), 4))))) = (int32_t)L_92;
		V_16 = (bool)1;
		goto IL_019c;
	}

IL_0197:
	{
		V_16 = (bool)0;
		goto IL_019c;
	}

IL_019c:
	{
		bool L_93 = V_16;
		return L_93;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMapBase_2_Remove_m6648F1C82F87EE0C1EC2361356969E1893FF4EAC_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, Il2CppFullySharedGenericStruct ___1_key, bool ___2_isMultiHashMap, const RuntimeMethod* method) 
{
	const uint32_t SizeOf_TKey_t693D3BBF62B067F3D91C53F42FC97AB9D4C1FE69 = il2cpp_codegen_sizeof(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 0));
	void* L_7 = alloca(Il2CppFakeBoxBuffer::SizeNeededFor(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 0)));
	void* L_19 = alloca(Il2CppFakeBoxBuffer::SizeNeededFor(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 0)));
	const Il2CppFullySharedGenericStruct L_17 = alloca(SizeOf_TKey_t693D3BBF62B067F3D91C53F42FC97AB9D4C1FE69);
	const Il2CppFullySharedGenericStruct L_18 = alloca(SizeOf_TKey_t693D3BBF62B067F3D91C53F42FC97AB9D4C1FE69);
	int32_t V_0 = 0;
	int32_t* V_1 = NULL;
	int32_t* V_2 = NULL;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	int32_t V_5 = 0;
	bool V_6 = false;
	int32_t V_7 = 0;
	bool V_8 = false;
	Il2CppFullySharedGenericStruct V_9 = alloca(SizeOf_TKey_t693D3BBF62B067F3D91C53F42FC97AB9D4C1FE69);
	memset(V_9, 0, SizeOf_TKey_t693D3BBF62B067F3D91C53F42FC97AB9D4C1FE69);
	int32_t V_10 = 0;
	bool V_11 = false;
	bool V_12 = false;
	bool V_13 = false;
	int32_t G_B15_0 = 0;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		int32_t L_1 = L_0->___keyCapacity;
		V_6 = (bool)((((int32_t)L_1) == ((int32_t)0))? 1 : 0);
		bool L_2 = V_6;
		if (!L_2)
		{
			goto IL_0019;
		}
	}
	{
		V_7 = 0;
		goto IL_010f;
	}

IL_0019:
	{
		V_0 = 0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_3 = ___0_data;
		NullCheck(L_3);
		uint8_t* L_4 = L_3->___buckets;
		V_1 = (int32_t*)L_4;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_5 = ___0_data;
		NullCheck(L_5);
		uint8_t* L_6 = L_5->___next;
		V_2 = (int32_t*)L_6;
		int32_t L_8;
		L_8 = ConstrainedFuncInvoker0< int32_t >::Invoke(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 0), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9), L_7, (void*)(Il2CppFullySharedGenericStruct*)___1_key);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_9 = ___0_data;
		NullCheck(L_9);
		int32_t L_10 = L_9->___bucketCapacityMask;
		V_3 = ((int32_t)(L_8&L_10));
		V_4 = (-1);
		int32_t* L_11 = V_1;
		int32_t L_12 = V_3;
		int32_t L_13 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_11, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_12), 4))))));
		V_5 = L_13;
		goto IL_00ef;
	}

IL_004f:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_14 = ___0_data;
		NullCheck(L_14);
		uint8_t* L_15 = L_14->___keys;
		int32_t L_16 = V_5;
		InvokerActionInvoker3< void*, int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13), NULL, (void*)L_15, L_16, (Il2CppFullySharedGenericStruct*)L_17);
		il2cpp_codegen_memcpy(V_9, L_17, SizeOf_TKey_t693D3BBF62B067F3D91C53F42FC97AB9D4C1FE69);
		il2cpp_codegen_memcpy(L_18, ___1_key, SizeOf_TKey_t693D3BBF62B067F3D91C53F42FC97AB9D4C1FE69);
		bool L_20;
		L_20 = ConstrainedFuncInvoker1< bool, Il2CppFullySharedGenericStruct >::Invoke(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 0), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 15), L_19, (void*)(Il2CppFullySharedGenericStruct*)V_9, L_18);
		V_8 = L_20;
		bool L_21 = V_8;
		if (!L_21)
		{
			goto IL_00de;
		}
	}
	{
		int32_t L_22 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add(L_22, 1));
		int32_t L_23 = V_4;
		V_11 = (bool)((((int32_t)L_23) < ((int32_t)0))? 1 : 0);
		bool L_24 = V_11;
		if (!L_24)
		{
			goto IL_0096;
		}
	}
	{
		int32_t* L_25 = V_1;
		int32_t L_26 = V_3;
		int32_t* L_27 = V_2;
		int32_t L_28 = V_5;
		int32_t L_29 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_27, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_28), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_25, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_26), 4))))) = (int32_t)L_29;
		goto IL_00a8;
	}

IL_0096:
	{
		int32_t* L_30 = V_2;
		int32_t L_31 = V_4;
		int32_t* L_32 = V_2;
		int32_t L_33 = V_5;
		int32_t L_34 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_32, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_33), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_30, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_31), 4))))) = (int32_t)L_34;
	}

IL_00a8:
	{
		int32_t* L_35 = V_2;
		int32_t L_36 = V_5;
		int32_t L_37 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_35, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_36), 4))))));
		V_10 = L_37;
		int32_t* L_38 = V_2;
		int32_t L_39 = V_5;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_40 = ___0_data;
		int32_t* L_41;
		L_41 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_40, NULL);
		int32_t L_42 = (*(L_41));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_38, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_39), 4))))) = (int32_t)L_42;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_43 = ___0_data;
		int32_t* L_44;
		L_44 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_43, NULL);
		int32_t L_45 = V_5;
		*((int32_t*)L_44) = (int32_t)L_45;
		int32_t L_46 = V_10;
		V_5 = L_46;
		bool L_47 = ___2_isMultiHashMap;
		V_12 = (bool)((((int32_t)L_47) == ((int32_t)0))? 1 : 0);
		bool L_48 = V_12;
		if (!L_48)
		{
			goto IL_00db;
		}
	}
	{
		goto IL_010a;
	}

IL_00db:
	{
		goto IL_00ee;
	}

IL_00de:
	{
		int32_t L_49 = V_5;
		V_4 = L_49;
		int32_t* L_50 = V_2;
		int32_t L_51 = V_5;
		int32_t L_52 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_50, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_51), 4))))));
		V_5 = L_52;
	}

IL_00ee:
	{
	}

IL_00ef:
	{
		int32_t L_53 = V_5;
		if ((((int32_t)L_53) < ((int32_t)0)))
		{
			goto IL_0100;
		}
	}
	{
		int32_t L_54 = V_5;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_55 = ___0_data;
		NullCheck(L_55);
		int32_t L_56 = L_55->___keyCapacity;
		G_B15_0 = ((((int32_t)L_54) < ((int32_t)L_56))? 1 : 0);
		goto IL_0101;
	}

IL_0100:
	{
		G_B15_0 = 0;
	}

IL_0101:
	{
		V_13 = (bool)G_B15_0;
		bool L_57 = V_13;
		if (L_57)
		{
			goto IL_004f;
		}
	}

IL_010a:
	{
		int32_t L_58 = V_0;
		V_7 = L_58;
		goto IL_010f;
	}

IL_010f:
	{
		int32_t L_59 = V_7;
		return L_59;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapBase_2_Remove_m8BAE6A94FC57AB2FD13A4FD8729670F270544F06_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51 ___1_it, const RuntimeMethod* method) 
{
	void* L_4 = alloca(Il2CppFakeBoxBuffer::SizeNeededFor(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 0)));
	const uint32_t SizeOf_NativeParallelMultiHashMapIterator_1_t8F8F521BA2FCBBCF9E4F521446265362C11BF3B8 = il2cpp_codegen_sizeof(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 11));
	const NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51 L_12 = alloca(SizeOf_NativeParallelMultiHashMapIterator_1_t8F8F521BA2FCBBCF9E4F521446265362C11BF3B8);
	const NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51 L_27 = L_12;
	const NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51 L_35 = L_12;
	const NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51 L_39 = L_12;
	const NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51 L_46 = alloca(SizeOf_NativeParallelMultiHashMapIterator_1_t8F8F521BA2FCBBCF9E4F521446265362C11BF3B8);
	int32_t* V_0 = NULL;
	int32_t* V_1 = NULL;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	bool V_4 = false;
	bool V_5 = false;
	bool V_6 = false;
	int32_t G_B7_0 = 0;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = ___0_data;
		NullCheck(L_0);
		uint8_t* L_1 = L_0->___buckets;
		V_0 = (int32_t*)L_1;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		NullCheck(L_2);
		uint8_t* L_3 = L_2->___next;
		V_1 = (int32_t*)L_3;
		int32_t L_5;
		L_5 = ConstrainedFuncInvoker0< int32_t >::Invoke(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 0), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9), L_4, (void*)(((Il2CppFullySharedGenericStruct*)il2cpp_codegen_get_instance_field_data_pointer((NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51*)___1_it, il2cpp_rgctx_field(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 11),0)))));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_6 = ___0_data;
		NullCheck(L_6);
		int32_t L_7 = L_6->___bucketCapacityMask;
		V_2 = ((int32_t)(L_5&L_7));
		int32_t* L_8 = V_0;
		int32_t L_9 = V_2;
		int32_t L_10 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_8, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_9), 4))))));
		V_3 = L_10;
		int32_t L_11 = V_3;
		il2cpp_codegen_memcpy(L_12, ___1_it, SizeOf_NativeParallelMultiHashMapIterator_1_t8F8F521BA2FCBBCF9E4F521446265362C11BF3B8);
		int32_t L_13 = *(int32_t*)il2cpp_codegen_get_instance_field_data_pointer(L_12, il2cpp_rgctx_field(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 11),2));
		V_4 = (bool)((((int32_t)L_11) == ((int32_t)L_13))? 1 : 0);
		bool L_14 = V_4;
		if (!L_14)
		{
			goto IL_0052;
		}
	}
	{
		int32_t* L_15 = V_0;
		int32_t L_16 = V_2;
		int32_t* L_17 = V_1;
		int32_t L_18 = V_3;
		int32_t L_19 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_17, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_18), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_15, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_16), 4))))) = (int32_t)L_19;
		goto IL_009e;
	}

IL_0052:
	{
		goto IL_005f;
	}

IL_0055:
	{
		int32_t* L_20 = V_1;
		int32_t L_21 = V_3;
		int32_t L_22 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_20, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_21), 4))))));
		V_3 = L_22;
	}

IL_005f:
	{
		int32_t L_23 = V_3;
		if ((((int32_t)L_23) < ((int32_t)0)))
		{
			goto IL_0077;
		}
	}
	{
		int32_t* L_24 = V_1;
		int32_t L_25 = V_3;
		int32_t L_26 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_24, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_25), 4))))));
		il2cpp_codegen_memcpy(L_27, ___1_it, SizeOf_NativeParallelMultiHashMapIterator_1_t8F8F521BA2FCBBCF9E4F521446265362C11BF3B8);
		int32_t L_28 = *(int32_t*)il2cpp_codegen_get_instance_field_data_pointer(L_27, il2cpp_rgctx_field(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 11),2));
		G_B7_0 = ((((int32_t)((((int32_t)L_26) == ((int32_t)L_28))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0078;
	}

IL_0077:
	{
		G_B7_0 = 0;
	}

IL_0078:
	{
		V_5 = (bool)G_B7_0;
		bool L_29 = V_5;
		if (L_29)
		{
			goto IL_0055;
		}
	}
	{
		int32_t L_30 = V_3;
		V_6 = (bool)((((int32_t)L_30) < ((int32_t)0))? 1 : 0);
		bool L_31 = V_6;
		if (!L_31)
		{
			goto IL_008a;
		}
	}
	{
	}

IL_008a:
	{
		int32_t* L_32 = V_1;
		int32_t L_33 = V_3;
		int32_t* L_34 = V_1;
		il2cpp_codegen_memcpy(L_35, ___1_it, SizeOf_NativeParallelMultiHashMapIterator_1_t8F8F521BA2FCBBCF9E4F521446265362C11BF3B8);
		int32_t L_36 = *(int32_t*)il2cpp_codegen_get_instance_field_data_pointer(L_35, il2cpp_rgctx_field(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 11),2));
		int32_t L_37 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_34, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_36), 4))))));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_32, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_33), 4))))) = (int32_t)L_37;
	}

IL_009e:
	{
		int32_t* L_38 = V_1;
		il2cpp_codegen_memcpy(L_39, ___1_it, SizeOf_NativeParallelMultiHashMapIterator_1_t8F8F521BA2FCBBCF9E4F521446265362C11BF3B8);
		int32_t L_40 = *(int32_t*)il2cpp_codegen_get_instance_field_data_pointer(L_39, il2cpp_rgctx_field(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 11),2));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_41 = ___0_data;
		int32_t* L_42;
		L_42 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_41, NULL);
		int32_t L_43 = (*(L_42));
		*((int32_t*)((int32_t*)il2cpp_codegen_add((intptr_t)L_38, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_40), 4))))) = (int32_t)L_43;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_44 = ___0_data;
		int32_t* L_45;
		L_45 = UnsafeParallelHashMapData_get_firstFreeTLS_m75A8F3E5E2ACC2BAA05561AC4D6CD59CC06F6CC5((UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)L_44, NULL);
		il2cpp_codegen_memcpy(L_46, ___1_it, SizeOf_NativeParallelMultiHashMapIterator_1_t8F8F521BA2FCBBCF9E4F521446265362C11BF3B8);
		int32_t L_47 = *(int32_t*)il2cpp_codegen_get_instance_field_data_pointer(L_46, il2cpp_rgctx_field(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 11),2));
		*((int32_t*)L_45) = (int32_t)L_47;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mB16D13831106B0DC2EF2AD361743D9FC6597B1DA_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, Il2CppFullySharedGenericStruct ___1_key, Il2CppFullySharedGenericStruct* ___2_item, NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51* ___3_it, const RuntimeMethod* method) 
{
	const uint32_t SizeOf_TKey_t693D3BBF62B067F3D91C53F42FC97AB9D4C1FE69 = il2cpp_codegen_sizeof(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 0));
	const uint32_t SizeOf_TValue_tB7B830249365402E1E7E370540F98F1B5A6B1DEC = il2cpp_codegen_sizeof(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 7));
	void* L_12 = alloca(Il2CppFakeBoxBuffer::SizeNeededFor(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 0)));
	const Il2CppFullySharedGenericStruct L_1 = alloca(SizeOf_TKey_t693D3BBF62B067F3D91C53F42FC97AB9D4C1FE69);
	int32_t* V_0 = NULL;
	int32_t V_1 = 0;
	bool V_2 = false;
	int32_t V_3 = 0;
	bool V_4 = false;
	{
		NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51* L_0 = ___3_it;
		il2cpp_codegen_memcpy(L_1, ___1_key, SizeOf_TKey_t693D3BBF62B067F3D91C53F42FC97AB9D4C1FE69);
		il2cpp_codegen_write_instance_field_data(L_0, il2cpp_rgctx_field(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 11),0), L_1, SizeOf_TKey_t693D3BBF62B067F3D91C53F42FC97AB9D4C1FE69);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = ___0_data;
		NullCheck(L_2);
		int32_t L_3 = L_2->___allocatedIndexLength;
		V_2 = (bool)((((int32_t)((((int32_t)L_3) > ((int32_t)0))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_4 = V_2;
		if (!L_4)
		{
			goto IL_0035;
		}
	}
	{
		NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51* L_5 = ___3_it;
		NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51* L_6 = ___3_it;
		int32_t L_7 = (-1);
		V_3 = L_7;
		il2cpp_codegen_write_instance_field_data<int32_t>(L_6, il2cpp_rgctx_field(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 11),1), L_7);
		int32_t L_8 = V_3;
		il2cpp_codegen_write_instance_field_data<int32_t>(L_5, il2cpp_rgctx_field(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 11),2), L_8);
		Il2CppFullySharedGenericStruct* L_9 = ___2_item;
		il2cpp_codegen_initobj(L_9, SizeOf_TValue_tB7B830249365402E1E7E370540F98F1B5A6B1DEC);
		V_4 = (bool)0;
		goto IL_0073;
	}

IL_0035:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_10 = ___0_data;
		NullCheck(L_10);
		uint8_t* L_11 = L_10->___buckets;
		V_0 = (int32_t*)L_11;
		int32_t L_13;
		L_13 = ConstrainedFuncInvoker0< int32_t >::Invoke(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 0), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9), L_12, (void*)(Il2CppFullySharedGenericStruct*)___1_key);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_14 = ___0_data;
		NullCheck(L_14);
		int32_t L_15 = L_14->___bucketCapacityMask;
		V_1 = ((int32_t)(L_13&L_15));
		NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51* L_16 = ___3_it;
		NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51* L_17 = ___3_it;
		int32_t* L_18 = V_0;
		int32_t L_19 = V_1;
		int32_t L_20 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_18, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_19), 4))))));
		int32_t L_21 = L_20;
		V_3 = L_21;
		il2cpp_codegen_write_instance_field_data<int32_t>(L_17, il2cpp_rgctx_field(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 11),1), L_21);
		int32_t L_22 = V_3;
		il2cpp_codegen_write_instance_field_data<int32_t>(L_16, il2cpp_rgctx_field(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 11),2), L_22);
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_23 = ___0_data;
		Il2CppFullySharedGenericStruct* L_24 = ___2_item;
		NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51* L_25 = ___3_it;
		bool L_26;
		L_26 = ((  bool (*) (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*, Il2CppFullySharedGenericStruct*, NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51*, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 16)))(L_23, L_24, L_25, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 16));
		V_4 = L_26;
		goto IL_0073;
	}

IL_0073:
	{
		bool L_27 = V_4;
		return L_27;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_TryGetNextValueAtomic_m02842BF5ACFFDD0CC5E0C86B2A523A797D5B0477_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, Il2CppFullySharedGenericStruct* ___1_item, NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51* ___2_it, const RuntimeMethod* method) 
{
	const uint32_t SizeOf_TKey_t693D3BBF62B067F3D91C53F42FC97AB9D4C1FE69 = il2cpp_codegen_sizeof(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 0));
	const uint32_t SizeOf_TValue_tB7B830249365402E1E7E370540F98F1B5A6B1DEC = il2cpp_codegen_sizeof(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 7));
	void* L_26 = alloca(Il2CppFakeBoxBuffer::SizeNeededFor(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 0)));
	const Il2CppFullySharedGenericStruct L_23 = alloca(SizeOf_TKey_t693D3BBF62B067F3D91C53F42FC97AB9D4C1FE69);
	const Il2CppFullySharedGenericStruct L_25 = alloca(SizeOf_TKey_t693D3BBF62B067F3D91C53F42FC97AB9D4C1FE69);
	const Il2CppFullySharedGenericStruct L_39 = alloca(SizeOf_TValue_tB7B830249365402E1E7E370540F98F1B5A6B1DEC);
	int32_t V_0 = 0;
	int32_t* V_1 = NULL;
	bool V_2 = false;
	bool V_3 = false;
	bool V_4 = false;
	bool V_5 = false;
	Il2CppFullySharedGenericStruct V_6 = alloca(SizeOf_TKey_t693D3BBF62B067F3D91C53F42FC97AB9D4C1FE69);
	memset(V_6, 0, SizeOf_TKey_t693D3BBF62B067F3D91C53F42FC97AB9D4C1FE69);
	int32_t G_B3_0 = 0;
	int32_t G_B9_0 = 0;
	{
		NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51* L_0 = ___2_it;
		int32_t L_1 = *(int32_t*)il2cpp_codegen_get_instance_field_data_pointer(L_0, il2cpp_rgctx_field(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 11),1));
		V_0 = L_1;
		NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51* L_2 = ___2_it;
		il2cpp_codegen_write_instance_field_data<int32_t>(L_2, il2cpp_rgctx_field(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 11),1), (-1));
		NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51* L_3 = ___2_it;
		il2cpp_codegen_write_instance_field_data<int32_t>(L_3, il2cpp_rgctx_field(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 11),2), (-1));
		Il2CppFullySharedGenericStruct* L_4 = ___1_item;
		il2cpp_codegen_initobj(L_4, SizeOf_TValue_tB7B830249365402E1E7E370540F98F1B5A6B1DEC);
		int32_t L_5 = V_0;
		if ((((int32_t)L_5) < ((int32_t)0)))
		{
			goto IL_002f;
		}
	}
	{
		int32_t L_6 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		int32_t L_8 = L_7->___keyCapacity;
		G_B3_0 = ((((int32_t)((((int32_t)L_6) < ((int32_t)L_8))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0030;
	}

IL_002f:
	{
		G_B3_0 = 1;
	}

IL_0030:
	{
		V_2 = (bool)G_B3_0;
		bool L_9 = V_2;
		if (!L_9)
		{
			goto IL_003c;
		}
	}
	{
		V_3 = (bool)0;
		goto IL_00c1;
	}

IL_003c:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_10 = ___0_data;
		NullCheck(L_10);
		uint8_t* L_11 = L_10->___next;
		V_1 = (int32_t*)L_11;
		goto IL_006d;
	}

IL_0045:
	{
		int32_t* L_12 = V_1;
		int32_t L_13 = V_0;
		int32_t L_14 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_12, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_13), 4))))));
		V_0 = L_14;
		int32_t L_15 = V_0;
		if ((((int32_t)L_15) < ((int32_t)0)))
		{
			goto IL_0060;
		}
	}
	{
		int32_t L_16 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_17 = ___0_data;
		NullCheck(L_17);
		int32_t L_18 = L_17->___keyCapacity;
		G_B9_0 = ((((int32_t)((((int32_t)L_16) < ((int32_t)L_18))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_0061;
	}

IL_0060:
	{
		G_B9_0 = 1;
	}

IL_0061:
	{
		V_4 = (bool)G_B9_0;
		bool L_19 = V_4;
		if (!L_19)
		{
			goto IL_006c;
		}
	}
	{
		V_3 = (bool)0;
		goto IL_00c1;
	}

IL_006c:
	{
	}

IL_006d:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_20 = ___0_data;
		NullCheck(L_20);
		uint8_t* L_21 = L_20->___keys;
		int32_t L_22 = V_0;
		InvokerActionInvoker3< void*, int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13), NULL, (void*)L_21, L_22, (Il2CppFullySharedGenericStruct*)L_23);
		il2cpp_codegen_memcpy(V_6, L_23, SizeOf_TKey_t693D3BBF62B067F3D91C53F42FC97AB9D4C1FE69);
		NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51* L_24 = ___2_it;
		il2cpp_codegen_memcpy(L_25, il2cpp_codegen_get_instance_field_data_pointer(L_24, il2cpp_rgctx_field(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 11),0)), SizeOf_TKey_t693D3BBF62B067F3D91C53F42FC97AB9D4C1FE69);
		bool L_27;
		L_27 = ConstrainedFuncInvoker1< bool, Il2CppFullySharedGenericStruct >::Invoke(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 0), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 15), L_26, (void*)(Il2CppFullySharedGenericStruct*)V_6, L_25);
		V_5 = (bool)((((int32_t)L_27) == ((int32_t)0))? 1 : 0);
		bool L_28 = V_5;
		if (L_28)
		{
			goto IL_0045;
		}
	}
	{
		NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51* L_29 = ___2_it;
		int32_t* L_30 = V_1;
		int32_t L_31 = V_0;
		int32_t L_32 = (*(((int32_t*)il2cpp_codegen_add((intptr_t)L_30, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_31), 4))))));
		il2cpp_codegen_write_instance_field_data<int32_t>(L_29, il2cpp_rgctx_field(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 11),1), L_32);
		NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51* L_33 = ___2_it;
		int32_t L_34 = V_0;
		il2cpp_codegen_write_instance_field_data<int32_t>(L_33, il2cpp_rgctx_field(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 11),2), L_34);
		Il2CppFullySharedGenericStruct* L_35 = ___1_item;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_36 = ___0_data;
		NullCheck(L_36);
		uint8_t* L_37 = L_36->___values;
		int32_t L_38 = V_0;
		InvokerActionInvoker3< void*, int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 17)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 17), NULL, (void*)L_37, L_38, (Il2CppFullySharedGenericStruct*)L_39);
		il2cpp_codegen_memcpy((Il2CppFullySharedGenericStruct*)L_35, L_39, SizeOf_TValue_tB7B830249365402E1E7E370540F98F1B5A6B1DEC);
		Il2CppCodeGenWriteBarrierForClass(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 7), (void**)(Il2CppFullySharedGenericStruct*)L_35, (void*)L_39);
		V_3 = (bool)1;
		goto IL_00c1;
	}

IL_00c1:
	{
		bool L_40 = V_3;
		return L_40;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMapBase_2_SetValue_m557C0D5801C035501701C60FE81775298FDD76A5_gshared (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* ___0_data, NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51* ___1_it, Il2CppFullySharedGenericStruct* ___2_item, const RuntimeMethod* method) 
{
	const uint32_t SizeOf_TValue_tB7B830249365402E1E7E370540F98F1B5A6B1DEC = il2cpp_codegen_sizeof(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 7));
	const Il2CppFullySharedGenericStruct L_11 = alloca(SizeOf_TValue_tB7B830249365402E1E7E370540F98F1B5A6B1DEC);
	int32_t V_0 = 0;
	bool V_1 = false;
	bool V_2 = false;
	int32_t G_B3_0 = 0;
	{
		NativeParallelMultiHashMapIterator_1_t14002B1AC025FFFD512A35206135D18FEBAB0F51* L_0 = ___1_it;
		int32_t L_1 = *(int32_t*)il2cpp_codegen_get_instance_field_data_pointer(L_0, il2cpp_rgctx_field(il2cpp_rgctx_data_no_init(InitializedTypeInfo(method->klass)->rgctx_data, 11),2));
		V_0 = L_1;
		int32_t L_2 = V_0;
		if ((((int32_t)L_2) < ((int32_t)0)))
		{
			goto IL_001a;
		}
	}
	{
		int32_t L_3 = V_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = ___0_data;
		NullCheck(L_4);
		int32_t L_5 = L_4->___keyCapacity;
		G_B3_0 = ((((int32_t)((((int32_t)L_3) < ((int32_t)L_5))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_001b;
	}

IL_001a:
	{
		G_B3_0 = 1;
	}

IL_001b:
	{
		V_1 = (bool)G_B3_0;
		bool L_6 = V_1;
		if (!L_6)
		{
			goto IL_0024;
		}
	}
	{
		V_2 = (bool)0;
		goto IL_003b;
	}

IL_0024:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_7 = ___0_data;
		NullCheck(L_7);
		uint8_t* L_8 = L_7->___values;
		int32_t L_9 = V_0;
		Il2CppFullySharedGenericStruct* L_10 = ___2_item;
		il2cpp_codegen_memcpy(L_11, L_10, SizeOf_TValue_tB7B830249365402E1E7E370540F98F1B5A6B1DEC);
		InvokerActionInvoker3< void*, int32_t, Il2CppFullySharedGenericStruct >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8)), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 8), NULL, (void*)L_8, L_9, L_11);
		V_2 = (bool)1;
		goto IL_003b;
	}

IL_003b:
	{
		bool L_12 = V_2;
		return L_12;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMapDebuggerTypeProxy_2__ctor_m987AD575BFED1AEAD92F5DABF40893738C0F47A0_gshared (UnsafeParallelHashMapDebuggerTypeProxy_2_t4A34F2944E65F462B1CA05BC595902280B2A97F4* __this, UnsafeParallelHashMap_2_t05EF7F8F2EB540DAE81F93C169AC7E6849413707 ___0_target, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2((RuntimeObject*)__this, NULL);
		UnsafeParallelHashMap_2_t05EF7F8F2EB540DAE81F93C169AC7E6849413707 L_0 = ___0_target;
		__this->___m_Target = L_0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR List_1_t8F0684E22184B81BF891DD99A3E16491E68B58B5* UnsafeParallelHashMapDebuggerTypeProxy_2_get_Items_mFAF8210CCD89AD5741956F8C54BAA23928CF4408_gshared (UnsafeParallelHashMapDebuggerTypeProxy_2_t4A34F2944E65F462B1CA05BC595902280B2A97F4* __this, const RuntimeMethod* method) 
{
	const uint32_t SizeOf_TKey_t44117398A1D9630A91890738A6FCCB444D9B95A2 = il2cpp_codegen_sizeof(il2cpp_rgctx_data_no_init(method->klass->rgctx_data, 10));
	const uint32_t SizeOf_TValue_t74FDE0389DE830F671A9DB277C30F5627C793B29 = il2cpp_codegen_sizeof(il2cpp_rgctx_data_no_init(method->klass->rgctx_data, 14));
	const uint32_t SizeOf_Pair_2_t3327C6534A3F1B1221CAC8AA7FF74990B2FFC609 = il2cpp_codegen_sizeof(il2cpp_rgctx_data_no_init(method->klass->rgctx_data, 15));
	const Il2CppFullySharedGenericStruct L_8 = alloca(SizeOf_TKey_t44117398A1D9630A91890738A6FCCB444D9B95A2);
	const Il2CppFullySharedGenericStruct L_13 = alloca(SizeOf_TKey_t44117398A1D9630A91890738A6FCCB444D9B95A2);
	const Il2CppFullySharedGenericStruct L_12 = alloca(SizeOf_TValue_t74FDE0389DE830F671A9DB277C30F5627C793B29);
	const Il2CppFullySharedGenericStruct L_14 = alloca(SizeOf_TValue_t74FDE0389DE830F671A9DB277C30F5627C793B29);
	const Pair_2_tD9FD7901920962567EFA915194252C62C833F9F6 L_15 = alloca(SizeOf_Pair_2_t3327C6534A3F1B1221CAC8AA7FF74990B2FFC609);
	List_1_t8F0684E22184B81BF891DD99A3E16491E68B58B5* V_0 = NULL;
	NativeKeyValueArrays_2_t97DEBC72840B73CFCEE6195C4C495C675E96FAF1 V_1;
	memset((&V_1), 0, sizeof(V_1));
	int32_t V_2 = 0;
	NativeArray_1_tDB8B8DC66CC8E16ED6D9A8C75D2C1AFC80AC1E18 V_3;
	memset((&V_3), 0, sizeof(V_3));
	NativeArray_1_tDB8B8DC66CC8E16ED6D9A8C75D2C1AFC80AC1E18 V_4;
	memset((&V_4), 0, sizeof(V_4));
	bool V_5 = false;
	List_1_t8F0684E22184B81BF891DD99A3E16491E68B58B5* V_6 = NULL;
	{
		List_1_t8F0684E22184B81BF891DD99A3E16491E68B58B5* L_0 = (List_1_t8F0684E22184B81BF891DD99A3E16491E68B58B5*)il2cpp_codegen_object_new(il2cpp_rgctx_data(method->klass->rgctx_data, 2));
		((  void (*) (List_1_t8F0684E22184B81BF891DD99A3E16491E68B58B5*, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->klass->rgctx_data, 3)))(L_0, il2cpp_rgctx_method(method->klass->rgctx_data, 3));
		V_0 = L_0;
		UnsafeParallelHashMap_2_t05EF7F8F2EB540DAE81F93C169AC7E6849413707* L_1 = (UnsafeParallelHashMap_2_t05EF7F8F2EB540DAE81F93C169AC7E6849413707*)(&__this->___m_Target);
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_2;
		L_2 = AllocatorHandle_op_Implicit_mDCF4431F31BB4A09438AE644785C4273F86B2B8D((int32_t)2, NULL);
		NativeKeyValueArrays_2_t97DEBC72840B73CFCEE6195C4C495C675E96FAF1 L_3;
		L_3 = ((  NativeKeyValueArrays_2_t97DEBC72840B73CFCEE6195C4C495C675E96FAF1 (*) (UnsafeParallelHashMap_2_t05EF7F8F2EB540DAE81F93C169AC7E6849413707*, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->klass->rgctx_data, 4)))(L_1, L_2, il2cpp_rgctx_method(method->klass->rgctx_data, 4));
		V_1 = L_3;
	}
	{
		auto __finallyBlock = il2cpp::utils::Finally([&]
		{

FINALLY_0062:
			{
				NativeKeyValueArrays_2_Dispose_m08B6A4226A0125C6123942BE90703D08153CCE37((&V_1), il2cpp_rgctx_method(method->klass->rgctx_data, 20));
				return;
			}
		});
		try
		{
			{
				V_2 = 0;
				goto IL_004f_1;
			}

IL_001e_1:
			{
				List_1_t8F0684E22184B81BF891DD99A3E16491E68B58B5* L_4 = V_0;
				NativeKeyValueArrays_2_t97DEBC72840B73CFCEE6195C4C495C675E96FAF1 L_5 = V_1;
				NativeArray_1_tDB8B8DC66CC8E16ED6D9A8C75D2C1AFC80AC1E18 L_6 = L_5.___Keys;
				V_3 = L_6;
				int32_t L_7 = V_2;
				InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->klass->rgctx_data, 8)), il2cpp_rgctx_method(method->klass->rgctx_data, 8), (&V_3), L_7, (Il2CppFullySharedGenericStruct*)L_8);
				NativeKeyValueArrays_2_t97DEBC72840B73CFCEE6195C4C495C675E96FAF1 L_9 = V_1;
				NativeArray_1_tDB8B8DC66CC8E16ED6D9A8C75D2C1AFC80AC1E18 L_10 = L_9.___Values;
				V_4 = L_10;
				int32_t L_11 = V_2;
				InvokerActionInvoker2< int32_t, Il2CppFullySharedGenericStruct* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->klass->rgctx_data, 12)), il2cpp_rgctx_method(method->klass->rgctx_data, 12), (&V_4), L_11, (Il2CppFullySharedGenericStruct*)L_12);
				memset(L_15, 0, SizeOf_Pair_2_t3327C6534A3F1B1221CAC8AA7FF74990B2FFC609);
				Pair_2__ctor_m080327976BEF3D9FBA133845A20983F2462E1D6A((Pair_2_tD9FD7901920962567EFA915194252C62C833F9F6*)L_15, il2cpp_codegen_memcpy(L_13, L_8, SizeOf_TKey_t44117398A1D9630A91890738A6FCCB444D9B95A2), il2cpp_codegen_memcpy(L_14, L_12, SizeOf_TValue_t74FDE0389DE830F671A9DB277C30F5627C793B29), il2cpp_rgctx_method(method->klass->rgctx_data, 16));
				NullCheck(L_4);
				InvokerActionInvoker1< Pair_2_tD9FD7901920962567EFA915194252C62C833F9F6 >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->klass->rgctx_data, 17)), il2cpp_rgctx_method(method->klass->rgctx_data, 17), L_4, L_15);
				int32_t L_16 = V_2;
				V_2 = ((int32_t)il2cpp_codegen_add(L_16, 1));
			}

IL_004f_1:
			{
				int32_t L_17 = V_2;
				int32_t L_18;
				L_18 = ((  int32_t (*) (NativeKeyValueArrays_2_t97DEBC72840B73CFCEE6195C4C495C675E96FAF1*, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->klass->rgctx_data, 18)))((&V_1), il2cpp_rgctx_method(method->klass->rgctx_data, 18));
				V_5 = (bool)((((int32_t)L_17) < ((int32_t)L_18))? 1 : 0);
				bool L_19 = V_5;
				if (L_19)
				{
					goto IL_001e_1;
				}
			}
			{
				goto IL_0071;
			}
		}
		catch(Il2CppExceptionWrapper& e)
		{
			__finallyBlock.StoreException(e.ex);
		}
	}

IL_0071:
	{
		List_1_t8F0684E22184B81BF891DD99A3E16491E68B58B5* L_20 = V_0;
		V_6 = L_20;
		goto IL_0076;
	}

IL_0076:
	{
		List_1_t8F0684E22184B81BF891DD99A3E16491E68B58B5* L_21 = V_6;
		return L_21;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMap_2__ctor_mAC8F198D20B98C2819447D8E080EBF2F2714BFFE_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, int32_t ___0_capacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___1_allocator, const RuntimeMethod* method) 
{
	{
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_0 = ___1_allocator;
		__this->___m_AllocatorLabel = L_0;
		int32_t L_1 = ___0_capacity;
		int32_t L_2 = ___0_capacity;
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_3 = ___1_allocator;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926** L_4 = (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926**)(&__this->___m_Buffer);
		UnsafeParallelHashMapData_AllocateHashMap_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m720B963A1A8BA6E3EF6204599F7B1AE86C47B938(L_1, ((int32_t)il2cpp_codegen_multiply(L_2, 2)), L_3, L_4, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 1));
		UnsafeParallelHashMap_2_Clear_mC24DF6084AB7BA5AECAF2DFE3C8D80CD6EEE830C(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 2));
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeParallelHashMap_2__ctor_mAC8F198D20B98C2819447D8E080EBF2F2714BFFE_AdjustorThunk (RuntimeObject* __this, int32_t ___0_capacity, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___1_allocator, const RuntimeMethod* method)
{
	UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*>(__this + _offset);
	UnsafeParallelHashMap_2__ctor_mAC8F198D20B98C2819447D8E080EBF2F2714BFFE(_thisAdjusted, ___0_capacity, ___1_allocator, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMap_2_get_IsCreated_m21986D033E89DA3F44B7D0C5B99F57C93E9FBFCC_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method) 
{
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = __this->___m_Buffer;
		return (bool)((((int32_t)((((intptr_t)L_0) == ((intptr_t)((uintptr_t)0)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
	}
}
IL2CPP_EXTERN_C  bool UnsafeParallelHashMap_2_get_IsCreated_m21986D033E89DA3F44B7D0C5B99F57C93E9FBFCC_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*>(__this + _offset);
	bool _returnValue;
	_returnValue = UnsafeParallelHashMap_2_get_IsCreated_m21986D033E89DA3F44B7D0C5B99F57C93E9FBFCC_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMap_2_get_IsEmpty_m2EB3B4B325AAF39DA286FF82FDB26405AE271998_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method) 
{
	int32_t G_B3_0 = 0;
	{
		bool L_0;
		L_0 = UnsafeParallelHashMap_2_get_IsCreated_m21986D033E89DA3F44B7D0C5B99F57C93E9FBFCC_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 4));
		if (!L_0)
		{
			goto IL_0015;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_1 = __this->___m_Buffer;
		bool L_2;
		L_2 = UnsafeParallelHashMapData_IsEmpty_m24404CDC35842532023F9D7094DB24BCBD57EC9D(L_1, NULL);
		G_B3_0 = ((int32_t)(L_2));
		goto IL_0016;
	}

IL_0015:
	{
		G_B3_0 = 1;
	}

IL_0016:
	{
		return (bool)G_B3_0;
	}
}
IL2CPP_EXTERN_C  bool UnsafeParallelHashMap_2_get_IsEmpty_m2EB3B4B325AAF39DA286FF82FDB26405AE271998_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*>(__this + _offset);
	bool _returnValue;
	_returnValue = UnsafeParallelHashMap_2_get_IsEmpty_m2EB3B4B325AAF39DA286FF82FDB26405AE271998_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMap_2_Count_m3B17849FD6E9AEFC745138B43A5F5924BDA651A6_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method) 
{
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = __this->___m_Buffer;
		int32_t L_1;
		L_1 = UnsafeParallelHashMapData_GetCount_mF10300D8E62B36979B41F3CBE396D96721931D7B(L_0, NULL);
		return L_1;
	}
}
IL2CPP_EXTERN_C  int32_t UnsafeParallelHashMap_2_Count_m3B17849FD6E9AEFC745138B43A5F5924BDA651A6_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*>(__this + _offset);
	int32_t _returnValue;
	_returnValue = UnsafeParallelHashMap_2_Count_m3B17849FD6E9AEFC745138B43A5F5924BDA651A6(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMap_2_get_Capacity_m5516D69B8E5C8A61A3B8112E3B0C0DC701FDEF20_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method) 
{
	UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* V_0 = NULL;
	int32_t V_1 = 0;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = __this->___m_Buffer;
		V_0 = L_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_1 = V_0;
		NullCheck(L_1);
		int32_t L_2 = L_1->___keyCapacity;
		V_1 = L_2;
		goto IL_0011;
	}

IL_0011:
	{
		int32_t L_3 = V_1;
		return L_3;
	}
}
IL2CPP_EXTERN_C  int32_t UnsafeParallelHashMap_2_get_Capacity_m5516D69B8E5C8A61A3B8112E3B0C0DC701FDEF20_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*>(__this + _offset);
	int32_t _returnValue;
	_returnValue = UnsafeParallelHashMap_2_get_Capacity_m5516D69B8E5C8A61A3B8112E3B0C0DC701FDEF20_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMap_2_set_Capacity_mD1D227DF7720121254BBE5435F29C5CB94D97831_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, int32_t ___0_value, const RuntimeMethod* method) 
{
	UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* V_0 = NULL;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = __this->___m_Buffer;
		V_0 = L_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_1 = V_0;
		int32_t L_2 = ___0_value;
		int32_t L_3 = ___0_value;
		int32_t L_4;
		L_4 = UnsafeParallelHashMapData_GetBucketSize_mEF90FF75EFE70E4B59CD6AF9FDCB3D564A1986A3(L_3, NULL);
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_5 = __this->___m_AllocatorLabel;
		UnsafeParallelHashMapData_ReallocateHashMap_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m74D70D8E65D60A3A3B782011BC925E749F8C29C8(L_1, L_2, L_4, L_5, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 5));
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeParallelHashMap_2_set_Capacity_mD1D227DF7720121254BBE5435F29C5CB94D97831_AdjustorThunk (RuntimeObject* __this, int32_t ___0_value, const RuntimeMethod* method)
{
	UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*>(__this + _offset);
	UnsafeParallelHashMap_2_set_Capacity_mD1D227DF7720121254BBE5435F29C5CB94D97831(_thisAdjusted, ___0_value, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMap_2_Clear_mC24DF6084AB7BA5AECAF2DFE3C8D80CD6EEE830C_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method) 
{
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = __this->___m_Buffer;
		UnsafeParallelHashMapBase_2_Clear_mEFDB8CAFDB397D0E8A4279CA11C361A29EC8A4BB(L_0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 6));
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeParallelHashMap_2_Clear_mC24DF6084AB7BA5AECAF2DFE3C8D80CD6EEE830C_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*>(__this + _offset);
	UnsafeParallelHashMap_2_Clear_mC24DF6084AB7BA5AECAF2DFE3C8D80CD6EEE830C(_thisAdjusted, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMap_2_Remove_mE398837783AB4D7D5B1519D6B47F03F029B40A9A_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___0_key, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = __this->___m_Buffer;
		DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 L_1 = ___0_key;
		int32_t L_2;
		L_2 = UnsafeParallelHashMapBase_2_Remove_mD0A7EC52AF9067A81379B898E9F19FA26F3F4B88(L_0, L_1, (bool)0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 9));
		V_0 = (bool)((!(((uint32_t)L_2) <= ((uint32_t)0)))? 1 : 0);
		goto IL_0014;
	}

IL_0014:
	{
		bool L_3 = V_0;
		return L_3;
	}
}
IL2CPP_EXTERN_C  bool UnsafeParallelHashMap_2_Remove_mE398837783AB4D7D5B1519D6B47F03F029B40A9A_AdjustorThunk (RuntimeObject* __this, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___0_key, const RuntimeMethod* method)
{
	UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*>(__this + _offset);
	bool _returnValue;
	_returnValue = UnsafeParallelHashMap_2_Remove_mE398837783AB4D7D5B1519D6B47F03F029B40A9A(_thisAdjusted, ___0_key, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMap_2_TryGetValue_m6B967A3210A9091B292D0A38D4D8A190E5DC59A6_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___0_key, int32_t* ___1_item, const RuntimeMethod* method) 
{
	NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A V_0;
	memset((&V_0), 0, sizeof(V_0));
	bool V_1 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = __this->___m_Buffer;
		DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 L_1 = ___0_key;
		int32_t* L_2 = ___1_item;
		bool L_3;
		L_3 = UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mC42AE53B9C096C5437713AA40D89EB873678D78F(L_0, L_1, L_2, (&V_0), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 11));
		V_1 = L_3;
		goto IL_0013;
	}

IL_0013:
	{
		bool L_4 = V_1;
		return L_4;
	}
}
IL2CPP_EXTERN_C  bool UnsafeParallelHashMap_2_TryGetValue_m6B967A3210A9091B292D0A38D4D8A190E5DC59A6_AdjustorThunk (RuntimeObject* __this, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___0_key, int32_t* ___1_item, const RuntimeMethod* method)
{
	UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*>(__this + _offset);
	bool _returnValue;
	_returnValue = UnsafeParallelHashMap_2_TryGetValue_m6B967A3210A9091B292D0A38D4D8A190E5DC59A6(_thisAdjusted, ___0_key, ___1_item, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool UnsafeParallelHashMap_2_ContainsKey_mFBBB13C3C28724EEB5E77C8EBCF29B6EFEAE9C8C_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___0_key, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A V_1;
	memset((&V_1), 0, sizeof(V_1));
	bool V_2 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = __this->___m_Buffer;
		DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 L_1 = ___0_key;
		bool L_2;
		L_2 = UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mC42AE53B9C096C5437713AA40D89EB873678D78F(L_0, L_1, (&V_0), (&V_1), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 11));
		V_2 = L_2;
		goto IL_0014;
	}

IL_0014:
	{
		bool L_3 = V_2;
		return L_3;
	}
}
IL2CPP_EXTERN_C  bool UnsafeParallelHashMap_2_ContainsKey_mFBBB13C3C28724EEB5E77C8EBCF29B6EFEAE9C8C_AdjustorThunk (RuntimeObject* __this, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___0_key, const RuntimeMethod* method)
{
	UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*>(__this + _offset);
	bool _returnValue;
	_returnValue = UnsafeParallelHashMap_2_ContainsKey_mFBBB13C3C28724EEB5E77C8EBCF29B6EFEAE9C8C(_thisAdjusted, ___0_key, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMap_2_set_Item_m78B278F2F9ECFF6DD543068ED4A22897FFEA5017_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___0_key, int32_t ___1_value, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	NativeParallelMultiHashMapIterator_1_tD4CC3C20E6B2CD3C882DF9F7C39522544B32FE4A V_1;
	memset((&V_1), 0, sizeof(V_1));
	bool V_2 = false;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = __this->___m_Buffer;
		DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 L_1 = ___0_key;
		bool L_2;
		L_2 = UnsafeParallelHashMapBase_2_TryGetFirstValueAtomic_mC42AE53B9C096C5437713AA40D89EB873678D78F(L_0, L_1, (&V_0), (&V_1), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 11));
		V_2 = L_2;
		bool L_3 = V_2;
		if (!L_3)
		{
			goto IL_0029;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = __this->___m_Buffer;
		bool L_5;
		L_5 = UnsafeParallelHashMapBase_2_SetValue_mBC2EB4E62A5FAA365C4795E1D7FA3F3ED271F97A(L_4, (&V_1), (&___1_value), il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 15));
		goto IL_0040;
	}

IL_0029:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_6 = __this->___m_Buffer;
		DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 L_7 = ___0_key;
		int32_t L_8 = ___1_value;
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_9 = __this->___m_AllocatorLabel;
		bool L_10;
		L_10 = UnsafeParallelHashMapBase_2_TryAdd_m7575B5C2D0CB741CCB79BFF102B543F951D1A91A(L_6, L_7, L_8, (bool)0, L_9, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 16));
	}

IL_0040:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeParallelHashMap_2_set_Item_m78B278F2F9ECFF6DD543068ED4A22897FFEA5017_AdjustorThunk (RuntimeObject* __this, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___0_key, int32_t ___1_value, const RuntimeMethod* method)
{
	UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*>(__this + _offset);
	UnsafeParallelHashMap_2_set_Item_m78B278F2F9ECFF6DD543068ED4A22897FFEA5017(_thisAdjusted, ___0_key, ___1_value, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnsafeParallelHashMap_2_Dispose_m90F628584C865984113787BB0EC79383B00A069C_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		bool L_0;
		L_0 = UnsafeParallelHashMap_2_get_IsCreated_m21986D033E89DA3F44B7D0C5B99F57C93E9FBFCC_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 4));
		V_0 = (bool)((((int32_t)L_0) == ((int32_t)0))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0011;
		}
	}
	{
		goto IL_002b;
	}

IL_0011:
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_2 = __this->___m_Buffer;
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_3 = __this->___m_AllocatorLabel;
		UnsafeParallelHashMapData_DeallocateHashMap_m8D0FEE08B8522A1D05FBFFBBB43CB203304F114F(L_2, L_3, NULL);
		__this->___m_Buffer = (UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926*)((uintptr_t)0);
	}

IL_002b:
	{
		return;
	}
}
IL2CPP_EXTERN_C  void UnsafeParallelHashMap_2_Dispose_m90F628584C865984113787BB0EC79383B00A069C_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*>(__this + _offset);
	UnsafeParallelHashMap_2_Dispose_m90F628584C865984113787BB0EC79383B00A069C(_thisAdjusted, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NativeArray_1_t2FF0F1BBD323229A2F9ABD52397EA6EF9B105E09 UnsafeParallelHashMap_2_GetKeyArray_m0790F3B72CBA21D7B667E1A333E76DEAC8678138_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___0_allocator, const RuntimeMethod* method) 
{
	NativeArray_1_t2FF0F1BBD323229A2F9ABD52397EA6EF9B105E09 V_0;
	memset((&V_0), 0, sizeof(V_0));
	NativeArray_1_t2FF0F1BBD323229A2F9ABD52397EA6EF9B105E09 V_1;
	memset((&V_1), 0, sizeof(V_1));
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = __this->___m_Buffer;
		int32_t L_1;
		L_1 = UnsafeParallelHashMapData_GetCount_mF10300D8E62B36979B41F3CBE396D96721931D7B(L_0, NULL);
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_2 = ___0_allocator;
		NativeArray_1_t2FF0F1BBD323229A2F9ABD52397EA6EF9B105E09 L_3;
		L_3 = CollectionHelper_CreateNativeArray_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_mAF52A80BBB617F62596D58F8FFD9E3E6AA9DB60F(L_1, L_2, (int32_t)0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 17));
		V_0 = L_3;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = __this->___m_Buffer;
		NativeArray_1_t2FF0F1BBD323229A2F9ABD52397EA6EF9B105E09 L_5 = V_0;
		UnsafeParallelHashMapData_GetKeyArray_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_m49E855A91D083A54CFF44DEB13335123AD3C4001(L_4, L_5, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 19));
		NativeArray_1_t2FF0F1BBD323229A2F9ABD52397EA6EF9B105E09 L_6 = V_0;
		V_1 = L_6;
		goto IL_0025;
	}

IL_0025:
	{
		NativeArray_1_t2FF0F1BBD323229A2F9ABD52397EA6EF9B105E09 L_7 = V_1;
		return L_7;
	}
}
IL2CPP_EXTERN_C  NativeArray_1_t2FF0F1BBD323229A2F9ABD52397EA6EF9B105E09 UnsafeParallelHashMap_2_GetKeyArray_m0790F3B72CBA21D7B667E1A333E76DEAC8678138_AdjustorThunk (RuntimeObject* __this, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___0_allocator, const RuntimeMethod* method)
{
	UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*>(__this + _offset);
	NativeArray_1_t2FF0F1BBD323229A2F9ABD52397EA6EF9B105E09 _returnValue;
	_returnValue = UnsafeParallelHashMap_2_GetKeyArray_m0790F3B72CBA21D7B667E1A333E76DEAC8678138(_thisAdjusted, ___0_allocator, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C UnsafeParallelHashMap_2_GetValueArray_m28E06E6A40485B8C1E9CEB5D9AD5DCEB3FD937B7_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___0_allocator, const RuntimeMethod* method) 
{
	NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C V_0;
	memset((&V_0), 0, sizeof(V_0));
	NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C V_1;
	memset((&V_1), 0, sizeof(V_1));
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = __this->___m_Buffer;
		int32_t L_1;
		L_1 = UnsafeParallelHashMapData_GetCount_mF10300D8E62B36979B41F3CBE396D96721931D7B(L_0, NULL);
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_2 = ___0_allocator;
		NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C L_3;
		L_3 = CollectionHelper_CreateNativeArray_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m53D2BC04C5127B3B1163A395E36386918CACFE4B(L_1, L_2, (int32_t)0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 20));
		V_0 = L_3;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_4 = __this->___m_Buffer;
		NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C L_5 = V_0;
		UnsafeParallelHashMapData_GetValueArray_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m4769F528CC3AB04D768F83B2A2A016AE29C5F87E(L_4, L_5, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 22));
		NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C L_6 = V_0;
		V_1 = L_6;
		goto IL_0025;
	}

IL_0025:
	{
		NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C L_7 = V_1;
		return L_7;
	}
}
IL2CPP_EXTERN_C  NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C UnsafeParallelHashMap_2_GetValueArray_m28E06E6A40485B8C1E9CEB5D9AD5DCEB3FD937B7_AdjustorThunk (RuntimeObject* __this, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___0_allocator, const RuntimeMethod* method)
{
	UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*>(__this + _offset);
	NativeArray_1_tA833EB7E3E1C9AF82C37976AD964B8D4BAC38B2C _returnValue;
	_returnValue = UnsafeParallelHashMap_2_GetValueArray_m28E06E6A40485B8C1E9CEB5D9AD5DCEB3FD937B7(_thisAdjusted, ___0_allocator, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NativeKeyValueArrays_2_t6F346645686D9ED3DF9980242A60F6343D9BD346 UnsafeParallelHashMap_2_GetKeyValueArrays_mBAD0B630B8637FBD3415B9CA1EB4912C07A0183A_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___0_allocator, const RuntimeMethod* method) 
{
	NativeKeyValueArrays_2_t6F346645686D9ED3DF9980242A60F6343D9BD346 V_0;
	memset((&V_0), 0, sizeof(V_0));
	NativeKeyValueArrays_2_t6F346645686D9ED3DF9980242A60F6343D9BD346 V_1;
	memset((&V_1), 0, sizeof(V_1));
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = __this->___m_Buffer;
		int32_t L_1;
		L_1 = UnsafeParallelHashMapData_GetCount_mF10300D8E62B36979B41F3CBE396D96721931D7B(L_0, NULL);
		AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 L_2 = ___0_allocator;
		NativeKeyValueArrays_2__ctor_m5C1BD5C2D8BD4FE03EC32866EEDF2EBECAB7B7F3((&V_0), L_1, L_2, (int32_t)0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 23));
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_3 = __this->___m_Buffer;
		NativeKeyValueArrays_2_t6F346645686D9ED3DF9980242A60F6343D9BD346 L_4 = V_0;
		UnsafeParallelHashMapData_GetKeyValueArrays_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_mC3C2330139E264EC4EB952292BE242F6511CA8E6(L_3, L_4, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 25));
		NativeKeyValueArrays_2_t6F346645686D9ED3DF9980242A60F6343D9BD346 L_5 = V_0;
		V_1 = L_5;
		goto IL_0026;
	}

IL_0026:
	{
		NativeKeyValueArrays_2_t6F346645686D9ED3DF9980242A60F6343D9BD346 L_6 = V_1;
		return L_6;
	}
}
IL2CPP_EXTERN_C  NativeKeyValueArrays_2_t6F346645686D9ED3DF9980242A60F6343D9BD346 UnsafeParallelHashMap_2_GetKeyValueArrays_mBAD0B630B8637FBD3415B9CA1EB4912C07A0183A_AdjustorThunk (RuntimeObject* __this, AllocatorHandle_t3CA09720B1F89F91A8DDBA95E74C28A1EC3E3148 ___0_allocator, const RuntimeMethod* method)
{
	UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*>(__this + _offset);
	NativeKeyValueArrays_2_t6F346645686D9ED3DF9980242A60F6343D9BD346 _returnValue;
	_returnValue = UnsafeParallelHashMap_2_GetKeyValueArrays_mBAD0B630B8637FBD3415B9CA1EB4912C07A0183A(_thisAdjusted, ___0_allocator, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ParallelWriter_t725B9E76F960232582498637DEF16962C7959261 UnsafeParallelHashMap_2_AsParallelWriter_mBB99B9D2617627AD5097AA220071CE11F5F93C2D_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method) 
{
	ParallelWriter_t725B9E76F960232582498637DEF16962C7959261 V_0;
	memset((&V_0), 0, sizeof(V_0));
	ParallelWriter_t725B9E76F960232582498637DEF16962C7959261 V_1;
	memset((&V_1), 0, sizeof(V_1));
	{
		(&V_0)->___m_ThreadIndex = 0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = __this->___m_Buffer;
		(&V_0)->___m_Buffer = L_0;
		ParallelWriter_t725B9E76F960232582498637DEF16962C7959261 L_1 = V_0;
		V_1 = L_1;
		goto IL_001a;
	}

IL_001a:
	{
		ParallelWriter_t725B9E76F960232582498637DEF16962C7959261 L_2 = V_1;
		return L_2;
	}
}
IL2CPP_EXTERN_C  ParallelWriter_t725B9E76F960232582498637DEF16962C7959261 UnsafeParallelHashMap_2_AsParallelWriter_mBB99B9D2617627AD5097AA220071CE11F5F93C2D_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*>(__this + _offset);
	ParallelWriter_t725B9E76F960232582498637DEF16962C7959261 _returnValue;
	_returnValue = UnsafeParallelHashMap_2_AsParallelWriter_mBB99B9D2617627AD5097AA220071CE11F5F93C2D(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* UnsafeParallelHashMap_2_System_Collections_Generic_IEnumerableU3CUnity_Collections_LowLevel_Unsafe_KeyValueU3CTKeyU2CTValueU3EU3E_GetEnumerator_m22AAA28BF2A503A1A9ACC7D180DA65A1F2AA0A86_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method) 
{
	{
		NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8* L_0 = (NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8_il2cpp_TypeInfo_var)));
		NotImplementedException__ctor_mDAB47BC6BD0E342E8F2171E5CABE3E67EA049F1C(L_0, NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_0, method);
	}
}
IL2CPP_EXTERN_C  RuntimeObject* UnsafeParallelHashMap_2_System_Collections_Generic_IEnumerableU3CUnity_Collections_LowLevel_Unsafe_KeyValueU3CTKeyU2CTValueU3EU3E_GetEnumerator_m22AAA28BF2A503A1A9ACC7D180DA65A1F2AA0A86_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*>(__this + _offset);
	RuntimeObject* _returnValue;
	_returnValue = UnsafeParallelHashMap_2_System_Collections_Generic_IEnumerableU3CUnity_Collections_LowLevel_Unsafe_KeyValueU3CTKeyU2CTValueU3EU3E_GetEnumerator_m22AAA28BF2A503A1A9ACC7D180DA65A1F2AA0A86(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* UnsafeParallelHashMap_2_System_Collections_IEnumerable_GetEnumerator_m1F6D4EBACBE01E83D9F84CF51098880680AFA3B5_gshared (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method) 
{
	{
		NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8* L_0 = (NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotImplementedException_t6366FE4DCF15094C51F4833B91A2AE68D4DA90E8_il2cpp_TypeInfo_var)));
		NotImplementedException__ctor_mDAB47BC6BD0E342E8F2171E5CABE3E67EA049F1C(L_0, NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_0, method);
	}
}
IL2CPP_EXTERN_C  RuntimeObject* UnsafeParallelHashMap_2_System_Collections_IEnumerable_GetEnumerator_m1F6D4EBACBE01E83D9F84CF51098880680AFA3B5_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271*>(__this + _offset);
	RuntimeObject* _returnValue;
	_returnValue = UnsafeParallelHashMap_2_System_Collections_IEnumerable_GetEnumerator_m1F6D4EBACBE01E83D9F84CF51098880680AFA3B5(_thisAdjusted, method);
	return _returnValue;
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline (int32_t ___0_value, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		int32_t L_0 = ___0_value;
		V_0 = L_0;
		goto IL_0005;
	}

IL_0005:
	{
		int32_t L_1 = V_0;
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t math_max_m9083201D37A8ED0157B127B5878D9B7F3A2A40BE_inline (int32_t ___0_x, int32_t ___1_y, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t G_B3_0 = 0;
	{
		int32_t L_0 = ___0_x;
		int32_t L_1 = ___1_y;
		if ((((int32_t)L_0) > ((int32_t)L_1)))
		{
			goto IL_0008;
		}
	}
	{
		int32_t L_2 = ___1_y;
		G_B3_0 = L_2;
		goto IL_0009;
	}

IL_0008:
	{
		int32_t L_3 = ___0_x;
		G_B3_0 = L_3;
	}

IL_0009:
	{
		V_0 = G_B3_0;
		goto IL_000c;
	}

IL_000c:
	{
		int32_t L_4 = V_0;
		return L_4;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t math_min_m02D43DF516544C279AF660EA4731449C82991849_inline (int32_t ___0_x, int32_t ___1_y, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t G_B3_0 = 0;
	{
		int32_t L_0 = ___0_x;
		int32_t L_1 = ___1_y;
		if ((((int32_t)L_0) < ((int32_t)L_1)))
		{
			goto IL_0008;
		}
	}
	{
		int32_t L_2 = ___1_y;
		G_B3_0 = L_2;
		goto IL_0009;
	}

IL_0008:
	{
		int32_t L_3 = ___0_x;
		G_B3_0 = L_3;
	}

IL_0009:
	{
		V_0 = G_B3_0;
		goto IL_000c;
	}

IL_000c:
	{
		int32_t L_4 = V_0;
		return L_4;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t UnsafeList_1_get_Length_m2673797C6B1B5ED6A4C644298C555559E56C2682_gshared_inline (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___m_length;
		int32_t L_1;
		L_1 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_0, NULL);
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t UnsafeList_1_get_Capacity_mE66A788D02ACCA321ADEC1D5939D6A0CC38E4A59_gshared_inline (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___m_capacity;
		int32_t L_1;
		L_1 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_0, NULL);
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D UnsafeList_1_get_Item_mE621D922A067844ECFB3EC3FD5CAF0F18284C825_gshared_inline (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_index, const RuntimeMethod* method) 
{
	OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_0 = __this->___Ptr;
		int32_t L_1 = ___0_index;
		int32_t L_2;
		L_2 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_1, NULL);
		uint32_t L_3 = sizeof(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D);
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D L_4 = (*(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)((OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_2), (int32_t)L_3)))));
		V_0 = L_4;
		goto IL_001e;
	}

IL_001e:
	{
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D L_5 = V_0;
		return L_5;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeList_1_set_Item_m36035574C8D1A1555A348CD8F326A3FB2F57A28B_gshared_inline (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_index, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D ___1_value, const RuntimeMethod* method) 
{
	{
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_0 = __this->___Ptr;
		int32_t L_1 = ___0_index;
		int32_t L_2;
		L_2 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_1, NULL);
		uint32_t L_3 = sizeof(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D);
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D L_4 = ___1_value;
		*(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)((OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_2), (int32_t)L_3)))) = L_4;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* UnsafeList_1_ElementAt_mDD19B169590525B93B12C98E9AD8209253E9A14B_gshared_inline (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, int32_t ___0_index, const RuntimeMethod* method) 
{
	OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* V_0 = NULL;
	{
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_0 = __this->___Ptr;
		int32_t L_1 = ___0_index;
		int32_t L_2;
		L_2 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_1, NULL);
		uint32_t L_3 = sizeof(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D);
		V_0 = (OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)((OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_2), (int32_t)L_3))));
		goto IL_0019;
	}

IL_0019:
	{
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_4 = V_0;
		return L_4;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool UnsafeList_1_get_IsCreated_m51C65B44C2F88F5642E21BC850480BAEEA7EA65D_gshared_inline (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method) 
{
	{
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_0 = __this->___Ptr;
		return (bool)((((int32_t)((((intptr_t)L_0) == ((intptr_t)((uintptr_t)0)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool UnsafeList_1_get_IsEmpty_m923A6014BAA5DC0E86E533ACE70D5C441A3F37DD_gshared_inline (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, const RuntimeMethod* method) 
{
	int32_t G_B3_0 = 0;
	{
		bool L_0;
		L_0 = UnsafeList_1_get_IsCreated_m51C65B44C2F88F5642E21BC850480BAEEA7EA65D_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		if (!L_0)
		{
			goto IL_0013;
		}
	}
	{
		int32_t L_1 = __this->___m_length;
		G_B3_0 = ((((int32_t)L_1) == ((int32_t)0))? 1 : 0);
		goto IL_0014;
	}

IL_0013:
	{
		G_B3_0 = 1;
	}

IL_0014:
	{
		return (bool)G_B3_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeUtility_WriteArrayElement_TisOccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D_mFCD82994FD19F18D338DCAB93FEA4EA811589FC1_gshared_inline (void* ___0_destination, int32_t ___1_index, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D ___2_value, const RuntimeMethod* method) 
{
	{
		void* L_0 = ___0_destination;
		int32_t L_1 = ___1_index;
		uint32_t L_2 = sizeof(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D);
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D L_3 = ___2_value;
		*(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)((void*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)((int64_t)il2cpp_codegen_multiply(((int64_t)L_1), ((int64_t)((int32_t)L_2))))))) = L_3;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeList_1_AddNoResize_m4C7CDA5A177C8AAE7272628C31A4981DFC474F33_gshared_inline (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D ___0_value, const RuntimeMethod* method) 
{
	{
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_0 = __this->___Ptr;
		int32_t L_1 = __this->___m_length;
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D L_2 = ___0_value;
		UnsafeUtility_WriteArrayElement_TisOccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D_mFCD82994FD19F18D338DCAB93FEA4EA811589FC1_inline((void*)L_0, L_1, L_2, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 19));
		int32_t L_3 = __this->___m_length;
		__this->___m_length = ((int32_t)il2cpp_codegen_add(L_3, 1));
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeList_1_Add_m1821E69B90EE213D7B3B9509F69E635B52C61023_gshared_inline (UnsafeList_1_t32D453EB9CD75257217D0A2E7ACB98E0A23EA5AA* __this, OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* ___0_value, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	bool V_1 = false;
	{
		int32_t L_0 = __this->___m_length;
		V_0 = L_0;
		int32_t L_1 = __this->___m_length;
		int32_t L_2 = __this->___m_capacity;
		V_1 = (bool)((((int32_t)L_1) < ((int32_t)L_2))? 1 : 0);
		bool L_3 = V_1;
		if (!L_3)
		{
			goto IL_0046;
		}
	}
	{
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_4 = __this->___Ptr;
		int32_t L_5 = V_0;
		uint32_t L_6 = sizeof(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D);
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_7 = ___0_value;
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D L_8 = (*(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)L_7);
		*(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)((OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)il2cpp_codegen_add((intptr_t)L_4, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_5), (int32_t)L_6)))) = L_8;
		int32_t L_9 = __this->___m_length;
		__this->___m_length = ((int32_t)il2cpp_codegen_add(L_9, 1));
		goto IL_006c;
	}

IL_0046:
	{
		int32_t L_10 = V_0;
		UnsafeList_1_Resize_m89BDE747429473AE232DB084BC36EF48F3AB388D(__this, ((int32_t)il2cpp_codegen_add(L_10, 1)), (int32_t)0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 3));
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_11 = __this->___Ptr;
		int32_t L_12 = V_0;
		uint32_t L_13 = sizeof(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D);
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D* L_14 = ___0_value;
		OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D L_15 = (*(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)L_14);
		*(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)((OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D*)il2cpp_codegen_add((intptr_t)L_11, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_12), (int32_t)L_13)))) = L_15;
	}

IL_006c:
	{
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t UnsafeUtility_SizeOf_TisOccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D_m06F3769E28E215E9E08FE78C81E8E16F99336462_gshared_inline (const RuntimeMethod* method) 
{
	{
		uint32_t L_0 = sizeof(OccluderContextSlot_t963DBFFF1612E4108D0BEB42369F78758BE71D5D);
		return (int32_t)L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t UnsafeList_1_get_Length_m30C8B237736009EBD4E69E7D215B9650233D037C_gshared_inline (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___m_length;
		int32_t L_1;
		L_1 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_0, NULL);
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t UnsafeList_1_get_Capacity_mD86B514B3119D3E1A021A6CB23BE78590F5E486E_gshared_inline (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___m_capacity;
		int32_t L_1;
		L_1 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_0, NULL);
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A UnsafeList_1_get_Item_m5047BC7B1C0732A194FACD8C079EC28A64A5F79D_gshared_inline (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_index, const RuntimeMethod* method) 
{
	SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_0 = __this->___Ptr;
		int32_t L_1 = ___0_index;
		int32_t L_2;
		L_2 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_1, NULL);
		uint32_t L_3 = sizeof(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A);
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A L_4 = (*(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)((SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_2), (int32_t)L_3)))));
		V_0 = L_4;
		goto IL_001e;
	}

IL_001e:
	{
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A L_5 = V_0;
		return L_5;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeList_1_set_Item_m2D938DC73BF3B2D244FB9468EBECDFA52B986B7B_gshared_inline (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_index, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A ___1_value, const RuntimeMethod* method) 
{
	{
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_0 = __this->___Ptr;
		int32_t L_1 = ___0_index;
		int32_t L_2;
		L_2 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_1, NULL);
		uint32_t L_3 = sizeof(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A);
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A L_4 = ___1_value;
		*(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)((SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_2), (int32_t)L_3)))) = L_4;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* UnsafeList_1_ElementAt_m9B7ADAC368CB917E0318285D89CD070BFFC7E2F9_gshared_inline (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, int32_t ___0_index, const RuntimeMethod* method) 
{
	SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* V_0 = NULL;
	{
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_0 = __this->___Ptr;
		int32_t L_1 = ___0_index;
		int32_t L_2;
		L_2 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_1, NULL);
		uint32_t L_3 = sizeof(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A);
		V_0 = (SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)((SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_2), (int32_t)L_3))));
		goto IL_0019;
	}

IL_0019:
	{
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_4 = V_0;
		return L_4;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool UnsafeList_1_get_IsCreated_mB1B61C071EA40B095E886B5298E0C3C54ED9A853_gshared_inline (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method) 
{
	{
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_0 = __this->___Ptr;
		return (bool)((((int32_t)((((intptr_t)L_0) == ((intptr_t)((uintptr_t)0)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool UnsafeList_1_get_IsEmpty_mFB3CDB4407674F5F2A7D1859C9FB368CC9077F1A_gshared_inline (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, const RuntimeMethod* method) 
{
	int32_t G_B3_0 = 0;
	{
		bool L_0;
		L_0 = UnsafeList_1_get_IsCreated_mB1B61C071EA40B095E886B5298E0C3C54ED9A853_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		if (!L_0)
		{
			goto IL_0013;
		}
	}
	{
		int32_t L_1 = __this->___m_length;
		G_B3_0 = ((((int32_t)L_1) == ((int32_t)0))? 1 : 0);
		goto IL_0014;
	}

IL_0013:
	{
		G_B3_0 = 1;
	}

IL_0014:
	{
		return (bool)G_B3_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeUtility_WriteArrayElement_TisSplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A_m4F71D70C126C24C918F9E6237DC37C71726A6CE8_gshared_inline (void* ___0_destination, int32_t ___1_index, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A ___2_value, const RuntimeMethod* method) 
{
	{
		void* L_0 = ___0_destination;
		int32_t L_1 = ___1_index;
		uint32_t L_2 = sizeof(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A);
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A L_3 = ___2_value;
		*(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)((void*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)((int64_t)il2cpp_codegen_multiply(((int64_t)L_1), ((int64_t)((int32_t)L_2))))))) = L_3;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeList_1_AddNoResize_mDD1844EF5F4B0A230D4C6141E4A6A3EF83521A5C_gshared_inline (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A ___0_value, const RuntimeMethod* method) 
{
	{
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_0 = __this->___Ptr;
		int32_t L_1 = __this->___m_length;
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A L_2 = ___0_value;
		UnsafeUtility_WriteArrayElement_TisSplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A_m4F71D70C126C24C918F9E6237DC37C71726A6CE8_inline((void*)L_0, L_1, L_2, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 19));
		int32_t L_3 = __this->___m_length;
		__this->___m_length = ((int32_t)il2cpp_codegen_add(L_3, 1));
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeList_1_Add_mE02101A02348C4FE5C69658E032EB2BC5E2B0EC1_gshared_inline (UnsafeList_1_tB27AD3CB321614AC6FA21D53846794B77943121C* __this, SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* ___0_value, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	bool V_1 = false;
	{
		int32_t L_0 = __this->___m_length;
		V_0 = L_0;
		int32_t L_1 = __this->___m_length;
		int32_t L_2 = __this->___m_capacity;
		V_1 = (bool)((((int32_t)L_1) < ((int32_t)L_2))? 1 : 0);
		bool L_3 = V_1;
		if (!L_3)
		{
			goto IL_0046;
		}
	}
	{
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_4 = __this->___Ptr;
		int32_t L_5 = V_0;
		uint32_t L_6 = sizeof(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A);
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_7 = ___0_value;
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A L_8 = (*(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)L_7);
		*(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)((SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)il2cpp_codegen_add((intptr_t)L_4, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_5), (int32_t)L_6)))) = L_8;
		int32_t L_9 = __this->___m_length;
		__this->___m_length = ((int32_t)il2cpp_codegen_add(L_9, 1));
		goto IL_006c;
	}

IL_0046:
	{
		int32_t L_10 = V_0;
		UnsafeList_1_Resize_mF872E9A04824A2B9B2B673782565D043892D31D9(__this, ((int32_t)il2cpp_codegen_add(L_10, 1)), (int32_t)0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 3));
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_11 = __this->___Ptr;
		int32_t L_12 = V_0;
		uint32_t L_13 = sizeof(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A);
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A* L_14 = ___0_value;
		SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A L_15 = (*(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)L_14);
		*(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)((SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A*)il2cpp_codegen_add((intptr_t)L_11, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_12), (int32_t)L_13)))) = L_15;
	}

IL_006c:
	{
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t UnsafeUtility_SizeOf_TisSplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A_m6C96A05E2AC56907C62A2A917FE69A67EB3F72FB_gshared_inline (const RuntimeMethod* method) 
{
	{
		uint32_t L_0 = sizeof(SplitInfo_tBD1436BC99CBBC9658FA9219EB22657F757C4A1A);
		return (int32_t)L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t UnsafeList_1_get_Length_mFE9C02C4C7169AE23DE6BC1B834E0DBC1D03DBB1_gshared_inline (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___m_length;
		int32_t L_1;
		L_1 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_0, NULL);
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t UnsafeList_1_get_Capacity_m9C10840F54FD1F0871C1C7E25CE7AF92622DF9AD_gshared_inline (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___m_capacity;
		int32_t L_1;
		L_1 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_0, NULL);
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 UnsafeList_1_get_Item_mEFA75FB7304D5FFEA7E3F6226B01453D10013A3B_gshared_inline (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_index, const RuntimeMethod* method) 
{
	Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_0 = __this->___Ptr;
		int32_t L_1 = ___0_index;
		int32_t L_2;
		L_2 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_1, NULL);
		uint32_t L_3 = sizeof(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127);
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 L_4 = (*(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)((Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_2), (int32_t)L_3)))));
		V_0 = L_4;
		goto IL_001e;
	}

IL_001e:
	{
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 L_5 = V_0;
		return L_5;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeList_1_set_Item_m0B5139C9A3714A3C5E0B576AB276E1A0FCA406B9_gshared_inline (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_index, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 ___1_value, const RuntimeMethod* method) 
{
	{
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_0 = __this->___Ptr;
		int32_t L_1 = ___0_index;
		int32_t L_2;
		L_2 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_1, NULL);
		uint32_t L_3 = sizeof(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127);
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 L_4 = ___1_value;
		*(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)((Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_2), (int32_t)L_3)))) = L_4;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* UnsafeList_1_ElementAt_m43B542F9E0F11A380A8AC0435939688D55836A0D_gshared_inline (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, int32_t ___0_index, const RuntimeMethod* method) 
{
	Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* V_0 = NULL;
	{
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_0 = __this->___Ptr;
		int32_t L_1 = ___0_index;
		int32_t L_2;
		L_2 = CollectionHelper_AssumePositive_mD1EC1F05F50F605141D9BA5D70C4332AC902B4B1_inline(L_1, NULL);
		uint32_t L_3 = sizeof(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127);
		V_0 = (Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)((Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_2), (int32_t)L_3))));
		goto IL_0019;
	}

IL_0019:
	{
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_4 = V_0;
		return L_4;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool UnsafeList_1_get_IsCreated_m4B100662A0B454C46725BE8CEC4A746E61835062_gshared_inline (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method) 
{
	{
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_0 = __this->___Ptr;
		return (bool)((((int32_t)((((intptr_t)L_0) == ((intptr_t)((uintptr_t)0)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool UnsafeList_1_get_IsEmpty_m436BA19BA9C162ACC4DB0819037CBB975135A952_gshared_inline (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, const RuntimeMethod* method) 
{
	int32_t G_B3_0 = 0;
	{
		bool L_0;
		L_0 = UnsafeList_1_get_IsCreated_m4B100662A0B454C46725BE8CEC4A746E61835062_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 13));
		if (!L_0)
		{
			goto IL_0013;
		}
	}
	{
		int32_t L_1 = __this->___m_length;
		G_B3_0 = ((((int32_t)L_1) == ((int32_t)0))? 1 : 0);
		goto IL_0014;
	}

IL_0013:
	{
		G_B3_0 = 1;
	}

IL_0014:
	{
		return (bool)G_B3_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeUtility_WriteArrayElement_TisSlot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127_m4F77AC19B6051E7566C5A3561715FC4CB8D462AF_gshared_inline (void* ___0_destination, int32_t ___1_index, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 ___2_value, const RuntimeMethod* method) 
{
	{
		void* L_0 = ___0_destination;
		int32_t L_1 = ___1_index;
		uint32_t L_2 = sizeof(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127);
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 L_3 = ___2_value;
		*(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)((void*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)((int64_t)il2cpp_codegen_multiply(((int64_t)L_1), ((int64_t)((int32_t)L_2))))))) = L_3;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeList_1_AddNoResize_m884048B32C3E428BD16BB73C3162E27F1B3EF326_gshared_inline (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 ___0_value, const RuntimeMethod* method) 
{
	{
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_0 = __this->___Ptr;
		int32_t L_1 = __this->___m_length;
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 L_2 = ___0_value;
		UnsafeUtility_WriteArrayElement_TisSlot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127_m4F77AC19B6051E7566C5A3561715FC4CB8D462AF_inline((void*)L_0, L_1, L_2, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 19));
		int32_t L_3 = __this->___m_length;
		__this->___m_length = ((int32_t)il2cpp_codegen_add(L_3, 1));
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeList_1_Add_m405283315301E592556E27548D759262F9B0C52F_gshared_inline (UnsafeList_1_t5324648C0890229F0FE531FDD1C786CAEE3243D7* __this, Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* ___0_value, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	bool V_1 = false;
	{
		int32_t L_0 = __this->___m_length;
		V_0 = L_0;
		int32_t L_1 = __this->___m_length;
		int32_t L_2 = __this->___m_capacity;
		V_1 = (bool)((((int32_t)L_1) < ((int32_t)L_2))? 1 : 0);
		bool L_3 = V_1;
		if (!L_3)
		{
			goto IL_0046;
		}
	}
	{
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_4 = __this->___Ptr;
		int32_t L_5 = V_0;
		uint32_t L_6 = sizeof(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127);
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_7 = ___0_value;
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 L_8 = (*(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)L_7);
		*(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)((Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)il2cpp_codegen_add((intptr_t)L_4, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_5), (int32_t)L_6)))) = L_8;
		int32_t L_9 = __this->___m_length;
		__this->___m_length = ((int32_t)il2cpp_codegen_add(L_9, 1));
		goto IL_006c;
	}

IL_0046:
	{
		int32_t L_10 = V_0;
		UnsafeList_1_Resize_mA8E41BF0D06DD764B65618C554B138588019DCA9(__this, ((int32_t)il2cpp_codegen_add(L_10, 1)), (int32_t)0, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 3));
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_11 = __this->___Ptr;
		int32_t L_12 = V_0;
		uint32_t L_13 = sizeof(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127);
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127* L_14 = ___0_value;
		Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127 L_15 = (*(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)L_14);
		*(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)((Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127*)il2cpp_codegen_add((intptr_t)L_11, ((intptr_t)il2cpp_codegen_multiply(((intptr_t)L_12), (int32_t)L_13)))) = L_15;
	}

IL_006c:
	{
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t UnsafeUtility_SizeOf_TisSlot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127_m9A004D5E211035E85A1BBF1B521142792C4F0A57_gshared_inline (const RuntimeMethod* method) 
{
	{
		uint32_t L_0 = sizeof(Slot_tA2F29CF08EAE46C3E2B6D96DCD7C96BF887A6127);
		return (int32_t)L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeUtility_WriteArrayElement_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_mAC61BCD78DBCF3665AB62CF3F0A9160131582E7C_gshared_inline (void* ___0_destination, int32_t ___1_index, DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 ___2_value, const RuntimeMethod* method) 
{
	{
		void* L_0 = ___0_destination;
		int32_t L_1 = ___1_index;
		uint32_t L_2 = sizeof(DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94);
		DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 L_3 = ___2_value;
		*(DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94*)((void*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)((int64_t)il2cpp_codegen_multiply(((int64_t)L_1), ((int64_t)((int32_t)L_2))))))) = L_3;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeUtility_WriteArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m0DD1CC90B2F1EF5041F2F4E1DABB58224229F0D7_gshared_inline (void* ___0_destination, int32_t ___1_index, int32_t ___2_value, const RuntimeMethod* method) 
{
	{
		void* L_0 = ___0_destination;
		int32_t L_1 = ___1_index;
		uint32_t L_2 = sizeof(int32_t);
		int32_t L_3 = ___2_value;
		*(int32_t*)((void*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)((int64_t)il2cpp_codegen_multiply(((int64_t)L_1), ((int64_t)((int32_t)L_2))))))) = L_3;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 UnsafeUtility_ReadArrayElement_TisDrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94_mFD7DBC1199616005466125347027F6201459B40D_gshared_inline (void* ___0_source, int32_t ___1_index, const RuntimeMethod* method) 
{
	{
		void* L_0 = ___0_source;
		int32_t L_1 = ___1_index;
		uint32_t L_2 = sizeof(DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94);
		DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94 L_3 = (*(DrawKey_t3B4EE6E2AE19E9DD7C1731E60C6A7B39FEEA1C94*)((void*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)((int64_t)il2cpp_codegen_multiply(((int64_t)L_1), ((int64_t)((int32_t)L_2))))))));
		return L_3;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t UnsafeUtility_ReadArrayElement_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_mFBA66C06ECEB0A2BC1AAE634B6E6BB436F957084_gshared_inline (void* ___0_source, int32_t ___1_index, const RuntimeMethod* method) 
{
	{
		void* L_0 = ___0_source;
		int32_t L_1 = ___1_index;
		uint32_t L_2 = sizeof(int32_t);
		int32_t L_3 = (*(int32_t*)((void*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)((int64_t)il2cpp_codegen_multiply(((int64_t)L_1), ((int64_t)((int32_t)L_2))))))));
		return L_3;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeUtility_WriteArrayElement_TisBatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C_m32FE612078445C09645A5FEFCADD35BF1B5497D3_gshared_inline (void* ___0_destination, int32_t ___1_index, BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C ___2_value, const RuntimeMethod* method) 
{
	{
		void* L_0 = ___0_destination;
		int32_t L_1 = ___1_index;
		uint32_t L_2 = sizeof(BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C);
		BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C L_3 = ___2_value;
		*(BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C*)((void*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)((int64_t)il2cpp_codegen_multiply(((int64_t)L_1), ((int64_t)((int32_t)L_2))))))) = L_3;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C UnsafeUtility_ReadArrayElement_TisBatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C_mDE41FFE3160D153E47D8D93EF29E4B9C3DB23D20_gshared_inline (void* ___0_source, int32_t ___1_index, const RuntimeMethod* method) 
{
	{
		void* L_0 = ___0_source;
		int32_t L_1 = ___1_index;
		uint32_t L_2 = sizeof(BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C);
		BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C L_3 = (*(BatchMaterialID_tF9E95833BB1C35A6D14D47CF4EC8A6EB7D15D65C*)((void*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)((int64_t)il2cpp_codegen_multiply(((int64_t)L_1), ((int64_t)((int32_t)L_2))))))));
		return L_3;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeUtility_WriteArrayElement_TisBatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0_m0CA08285DF610E216621F21C754D8D5E56428B01_gshared_inline (void* ___0_destination, int32_t ___1_index, BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0 ___2_value, const RuntimeMethod* method) 
{
	{
		void* L_0 = ___0_destination;
		int32_t L_1 = ___1_index;
		uint32_t L_2 = sizeof(BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0);
		BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0 L_3 = ___2_value;
		*(BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0*)((void*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)((int64_t)il2cpp_codegen_multiply(((int64_t)L_1), ((int64_t)((int32_t)L_2))))))) = L_3;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0 UnsafeUtility_ReadArrayElement_TisBatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0_mD0CAE37D791EB711A170B7F9BDCEAB6ED472C3E3_gshared_inline (void* ___0_source, int32_t ___1_index, const RuntimeMethod* method) 
{
	{
		void* L_0 = ___0_source;
		int32_t L_1 = ___1_index;
		uint32_t L_2 = sizeof(BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0);
		BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0 L_3 = (*(BatchMeshID_t34167B7C1D0503C43A01A7BD213DFC367525D2A0*)((void*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)((int64_t)il2cpp_codegen_multiply(((int64_t)L_1), ((int64_t)((int32_t)L_2))))))));
		return L_3;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeUtility_WriteArrayElement_TisGPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78_mFC4E3A09D0F9A76B3DA65553F10F7EF785896EEA_gshared_inline (void* ___0_destination, int32_t ___1_index, GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78 ___2_value, const RuntimeMethod* method) 
{
	{
		void* L_0 = ___0_destination;
		int32_t L_1 = ___1_index;
		uint32_t L_2 = sizeof(GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78);
		GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78 L_3 = ___2_value;
		*(GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78*)((void*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)((int64_t)il2cpp_codegen_multiply(((int64_t)L_1), ((int64_t)((int32_t)L_2))))))) = L_3;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78 UnsafeUtility_ReadArrayElement_TisGPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78_mF42F014B5AA9C633D3FCAB3FFF26646E54395BD8_gshared_inline (void* ___0_source, int32_t ___1_index, const RuntimeMethod* method) 
{
	{
		void* L_0 = ___0_source;
		int32_t L_1 = ___1_index;
		uint32_t L_2 = sizeof(GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78);
		GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78 L_3 = (*(GPUInstanceIndex_t1B73FC29B273B0470A8E186E3C2F19CA6D8FBA78*)((void*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)((int64_t)il2cpp_codegen_multiply(((int64_t)L_1), ((int64_t)((int32_t)L_2))))))));
		return L_3;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeUtility_WriteArrayElement_TisInstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B_m2D4905CE9CCFB4EF383D04FA0F872F621E08A309_gshared_inline (void* ___0_destination, int32_t ___1_index, InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B ___2_value, const RuntimeMethod* method) 
{
	{
		void* L_0 = ___0_destination;
		int32_t L_1 = ___1_index;
		uint32_t L_2 = sizeof(InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B);
		InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B L_3 = ___2_value;
		*(InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B*)((void*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)((int64_t)il2cpp_codegen_multiply(((int64_t)L_1), ((int64_t)((int32_t)L_2))))))) = L_3;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B UnsafeUtility_ReadArrayElement_TisInstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B_m86FC76E325E9D3B56133BB7A193BAF12B47FBCC1_gshared_inline (void* ___0_source, int32_t ___1_index, const RuntimeMethod* method) 
{
	{
		void* L_0 = ___0_source;
		int32_t L_1 = ___1_index;
		uint32_t L_2 = sizeof(InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B);
		InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B L_3 = (*(InstanceHandle_tE8D892B001AFFDB8FA53EB19F2B356436AC36C3B*)((void*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)((int64_t)il2cpp_codegen_multiply(((int64_t)L_1), ((int64_t)((int32_t)L_2))))))));
		return L_3;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeUtility_WriteArrayElement_TisRangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C_m6E993EC5F50FC82EDD84AF158A50E9FF2BAE2705_gshared_inline (void* ___0_destination, int32_t ___1_index, RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C ___2_value, const RuntimeMethod* method) 
{
	{
		void* L_0 = ___0_destination;
		int32_t L_1 = ___1_index;
		uint32_t L_2 = sizeof(RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C);
		RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C L_3 = ___2_value;
		*(RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C*)((void*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)((int64_t)il2cpp_codegen_multiply(((int64_t)L_1), ((int64_t)((int32_t)L_2))))))) = L_3;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C UnsafeUtility_ReadArrayElement_TisRangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C_mFDF2C4591B5F4C0AF4424ED681225F9CF100C5BB_gshared_inline (void* ___0_source, int32_t ___1_index, const RuntimeMethod* method) 
{
	{
		void* L_0 = ___0_source;
		int32_t L_1 = ___1_index;
		uint32_t L_2 = sizeof(RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C);
		RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C L_3 = (*(RangeKey_t6D4869B364ADC52DCAE541898513EF33CEE8878C*)((void*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)((int64_t)il2cpp_codegen_multiply(((int64_t)L_1), ((int64_t)((int32_t)L_2))))))));
		return L_3;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeUtility_WriteArrayElement_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_m839FEB3192BEC0090FBA73A11E371E1A01C13ADF_gshared_inline (void* ___0_destination, int32_t ___1_index, uint32_t ___2_value, const RuntimeMethod* method) 
{
	{
		void* L_0 = ___0_destination;
		int32_t L_1 = ___1_index;
		uint32_t L_2 = sizeof(uint32_t);
		uint32_t L_3 = ___2_value;
		*(uint32_t*)((void*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)((int64_t)il2cpp_codegen_multiply(((int64_t)L_1), ((int64_t)((int32_t)L_2))))))) = L_3;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void UnsafeUtility_WriteArrayElement_TisBatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770_m60CD2C2DE2B559F255B8BEA36B0554E698FF9651_gshared_inline (void* ___0_destination, int32_t ___1_index, BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770 ___2_value, const RuntimeMethod* method) 
{
	{
		void* L_0 = ___0_destination;
		int32_t L_1 = ___1_index;
		uint32_t L_2 = sizeof(BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770);
		BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770 L_3 = ___2_value;
		*(BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770*)((void*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)((int64_t)il2cpp_codegen_multiply(((int64_t)L_1), ((int64_t)((int32_t)L_2))))))) = L_3;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint32_t UnsafeUtility_ReadArrayElement_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_mDA80BAFF55EA77496672B3B5B3804B55274B7E95_gshared_inline (void* ___0_source, int32_t ___1_index, const RuntimeMethod* method) 
{
	{
		void* L_0 = ___0_source;
		int32_t L_1 = ___1_index;
		uint32_t L_2 = sizeof(uint32_t);
		uint32_t L_3 = (*(uint32_t*)((void*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)((int64_t)il2cpp_codegen_multiply(((int64_t)L_1), ((int64_t)((int32_t)L_2))))))));
		return L_3;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770 UnsafeUtility_ReadArrayElement_TisBatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770_m80C61348EC8F9D4F73F0AAA4A69A028E6D599DCD_gshared_inline (void* ___0_source, int32_t ___1_index, const RuntimeMethod* method) 
{
	{
		void* L_0 = ___0_source;
		int32_t L_1 = ___1_index;
		uint32_t L_2 = sizeof(BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770);
		BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770 L_3 = (*(BatchID_t884E3C204D1F4C18FFD2361FC14A1E64CFBD8770*)((void*)il2cpp_codegen_add((intptr_t)L_0, ((intptr_t)((int64_t)il2cpp_codegen_multiply(((int64_t)L_1), ((int64_t)((int32_t)L_2))))))));
		return L_3;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool UnsafeParallelHashMap_2_get_IsCreated_m21986D033E89DA3F44B7D0C5B99F57C93E9FBFCC_gshared_inline (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method) 
{
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = __this->___m_Buffer;
		return (bool)((((int32_t)((((intptr_t)L_0) == ((intptr_t)((uintptr_t)0)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool UnsafeParallelHashMap_2_get_IsEmpty_m2EB3B4B325AAF39DA286FF82FDB26405AE271998_gshared_inline (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method) 
{
	int32_t G_B3_0 = 0;
	{
		bool L_0;
		L_0 = UnsafeParallelHashMap_2_get_IsCreated_m21986D033E89DA3F44B7D0C5B99F57C93E9FBFCC_inline(__this, il2cpp_rgctx_method(InitializedTypeInfo(method->klass)->rgctx_data, 4));
		if (!L_0)
		{
			goto IL_0015;
		}
	}
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_1 = __this->___m_Buffer;
		bool L_2;
		L_2 = UnsafeParallelHashMapData_IsEmpty_m24404CDC35842532023F9D7094DB24BCBD57EC9D(L_1, NULL);
		G_B3_0 = ((int32_t)(L_2));
		goto IL_0016;
	}

IL_0015:
	{
		G_B3_0 = 1;
	}

IL_0016:
	{
		return (bool)G_B3_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t UnsafeParallelHashMap_2_get_Capacity_m5516D69B8E5C8A61A3B8112E3B0C0DC701FDEF20_gshared_inline (UnsafeParallelHashMap_2_t16A91603015498C4CAFD401670CE1CDBBA245271* __this, const RuntimeMethod* method) 
{
	UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* V_0 = NULL;
	int32_t V_1 = 0;
	{
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_0 = __this->___m_Buffer;
		V_0 = L_0;
		UnsafeParallelHashMapData_t43CAB3170FBB624A9CCB6F30C0EC1BB820D57926* L_1 = V_0;
		NullCheck(L_1);
		int32_t L_2 = L_1->___keyCapacity;
		V_1 = L_2;
		goto IL_0011;
	}

IL_0011:
	{
		int32_t L_3 = V_1;
		return L_3;
	}
}
