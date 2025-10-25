using UnityEngine;

public class DirtMask : MonoBehaviour
{
    [SerializeField] protected UI_Manager uiManager;
    [SerializeField] protected Draw draw;
    [SerializeField] protected Material material;
    [SerializeField] protected Color color;
    [SerializeField] protected byte completeValue;
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
            Destroy(gameObject);
            draw.percentage = 0;
        }
    }
    protected void CheckIfCanDraw()
    {
        
        if (uiManager.selectedTool == requiredTool)
            draw.canDraw = true;
        else
            draw.canDraw = false;
    }
}
