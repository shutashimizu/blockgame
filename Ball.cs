using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public bool isDead = false;
    public float speed = 3.0f;
    public float accelSpeed = 0.5f;
    public ScoreManager scoreManager;
    public GameObject plusScoreTextPrefab;
    public GameObject explosionPrefab;
    public AudioClip touchBarSE;
    public AudioClip touchOtherSE;
    
    bool isStart = false;
    Rigidbody rb;
    AudioSource audioSouce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSouce = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart == false && Input.GetMouseButtonDown(0))
        {
            isStart = true;
            rb.AddForce(new Vector3(1,-1,0) * speed, ForceMode.VelocityChange);
        }  
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            scoreManager.AddScore();
            Destroy(collision.gameObject);
            GameObject explosion = Instantiate(explosionPrefab,collision.transform.position, Quaternion.identity);
            explosion.transform.localScale = new Vector3(0.6f,0.6f,0.6f);
            Destroy(explosion, 2.0f);

            Vector3 plusTextPos = collision.transform.position;
            plusTextPos.z = -1;
            GameObject plusScoreText = Instantiate(plusScoreTextPrefab, plusTextPos, Quaternion.identity);
            int plusScore = scoreManager.GetScoreValue();
            Text scoreText = plusScoreText.GetComponentInChildren<Text>();
            scoreText.text = "+" + plusScore;
            int combo = scoreManager.GetComboValue();
            scoreText.fontSize += combo * 10;
            Color color = scoreText.color;
            color.g -= combo * 0.1f;
            scoreText.color = color;
        }

        if (collision.gameObject.name == "Wall_Bottom")
        {
            isDead = true;
        }
        
        if (collision.gameObject.name == "Bar")
        {
            scoreManager.ResetCombo();
            speed += accelSpeed;
            Vector3 vec = transform.position - collision.transform.position;
            rb.velocity = Vector3.zero;
            rb.AddForce(vec.normalized * speed, ForceMode.VelocityChange);
            audioSouce.PlayOneShot(touchBarSE);
        }
        else
        {
            audioSouce.PlayOneShot(touchOtherSE);
        }
    }
}
