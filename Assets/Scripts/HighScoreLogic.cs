using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class HighScoreLogic : MonoBehaviour
{
    public TextMeshProUGUI records;
    public TextMeshProUGUI gamesPlayedText;

    void Start()
    {
        string json = File.ReadAllText(Application.dataPath+"/saveFile.json");
        HighScores highScores = JsonUtility.FromJson<HighScores>(json);
        for (int i = 0; i < 10; i++)
        {
            records.text += (i + 1) + ". " + highScores.highScoresList[i]+"\n";
        }

        gamesPlayedText.text += highScores.gamesPlayed;
        /*string text = File.ReadAllText("Assets/highscores.txt");
        char[] separators = {','};
        string[] strValues = text.Split(separators);
        foreach (string str in strValues)
        {
            int val = 0;
            if(int.TryParse(str, out val)) highScoreList.Add(val);
            Debug.Log(val);
        }

        for (int i = 0; i < 10; i++)
        {
            records.text += (i + 1) + ". " + highScoreList[i]+"\n";
        }*/
    }

    public class HighScores
    {
        public List<int> highScoresList = new List<int>();
        public int gamesPlayed;
    }
}
