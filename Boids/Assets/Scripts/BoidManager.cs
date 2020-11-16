using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BoidManager : MonoBehaviour
{
    List<Boid> Boids;
    // Start is called before the first frame update
    void Start()
    {
        Boids = new List<Boid>();

        //Spawn Boids
        for(int i = 0; i < 20; i++)
        {
            GameObject boidBody = Resources.Load("BoidPrefab") as GameObject;

            GameObject bodytemp = Instantiate(boidBody, new Vector3(Random.Range(-10f, 10f), Random.Range(1f, 20f), Random.Range(-10f, 10f)),
                new Quaternion(Random.Range(-1f,1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f,1f)));

            Boid boidtemp = new Boid(bodytemp);
            Boids.Add(boidtemp);
            boidtemp.velocity = bodytemp.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v1, v2, v3;
        foreach (Boid boid in Boids)
        {
            //check rule 1
            v1 = boid.Rule1(Boids);

            //check rule 2
            v2 = boid.Rule2(Boids);

            //check rule 3
            v3 = boid.Rule3(Boids);

            //change position
            boid.velocity = boid.velocity + v1 + v2 + v3;
            boid.velocity = boid.velocity.normalized;
            boid.boidBody.transform.position = boid.boidBody.transform.position + boid.velocity;
        }
    }
}
