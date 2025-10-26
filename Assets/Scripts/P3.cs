using UnityEngine;

public class P3 : Painting
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        paintingNumber = 3;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (selected)
            db.selected[paintingNumber] = true;
    }
}
