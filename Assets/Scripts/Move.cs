using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private GameObject camera;
    public GameObject point1;
    public GameObject point2;
    private Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        gameObject.transform.position = point2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float a = (camera.transform.position.x - camera.GetComponent<CameraFollow>().minPosition.x) / (camera.GetComponent<CameraFollow>().maxPosition.x - camera.GetComponent<CameraFollow>().minPosition.x);
        gameObject.transform.position = new Vector3((point2.transform.position.x-(point2.transform.position.x- point1.transform.position.x) * a), gameObject.transform.position.y, gameObject.transform.position.z);
    }
}
