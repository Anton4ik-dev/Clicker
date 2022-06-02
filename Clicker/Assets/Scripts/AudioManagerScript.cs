using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManagerScript : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    public static AudioSource sfxSound;
    [HideInInspector] public const string MUSIC_KEY = "musicVolume";
    [HideInInspector] public const string SFX_KEY = "sfxVolume";
    public static float delay;
    private void Awake()
    {
        sfxSound = transform.GetChild(0).GetComponent<AudioSource>();
        LoadVolume();
    }
    private void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0)
            ClickFixer.mainTheme.Pause();
    }
    private void LoadVolume()
    {
        mixer.SetFloat(CanvasScript.MIXER_MUSIC, Mathf.Log10(PlayerPrefs.GetFloat(MUSIC_KEY, 1f)) * 20);
        mixer.SetFloat(CanvasScript.MIXER_SFX, Mathf.Log10(PlayerPrefs.GetFloat(SFX_KEY, 1f)) * 20);
    }
}