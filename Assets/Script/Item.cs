using UnityEngine;

public class Item : MonoBehaviour
{
    public string commentary;
    public GameObject UIstuff;
    public bool interactable = false;

    private void Update()
    {
        if (interactable && Input.GetKeyDown(KeyCode.E))
        {
            TextFadeOutScript.instance.CallFadeOut(commentary);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactable = true;
            UIstuff.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactable = false;
            UIstuff.SetActive(false);
        }
    }
}
