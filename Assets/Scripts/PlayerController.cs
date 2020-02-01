using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity;
    public Transform worldCenter;
    public Rigidbody2D rb;
    public float speed;

    private Vector2 gravityDirection;
    private Vector3 moveDirection;
    private Directions inputDirection = Directions.NONE; 

    private enum Directions
    {
        NONE,
        RIGHT,
        LEFT
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        gravityDirection = worldCenter.position - transform.position;

        moveDirection.Set(-gravityDirection.normalized.y, gravityDirection.normalized.x,0);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            inputDirection = Directions.LEFT;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            inputDirection = Directions.RIGHT;
        }
        else
        {
            inputDirection = Directions.NONE;
        }
    }

    private void FixedUpdate()
    {
        int movementIndex;
        float delta = Time.fixedDeltaTime * 1000;
        float distance = 50;

        rb.AddForce(-Physics2D.gravity*gravity*gravityDirection.normalized,ForceMode2D.Force);

        //rb.velocity = Vector2.right * Input.GetAxis("Horizontal") * speed * delta;

        switch (inputDirection)
        {
            case Directions.NONE:
                movementIndex = 0;
                break;
            case Directions.RIGHT:
                movementIndex = 1;
                break;
            case Directions.LEFT:
                movementIndex = -1;
                break;
            default:
                movementIndex = 0;
                break;
        }

        rb.MovePosition(transform.position + moveDirection.normalized * speed * delta * movementIndex );

    }
}
