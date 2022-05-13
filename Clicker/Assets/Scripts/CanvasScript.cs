using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public void StartGame()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
    }
    public void ToMainMenu()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
    }
    public void OpenPanel(Image panel)
    {
        panel.gameObject.SetActive(true);
    }
    public void ClosePanel(Image panel)
    {
        panel.gameObject.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}