using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    void MakeInstance()
    {
        if(_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = this;
        }else if(_instance != null)
        {
            Destroy(gameObject);
        }
    }

    void Awake()
    {
        MakeInstance();
    }


    public CameraManager cameraRef;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
