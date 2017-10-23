using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MusicManager : MonoBehaviour {
    public bool musicIsMuted = false;
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
	}

    public bool OnEnable ()
    {
        if (currentClip != null)
        {
            PlayClip(currentClip);
        }
        else
        {
            PlaySceneMusicByIndex(SceneManager.GetActiveScene().buildIndex);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
        musicIsMuted = false;

        return musicIsMuted;
    }

    public bool OnDisable ()
    {
        audioSource.Stop();
        SceneManager.sceneLoaded -= OnSceneLoaded;
        musicIsMuted = true;

        return musicIsMuted;
    }

    public bool ToggleMusic ()
    {
        if (musicIsMuted)
        {
            return OnEnable();
        }
        else
        {
            return OnDisable();
        }
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
