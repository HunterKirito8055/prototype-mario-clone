using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    private float speed = 10f;

    
    private Animator anime;

    public bool canMove;
    private void Awake()
    {
        anime = GetComponent<Animator>();
    }
    void Start()
    {
       
        StartCoroutine(DisableBullet(5f));
    }

   
    void Update()
    {
        Move();
        
    }
    void Move()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;

    }
    public float _Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }
    IEnumerator DisableBullet(float timer)
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
        
       

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag ==MyTags.beetle_tag || collision.gameObject.tag== MyTags.snail_tag || collision.gameObject.tag == MyTags.spider_tag    )
        {
            anime.Play("Explode");
            canMove = false;
            StartCoroutine(DisableBullet(0.9f));
           
           // gameObject.SetActive(false);
        }
    }
}       
