using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private Input_Manager inputManager;
    [SerializeField] private PlayerController  playerController;
    public bool drawing;
    public bool onTable;

    private void Update()
    {
        if (inputManager.draw)
            drawing = !drawing;
        
    }
}
