using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement1 : MonoBehaviour
{
    [SerializeField] private float movespd = 5f;
    [SerializeField] private float jumpforce = 60f;
    public Transform Sprite;
    public bool isjumping;
    private Rigidbody2D rb;
    private float movehorizontal;
    private float movevertical;
    public Animator animator;
    public bool facingRight = true;
    public float yvel;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        movehorizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(movehorizontal));
        movevertical = Input.GetAxisRaw("Vertical");
        yvel = rb.linearVelocity.y;
        animator.SetFloat("VSpd", yvel);


    }

    void FixedUpdate()
    {
       if (movehorizontal > 0.1f || movehorizontal < -0.1f)
        {
            rb.AddForce(new Vector2(movehorizontal * movespd,0f),ForceMode2D.Impulse);
            
        }
        if (!isjumping && movevertical > 0.1f)
        {   
            rb.AddForce(new Vector2(0f,movevertical * jumpforce), ForceMode2D.Impulse);
        }

        if (movehorizontal > 0f && !facingRight)
        {
            filp();
        }
        if (movehorizontal < 0f && facingRight)
        {
            filp();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isjumping = false;
            animator.SetBool("Isjumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isjumping = true;
            animator.SetBool("Isjumping", true);
        }
    }

    private void filp()
    {
            Vector3 Itemp = Sprite.transform.localScale;
            Itemp.x *= -1;
            Sprite.localScale = Itemp;

            facingRight = !facingRight;
    }
}
