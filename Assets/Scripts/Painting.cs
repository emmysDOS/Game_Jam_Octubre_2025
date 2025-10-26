using UnityEngine;

public class Painting : MonoBehaviour
{
    [SerializeField] protected PlayerController player;
    [SerializeField] protected Input_Manager inputManager;   
    [SerializeField] protected Transform table;
    [SerializeField] protected Animator animator;
    public bool selected;
    [SerializeField] protected int layerCount;
    public bool completed;
    [SerializeField] protected Transform dustMask;
    [SerializeField] protected GameObject layersParent;
    [SerializeField] protected int wallPos;
    [SerializeField] protected PaintingsDB db;
    protected byte paintingNumber;
    [SerializeField] protected UI_Manager uiManager;
    
    
    [SerializeField] protected bool closedByInput;
    [SerializeField] protected bool nextMessage;
    [SerializeField] protected string message1;
    protected string message2;

    [SerializeField] protected string[] messages;
    
    public bool alreadyOpened;

    [SerializeField] protected GameObject BackgroundsParent;

    protected void Start()
    {
        animator.SetInteger("pos", wallPos);
        SetBkg();
    }
    protected void Update()
    {
        layerCount = layersParent.transform.childCount;
        if (layerCount == 0)
        {
            completed = true;
            selected = false;
            player.paintingSelected = false;
            db.completed[paintingNumber] = true;    
            uiManager.CloseBubble();
            gameObject.GetComponent<Painting>().enabled = false;
            //player.ResetCamera();
        }


        animator.SetBool("completed", completed);

        HandleSelected();
        player.C1Completed = completed;
        HandleBubble(message1, message2);


    }
    protected void HandleSelected()
    {
        if (player.hitTransform.name == dustMask.name)
        {
            player.paintingSelected = true;
            selected = true;
        }
 
        else
            selected = false;
        
        animator.SetBool("selected", selected);
    }

    protected void HandleBubble(string message1, string message2)
    {
        if (inputManager.action2.IsPressed())
            nextMessage = true;
        
        if (selected && !alreadyOpened)
        {
            uiManager.SendBubble(message1);
            if (nextMessage)
                uiManager.SendBubble(message2);
            alreadyOpened = true;
        }
    }

    protected void SetBkg()
    {
        int value = Random.Range(0, BackgroundsParent.transform.childCount);
        BackgroundsParent.transform.GetChild(value).gameObject.SetActive(true);
        message1 = messages[value];
        
        
    }



    protected void ResetPlayerCamera()
    {
        player.ResetCamera();
    }
    
}
