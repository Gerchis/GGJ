using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplleController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float gravity;
    public Transform world;

    private Vector2 gravityDirection;
    public bool fallen = false;


    private void FixedUpdate()
    {
        gravityDirection = rb.transform.position - world.position;

        if (fallen)
        {
            rb.AddForce(-Physics2D.gravity.magnitude * gravity * gravityDirection.normalized, ForceMode2D.Force);
        }
        
    }

    public void Interaction()
    {
        fallen = true;
    }
}
