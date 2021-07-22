using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ropePoint : MonoBehaviour,IPointerClickHandler
{
    GameObject player;
    public GameObject rope;
    public GameObject skin;
    public float distance=8f;
    bool canClick = false;
    bool connect = false;
    private float Timer = 1.2f;
    private bool isThisOne = false;
    int d = 1;

    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        rope.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (canClick)
        {
            player.GetComponent<PlayerController>().hang(this.gameObject);
            rope.SetActive(true);
            isThisOne = true;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(this.transform.position,player.transform.position) < distance)
        {
            skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/point1");
            canClick = true;
            Timer -= Time.deltaTime * 0.15f * d;
            if (Timer < 0.9f)
            {
                Timer = 0.9f;
                d *= -1;
            }
            else if (Timer > 1.1f)
            {
                Timer = 1.1f;
                d *= -1;
            }

            skin.transform.localScale = new Vector3(Timer, Timer, 1);
        }
        else
        {
            skin.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/point");
            skin.transform.localScale = new Vector3(1, 1, 1);
            canClick = false;
        }

        connect = !player.GetComponent<PlayerController>().canMove;


        if (connect)
        {
            if (isThisOne)
            {
                if (count == 0)
                {
                    Instantiate(Resources.Load("Audio/gousheng"), gameObject.transform);
                    count = 1;
                }

                Vector3 playerHand = player.transform.position + new Vector3(0, 2, 0);
                rope.SetActive(true);
                //rope.transform.position = (this.transform.position + playerHand) / 2;
                //rope.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90 + Mathf.Atan((playerHand.y - this.transform.position.y)/
                //    (playerHand.x - this.transform.position.x))*180/Mathf.PI));
                //rope.transform.localScale = new Vector3(0.1f, Vector2.Distance(this.transform.position, playerHand) /2, 0.1f);

                float distance = Vector2.Distance(gameObject.transform.position, player.GetComponent<PlayerController>().RightHand.transform.position);
                rope.GetComponent<Detent>().DrawLength(player.GetComponent<PlayerController>().RightHand.transform.position, gameObject.transform.position, distance);
                player.GetComponent<Animator>().SetBool("Hook", true);
            }
        }
        else
        {
            isThisOne = false;
            count = 0;
            rope.SetActive(false);
            rope.GetComponent<Detent>().Clear();
            player.GetComponent<Animator>().SetBool("Hook", false);

        }

    }
}
