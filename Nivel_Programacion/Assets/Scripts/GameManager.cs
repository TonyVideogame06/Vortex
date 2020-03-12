using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Se hace aqui la enumeracion ya que lo queremos ocupar globalmente en todos los scripts

public enum GameState//Enumera los estados que va a tener nuestro videojuego
{
    menu,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{
    public GameState currentState = GameState.menu; //El estado actual de nuestro juego es el menu para que el jugador tenga la libertad de decidir cuando empezar el jugeo

    public static GameManager sharedInstance;

    public int level = 1; //Nivel

    //public string cuarto = "Scene" + sharedInstance.level;

    public bool bossRoom = false; //Es un cuarto de Boss
    public bool bossDefeated = false;

    private PlayerController controller;

    void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }    
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit")&& currentState!=GameState.inGame)
        {
            StarGame();
        }
    }

    public void StarGame() //Estado de empezar juego
    {
        SetGameState(GameState.inGame);
    }

    public void GameOver() //Estado de Game Over
    {
        SetGameState(GameState.gameOver);
    }

    public void BackToMenu() // Estado de Volver al menu
    {
        SetGameState(GameState.menu);
    }

    private void SetGameState(GameState newGameState) //Asignar acciones si estamos en alguno de estos estados 
    {
        if (newGameState == GameState.menu)
        {
            //TODO: colocar la logica del menu
        }
        else
        {
            if (newGameState == GameState.inGame)
            {
                //TODO: Hay que preparar la escena para jugar
                controller.StartGame();
            }
            else
            {
                if (newGameState == GameState.gameOver)
                {
                    //TODO: Preparar el juego para el Game Over
                }
                else
                {
                    if (true)
                    {

                    }
                }
            }
        }

        this.currentState = newGameState; //Asignar el nuevo estado en el que estamos
    }
}
