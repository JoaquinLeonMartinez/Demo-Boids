using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoidScaredBehaviour : MonoBehaviour
{
    private Boid boid;

    public float radious;

    public float scaredForce;

    public bool scared;

    private float defaultMaxVelocity;

    void Start()
    {
        defaultMaxVelocity = 3;
        scared = false;
        boid = GetComponent<Boid>();
    }

    void Update()
    {
        if (scared)
        {
            runAway();
        }
    }


    public void runAway()
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
            defaultMaxVelocity = boid.maxVelocity;
            boid.maxVelocity = 20;
            average = average / found;
            boid.velocity -= Vector3.Lerp(Vector3.zero, average, average.magnitude / radious) * scaredForce;
            StartCoroutine(ReturnNormalState(boid));

        }

        scared = false;
    }

    IEnumerator ReturnNormalState(Boid _boid)
    {
        yield return new WaitForSeconds(3);
        _boid.maxVelocity = defaultMaxVelocity;
        //GetComponent<Renderer>().material.color = Color.red;
    }
}
