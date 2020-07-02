using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioObject : MonoBehaviour
{
    public string Name = "New Audio Object";

    #region Notes
    //FUTURE ITERATION: Make new editor that adapts to the ObjectType enum.
    //public enum ObjectType { simple, randomContainer, sequenceContainer }
    //public ObjectType objectType;
    #endregion

    [Header("Settings")]
    [SerializeField] private int voiceLimit = 3;
    private enum Positioning { _3D, _2D }
    [SerializeField] private Positioning positioning;
    public bool loop;
    //public AudioMixerGroup output;

    [Header("Assets")]
    public AudioClip[] audioClips;

    private List<AudioSource> voices;

    //private AudioSource defaultAudioSource;

    private AudioSource _voice;

    void Awake()
    {
        Init();
    }

    void Init()
    {
        CreateVoices(voiceLimit);
        SetPositioning(positioning);
    }

    void Start()
    {

    }

    public void PlaySound()
    {
        //TODO: pool voices by:
        //  1. enable AudioSource, Enqueue in Dictionary
        //  2. Load clip and play
        //  3. disable AudioSource after clip is finished, Dequeue in Dictionary
        //OR: Try todo this just using the list.

        //TODO: Try just dynamically adding and removing one AudioSource for each voice to be played. Probably less performant, but worth testing.

        int voiceToPlay = 0;
        int randomClip = Random.Range(0, audioClips.Length);

        AudioSource audioSource = voices[voiceToPlay];

        audioSource.clip = audioClips[randomClip];
        audioSource.Play();
    }

    void StopSound()
    {

    }

    void CreateVoices(int _voiceLimit)
    {
        voices = new List<AudioSource>();

        if (_voiceLimit <= 0)
        {
            _voiceLimit = 1;
            Debug.LogWarning("Invalid voiceLimit! Set to default: 1.");
        }

        if (_voiceLimit > 0)
        {
            for (int i = 0; i < _voiceLimit; i++)
            {
                _voice = gameObject.AddComponent<AudioSource>();
                _voice.enabled = false;

                if (loop)
                {
                    _voice.loop = true;
                }

                voices.Add(_voice);
            }
        }
    }

    void SetPositioning(Positioning _positioning)
    {
        Positioning setPositioning = _positioning;

        switch (setPositioning)
        {
            case Positioning._3D:
                Debug.Log("3D-sound [" + Name + "] initialized. " + "Voice Limit: " + voiceLimit);
                _voice.spatialBlend = 1;
                break;
            case Positioning._2D:
                _voice.spatialBlend = 2;
                Debug.Log("2D-sound [" + Name + "] initialized. " + "Voice Limit: " + voiceLimit);
                break;
            default:
                break;
        }
    }
}
