using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class GameUI : MonoBehaviour
{

    [SerializeField] InputAction openPauseMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] TextMeshProUGUI timerText;

    public float currentTime;
    private TimeSpan timePlaying;

    private void Start()
    {
        openPauseMenu.Enable();
    }
    private void Update()
    {
        if (openPauseMenu.triggered)
        {
            pauseMenu.SetActive(true);
            GameManager.Instance.PauseGame();
            
        }
        currentTime += Time.deltaTime;
        timePlaying = TimeSpan.FromSeconds(currentTime);
        timerText.text = timePlaying.ToString("mm':'ss");

    }


    public void ReturnToGame()
    {
        pauseMenu.SetActive(false);
        GameManager.Instance.PauseGame();
    }

    public void Restart()
    {
        GameManager.Instance.StartGame();
        GameManager.Instance.PauseGame();
    }

    public void ExitToMain()
    {
        GameManager.Instance.MainMenu();
        GameManager.Instance.PauseGame();
    }
}
