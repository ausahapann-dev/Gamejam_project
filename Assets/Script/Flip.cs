using UnityEngine;

public class Flip : MonoBehaviour
{
    void FixedUpdate()
    {
        float InputX = gameObject.GetComponent<Movement>().GetInputX();
        if (InputX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (InputX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
