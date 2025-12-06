using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    private float cameraZoom = 6f;
    private float cameraLerpSpeed1 = 4f;
    private float cameraLerpSpeed2 = 2.5f;
    private float cameraZOffset = -10f;
    private float cameraYOffset = 2f;

    void Update()
    {
        cameraYOffset = cameraZoom / 1.5f - 1f;
        transform.position = Vector3.Lerp(transform.position, player.position + Vector3.up * cameraYOffset + Vector3.forward * cameraZOffset, Time.deltaTime * cameraLerpSpeed1);
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, cameraZoom, Time.deltaTime * cameraLerpSpeed2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CameraZone"))
        {
            Debug.Log("Collider Entered");
            cameraZoom = collision.GetComponent<CameraZone>().zoomLevel;
        }
    }
}
