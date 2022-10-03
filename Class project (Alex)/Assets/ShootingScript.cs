using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{

    public GameObject bullet;
    public Transform spawn;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
    if(Input.GetMouseButtonDown(0)){
        Instantiate(bullet,spawn.position,spawn.rotation);
    }
    }
}
