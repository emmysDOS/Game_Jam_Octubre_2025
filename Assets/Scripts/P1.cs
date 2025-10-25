using UnityEngine;

public class P1 : Painting
{
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();   
        player.C1Selected = selected;
        if (layerCount == 0)
            player.C1Selected = false;
    }
}
