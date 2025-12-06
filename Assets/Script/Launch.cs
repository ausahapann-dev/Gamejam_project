using UnityEngine;
using System.Collections;

public class Launch : MonoBehaviour
{
    public float gravity_scale = 0f;
    public Rigidbody2D rb;
    public float launchPower = 6f;
    public float launch_time = 0.2f;

    private void Start()
    {
        gravity_scale = rb.gravityScale;
    }
    public void LaunchPlayer(Vector2 Dir)
    {
        gameObject.GetComponent<Dash>().DashReset();
        rb.gravityScale = 0f;
        rb.linearVelocity = Vector2.zero;
        rb.linearVelocity = Dir.normalized * launchPower;
        StartCoroutine(LaunchState(launch_time));
    }
    public IEnumerator LaunchState(float launch_time)
    {
        yield return new WaitForSeconds(launch_time);
        rb.gravityScale = gravity_scale;
        rb.linearVelocity = Vector2.zero;
    }

}
