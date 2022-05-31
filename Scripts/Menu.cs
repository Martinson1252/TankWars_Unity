using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    public Button startB,creditB,workShopB,ExitB;
    public GameObject creditScreen,levelsScreen;
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        startB = root.Q<Button>("Play");
        startB.clicked += StartLevel;
        creditB = root.Q<Button>("Credit");
        creditB.clicked += StartCredits;
        workShopB = root.Q<Button>("WorkShop");
        ExitB = root.Q<Button>("Exit");
        ExitB.clicked += Exit;

    }

    
    void StartLevel()
    {
        
        levelsScreen.SetActive(true);
        gameObject.SetActive(false);
    }

    void StartCredits()
    {
        creditScreen.SetActive(true);
        gameObject.SetActive(false);
    }

    void Exit()
    {
        Application.Quit();
    }

    public void SetButtonsAgain()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        startB = root.Q<Button>("Play");
        creditB = root.Q<Button>("Credit");
        startB.clicked += StartLevel;
        creditB.clicked += StartCredits;
    }
}
