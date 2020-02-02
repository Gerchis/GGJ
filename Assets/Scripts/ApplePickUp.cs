using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePickUp : MonoBehaviour
{
    public SceneControlle scene;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            scene.newDay();
        }
    }
}
