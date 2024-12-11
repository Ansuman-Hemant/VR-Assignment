using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip clip1;
    public AudioSource src;

    void Start()
    {
        // Play the clip once at the start if the AudioSource is set
        if (src != null)
        {
            src.clip = clip1; // Assign the clip
            src.Play(); // Play the audio
        }
    }
}
