using UnityEngine;

public class ComputerActivationController : MonoBehaviour
{
    [SerializeField] private GameObject computer;

    private AudioSource audioSource;

    private void Start()
    {
        computer.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    public void ActivateComputer()
    {
        computer.SetActive(true);
        audioSource.Play();
    }

    public void DeactivateComputer()
    {
        computer.SetActive(false);
    }
}
