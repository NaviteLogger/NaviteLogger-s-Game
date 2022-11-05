using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody rb;
    public float playerMovementSpeed;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * playerMovementSpeed,rb.velocity.y, verticalInput * playerMovementSpeed); ;

        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
/*        if (Input.GetKey("w"))
        {
            rb.velocity = new Vector3(0, 0, 5f);
        }
        if (Input.GetKey("s"))
        {
            rb.velocity = new Vector3(0, 0, -5f);
        }
        if (Input.GetKey("d"))
        {
            rb.velocity = new Vector3(5f, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.velocity = new Vector3(-5f, 0, 0);
        }*/
    }
}
