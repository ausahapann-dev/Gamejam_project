using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CutterLv0 : MonoBehaviour
{
    public GameObject cutterScene;
    public GameObject player;
    public bool interactable = false;

    private bool interacted = false;

    private void Update()
    {
        if (interactable && Input.GetKeyDown(KeyCode.E) && !interacted)
        {
            interacted = true;
            StartCoroutine(CutterScene());
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.transform.parent.gameObject;
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

    public IEnumerator CutterScene()
    {
        player.GetComponent<Movement>().StopMovement();
        BlackFade.instance.FadeObjSetActive(true);
        cutterScene.SetActive(true);
        InputBlock.instance.SetInputBlockStatus(true);
        yield return new WaitForSeconds(1f);
        InputBlock.instance.SetInputBlockStatus(false);
        while (true)
        {
            if (Input.anyKeyDown)
            {
                break;
            }
            yield return null;
        }
        BlackFadeClear.instance.Activate();
        BlackFade.instance.FadeObjSetActive(false);
        cutterScene.SetActive(false);
    }
}
