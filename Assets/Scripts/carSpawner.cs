using UnityEngine;

public class carSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float timer;
    [SerializeField] private int timeTreshold;
    [SerializeField] private GameObject[] cars = new  GameObject[2];
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer +=  Time.deltaTime;


        if (timer >= timeTreshold)
        {
            Instantiate(cars[Random.Range(0, cars.Length)], transform.position, transform.rotation);
            timer = 0;
        }

    }
}
