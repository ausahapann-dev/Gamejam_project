using UnityEngine;

public class DoorLv0 : MonoBehaviour
{
    public GameObject CutterObj;
    public bool interactable = false;

    private bool interacted = false;

    private void Update()
    {
        if (interactable && Input.GetKeyDown(KeyCode.E) && !interacted)
        {
            interacted = true;
            CutterObj.SetActive(true);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactable = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactable = false;
        }
    }
}
