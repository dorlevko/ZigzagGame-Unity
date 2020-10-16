using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed = 10f;
    public GameObject particleSystem;
    public GameObject gameOverState;
    public LayerMask whatIsGround;
    public Transform contactPoint;
    public int scorePerCube = 50;
    public int scorePerMovement = 1;

    Vector3 dir;
    bool isDead;
    bool isPlaying = false;
    LevelManager levelManager;
    ScoreHolder scoreHolder;
    int timer;


    void Start()
    {
        isDead = false;
        dir = Vector3.zero;
        levelManager = FindObjectOfType<LevelManager>();
        scoreHolder = FindObjectOfType<ScoreHolder>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        GameOver();
    }

    private void Movement()
    {
        if (Input.GetMouseButtonDown(0) && !isDead){
            isPlaying = true;

            if (dir == Vector3.forward){
                dir = Vector3.left;
            }
            else{
                dir = Vector3.forward;                
            }
            scoreHolder.AddToScore(scorePerMovement);
        }
        float amountToMove = playerSpeed * Time.deltaTime;
        transform.Translate(dir * amountToMove);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Pickup")){        // Remember!
            other.gameObject.SetActive(false);
            Instantiate(particleSystem, other.transform.position, Quaternion.identity);
            scoreHolder.AddToScore(scorePerCube);
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        /*
        if (other.CompareTag("Tile")){
            RaycastHit hit;
            Ray downRay = new Ray(transform.position, -Vector3.up);

            if (!Physics.Raycast(downRay, out hit)){
                // End the game
                isDead = true;
                
                if (transform.childCount > 0)
                    transform.GetChild(0).transform.parent = null;  // Remember!
                
                gameOverState.SetActive(true);

                scoreHolder.GameOver();
            }
            
        } */
    }

    private void GameOver()
    {
        if (!IsGrounded() && isPlaying){
            isDead = true;

            if (transform.childCount > 0)
                transform.GetChild(0).transform.parent = null;  // Remember!

            gameOverState.SetActive(true);

            scoreHolder.GameOver();
        }
    }

    private bool IsGrounded()
    {
        Collider[] colliders = Physics.OverlapSphere(contactPoint.position, 0.5f, whatIsGround);

        foreach (var collider in colliders)
        {
            if (collider.gameObject != gameObject)
                return true;
        }
        return false;
    }

    
}
