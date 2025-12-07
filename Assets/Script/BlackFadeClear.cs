using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlackFadeClear : MonoBehaviour
{
    public static BlackFadeClear instance;
    public Coroutine onFading;

    public Image render;
    private float fadetime = 0.3f;
    void Awake()
    {
        instance = this;
    }

    public void Activate()
    {
        if (onFading == null && BlackFadeFailed.instance.onFading == null && WhireFadeClear.instance.onFading == null)
        {
            onFading = StartCoroutine(Fade());
        }
    }
    public void FadeReset()
    {
        render.color = new Color(0,0,0,0);
    }
    public IEnumerator Fade()
    {
        Color startColor = Color.red;
        float timer = 0f;

        while (timer < fadetime)
        {
            timer += Time.deltaTime;
            float newAlpha = Mathf.Lerp(1f, 0f, timer / fadetime);
            render.color = new Color(newAlpha, 0f, 0f, 1f);
            yield return null;
        }
        render.color = Color.black;
        yield return new WaitForSeconds(1f);
        LoadStarterScene.instance.StageCleared();
        yield return new WaitForSeconds(5f);
    }
}
