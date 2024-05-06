using UnityEngine;
using UnityEngine.UI;

public class NumpadController : MonoBehaviour
{
    public int correctAdditionCode;
    [Range(1, 9)] public int maxPressedButtons = 4;
    [SerializeField] private GameObject[] numpadButtons = new GameObject[9];

    private int pressedButtons = 0;
    private int inputSum = 0;
    private TabletController tabletController;

    private void Awake()
    {
        tabletController = transform.parent.GetComponent<TabletController>();
    }

    private void Start()
    {
        tabletController.PlayOpenAppSound();
    }

    internal void OnNumpadButtonPressed(int buttonIndex, bool isActive)
    {
        tabletController.PlayClickSound();

        if (!isActive)
        {
            pressedButtons--;
            inputSum -= buttonIndex;
            //Debug.Log($"Button {buttonIndex} released");
            return;
        }
        else
        {
            pressedButtons++;
            inputSum += buttonIndex;
            //Debug.Log($"Button {buttonIndex} pressed");
        }

        if (maxPressedButtons == pressedButtons)
        {
            //Debug.Log("Max buttons pressed");
            ResetNumpad();
            return;
        }
    }

    private void ResetNumpad()
    {

        if (inputSum == correctAdditionCode) tabletController.Activate();
        else tabletController.PlayLateErrorSound();

        for (int i = 0; i < numpadButtons.Length; i++)
        {
            numpadButtons[i].GetComponent<Toggle>().isOn = false;
        }

        pressedButtons = 0;
        inputSum = 0;
    }
}
