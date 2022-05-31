using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : PlayerComponent
{
    public GameObject shell;
    public Transform firepoint;
    public AudioSource fireS;
    public PlayerMovement p_mov;
    public float sTime, time;
    public bool readyToShoot;
    // Start is called before the first frame update
    void Start()
    {
        readyToShoot = false;
        time = sTime = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Wait();
        if (Input.GetMouseButtonUp(0) && readyToShoot)
        {
            Shoot();
            sTime = time;
            readyToShoot = false;
        }
    }

    void Shoot()
	{
        fireS.Play();
        GameObject SHELL = Instantiate(shell);
        SHELL.transform.GetComponent<Projectile>().type = Projectile.Type.playerProjectile;
        SHELL.transform.position = firepoint.position;
        SHELL.transform.rotation = turrent.transform.rotation;
        SHELL.GetComponent<Rigidbody>().AddForce(turrent.transform.forward * (p_mov.movement.magnitude*0.2f + 12) , ForceMode.VelocityChange); 
	}

    void Wait()
    {
        if (sTime <= 0) readyToShoot = true;
        else
        {
            sTime -= Time.deltaTime;
        }
    }
}
