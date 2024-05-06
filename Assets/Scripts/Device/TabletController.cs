using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletController : MonoBehaviour
{
    [SerializeField] private AudioClip openApp, click, correct, error;

    internal Collider deviceCollider;

    private GameObject defaultCanvas;
    private GameObject player;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        player = GameObject.FindGameObjectWithTag("Player");
        defaultCanvas = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Device"))
        {
            defaultCanvas.SetActive(false);

            deviceCollider = other;

            GameObject appInstance = other.GetComponent<DeviceController>().GetApp();
            GameObject appNewInstance = Instantiate(appInstance, defaultCanvas.transform.position, defaultCanvas.transform.rotation);
            Destroy(appInstance);
            appNewInstance.transform.SetParent(transform);
            appNewInstance.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Device"))
        {
            defaultCanvas.SetActive(true);

            deviceCollider = null;
            Destroy(GameObject.FindGameObjectWithTag("App"));
        }
    }

    public void OnRelease()
    {
        if (transform.parent != player.transform)
        {
            transform.SetParent(player.transform);
        }
    }

    public void Activate()
    {
        if (deviceCollider != null)
        {
            deviceCollider.GetComponent<DeviceController>().PlayAnims();
            OnTriggerExit(deviceCollider);

            StartCoroutine(PlayLateCorrectCoroutine());
        }
    }

    public void TurnOn()
    {
        if (deviceCollider != null)
        {
            deviceCollider.GetComponent<DeviceController>().TurnDeviceOn();
        }
    }

    public void TurnOff()
    {
        if (deviceCollider != null)
        {
            deviceCollider.GetComponent<DeviceController>().TurnDeviceOff();
        }
    }

    public void PlayOpenAppSound()
    {
        audioSource.PlayOneShot(openApp);
    }

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(click);
    }

    public void PlayCorrectSound()
    {
        audioSource.PlayOneShot(correct);
    }

    private IEnumerator PlayLateCorrectCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        PlayCorrectSound();
    }

    public void PlayErrorSound()
    {
        audioSource.PlayOneShot(error);
    }

    public void PlayLateErrorSound()
    {
        StartCoroutine(PlayLateErrorCoroutine());
    }

    private IEnumerator PlayLateErrorCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        PlayErrorSound();
    }
}
