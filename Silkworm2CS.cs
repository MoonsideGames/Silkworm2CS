/* Silkworm2CS - C# bindings for the Silkworm2 cloth physics library
 *
 * Copyright (c) 2022 Evan Hemsley
 *
 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the authors be held liable for any damages arising from
 * the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 * claim that you wrote the original software. If you use this software in a
 * product, an acknowledgment in the product documentation would be
 * appreciated but is not required.
 *
 * 2. Altered source versions must be plainly marked as such, and must not be
 * misrepresented as being the original software.
 *
 * 3. This notice may not be removed or altered from any source distribution.
 *
 * Evan "cosmonaut" Hemsley <evan@moonside.games>
 *
 */

using System;
using System.Runtime.InteropServices;

namespace Silkworm2CS
{
	public static class Silkworm2
	{
		private const string nativeLibName = "Silkworm2";

		public const uint SILKWORM2_MAJOR_VERSION = 0;
		public const uint SILKWORM2_MINOR_VERSION = 1;
		public const uint SILKWORM2_PATCH_VERSION = 0;

		[StructLayout(LayoutKind.Sequential)]
		public struct NodeCreateInfo
		{
			int X;
			int Y;
			float Mass;
			float Friction;
			float Radius;
			bool Pinned;
			float PushFactor;
			float WindFactor;
			bool Destroyable;
		};

		[StructLayout(LayoutKind.Sequential)]
		public struct ClothCreateInfo
		{
			int X;
			int Y;
			int HorizontalNodeCount;
			int VerticalNodeCount;
			float Mass;
			float Friction;
			float WindFactor;
			float TearThreshold;
		};

		[StructLayout(LayoutKind.Sequential)]
		public struct Vertex
		{
			float X;
			float Y;
			float Z;
			float U;
			float V;
		}

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void Silkworm_Init();

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void Silkworm_Update(
			float delta,
			float windSpeedX,
			float windSpeedY
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern IntPtr Silkworm_CreateNode(NodeCreateInfo* nodeCreateInfo);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void Silkworm_DestroyNode(IntPtr nodePtr);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr Silkworm_CreateLink(
			IntPtr nodeA,
			IntPtr nodeB,
			float distance,
			float tearThreshold
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern IntPtr Silkworm_ClothCreate(ClothCreateInfo* clothCreateInfo);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern void Silkworm_ClothNodePin(IntPtr clothPtr, uint i, uint j);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern void Silkworm_ClothNodeUnpin(IntPtr clothPtr, uint i, uint j);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern void Silkworm_ClothNodeDestroy(IntPtr clothPtr, uint i, uint j);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern int Silkworm_ClothFillTriangleBuffer(
			IntPtr clothPtr,
			IntPtr vertexBufferPtr,
			float depth,
			float leftUV,
			float widthUV,
			float topUV,
			float heightUV
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern void Silkworm_ClothDestroy(IntPtr clothPtr);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern void Silkworm_PinNodesInRadius(float x, float y, float radius);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern void Silkworm_UnpinNodesInRadius(float x, float y, float radius);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern void Silkworm_PushNodesInRadius(
			float x,
			float y,
			float radius,
			float xDirection,
			float yDirection
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern void Silkworm_DestroyNodesInRadius(float x, float y, float radius);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern IntPtr Silkworm_FindClothInRadius(float x, float y, float radius);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern void Silkworm_PerformDestroys();

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern void Silkworm_ClearAll();

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern void Silkworm_Finish();
	}
}
