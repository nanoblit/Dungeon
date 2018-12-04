using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool IsPlayerInControl = true;

    private FadeController _fadeController;

    public static GameManager I { get; private set; }
    private void SetSingleton()
    {
        if (I == null)
        {
            I = this;
        }
        else if (I != this)
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        SetSingleton();

        _fadeController = GameObject.Find("Fade").GetComponent<FadeController>();
    }

    private void Start()
    {
        StartCoroutine(StartLevelCoroutine());
    }

    public void RestartLevel()
    {
        StartCoroutine(RestartLevelCoroutine());
    }

    public void NextLevel()
    {
        StartCoroutine(NextLevelCoroutine());
    }

    private IEnumerator StartLevelCoroutine()
    {
        IsPlayerInControl = false;
        _fadeController.gameObject.SetActive(true);
        _fadeController.FadeIn();
        yield return new WaitForSeconds(_fadeController.FadeTime);
        _fadeController.gameObject.SetActive(false);
        IsPlayerInControl = true;
    }

    private IEnumerator RestartLevelCoroutine()
    {
        IsPlayerInControl = false;
        _fadeController.gameObject.SetActive(true);
        _fadeController.FadeOut();
        yield return new WaitForSeconds(_fadeController.FadeTime);
        IsPlayerInControl = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator NextLevelCoroutine()
    {
        IsPlayerInControl = false;
        _fadeController.gameObject.SetActive(true);
        _fadeController.FadeOut();
        yield return new WaitForSeconds(_fadeController.FadeTime);

        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextLevelIndex);
        }
        else
        {
            Debug.Log("Last level!");
        }
    }
}
