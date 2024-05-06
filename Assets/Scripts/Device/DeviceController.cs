using UnityEngine;

public class DeviceController : MonoBehaviour
{
    [SerializeField] private GameObject appCanvas;
    [SerializeField] private Animator[] animators;
    public GameObject deviceInteractableObject;
    [SerializeField] private bool turnOffOnStart = true;
    [SerializeField] private int additionCode = 9;
    [SerializeField] private int maxPressedButtons = 4;

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

    public GameObject GetApp()
    {
        GameObject appInstance = null;

        NumpadController numpadController = appCanvas.GetComponent<NumpadController>();
        if(numpadController != null)
        {
            appInstance = Instantiate(appCanvas);
            appInstance.GetComponent<NumpadController>().correctAdditionCode = additionCode;
            appInstance.GetComponent<NumpadController>().maxPressedButtons = maxPressedButtons;
        }
        else
        {
            appInstance = Instantiate(appCanvas);
        }

        return appInstance;
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
