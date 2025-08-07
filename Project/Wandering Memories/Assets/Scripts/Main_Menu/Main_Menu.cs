using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    [SerializeField]
    private SceneController sceneController;
    public void EndlessMode()
    {
        sceneController.LoadScene("EndlessMode");
    }
    public void Story()
    {
        sceneController.LoadScene("Level 1 Intro");
    }
    public void Level1()
    {
        sceneController.LoadScene("Level 1");
    }
    public void Level2()
    {
        sceneController.LoadScene("Level 2");
    }
    public void Level3()
    {
        sceneController.LoadScene("Level 3");
    }
    public void Level4()
    {
        sceneController.LoadScene("Level 4");
    }
    public void Level5()
    {
        sceneController.LoadScene("Level 5");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    private void LoadScene(string sceneName)
    {
        //Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        SceneManager.LoadScene(sceneName);
    }
}
