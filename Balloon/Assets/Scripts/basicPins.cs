using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicPins : MonoBehaviour
{
    float speed = 5f;
    float force = 20f;
    Vector3 vel;
    private float gravity;
    private Rigidbody rigidbody;
    private float sqrMag = 100f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody.velocity.sqrMagnitude < sqrMag)
        {
            gravity = 10f;
        }
        else {
            gravity = 0;
        }

        Physics.gravity = new Vector3(0f, 0f, gravity);
    }



}
