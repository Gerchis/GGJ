using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetPlayer;
    public Transform playerDay;
    public Transform playerNight;

    private bool kinematic = false;

    void Start()
    {
        
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
    }

    public void endAnimation ()
    {
        kinematic = false;
    }
}
