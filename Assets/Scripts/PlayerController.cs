using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity;
    public Transform worldCenter;
    public Rigidbody2D rb;
    public float speed;
    public SceneControlle scene;

    public Texture2D defaultCursor;
    public Texture2D interactCursor;

    private Vector2 gravityDirection;
    private Vector3 moveDirection;
    private Directions inputDirection = Directions.NONE;
    private Animator anim;
    private SpriteRenderer sprite;

    private bool right = true;

    private MerchantController npc;
    private ApplleController aple;

    private enum Directions
    {
        NONE,
        RIGHT,
        LEFT
    }

    public SceneControlle.Phase playerPhase = SceneControlle.Phase.DAY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        gravityDirection = worldCenter.position - transform.position;

        moveDirection.Set(-gravityDirection.normalized.y, gravityDirection.normalized.x,0);

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            inputDirection = Directions.LEFT;

            anim.SetBool("Walk", true);

            if (right)
            {
                sprite.flipX = true;

                right = false;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            inputDirection = Directions.RIGHT;

            anim.SetBool("Walk", true);

            if (!right)
            {
                sprite.flipX = false;

                right = true;
            }
        }
        else
        {
            inputDirection = Directions.NONE;

            anim.SetBool("Walk", false);
        }

    }

    private void FixedUpdate()
    {
        int movementIndex;
        float delta = Time.fixedDeltaTime * 1000;
        float distance = 50;

        rb.AddForce(-Physics2D.gravity*gravity*gravityDirection.normalized,ForceMode2D.Force);

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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (scene.actualPhase == playerPhase)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (collision.gameObject.tag == "NPC")
                {
                    npc = collision.GetComponent<MerchantController>();

                    if (!npc.bocadillo.gameObject.activeSelf)
                    {
                        npc.bocadillo.gameObject.SetActive(true);
                    }

                    npc.Interaction();
                }
                else if (collision.gameObject.tag == "Tree")
                {
                    aple = collision.GetComponent<ApplleController>();

                    aple.Interaction();

                }
            }
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Cursor.SetCursor(interactCursor, Vector2.zero, CursorMode.Auto);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }
}
