using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float rayDistance;
    [SerializeField] private Input_Manager inputManager;
    [SerializeField] private GameObject Camera;
    public Animator cameraAnimator;
    [SerializeField] private Transform work;
    [SerializeField] private GameObject Head;
    public Transform hitTransform;
    [SerializeField] private float toTableSpeed;
    public float speed;
    public float sideSpeed;
    public float mouseSensitivityX;
    public float mouseSensitivityY;
    public bool drawing;
    [SerializeField] private Transform wall;
    [SerializeField] private Transform tableCameraPos;


    public bool C1Selected;
    public bool C2Selected;
    void Update()
    {

        if (inputManager.action)
            ThrowRay();


        if (C1Selected || C2Selected)
        {
            Cursor.visible = true;
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, work.transform.position.x, toTableSpeed), Mathf.Lerp(transform.position.y, work.transform.position.y, toTableSpeed), transform.position.z);
            //cameraAnimator.SetBool("table", true);
            //transform.LookAt(Vector3.forward);
            Head.transform.position = tableCameraPos.position;
            Head.transform.rotation = tableCameraPos.transform.rotation;
        }
        else
        {
            Cursor.visible = false;
            Walk(speed,sideSpeed);
            HandleCamera();
            Debug.Log("Drawing");
            //cameraAnimator.SetBool("table", false);
            Head.transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
        }
       
    }
    private void Walk(float speed, float sideSpeed)
    {
        transform.position += new Vector3(Head.transform.forward.x, 0, Head.transform.forward.z) * Time.deltaTime * inputManager.yInput * -speed; 
        transform.position += new Vector3(Head.transform.right.x, 0, Head.transform.right.z) * Time.deltaTime * inputManager.xInput * -sideSpeed; 
    }
    private void HandleCamera()
    {
        float mouseX = inputManager.mouseX;
        float mouseY = inputManager.mouseY;

        Cursor.visible = false;
        Vector3 rotation =  Head.transform.rotation.eulerAngles;
        rotation.y += mouseY * mouseSensitivityY;
        rotation.x += mouseX * mouseSensitivityX;
        //Camera.transform.localEulerAngles = rotation;
        Head.transform.localEulerAngles = rotation;
    }
    public void ThrowRay()
    {
        RaycastHit hit;
        Physics.Raycast(Head.transform.position, Head.transform.forward * rayDistance, out hit);
        hitTransform = hit.transform;
        Debug.Log(hit.transform.name.ToString());
    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay(Head.transform.position, Head.transform.forward * rayDistance, Color.red);
    }
}
