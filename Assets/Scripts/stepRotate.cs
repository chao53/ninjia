using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepRotate : MonoBehaviour
{
    public float rotateSpeed = 0.5f;
    Vector3 v3 = new Vector3(0,1,0);
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(v3*rotateSpeed);
    }
}
