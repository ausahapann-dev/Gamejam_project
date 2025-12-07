using UnityEngine;

public class WhiteFog : MonoBehaviour
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
        WhireFadeClear.instance.Activate();
    }
}
