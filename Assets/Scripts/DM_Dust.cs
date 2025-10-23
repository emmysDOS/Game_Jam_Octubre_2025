using UnityEngine;

public class DM_Dust : DirtMask
{
    private void Start()
    {
        base.Start();
    }
    private void Update()
    {
        CheckIfCanDraw();
        if (draw.canvas == gameObject.transform)
            HandleAliveTime();
    }
}
