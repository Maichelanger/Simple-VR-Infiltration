using UnityEngine;

public class TestButtonOpenenerBehaviour : MonoBehaviour
{
    [SerializeField] private Animator doorAnim;

    public void OpenDoor()
    {
        Debug.Log("Open door");
        doorAnim.SetTrigger("Open");
    }
}
