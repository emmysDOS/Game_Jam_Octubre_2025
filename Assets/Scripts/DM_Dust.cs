using UnityEngine;

public class DM_Dust : DirtMask
{
    private void Start()
    {
        base.Start();
        //Debug.Log(draw, material);
    }
    private void Update()
    {
        if (draw.canvas == gameObject.transform)
            HandleAliveTime();
    }
}
