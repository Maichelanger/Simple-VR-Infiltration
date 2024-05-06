using System.Collections;
using UnityEngine;

public class KeycardWritterController : MonoBehaviour
{
    internal bool isWriting = false;
    internal bool isKeycardIn = false;

    private GameObject keycard;

    public void WriteKeycard()
    {
        if (CheckForKeycard())
        {
            StartCoroutine(WriteKeycardCoroutine());
        }
    }

    public bool CheckForKeycard()
    {
        bool isIn = false;

        if (isKeycardIn && keycard != null) isIn = true;

        return isIn;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            isKeycardIn = true;
            keycard = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            isKeycardIn = false;
            keycard = null;
        }
    }

    IEnumerator WriteKeycardCoroutine()
    {
        isWriting = true;
        yield return new WaitForSeconds(3);

        if (CheckForKeycard())
        {
            keycard.GetComponent<KeycardController>().isKeycardActivated = true;
        }

        isWriting = false;
    }
}
