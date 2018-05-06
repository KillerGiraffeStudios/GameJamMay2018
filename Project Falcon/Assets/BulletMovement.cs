using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class BulletMovement : MonoBehaviour {

    public float speed = 10;
    public GamePad.Index Player = GamePad.Index.One;
    public Transform bulletSpawn;
    public GameObject bulletPrefab;

    // Use this for initialization
    void Start () {
    }
    bool shoot;
    bool canShoot = true;
	// Update is called once per frame
	void Update () {
        shoot = GamePad.GetButtonDown(GamePad.Button.A, Player);
        if(shoot && canShoot)
        {
            Shoot();
        }
    }


    //shoot function, spawns bullet and sets velocity.
    void Shoot()
    {
        if(!gameObject.GetComponent<AudioSource>().isPlaying)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }

        float spawnSpeedX = bulletSpawn.parent.gameObject.GetComponent<Rigidbody2D>().velocity.x;
        float spawnSpeedY = bulletSpawn.parent.gameObject.GetComponent<Rigidbody2D>().velocity.y;
        canShoot = false;
        Invoke("enableShoot",0.2f);
        
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        var rotation = transform.eulerAngles.z * Mathf.Deg2Rad;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(rotation)*speed + spawnSpeedX, Mathf.Sin(rotation)*speed + spawnSpeedY);
        Destroy(bullet, 5.0f);
    }

    void enableShoot(){
        canShoot = true;
    }
}
