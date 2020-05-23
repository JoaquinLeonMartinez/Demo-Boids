using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Boid))]

public class BoidContainer : MonoBehaviour
{
    public float radious; //tal y como usaremos este radio , sera con respecto al punto 0,0,0 de la escena

    public float containerForce;

    private Boid boid;

    void Start()
    {
        boid = GetComponent<Boid>();
    }

    void Update()
    {
        if (boid.transform.position.magnitude > radious)
        {
            boid.velocity += this.transform.position.normalized * (radious - boid.transform.position.magnitude)  * containerForce * Time.deltaTime;
        }
    }
}
