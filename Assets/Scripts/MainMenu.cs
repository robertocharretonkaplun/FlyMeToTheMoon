using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public GameObject pauseMenu;
  public void PlayGame()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }

  public void ActivateMenu()
  {
    pauseMenu.SetActive(true);
  }

  public void GoToMenu()
  {
    SceneManager.LoadScene("Main Menu");
  }

  public void QuitGame()
  {
    Application.Quit();
  }
}
