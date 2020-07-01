﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioObject : MonoBehaviour
{
    public GameObject voiceObjectPrefab;
    public string name = "New Audio Object";
    
    [Header("Settings")]
    public int voiceLimit;
    public enum Positioning{
        spatialized,
        flat
    }

    public Positioning positioning;
    public bool loop;
    private AudioSource audioSource;

    void Awake()
    {
        Init();
    }

    void Init()
    {
        audioSource = GetComponent<AudioSource>();

        var setPositioning = Positioning.spatialized;

        switch (setPositioning)
        {
            case Positioning.spatialized:
                Debug.Log("3D-sound");
                audioSource.spatialBlend = 1;
                break;
            case Positioning.flat:
                audioSource.spatialBlend = 2;
                Debug.Log("2D-sound");
                break;
            default:
                break;
        }

        if (loop)
        {
            audioSource.loop = true;
        }
    }

    void Start()
    {

    }

    void PlaySound()
    {

    }

    void StopSound()
    {

    }
}
