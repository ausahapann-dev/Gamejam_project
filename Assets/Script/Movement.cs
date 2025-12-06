using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    private float movementX = 0;

    void Update()
    {
        if (InputBlock.instance.GetInputBlockStatus())
        {
            return;
        }

        movementX = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * movementX * speed * Time.deltaTime;
    }

    public float GetInputX()
    {
        return movementX;
    }
}
