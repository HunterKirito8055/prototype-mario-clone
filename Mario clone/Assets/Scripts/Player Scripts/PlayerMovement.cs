using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f ;

    private Rigidbody2D myBody;
    private Animator anim;

    public Transform groundchecking;
    public LayerMask groundlayer;

    private bool isOnGround;
    private bool jumped;

    private float jumpPower = 13f;

    //private void Awake()
    //{
    //    myBody = GetComponent <Rigidbody2D>();
    //    anim = GetComponent<Animator>();
    //}

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Physics2D.Raycast(groundchecking.position, Vector2.down, 0.5f, groundlayer))
        //{
        //    print("colision by ray and on ground");
        //}
        //else
        //{
        //    print("jumped");
        //}
        CheckifOnGround();
        Playerjump();

    }

    private void FixedUpdate()
    {
        PlayerWalk();
    }

    void PlayerWalk()
    {
        float h = Input.GetAxisRaw("Horizontal");
        /*we can use Input.GetAxis("Horizontal/vertical") but the value it gives will be in decimals...viz., 0.2531 or 1.235
         * and.. Input.GetAxisRaw("Horizontal/vertical") will always gives the value in exact digits... viz., 1 or 0 */
        
        /* we are making the player walk horizontally, hence, y-axis stays constant */

        if (h>0)
        {
            myBody.velocity = new Vector2(speed, myBody.velocity.y);
            ChangeDirection(1);
        }
        else if(h<0)
        {
            myBody.velocity = new Vector2(-speed, myBody.velocity.y);
            ChangeDirection(-1); 
        }
        else
        {
            myBody.velocity = new Vector2(0, myBody.velocity.y);
        }
        //print(h);
        //float v = Input.GetAxisRaw("Vertical");
        //print(v);

        anim.SetInteger  ("Speed", Mathf.Abs((int)myBody.velocity.x)); // obj.function ("type_variable", value);


    }

    void ChangeDirection(int direction)
    {
        Vector3 tempscale = transform.localScale;
        tempscale.x = direction;
        transform.localScale = tempscale;
    }


    void CheckifOnGround()
    {
        isOnGround = Physics2D.Raycast(groundchecking.position, Vector2.down, 0.5f, groundlayer); //sets true to isOnGround
        if (isOnGround)
        {
            // we are on ground and jumped before.
            if(jumped)
            {   
                jumped = false;
                anim.SetBool("Jump", false);
            }
        }

    }


    void Playerjump()
    {
        if(isOnGround)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                jumped = true;
                myBody.velocity = new Vector2(myBody.velocity.x, jumpPower);
                anim.SetBool("Jump", true);
            }
        }
    }
                               


} //class





/////*one of 2 ways to detect collion is below */

//private void OnCollisionEnter2D(Collision2D collision)
//{
//    //            //if (collision.gameObject.name == "Ground")
//    //            //    print("Collision occured with ground");
//    //            //else if (collision.gameObject.name == "Player1")
//    //            //    print("Collision occured with player");
//}

////        /*2 of 2 ways to detect collion and go through is below */

//private void OnTriggerEnter2D(Collider2D collision)
//{
//    //            //if (collision.gameObject.name == "Player1")
//    //            //    print("Colliding");
//}
