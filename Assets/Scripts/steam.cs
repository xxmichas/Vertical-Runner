using Steamworks;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class steam : MonoBehaviour
{

    public GameObject Error;

    // Start is called before the first frame update
    void Start()
    {

        GameObject[] objs = GameObject.FindGameObjectsWithTag("steam");

        if (objs.Length > 1)
        {

        }
        else
        {
            try
            {
                SteamClient.Init(1291740);


                PlayerPrefs.SetInt("Connected", 1);

                if (SteamUserStats.GetStatInt("highscore") >= PlayerPrefs.GetInt("highscore", 0))
                {
                    score.highscore = SteamUserStats.GetStatInt("highscore");
                }
                else
                {
                    score.highscore = PlayerPrefs.GetInt("highscore", 0);
                }
                PlayerPrefs.SetInt("highscore", score.highscore);

                if (SteamUserStats.GetStatInt("deaths") >= PlayerPrefs.GetInt("Deaths", 0))
                {
                    PlayerPrefs.SetInt("Deaths", SteamUserStats.GetStatInt("deaths"));
                }
                else
                {
                    SteamUserStats.SetStat("deaths", PlayerPrefs.GetInt("Deaths", 0));
                }


                SteamFriends.SetRichPresence("steam_display", "#Menu");
            }
            catch (System.Exception e)
            {
                PlayerPrefs.SetInt("Connected", 0);
                // Couldn't init for some reason (steam is closed etc)
                print("Couldnt connect to Steam");
                Error.gameObject.SetActive(true);
            }

            DontDestroyOnLoad(this.gameObject);
        }

        if (PlayerPrefs.GetInt("Connected", 0) == 0)
        {
            print("error lost connection");
            Error.gameObject.SetActive(true);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        Steamworks.SteamClient.RunCallbacks();
    }

    public static void updatestats(int x)
    {
        try
        {
            if (SteamUserStats.GetStatInt("highscore") >= x)
            {

            }
            else
            {
                SteamUserStats.SetStat("highscore", x);
            }

            if (SteamUserStats.GetStatInt("deaths") >= PlayerPrefs.GetInt("Deaths", 0))
            {
                PlayerPrefs.SetInt("Deaths", SteamUserStats.GetStatInt("deaths"));
            }
            else
            {
                SteamUserStats.SetStat("deaths", PlayerPrefs.GetInt("Deaths", 0));
            }

            print("Stats updated");
        }
        catch (System.Exception e)
        {
            // Couldn't init for some reason (steam is closed etc)
            print("Couldnt connect to Steam");
        }
    }

    public static void steamRPC(int x)
    {
        try
        {
            SteamFriends.SetRichPresence("steam_display", "#Score");
            SteamFriends.SetRichPresence("score", x.ToString());
        }
        catch (System.Exception e)
        {
            // Couldn't init for some reason (steam is closed etc)
            print("Couldnt connect to Steam");
        }
    }

    public Animator ErrorPopup, ErrorMsgAnim, RetryButtonAnim;
    public GameObject ErrorPop;
    public Text Highscoretxt;

    public void RetryToConnect()
    {
        SteamClient.Shutdown();

        try
        {
            SteamClient.Init(1291740);

            PlayerPrefs.SetInt("Connected", 1);

            if (SteamUserStats.GetStatInt("highscore") >= PlayerPrefs.GetInt("highscore", 0))
            {
                score.highscore = SteamUserStats.GetStatInt("highscore");
            }
            else
            {
                score.highscore = PlayerPrefs.GetInt("highscore", 0);
            }
            PlayerPrefs.SetInt("highscore", score.highscore);

            SteamFriends.SetRichPresence("steam_display", "#Menu");

            Highscoretxt.text = "High Score: " + score.highscore;

            print("connected");

            ErrorMsgAnim.Play("ErrorMsgAnimReverse", 0);
            RetryButtonAnim.Play("RetryButtonAnionReverse", 0);
            ErrorPopup.Play("ErrorPopupReverse", 0);
            StartCoroutine(RemovePopup());
        }
        catch (System.Exception e)
        {
            // Couldn't init for some reason (steam is closed etc)
            print("Couldnt connect to Steam");
        }
    }

    IEnumerator RemovePopup()
    {
        yield return new WaitForSeconds(1f);
        ErrorPop.SetActive(false);
    }
}
