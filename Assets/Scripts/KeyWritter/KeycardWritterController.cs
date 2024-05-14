using System.Collections;
using UnityEngine;

public class KeycardWritterController : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            other.GetComponent<KeycardController>().isKeycardActivated = true;
            audioSource.Play();
        }
    }
}
