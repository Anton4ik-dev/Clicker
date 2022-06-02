using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject game;
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject tutor;

    [HideInInspector] public const string MIXER_MUSIC = "MusicVolume";
    [HideInInspector] public const string MIXER_SFX = "SFXVolume";
    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat(AudioManagerScript.MUSIC_KEY, 1f);
        sfxSlider.value = PlayerPrefs.GetFloat(AudioManagerScript.SFX_KEY, 1f);
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManagerScript.MUSIC_KEY, musicSlider.value);
        PlayerPrefs.SetFloat(AudioManagerScript.SFX_KEY, sfxSlider.value);
    }
    public void StartGame()
    {
        AudioManagerScript.sfxSound.Play();
        EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Continue";
        mainMenu.SetActive(false);
        game.SetActive(true);
    }
    public void Pause()
    {
        AudioManagerScript.sfxSound.Play();
        pause.SetActive(true);
        Time.timeScale = 0;
    }
    public void Continue()
    {
        AudioManagerScript.sfxSound.Play();
        pause.SetActive(false);
        game.SetActive(true);
        Time.timeScale = 1;
    }
    public void ToSettings(string FromWhere)
    {
        AudioManagerScript.sfxSound.Play();
        if (FromWhere == "menu")
            mainMenu.SetActive(false);
        else if(FromWhere == "pause")
            pause.SetActive(false);
        settings.SetActive(true);
        settings.transform.GetChild(2).GetComponent<Button>().onClick.RemoveAllListeners();
        settings.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => TurnOn(FromWhere));
    }
    private void TurnOn(string FromWhere)
    {
        AudioManagerScript.sfxSound.Play();
        if (FromWhere == "menu")
            mainMenu.SetActive(true);
        else if (FromWhere == "pause")
            pause.SetActive(true);
        settings.SetActive(false);
    }
    public void ToMainMenu()
    {
        AudioManagerScript.sfxSound.Play();
        mainMenu.SetActive(true);
        pause.SetActive(false);
        game.SetActive(false);
        Time.timeScale = 1;
    }
    public void Fin()
    {
        AudioManagerScript.sfxSound.Play();
        SceneManager.LoadScene(0);
    }
    public void OpenPanel(Image panel)
    {
        panel.gameObject.SetActive(true);
    }
    public void ClosePanel(Image panel)
    {
        AudioManagerScript.sfxSound.Play();
        panel.gameObject.SetActive(false);
    }
    public void Exit()
    {
        AudioManagerScript.sfxSound.Play();
        Application.Quit();
    }
    public void PlaySFX()
    {
        AudioManagerScript.sfxSound.Play();
    }
    public void SetMusicVolume()
    {
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(musicSlider.value) * 20);
    }
    public void SetSFXVolume()
    {
        
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(sfxSlider.value) * 20);
    }
}