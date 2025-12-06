using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jump_force = 10f;
    public Rigidbody2D rb;
    public bool isJumped = false;

    private void Update()
    {
        if (InputBlock.instance.GetInputBlockStatus())
        {
            return;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumped = false;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (InputBlock.instance.GetInputBlockStatus())
            {
                return;
            }

            if (Input.GetKey(KeyCode.Space) && !isJumped)
            {
                if (Input.GetKey(KeyCode.S))
                {
                    isJumped = true;
                }
                else
                {
                    isJumped = true;
                    PlayerJump();
                }
            }
        }
    }

    public void PlayerJump()
    {
        gameObject.GetComponent<Dash>().CancelDash();
        rb.linearVelocityY = jump_force;
    }
}
