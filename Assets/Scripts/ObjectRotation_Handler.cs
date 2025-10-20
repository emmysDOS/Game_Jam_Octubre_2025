using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectRotation_Handler : MonoBehaviour
{
    [SerializeField] private Input_Manager inputManager;
    private void Update()
    {
        float posX = inputManager.inputPos.x;
        float posY = inputManager.inputPos.y;
        transform.rotation = Quaternion.Euler(transform.rotation.x + posX, transform.rotation.y, transform.rotation.z + posY);

    }
}
