using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayUISound : MonoBehaviour
{
    public string eventName = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Play()
    {
        GameObject mainCamera = GameObject.Find("Main Camera");
        if (!string.IsNullOrEmpty(eventName))
        {
            AkSoundEngine.PostEvent(eventName, mainCamera);
            
        }
    }

    public void Stop()
    {
        GameObject mainCamera = GameObject.Find("Main Camera");
        if (!string.IsNullOrEmpty(eventName))
        {
            AkSoundEngine.StopAll(mainCamera);

        }
    }
}
