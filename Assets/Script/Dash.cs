using System.Collections;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float gravity_scale = 0f;
    public float dash_force = 10f;
    public float dash_time = 0.2f;
    public float dash_cooldown = 0.5f;
    public float dash_timer = 0f;
    public bool DashAvailable = true;
    public bool isDashing = false;
    public bool isRight = true;
    public Rigidbody2D rb;

    private Coroutine DashingState;

    private void Start()
    {
        gravity_scale = rb.gravityScale;
    }
    private void Update()
    {
        dash_timer += Time.deltaTime;

        if (InputBlock.instance.GetInputBlockStatus())
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            isRight = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            isRight = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (DashAvailable && dash_timer > dash_cooldown)
            {
                PlayerDash();
                dash_timer = 0f;
                DashAvailable = false;
                isDashing = true;
            }
        }
    }
    public void PlayerDash()
    {
        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0;
        if (isRight)
        {
            rb.linearVelocityX = dash_force;
        }
        else
        {
            rb.linearVelocityX = -dash_force;
        }
        DashingState = StartCoroutine(DashState(dash_time));
    }

    public void DashReset()
    {
        DashAvailable = true;
    }

    public void CancelDash()
    {
        if (DashingState != null)
        {
            StopCoroutine(DashingState);
            rb.gravityScale = gravity_scale;
            isDashing = false;
        }
    }
    public IEnumerator DashState(float dash_time)
    {
        yield return new WaitForSeconds(dash_time);
        rb.gravityScale = gravity_scale;
        isDashing = false;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            DashAvailable = true;
        }
    }
}
