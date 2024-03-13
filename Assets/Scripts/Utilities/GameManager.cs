using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup gameEndScreen;
    [SerializeField] private GameObject pauseMenu;
    private Tween fadeTween;

    private Player player;

    private void OnEnable()
    {
        Crush.OnGameEnd += EndGame;
        PlayerController.OnPlayerPause += OnPause;
    }

    private void OnDisable()
    {
        Crush.OnGameEnd -= EndGame;
        PlayerController.OnPlayerPause -= OnPause;
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    private void EndGame()
    {
        player.DisableInteraction();

        FadeIn(5f);
    }

    public void FadeIn(float duration)
    {
        Fade(1f, duration, () =>
        {
            gameEndScreen.interactable = true;
            gameEndScreen.blocksRaycasts = true;
        });
    }

    private void Fade(float endValue, float duration, TweenCallback onEnd)
    {
        if (fadeTween != null)
        {
            fadeTween.Kill(false);
        }

        fadeTween = gameEndScreen.DOFade(endValue, duration);
        fadeTween.onComplete += onEnd;
    }

    public void GiveUp()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnPause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

}
