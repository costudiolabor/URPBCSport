#include "pch-c.h"
#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include "codegen/il2cpp-codegen-metadata.h"





// 0x00000001 System.Void Microsoft.CodeAnalysis.EmbeddedAttribute::.ctor()
extern void EmbeddedAttribute__ctor_m628CC67654B75C0712A2654E359B2A57C3A308F2 (void);
// 0x00000002 System.Void System.Runtime.CompilerServices.IsReadOnlyAttribute::.ctor()
extern void IsReadOnlyAttribute__ctor_mE253E2A5CFC2D82EB182AC5A7F4691501F8A4D00 (void);
// 0x00000003 UnityEngine.SphereCollider UnityEngine.ClothSphereColliderPair::get_first()
extern void ClothSphereColliderPair_get_first_m946C5B40948A5D91176D9498D36F160FC8CBA69D (void);
// 0x00000004 System.Void UnityEngine.ClothSphereColliderPair::set_first(UnityEngine.SphereCollider)
extern void ClothSphereColliderPair_set_first_m0A1B7959D953AE101AFE5E2D05816A00AD3FE75E (void);
// 0x00000005 System.Void UnityEngine.Cloth::set_sphereColliders(UnityEngine.ClothSphereColliderPair[])
extern void Cloth_set_sphereColliders_m1B3D44590D44B6C0666614AFB1C3EAB694BCA468 (void);
static Il2CppMethodPointer s_methodPointers[5] = 
{
	EmbeddedAttribute__ctor_m628CC67654B75C0712A2654E359B2A57C3A308F2,
	IsReadOnlyAttribute__ctor_mE253E2A5CFC2D82EB182AC5A7F4691501F8A4D00,
	ClothSphereColliderPair_get_first_m946C5B40948A5D91176D9498D36F160FC8CBA69D,
	ClothSphereColliderPair_set_first_m0A1B7959D953AE101AFE5E2D05816A00AD3FE75E,
	Cloth_set_sphereColliders_m1B3D44590D44B6C0666614AFB1C3EAB694BCA468,
};
extern void ClothSphereColliderPair_get_first_m946C5B40948A5D91176D9498D36F160FC8CBA69D_AdjustorThunk (void);
extern void ClothSphereColliderPair_set_first_m0A1B7959D953AE101AFE5E2D05816A00AD3FE75E_AdjustorThunk (void);
static Il2CppTokenAdjustorThunkPair s_adjustorThunks[2] = 
{
	{ 0x06000003, ClothSphereColliderPair_get_first_m946C5B40948A5D91176D9498D36F160FC8CBA69D_AdjustorThunk },
	{ 0x06000004, ClothSphereColliderPair_set_first_m0A1B7959D953AE101AFE5E2D05816A00AD3FE75E_AdjustorThunk },
};
static const int32_t s_InvokerIndices[5] = 
{
	7541,
	7541,
	7408,
	5957,
	5957,
};
IL2CPP_EXTERN_C const Il2CppCodeGenModule g_UnityEngine_ClothModule_CodeGenModule;
const Il2CppCodeGenModule g_UnityEngine_ClothModule_CodeGenModule = 
{
	"UnityEngine.ClothModule.dll",
	5,
	s_methodPointers,
	2,
	s_adjustorThunks,
	s_InvokerIndices,
	0,
	NULL,
	0,
	NULL,
	0,
	NULL,
	NULL,
	NULL, // module initializer,
	NULL,
	NULL,
	NULL,
};
