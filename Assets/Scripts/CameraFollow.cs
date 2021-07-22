using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing;

    public Vector2 minPosition;
    public Vector2 maxPosition;
    private float i=0;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        if(target != null)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Vector3 targetPos = target.position;
                targetPos.z = transform.position.z;
                targetPos.x = Mathf.Clamp(targetPos.x, minPosition.x, maxPosition.x);
                if (i < 4)
                {
                    i += Time.deltaTime*5;
                    

                }
                targetPos.y = Mathf.Clamp(targetPos.y + 3, minPosition.y, maxPosition.y) + i;
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);

            }
            else if(Input.GetKey(KeyCode.S))
            {
                Vector3 targetPos = target.position;
                targetPos.z = transform.position.z;
                targetPos.x = Mathf.Clamp(targetPos.x, minPosition.x, maxPosition.x);
                if (i > -4)
                {
                    i -= Time.deltaTime*5;
                   

                }
                targetPos.y = Mathf.Clamp(targetPos.y + 3, minPosition.y, maxPosition.y) + i;
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);

            }
            else if (transform.position != target.position)
            {
               
                Vector3 targetPos = target.position;
                targetPos.z = transform.position.z;
                targetPos.x = Mathf.Clamp(targetPos.x, minPosition.x, maxPosition.x);
                if (i > 0.2)
                {
                    i -= Time.deltaTime * 10;

                }
                else if(i<-0.2)
                {
                    i += Time.deltaTime * 10;
                }
                else
                {
                    i = 0;
                }
                targetPos.y = Mathf.Clamp(targetPos.y + 3, minPosition.y, maxPosition.y) + i;
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
            }
            
        }
    }

    public void SetCamPosLimit(Vector2 minPos, Vector2 maxPos)
    {
        minPosition = minPos;
        maxPosition = maxPos;
    }
}
