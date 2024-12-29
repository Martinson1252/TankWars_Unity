using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Levels : MonoBehaviour
{
    public Button exitB, playB;
    public GameObject menuScreen, levelsScreen;
    public VisualElement root;
    public RadioButtonGroup radiogroup;
    void Setup()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        playB = root.Q<Button>("Play");
        playB.clicked += () => StartLevel();
        exitB = root.Q<Button>("Exit");
        exitB.clicked += () => GoToMenuScreen();
        radiogroup = root.Q<RadioButtonGroup>("LevelSelector");
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
        SceneManager.LoadScene(radiogroup.value + 1);
        Debug.Log(radiogroup.value);
        //levelsScreen.SetActive(true);
        //gameObject.SetActive(false);
    }

    void GoToMenuScreen()
    {
        //exitB.clicked += ()=> GoToMenuScreen();
        menuScreen.SetActive(true);
        levelsScreen.SetActive(false);
    }

   
}
