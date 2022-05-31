using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class winScreen : MonoBehaviour
{
    Button backB, nextLB;


    private void Start()
    {
        SetButtons();
    }

    public void SetButtons()
    {
        BasicGamePlayFunctionality Manager = new BasicGamePlayFunctionality();
        var root = GetComponent<UIDocument>().rootVisualElement;
        backB = root.Q<Button>("backToMenu");
        backB.clicked += Manager.GoToMainMenu;
        nextLB = root.Q<Button>("nextLevel");
        nextLB.clicked += Manager.NextLevel;
    }
}
