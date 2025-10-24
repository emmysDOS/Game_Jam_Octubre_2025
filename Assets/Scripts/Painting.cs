using UnityEngine;

public class Painting : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private Input_Manager inputManager;    
    private Transform heldReference;
    public bool held;
    private void Start()
    {
        heldReference = player.transform.GetChild(1);
    }
    private void Update()
    {
        HandleHeld();
        if (held)
            transform.position = heldReference.position;
    }
    private void HandleHeld()
    {
        /*
        Transform main = transform.GetChild(0);
        Transform dustMask = main.transform.GetChild(1).transform;
        //Debug.Log(dustMask);
        if (player.HandleRayToObject().transform.name == dustMask.name && inputManager.action)
            held = true;
        */
        held = inputManager.action;


    }
}
