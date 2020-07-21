using UnityEngine;

[System.Serializable]
public class AudioEvent: MonoBehaviour
{
    public string EventName = "New Audio Event";
    public AudioObject[] AudioObjects;
    private AudioObject audioObject;

    public void PlayEvent()
    {
        //if (Emitter == null)
        //{
        //    Debug.LogWarning("No audio emitter designated. Assigning automatically.");
        //}

        //if (audioEmitter == null)
        //{
        //    Debug.LogError(this + ":" + " No audio emitter assigned!");
        //    return;
        //}



        for (int i = 0; i < AudioObjects.Length; i++)
        {
            audioObject = AudioObjects[i];
            //audioObject.transform.parent = Emitter.transform;
            audioObject.PlaySound();
        }
    }
}
