using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject other;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown("q"))
        //{

        //    float a = Vector2.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position);
        //    Debug.Log(gameObject.name+a);
        //    if (a < 1f)
        //    {
        //        if (other)
        //        {
        //            GameObject.FindGameObjectWithTag("Player").transform.position = other.transform.position;

        //        }
        //    }
        //}


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("q"))
            {
                if (other)
                {
                    collision.gameObject.transform.position = other.transform.position;
                    Instantiate(Resources.Load<GameObject>("Audio/tp(door)"), gameObject.transform);
                    //GameObject a = collision.gameObject.GetComponent<PlayerController>().effct;
                    //Instantiate(collision.gameObject.GetComponent<PlayerController>().effct);
                    //a.transform.position = collision.gameObject.transform.position;
                    //Destroy(a, 3);


                }

            }

        }

        if(collision.gameObject.tag == "Bullet")
        {
            if (other)
            {
                collision.gameObject.transform.position = other.transform.position;

            }

        }
    }
}
