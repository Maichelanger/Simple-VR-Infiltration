using UnityEngine;

public class ComputerActivationController : MonoBehaviour
{
    [SerializeField] private GameObject computer;
    [SerializeField] private Transform ancor;

    private AudioSource audioSource;
    private bool cellInAncor = false;

    private void Start()
    {
        computer.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cell") && !cellInAncor)
        {
            cellInAncor = true;
            other.transform.position = ancor.position;
            other.transform.rotation = ancor.rotation;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            other.GetComponent<Rigidbody>().isKinematic = true;
            ActivateComputer();
        }
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
