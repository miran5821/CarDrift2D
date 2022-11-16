using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] GameObject helpPanel, settingsPanel, storePanel,gameUIPanel,startGameBtn,menuPanel;
    [SerializeField] GameObject player;
    [SerializeField] Image settingsMusic, settingsFx;
    #endregion

    #region START_METHODS
    private void Awake()
    {
        helpPanel.SetActive(false);
        settingsPanel.SetActive(false);
        storePanel.SetActive(false);
        player.SetActive(false);
    }

    #endregion

    #region BUTTON_FUNCTIONS
    public void PlayGame()
    {
        menuPanel.SetActive(false);
        gameUIPanel.SetActive(true);
        startGameBtn.SetActive(true);
        player.SetActive(true);
    }
    public void OpenHelpPanel()
    {
        helpPanel.SetActive(true);
    }

    public void CloseHelpPanel()
    {
        helpPanel.SetActive(false);
    }

    public void OpenStorePanel()
    {
        storePanel.SetActive(true);
    }
    public void CloseStorePanel()
    {
        storePanel.SetActive(false);
        player.GetComponent<SpriteRenderer>().sprite = MarketController.Instance.shopCharacter.GetComponent<Image>().sprite;
    }
    public void OpenSettingsPanel()
    {
        settingsPanel.SetActive(true);
        SetSettingsButton(settingsMusic, Global.Settings.SETTINGS_MUSIC);
        SetSettingsButton(settingsFx, Global.Settings.SETTINGS_FX);       
    }

    public void CloseSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }

    public void ClickSwitchMusic()
    {
        SwitchSettingsButton(settingsMusic, Global.Settings.SETTINGS_MUSIC);
        SoundManager.instance.SetMusic();
    }
    public void ClickSwitchFx()
    {
        SwitchSettingsButton(settingsFx, Global.Settings.SETTINGS_FX);
        SoundManager.instance.SetEffect();
    }
    #endregion

    #region HELPER_FUNCTÝONS
    void SetSettingsButton(Image currentImage,string key) // ses atama 
    {
        int result;
        if (PlayerPrefs.HasKey(key)) // deðer varsa
        {
            result = PlayerPrefs.GetInt(key);
        }
        else
        {
            result = 1;
        }
        PlayerPrefs.SetInt(key,result);
        if (result == 1)
        {
            currentImage.color = Color.white;
        }
        else
        {
            currentImage.color = Color.gray;
        }
    }

    void SwitchSettingsButton(Image currentImage, string key) // ses deðiþtirme
    {
        int result;
        if (PlayerPrefs.HasKey(key)) // deðer varsa
        {
            result = PlayerPrefs.GetInt(key);
        }
        else
        {
            result = 1;
        }
        result = result == 1 ? 0 : 1; // if(result == 1) ise 0 e eþitle deðilse 1 e eþitle
        PlayerPrefs.SetInt(key, result);
        if (result == 1)
        {
            currentImage.color = Color.white;
        }
        else
        {
            currentImage.color = Color.gray;
        }
    }
    #endregion
}
