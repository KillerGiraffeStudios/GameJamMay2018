using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rabbit_AI : MonoBehaviour {
    [SerializeField]
    public float MinDist = 0.5f;
    public float MaxDist = 0.5f;
    private GameObject Anchor;
    public int speed = 4;
    // Use this for initialization
    void Start()
    {
        Anchor = GameObject.FindGameObjectWithTag("anchor");
        DeathTimer();
    }
    void DeathTimer()
    {
        Destroy(gameObject, 120);
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
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 270);
        }



            
        }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "anchor")
        {
            coll.gameObject.SendMessage("Damage");
            Destroy(gameObject);
        }
    }
}
