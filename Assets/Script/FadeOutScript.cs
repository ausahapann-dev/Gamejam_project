using System.Collections;
using UnityEngine;

public class FadeOutScript : MonoBehaviour
{
    public SpriteRenderer render;
    public float fadetime = 1f;

    public void CallFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeOut()
    {
        Color startColor = render.color;
        float timer = 0f;

        while (timer < fadetime)
        {
            timer += Time.deltaTime;
            float newAlpha = Mathf.Lerp(1f, 0f, timer / fadetime);
            render.color = new Color(startColor.r, startColor.g, startColor.b, newAlpha);
            yield return null;
        }
        render.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
        gameObject.SetActive(false);
    }       
}
