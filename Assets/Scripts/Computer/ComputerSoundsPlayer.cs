using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerSoundsPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip openApp, closeWindow, errorWindow, click;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayOpenAppSound()
    {
        audioSource.PlayOneShot(openApp);
    }

    public void PlayCloseWindowSound()
    {
        audioSource.PlayOneShot(closeWindow);
    }

    public void PlayErrorWindowSound()
    {
        audioSource.PlayOneShot(errorWindow);
    }

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(click);
    }

    public void PlayLateErrorWindowSound()
    {
        StartCoroutine(PlayLateErrorWindowSoundCoroutine());
    }

    private IEnumerator PlayLateErrorWindowSoundCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        PlayErrorWindowSound();
    }
}
