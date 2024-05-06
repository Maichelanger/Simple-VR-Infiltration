using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;
    [SerializeField] private Animator fadePanelAnim;
    [SerializeField] private float fadeDuration = 0.9f;

    private void Update()
    {
        if (isGameOver)
            GameOver();
    }

    public void GameOver()
    {
        isGameOver = false;

        fadePanelAnim.SetTrigger("Play");

        StartCoroutine(LateChangeScene());
    }

    IEnumerator LateChangeScene()
    {
        yield return new WaitForSeconds(fadeDuration);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
