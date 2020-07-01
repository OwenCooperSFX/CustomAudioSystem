using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEventManager : MonoBehaviour
{
    [System.Serializable]
    public class AudioEvent
    {
        [SerializeField] string name = "New Audio Event";
        [SerializeField] GameObject[] audioObjects;

    }

    public List<AudioEvent> eventList; 
}
