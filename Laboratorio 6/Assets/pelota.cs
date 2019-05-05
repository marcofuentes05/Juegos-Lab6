﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class pelota : MonoBehaviour
{
    private Vector3 pos;
    public static int powerUps = 0;
    public int nSaltos = 0;
    public float speed = 1f;
    public float moveSpeed = 0.5f;
    public GameObject prefab;
    public NavMeshAgent agent;
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (!gameObject)
            {
                Instantiate(prefab, pos,Quaternion.identity);
            }
        }
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.CompareTag("suelo"))
                {
                    agent.SetDestination(hit.point);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            float v = gameObject.GetComponent<Rigidbody>().velocity.y;

            if (Mathf.Abs(v)<=0.1f)
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(0, 50, 0), ForceMode.Impulse);
            }

        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Suelo" || collision.gameObject.tag == "Suelo1")
        {
            nSaltos = 0;
        }
        if (collision.gameObject.tag == "enemigo")
        {
            Destroy(gameObject);
        }
        
    }

    
}
