using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    private Vector3 fp;
    private Vector3 lp;
    Animator playerAnimator;
    Rigidbody playerRigidbody;
    Transform playerTransform;
    Vector3 startPos, endPos;
    float moveTime;
    public AudioSource enemySound;
    public AudioSource coinSound;
    //public AudioSource gameOver;
    public AudioSource jump;
    public AudioSource roll;
    public Text scoreDisplay;
    int score = 0;
    public Text Coindisplay;
    int coin = 0;
    public Text highScoredisplay;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
        scoreDisplay.text = "Score :- " + score;
        Coindisplay.text = "Coins :-" + coin;
        highScoredisplay.text = "HighScore:-" + PlayerPrefs.GetInt("HighScore", 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("Gameover");
            //gameOver.Play();
        }
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinSound.Play();
            coin++;

        }
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(WaitForPlayerMovement());
    }
    IEnumerator WaitForPlayerMovement()
    {
       
        yield return new WaitForSeconds(4f);
        score++;
        scoreDisplay.text = "Score :-" + score;
        Coindisplay.text = "coins :-" + coin;
        if(score>PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoredisplay.text = "HighScore :-" + score.ToString();
        }
        if ((Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.W))) && playerRigidbody.velocity.y == 0)
        {
            playerRigidbody.velocity = new Vector3(0, 5f, 0);
            playerAnimator.SetTrigger("jump");
            jump.Play();

        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || (Input.GetKeyDown(KeyCode.S)))
        {
            playerRigidbody.velocity = new Vector3(0, -3f, 0);
            playerAnimator.SetTrigger("roll");
            roll.Play();

        }
        if (((Input.GetKeyDown(KeyCode.LeftArrow)) || (Input.GetKeyDown(KeyCode.A))) && (transform.position.x==0))
        {
            //playerTransform.position = new Vector3(-3f, 0, 0);
            StartCoroutine(Move("Left"));
        }
        if (((Input.GetKeyDown(KeyCode.RightArrow)) || (Input.GetKeyDown(KeyCode.D))) && (transform.position.x==0))
        {
            StartCoroutine(Move("Right"));

            //playerTransform.position = new Vector3(3, 0, 0);
        }
        if (((Input.GetKeyDown(KeyCode.LeftArrow)) || (Input.GetKeyDown(KeyCode.A))) && (transform.position.x == 3))
        {
            //playerTransform.position = new Vector3(0, 0, 0);
            StartCoroutine(Move("Left"));
        }
        if (((Input.GetKeyDown(KeyCode.RightArrow)) || (Input.GetKeyDown(KeyCode.D))) && (transform.position.x == -3))
        {
            StartCoroutine(Move("Right"));
            //playerTransform.position = new Vector3(0, 0, 0);
        }
    }
   
    IEnumerator Move(string WhereToMove)
    {
        switch(WhereToMove)
        {
            case "Right":
                moveTime = 0f;
                startPos = this.transform.position;
                endPos = new Vector3(this.transform.position.x + 3f, this.transform.position.y, this.transform.position.z);
                while(moveTime < 0.5f)
                {
                    moveTime += 0.02f;
                    this.transform.position = Vector3.Lerp(startPos, endPos, moveTime / 0.5f);
                        yield return null;
                }
                break;
            case "Left":
                moveTime = 0f;
                startPos = this.transform.position;
                endPos = new Vector3(this.transform.position.x - 3f, this.transform.position.y, this.transform.position.z);
                    while(moveTime <0.5f)
                {
                    moveTime += 0.02f;
                    this.transform.position = Vector3.Lerp(startPos, endPos, moveTime / 0.5f);
                    yield return null;


                }break;
                
        }
    }
}
