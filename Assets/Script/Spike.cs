using System.Collections;
using UnityEngine;

public class SpikeLv1 : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpikeDamage();
        }
    }

    public void SpikeDamage()
    {
        BlackFadeClear.instance.Activate();
    }
}
