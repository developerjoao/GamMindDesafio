using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public GameObject myCanvas;
    public InteractableObject myObject;
    
    public void CompleteChallenge(int index)
    {
        myObject.CompletedTask();
        myCanvas.SetActive(false);
        GameManager.Instance.AddPage(index);
        GameManager.Instance.ChangePlayerState('d');
        GameManager.Instance.ChangeChallengeState(index);
        GameManager.Instance.UpdatePageCount();
        GameManager.Instance.ReturnCameraToPlayer();
    }

    public void ClosePanel()
    {
        myCanvas.SetActive(false);
        GameManager.Instance.ChangePlayerState('d');
        GameManager.Instance.ReturnCameraToPlayer();
    }
}
