using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainButtonScript : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject helpPanel;
    public Canvas collectionCanvas;

    public void StartButtonClick()
    {
        SceneManager.LoadScene("ChapterSelectScene");
    }

    public void CollectionButtonClick()
    {
        collectionCanvas.enabled = true;
    }

    public void ExitButtonClick()
    {
        Application.Quit();
    }

    public void SettingButtonClick()
    {
        settingPanel.SetActive(true);
    }

    public void HelpButtonClick()
    {
        helpPanel.SetActive(true);
    }

    public void HelplBackButtonClick()
    {
        helpPanel.SetActive(false);
    }

}
