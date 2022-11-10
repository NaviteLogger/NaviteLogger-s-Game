using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float playerMovementSpeed;
    [SerializeField] float jumpForce;

    [SerializeField] Transform groudCheck;
    [SerializeField] LayerMask ground;
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

        if(Input.GetButtonDown("Jump") && IsTouchingTheFloor())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

    bool IsTouchingTheFloor()
    {
        return Physics.CheckSphere(groudCheck.position, 0.1f, ground);
    }
}
