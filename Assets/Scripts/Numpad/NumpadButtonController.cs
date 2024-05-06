using UnityEngine;
using UnityEngine.UI;

public class NumpadButtonController : MonoBehaviour
{
    [SerializeField] private int buttonIndex;
    [SerializeField] private NumpadController numpadController;

    public void OnButtonPressed()
    {
        bool isActive = GetComponent<Toggle>().isOn;
        numpadController.OnNumpadButtonPressed(buttonIndex, isActive);
    }
}
