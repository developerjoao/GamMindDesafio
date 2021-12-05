using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        //DontDestroyOnLoad(gameObject);
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

    public GameObject firstPanel;
    public void StartGame()
    {
        firstPanel.SetActive(false);
        player.ChangeState('d');
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

    public void ChangeCameraTarget(GameObject newTarget)
    {
        cameraRef.ChangeTarget(newTarget);
    }

    public void ReturnCameraToPlayer()
    {
        cameraRef.ReturnCameraToPlayer();
    }
    //Fim do management de elementos visuais


    //Atualização dos estados do jogo
    public TextMeshProUGUI[] challengeState;
    public bool[] challengesWon;
    public InteractableObject[] taskObjects;
    public GameObject[] invWalls;
    public void ChangeChallengeState(int index)
    {
        challengeState[index].text = "Concluído!";
    }

    public void ChangePlayerState(char state)
    {
        player.ChangeState(state);
    }

    public void AddPage(int index)
    {
        challengesWon[index] = true;
        invWalls[index].SetActive(false);
    }

    public void ClearPages()
    {
        for(int i = 0; i< challengesWon.Length; i++){
            challengesWon[i] = false;
            challengeState[i].text = "Não concluído";
            taskObjects[i].ResetTask();
        }
        for(int i=0; i< invWalls.Length;i++)
        {
            invWalls[i].SetActive(true);
        }
        pageCountInt = 0;
        pageCount.text = pageCountInt.ToString();
    }

    public void KillPlayer()
    {
        ClearPages();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void WinGame()
    {
        SceneManager.LoadScene(2);
    }
    //Fim da atualização dos estados do jogo
}
