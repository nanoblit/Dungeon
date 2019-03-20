using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionButtonScript : MonoBehaviour
{
    public void GoToLevelSelection()
    {
        SceneManager.LoadScene(1);
    }
}
