﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving2 : MonoBehaviour
{
    private Transform position;
    private GameObject animal;

    // Start is called before the first frame update
    void Start()
    {
        position = this.GetComponent<Transform>();
        animal = null;
    }

    // Update is called once per frame
    public void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W))
        {
            position.transform.Translate(new Vector3(0, 0, 0.9f * GetComponent<Wolf>().speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D))
        {
            position.transform.Translate(new Vector3(0.01f, 0.0f, 0.0f));
            position.Rotate(new Vector3(0, 1, 0), 1.0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            position.transform.Translate(new Vector3(-0.01f, 0.0f, 0.0f));
            position.Rotate(new Vector3(0, -1, 0), 1.0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            position.transform.Translate(new Vector3(0f, 0.0f, -0.05f));

        }

        if (Input.GetButton("Sprint"))
        {
            position.transform.Translate(new Vector3(0, 0, 1.2f * GetComponent<Wolf>().speed * Time.deltaTime));

        }

        if (Input.GetButton("Eat"))
        {

            if (animal!= null && Vector3.Distance(this.gameObject.transform.position, animal.gameObject.transform.position ) < 2.0f)
            {
                GameObject.Destroy(animal);
            }
        }

        //if (Input.GetKey(KeyCode.Space))
        //{
        //    Vector3 oldPos = position.position;
        //    GetComponent<Rigidbody>().AddForce(new Vector3(0, 50f, 0));
        //}
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Animal"))
        {
            animal = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Animal"))
        {
            animal = null;
        }
    }
}
