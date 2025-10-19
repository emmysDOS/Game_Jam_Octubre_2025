using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform canvas;
    public float radius = 1.0f;
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
                    UVcoord.x *= texture.width;
                    UVcoord.y *= texture.height;
                    Debug.Log(UVcoord);
                    drawCircle(UVcoord, texture);
                }
            }
        }
    }

    void drawCircle(Vector2 origin, Texture2D texture)
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
