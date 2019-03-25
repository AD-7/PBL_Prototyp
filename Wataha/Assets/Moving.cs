using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speed = 0.1f;
    private Transform position;
    public GameObject wolves;
    // Start is called before the first frame update
    void Start()
    {
        position = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    public void Update()
    {
     
   
        if (Input.GetKey(KeyCode.W))
        {
            position.transform.Translate(new Vector3(0, 0, speed));
        }
        if (Input.GetKey(KeyCode.D))
        {
           position.transform.Translate(new Vector3(0.01f, 0.0f, 0.0f));
            position.Rotate(new Vector3(0, 1, 0), 0.4f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            position.transform.Translate(new Vector3(-0.01f, 0.0f, 0.0f));
            position.Rotate(new Vector3(0, -1, 0), 0.4f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            position.transform.Translate(new Vector3(0f, 0.0f, -0.05f));
           
        }
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    Vector3 oldPos = position.position;
        //    GetComponent<Rigidbody>().AddForce(new Vector3(0, 50f, 0));
        //}
    }
}
