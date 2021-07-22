using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damege;
    //public float x1;
    //public float x2;
    //public float moveSpeed;

    //private bool canTurnRight=false;
    //private bool canTurnLeft=true;
    //private Rigidbody2D myRigidbody;
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    public void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        //myRigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    public void Update()
    {
        //move();
        //Flip();
    }

  


    //void move()
    //{
    //    float xVel = (float)Math.Round((double)transform.position.x, 2);
    //    Vector2 enemyVel = new Vector2( moveSpeed, 0);
    //    myRigidbody.velocity = Vector2.right * enemyVel;
    //    if(xVel == x2&&canTurnLeft)
    //    {
    //        canTurnLeft = false;
    //        canTurnRight = true;
    //        moveSpeed = -moveSpeed;
    //    }else if(xVel == x1&& canTurnRight)
    //    {
    //        canTurnLeft = true;
    //        canTurnRight = false;
    //        moveSpeed = -moveSpeed;
    //    }

    //}

    //void Flip()
    //{
    //    bool plyerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
    //    if (plyerHasXAxisSpeed)
    //    {
    //        if (myRigidbody.velocity.x > 0.1f)
    //        {
    //            transform.localRotation = Quaternion.Euler(0, 0, 0);
                
    //        }

    //        if (myRigidbody.velocity.x < -0.1f)
    //        {
    //            transform.localRotation = Quaternion.Euler(0, 180, 0);
    //        }
    //    }
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") )
        {
            if(playerHealth != null)
            {
                playerHealth.DamagePlayer(damege);
            }            
        }
    }
}
