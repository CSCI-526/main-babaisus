using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeScript : MonoBehaviour
{
    public GameOverManager gameOverManager;
    // Start is called before the first frame update
    public AudioClip loseSound;
    void Start()
    {
        if(gameOverManager == null) {
            // Automatically find the GameOverManager in the related scene
            gameOverManager = FindObjectOfType<GameOverManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Circle")){
            AudioSource circleAudio = collision.gameObject.GetComponent<AudioSource>();
            circleAudio.clip = loseSound;
            circleAudio.volume = 0.1f;
            circleAudio.Play();
            Debug.Log("Spike hit, restart level");
            gameOverManager.ShowGameOver();
            // TODO: when hit the flag, call this function
            // gameOverManager.ShowPassGame();
        }
    }
}
