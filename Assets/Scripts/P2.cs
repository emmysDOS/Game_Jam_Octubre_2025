using UnityEngine;

public class P2 : Painting
{
    void Start()
    {
        paintingNumber = 2;
        dustName = "DM1C2";
        base.Start();
    }

    void Update()
    {
        base.Update();
        
        if (selected)
            db.selected[paintingNumber] = true;

    }
}
