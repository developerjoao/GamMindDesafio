using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public static GameManager Instance
    {
        get {return _instance;}
    }

    void MakeInstance()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Awake()
    {
        MakeInstance();
    }


    public CameraManager cameraRef;
    public PlayerBehaviour player;

    // Start is called before the first frame update
    void Start()
    {
        pageCount.text = pageCountInt.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Management de elementos visuais
    public GameObject interactButton;
    public TextMeshProUGUI interactText;
    public void ShowInteractButton()
    {
        interactText.text = "Interagir";
        interactButton.SetActive(true);
    }

    public void DisableInteractButton()
    {
        interactButton.SetActive(false);
    }
    
    public int pageCountInt = 0;
    public TextMeshProUGUI pageCount;
    public void UpdatePageCount()
    {
        pageCountInt += 1;
        pageCount.text = pageCountInt.ToString();
    }

    public GameObject zoneHint;
    public TextMeshProUGUI zoneName;
    public bool isShowing = false;
    public void ShowZoneName(string zoneCollided)
    { 
        StopCoroutine(DisplayZoneName());
        zoneHint.SetActive(true);
        zoneName.text = zoneCollided;
        StartCoroutine(DisplayZoneName());
    }

    private IEnumerator DisplayZoneName()
    {
        yield return new WaitForSeconds(3.0f);
        zoneHint.SetActive(false);
    }
    //Fim do management de elementos visuais


    //Atualização dos estados do jogo
    public TextMeshProUGUI[] challengeState;
    public void ChangeChallengeState(int index)
    {
        challengeState[index].text = "Concluído!";
    }

    public void ChangePlayerState(char state)
    {
        player.ChangeState(state);
    }
    //Fim da atualização dos estados do jogo
}
