using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Boid))]

public class BoidRepulsionBehaviour : MonoBehaviour
{
    private Boid boid;

    public float radious;

    public float repulsionForce;

    void Start()
    {
        boid = GetComponent<Boid>();
    }

    // Update is called once per frame
    void Update()
    {
        var boids = FindObjectsOfType<Boid>();
        var average = Vector3.zero;
        var found = 0;

        foreach (var boid in boids.Where(b => b != boid))
        {
            var diff = boid.transform.position - this.transform.position;
            if (diff.magnitude < radious)
            {
                average += diff; //hace la media para encontrar el centro pero va luego hacia el lado contrario
                found += 1;
            }
        }

        if (found > 0)
        {
            average = average / found;
            boid.velocity -= Vector3.Lerp(Vector3.zero, average, average.magnitude / radious) * repulsionForce;

        }
    }
}
