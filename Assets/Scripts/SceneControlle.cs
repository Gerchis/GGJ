using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControlle : MonoBehaviour
{
    public Animator cameraAnim;
    public int day;

    public Phase actualPhase;
    public Texture2D defaultCursor;
    public AudioClip[] audios;

    public GameObject[] events;
    public int[] dayIndex;
    private int eventCount = 0;
    private AudioSource source;

    public enum Phase
    {
        DAY,NIGHT
    }

    public void Start()
    {
        for (int i = 0; i < events.Length; i++)
        {
            events[i].SetActive(false);
        }

        source = GetComponent<AudioSource>();
    }

    public void newDay()
    {
        cameraAnim.SetTrigger("Change");

        day++;

        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);

        switch (actualPhase)
        {
            case Phase.DAY:
                actualPhase = Phase.NIGHT;

                source.clip = audios[0];
                break;
            case Phase.NIGHT:
                actualPhase = Phase.DAY;

                source.clip = audios[1];

                for (int i = 0; i < events.Length; i++)
                {
                    events[i].SetActive(false);
                }
                break;
            default:
                break;
        }

        if (actualPhase == Phase.NIGHT)
        {
            for (int i = 0; i < dayIndex[(day-1)/2]; i++)
            {
                events[eventCount].SetActive(true);

                eventCount++;
            }
        }        
    }
}
