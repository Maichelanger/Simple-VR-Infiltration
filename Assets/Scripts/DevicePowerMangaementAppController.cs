using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DevicePowerMangaementAppController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private Toggle buttonToggle;

    private DeviceController deviceController;
    private TabletController tabletController;
    private bool interactable = false;

    private void Awake()
    {
        buttonToggle.interactable = false;
        buttonToggle.onValueChanged.AddListener(delegate { TogglePower(); });
        deviceController = transform.parent.GetComponent<TabletController>().deviceCollider.GetComponent<DeviceController>();
        tabletController = transform.parent.GetComponent<TabletController>();
        StartCoroutine(EnableInteractable());

        tabletController.PlayOpenAppSound();
    }

    private void Start()
    {
        if (deviceController.IsDeviceOn)
        {
            buttonText.text = "1";
            buttonToggle.isOn = true;
        }
        else
        {
            buttonText.text = "0";
            buttonToggle.isOn = false;
        }
    }

    public void TogglePower()
    {
        if (interactable)
        {
            tabletController.PlayClickSound();
            if (deviceController.IsDeviceOn) OnPowerOff();
            else OnPowerOn();
        }
    }

    private void OnPowerOff()
    {
        tabletController.TurnOff();
        buttonText.text = "0";
    }

    private void OnPowerOn()
    {
        tabletController.TurnOn();
        buttonText.text = "1";
    }

    IEnumerator EnableInteractable()
    {
        yield return new WaitForSeconds(0.5f);
        interactable = true;
        buttonToggle.interactable = true;
    }
}
