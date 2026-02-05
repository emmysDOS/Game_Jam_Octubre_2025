using UnityEngine;

public class P1 : Painting
{
    //public bool closedByInput;
    void Start()
    {
        paintingNumber = 1;
        dustName = "DM1C1";
        base.Start();
    }
    void Update()
    {
        base.Update();
        if (selected)
            db.selected[paintingNumber] = true;
    }

}
