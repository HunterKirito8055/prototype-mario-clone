using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag== MyTags.player_tag)
        {
            //DAMAGE THE PLAYER
        }
        gameObject.SetActive(false);

    }
}
