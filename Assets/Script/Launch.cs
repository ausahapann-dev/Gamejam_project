using UnityEngine;
using System.Collections;

public class Launch : MonoBehaviour
{
    public Rigidbody2D rb;
    public float launchPower = 6f;
    public float launch_time = 0.2f;

    public Animator animator;
    private Movement player_movement;

    private Coroutine launchState;

    private void Start()
    {
        player_movement = GetComponent<Movement>();
    }
    public void LaunchPlayer(Vector2 Dir)
    {
        gameObject.GetComponent<Dash>().DashReset();
        gameObject.GetComponent<Dash>().CancelDash();
        rb.gravityScale = 0;
        rb.linearVelocity = Vector2.zero;
        player_movement.SetLaunchVelocity(launchPower * Dir.normalized);
        animator.SetBool("Isjumping", true);
        launchState = StartCoroutine(LaunchState(launch_time));
    }
    public void CancelLaunch()
    {
        if (launchState != null)
        {
            player_movement.SetLaunchVelocity(Vector2.zero);
            StopCoroutine(launchState);
            rb.gravityScale = 0;
            animator.SetBool("Isjumping", false);
        }
    }
    public IEnumerator LaunchState(float launch_time)
    {
        yield return new WaitForSeconds(launch_time);
        player_movement.SetLaunchVelocity(Vector2.zero);
        rb.gravityScale = 1.6f;
        animator.SetBool("Isjumping", false);
    }

}
