using UnityEngine;

public class CameraInstance : MonoBehaviour
{
    public static CameraInstance instance;

    private void Awake()
    {
        instance = this;
    }
}
