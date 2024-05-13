using UnityEngine;
using UnityEngine.UI;

public class RockPaperScissorsController : MonoBehaviour
{
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite rockSprite;
    [SerializeField] private Sprite paperSprite;
    [SerializeField] private Sprite scissorsSprite;
    [SerializeField] private Image UiImage;

    private void Start()
    {
        UiImage.sprite = defaultSprite;
    }

    public void Rock()
    {
        UiImage.sprite = rockSprite;
    }

    public void Paper()
    {
        UiImage.sprite = paperSprite;
    }

    public void Scissors()
    {
        UiImage.sprite = scissorsSprite;
    }

    public void Reset()
    {
        UiImage.sprite = defaultSprite;
    }
}
