using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float rayDistance;
    [SerializeField] private Input_Manager inputManager;
    [SerializeField] private GameObject Camera;
    public float speed;
    public float sideSpeed;
    public float mouseSensitivityX;
    public float mouseSensitivityY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleRayToObject();
        Walk(speed,sideSpeed);
        HandleCamera();
    }
    private void Walk(float speed, float sideSpeed)
    {
        transform.position += transform.forward * Time.deltaTime * inputManager.yInput * -speed;
        transform.position += transform.right * Time.deltaTime * inputManager.xInput * -sideSpeed;
    }
    private void HandleCamera()
    {
        float mouseX = inputManager.mouseX;
        float mouseY = inputManager.mouseY;

        Cursor.visible = false;
        Vector3 rotation = Camera.transform.localEulerAngles;
        rotation.y += mouseY * mouseSensitivityY;
        rotation.x += mouseX * mouseSensitivityX;
        Camera.transform.localEulerAngles = rotation;
    }
    public RaycastHit HandleRayToObject()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward * rayDistance, out hit);
        //Debug.Log(hit.transform.name.ToString());
        return hit;
    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.forward * rayDistance);
    }
}
