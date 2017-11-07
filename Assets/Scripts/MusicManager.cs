using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MusicManager : MonoBehaviour {
    public AudioClip[] levelMusic;

    private AudioSource audioSource;
    private AudioClip currentClip;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start ()
    {
        audioSource = this.GetComponent<AudioSource>();
        SetVolume(PlayerPrefsManager.GetMasterVolume());
        SceneManager.sceneLoaded += OnSceneLoaded;
	}

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    private void OnSceneLoaded (Scene scene, LoadSceneMode mode)
    {
        PlaySceneMusicByIndex(scene.buildIndex);
    }

    private void PlaySceneMusicByIndex (int index)
    {
        if (levelMusic.Length - 1 > index)
        {
            AudioClip currentSceneMusic = levelMusic[index];
            if (currentSceneMusic && currentSceneMusic != currentClip)
            {
                currentClip = currentSceneMusic;
                PlayClip(currentSceneMusic);
            }
        }
    }

    private void PlayClip(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.PlayOneShot(clip);
    }
}
