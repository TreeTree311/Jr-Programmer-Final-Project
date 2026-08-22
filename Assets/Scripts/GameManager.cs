using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
    }
    public void StartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1, LoadSceneMode.Single) ;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
        }
        
    }
    public void UnPauseGame()
    {
        Time.timeScale = 1f;  
    }
}
