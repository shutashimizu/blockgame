using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject GameClearText;
    public GameObject GameOverText;
    public GameObject ball;
    public GameObject RetryButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        if (blocks.Length == 0)
        {
            GameClearText.SetActive(true);
            ball.GetComponent<Rigidbody>().isKinematic = true;
            RetryButton.SetActive(true);
        }

        if ( ball.GetComponent<Ball>().isDead == true)
        {
            GameOverText.SetActive(true);
            ball.GetComponent<Rigidbody>().isKinematic = true;
            RetryButton.SetActive(true);
        }
    }

       public void Retry()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
}
