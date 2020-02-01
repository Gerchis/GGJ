using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity;
    public Transform worldCenter;
    public Rigidbody2D rb;

    private Vector2 gravityDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        gravityDirection.Set(transform.position.x - worldCenter.position.x, transform.position.y - worldCenter.position.y);
    }

    private void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime * 1000;

        rb.velocity = gravityDirection.normalized * -gravity * delta;
    }
}
