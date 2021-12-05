using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject myCanvas;
    public bool isCompleted = false;
    public bool isGhost = false;
    public bool isSwitch = false;
    public GameObject myPage;
    public GameObject switchObject;

    public void Interact()
    {
        if(GameManager.Instance.challengesWon[0] && isSwitch)
        {
            switchObject.SetActive(false);
        }
        if(isGhost)
        {
            GameManager.Instance.KillPlayer();
        }

        if(!isCompleted)
        {
            if(!myCanvas.activeSelf)
            {
                GameManager.Instance.ChangeCameraTarget(this.gameObject);
                myCanvas.SetActive(true);
                GameManager.Instance.ChangePlayerState('c');
                GameManager.Instance.interactText.text = "Sair";
            }else{
                GameManager.Instance.ReturnCameraToPlayer();
                GameManager.Instance.ChangePlayerState('d');
                myCanvas.SetActive(false);
            }
        }
    }

    public void CompletedTask()
    {
        isCompleted = true;
        myPage.SetActive(false);
    }

    public void ResetTask()
    {
        isCompleted = false;
        myPage.SetActive(true);
    }
}
