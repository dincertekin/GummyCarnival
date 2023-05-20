using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroTextFade : MonoBehaviour
{
    public Text introText;
    public float fadeDuration = 2f;

    private void Start()
    {
        introText.color = Color.clear;
        StartCoroutine(FadeInText());
    }

    private System.Collections.IEnumerator FadeInText()
    {
        float elapsedTime = 0f;
        Color initialColor = Color.clear;
        Color targetColor = Color.white;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime / fadeDuration;
            introText.color = Color.Lerp(initialColor, targetColor, elapsedTime);
            yield return null;
        }

        yield return new WaitForSeconds(2f);

        StartCoroutine(FadeOutText());
    }

    private System.Collections.IEnumerator FadeOutText()
    {
        float elapsedTime = 0f;
        Color initialColor = Color.white;
        Color targetColor = Color.clear;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime / fadeDuration;
            introText.color = Color.Lerp(initialColor, targetColor, elapsedTime);
            yield return null;
        }

        SceneManager.LoadScene("MainGameScene");
    }
}
