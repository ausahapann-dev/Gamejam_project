using Unity.VisualScripting;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    public float parallaxStrength = 0.5f;
    private Transform screen;


    void Update()
    {
        if (screen == null)
        {
            screen = CameraInstance.instance.transform;
            return;
        }

        transform.position = new Vector3(screen.position.x, screen.position.y, transform.position.z / parallaxStrength) * parallaxStrength;
    }
}
