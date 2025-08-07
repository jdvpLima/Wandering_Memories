using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose_Menu : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
}
