using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MerchantController : MonoBehaviour
{
    public string[] dialogues;
    public Text texto;
    public Image bocadillo;
    public int[] timesSpoke;
    public float talkingTime;
    public bool merchant;

    public SceneControlle scene;

    private float actualTalkingTime;
    private Animator anim;
    private bool talking;
    private int dialogueLine;
    private int dialogue;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (anim)
        {
            if (Time.time < actualTalkingTime)
            {
                anim.SetBool("Talking", true);
            }
            else if (anim.GetBool("Talking"))
            {
                anim.SetBool("Talking", false);
            }
        }        
    }

    public void Interaction()
    {
        if (scene.actualPhase == SceneControlle.Phase.DAY)
        {
            if (dialogueLine < timesSpoke[scene.day / 2])
            {
                texto.text = dialogues[dialogue];

                dialogueLine++;
                dialogue++;

                actualTalkingTime = Time.time + talkingTime;
            }
            else
            {
                if (bocadillo.gameObject.activeSelf)
                {
                    bocadillo.gameObject.SetActive(false);


                    if (dialogue >= dialogues.Length)
                    {
                        SceneManager.LoadScene("MenuScene");
                    }

                    dialogueLine = 0;

                    if (merchant)
                    {
                        scene.newDay();
                    }
                    else
                    {
                        dialogue -= timesSpoke[scene.day / 2];
                    }
                }
            }

        }
        else
        {
            if (dialogueLine < timesSpoke[(scene.day-1) / 2])
            {
                texto.text = dialogues[dialogue];

                dialogueLine++;
                dialogue++;

                actualTalkingTime = Time.time + talkingTime;
            }
            else
            {
                if (bocadillo.gameObject.activeSelf)
                {
                    bocadillo.gameObject.SetActive(false);


                    dialogueLine = 0;

                    if (merchant)
                    {
                        scene.newDay();
                    }
                    else
                    {
                        dialogue -= timesSpoke[(scene.day-1) / 2];
                    }
                }
            }
        }

    }
}
