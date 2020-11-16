using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour
{
    public GameObject BoidVisual;
    public List<Boid> AllBoids;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject temp = Instantiate(BoidVisual, new Vector2(Random.Range(-9f, 9f), Random.Range(-5f, 5f)), new Quaternion(0, 0, 0, 0));
            AllBoids.Add(temp.GetComponent<Boid>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Boid boid in AllBoids)
        {

            Vector3 v1 = SteerAway(boid);
            Vector3 v2 = matchVelocity(boid);
            Vector3 v3 = towardsCenter(boid);

            boid.velocity = boid.velocity + v1 + v2 + v3;
            Debug.Log(v2);
            boid.velocity = boid.velocity.normalized / 10;

            if (boid.transform.position.y > 6f)
            {
                boid.transform.position = new Vector2(boid.transform.position.x, -5.4f);
            }

            if (boid.transform.position.y < -6f)
            {
                boid.transform.position = new Vector2(boid.transform.position.x, 5.4f);
            }

            if (boid.transform.position.x > 11)
            {
                boid.transform.position = new Vector2(-9.9f, boid.transform.position.y);
            }

            if (boid.transform.position.x < -11)
            {
                boid.transform.position = new Vector2(9.9f, boid.transform.position.y);
            }

            boid.transform.position = Vector3.MoveTowards( boid.transform.position, boid.transform.position + boid.velocity, 1f);
        }
    }

    Vector3 SteerAway(Boid boid)
    {
        Vector3 steerDir = Vector3.zero;
        foreach (Boid boid2 in AllBoids)
        {
            if (boid2 != boid && Vector2.Distance(boid2.transform.position, boid.transform.position) < boid.visionRadius)
            {
                steerDir += (boid.transform.position - boid2.transform.position).normalized;
            }
        }

        return (steerDir / 100).normalized;
    }

    Vector3 towardsCenter(Boid boid)
    {
        Vector3 steerDir = Vector3.zero;

        int numberOfNeighbours = 0;

        foreach (Boid boid2 in AllBoids)
        {
            if (boid2 != boid && Vector2.Distance(boid2.transform.position, boid.transform.position) < boid.visionRadius)
            {
                numberOfNeighbours += 1;
                steerDir += boid2.transform.position.normalized;
            }
        }

        if (numberOfNeighbours != 0)
            steerDir /= numberOfNeighbours;

        return (steerDir / 100).normalized;
    }

    Vector3 matchVelocity(Boid boid)
    {
        Vector3 perceivedVelocity = Vector3.zero;

        int numberOfNeighbours = 0;
        foreach (Boid boid2 in AllBoids)
        {
            if (boid2 != boid && Vector2.Distance(boid2.transform.position, boid.transform.position) < boid.visionRadius)
            {
                numberOfNeighbours += 1;
                perceivedVelocity += boid2.velocity.normalized;
            }
        }

        if (numberOfNeighbours != 0)
            perceivedVelocity /= numberOfNeighbours;

        return (perceivedVelocity / 8).normalized;

    }
}
