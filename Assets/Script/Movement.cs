using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    private float movementX = 0;
    private float dash_velocity;

    public Rigidbody2D rb;
    public Animator animator;

    void Update()
    {
        if (InputBlock.instance.GetInputBlockStatus())
        {
            return;
        }

        movementX = Input.GetAxis("Horizontal");
        rb.linearVelocityX = movementX * speed + dash_velocity;
        animator.SetFloat("Speed", Mathf.Abs(movementX));
    }

    public float GetInputX()
    {
        return movementX;
    }

    public void SetDashVelocity(float value)
    {
        dash_velocity = value;
    }
    public void SetLaunchVelocity(Vector2 value)
    {
        rb.linearVelocityX += value.x;
        rb.linearVelocityY += value.y;
    }

    public void StopMovement()
    {
        rb.linearVelocityX = 0; 
        rb.linearVelocityY = 0;
        dash_velocity = 0;
    }
}
