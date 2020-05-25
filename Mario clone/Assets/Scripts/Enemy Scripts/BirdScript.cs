using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rigid;

                                            private Vector3 Moving = Vector3.left;

                                            private Vector3 LeftPos;
                                            private Vector3 RightPos;

    public LayerMask PlayerLayer;

    private bool attacked;
    private bool canMove;

    public float Speed;

    public GameObject BirdEgg;  

                                        //public Vector3 MovingLeft1 { get => MovingLeft; set => MovingLeft = value; }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        RightPos = transform.position;
        RightPos.x += 6f;

        LeftPos = transform.position;
        LeftPos.x -= 6f;

        canMove = true;
    }

    void Update()
    {
        MoveDirection();
        DropEgg();
    }


    void MoveDirection()
    {

        if(canMove)
        {
            transform.Translate(Moving * Speed* Time.smoothDeltaTime);
            if(transform.position.x >= RightPos.x)
            {
                Moving = Vector3.left;
                ChangeDir(0.5f);
            }
            else if (transform.position.x <= LeftPos.x)
            {
                Moving = Vector3.right;
                ChangeDir(-0.5f);
            }

        }//if canMove
    }

    void ChangeDir(float dir)
    {

        Vector3 temp = transform.localScale;
        temp.x = dir;
        transform.localScale = temp;

    }


    void DropEgg()
    {
        if(!attacked)
        {
            if (Physics2D.Raycast(transform.position,  Vector2.down, Mathf.Infinity,PlayerLayer))
            {
                Instantiate(BirdEgg, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z), Quaternion.identity);
                attacked = true;
                anim.Play("BirdFly");
            }
        }
    }

    IEnumerator BirdDead()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag==MyTags.bullet_tag)
        {
            anim.Play("BirdDead");

            GetComponent<BoxCollider2D>().isTrigger = true;
            rigid.bodyType = RigidbodyType2D.Dynamic;

            canMove = false;
            StartCoroutine(BirdDead());
        }
    }

}//class
