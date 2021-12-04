using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject myCanvas;
    public bool isCompleted = false;
    public GameObject myPage;

    public void Interact()
    {
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
