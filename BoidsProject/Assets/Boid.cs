using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public Vector3 velocity;
    public float maxVelocity;

    public float minVelocity;

    public Color[] posibleColors;

    void Start()
    {
        //maxVelocity = 4;
        posibleColors = new Color[] {
            Color.red,
            Color.blue,
            Color.yellow,
            Color.green,
            Color.black
        };
        velocity = this.transform.forward * maxVelocity;
        //GetComponent<Renderer>().material.color = new Color((float)Random.Range(0, 255), (float)Random.Range(0, 255), (float)Random.Range(0, 255));
        GetComponent<Renderer>().material.color = posibleColors[Random.Range(0, posibleColors.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if (velocity.magnitude > maxVelocity)
        {
            velocity = velocity.normalized * maxVelocity;
        }
        else if (velocity.magnitude < minVelocity)
        {
            velocity = velocity.normalized * minVelocity;
        }

        this.transform.position += Time.deltaTime * velocity;
        this.transform.rotation = Quaternion.LookRotation(velocity);
    }
}
