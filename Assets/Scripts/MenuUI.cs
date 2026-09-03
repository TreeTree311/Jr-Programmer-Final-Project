using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{

   public void GameStart()
    {
        GameManager.Instance.StartGame();
    }
    public void Exit()
    {
        GameManager.Instance.ExitGame();
    }
}
