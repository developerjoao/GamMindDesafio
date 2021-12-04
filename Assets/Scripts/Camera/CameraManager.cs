using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //seguir jogador
    public GameObject player;
    public GameObject currentTarget;
    public Vector3 playerOffset;
    public Vector3 objectOffset;
    public Vector3 cameraPosition;
    public bool playerTarget = true;

    // Start is called before the first frame update
    void Start()
    {
        playerOffset = transform.position - currentTarget.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTarget)
        {
            cameraPosition = currentTarget.transform.position + playerOffset;
            transform.position = cameraPosition;

            transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation,Time.deltaTime * 10f);
        }else{
            cameraPosition = currentTarget.transform.position + objectOffset;
            transform.position = cameraPosition;
        }
        
    }


    public void ChangeTarget(GameObject newTarget)
    {
        currentTarget = newTarget;
        playerTarget = false;

    }

    public void ReturnCameraToPlayer()
    {
        currentTarget = player;
        playerTarget = true;
    }
}
