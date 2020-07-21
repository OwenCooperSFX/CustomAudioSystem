using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEventManager : MonoBehaviour
{
    public List<GameObject> eventList;

    public Dictionary<string, AudioEvent> eventDictionary;

    void Awake()
    {
        //eventDictionary = new Dictionary<string, AudioEvent>();

        //foreach (AudioEvent _audioEvent in eventList)
        //{
        //    eventDictionary.Add(_audioEvent.EventName, _audioEvent);
        //}
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            //eventList[0].PlayEvent();

            //foreach (AudioEvent _audioEvent in eventList)
            //{
            //    _audioEvent.PlayEvent();
            //}
            Debug.Log("AudioEvent.PlayEvent");
        }
    }

    void Init()
    {

    }
}
