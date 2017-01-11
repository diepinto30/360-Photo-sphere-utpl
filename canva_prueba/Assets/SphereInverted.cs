using UnityEngine;
using System.Collections;

public class SphereInverted : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SetInvertedSphere(25.0f);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void SetInvertedSphere(float size)
    {
        GameObject go = GameObject.FindGameObjectsWithTag("Respawn")[0];
        MeshFilter mf = go.GetComponent<MeshFilter>();
        Mesh mesh = mf.sharedMesh;

        GameObject goNew = new GameObject();
        goNew.name = "Inverted Sphere";
        MeshFilter mfNew = goNew.AddComponent<MeshFilter>();
        mfNew.sharedMesh = new Mesh();


        //Scale the vertices;
        Vector3[] vertices = mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
            vertices[i] = vertices[i] * size;
        mfNew.sharedMesh.vertices = vertices;

        // Reverse the triangles
        int[] triangles = mesh.triangles;
        for (int i = 0; i < triangles.Length; i += 3)
        {
            int t = triangles[i];
            triangles[i] = triangles[i + 2];
            triangles[i + 2] = t;
        }
        mfNew.sharedMesh.triangles = triangles;

        // Reverse the normals;
        Vector3[] normals = mesh.normals;
        for (int i = 0; i < normals.Length; i++)
            normals[i] = -normals[i];
        mfNew.sharedMesh.normals = normals;


        mfNew.sharedMesh.uv = mesh.uv;
        mfNew.sharedMesh.uv2 = mesh.uv2;
        mfNew.sharedMesh.RecalculateBounds();


		//color

        // Add the same material that the original sphere used
        MeshRenderer mr = goNew.AddComponent<MeshRenderer>();
		// getcomponent working and changing the color the photo
		//gameObject.GetComponent<Renderer>().sharedMaterials[1].color = Color.blue;
       	mr.sharedMaterial = go.GetComponent<Renderer>().sharedMaterial;

        DestroyImmediate(go);
    }
}
