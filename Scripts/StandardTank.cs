using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.AI;

public class StandardTank : EnemyTank,IHitable
{
	
	private void Start()
	{
		range_radius = 25;
		agent.stoppingDistance = 8;
		agent.speed = 3.5f;
        time = sTime = 2;
        Debug.Log(sTime);
    }


	
}
