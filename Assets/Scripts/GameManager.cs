using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isRestart = false;


    #region Yeniden Oyna İşlemi

    public void RestartGame()
    {
        isRestart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    #endregion

    #region Oyundan Çıkış İşlemleri
    public void QuitGame()
    {
        Application.Quit();
    }

    #endregion
}
