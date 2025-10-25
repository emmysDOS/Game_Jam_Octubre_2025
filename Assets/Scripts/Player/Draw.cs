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
    public RaycastHit Hit;
    public bool canDraw;
    public float radius;
    
    private Texture2D _texture;
    private bool _reinitialize;
    
    //Percentage calculation
    public int percentage;
    private float _calculePercTimer = 3f;
    private bool _canCalculePercentage = true;
    void Update () 
    {
        if (_reinitialize)
            ReinitializeCanvas();
        if (inputManager.leftMouse)
        {
            if (_texture == null)
            {
                GetCoords();
                ReinitializeCanvas();
            }
            else
                GetCoords();
        }
        if (_canCalculePercentage)
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
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out Hit))
        {
            if (true)
            {
                canvas =  Hit.transform;
                Renderer rend = Hit.transform.GetComponent<Renderer>();
                _texture = (Texture2D)rend.material.mainTexture;
                Vector2 UVcoord = Hit.textureCoord;
                UVcoord.x *= _texture.width;
                UVcoord.y *= _texture.height;
                //Debug.Log(UVcoord);
                DrawCircle(UVcoord, _texture);
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
    public void ReinitializeCanvas()
    {
        _texture.Reinitialize(_texture.width, _texture.height, TextureFormat.RGBA32, true);
        _texture.Apply();
        GetPercentage();
        _reinitialize = false;
    }

    private void ManagePercTimer()
    {
        switch(percentage)
        {
            case 0:
                {
                    _calculePercTimer = .1f;//This was .2
                    ReinitializeCanvas();
                    break;
                }
            default:
                {
                    _calculePercTimer = 3;
                    break;
                }
        }
    }

    private void GetPercentage()
    {
        //Stopwatch s = Stopwatch.StartNew();
        int black = 0;
        int white = 0;
        Color32[] colors = _texture.GetPixels32();
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
        _canCalculePercentage = false;
        yield return new WaitForSeconds(_calculePercTimer);
        _canCalculePercentage = true;
    }
    
}
