using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionController : MonoBehaviour
{
    [SerializeField] private Transform _buttonPrefab;

    private void Start()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;

        for (int i = 0; i < sceneCount - 2; i++)
        {
            Transform button = Instantiate(_buttonPrefab, transform);
            button.GetComponentInChildren<Text>().text = (i + 1).ToString();
            button.GetComponent<ButtonLevelSelector>().LevelToGoTo = i + 1;
            button.SetAsLastSibling();
        }
    }
}
