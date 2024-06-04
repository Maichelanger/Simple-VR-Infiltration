using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetUnlockController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    public void SetCabinetUnlocked()
    {
        gameManager.grabbableKeycard = true;
    }
}
