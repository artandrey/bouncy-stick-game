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
        musicSlider.value = volume;
        myMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
        MusicVolume = volume;
        Debug.Log(volume);
    }
    

    public void SetSFXVolume(float volume)
    {
        SFXSlider.value = volume;
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
        SFXVolume = volume;
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
