using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollisionCuartoSig : MonoBehaviour
{
    public Collider2D cambio;
    // Start is called before the first frame update
    void Awake()
    {

        cambio = GetComponent<Collider2D>();
        
    }

    void Start()
    {
        cambio.tag = "Boss"; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.tag == "Player"&& GameManager.sharedInstance.bossRoom==false&& GameManager.sharedInstance.bossDefeated == false )
        {
            
            GameManager.sharedInstance.level++;
            SceneManager.LoadScene("Scene" + GameManager.sharedInstance.level, LoadSceneMode.Single); 
            

        }
        else
        {
            if (collision.tag == "Player" && cambio.tag == "Boss" && GameManager.sharedInstance.bossRoom == true && GameManager.sharedInstance.bossDefeated == false)
            {
                collision.GetComponent<Collider2D>().enabled = false;
            }
            else 
            {
                if (collision.tag == "Player" &&cambio.tag == "Boss"&&GameManager.sharedInstance.bossRoom == true && GameManager.sharedInstance.bossDefeated == true)
                {
                    collision.GetComponent<Collider2D>().enabled = true;
                    GameManager.sharedInstance.level++;
                    SceneManager.LoadScene("Scene" + GameManager.sharedInstance.level, LoadSceneMode.Single);
                    
                }
                
            }
        }
    }
}
