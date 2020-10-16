using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    float exitTime = 2.5f;

    public GameObject gameOverState, startGameState;
    Animator animatorEndGame, animatorStartGame;

    private void Start() 
    {
        if (gameOverState){ 
            animatorEndGame = gameOverState.GetComponent<Animator>(); 
        }
        else if (startGameState){
            animatorStartGame = startGameState.GetComponent<Animator>();
        }
    }

    public void StartGame()
    {
        StartCoroutine(StartGameCoroutine());
    }

    IEnumerator StartGameCoroutine()
    {
        animatorStartGame.SetTrigger("Button Pressed");
        yield return new WaitForSeconds(exitTime);
        SceneManager.LoadScene("GameScene");
    }

    public void QuitApp()
    {
        Application.Quit();
    }
    

    public void ResetLevel()
    {
        StartCoroutine(ResetGameCoroutine());
    }

    IEnumerator ResetGameCoroutine()
    {
        animatorEndGame.SetTrigger("Button Pressed");
        yield return new WaitForSeconds(exitTime);
        Application.LoadLevel(Application.loadedLevel);
    }


    
}
