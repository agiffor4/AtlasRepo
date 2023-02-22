using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShootingController : MonoBehaviour
{
    public GameObject shot;
    public GameObject AmongUs_shot;
    public GameObject spawnFPS;
    public GameObject spawnTPS;
    public GameObject spawnMAG;
    public GameObject magazine;

    public GameObject gunFPS;
    public GameObject gunTPS;
    public bool Fperson = false;
    public AudioSource source;

    public AudioClip A_shot;
    public AudioClip A_AmongUs_shot;
    public AudioClip A_insertM;
    public AudioClip A_removeM;

    public float fireRate;
    public float fireTime;
    public int ammo;
    public int ammoMax;
    public Text ammoT; 
    public float reloadTime;

    public Animator anim;
    public bool AMONGUSMODE;
    // Start is called before the first frame update
    void Start()
    {fireTime = fireRate;
        SwitchShootState(Fperson);
        ammo = ammoMax;
        updateCanvas();


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.M))
        {
            AMONGUSMODE= !AMONGUSMODE;

        }
            if (fireTime >= 0){fireTime -= Time.deltaTime;}
        if (Input.GetMouseButtonDown(1))
        {
            Fperson = !Fperson;
            SwitchShootState(Fperson);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(AMONGUSMODE == true)
            {
                AMONGUSSHOOT();
            }else { Shoot(); }
           
        }

         if (Input.GetMouseButton(0))
        {
            if (AMONGUSMODE == true)
            {
                AMONGUSSHOOT();
            }
            else { Shoot(); }
        }

        if(Input.GetKeyDown(KeyCode.R)){StartCoroutine(reloadSequence());} 
    }

    public void SwitchShootState(bool f)
    {
        if (f == true)
        {
            gunTPS.SetActive(false);
            gunFPS.SetActive(true);
        }
        else
        {
            gunTPS.SetActive(true);
            gunFPS.SetActive(false);
        }
    }
public void Shoot(){
    if(ammo <= 0){
return;
    }
        if(fireTime > 0){return; }
        if (Fperson == true)
            {
                Instantiate(shot, spawnFPS.transform.position, spawnFPS.transform.rotation);
            }
            else
            {
                Instantiate(shot, spawnTPS.transform.position, spawnTPS.transform.rotation);
            }

        Playsound(A_shot);
                ammo -= 1;
                updateCanvas();
    fireTime = fireRate;}


    public void AMONGUSSHOOT()
    {
        if (ammo <= 0)
        {
            return;
        }
        if (fireTime > 0) { return; }
        if (Fperson == true)
        {
            Instantiate(AmongUs_shot, spawnFPS.transform.position, spawnFPS.transform.rotation);
        }
        else
        {
            Instantiate(AmongUs_shot, spawnTPS.transform.position, spawnTPS.transform.rotation);
        }

        Playsound(A_AmongUs_shot);
        ammo -= 1;
        updateCanvas();
        fireTime = fireRate;
    }
    public void reload(){
        ammo = ammoMax;
        updateCanvas();
    }
    public void updateCanvas(){
ammoT.text = new string(ammo + " / " + ammoMax);

    }
    public void Playsound(AudioClip clip){
    source.clip= clip;
        source.Play();
    }
    
     public IEnumerator reloadSequence(){
        anim.SetTrigger("reloadA");

        yield return new WaitForSeconds(0.6f);
        //eject mag 
        Playsound(A_removeM);
        yield return new WaitForSeconds(1.7f);
        //yield return new WaitForSeconds(reloadTime);
        Instantiate(magazine, spawnMAG.transform.position, spawnMAG.transform.rotation);
        yield return new WaitForSeconds(0.2f);
        //play insert mag sound
        Playsound(A_insertM);
        //add reload sound    
        reload();

    }
}
