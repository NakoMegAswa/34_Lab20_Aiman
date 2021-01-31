using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSpawn : MonoBehaviour
{
    public Rigidbody rb;
    //public BoxCollider col;
    public GameObject Goalprefab;          //BlockPrefab
    public float spawnInterval;             //Interval between each spawn

    // Spawn Area //
    public float minX;                      //minX position
    public float maxX;                      //maxX position
    public float minZ;                      //minZ position
    public float maxZ;                      //maxZ position

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       // col = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        // hack =X //
        if (rb.IsSleeping())
            rb.WakeUp();
       
        
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
    */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
          

            Destroy(gameObject);
            Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), 0.1f, Random.Range(minZ, maxZ));

            Instantiate(Goalprefab, spawnPosition, Quaternion.identity);

            Debug.Log("Goal is touched! from this side too LMAO!");
        }

       
    }
}
