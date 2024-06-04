using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeycardController : MonoBehaviour
{
    public bool isKeycardActivated = false;
    [SerializeField] private GameManager gameManager;

    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.enabled = false;
    }

    private void Update()
    {
        if (gameManager.grabbableKeycard && !grabInteractable.enabled)
        {
            grabInteractable.enabled = true;
        }
    }
}
