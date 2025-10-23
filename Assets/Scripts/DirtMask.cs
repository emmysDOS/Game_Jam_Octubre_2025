using UnityEngine;

public class DirtMask : MonoBehaviour
{
    [SerializeField] protected UI_Manager uiManager;
    [SerializeField] protected Input_Manager inputManager;
    [SerializeField] protected Draw draw;
    [SerializeField] protected byte completeValue;
    [SerializeField] protected Material material;
    [SerializeField] protected Color color;

    [SerializeField] protected byte requiredTool;
    protected void Start()
    {
        draw = FindAnyObjectByType<Draw>();
        gameObject.GetComponent<Renderer>().material = material;
        material.color = color;
    }
    protected void HandleAliveTime()
    {
        float percentage = draw.percentage;
        if (percentage >= completeValue)
        {
            gameObject.SetActive(false);
            draw.percentage = 0;
        }

    }
    protected void checkIfCanDraw()
    {
        byte uiTool = uiManager.selectedTool;
        if (uiTool == requiredTool)
            draw.canDraw = true;
        else
        {
            draw.canDraw = false;
            if (inputManager.leftMouse && draw.canvas == gameObject.transform && uiManager.selectedTool != requiredTool)
               uiManager.SendAlert("You need to use Tool " + requiredTool + " to clean this surface");

            else if (inputManager.leftMouse && uiManager.selectedTool == 0)
                uiManager.SendAlert("You need to choose a tool before");
            else if (uiManager.selectedTool != 0)
                uiManager.CloseAlert();

                
        }
    }
}
