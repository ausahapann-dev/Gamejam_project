using UnityEngine;

public class LadderScript : MonoBehaviour
{
    public Collider2D[] collider_object;

    void Update()
    {
        if (Player.instance.GetY() > transform.position.y)
        {
            HitboxActivate(true);
        }
        else
        {
            HitboxActivate(false);
        }
    }

    void HitboxActivate(bool status)
    {
        for (int i = 0; i < collider_object.Length; i++)
        {
            collider_object[i].enabled = status;
        }
    }
}
