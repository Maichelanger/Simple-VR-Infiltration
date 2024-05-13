using UnityEngine;

public class DeviceController : MonoBehaviour
{
    [SerializeField] private Animator[] animators;
    public GameObject deviceInteractableObject;
    [SerializeField] private bool turnOffOnStart = true;

    private Collider deviceCollider;
    private bool isDeviceOn = false;
    public bool IsDeviceOn
    {
        get { return isDeviceOn; }
    }

    private void Start()
    {
        deviceCollider = GetComponent<Collider>();

        if (turnOffOnStart)
            TurnDeviceOff();
        else
            TurnDeviceOn();
    }

    public void PlayAnims()
    {
        if (animators.Length == 0)
            return;

        foreach (Animator animator in animators)
        {
            animator.SetTrigger("Play");
        }

        deviceCollider.enabled = false;
    }

    public void TurnDeviceOn()
    {
        if (deviceInteractableObject == null)
            return;

        deviceInteractableObject.SetActive(true);
        isDeviceOn = true;
    }

    public void TurnDeviceOff()
    {
        if (deviceInteractableObject == null)
            return;

        deviceInteractableObject.SetActive(false);
        isDeviceOn = false;
    }
}
