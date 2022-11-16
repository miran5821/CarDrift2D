using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource musicSource, effectSource;

    [SerializeField]
    private AudioClip clickSound;

    public static SoundManager instance;

    private bool isMusicMuted;
    private bool IsMusicMuted
    {
        get
        {
            isMusicMuted = PlayerPrefs.HasKey(Global.Settings.SETTINGS_MUSIC)
                ? (PlayerPrefs.GetInt(Global.Settings.SETTINGS_MUSIC) == 0) : false;
            return isMusicMuted;
        }
        set
        {
            PlayerPrefs.SetInt(Global.Settings.SETTINGS_MUSIC, value ? 0 : 1);
            IsMusicMuted = value;
        }
    }

    private bool isEffectMuted;
    private bool IsEffectMuted
    {
        get
        {
            isEffectMuted = PlayerPrefs.HasKey(Global.Settings.SETTINGS_FX)
                ? (PlayerPrefs.GetInt(Global.Settings.SETTINGS_FX) == 0) : false;
            return isEffectMuted;
        }
        set
        {
            PlayerPrefs.SetInt(Global.Settings.SETTINGS_FX, value ? 0 : 1);
            isEffectMuted = value;
        }
    }

   

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        PlayerPrefs.SetInt(Global.Settings.SETTINGS_MUSIC, IsMusicMuted ? 0 : 1);
        PlayerPrefs.SetInt(Global.Settings.SETTINGS_FX, IsEffectMuted ? 0 : 1);
        effectSource.mute = IsEffectMuted;
        musicSource.mute = IsMusicMuted;

        AddButtonSound();
    }

    public void AddButtonSound()
    {
        var button = FindObjectsOfType<Button>(true);
        foreach (var item in button)
        {
            item.onClick.AddListener(() => {
                PlaySound(clickSound);
            });
        }
    }

    public void PlaySound(AudioClip clip)
    {
        if (IsEffectMuted) return;
        effectSource.PlayOneShot(clip);
    }

    public void SetMusic()
    {
        musicSource.mute = IsMusicMuted;
    }

    public void SetEffect()
    {
        effectSource.mute = IsEffectMuted;
    }
}
