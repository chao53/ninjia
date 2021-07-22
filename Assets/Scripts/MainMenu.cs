using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject choice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);

    }

    public void Choice(int i)
    {
        SceneManager.LoadScene(i);

    }

    public void Back()
    {
        mainMenu.SetActive(true);
        choice.SetActive(false);
    }

    public void GoChoice()
    {
        mainMenu.SetActive(false);
        choice.SetActive(true);
    }
}
