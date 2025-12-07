using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WhireFadeClear : MonoBehaviour
{
    public static WhireFadeClear instance;
    public Coroutine onFading;

    public Image render;
    private float fadetime = 0.3f;
    void Awake()
    {
        instance = this;
    }
    public void Activate()
    {
        if (onFading == null && BlackFadeClear.instance.onFading == null && BlackFadeFailed.instance.onFading == null)
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
            render.color = new Color(newAlpha, newAlpha, newAlpha, newAlpha);
            yield return null;
        }
        render.color = Color.white;
        yield return new WaitForSeconds(1f);
        LoadStarterScene.instance.StageCleared();
        yield return new WaitForSeconds(5f);
    }
}
