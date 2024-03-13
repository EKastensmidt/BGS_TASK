using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup gameEndScreen;
    private Tween fadeTween;

    private Player player;

    private void OnEnable()
    {
        Crush.OnGameEnd += EndGame;
    }

    private void OnDisable()
    {
        Crush.OnGameEnd -= EndGame;
    }

    private void Start()
    {
        
    }
    private void EndGame()
    {
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

    private void GiveUp()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
