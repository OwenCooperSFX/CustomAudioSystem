using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public RandomContainer randomContainer;

    void Awake()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            randomContainer.PlaySound();
            Debug.Log("Active voices: " + randomContainer.activeVoices);
        }
    }
}
