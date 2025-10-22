using UnityEngine;

public class Input_Manager : MonoBehaviour
{
    public  Vector2 inputPos;
    public bool resetScene;
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
            inputPos.x -= Time.deltaTime;
        else if (Input.GetKey(KeyCode.S))
            inputPos.x += Time.deltaTime;
        else if (Input.GetKey(KeyCode.A))
            inputPos.y -= Time.deltaTime;
        else if (Input.GetKey(KeyCode.D))
            inputPos.y += Time.deltaTime;

        resetScene = (Input.GetKey(KeyCode.R));
                          

    }
}
