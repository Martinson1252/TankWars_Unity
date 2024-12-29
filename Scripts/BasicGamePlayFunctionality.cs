using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BasicGamePlayFunctionality : MonoBehaviour
{

    public ToggleGroup tg;
    string levN;
    public void RestartActualLevel()
    {
        Scene active = SceneManager.GetActiveScene();
        SceneManager.LoadScene(active.name);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void NextLevel()
    {
        Scene active = SceneManager.GetActiveScene();
        SceneManager.LoadScene(active.buildIndex+1);
    }

    public void LoadLevelFromSelector(TextMeshProUGUI map)
    {
        SceneManager.LoadScene(map.text+"_"+levN);
    }

    public void SetActiveLevel(TextMeshProUGUI t)
    {
        levN = t.text;
    }
  
}
