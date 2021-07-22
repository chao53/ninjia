using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockRolling : MonoBehaviour
{
    public GameObject rock1;
    private Rigidbody2D rock1Rig;
    private bool flag = false;
    private int count;
    private float timer;
    
    void Start()
    {
        rock1Rig = rock1.GetComponent<Rigidbody2D>();

        rock1Rig.gravityScale = 0;
        timer = 0;
        count = 0;
    }
    
    private void Update() {
        if(count<1)
        {
            if(flag)timer+=Time.deltaTime;
            //Debug.Log(rock1Rig.velocity);
            if(timer>1.0f)
            {
                if(rock1Rig.gravityScale == 1&&rock1Rig.velocity.x <= 0.5&&rock1Rig.velocity.y <= 0.5)
                {
                    rock1.GetComponent<Enemy>().damege = 0;
                    count++;
                }
            }
        }
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"&&!flag)
        {
            rock1Rig.gravityScale = 1;
            flag = true;
        }
    }
}
