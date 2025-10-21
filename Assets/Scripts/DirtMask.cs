using UnityEngine;

public class DirtMask : MonoBehaviour
{
    [SerializeField] protected Draw draw;
    [SerializeField] protected byte completeValue;
    [SerializeField] protected Material material;
    [SerializeField] protected Color color;
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
}
