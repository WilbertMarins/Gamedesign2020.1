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

    // Start is called before the first frame update

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
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
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                rigid.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                
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
            //animator.SetBool("jump", false);
        }

        //if (collision.gameObject.tag == "Spike" || collision.gameObject.tag == "Saw") // tag Spike or Saw
        //{
            //GameController.instance.ShowGameOver();
            //Destroy(gameObject);
        //}
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8) // layer Ground
        {
            isJumping = true;
        }
    }




}
