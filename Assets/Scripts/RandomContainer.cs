using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;

public class RandomContainer : MonoBehaviour
{
    public AudioMixerGroup output;

    private float nativeVolume = 1f;
    private float nativePitch = 1f;

    [Header("Settings")]
    public bool randomizePitch = false;
    [Range(0f, 3f)]
    public float pitchRandomization;
    public bool randomizeVolume = false;
    [Range(0f, 1f)]
    public float volumeRandomization;
    private float rndPitch;
    private float rndVolume;

    [Header("Advanced Settings")]
    public bool limitVoices = false;
    [SerializeField] private int voiceLimit = 10;
    public int activeVoices = 0;

    [Header("Audio Clips")]
    public AudioClip[] audioClips;

    public GameObject audioSourcePrefab;
    private AudioSource audioSource;
    public AudioSource defaultAudioSourceSettings;

    ObjectPooler objectPooler;

    private float timeLeft = 5;

    void Awake()
    {
        defaultAudioSourceSettings = this.GetComponent<AudioSource>();
    }

    void Start()
    {
        nativePitch = defaultAudioSourceSettings.pitch;
        nativeVolume = defaultAudioSourceSettings.volume;

        objectPooler = FindObjectOfType<ObjectPooler>();
    }

    private void FixedUpdate()
    {
        //TEST: this works on Fixed update. Why doesn't it work in the PlaySound() method?
        //objectPooler.SpawnFromPool("voices", this.transform.position, Quaternion.identity);
    }

    void Update()
    {

    }

    public void PlaySound()
    {
        //Spawn a temporary GameObject with an AudioSource at the location of this GameObject.
        //TODO: use pooling instead of Instantiation.
        //objectPooler.SpawnFromPool("voices", this.transform.position, Quaternion.identity);

        GameObject audioSourceInstance = Instantiate(audioSourcePrefab);

        audioSource = audioSourceInstance.GetComponent<AudioSource>();

        //If enabled, apply pitch/volume randomization.
        ApplyRandoms(randomizePitch, randomizeVolume);

        //Load a random clip from the array.
        int randomClip = Random.Range(0, audioClips.Length);
        audioSource.clip = audioClips[randomClip];

        //Play the AudioSource on the temporary GameObject
        audioSource.Play();
        Debug.Log("PlaySound");
        activeVoices++;

        //Destroy the temporary GameObject when the clip is finished playing.
        KillVoice(audioSourceInstance, audioClips[randomClip].length);
    }

    void ApplyRandoms(bool randomizePitch, bool randomizeVolume)
    {
        if (randomizePitch)
            rndPitch = Random.Range((nativePitch - Random.Range(0f, pitchRandomization)), (nativePitch + Random.Range(0f, pitchRandomization)));
        else
            rndPitch = nativePitch;

        if (randomizeVolume)
            rndVolume = Random.Range((nativeVolume - Random.Range(0f, volumeRandomization)), (nativeVolume + Random.Range(0f, volumeRandomization)));
        else
            rndVolume = nativeVolume;

        audioSource.pitch = rndPitch;
        audioSource.volume = rndVolume;
    }

    void KillVoice(GameObject _audioSourceInstance, float _clipLength)
    {
        Destroy(_audioSourceInstance, _clipLength);
    }

}
