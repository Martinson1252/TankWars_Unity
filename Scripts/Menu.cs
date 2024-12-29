using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    public Button startB,creditB,workShopB,ExitB;
    public GameObject creditScreen,levelsScreen;

    void Setup()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        startB = root.Q<Button>("Play");
        startB.clicked += StartLevel;
        creditB = root.Q<Button>("Credit");
        creditB.clicked += StartCredits;
        ExitB = root.Q<Button>("Exit");
        ExitB.clicked += Exit;
        workShopB = root.Q<Button>("WorkShop");
    }

    private void OnEnable()
    {
        Setup();
    }

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    
    void StartLevel()
    {
        levelsScreen.SetActive(true);
        gameObject.SetActive(false);
        //startB.clicked += StartLevel;
    }

    void StartCredits()
    {
        creditScreen.SetActive(true);
        gameObject.SetActive(false);
        //creditB.clicked += StartCredits;
    }

    void Exit()
    {
        Application.Quit();
    }

    public void ResetButtons()
    {
        startB.clicked += StartLevel;
        creditB.clicked += StartCredits;
    }

}
