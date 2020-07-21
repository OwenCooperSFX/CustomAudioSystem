using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public GameObject eventObject;
    private AudioEvent audioEvent;

    void Awake()
    {
        audioEvent = GetComponent<AudioEvent>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            audioEvent.PlayEvent();
        }
    }
}
