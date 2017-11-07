using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptonsController : MonoBehaviour {
    public LevelManager levelManager;
    public Slider volumeSlider;
    public Slider difficultySlider;
    public Text volumeDisplay;
    public Text difficultyDisplay;

    private MusicManager musicManager;

    // Use this for initialization
    void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();

        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}

    void Update ()
    {
        float currentVolume = volumeSlider.value;
        float currentDifficulty = difficultySlider.value;
        musicManager.SetVolume(currentVolume);

        if (volumeDisplay)
        {
            volumeDisplay.text = Mathf.Round(currentVolume * 100).ToString();
        }

        if (difficultyDisplay)
        {
            difficultyDisplay.text = currentDifficulty.ToString();
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);

        levelManager.LoadScene("Start");
    }

    public void SetDefaults()
    {
        volumeSlider.value = 0.8f;
        difficultySlider.value = 1f;
    }
}
