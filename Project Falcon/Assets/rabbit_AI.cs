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

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Anchor.transform.position) >= MinDist)
        {

            transform.position = Vector2.MoveTowards(transform.position, Anchor.transform.position, speed * Time.deltaTime);



            if (Vector3.Distance(transform.position, Anchor.transform.position) <= MaxDist)
            {
                Anchor.SendMessage("Damage");
                gameObject.SendMessage("Kill");
            }

        }
    }
}
