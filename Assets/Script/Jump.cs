using System.Collections;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jump_force = 10f;
    public Rigidbody2D rb;
    public bool isJumped = false;

    public Animator animator;

    private void Update()
    {
        animator.SetFloat("VSpd", rb.linearVelocityY);

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
                animator.SetBool("Isjumping", true);
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
        rb.linearVelocity = Vector2.zero;
        rb.AddForceY(jump_force, ForceMode2D.Impulse);
        StartCoroutine(Jumping());
    }

    public IEnumerator Jumping()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Isjumping", false);
    }    
}
