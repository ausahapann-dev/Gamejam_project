using TMPro;
using UnityEngine;
using System.Collections;

public class TextFadeOutScript : MonoBehaviour
{
    public static TextFadeOutScript instance;

    public TextMeshProUGUI commentaryText;
    public float fadetime = 1f;

    private Coroutine fadeOutCoroutine;
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        fadeOutCoroutine = null;
    }
    public void CallFadeOut(string text)
    {
        commentaryText.text = text;
        commentaryText.color = Color.white;
        if(fadeOutCoroutine != null)
        {
            StopCoroutine(fadeOutCoroutine);
        }
        fadeOutCoroutine = StartCoroutine(FadeOut());
    }
    public IEnumerator FadeOut()
    {
        Color startColor = commentaryText.color;
        float timer = 0f;

        while (timer < fadetime)
        {
            timer += Time.deltaTime;
            float newAlpha = Mathf.Lerp(1f, 0f, timer / fadetime);
            commentaryText.color = new Color(startColor.r, startColor.g, startColor.b, newAlpha);
            yield return null;
        }
        commentaryText.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
    }

}
