using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    //[SerializeField] Button StartGame;

   public void GameStart()
    {
        GameManager.Instance.StartGame();
    }
    public void Exit()
    {
        GameManager.Instance.ExitGame();
    }
}
