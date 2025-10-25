using UnityEngine;

public class P1 : Painting
{
    //public bool closedByInput;
    void Start()
    {
        paintingNumber = 1;
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
