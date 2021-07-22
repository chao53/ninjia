using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float runSpeed;
    public float walkSpeed;
    public float jumpSpeed;
    public float doulbJumpSpeed;
    public float wallJumpSpeed1;
    public float wallJumpSpeed2;
    public float time;
    public int down=-30;
    public GameObject leftHand;
    public GameObject RightHand;
    public GameObject effct;
    public GameObject effct1;
    public GameObject effct2;
    public GameObject effct3;

    private Rigidbody2D myRigidbody;
    private Animator myAnim;
    private BoxCollider2D myFeet;
    private CapsuleCollider2D myBody;
    private bool isGround;
    private bool isWall;
    private bool canDoubleJump;
    private bool canWallJump;
    private string direction;
    private float speed;
    private float t1;
    private float t2;
    private bool canRun=true;

    public bool canMove = true;
    private float hangTimer = 0;
    private float dis = 0;
    private float hangAngle = 0;
    private Transform poinTransform = null;

    //public GameObject bullet1;
    //public GameObject bullet2;
    //public GameObject bullet3;



    private GameObject a;
    private GameObject b1;
    private GameObject b2;
    private GameObject c;



    //private Vector2 move;



    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myFeet = GetComponent<BoxCollider2D>();
        myBody = GetComponent<CapsuleCollider2D>();
        speed = walkSpeed;
        Debug.Log(leftHand.transform.position);
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t1 += Time.deltaTime;
        t2 += Time.deltaTime;
        Die();
        Flip();
        if (canMove)
        {
            hangTimer = 2;       
            CheckGrounded();
            CheckWalled();
            Jump();
            WallJump();
            if (canRun)
            Run();


            
            myAnim.SetFloat("Speed", Mathf.Abs(myRigidbody.velocity.x / (walkSpeed * 2)));
            myAnim.SetFloat("UpSpeed", myRigidbody.velocity.y / (jumpSpeed));

            

            myAnim.SetBool("Transfer", false);
            myAnim.SetBool("Portal", false);
            myAnim.SetBool("Transfer", false);

           
            Transfer();
            
           


            if (isGround)
            {
                Portal();
            }

            
        }
        else
        {
            
            hangTimer += Time.deltaTime;

            Vector2 hangSpeed1 = new Vector2(Mathf.Sin(hangAngle)*10,Mathf.Cos(hangAngle)*10);
            Vector2 hangSpeed2 = new Vector2(Mathf.Sin(hangAngle) * 10, -Mathf.Cos(hangAngle) * 5);
            Vector2 hangSpeed3 = new Vector2(Mathf.Sin(hangAngle) * 10, Mathf.Cos(hangAngle) * 2.5f);
            Vector2 hangSpeed4 = new Vector2(Mathf.Sin(hangAngle)*10, -Mathf.Cos(hangAngle)*10);


            if (hangTimer < dis / 20)
            {
                myRigidbody.velocity = hangSpeed1;
                
            }
            else if (hangTimer < dis / 20 + Mathf.Abs(Mathf.Sin(hangAngle)*dis) / 10f)
            {
                myRigidbody.velocity = hangSpeed2;
                print(Mathf.Abs(Mathf.Sin(hangAngle)*dis) / 2.5f);
            }
            else if (hangTimer < dis / 20 + Mathf.Abs(Mathf.Sin(hangAngle)) * dis / 5f)
            {
                myRigidbody.velocity = hangSpeed3;
                print("3");
            }
            else if(hangTimer < dis/10 + Mathf.Sin(hangAngle) / 5)
            {
                myRigidbody.velocity = hangSpeed4;
                print("4");
            }
            else
            {
                canMove = true;
                myRigidbody.gravityScale = 4;
            }
            
            //myRigidbody.velocity = Vector2
        }
    }


    public void hang(GameObject point)
    {
        dis = Vector2.Distance(this.transform.position, point.transform.position);
        hangAngle = Mathf.Atan((point.transform.position.x - this.transform.position.x) / (point.transform.position.y - this.transform.position.y));
        poinTransform = point.transform;
        canMove = false;
        myRigidbody.gravityScale = 0;
        hangTimer = 0;
    }

    
    void CheckGrounded()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
        if (isGround)
        {
            myAnim.SetBool("IsGround", true);
        }
        else
        {
            myAnim.SetBool("IsGround", false);
        }
        
    }

    void CheckWalled()
    {
        if (myBody.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            if (direction == "right")
            {
                if (Input.GetAxis("Horizontal")>0)
                {
                    isWall = true;
                }
                else
                {
                    isWall = false;
                }
            }
            else
            {
                if (Input.GetAxis("Horizontal") < 0)
                {
                    isWall = true;
                }
                else
                {
                    isWall = false;
                }
            }
        }
        else
        {
            isWall = false;
        }

        if (isWall)
        {
            myAnim.SetBool("IsWall", true);
            canWallJump = true;
        }
        else
        {
            myAnim.SetBool("IsWall", false);
            canWallJump = false;
        }
    }

    void Die()
    {
        if (myRigidbody.velocity.y < down)
        {
            GetComponent<PlayerHealth>().DamagePlayer(1);
        }
    }


    void Flip()
    {
        bool plyerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (plyerHasXAxisSpeed)
        {
           
            if (myRigidbody.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0,0, 0);
                direction = "right";
            }

            if (myRigidbody.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                direction = "left";
            }
        }

        //if (myRigidbody.gravityScale == G)
        //{
        //    if (plyerHasXAxisSpeed)
        //    {
        //        if (myRigidbody.velocity.x > 0.1f)
        //        {
        //            transform.localRotation = Quaternion.Euler(180, 0, 0);
        //        }

        //        if (myRigidbody.velocity.x < -0.1f)
        //        {
        //            transform.localRotation = Quaternion.Euler(180, 180, 0);
        //        }
        //    }
        //}
    }

    void Run()
    {
        if (t2 > time)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed = runSpeed;
                Instantiate(Resources.Load("Audio/chongci"), gameObject.transform);
                t2 = 0;
            }

           
        }
        if (speed > walkSpeed)
        {
            speed -= Time.deltaTime * 60;
        }
        if (speed < walkSpeed)
        {
            speed = walkSpeed;
        }

        
        float moveDir = Input.GetAxis("Horizontal");
        //Debug.Log("moveDir = " + moveDir.ToString());
        Vector2 playerVel = new Vector2(moveDir * speed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVel;
        bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (isGround)
        {
            if (myAnim.GetFloat("Speed") > 0.2)
            {
                GetComponent<AudioSource>().UnPause();
            }
            else
            {
                GetComponent<AudioSource>().Pause();
            }
        }
       
        else
        {
            GetComponent<AudioSource>().Pause();
        }


    }

    void Jump()
    {

        if (isGround)
        {
            myAnim.SetBool("Jump", false);
            canDoubleJump = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if(isGround)
            {
                myAnim.SetBool("Jump", true);
                Instantiate(Resources.Load("Audio/tiao"),gameObject.transform);
                Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
                myRigidbody.velocity = Vector2.up * jumpVel;
                
            }
            else
            {
                if (!isWall)
                {
                    if (canDoubleJump)
                    {
                        myAnim.SetBool("Jump", true);
                        Instantiate(Resources.Load("Audio/tiao"), gameObject.transform);
                        Vector2 doubleJumpVel = new Vector2(0.0f, doulbJumpSpeed);
                        myRigidbody.velocity = Vector2.up * doubleJumpVel;
                        canDoubleJump = false;
                    }
                }
                
            }
        }
    }

    public void CanRun()
    {
        canRun = true;

    }

    void WallJump()
    {
        

        if (Input.GetButtonDown("Jump"))
        {
            if (canWallJump)
            {
                myAnim.SetBool("Jump", true);
                Instantiate(Resources.Load("Audio/tiao"), gameObject.transform);
                canRun = false;
                if (direction == "right")
                {
                    Vector2 wallJumpVel2 = new Vector2(wallJumpSpeed2*-1, wallJumpSpeed1);
                    myRigidbody.velocity = wallJumpVel2;
                    Debug.Log(myRigidbody.velocity);
                }
                else if (direction == "left")
                {
                    Vector2 wallJumpVel2 = new Vector2(wallJumpSpeed2, wallJumpSpeed1);
                    myRigidbody.velocity = wallJumpVel2;
                    Debug.Log(myRigidbody.velocity);
                }
                //Vector2 wallJumpVel1 = new Vector2(0.0f, wallJumpSpeed1 );
                //myRigidbody.velocity = Vector2.up * wallJumpVel1;
                Invoke("CanRun",0.25f);
                
                //canWallJump = false;
            }
            
        }
    }

    void Transfer()
    {
        
            if (Input.GetMouseButtonDown(1))
            {
                if (!a)
                {
                    if (t1 > time)
                    {
                        a = Instantiate(Resources.Load<GameObject>("prefabs/fkuwu"));
                        Instantiate(Resources.Load<GameObject>("Audio/feibiao"), gameObject.transform);
                        a.transform.position = transform.position + Vector3.up;
                        myAnim.SetBool("Transfer", true);
                        t1 = 0;
                    }
                }
                else
                {
                    gameObject.transform.position = a.transform.position;
                    Destroy(a);
                    Instantiate(Resources.Load<GameObject>("Audio/tp"), gameObject.transform);
                }
            }
       
        


    }

    void Portal()
    {
        if (Input.GetKeyDown("r"))
        {
            Destroy(b1);
            Destroy(b2);
            Instantiate(Resources.Load("Audio/chadi"), gameObject.transform);
        }
        if (Input.GetKeyDown("e"))
        {
            myAnim.SetBool("Portal", true);
            if (!b1)
            {

                b1 = Instantiate(Resources.Load<GameObject>("portal1"));
                Instantiate(Resources.Load("Audio/chadi"), gameObject.transform);
                b1.transform.position =transform.position+Vector3.up;
                b1.gameObject.GetComponent<Portal>().other = b1;
                Debug.Log(b1.transform.position);
                Debug.Log(leftHand.transform.position);
            }
            else if (!b2)
            {
                b2 = Instantiate(Resources.Load<GameObject>("portal2"));
                Instantiate(Resources.Load("Audio/chadi"), gameObject.transform);
                b2.transform.position = transform.position + Vector3.up;
                b1.gameObject.GetComponent<Portal>().other = b2;
                b2.gameObject.GetComponent<Portal>().other = b1;
                Debug.Log(b2.transform.position);
            }
            else
            {

                b1.transform.position =transform.position + Vector3.up;
                Instantiate(Resources.Load("Audio/chadi"), gameObject.transform);

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grass")
        {
               GetComponent<AudioSource>().clip = Resources.Load<AudioSource>("Audio/zoulu(caodi)").clip;
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }
            Debug.Log("Grass");
        }
        
    }



}
