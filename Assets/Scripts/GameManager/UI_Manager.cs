using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private Draw draw;
    [SerializeField] private Slider brushRadiusSlider;
    [SerializeField] private TMP_Text perfentageText;
    [SerializeField] private TMP_Text selectedToolText;
    [SerializeField] private GameObject alertBox;
    [SerializeField] private TMP_Text alertText;
    public byte selectedTool;
    public void ReinitializeCanvas()
    {
       draw.ReinitializeCanvas(draw.texture);
    }

    public void SetDrawRadius()
    {
        draw.radius = brushRadiusSlider.value;
    }
    public void SetTool_0()
    {
        selectedTool = 0;
    }
    public void SetTool_1()
    {
        selectedTool = 1;
    }
    public void SetTool_2()
    {
        selectedTool = 2;
    }
    private string HandleToolSelected(byte selectedTool)
    {
        switch (selectedTool)
        {
            case 0:
                    return "Selected Tool: None";
            default:
                    return "Selected Tool" + selectedTool;
        }
    }    
    public void SendAlert(string message)
    {
        alertBox.SetActive(true);
        alertText.text = message;
    }
    public void CloseAlert()
    {
        alertBox.SetActive(false);
    }
    private void Start()
    {
        alertBox.SetActive (false);
        alertText = alertBox.GetComponentInChildren<TMP_Text>();
    }
    private void Update()
    {
        perfentageText.text = draw.percentage.ToString() + "%";
        selectedToolText.text = HandleToolSelected(selectedTool);
    }

}
