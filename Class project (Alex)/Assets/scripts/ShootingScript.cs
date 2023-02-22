using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{

    public GameObject bullet;
    public Transform spawn;
    public AudioSource source;
    public float fireRate;
    public float fireTime; 

    // Start is called before the first frame update
    void Start()
    {
           fireTime = fireRate;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(fireTime >= 0){fireTime -= Time.deltaTime;}
    if(Input.GetMouseButtonDown(0)){
        Shoot();
    }
    }
    
    public void Shoot(){
        if(fireTime > 0){return; }
        Instantiate(bullet,spawn.position,spawn.rotation);
        source.Play();
    fireTime = fireRate;
    }
}
