using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine;

public class GameOverScreen : Screen
{
    [SerializeField] private AudioClip _buttonPress;
    [SerializeField] private AudioClip _gameOver;

    public event UnityAction RestartButtonClick;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnReturnMenuClick();
        }
    }

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        Button.interactable = false;
    }

    public override void Open()
    {
        GetComponent<AudioSource>().PlayOneShot(_gameOver);
        CanvasGroup.alpha = 1;
        Button.interactable = true;
    }

    protected override void OnButtonClick()
    {
        RestartButtonClick?.Invoke();
    }

    public void OnReturnMenuClick()
    {
        GetComponent<AudioSource>().PlayOneShot(_buttonPress);
        SceneManager.LoadScene(0);
    }
}