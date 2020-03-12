using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables del movimiento del personaje

    
    public float jumpForce = 16f;
    public float runningSpeed = 2f;
    private Rigidbody2D playerRigidbody;
    public LayerMask groundMask;
    
    private Animator animator;
    private bool hasRotatedLeft = false;//Bandera si el jugador a rotado hacia la izquierda
    private SpriteRenderer playerSpriterenderer;
    Vector3 startPosition;

    private const string STATE_ALIVE = "isAlive";
    private const string STATE_ON_THE_GROUND = "isOnTheGround";
    private const string STATE_IS_WALKING = "Walking";
    private const string STATE_IS_QUIET = "Quiet";

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>(); //Constructor de RigiBody2D
        animator = GetComponent<Animator>(); //Constructor de las animaciones
        playerSpriterenderer = GetComponent<SpriteRenderer>(); // Constructor del spriterenderer

    }

    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
    }

    public void StartGame()//Start game desde el punto de vista del jugador
    {

        animator.SetBool(STATE_ALIVE, true);//Declaracion en verdadero  de la animacion del estado SiEstaVivo
        animator.SetBool(STATE_ON_THE_GROUND, true);//Declaracion en verdadero de la animacion del estado SiEstaTocandoElSuelo
        animator.SetBool(STATE_IS_WALKING, true);
        animator.SetBool(STATE_IS_QUIET, true);
        Invoke("RestartPosition", 0.2f);

    }

    void RestartPosition()
    {
        this.transform.position = startPosition;
        this.playerRigidbody.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //Si presiona esa tecla se efectua el metodo dentro del if
        if (Input.GetButtonDown("Jump"))
        {                
            Jump();
        }
        //if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        //{
        //    MoveRight();
        //}
        //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        //{
        //    MoveLeft();
        //}
        animator.SetBool(STATE_ON_THE_GROUND, IsTouchingTheGround());
        Debug.DrawRay(this.transform.position, Vector2.down * 1.4f, Color.black); //Testing: Dibuja una linea hacia abajo para ver si llega al suelo el centro del player
    }
    void MoveRight()//Moverse hacia la derecha
    {
        if (playerRigidbody.velocity.x < runningSpeed)//Si la velocidad en x es menor que runningspeed
        {
            if (hasRotatedLeft == true)
            {
                playerSpriterenderer.flipX = false;
           
            }
            playerRigidbody.velocity = new Vector2(runningSpeed, playerRigidbody.velocity.y);//Nuevo vector de velocidad en X en negativo que hace que el player se pueda mover a la derecha
        }
    }

    void MoveLeft()//Moverse hacia la izquierda
    {
        playerRigidbody.velocity = new Vector2(runningSpeed * -1, playerRigidbody.velocity.y);//Nuevo vector de velocidad en X en negativo que hace que el player se pueda mover a la izquierda
        if (playerRigidbody.velocity.x < 0)
        {
            playerSpriterenderer.flipX = true;//Cambio de sentido de los frames
            hasRotatedLeft = true;//Bandera de que efectivamente el jugador a rotado hacia la izquierda
        }
        else
        {
            playerSpriterenderer.flipX = false;
        }
    }
    void FixedUpdate()
    {
        if (GameManager.sharedInstance.currentState == GameState.inGame) //Si estamos dentro de la partida
        {
            //if (playerRigidbody.velocity.x < runningSpeed)
            //{
            //    playerRigidbody.velocity = new Vector2(runningSpeed, // x
            //                                           playerRigidbody.velocity.y); // y
            //}
            playerMovement();
        }
        else //Si no estamos dentro de la partida
        {
            playerRigidbody.velocity = new Vector2(0, playerRigidbody.velocity.y);
        }

    }


    void playerMovement()
    {

        float isWalking = Input.GetAxisRaw("Horizontal");

        if (isWalking != 0)
        { //is true

            animator.SetBool(STATE_IS_QUIET, false);
            animator.SetBool(STATE_IS_WALKING, true);
            playerRigidbody.velocity = new Vector2(isWalking * runningSpeed, playerRigidbody.velocity.y);
            playerSpriterenderer.flipX = (isWalking == -1) ? true : false;
            //if the value returns -1 that means is walking to the left and we need to make a flip in X
        }
        else
        {
            animator.SetBool(STATE_IS_QUIET, true);
            animator.SetBool(STATE_IS_WALKING, false);
        }

    }

    //Funcion para saltar
    void Jump()
    {
        if (GameManager.sharedInstance.currentState == GameState.inGame) //Si estamos dentro de la partida
        {
            if (IsTouchingTheGround())
            {
                playerRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    //Nos indica si el personaje esta o no tocando el suelo
    bool IsTouchingTheGround()
    {
        if (Physics2D.Raycast(this.transform.position, // Desde donde estoy
                             Vector2.down, // Trazar rayo hacia abajo
                             1.4f, //Distancia maxima de 1.5 m desde el centro del personaje hasta el suelo
                             groundMask)) //Contra la mascara del suelo

        {
            //TODO: programar logica de contacto con el suelo
            //animator.enabled = true;
            //GameManager.sharedInstance.currentState = GameState.inGame;
            return true;
        }
        else
        {
            //TODO: programar logica de no contacto con el suelo
            //animator.enabled = false;
            return false;
        }
    }

    public void Die()
    {
        this.animator.SetBool(STATE_ALIVE, false);
        GameManager.sharedInstance.GameOver();
    }
}
