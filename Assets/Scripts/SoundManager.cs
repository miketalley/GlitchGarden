using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {
    public Text musicMuteStatus;
    private MusicManager musicManager;

    private void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();
        SetMusicMuteText(musicManager.musicIsMuted);
    }

    public void ToggleMusic()
    {
        bool isMuted = musicManager.ToggleMusic();
        SetMusicMuteText(isMuted);
    }

    private void SetMusicMuteText(bool isMuted)
    {
        if (isMuted)
        {
            musicMuteStatus.text = "music off";
            musicMuteStatus.color = Color.red;
        }
        else
        {
            musicMuteStatus.text = "music on";
            musicMuteStatus.color = Color.green;
        }
    }

}
