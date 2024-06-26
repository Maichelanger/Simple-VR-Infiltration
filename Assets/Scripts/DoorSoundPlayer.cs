using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSoundPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        audioSource.Play();
    }
}
