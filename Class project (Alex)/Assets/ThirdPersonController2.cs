using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// hi there
public class ThirdPersonController2 : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public float speed = 6f;
    

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal,0f,vertical).normalized;

        if(direction.magnitude>=0.1f){

            float targetangle = Mathf.Atan2(direction.x,direction.y) *Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f,targetangle,0f);
            controller.Move(direction*speed*Time.deltaTime);
        }
    }
}
