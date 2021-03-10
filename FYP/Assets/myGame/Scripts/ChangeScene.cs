using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static ChangeScene changeScene;

    private void Awake()
    {
        changeScene = this;
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Brand")
        {
            StartCoroutine(ToName(2));
        }

        if (SceneManager.GetActiveScene().name == "GameName")
        {
            StartCoroutine(startGame(3));
        }
    }

    IEnumerator ToName(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ToGameName();
    }

    public void ToGameName()
    {
        SceneManager.LoadScene("GameName");
    }

    IEnumerator startGame(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ToMainMenu();
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ToStartGame()
    {
        SceneManager.LoadScene("StartGame");
    }

    public void ToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Change(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
