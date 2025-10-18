using Unity.VisualScripting;
using UnityEngine;

public class Clean : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Texture2D _dirtMaskBase;
    [SerializeField] private Texture2D _brush;
    [SerializeField] private Material _material;
    Color[] originalPixels;

    private Texture2D _templateDirtMask;
    private Vector2 _lastMousePos;
    private Vector2? _lastBrushUV = null;
    [SerializeField] private bool _isCleaning = false;

    //[SerializeField] private Vector2[] coords;
    public int index;


    private void Start()
    {
        CreateTexture();
        //coords = new Vector2[10];
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (!_isCleaning)
            {
                _isCleaning = true;
            }

            CleanSurface();
        }
        else
        {
            _isCleaning = false;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            float cleaned = GetCleanPercentage();
            Debug.Log($"Cleaned: {cleaned:F2}%");
        }
    }

    private void CleanSurface()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector2 textureCoord = hit.textureCoord;



            Debug.Log("Texture Coord:" + textureCoord);

            // Convert texture coordinates to pixel space
            int pixelX = Mathf.FloorToInt(textureCoord.x * _templateDirtMask.width);
            int pixelY = Mathf.FloorToInt(textureCoord.y * _templateDirtMask.height);

            // Make sure brush is within bounds
            for (int x = 0; x < _brush.width; x++)
            {
                for (int y = 0; y < _brush.height; y++)
                {
                    int brushPixelX = pixelX + x - _brush.width / 2;
                    int brushPixelY = pixelY + y - _brush.height / 2;

                    // Ensure we don't go out of bounds
                    if (brushPixelX >= 0 && brushPixelX < _templateDirtMask.width && brushPixelY >= 0 && brushPixelY < _templateDirtMask.height)
                    {
                        Color brushPixel = _brush.GetPixel(x, y);
                        Color dirtPixel = _templateDirtMask.GetPixel(brushPixelX, brushPixelY);

                        // Blend brush color with dirt mask (cleaning effect)
                        Color newDirtPixel = Color.Lerp(dirtPixel, Color.clear, brushPixel.a); // Modify this as needed
                        _templateDirtMask.SetPixel(brushPixelX, brushPixelY, newDirtPixel);
                    }
                }
            }

            // Apply changes to texture only when there are changes
            if (_isCleaning)
            {
                _templateDirtMask.Apply();
               // if (textureCoord != )
                index++;
            }
        }
    }
    public float GetCleanPercentage()
    {
        Color[] originalPixels = _dirtMaskBase.GetPixels();
        Color[] currentPixels = _templateDirtMask.GetPixels();

        int totalPixels = originalPixels.Length;
        int cleanPixels = 0;

        for (int i = 0; i < totalPixels; i++)
        {
            float originalGreen = originalPixels[i].g;
            float currentGreen = currentPixels[i].g;

            // If current green is significantly lower than the original, it's cleaner
            if (currentGreen < originalGreen * 0.9f) // or set your own threshold
            {
                cleanPixels++;
            }
        }

        float cleanPercent = (float)cleanPixels / totalPixels;
        return cleanPercent * 100f;
    }

    private void CreateTexture()
    {
        _templateDirtMask = new Texture2D(_dirtMaskBase.width, _dirtMaskBase.height);
        _templateDirtMask.SetPixels(_dirtMaskBase.GetPixels());
        _templateDirtMask.Apply();

        // Set texture on material
        _material.SetTexture("_DirtTexture", _templateDirtMask);  // Ensure the shader uses the correct property name
        Debug.Log("Dirt texture applied to material.");
    }
}
