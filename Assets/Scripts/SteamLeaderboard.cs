using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Steamworks;
using Steamworks.Data;

public class SteamLeaderboard : MonoBehaviour
{
    public Transform Entry;
    public Transform Container;
    bool DoesRankingIncludeMe = false;
    
    // Start is called before the first frame update
    void Start()
    {
        GetLeaderBoard();
    }

    public async void GetLeaderBoard()
    {
        var leaderboard = await SteamUserStats.FindLeaderboardAsync("TopHighScoresLeaderBoard");
        if (leaderboard.HasValue)
        {
            var lb = leaderboard.Value;
            await lb.SubmitScoreAsync(PlayerPrefs.GetInt("highscore", 0));
            var globalScores = await lb.GetScoresAsync(9);


            Entry.gameObject.SetActive(false);
            int i = 0;

            foreach (var e in globalScores)
            {
                if (e.User.IsMe)
                {
                    DoesRankingIncludeMe = true;
                }

                Transform EntryTransform = Instantiate(Entry, Container);
                RectTransform EntryRectTransform = EntryTransform.GetComponent<RectTransform>();
                EntryRectTransform.anchoredPosition = new Vector2(0, -20f * i);
                i = i + 1;
                EntryTransform.gameObject.SetActive(true);
                
                if (e.User.IsMe)
                {
                    EntryTransform.Find("PosEntry").GetComponent<Text>().text = e.GlobalRank.ToString();
                    EntryTransform.Find("NameEntry").GetComponent<Text>().text = e.User.Name;
                    EntryTransform.Find("ScoreEntry").GetComponent<Text>().text = e.Score.ToString();

                    EntryTransform.Find("PosEntry").GetComponent<Text>().color = UnityEngine.Color.yellow;
                    EntryTransform.Find("NameEntry").GetComponent<Text>().color = UnityEngine.Color.yellow;
                    EntryTransform.Find("ScoreEntry").GetComponent<Text>().color = UnityEngine.Color.yellow;
                }
                else
                {
                    EntryTransform.Find("PosEntry").GetComponent<Text>().text = e.GlobalRank.ToString();
                    EntryTransform.Find("NameEntry").GetComponent<Text>().text = e.User.Name;
                    EntryTransform.Find("ScoreEntry").GetComponent<Text>().text = e.Score.ToString();
                }
            }

            if (!DoesRankingIncludeMe)
            {
                var MyScore = await lb.GetScoresAroundUserAsync(0, 0);

                Transform EntryTransform = Instantiate(Entry, Container);
                RectTransform EntryRectTransform = EntryTransform.GetComponent<RectTransform>();
                EntryRectTransform.anchoredPosition = new Vector2(0, -20f * i);
                i = i + 1;
                EntryTransform.gameObject.SetActive(true);

                foreach (var e in MyScore)
                {
                    EntryTransform.Find("PosEntry").GetComponent<Text>().text = e.GlobalRank.ToString();
                    EntryTransform.Find("NameEntry").GetComponent<Text>().text = e.User.Name;
                    EntryTransform.Find("ScoreEntry").GetComponent<Text>().text = e.Score.ToString();

                    EntryTransform.Find("PosEntry").GetComponent<Text>().color = UnityEngine.Color.yellow;
                    EntryTransform.Find("NameEntry").GetComponent<Text>().color = UnityEngine.Color.yellow;
                    EntryTransform.Find("ScoreEntry").GetComponent<Text>().color = UnityEngine.Color.yellow;
                }
            }
        }
        else
        {
            print("leaderboard not found");
        }
    }
}
