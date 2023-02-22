using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float life_span = 3f;
    public float speed = 10f;
    private Rigidbody RB;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        RB.AddForce(RB.transform.forward * 100 * speed);
        Destroy(gameObject, life_span);

    }
}
