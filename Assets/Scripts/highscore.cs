using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class highscore : MonoBehaviour
{
    public Text highscoretext, deathstext;

    // Start is called before the first frame update
    void Start()
    {
        highscoretext.text = "High Score: " + score.highscore;
        deathstext.text = "Deaths: " + PlayerPrefs.GetInt("Deaths", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
