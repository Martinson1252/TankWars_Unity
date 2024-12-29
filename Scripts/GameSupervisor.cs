using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Threading;
using System.Threading.Tasks;
public class GameSupervisor : MonoBehaviour
{
    public List<GameObject> enemyL;
    public GameObject Player,winScreen,myCamera;
    // Start is called before the first frame update
    void Start()
    {
        WaitGameToLoad();
        Scene active = SceneManager.GetActiveScene();
        //Debug.Log(enemyL.Count+"LLL");
    }

     async void WaitGameToLoad()
	 {
        Time.timeScale = 0;
            while (!SceneManager.GetActiveScene().isLoaded)
            {   
                await Task.Yield();
                        
            }
            print("FINISHED!");
        Time.timeScale = 1;
        PrepareLevel();
    }

	void PrepareLevel()
	{
        LoadEnemies();
	}

    void LoadEnemies()
	{
        foreach( GameObject a in enemyL)
		{
             a.SetActive(true);
             a.GetComponent<EnemyTank>().target = Player.transform;
		}
	}

    public void CheckGameState()
    {
        StartCoroutine("LetToCheckIfWon");
        StartCoroutine("LetToCheckIfLose");
    }

    IEnumerator LetToCheckIfWon()
    {
        yield return new WaitForSeconds(2.5f);
        int l = 0;
        foreach (GameObject enemy in enemyL)
            if (enemy == null)
                l++;
        if (enemyL.Count == l)
            winScreen.SetActive(true);
    
      
    }

    IEnumerator LetToCheckIfLose()
    {
        yield return null;
        if (Player == null)
        {
            myCamera.GetComponent<ControlCamera>().StopFollow();
        }
    }
  

}

  

