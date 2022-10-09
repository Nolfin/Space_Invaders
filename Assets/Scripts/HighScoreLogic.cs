using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class HighScoreLogic : MonoBehaviour
{
    public static List<int> highScoreList = new List<int>(10);

    public TextMeshProUGUI records;

    void Start()
    {
        string text = File.ReadAllText("Assets/highscores.txt");
        char[] separators = {','};
        string[] strValues = text.Split(separators);
        foreach (string str in strValues)
        {
            int val = 0;
            if(int.TryParse(str, out val)) highScoreList.Add(val);
        }

        for (int i = 0; i < 10; i++)
        {
            records.text += (i + 1) + ". " + highScoreList[i]+"\n";
        }
    }
}
