using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D body;

    private string coroutine_name = "ChangeDir";
    private Vector3 MoveDirection = Vector3.down;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(coroutine_name);
    }
    private void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(MoveDirection * Time.smoothDeltaTime);
       
    }

    IEnumerator ChangeDir()
    {
        yield return new WaitForSeconds(Random.Range(2f, 4.5f));
        if (MoveDirection == Vector3.down)
        {
            MoveDirection = Vector3.up;
            
        }
        else
        {
            MoveDirection = Vector3.down;
           
        }
        StartCoroutine(coroutine_name);
    }

    IEnumerator SpiderDead()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == MyTags.player_tag)
        {
            //DAMAGE TO PLAYER
        }
        if(collision.tag== MyTags.bullet_tag)
        {
            anim.Play("SpiderDead");
            body.bodyType = RigidbodyType2D.Dynamic;
            StartCoroutine(SpiderDead());
            //StopCoroutine("ChandeDir()");
        }
    }

}//class
