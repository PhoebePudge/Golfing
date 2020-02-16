using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    [SerializeField] Texture2D Map;
    private Vector3[] vertices;
    private int[] triangles;
    private Mesh mesh;
    void Start(){
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        CreateTerrain();
        UpdateMesh();
    }
    private void CreateTerrain(){
        vertices = new Vector3[(Map.width + 1) * (Map.height + 1)];
        triangles = new int[Map.width * Map.height * 6];
        int vcounters = 0;
        int vertexcounter = 0;
        int trianglecount = 0;
        for (int i = 0; i < Map.width; i++){
            for (int j = 0; j < Map.height; j++){
                vertices[vcounters] = new Vector3(i, (float)Map.GetPixel(i, j).b, j);
                triangles[0 + trianglecount] = vertexcounter + 0;
                triangles[1 + trianglecount] = vertexcounter + 1;
                triangles[2 + trianglecount] = vertexcounter + 1;
                triangles[3 + trianglecount] = vertexcounter + 1;
                triangles[4 + trianglecount] = vertexcounter + 1;
                triangles[5 + trianglecount] = vertexcounter + 2;
                vcounters++;
                trianglecount += 6;
            }
            vertexcounter++;
        }
    }
    private void UpdateMesh(){
        mesh.Clear();
        mesh.vertices = vertices;
        Debug.Log(vertices.Length);
        mesh.triangles = triangles;
        Debug.Log(triangles.Length);
        mesh.RecalculateNormals();
    }
}
