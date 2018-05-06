using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squirrel_AI : MonoBehaviour {

    public int cooldownTimer = 5;
    public GameObject acorn;
    [SerializeField]
    public float MinDist = 3.0f;
    public float MaxDist = 8.0f;
    private GameObject Anchor;
    public int speed = 3;
    public GameObject Bullet;
    private bool cooldown = false;
    AudioSource shootingsound;

    
    // Use this for initialization
    void Start()
    {
        Anchor = GameObject.FindGameObjectWithTag("anchor");
        shootingsound = gameObject.GetComponentInChildren<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Anchor.transform.position) >= MinDist)
        {

            transform.position = Vector2.MoveTowards(transform.position, Anchor.transform.position, speed * Time.deltaTime);
            Vector3 diff = Anchor.transform.position - gameObject.transform.position;

            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
        }



        if (Vector3.Distance(transform.position, Anchor.transform.position) <= MaxDist)
        {
            Shoot();
        }

    }

    IEnumerator JustShot()
    {
        cooldown = true;
        yield return new WaitForSeconds(cooldownTimer);
        cooldown = false;
    }

    void Shoot()
    {
        if (!cooldown) {
            if(!shootingsound.isPlaying)
            {
                shootingsound.Play();
            }
            var acornbullet = (GameObject)Instantiate(acorn, gameObject.transform.position + gameObject.transform.right*1, gameObject.transform.rotation);
            var rotation = transform.eulerAngles.z * Mathf.Deg2Rad;
            acornbullet.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(rotation) * speed, Mathf.Sin(rotation) * speed);
            Destroy(acornbullet, 5.0f);
            StartCoroutine(JustShot());
        }
    }
}
