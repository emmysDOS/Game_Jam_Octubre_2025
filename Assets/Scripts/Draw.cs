using UnityEngine;
public class Draw : MonoBehaviour
{
    /// <summary>
    /// This script needs to be attached to the camera
    /// </summary>
    
    public Transform canvas;
    public float radius = 1.0f;
    public bool reinitialize;
    void Update () 
    {
        

        
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == canvas.name)
                {
                    Renderer renderer = hit.transform.GetComponent<Renderer>();
                    Texture2D texture = (Texture2D)renderer.material.mainTexture;
                    Vector2 UVcoord = hit.textureCoord;
                    if (reinitialize)
                    {
                        texture.Reinitialize(texture.width, texture.height, TextureFormat.RGBA64, true);
                        texture.Reinitialize(texture.width, texture.height, TextureFormat.RGBA32, true);
                        
                        Debug.Log("Reinitialized");
                    }
                    UVcoord.x *= texture.width;
                    UVcoord.y *= texture.height;
                    Debug.Log(UVcoord);
                    DrawCircle(UVcoord, texture);

                    

                }
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
                    texture.SetPixel((int)(origin.x + x), (int)(origin.y + y), Color.black);
            }
        }
        texture.Apply();
    }
}
