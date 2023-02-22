using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombienoise : MonoBehaviour
{
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("zombieplay", 5f, Random.Range(5f, 15f) );
        zombieplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void zombieplay(){

source.Play();

    }
}
