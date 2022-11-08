using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResettingWorldCenterOfMass : MonoBehaviour
{
    public Vector3 com = new Vector3(0,0,0);
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.centerOfMass = com;
    }
}
