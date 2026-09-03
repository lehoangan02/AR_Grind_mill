using System.Collections.Generic;
using UnityEngine;

namespace Khoa.Farming.Boating
{
    /// <summary>
    /// Bộ tạo mesh Xuồng Ba Lá Nam Bộ thủ công (tapered hull mesh).
    /// Đảm bảo tính độc lập 100% cho module Khoa, không phụ thuộc primitive hình khối thô.
    /// Gồm: Ván đáy thuôn nhọn 2 đầu, 2 be mạn cong vát xòe, be chắn mũi/lái và đòn ngồi.
    /// </summary>
    public static class SampanMeshGenerator
    {
        public static Mesh GenerateSampanHullMesh(float length = 3.6f, float width = 0.85f, float height = 0.42f)
        {
            Mesh mesh = new Mesh();
            mesh.name = "Sampan_BaLa_Hull_Mesh";

            List<Vector3> vertices = new List<Vector3>();
            List<int> triangles = new List<int>();
            List<Vector2> uvs = new List<Vector2>();
            List<Vector3> normals = new List<Vector3>();

            int segments = 12;
            float halfLen = length * 0.5f;

            // Xây dựng mặt cắt ngang dọc theo thân xuồng
            // Mỗi mặt cắt có: Đáy trái, Đáy phải, Mạn trái trên, Mạn phải trên
            for (int i = 0; i <= segments; i++)
            {
                float t = (float)i / segments;
                float z = Mathf.Lerp(-halfLen, halfLen, t);

                // Độ thuôn nhọn ở 2 đầu mũi và lái (parabol)
                float normZ = (z / halfLen); // -1 đến 1
                float taper = 1f - (normZ * normZ * 0.75f); // 1.0 ở giữa, ~0.25 ở 2 đầu mũi

                // Độ cong vểnh lên ở mũi và lái (sheer line)
                float sheer = (normZ * normZ) * 0.18f;

                float curWidthBottom = (width * 0.45f) * taper;
                float curWidthTop = (width * 0.5f) * taper;
                float curBottomY = sheer;
                float curTopY = sheer + height;

                // 4 đỉnh của mặt cắt:
                // 0: Mạn trái trên
                // 1: Đáy trái
                // 2: Đáy phải
                // 3: Mạn phải trên
                Vector3 pTopLeft = new Vector3(-curWidthTop, curTopY, z);
                Vector3 pBottomLeft = new Vector3(-curWidthBottom, curBottomY, z);
                Vector3 pBottomRight = new Vector3(curWidthBottom, curBottomY, z);
                Vector3 pTopRight = new Vector3(curWidthTop, curTopY, z);

                vertices.Add(pTopLeft);
                vertices.Add(pBottomLeft);
                vertices.Add(pBottomRight);
                vertices.Add(pTopRight);

                uvs.Add(new Vector2(0f, t));
                uvs.Add(new Vector2(0.35f, t));
                uvs.Add(new Vector2(0.65f, t));
                uvs.Add(new Vector2(1f, t));
            }

            // Nối tam giác (Triangles)
            for (int i = 0; i < segments; i++)
            {
                int r0 = i * 4;
                int r1 = (i + 1) * 4;

                // 1. Ván mạn trái (Left Flank)
                // r0+0 (TopL0), r0+1 (BotL0), r1+0 (TopL1), r1+1 (BotL1)
                AddQuad(triangles, r0 + 0, r1 + 0, r1 + 1, r0 + 1);

                // 2. Ván đáy thuyền (Bottom Plank)
                // r0+1 (BotL0), r0+2 (BotR0), r1+1 (BotL1), r1+2 (BotR1)
                AddQuad(triangles, r0 + 1, r1 + 1, r1 + 2, r0 + 2);

                // 3. Ván mạn phải (Right Flank)
                // r0+2 (BotR0), r0+3 (TopR0), r1+2 (BotR1), r1+3 (TopR1)
                AddQuad(triangles, r0 + 2, r1 + 2, r1 + 3, r0 + 3);
            }

            // Bịt 2 đầu mũi và lái
            // Đuôi thuyền (z = -halfLen)
            triangles.Add(0); triangles.Add(1); triangles.Add(2);
            triangles.Add(0); triangles.Add(2); triangles.Add(3);

            // Mũi thuyền (z = +halfLen)
            int lastRow = segments * 4;
            triangles.Add(lastRow + 2); triangles.Add(lastRow + 1); triangles.Add(lastRow + 0);
            triangles.Add(lastRow + 3); triangles.Add(lastRow + 2); triangles.Add(lastRow + 0);

            mesh.SetVertices(vertices);
            mesh.SetTriangles(triangles, 0);
            mesh.SetUVs(0, uvs);
            mesh.RecalculateNormals();
            mesh.RecalculateBounds();

            return mesh;
        }

        private static void AddQuad(List<int> tris, int v0, int v1, int v2, int v3)
        {
            tris.Add(v0);
            tris.Add(v1);
            tris.Add(v2);

            tris.Add(v0);
            tris.Add(v2);
            tris.Add(v3);
        }
    }
}
