using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalConfig : MonoBehaviour
{
    public static GlobalConfig instance;
    public GameObject requestDataUI;
    public bool testNotchDevices;

    public Sprite spHpAlly;
    public Sprite spHpEnemy;

    public bool isTurnOnSound;
    public bool isCacheIrcConsent;

    private void Awake()
    {
        instance = this;
#if UNITY_EDITOR
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
#endif
    }

    private void Start()
    {
        if(PlayerPrefs.GetInt(GameDefine.is_first_opened, 0) == 0)
        {
            PlayerPrefs.SetInt(GameDefine.is_first_opened, 1); 
        }
        //SetUnlockDefaultCharacter();
        isTurnOnSound = PlayerPrefs.GetInt(GameDefine.is_turn_on_sound, 1) == 1;

#if EXISTED_IRON_SOURCE
        //isCacheIrcConsent = PlayerPrefs.GetInt(GameDefine.is_cache_irc_consent, 0) == 1;

        isCacheIrcConsent = true;

        //if (PlayerPrefs.GetInt(GameDefine.is_show_request_data,0) == 0)
        //{
        //    requestDataUI.SetActive(true);
        //}
#else
        isCacheIrcConsent = true;
#endif

        SetUpNotification();
    }

    public int GetLv()
    {
        return PlayerPrefs.GetInt(CONST_STRING.lv, 0);
    }

    public void IncreaseLv()
    {
        PlayerPrefs.SetInt(CONST_STRING.lv, PlayerPrefs.GetInt(CONST_STRING.lv, 0) + 1);
    }

    public void UpdateCoin(float change)
    {
        float coin = PlayerPrefs.GetFloat(CONST_STRING.coin, 0);
        coin += change;
        if (coin <= 0)
            coin = 0;

        PlayerPrefs.SetFloat(CONST_STRING.coin, Mathf.Floor(coin));
    }

    public float GetCoin()
    {
        return PlayerPrefs.GetFloat(CONST_STRING.coin, 0);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }

    public void TurnOnSound()
    {
        PlayerPrefs.SetInt(GameDefine.is_turn_on_sound, 1);
        isTurnOnSound = true;
    }

    public void TurnOffSound()
    {
        PlayerPrefs.SetInt(GameDefine.is_turn_on_sound, 0);
        isTurnOnSound = false;
    }

    private void SetUpNotification()
    {
        if(PlayerPrefs.GetInt(GameDefine.is_set_up_notification, 0) == 0)
        {  
            PlayerPrefs.SetInt(GameDefine.is_set_up_notification, 1);
        }
    }
}