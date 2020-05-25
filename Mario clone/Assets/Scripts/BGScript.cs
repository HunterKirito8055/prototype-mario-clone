using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScript : MonoBehaviour
{
    private void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        transform.localScale = new Vector3(1, 1, 1);

        float width = sr.sprite.bounds.size.x;
            //Debug.Log("width = "+ width);
        
        float height = sr.sprite.bounds.size.y;
            //Debug.Log("height = " + height);
        float WorldHeight = Camera.main.orthographicSize * 2f ;

            //Debug.Log("Worldheigh = " + WorldHeight);
            //Debug.Log("ortho = " + Camera.main.orthographicSize);

        float WorldWidth = WorldHeight / Screen.height    * Screen.width;

            //Debug.Log("Screenheight = " + Screen.height + "Screenwidth = " + Screen.width);
            //Debug.Log("worldwidth = " + WorldWidth);

        Vector3 tempscale = transform.localScale;
        tempscale.x = WorldWidth / width  ;

            //Debug.Log("tempscale.x = " + tempscale.x);

        tempscale.y = WorldHeight / height ;

            //Debug.Log("tempscale.y = " + tempscale.y);

        transform.localScale = tempscale;
    }




}//class
