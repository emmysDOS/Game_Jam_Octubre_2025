using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private Draw draw;
    [SerializeField] private Slider brushRadiusSlider;
    [SerializeField] private TMP_Text perfentageText;
    public void ReinitializeCanvas()
    {
       draw.ReinitializeCanvas(draw.texture);
    }

    public void SetDrawRadius()
    {
        draw.radius = brushRadiusSlider.value;
    }

    private void Update()
    {
        perfentageText.text = draw.percentage.ToString() + "%";
    }
}
