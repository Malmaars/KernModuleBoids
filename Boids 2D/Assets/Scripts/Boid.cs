using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public Vector3 velocity;
    public float visionRadius = 2f;
    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        velocity /= 30;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
