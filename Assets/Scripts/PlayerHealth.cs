using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public float dieTime;

    //private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(int damage)
    {
        health -= damage;
        if (health == 0)
        {
            //anim.SetTrigger("Die");
            GetComponent<Animator>().SetBool("Die", true);
            GetComponent<PlayerController>().enabled = false;
            Instantiate(Resources.Load("Audio/siwang"), gameObject.transform);
            Invoke("KillPlayer", dieTime);
        }
    }

    void KillPlayer()
    {

        GameObject.Find("Canvas").GetComponent<Menu>().failMenuUI.SetActive(true);
        GameObject.Find("Canvas").GetComponent<Menu>().backGround.SetActive(true);
    }




}
