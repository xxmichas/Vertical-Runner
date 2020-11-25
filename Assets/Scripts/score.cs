using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public static float scorevalue;
    public Text scoretext;
    public static int highscore;

    private float timer = 0.0f;
    private float OneTenthSecTimer = 0.10f;

    public static float TimeMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        scorevalue = 0f;
        highscore = PlayerPrefs.GetInt("highscore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (colision.pause)
        {

        }
        else
        {
            timer += Time.deltaTime;
            if (timer > OneTenthSecTimer)
            {
                timer = timer - OneTenthSecTimer;
                scorevalue = scorevalue + 1f;
                if (highscore < scorevalue)
                {
                    highscore = (int)scorevalue;
                }
            }
            scoretext.text = (int)scorevalue + "";

            TimeMultiplier = 1f + scorevalue / 1000;
            if (TimeMultiplier >= 3f)
            {
                Time.timeScale = 3f;
            }
            else
            {
                Time.timeScale = TimeMultiplier;
            }
        }
    }
}
