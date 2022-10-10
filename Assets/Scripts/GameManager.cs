using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    

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
                break;
            }
            else 
            {
                highScores.highScoresList.Insert(i+1, PointLogic.PointsProperty);
                break;
            }
        }

        highScores.gamesPlayed++;
        json = JsonUtility.ToJson(highScores);
        Debug.Log(json);
        File.WriteAllText(Application.dataPath+"/saveFile.json", json);
        /*for (int i = 9; i >= 0; i--)
        {
            if (PointLogic.PointsProperty >= HighScoreLogic.highScoreList[i] && i != 0) continue;
            if (i == 9) break;
            HighScoreLogic.highScoreList.Remove(10);
            if (PointLogic.PointsProperty >= HighScoreLogic.highScoreList[i] && i == 0)
            {
                HighScoreLogic.highScoreList.Insert(0, PointLogic.PointsProperty);
                break;
            }
            HighScoreLogic.highScoreList.Insert(i+1, PointLogic.PointsProperty);
        }

        for (int i = 0; i < 10; i++)
        {
            if (PointLogic.PointsProperty >= HighScoreLogic.highScoreList[i])
            {
                HighScoreLogic.highScoreList.Remove(HighScoreLogic.highScoreList.Capacity-1);
                HighScoreLogic.highScoreList.Insert(i, PointLogic.PointsProperty);
                break;
            }
        }
        
        if (PointLogic.PointsProperty >= HighScoreLogic.highScoreList[9])
        {
            string text="";
            for (int i = 0; i < 10; i++)
            {
                text += HighScoreLogic.highScoreList[i] + ",\n";
            }

            text += HighScoreLogic.highScoreList[10]+1;
            File.WriteAllText("Assets/highscores.txt", text);
        }*/
        SceneManager.LoadScene("MenuScene");
    }
}
