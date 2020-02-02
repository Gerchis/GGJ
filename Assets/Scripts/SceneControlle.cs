using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControlle : MonoBehaviour
{
    public Animator cameraAnim;
    public int day;

    public Phase actualPhase;

    public GameObject[] events;
    public int[] dayIndex;
    private int eventCount = 0;

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
    }

    public void newDay()
    {
        cameraAnim.SetTrigger("Change");

        day++;

        switch (actualPhase)
        {
            case Phase.DAY:
                actualPhase = Phase.NIGHT;
                break;
            case Phase.NIGHT:
                actualPhase = Phase.DAY;

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
