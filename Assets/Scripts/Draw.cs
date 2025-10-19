using UnityEngine;
public class Draw : MonoBehaviour
{
    /// <summary>
    /// This script needs to be attached to the camera
    /// </summary>
    
    public Transform canvas;

    public Texture2D texture;
    public float radius = 1.0f;
    public Color color;
    public bool reinitialize;
    void Update () 
    {
        if (reinitialize)
            ReinitializeCanvas(texture);
        if (Input.GetMouseButton(0))
            GetCoords();
    }

    public void ReinitializeCanvas(Texture2D texture)
    {
        texture.Reinitialize(texture.width, texture.height, TextureFormat.RGBA64, true);
        texture.Reinitialize(texture.width, texture.height, TextureFormat.RGBA32, true);
        texture.Apply();
        reinitialize = false;
    }

    void GetCoords()
    {
        RaycastHit hit;
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.name == canvas.name)
            {
                Renderer renderer = hit.transform.GetComponent<Renderer>();
                texture = (Texture2D)renderer.material.mainTexture;
                Vector2 UVcoord = hit.textureCoord;
                UVcoord.x *= texture.width;
                UVcoord.y *= texture.height;
                Debug.Log(UVcoord);
                DrawCircle(UVcoord, texture);
            }
        }
    }
    void DrawCircle(Vector2 origin, Texture2D texture)
    {
        for (float x = -radius; x <= radius; x++)
        {
            for (float y = -radius; y <= radius; y++)
            {
                if ((x * x) + (y * y) <= radius * radius)
                    texture.SetPixel((int)(origin.x + x), (int)(origin.y + y), color);
            }
        }
        texture.Apply();
    }
    
}
