using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cone : MonoBehaviour
{
    // Mesh
    Mesh _mesh;
    MeshRenderer _meshRenderer;

    //Vertices
    List<Vector3> _vertices;
    List<int> triangles;

    public Material material;

    // Cone Params
    public float height, radius;
    public int segments;

    Vector3 _position;

    float _angle = 0f, _angleAmount = 0f; 

    void Start()
    {
        // Init Mesh and Material
        gameObject.AddComponent<MeshFilter>();
        _meshRenderer = gameObject.AddComponent<MeshRenderer>();
        _meshRenderer.material = material;
        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;

        // Init veritices and angle position
        _vertices = new List<Vector3>();
        _position = new Vector3();

        _angleAmount = 2 * Mathf.PI / segments;
        _angle = 0f;

        // High center
        _position.x = 0f;
        _position.y = height;
        _position.z = 0f;
        _vertices.Add(new Vector3(_position.x, _position.y, _position.z));

        // Base center
        _position.y = 0f;
        _vertices.Add(new Vector3(_position.x, _position.y, _position.z));

        for (int i=0; i < segments; i++)
        {
            // Asign vertices
            _position.x = radius * Mathf.Sin(_angle);
            _position.z = radius * Mathf.Cos(_angle);

            _vertices.Add(new Vector3(_position.x, _position.y, _position.z));

            _angle -= _angleAmount;
        }

        // Asign verticves to mesh
        _mesh.vertices = _vertices.ToArray();

        // Init triangle list
        triangles = new List<int>();

        for (int i = 2; i < segments +1; i++)
        {
            triangles.Add(0);
            triangles.Add(i + 1);
            triangles.Add(i);
        }

        // Finish
        triangles.Add(0);
        triangles.Add(2);
        triangles.Add(segments + 1);

        _mesh.triangles = triangles.ToArray();
    }
}
