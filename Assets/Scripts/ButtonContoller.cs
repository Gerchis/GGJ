using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonContoller : MonoBehaviour
{
    public string sceneName;


    public void PlayGame()
    {
        SceneManager.LoadScene(sceneName);
    }
}
