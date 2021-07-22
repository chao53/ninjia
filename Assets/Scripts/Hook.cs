
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] public float speed = 5f;//子弹的速度
    public Rigidbody2D rig;
    public int time;
    //public LineRenderer l;
    private Detent detent;

    private SpringJoint2D joint;
    private float distance;
    private Transform player;


    // Start is called before the first frame update


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rig = GetComponent<Rigidbody2D>();//获取子弹刚体组件
        Vector3 direction = Input.mousePosition;
        rig.velocity = (new Vector3(direction.x - Camera.main.pixelWidth / 2, direction.y - Camera.main.pixelHeight / 2, 0).normalized * speed);

       
        detent = gameObject.transform.GetChild(0).gameObject.GetComponent<Detent>();
    }

    // Update is called once per frame
    void Update()
    {

        Controller();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player" && collision.tag != "Chain")
        {
            
            rig.velocity = Vector3.zero;
            rig.gravityScale = 100;
            rig.constraints = RigidbodyConstraints2D.FreezeAll;

            StartGrapple();





            //Destroy(gameObject);
        }

    }

    void StartGrapple()
    {
        distance = Vector2.Distance(gameObject.transform.position, GameObject.Find("Hand").transform.position);
        detent.DrawLength(GameObject.Find("Hand").transform.position, gameObject.transform.position, distance);

       


    }


    /// <summary>
    /// Call whenever we want to stop a grapple
    /// </summary>
    void StopGrapple()
    {
        Destroy(gameObject);
        Destroy(joint);
    }

    private void Controller()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            StopGrapple();
        }
       
    }
}
