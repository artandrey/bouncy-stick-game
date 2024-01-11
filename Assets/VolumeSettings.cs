using System;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private Toggle myToggle;
    [SerializeField]
    private Image musicButtonImage;
    [SerializeField]

    private Image sfxButtonImage;

    private readonly Color red = new Color(243f / 255f, 174f / 255f, 174f / 255f);
    private readonly Color white = Color.white;
    private bool audioIn;
    private float MusicVolume;
    private float SFXVolume;
    readonly float MinVolume = 0.0001f;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume(0);
            SetSFXVolume(0);
        }
    }

    public void SetMusicVolume(float volume)
    {
        MusicVolume = volume;
        musicSlider.value = volume;
        myMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        musicButtonImage.color = MusicVolume == MinVolume ? red : white;
        PlayerPrefs.SetFloat("musicVolume", volume);
        Debug.Log(volume);
    }


    public void SetSFXVolume(float volume)
    {
        SFXVolume = volume;
        SFXSlider.value = volume;
        sfxButtonImage.color = SFXVolume == MinVolume ? red : white;
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
        Debug.Log(volume);
    }

    public void ToggleSFX()
    {
        if (SFXVolume == MinVolume)
        {
            SetSFXVolume(1);
        }
        else
        {
            SetSFXVolume(MinVolume);
        }
    }

    public void ToggleMusic()
    {
        if (MusicVolume == MinVolume)
        {
            SetMusicVolume(1);
        }
        else
        {
            SetMusicVolume(MinVolume);
        }
    }

    public void OnMusicSliderChange()
    {
        SetMusicVolume(musicSlider.value);
    }

    public void OnSFXSliderChange()
    {
        SetSFXVolume(SFXSlider.value);
    }

    private void LoadVolume()
    {
        SetMusicVolume(PlayerPrefs.GetFloat("musicVolume"));
        SetSFXVolume(PlayerPrefs.GetFloat("SFXVolume"));
    }
}
