using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject BulletFire;


    private void Update()
    {
        ShootBullet();
    }
    void ShootBullet()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            GameObject _bullet = Instantiate(BulletFire, transform.position, Quaternion.identity);
            _bullet.GetComponent<FireBullet>()._Speed *= transform.localScale.x;
            
        }
    }
}
