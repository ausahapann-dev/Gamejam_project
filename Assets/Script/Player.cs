using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    private void Awake()
    {
        instance = this;
    }

    public float GetY()
    {
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Space))
        {
            return transform.position.y - 0.5f;
        }
        else
        {
            return transform.position.y - 0.1f;
        }
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fog"))
        {
            collision.gameObject.GetComponent<FadeOutScript>().CallFadeOut();
        }
    }
}
