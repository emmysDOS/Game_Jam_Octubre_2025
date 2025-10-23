using UnityEngine;

public class Input_Manager : MonoBehaviour
{
    public bool leftMouse;
    public  Vector2 inputPos;
    public bool resetScene;
    private void Update()
    {
        HandleDrawInputs();
        HandleCanvasRotation();

        resetScene = (Input.GetKey(KeyCode.R));


    }

    private void HandleDrawInputs()
    {
        leftMouse = Input.GetMouseButton(0);
    }

    public byte HandleToolSelectionInput()
    {
        if (Input.GetKey(KeyCode.Alpha0))
            return 0;
        else if (Input.GetKey(KeyCode.Alpha1))
            return 1;
        else if (Input.GetKey(KeyCode.Alpha2))
            return 2;
        else
            return 9;
    }

    private void HandleCanvasRotation()
    {
        if (Input.GetKey(KeyCode.W))
            inputPos.x -= Time.deltaTime;
        else if (Input.GetKey(KeyCode.S))
            inputPos.x += Time.deltaTime;
        else if (Input.GetKey(KeyCode.A))
            inputPos.y -= Time.deltaTime;
        else if (Input.GetKey(KeyCode.D))
            inputPos.y += Time.deltaTime;
    }
}
