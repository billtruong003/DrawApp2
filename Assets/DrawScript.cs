using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawScript : MonoBehaviour
{
    public Material material;
    public Texture2D drawingTexture;
    public float brushSize = 0.1f;

    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;
    private Vector2[] uvs;
    private Color[] colors;
    private int vertexIndex;

    [SerializeField] private MeshRenderer meshRenderer;
    private Texture2D texture;
    private bool isDrawing = false;
    private Vector2 mousePosition;
    private Vector2 uv;
    public void Start()
    {
        // Create a new mesh
        mesh = new Mesh();
        mesh.name = "CustomMesh";

        // Get the MeshRenderer component
        meshRenderer = GetComponent<MeshRenderer>();

        // Create a new texture for drawing
        texture = new Texture2D(256, 256);
        texture.wrapMode = TextureWrapMode.Clamp;

        // Set the material's texture to the drawing texture
        material.SetTexture("_MainTex", texture);

        // Assign the mesh to the MeshFilter component
        GetComponent<MeshFilter>().mesh = mesh;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDrawing = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDrawing = false;
        }

        // Draw on the texture while mouse is being held down
        if (isDrawing)
        {
            // Convert mouse position to texture coordinates
            mousePosition = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);
            uv = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);

            // Draw on the texture
            DrawOnTexture(uv);
        }

        // Update the mesh with the modified texture
        UpdateMesh();
    }

    private void DrawOnTexture(Vector2 uv)
    {
        // Calculate pixel coordinates from UV coordinates
        int x = (int)((uv.x * texture.width) - 30);
        int y = (int)(uv.y * texture.height);

        // Set the pixel color at the specified coordinates
        texture.SetPixel(x, y, Color.black);

        // Apply changes to the texture
        texture.Apply();
    }

    public void UpdateMesh()
    {
        // Clear previous mesh data
        mesh.Clear();

        // Create arrays for vertices, triangles, uvs, and colors
        vertices = new Vector3[4];
        triangles = new int[6];
        uvs = new Vector2[4];
        colors = new Color[4];

        // Define vertices and UVs for a simple quad
        vertices[0] = new Vector3(-0.5f, 0, -0.5f);
        vertices[1] = new Vector3(-0.5f, 0, 0.5f);
        vertices[2] = new Vector3(0.5f, 0, -0.5f);
        vertices[3] = new Vector3(0.5f, 0, 0.5f);

        uvs[0] = new Vector2(0, 0);
        uvs[1] = new Vector2(0, 1);
        uvs[2] = new Vector2(1, 0);
        uvs[3] = new Vector2(1, 1);

        // Define triangles for the
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 2;
        triangles[4] = 1;
        triangles[5] = 3;

        // Set vertex colors
        Color color = Color.white;
        colors[0] = color;
        colors[1] = color;
        colors[2] = color;
        colors[3] = color;

        // Assign the arrays to the mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.colors = colors;

        // Recalculate the mesh bounds
        mesh.RecalculateBounds();

        // Update the MeshRenderer to use the updated mesh
        meshRenderer.sharedMaterial = material;
    }
}
