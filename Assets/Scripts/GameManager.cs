using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI achievedPointsText;
    public TextMeshProUGUI achievedPlaceText;

    private int _placeTakenOnLeaderboard;

    void Start()
    {
        if (!System.IO.File.Exists(Application.dataPath+"/saveFile.json"))
        {
            HighScoreLogic.HighScores highScores = new HighScoreLogic.HighScores();
            highScores.highScoresList = new List<int>() { 0,0,0,0,0,0,0,0,0,0};
            highScores.gamesPlayed = 0;
            string json = JsonUtility.ToJson(highScores);
            File.WriteAllText(Application.dataPath+"/saveFile.json", json);
        }
        GameObject.Find("Canvas").transform.Find("Button").gameObject.SetActive(true);
    }
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length != 0) return;
        string json = File.ReadAllText(Application.dataPath+"/saveFile.json");
        HighScoreLogic.HighScores highScores = JsonUtility.FromJson<HighScoreLogic.HighScores>(json);
        for (int i = 9; i >= 0; i--)
        {
            if (PointLogic.PointsProperty >= highScores.highScoresList[i] && i != 0) continue;
            if (i == 9) break;
            
            highScores.highScoresList.RemoveAt(9);
            if (PointLogic.PointsProperty >= highScores.highScoresList[i] && i == 0)
            {
                highScores.highScoresList.Insert(0, PointLogic.PointsProperty);
                _placeTakenOnLeaderboard = 1;
                break;
            }
            else 
            {
                highScores.highScoresList.Insert(i+1, PointLogic.PointsProperty);
                _placeTakenOnLeaderboard = i+2;
                break;
            }
        }

        highScores.gamesPlayed++;
        json = JsonUtility.ToJson(highScores);
        Debug.Log(json);
        File.WriteAllText(Application.dataPath+"/saveFile.json", json);
        achievedPointsText.text += PointLogic.PointsProperty + " points!";
        achievedPlaceText.text = "You achieved " + _placeTakenOnLeaderboard + " place!";
        GameObject.Find("Canvas").transform.Find("RawImage").transform.Find("PointsText").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("Button").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("EndScreen").gameObject.SetActive(true);
        GameObject.Find("Player").gameObject.SetActive(false);
        if(_placeTakenOnLeaderboard==0) achievedPlaceText.gameObject.SetActive(false);
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
