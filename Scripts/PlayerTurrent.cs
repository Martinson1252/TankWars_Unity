using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerTurrent : PlayerComponent
{
    public GameObject sphere;
    Camera cam;
    Vector3 turretPos,dir;
    Quaternion rotat;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }


    void Rotate()
	{
        if (Input.touchCount == 2)
        {
            UnityEngine.Touch touch2 = Input.GetTouch(1);
            if (touch2.phase == TouchPhase.Began)
            // || Input.GetMouseButtonUp(0) && readyToShoot && MouseOverEnemy)
            {
                turretPos = Input.GetTouch(1).position;
            }
        }
        if (Input.touchCount == 1)
        {
            UnityEngine.Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            // || Input.GetMouseButtonUp(0) && readyToShoot && MouseOverEnemy)
            {
                turretPos = Input.GetTouch(0).position;
            }
        }
        if(Input.touchCount<=0) turretPos = Input.mousePosition;

        Ray ray = cam.ScreenPointToRay(turretPos);

        if (Physics.Raycast(ray, out RaycastHit hit))
            sphere.transform.position = hit.point;
        dir = hit.point - transform.position;
        rotat = Quaternion.LookRotation(dir);
        rotat.x = rotat.z = 0;
        turrent.transform.rotation = rotat;

        
	}
}
