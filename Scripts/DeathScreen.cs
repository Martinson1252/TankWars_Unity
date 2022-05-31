using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DeathScreen : MonoBehaviour
{
    Button restartB, backB;


    private void Start()
    {
        SetButtons();
    }

    public void SetButtons()
    {
        BasicGamePlayFunctionality Manager = new BasicGamePlayFunctionality();
        var root = GetComponent<UIDocument>().rootVisualElement;
        restartB = root.Q<Button>("Restart");
        restartB.clicked += Manager.RestartActualLevel;
        backB = root.Q<Button>("Back");
        backB.clicked += Manager.GoToMainMenu;
    }

    
}
