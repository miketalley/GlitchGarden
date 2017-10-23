using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {
    public float fadeInTime;
    public float fadeOutAfter;
    public float fadeOutTime;

    private Image fadePanel;
    private Color currentColor = Color.black;

	void Start () {
        fadePanel = GetComponent<Image>();	
	}
	
	void Update () {
		if (Time.timeSinceLevelLoad < fadeInTime)
        {
            float alphaChange = Time.deltaTime / fadeInTime;
            currentColor.a -= alphaChange;
            fadePanel.color = currentColor;
        }
        else if (fadeOutAfter > 0 && Time.timeSinceLevelLoad > fadeOutAfter)
        {
            float alphaChange = Time.deltaTime / fadeOutTime;
            currentColor.a += alphaChange;
            fadePanel.color = currentColor;
        }
        else if (fadeOutAfter == 0)
        {
            gameObject.SetActive(false);
        }
	}
}
