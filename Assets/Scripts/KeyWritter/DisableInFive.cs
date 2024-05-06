using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableInFive : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Disable());
    }

    private IEnumerator Disable()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
