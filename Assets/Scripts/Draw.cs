using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Draw : MonoBehaviour
{
    /// <summary>
    /// This script needs to be attached to the camera
    /// </summary>

    [SerializeField] private Input_Manager inputManager;
    
    //Texture
    public Transform canvas;
    public Texture2D texture;
    public float radius;
    public bool reinitialize;
    
    //Percentage calculation
    public int percentage;
    public float calculePercTimer = 3f;
    [SerializeField] bool canCalculePercentage = true;
    void Update () 
    {
        if (reinitialize)
            ReinitializeCanvas(texture);
        if (Input.GetMouseButton(0))
        {
            if (texture == null)
            {
                GetCoords();
                ReinitializeCanvas(texture);
            }
            else
                GetCoords();
        }
        if (canCalculePercentage)
            StartCoroutine(GetPercentageRoutine());

        ManagePercTimer();

        if (inputManager.resetScene)
            ResetScene();
    }

    private static void ResetScene()
    {
        Scene currentSceme = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentSceme.name);
    }

    void GetCoords()
    {
        RaycastHit hit;
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (true)
            {
                canvas =  hit.transform;
                Renderer rend = hit.transform.GetComponent<Renderer>();
                texture = (Texture2D)rend.material.mainTexture;
                Vector2 UVcoord = hit.textureCoord;
                UVcoord.x *= texture.width;
                UVcoord.y *= texture.height;
                //Debug.Log(UVcoord);
                DrawCircle(UVcoord, texture);
            }
        }
    }
    void DrawCircle(Vector2 origin, Texture2D tex)
    {
        for (float x = -radius; x <= radius; x++)
        {
            for (float y = -radius; y <= radius; y++)
            {
                if ((x * x) + (y * y) <= radius * radius)
                    tex.SetPixel((int)(origin.x + x), (int)(origin.y + y), Color.clear);
            }
        }
        tex.Apply();
    }
    public void ReinitializeCanvas(Texture2D tex)
    {
        tex.Reinitialize(tex.width, tex.height, TextureFormat.RGBA32, true);
        tex.Apply();
        GetPercentage();
        reinitialize = false;
    }

    private void ManagePercTimer()
    {
        switch(percentage)
        {
            case 0:
                {
                    calculePercTimer = .2f;
                    ReinitializeCanvas(texture);
                    break;
                }
            default:
                {
                    calculePercTimer = 3;
                    break;
                }
        }
    }

    private void GetPercentage()
    {
        //Stopwatch s = Stopwatch.StartNew();
        int black = 0;
        int white = 0;
        Color32[] colors = texture.GetPixels32();
        for (int i = 0; i < colors.Length; i++)
        {
            switch (colors[i].r == 0)
            {
                case true:
                {
                    white++;
                    break;
                }
                default:
                {
                    black++;
                    break;
                }
            }
        }

        percentage = (white * 100) / colors.Length;
        //Debug.Log("S: " + s.ElapsedTicks);
        //Debug.Log("Black " + black);
        //Debug.Log("White: " + white);

        //calculate = false;
    }

    private IEnumerator GetPercentageRoutine()
    {
        GetPercentage();
        canCalculePercentage = false;
        yield return new WaitForSeconds(calculePercTimer);
        canCalculePercentage = true;
    }
    
    
}
