using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEventManager : MonoBehaviour
{
    [System.Serializable]
    public class AudioEvent
    {
        public string Name = "New Audio Event";
        public AudioObject[] AudioObjects;
    }

    public List<AudioEvent> eventList;

    private AudioEvent audioEvent;

    void Awake()
    {
        audioEvent = new AudioEvent();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            for (int i = 0; i < (audioEvent.AudioObjects.Length - 1); i++)
            {
                audioEvent.AudioObjects[i].PlaySound();
            }
        }
    }
}
