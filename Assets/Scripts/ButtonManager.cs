using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void StartGameButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void StatButton()
    {
        GameObject.Find("Canvas").transform.Find("MainMenu").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("StatScreen").gameObject.SetActive(true);
    }

    public void BackButton()
    {
        GameObject.Find("Canvas").transform.Find("StatScreen").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("MainMenu").gameObject.SetActive(true);
    }
}
