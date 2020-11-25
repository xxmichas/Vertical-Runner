using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{

    public GameObject SettingsMenu;
    public Animation transition;

    void Start()
    {
        QualitySettings.vSyncCount = 1;
        Time.timeScale = 1f;
    }
    public void play()
    {
        transition.Play();
        StartCoroutine(TransitionTime());
    }

    IEnumerator TransitionTime()
    {
        yield return new WaitForSeconds(1.167f);
        SceneManager.LoadScene("platformer");
    }

    public void ToSettings()
    {
        SettingsMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
