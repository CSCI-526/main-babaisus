using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoadNext : MonoBehaviour
{
    public string nextLevelName = "MainMenu";
    // public GameObject winScreen;
    public GameOverManager gameOverManager;
    // Start is called before the first frame update
    void Start()
    {
        if(gameOverManager == null) {
            gameOverManager = FindObjectOfType<GameOverManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Circle")){
            Debug.Log("Flag hit, next level");
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.gravityScale = 0.0f;
            rb.velocity = new Vector2(0.0f, 0.0f);
            rb.angularVelocity = 0.0f;
            //rb.rotation = 0.0f;
            // winScreen.SetActive(true);
            if(gameOverManager) {
                Debug.Log("pass game, stars acuired: 3");
                gameOverManager.ShowPassGame();
            } else {
                SceneManager.LoadScene(nextLevelName);
            }
            
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Circle")){
            // Debug.Log("Flag intersected, next level");
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            rb.gravityScale = 0.0f;
            rb.velocity = new Vector2(0.0f, 0.0f);
            rb.angularVelocity = 0.0f;
            // rb.rotation = 0.0f;
            // winScreen.SetActive(true);
            if(gameOverManager) {
                // Debug.Log("pass game, stars acuired: 3");
                gameOverManager.ShowPassGame();
            } else {
                SceneManager.LoadScene(nextLevelName);
            }
        }
    }
}