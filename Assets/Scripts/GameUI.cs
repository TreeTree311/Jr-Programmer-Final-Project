using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameUI : MonoBehaviour
{

    [SerializeField] InputAction openPauseMenu; // ENCAPSULATION
    [SerializeField] GameObject pauseMenu; // ENCAPSULATION
    [SerializeField] GameObject returnToGame; // ENCAPSULATION
    [SerializeField] GameObject gameOver; // ENCAPSULATION
    [SerializeField] TextMeshProUGUI timerText; // ENCAPSULATION

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
        GameManager.Instance.UnPauseGame();
    }

    public void Restart()
    {
        GameManager.Instance.StartGame();
        

    }

    public void ExitToMain()
    {
        GameManager.Instance.MainMenu();
        GameManager.Instance.PauseGame();
        
    }
    public void GameOver()
    {
        GameManager.Instance.PauseGame();
        pauseMenu.SetActive(true);
        returnToGame.SetActive(false);
        gameOver.SetActive(true);
        
    }
}
