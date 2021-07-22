using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //public GameObject bullet1;
    //public GameObject bullet2;
    //public GameObject bullet3;


    private static string shoot1;
    private static string shoot2;
    private static string shoot3;

    private GameObject a;
    private GameObject b1;
    private GameObject b2;
    private GameObject c;

    private Vector3 targetpos;
    private LineRenderer linerenderer;
    private Animator  myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        shoot1 = "shoot";
        shoot2 = "shoot1";
        shoot3 = "shoot";
        linerenderer = GetComponent<LineRenderer>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        myAnimator.SetBool("Transfer", false);
        myAnimator.SetBool("Portal", false);
        myAnimator.SetBool("Transfer", false);
        Transfer();
        if (myAnimator.GetBool("IsGround"))
        {
            Portal();
        }

        if (c)
        {
            myAnimator.SetBool("IsHook", true);
        }
        else
        {
            myAnimator.SetBool("IsHook", false);
        }
       
        Hook();
    }

 

    void Transfer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!a)
            {
                a = Instantiate(Resources.Load<GameObject>("bullet1"));
                a.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position+Vector3.up;
                myAnimator.SetBool("Transfer", true);
            }
            else
            {
                gameObject.transform.position = a.transform.position;
                Destroy(a);
            }
        }
        

    }

    void Portal()
    {
        if (Input.GetKeyDown("r"))
        {
            Destroy(b1);
            Destroy(b2);
        }
        if (Input.GetKeyDown("e"))
        {
            myAnimator.SetBool("Portal", true);
            if (!b1)
            {
                
                b1 = Instantiate(Resources.Load<GameObject>("portal1"));
                b1.transform.position = GameObject.Find("Hand").transform.position;
                b1.gameObject.GetComponent<Portal>().other = b1;
            }
            else if(!b2)
            {
                b2 = Instantiate(Resources.Load<GameObject>("portal2"));
                b2.transform.position = GameObject.Find("Hand").transform.position;
                b1.gameObject.GetComponent<Portal>().other = b2;
                b2.gameObject.GetComponent<Portal>().other = b1;
            }
            else
            {
                
                b1.transform.position = GameObject.Find("Hand").transform.position;

            }
        }
    }

    void Hook()
    {
        if (!c)
        {
            if (Input.GetMouseButtonDown(1))
            {
                myAnimator.SetBool("Transfer", true);
                c = Instantiate(Resources.Load<GameObject>("hook"));
                c.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + Vector3.up;
            }
            
        }
        
        
    }

}
