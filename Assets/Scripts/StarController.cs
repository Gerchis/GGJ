using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    public SceneControlle scene;

    public void Interaction()
    {
        scene.newDay();
    }
}
