using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    //Variáveis de estado
    /*
    d - Default (padrão / Nada associado / cutscene)
    m - Movimentação (Pode se mover e interagir)
    c - Em desafio (Não pode se mover até sair do estado)
    */
    public char myState = 'd';

    public Vector3 startPosition;

    //Variáveis de movimentação
    public CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 10;
    public float rotationSpeed = 180;
    private bool groundedPlayer;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<CharacterController>();
        startPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            PlayerInteract();
        }
        if(myState == 'd')
        {
            FreeMovement();
        }
    }


    RaycastHit hit;
    public void FreeMovement()
    {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2.0f) && hit.transform.tag == "Interactable")
        {
            GameManager.Instance.ShowInteractButton();
        }else{
            GameManager.Instance.DisableInteractButton();
        }
        CheckZone();

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime, 0);
 
        Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        move = this.transform.TransformDirection(move);
        controller.Move(move * speed);
        this.transform.Rotate(this.rotation);

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    
    }

    public void PlayerInteract()
    {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2.0f) && hit.transform.tag == "Interactable")
            hit.collider.gameObject.GetComponent<InteractableObject>().Interact();
    }


    public void CheckZone()
    {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2.0f) && hit.transform.tag == "ZoneHit")
        {
            GameManager.Instance.ShowZoneName(hit.collider.gameObject.name);
        }
    }

    public void ChangeState(char state)
    {
        myState = state;
    }

    public void Respawn()
    {
        gameObject.transform.position = startPosition;
    }
}
