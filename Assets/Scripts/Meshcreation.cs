using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Meshcreation : MonoBehaviour
{
    Mesh mesh;
    //Vertices
    Vector3[] vertices;

    //Triangles
    int[] triangles;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        generatemesh();
        updatemesh();
    }
    void generatemesh()
    {
        //declare vertices
        vertices = new Vector3[]
        {
            new Vector3 (0,0,0),
            new Vector3 (0,0,1),
            new Vector3 (1,0,0)
        };

        triangles = new int[]
        {
            0,1,2
        };
    }

    void updatemesh()
    {
        //clear mesh data first
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }

   

}
