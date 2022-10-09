using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Vector3 = UnityEngine.Vector3;

public class drawPlayer : MonoBehaviour
{
    Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;
    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    void Start()
    {
        DrawTriangle();
        CreateMesh();
    }

    void DrawTriangle()
    {
        vertices = new Vector3[] { new Vector3(0.3f,0.2f,0), new Vector3(0.3f,-0.2f,0), new Vector3(0,0,0) };
        triangles = new int[] {0, 1, 2};
    }

    void CreateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
}
