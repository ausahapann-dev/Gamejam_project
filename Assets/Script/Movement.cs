using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    private float movementX = 0;

    public Rigidbody2D rb;
    public Animator animator;

    void Update()
    {
        if (InputBlock.instance.GetInputBlockStatus())
        {
            return;
        }

        movementX = Input.GetAxis("Horizontal");
        rb.linearVelocityX = movementX * speed;
        animator.SetFloat("Speed", Mathf.Abs(movementX));
    }

    public float GetInputX()
    {
        return movementX;
    }
}
