using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid
{
    public Vector3 velocity;
    public GameObject boidBody;
    public Boid(GameObject body)
    {
        boidBody = body;
    }
    public Vector3 Rule1(List<Boid> allTheBoids)
    {
        Vector3 perceivedCentre = Vector3.zero;
        foreach (Boid boid in allTheBoids)
        {
            if(boid != this)
            {
                perceivedCentre = perceivedCentre + boid.boidBody.transform.position;
            }
        }
        Debug.Log(allTheBoids.Count);
        perceivedCentre = perceivedCentre / (allTheBoids.Count - 1);

        return (perceivedCentre - boidBody.transform.position) / 100;
    }

    public Vector3 Rule2(List<Boid> allTheBoids)
    {
        Vector3 c = Vector3.zero;
        foreach (Boid boid in allTheBoids)
        {
            if(boid != this)
            {
                if (Vector3.Magnitude(boid.boidBody.transform.position - boidBody.transform.position) < 300)
                {
                    //Debug.Log(Vector3.Distance(boid.boidBody.transform.position, boidBody.transform.position));
                    c = c - (boid.boidBody.transform.position - boidBody.transform.position) / 100;
                }
            }
        }
            return c;
    }

    public Vector3 Rule3(List<Boid> allTheBoids)
    {
        Vector3 perceivedVelocity = Vector3.zero;
        foreach (Boid boid in allTheBoids)
        {
            if (boid != this)
            {
                perceivedVelocity = perceivedVelocity + boid.velocity;
            }

            perceivedVelocity = perceivedVelocity / (allTheBoids.Count - 1);

        }

        return (perceivedVelocity - velocity) / 8;
    }
}
