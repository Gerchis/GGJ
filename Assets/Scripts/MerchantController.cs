using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MerchantController : MonoBehaviour
{
    public string[] dialogues;
    public Text texto;
    public Image bocadillo;
    public int[] timesSpoke;
    public float talkingTime;

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
        if (Time.time < actualTalkingTime)
        {
            anim.SetBool("Talking",true);
        }
        else if (anim.GetBool("Talking"))
        {
            anim.SetBool("Talking", false);
        }
    }

    public void Interaction()
    {
        if (dialogueLine < timesSpoke[scene.day])
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

                dialogue -= timesSpoke[scene.day];
            }
    
        }

        Debug.Log(dialogue);
    }
}
