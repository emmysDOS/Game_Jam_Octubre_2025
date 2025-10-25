using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int life;
    float timer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.forward * speed * Time.deltaTime;

        timer += Time.deltaTime;

        if (timer >= life)
        {
            Destroy(gameObject);
        }
    }


}
