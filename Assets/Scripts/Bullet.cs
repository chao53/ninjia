using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

[Hotfix]
public class Bullet : MonoBehaviour {

    [SerializeField] private static float speed = 15f;//子弹的速度
    public Rigidbody2D rig;

  

	public int time;

	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody2D>();//获取子弹刚体组件
        Vector3 direction = Input.mousePosition;
        rig.velocity = (new Vector3(direction.x - Camera.main.pixelWidth / 2, direction.y - Camera.main.pixelHeight / 2, 0).normalized * speed);
        //transform.LookAt(new Vector3(direction.x - Camera.main.pixelWidth / 2, direction.y - Camera.main.pixelHeight / 2, 0).normalized);
        //transform.localEulerAngles = new Vector3(0, 0, direction.z - Camera.main.pixelWidth / 2).normalized;
        //rig.velocity = (new Vector3(direction.x - GameObject.FindGameObjectWithTag("Player").transform.position.x , direction.y - GameObject.FindGameObjectWithTag("Player").transform.position.y , 0).normalized * speed);


        Vector3 direction1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // 方向向量转换为角度值
        float angle = 360 - Mathf.Atan2(direction.x - Camera.main.pixelWidth / 2, direction.y - Camera.main.pixelHeight / 2) * Mathf.Rad2Deg;
        // 将当前物体的角度设置为对应角度
        transform.eulerAngles = new Vector3(0, 0, angle+90f);
        Destroy(gameObject, time);
	}

	// Update is called once per frame
	void Update()
	{
       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player" && collision.tag != "Chain"&&collision.tag!="Portal")
        {
            //if (collision.gameObject.tag == "Enemy")//如果碰撞对象是敌人
            //{
            //    collision.gameObject.GetComponent<CrabController>().Hurt();//调用敌人的受伤函数，新加入到敌人的里面函数用来扣敌人血量，方便查看效果，不然太快了
            //}
            
            Destroy(gameObject);
            Debug.Log("123456789");
        }
        
		
	}
}
