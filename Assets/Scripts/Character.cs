using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{

    float speed = 5;
    float rotationspeed = 360;

    public bool playerParentIsOnGround = true;
    public float jumpForce = 7;
    private int currentJump = 0;
    public Rigidbody playerRb;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;

            // transform.Translate(Vector3.forward * Time.deltaTime * speed);
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            //transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, Time.deltaTime * -speed);

            // transform.Translate(Vector3.forward * Time.deltaTime * speed);
            //transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * -rotationspeed, 0));

            //transform.Translate(Vector3.forward * Time.deltaTime * speed);
            //transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //transform.Translate(Vector3.forward * Time.deltaTime * speed);
            //transform.rotation = Quaternion.Euler(0, 90, 0);
            transform.Rotate(new Vector3(0, Time.deltaTime * rotationspeed, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space) && (playerParentIsOnGround))
        {

            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerParentIsOnGround = false;
            currentJump++;

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            playerParentIsOnGround = true;
            currentJump = 0;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            playerParentIsOnGround = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Goal is touched!");


        }
    }
}
