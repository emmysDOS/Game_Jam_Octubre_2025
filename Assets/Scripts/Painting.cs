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

    protected void Start()
    {
        animator.SetInteger("pos", wallPos);
    }
    protected void Update()
    {
        layerCount = layersParent.transform.childCount;
        if (layerCount == 0)
        {
            selected = false;
            player.drawing  = false;
            completed = true;
        }


        animator.SetBool("completed", completed);

        HandleSelected();


    }
    protected void HandleSelected()
    {
        if (player.hitTransform.name == dustMask.name)
            selected = true;
        else
            selected = false;
        
        animator.SetBool("selected", selected);

        player.drawing = selected;
    }
}
