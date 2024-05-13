using UnityEngine;

public class LoginController : MonoBehaviour
{
    [SerializeField] private GameObject computer;
    [SerializeField] private GameObject loginPanel;

    private bool isLogged = false;

    private void Start()
    {
        computer.SetActive(false);
    }

    public void ActivateComputer()
    {
        if (isLogged) return;

        isLogged = true;
        computer.SetActive(true);
        loginPanel.SetActive(false);
    }
}
