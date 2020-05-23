using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Boid))]
public class Explosion : MonoBehaviour
{

    private Boid boid;

    public float radious;

    public float explosionForce;

    public float explosiontimeMax;

    private float explosionTimer;

    void Start()
    {
        explosionTimer = 0;
        boid = GetComponent<Boid>();
    }

    // Update is called once per frame
    void Update()
    {
        if (explosionTimer >= explosiontimeMax)
        {
            //explosion();
            explosionTimer = 0;
        }
        else
        {
            explosionTimer += Time.deltaTime;
        }
    }


    public void explosion()
    {
        var boids = FindObjectsOfType<Boid>();
        var average = Vector3.zero;
        var found = 0;

        foreach (var boid in boids.Where(b => b != boid))
        {
            var diff = boid.transform.position - this.transform.position;
            if (diff.magnitude < radious)
            {
                average += diff; 
                found += 1;
            }
        }

        if (found > 0)
        {
            boid.maxVelocity = 999999;
            average = average / found;
            boid.velocity -= Vector3.Lerp(Vector3.zero, average, average.magnitude / radious) * explosionForce;

        }
    }
}
