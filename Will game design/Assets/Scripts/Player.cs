using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public bool isJumping;
    public bool doubleJump;

    private Rigidbody2D rigid;
    private Animator animator;

    // Start is called before the first frame update

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();

    }


    void Move()
    {  
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        float movimento = Input.GetAxis("Horizontal");
        if (movimento > 0f)
        {
            animator.SetBool("walk", true);
            //rotaciona o personagem direita
            
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if (movimento < 0f)
        {
            animator.SetBool("walk", true);
            //rotaciona o personagem esquerda
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (movimento == 0f)
        {
            animator.SetBool("walk", false);
        }
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                rigid.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                animator.SetBool("jump", true);

            }
            else
            {
                if (doubleJump)
                {
                    rigid.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }

        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8) // layer Ground
        {
            isJumping = false;
            //doubleJump = false;
            animator.SetBool("jump", false);
        }

      
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8) // layer Ground
        {
            isJumping = true;
        }
    }




}
