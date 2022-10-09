using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length != 0) return;
        for (int i = 9; i >= 0; i--)
        {
            if (PointLogic.PointsProperty >= HighScoreLogic.highScoreList[i] && i != 0) continue;
            if (i == 9) break;
            HighScoreLogic.highScoreList.Remove(10);
            if (i == 0)
            {
                HighScoreLogic.highScoreList.Insert(0, PointLogic.PointsProperty);
                break;
            }
            HighScoreLogic.highScoreList.Insert(i+1, PointLogic.PointsProperty);
        }

        if (PointLogic.PointsProperty >= HighScoreLogic.highScoreList[9])
        {
            string text="";
            for (int i = 0; i < 10; i++)
            {
                text += HighScoreLogic.highScoreList[i];
                if (i != 9) text += ",\n";
            }
            File.WriteAllText("Assets/highscores.txt", text);
        }
        SceneManager.LoadScene("MenuScene");
    }
}
