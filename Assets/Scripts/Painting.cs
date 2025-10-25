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

    protected void Start()
    {
        animator.SetInteger("pos", wallPos);
    }
    protected void Update()
    {
        layerCount = layersParent.transform.childCount;
        if (layerCount == 0)
        {
            completed = true;
            selected = false;
            player.paintingSelected = false;
            gameObject.GetComponent<Painting>().enabled = false;
            db.completed[paintingNumber] = true;    
        }


        animator.SetBool("completed", completed);

        HandleSelected();
        player.C1Completed = completed;


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
}
