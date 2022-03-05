using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine;

public class StartScreen : Screen
{
    [SerializeField] private AudioClip _buttonPress;

    public event UnityAction PlayButtonClick;

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
        CanvasGroup.alpha = 1;
        Button.interactable = true;
    }

    protected override void OnButtonClick()
    {
        PlayButtonClick?.Invoke();
    }

    public void OnReturnMenuClick()
    {
        GetComponent<AudioSource>().PlayOneShot(_buttonPress);
        SceneManager.LoadScene(0);
    }
}