using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class colision : MonoBehaviour
{
    public player movement;

    public GameObject ObsCheck;

    public GameObject gameover;
    public static bool pause, gameoverpause;

    private float timer = 0.0f;
    private float OneHalfSecTimer = 0.50f;

    public GameObject Obstacle0;
    public GameObject Obstacle1;
    public GameObject Obstacle2;

    private int RandomNum;


    public Animator RestartAnim;

    public void NewGame()
    {
        RestartAnim.Play("RestartAnim", 0);
        StartCoroutine(TransitionTime());
    }

    IEnumerator TransitionTime()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        pause = false;
        gameoverpause = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            gameover.SetActive(true);
            Time.timeScale = 0f;
            pause = true;
            gameoverpause = true;

            PlayerPrefs.SetInt("highscore", score.highscore);
            PlayerPrefs.SetInt("Deaths", (PlayerPrefs.GetInt("Deaths", 0)+1));

            steam.updatestats(score.highscore);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > OneHalfSecTimer)
        {
            timer = timer - OneHalfSecTimer;

            steam.steamRPC((int)score.scorevalue);

            RandomNum = Random.Range(0,3);


            if (RandomNum == 0)
            {
                if (Obstacle0.GetComponent<Transform>().position.x >= ObsCheck.GetComponent<Transform>().position.x)
                {
                    Obstacle1.SetActive(true);
                    Obstacle2.SetActive(true);
                }
                else
                {
                    Obstacle0.SetActive(false);
                    Obstacle1.SetActive(true);
                    Obstacle2.SetActive(true);
                }
            }
            if (RandomNum == 1)
            {
                if (Obstacle1.GetComponent<Transform>().position.x >= ObsCheck.GetComponent<Transform>().position.x)
                {
                    Obstacle0.SetActive(true);
                    Obstacle2.SetActive(true);
                }
                else
                {
                    Obstacle0.SetActive(true);
                    Obstacle1.SetActive(false);
                    Obstacle2.SetActive(true);
                }
            }
            if (RandomNum == 2)
            {
                if (Obstacle2.GetComponent<Transform>().position.x >= ObsCheck.GetComponent<Transform>().position.x)
                {
                    Obstacle0.SetActive(true);
                    Obstacle1.SetActive(true);
                }
                else
                {
                    Obstacle0.SetActive(true);
                    Obstacle1.SetActive(true);
                    Obstacle2.SetActive(false);
                }
            }
        }
    }
}
