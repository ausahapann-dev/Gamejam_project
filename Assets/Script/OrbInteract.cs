using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class OrbInteract : MonoBehaviour
{
    public Vector2 launchDir;
    public bool interactable = false;

    private GameObject player;
    private Coroutine blockState;

    private void Update()
    {
        if (player != null && interactable && Input.GetKeyDown(KeyCode.Mouse0))
        {
            player.GetComponent<Launch>().LaunchPlayer(launchDir);
            if (blockState != null)
            {
                StopCoroutine(blockState);
            }
            blockState = StartCoroutine(InputBlockState());
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.transform.parent.gameObject;
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

    public IEnumerator InputBlockState()
    {
        InputBlock.instance.SetInputBlockStatus(true);
        yield return new WaitForSeconds(0.2f);
        InputBlock.instance.SetInputBlockStatus(false);
    }
}
