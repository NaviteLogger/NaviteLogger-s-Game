using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRigidbodySliding : MonoBehaviour
{
    [Tooltip("A velocity per axis smaller than this will be considered unwanted sliding and fixed.")]
    [Min(0.0005f)] public float minimumVelocityAllowed = 0.001f;


    new Rigidbody rigidbody;
    Vector3 lastPosition = Vector3.zero;

    void OnEnable()
    {
        rigidbody = GetComponent<Rigidbody>();
        if (rigidbody == null) { this.enabled = false; return; }
        lastPosition = rigidbody.position;
    }

    void FixedUpdate()
    {
        var delta = rigidbody.position - lastPosition;
        var minDeltaPos = minimumVelocityAllowed * Time.fixedDeltaTime * 10f;

        // avoid issues when teleporting object:
        if (Mathf.Abs(delta.x) > minDeltaPos || Mathf.Abs(delta.y) > minDeltaPos || Mathf.Abs(delta.z) > minDeltaPos)
        {
            lastPosition = rigidbody.position;
            return;
        }

        var vel = rigidbody.velocity;
        var rbp = rigidbody.position;
        var posx = rbp.x;
        var posy = rbp.y;
        var posz = rbp.z;
        if (Mathf.Abs(vel.x) < minimumVelocityAllowed) posx = lastPosition.x;
        if (Mathf.Abs(vel.y) < minimumVelocityAllowed) posy = lastPosition.y;
        if (Mathf.Abs(vel.z) < minimumVelocityAllowed) posz = lastPosition.z;
        rigidbody.position = new Vector3(posx, posy, posz);

        lastPosition = rigidbody.position;
    }

}