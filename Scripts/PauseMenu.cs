using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenu : BasicGamePlayFunctionality
{
    Button resume, quit;

    private void OnEnable()
    {
        Time.timeScale = 0;
        SetButtons();
    }

    // Start is called before the first frame update
    //void Start()
    //{
    //    Time.timeScale = 0;
    //    SetButtons();
    //}

    

    public void SetButtons()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        resume = root.Q<Button>("resume");
        quit = root.Q<Button>("quit");
        resume.clicked += Resume;
        quit.clicked += GoToMainMenu;
    }

    void Resume()
    {
        Time.timeScale = 1;
        SetButtons();
        gameObject.SetActive(false);
    }

    
  
}
