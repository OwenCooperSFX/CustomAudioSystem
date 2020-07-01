using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvent : MonoBehaviour
{
    [System.Serializable]
    public class Stuff
    {
        //Name the object, load a prefab that carries the audioclips and the class for what it does (e.g. RandomContainer, SequenceContainer)
        //Probably the best way to store custom audioObjects is to the Unity Prefabs, so they can be stored and tweaked individually,
        //without risking screwing things up here.
        public string name;
        public GameObject audioObject;
        public int voiceLimit = 10; //Use the voiceLimit as an argument for the audioObject's class.
    }

    public List<Stuff> Stuffs;

    void Awake()
    {
        //audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    void Start()
    {
        foreach (Stuff thing in Stuffs)
        {
            // too tired for this :(
        }
    }

    /*
    void PostEvent()
    {
        for (int i = 0; i < audioObjects.Length; i++)
        {
            if (audioObjects[i] != null)
            {

            }
        }
    }
    */
}
