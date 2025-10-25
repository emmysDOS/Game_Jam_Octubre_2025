using UnityEngine;

public class P2 : Painting
{
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        player.C2Selected = selected;
        if (layerCount == 0)
            player.C2Selected = false;
    }
}
