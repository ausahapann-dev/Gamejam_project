using UnityEngine;

public class Fog : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FogFaint();
        }
    }
    public void FogFaint()
    {
        BlackFadeFailed.instance.Activate();
    }
}
