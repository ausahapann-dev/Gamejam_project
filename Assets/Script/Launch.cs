using UnityEngine;
using System.Collections;

public class Launch : MonoBehaviour
{
    public Rigidbody2D rb;
    public float launchPower = 6f;
    public float launch_time = 0.2f;

    public Animator animator;

    public void LaunchPlayer(Vector2 Dir)
    {
        gameObject.GetComponent<Dash>().DashReset();
        rb.gravityScale = 0;
        rb.linearVelocity = Vector2.zero;
        rb.linearVelocity = launchPower * Dir.normalized;
        animator.SetBool("IsJumping", true);
        StartCoroutine(LaunchState(launch_time));
    }
    public IEnumerator LaunchState(float launch_time)
    {
        yield return new WaitForSeconds(launch_time);
        rb.gravityScale = 1.6f;
        animator.SetBool("IsJumping", false);
    }

}
