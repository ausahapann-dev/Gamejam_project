using UnityEngine;

public class Flip : MonoBehaviour
{
    public SpriteRenderer player_sprite;
    void Update()
    {
        float InputX = gameObject.GetComponent<Movement>().GetInputX();
        if (InputX < 0)
        {
            player_sprite.flipX = true;
        }
        if (InputX > 0)
        {
            player_sprite.flipX = false;
        }
    }
}
