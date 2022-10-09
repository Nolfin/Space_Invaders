using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointLogic : MonoBehaviour
{
    private static int _points;
    public static int PointsProperty {
        get => _points;
        set
        {
            _points = value;
            pointsOnChange();
        }
    }

    static void pointsOnChange()
    {
        GameObject.Find("Canvas").transform.Find("PointsText").GetComponent<TextMeshProUGUI>().text = _points.ToString();
    }
    
    
}
