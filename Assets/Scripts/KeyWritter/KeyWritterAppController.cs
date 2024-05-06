using System.Collections;
using UnityEngine;

public class KeyWritterAppController : MonoBehaviour
{
    [SerializeField] private GameObject waitingForKeyScreen, keyInReaderScreen, writtingScreen, sucessScreen, failScreen;

    private TabletController tabletController;
    private KeycardWritterController writterController;

    private void Awake()
    {
        tabletController = transform.parent.GetComponent<TabletController>();
        writterController = tabletController.deviceCollider.GetComponent<DeviceController>().
            deviceInteractableObject.GetComponent<KeycardWritterController>();

        tabletController.PlayOpenAppSound();
    }

    private void Update()
    {
        CheckCurrentBackgroundScreen();
    }

    public void OnWriteKeycard()
    {
        if (!writterController.isWriting)
        {
            tabletController.PlayClickSound();
            writterController.WriteKeycard();
            StartCoroutine(WaitForStopWritting());
        }
    }

    private void CheckCurrentBackgroundScreen()
    {
        if (writterController.isKeycardIn && !writterController.isWriting)
        {
            keyInReaderScreen.SetActive(true);
            waitingForKeyScreen.SetActive(false);
            writtingScreen.SetActive(false);
        }
        else if (writterController.isWriting)
        {
            keyInReaderScreen.SetActive(false);
            waitingForKeyScreen.SetActive(false);
            writtingScreen.SetActive(true);
        }
        else
        {
            keyInReaderScreen.SetActive(false);
            waitingForKeyScreen.SetActive(true);
            writtingScreen.SetActive(false);
        }
    }

    private IEnumerator WaitForStopWritting()
    {
        yield return new WaitUntil(() => !writterController.isWriting);

        if (writterController.CheckForKeycard())
        {
            tabletController.PlayCorrectSound();
            sucessScreen.SetActive(true);
        }
        else
        {
            tabletController.PlayErrorSound();
            failScreen.SetActive(true);
        }
    }
}
