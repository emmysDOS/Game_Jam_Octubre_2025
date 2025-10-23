using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private Draw draw;
    [SerializeField] private Slider brushRadiusSlider;
    [SerializeField] private TMP_Text perfentageText;
    [SerializeField] private TMP_Text selectedToolText;
    public byte selectedTool;
    public void ReinitializeCanvas()
    {
       draw.ReinitializeCanvas(draw.texture);
    }

    public void SetDrawRadius()
    {
        draw.radius = brushRadiusSlider.value;
    }
    public void setTool_0()
    {
        selectedTool = 0;
    }
    public void setTool_1()
    {
        selectedTool = 1;
    }
    private void Update()
    {
        perfentageText.text = draw.percentage.ToString() + "%";
        selectedToolText.text = "Selected Tool: " + selectedTool;
    }
}
