using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private Input_Manager inputManager;
    [SerializeField] private Draw draw;
    [SerializeField] private Slider brushRadiusSlider;
    [SerializeField] private GameObject alertBox;
    [SerializeField] private TMP_Text alertText;
    [SerializeField] private TMP_Text percentageText;
    [SerializeField] private TMP_Text selectedToolText;
    public byte selectedTool;
    public void ReinitializeCanvas()
    {
       draw.ReinitializeCanvas();
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
    private string HandleToolSelected()
    {
        if (selectedTool != inputManager.HandleToolSelectionInput() && inputManager.HandleToolSelectionInput() != 9)
            selectedTool = inputManager.HandleToolSelectionInput();
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
        CloseAlert();
        alertText = alertBox.GetComponentInChildren<TMP_Text>();
    }
    private void Update()
    {
        HandleToolSelected();
        percentageText.text = draw.percentage.ToString() + "%";
        selectedToolText.text = "Selected tool: " + selectedTool;
        /*
        if (inputManager.leftMouse && !draw.canDraw && draw.Hit.transform.CompareTag("Mask"))
            SendAlert("You need to use another tool to clean this surface");
        else
            CloseAlert();
            */
    }

}
