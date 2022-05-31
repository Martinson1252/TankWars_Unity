using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurrent : PlayerComponent
{
    public GameObject sphere;
    Camera cam;
    Vector3 mouseWPos,dir;
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
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
            sphere.transform.position = hit.point;
        dir = hit.point - transform.position;
        rotat = Quaternion.LookRotation(dir);
        rotat.x = rotat.z = 0;
        turrent.transform.rotation = rotat;

        
	}
}
