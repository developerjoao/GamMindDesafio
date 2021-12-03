using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //seguir jogador
    public GameObject player;
    public GameObject currentTarget;
    public Vector3 offset;
    public Vector3 cameraPosition;

    //mostrar desafio
    public bool onChallenge = false;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - currentTarget.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!onChallenge)
        {
            cameraPosition = currentTarget.transform.position + offset;
            transform.position = cameraPosition;

            transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation,Time.deltaTime * 10f);
        }
    }


    public void ChangeTarget(GameObject newTarget)
    {
        currentTarget = newTarget;

        cameraPosition = currentTarget.transform.position + offset;
        transform.position = cameraPosition;

        onChallenge = true;
    }

    public void ReturnCameraToPlayer()
    {
        currentTarget = player;
    }
}
