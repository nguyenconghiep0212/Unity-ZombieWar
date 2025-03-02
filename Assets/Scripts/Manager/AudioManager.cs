using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public static float DefaultBgmVolumeScale = 1f;
    public static float DefaultSfxVolumeScale = 1;


    [SerializeField] private string m_BgmPath = "Audio/Bgm";
    [SerializeField] private string m_SfxPath = "Audio/Sfx";
    [SerializeField] internal AudioSource m_BgmSource;
    [SerializeField] internal AudioSource m_SfxSource;

    private Dictionary<string, AudioClip> m_AudioDict = new Dictionary<string, AudioClip>();

    private void Start()
    {
        StopAllCoroutines();
        Background();
    }

    public void PlaySfx(string audioName, float volumeScale = 1f, bool oneShot = true, bool isLoop = false, float delay = 0, Action actionMoveCam = null)
    {
        if (GameManager.Instance.userData.soundOn)
            StartCoroutine(CoroutinePlaySFX(audioName, volumeScale, oneShot, isLoop, delay, actionMoveCam));
    }

    private IEnumerator CoroutinePlaySFX(string audioName, float volumeScale = 1f, bool oneShot = true, bool isLoop = false, float delay = 0, Action actionMoveCam = null)
    {

        yield return new WaitForSeconds(delay);
        CacheClip(m_SfxPath, audioName);

        m_SfxSource.volume = DefaultSfxVolumeScale * volumeScale;
        if (oneShot)
        {
            m_SfxSource.PlayOneShot(m_AudioDict[audioName], m_SfxSource.volume);
        }
        if (isLoop)
        {
            m_SfxSource.loop = isLoop;
            m_SfxSource.clip = m_AudioDict[audioName];
            m_SfxSource.Play();
        }
    }
    public float GetLength(AudioClip audioClip)
    {
        return audioClip.length;
    }

    public void PlayBgm(string audioName)
    {
        m_BgmSource.volume = DefaultBgmVolumeScale ;

        bool currentClipNull = (m_BgmSource.clip == null);
        bool sameCurrentClip = (!currentClipNull && m_BgmSource.clip.name == audioName);

        if (sameCurrentClip)
        {
            if (!m_BgmSource.isPlaying)
            {
                m_BgmSource.Play();
            }
        }
        else
        {
            if (!currentClipNull)
            {
                StopBgm(true);
            }
            m_BgmSource.clip = Resources.Load<AudioClip>(System.IO.Path.Combine(m_BgmPath, audioName));
            m_BgmSource.Play();
        }
    }

    public void StopBgm(bool clearClip = false)
    {
        if (m_BgmSource.isPlaying)
        {
            m_BgmSource.Stop();
        }

        if (clearClip && m_BgmSource.clip != null)
        {
            Resources.UnloadAsset(m_BgmSource.clip);
            m_BgmSource.clip = null;
        }
    }

    public void CacheClip(string path, string audioName)
    {
        if (!m_AudioDict.ContainsKey(audioName))
        {
            AudioClip clip = Resources.Load<AudioClip>(System.IO.Path.Combine(path, audioName));
            if (clip == null) { Debug.LogError("audioclip not found " + System.IO.Path.Combine(path, audioName)); }
            m_AudioDict.Add(audioName, clip);
        }
    }

    public void ClearCacheClip(string audioName, bool unloadClip)
    {
        if (m_AudioDict.ContainsKey(audioName))
        {
            if (unloadClip)
            {
                Resources.UnloadAsset(m_AudioDict[audioName]);
            }
            m_AudioDict.Remove(audioName);
        }
    }

    public void ClearCacheAllClip()
    {
        foreach (var item in m_AudioDict)
        {
            Resources.UnloadAsset(item.Value);
        }
        m_AudioDict.Clear();
    }

    public void ToggleBackgroundMusic()
    {
        if (GameManager.Instance.userData.musicOn)
        {
            DefaultBgmVolumeScale = 1;
        }
        else
        {
            DefaultBgmVolumeScale = 0;
        }
        m_BgmSource.volume = DefaultBgmVolumeScale;
    }

    // BAXKGROUND MUSIC
    public void Background()
    {
        PlayBgm("Background 1");
    }

    // SOUND EFFECT
    public void ChimpTestRight()
    {
        PlaySfx("ChimpTest_Right");
    }
    public void ChimpTestWrong()
    {
        PlaySfx("ChimpTest_Wrong");
    }
    public void LevelBegin()
    {
        PlaySfx("LevelBegin");
    }
    public void LevelEnd()
    {
        PlaySfx("LevelEnd");
    }
    public void PuzzleSpin()
    {
        PlaySfx("PuzzleSpin");
    }
    public void HomeClickSfx()
    {
        PlaySfx("ButtonMenu");
    }
    public void ButtonClickSfx()
    {
        PlaySfx("Button");
    }
    public void CardFlipSfx()
    {
        PlaySfx("Card Flip");
    }
    public void RoboticFlowRemoveSfx()
    {
        PlaySfx("Robotic Flow Remove");
    }
    public void RoboticFlowConnectSfx()
    {
        PlaySfx("Robotic Flow Connect");
    }
}