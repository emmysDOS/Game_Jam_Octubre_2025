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
    [SerializeField] private GameObject bubble;
    [SerializeField] private PaintingsDB paintingsDB;
    private int completedCount;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private TMP_Text completedText;
    [SerializeField] private GameObject loadingIcon;
    [SerializeField] private bool loading;
    [SerializeField] private AudioManager3 audioManager3;
    [SerializeField] private GameObject controles;
    public bool painting;
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
        HandleCompletedCount();
        HandleLoadingIcon();
        HandleControles();
        percentageText.text = draw.percentage.ToString() + "%";
        selectedToolText.text = "Selected tool: " + selectedTool;
        completedText.text = "Completados: " + completedCount.ToString();
    }
    private void HandleCompletedCount()
    {
        int count = 0;
        for (int i = 0; i < paintingsDB.completed.Length; i++)
        {
            if (paintingsDB.completed[i] == true)
                count++;
        }
        completedCount = count;
    }

    public void SendBubble(string message)
    {
        bubble.SetActive(true);
        bubble.GetComponentInChildren<TMP_Text>().text = message;
    }
    private void HandleLoadingIcon()
    {
        loading = (draw.percentage == 0 && inputManager.leftMouse && playerController.paintingSelected);

        loadingIcon.SetActive(loading);

        painting = (draw.percentage > 0 && inputManager.leftMouse && playerController.paintingSelected);
    }
    private void HandleControles()
    {
        if (playerController.paintingSelected)
            controles.SetActive(false);
    }

    public void CloseBubble()
    {

        audioManager3.PlaySound();
        bubble.SetActive(false);
    }

}
