using UnityEngine;

public class Input_Manager : MonoBehaviour
{
    public  Vector2 inputPos;
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
            inputPos.x -= Time.deltaTime;
        else if (Input.GetKey(KeyCode.D))
            inputPos.x += Time.deltaTime;
        else if (Input.GetKey(KeyCode.W))
            inputPos.y -= Time.deltaTime;
        else if (Input.GetKey(KeyCode.S))
            inputPos.y += Time.deltaTime;


        //If time after no input reset posS                     

    }
}
