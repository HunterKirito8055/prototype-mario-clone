using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    private Text coinText;
    private AudioSource audioManage;

    private int score;
    private void Awake()
    {
        audioManage = GetComponent<AudioSource>();
        coinText = GameObject.Find("Coin Text").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == MyTags.Coin_tag)
        {
            collision.gameObject.SetActive(false);
            audioManage.Play();
            score++;
            coinText.text = "x" + score;
        }
    }















}
















