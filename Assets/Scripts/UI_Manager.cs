using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private Draw draw;
    [SerializeField] private Slider brushRadiusSlider;
    public void ReinitializeCanvas()
    {
       draw.ReinitializeCanvas(draw.texture);
    }

    public void SetDrawRadius()
    {
        draw.radius = brushRadiusSlider.value;
    }
}
