using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public Button level02;

    int levelPassed;

    // Start is called before the first frame update
    void Start()
    {
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        //level01.interactable = false;
        level02.interactable = false;

        switch (levelPassed)
        {
            case 1:
                level02.interactable = true;
                break;
        }
    }

    public void levelToLoad (string level)
    {
        SceneManager.LoadScene(level);
    }
}
