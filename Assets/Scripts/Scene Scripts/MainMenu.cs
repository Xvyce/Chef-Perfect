using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public void LoadScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }









    //public void PlayGame () //From Main Menu or Victory //no. 0
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Going to no.1

    //}

    public void PauseMenu() //Pause Scene //no.1
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!!!");
        Application.Quit();
    }

    //public void MainMenu1() //From Victory //no.0
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    //}

    //public void MainMenu2() //From Congratulations //no.0
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    //}





    //public void RetryMenu1() //From GameOver //no.2
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    //}

    //public void RetryMenu2() //From Victory //no.2
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    //}





    //public void RestartScene()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}

    //public void LoadPreviousScene()
    //{
    //    if (SceneManager.GetActiveScene().buildIndex > 0)
    //    {
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    //    }
    //    else RestartScene();
    //}

    //public void LoadNextScene()
    //{
    //    if ((SceneManager.GetActiveScene().buildIndex + 1) < SceneManager.sceneCount)
    //    {
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //    }
    //    else RestartScene();
    //}



}
