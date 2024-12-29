using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ControlCamera : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    public Action CamAction;
    // Start is called before the first frame update
    void Start()
    {
        CamAction += FollowPlayer;
        StartCoroutine("Follow");
    }


    void FollowPlayer()
	{
        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform);
	}

    public void StopFollow()
    {
        Debug.Log("STOP");
        CamAction = null;
    }


    IEnumerator Follow()
    {
        while (player != null)
        {
            FollowPlayer();
            yield return null;
        }
    }
}
