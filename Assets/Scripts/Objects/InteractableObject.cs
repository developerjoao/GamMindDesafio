using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject myCanvas;

    public void Interact()
    {
        if(!myCanvas.activeSelf)
        {
            myCanvas.SetActive(true);
            GameManager.Instance.ChangePlayerState('c');
            GameManager.Instance.interactText.text = "Sair";
        }else{
            GameManager.Instance.ChangePlayerState('d');
            myCanvas.SetActive(false);
        }
    }
}
