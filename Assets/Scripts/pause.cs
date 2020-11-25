using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{

    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!colision.gameoverpause)
        {
            if (!colision.pause)
            {
                if (Input.GetKeyDown("escape"))
                {
                    print(Time.timeScale);

                    colision.pause = true;
                    Time.timeScale = 0f;

                    pauseMenu.SetActive(true);
                }
            }
            else
            {
                if (Input.GetKeyDown("escape"))
                {
                    pauseMenu.SetActive(false);
                    colision.pause = false;
                    Time.timeScale = score.TimeMultiplier;
                }
            }
        }
    }

    public void resume()
    {
        pauseMenu.SetActive(false);
        colision.pause = false;
        Time.timeScale = score.TimeMultiplier;
    }

    public void menu()
    {
        SceneManager.LoadScene("Menu");
        colision.pause = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
