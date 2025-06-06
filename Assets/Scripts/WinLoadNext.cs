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
    private AudioSource winAudio;

    Rigidbody2D rb;
    void Start()
    {
        if(gameOverManager == null) {
            gameOverManager = FindObjectOfType<GameOverManager>();
        }

        Transform parentTransform = transform.parent;
        if (parentTransform){
            GameObject parent = transform.parent.gameObject;
            if (parent){
                rb=parent.GetComponent<Rigidbody2D>();
            }
        }
        winAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity=new Vector2(0,rb.velocity.y);
        // winAudio.Play();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Circle")){
            winAudio.Play();
            Debug.Log("Flag hit, next level");
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.gravityScale = 0.0f;
            rb.velocity = new Vector2(0.0f, 0.0f);
            rb.angularVelocity = 0.0f;
            //rb.rotation = 0.0f;
            // winScreen.SetActive(true);
            if(gameOverManager) {
                Debug.Log("pass game, stars acuired: 3");
                StartCoroutine(ActivateAfterDelay());
                // gameOverManager.ShowPassGame();
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
                StartCoroutine(ActivateAfterDelay());
                // gameOverManager.ShowPassGame();
            } else {
                SceneManager.LoadScene(nextLevelName);
            }
        }
    }

    IEnumerator ActivateAfterDelay()
    {
        Debug.Log("Before Wait: " + Time.realtimeSinceStartup);
        yield return new WaitForSeconds(1f);
        Debug.Log("After Wait: " + Time.realtimeSinceStartup);
        gameOverManager.ShowPassGame();
    }
}