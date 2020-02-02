using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform targetPlayer;
    public Transform playerDay;
    public Transform playerNight;

    public Animator world;

    private bool kinematic = false;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        targetPlayer = playerDay;
    }

    void LateUpdate()
    {
        if (!kinematic)
        {
            Vector3 cameraPos = new Vector3(targetPlayer.position.x, targetPlayer.position.y + 1f, transform.position.z);
            transform.position = cameraPos;
        }
    }

    public void startAnimation ()
    {
        kinematic = true;

        if (targetPlayer == playerNight)
        {
            targetPlayer = playerDay;
        }
        else
        {
            targetPlayer = playerNight;
        }
    }

    public void rotateWorld ()
    {
        world.SetTrigger("Rotate");
    }

    public void endAnimation ()
    {
        kinematic = false;
    }
}
