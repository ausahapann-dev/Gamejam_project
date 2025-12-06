using UnityEngine;

public class InputBlock : MonoBehaviour
{
    public static InputBlock instance;
    public bool inputBlocked = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void SetInputBlockStatus(bool status)
    {
        inputBlocked = status;
    }

    public bool GetInputBlockStatus()
    {
        return inputBlocked;
    }
}
