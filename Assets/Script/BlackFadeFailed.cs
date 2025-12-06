using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlackFadeFailed : MonoBehaviour
{
    public static BlackFadeFailed instance;
    public Coroutine onFading;

    public Image render;
    private float fadetime = 0.3f;
    void Awake()
    {
        instance = this;
    }
    public void Activate()
    {
        if (onFading == null)
        {
            onFading = StartCoroutine(Fade());
        }
    }
    public void FadeReset()
    {
        render.color = new Color(0, 0, 0, 0);
    }
    public IEnumerator Fade()
    {
        Color startColor = new Color(0f, 0f, 0f, 0f);
        float timer = 0f;

        while (timer < fadetime)
        {
            timer += Time.deltaTime;
            float newAlpha = Mathf.Lerp(0f, 1f, timer / fadetime);
            render.color = new Color(0f, 0f, 0f, newAlpha);
            yield return null;
        }
        render.color = Color.black;
        yield return new WaitForSeconds(1f);
        LoadStarterScene.instance.StageFailed();
        yield return new WaitForSeconds(5f);
    }
}
