using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UIElements;

public class PlayerShoot : PlayerComponent
{
    public Ray ray;
    public RaycastHit hit;
    public GameObject shell;
    public Transform firepoint;
    public AudioSource fireS;
    public PlayerMovement p_mov;
    public float shootTime, timeToReload;
    public bool readyToShoot, MousefirstOverUI, MouseOverEnemy;
    public GameObject sphere;
    public Animator anim;
    Camera cam;
    Vector3 turretPos, dir;
    Quaternion rotat;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        readyToShoot = true;
        MousefirstOverUI = true;
        MouseOverEnemy = true;
        timeToReload = 1.5f;
        shootTime = 0;
    }

    public void CheckInput()
    {
        if (Input.touchCount == 2)
        {
            Touch touch2 = Input.GetTouch(1);
            if (touch2.phase == TouchPhase.Began && readyToShoot && !EventSystem.current.IsPointerOverGameObject())
            // || Input.GetMouseButtonUp(0) && readyToShoot && MouseOverEnemy)
            {
                turretPos = Input.GetTouch(1).position;
                Shoot();
                shootTime = timeToReload;
                readyToShoot = false;
            }
        }
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && readyToShoot && !EventSystem.current.IsPointerOverGameObject())
            // || Input.GetMouseButtonUp(0) && readyToShoot && MouseOverEnemy)
            {
                turretPos = Input.GetTouch(0).position;
                Shoot();
                shootTime = timeToReload;
                readyToShoot = false;
            }
            
        }
        if (Input.touchCount == 0 && Input.GetMouseButtonDown(0) && readyToShoot)
        {
            turretPos = Input.mousePosition;
            Shoot();
            shootTime = timeToReload;
            readyToShoot = false;
        }

    }
    

    // Update is called once per frame
    void Update()
    {
        Wait();
        CheckInput();
        
    }

    void Shoot()
	{
        Ray ray = cam.ScreenPointToRay(turretPos);
        if (Physics.Raycast(ray, out RaycastHit hit))
            //sphere.transform.position = hit.point;
        dir = hit.point - transform.position;
        rotat = Quaternion.LookRotation(dir);
        rotat.x = rotat.z = 0;
        turrent.transform.rotation = rotat;
        fireS.Play();
        GameObject SHELL = Instantiate(shell);
        SHELL.transform.GetComponent<Projectile>().type = Projectile.Type.playerProjectile;
        SHELL.transform.position = firepoint.position;
        SHELL.transform.rotation = turrent.transform.rotation;
        SHELL.GetComponent<Rigidbody>().AddForce(turrent.transform.forward * (p_mov.movement.magnitude*0.2f + 12) , ForceMode.VelocityChange); 
	}

    void Wait()
    {
        if (shootTime <= 0) { readyToShoot = true; }
        else
        {
            if (reloadAnim.GetBool("reloading") == false) { reloadAnim.SetBool("reloading",true); reloadingStateTEXT.text = "Reloading...";}
            reloadBar.fillAmount = (timeToReload - shootTime);
            shootTime -= Time.deltaTime;
        }
        if (reloadAnim.GetBool("reloading") == true && readyToShoot == true) { reloadAnim.SetBool("reloading", false); reloadingStateTEXT.text = "Ready"; }
    }
}
