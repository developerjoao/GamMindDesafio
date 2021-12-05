using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public GameObject instructionCanvas;

    public void ShowInstructions()
    {
        instructionCanvas.SetActive(true);
    }
    public void DisableInstructions()
    {
        instructionCanvas.SetActive(false);
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
