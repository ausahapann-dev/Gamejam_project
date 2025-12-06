using UnityEngine;

public class BlackFade : MonoBehaviour
{
    public static BlackFade instance;
    public GameObject fadeobj;

    void Awake()
    {
        instance = this;
    }

    public void FadeObjSetActive(bool status)
    {
        fadeobj.SetActive(status);
    }
}
