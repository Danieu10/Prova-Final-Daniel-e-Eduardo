using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
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
        SceneManager.LoadScene("preludio");
    }

    public void ControlsGame()
    {
        SceneManager.LoadScene("controles");
    }

    public void MenuGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void fasesGame()
    {
        SceneManager.LoadScene("1fase");
    }
    public void Game2()
    {
        SceneManager.LoadScene("2fase");
    }
    public void Game3()
    {
        SceneManager.LoadScene("3fase");
    }
    public void Game4()
    {
        SceneManager.LoadScene("4fase");
    }
    public void Game5()
    {
        SceneManager.LoadScene("5fase");
    }




}
