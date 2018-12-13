using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLevelSelector : MonoBehaviour
{
    public int LevelToGoTo;

    public void GoToLevel()
    {
        SceneManager.LoadScene(1 + LevelToGoTo);
    }
}
