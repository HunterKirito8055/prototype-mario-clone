using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerDamage : MonoBehaviour
{

    private Text PlayerLife;
    private int lives;

    private bool canDamage;
    private void Awake()
    {
        PlayerLife = GameObject.Find("Coin Text").GetComponent<Text>();
        lives = 3;
        canDamage = true;
        PlayerLife.text = "x " + lives;
    }

    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void DealDamage()
    {
        if(canDamage)
        {
            lives--;

            if(lives > 0)
            {
                PlayerLife.text = "x " + lives;
            }
            if(lives == 0)
            {
                Time.timeScale = 0f;
                StartCoroutine(Restart());
            }

            canDamage = false;
            StartCoroutine(WaitforDamage());
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("Gameplay");
    }

    IEnumerator WaitforDamage()
    {
        yield return new WaitForSeconds(2f);
        canDamage = true;
    }














}//class
