using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailScript : MonoBehaviour
{
    public float movespeed = 1f;

    private Animator anim;
    private Rigidbody2D snailbody;
    public LayerMask playerLayer; 
    private bool moveleft;
    private bool canMove, Stunned;

    public Transform Down_collision, left_col, right_col, top_col;
    
    private Vector3 leftCollision, rightCollision;



    private void Awake()
    {
        anim=GetComponent<Animator>();
        snailbody = GetComponent<Rigidbody2D>();
        leftCollision = left_col.position;
        rightCollision = right_col.position;
    }
    void Start()
    {
        moveleft = true; //bool
        canMove = true;
    }

    
    
    void Update()
    {
        if (canMove)
        {
            if (moveleft)       //to move left
            {
                snailbody.velocity = new Vector2(-movespeed, snailbody.velocity.y);
                //ChangeDirection(-0.37f);  //turn left face
            }
            else //to move left

            {
                snailbody.velocity = new Vector2(movespeed, snailbody.velocity.y);
                //ChangeDirection(0.37f);    //turn right face
            }
        }
        checkCollision();
    }

    void ChangeDirection(/*float dir*/)
    {
        moveleft = !moveleft;
        Vector3 temp = transform.localScale;
        if(moveleft)
        {
            temp.x = Mathf.Abs(temp.x); //turns  right
            right_col.position = rightCollision;
            left_col.position = leftCollision;
        }
        else
        {
            temp.x = -Mathf.Abs(temp.x);    //turns left
            right_col.position = leftCollision;
            left_col.position = rightCollision;
        }
       // temp.x = dir;  //using only X axis from the {X=dir,Y and Z doesnt changes}
        transform.localScale = temp;
    }

    void checkCollision()
    {
        RaycastHit2D righthit = Physics2D.Raycast(right_col.position, Vector2.right, 0.1f,playerLayer);
        RaycastHit2D lefthit = Physics2D.Raycast(left_col.position, Vector2.left, 0.1f,playerLayer);

        Collider2D tophit = Physics2D.OverlapCircle(top_col.position, 0.2f, playerLayer);  

        if(tophit!=null)
        {
            if (tophit.gameObject.tag == MyTags.player_tag) //tags stored in Helper SCripts Folder-> MyTags script
            {
                if (!Stunned)
                {
                    // tophit gameobject and getting that rigidbody2d component 
                    
                    tophit.gameObject.GetComponent<Rigidbody2D>().velocity = 
                        new Vector2(tophit.gameObject.GetComponent<Rigidbody2D>().velocity.x, 6f); 
                    

                    //snail is stunned and cannot move now
                    canMove = false;
                    snailbody.velocity = new Vector2(0, 0);   //vector2(0,0)
                    anim.Play("Stunned");
                    Stunned = true;
                    
                    ///BEETLE CODE HERE
                    
                if(tag==MyTags.beetle_tag)
                    {
                        anim.Play("BeetleStunned");
                        StartCoroutine( Dead (0.5f));
                        
                    }
                   
                }
            }
        }
        if(lefthit)
        {
            if(lefthit.collider.gameObject.tag== MyTags.player_tag)
            {
                if(!Stunned)
                {
                    //APPLY DAMAGE TO PLAYER
                }   
                else
                {
                    if (tag != MyTags.beetle_tag)
                    {
                        snailbody.velocity = new Vector2(13f, snailbody.velocity.y);

                        StartCoroutine(Dead(3f));
                    }
                }
            }
        }
        if(righthit)
        {
            if(righthit.collider.gameObject.tag==MyTags.player_tag)
            {
                if(!Stunned)
                {
                    //APPLY DAMAGE TO PLAYER
                }
                else
                {
                    if(tag!=MyTags.beetle_tag)
                    snailbody.velocity = new Vector2(-15f, snailbody.velocity.y);
                    StartCoroutine(Dead(3f));
                }
            }
        }

        // if we dont detect collision, then do what's in { }
        if (!Physics2D.Raycast(Down_collision.position, Vector2.down, 0.1f)) //if the snail doesnt touches ground
        {
            ChangeDirection();
        }
        
    }
    IEnumerator Dead(float timer)
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == MyTags.bullet_tag)
        {
            if (tag == MyTags.beetle_tag)
            {
                anim.Play("Stunned");
                canMove = false;
                snailbody.velocity = new Vector2(0, 0);
                StartCoroutine(Dead(0.2f));
            }
            if(tag == MyTags.snail_tag)
            {
                if(!Stunned)
                {
                    anim.Play("Stunned");
                    Stunned = true;
                    canMove = false;
                    snailbody.velocity = new Vector2(0, 0);
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }

}//class



























