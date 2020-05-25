using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class FrogScript : MonoBehaviour
{
    private Animator anim;
   

    private bool anime_starts;
    private bool anime_finish;

    private int jumptimes;
    private bool jumpleft = true;

    private void Awake()
    {
         
        anim = GetComponent<Animator>();
        
    }
    void Start()
    {
        StartCoroutine(FrogJump());
    }

  void LateUpdate()
    {
        if(anime_finish && anime_starts)
        {
            anime_starts = false;

            transform.parent.position = transform.position;
            transform.localPosition = Vector3.zero;
            
        }
    }

   

    IEnumerator FrogJump()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        
            anime_starts = true;
            anime_finish = false;
        jumptimes++;

        if (jumpleft)
        {
            anim.Play("FrogJumpLeft");
        }
        else
        {
            anim.Play("FrogJumpRight");
        }
        StartCoroutine(FrogJump());
    }

    void AnimationFinish()
    {
        anime_finish = true;
        if(jumpleft)
        {
            anim.Play("FrogIdleLeft");
        }
        else
        {
            anim.Play("FrogIdleRight");
        }

        if (jumptimes == 3)
        {
            jumptimes = 0;
            Vector3 tempscale = transform.localScale;
            tempscale.x *= -1;
            transform.localScale = tempscale;

            jumpleft = !jumpleft;
        }
    }

}//class
