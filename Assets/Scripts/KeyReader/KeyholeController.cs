using UnityEngine;

public class KeyholeController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Animator[] doorAnims;
    [SerializeField] private AudioClip rejectSound, acceptSound;

    private Collider deviceCollider;
    private AudioSource audioSource;

    private void Awake()
    {
        deviceCollider = GetComponent<Collider>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            if (other.gameObject.GetComponent<KeycardController>().isKeycardActivated) OpenDoor();
            else RejectCard();
        }
    }

    private void OpenDoor()
    {
        audioSource.PlayOneShot(acceptSound);

        foreach (Animator animator in doorAnims)
        {
            animator.SetTrigger("Play");
        }
            

        deviceCollider.enabled = false;

        gameManager.isGameOver = true;
    }

    private void RejectCard()
    {
        audioSource.PlayOneShot(rejectSound);
    }
}
