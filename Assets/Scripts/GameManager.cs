
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int level = 1;
    public int score = 0;
    public int lives = 3;
    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start() {
        NewGame();
    }

    private void NewGame()
    {
        this.score = 0;
        this.lives = 3;
        
        LoadLevel(1);
    }

    private void LoadLevel(int level) {

        this.level = level;

        SceneManager.LoadScene("Level" + level);

    }

    public void Hit(Brick brick){
        this.score +=  brick.points;
    }

    private void ResetLevel() {

    }

    private void GameOver() {
        SceneManager.LoadScene("GameOver");
    }

    public void Miss() {
        this.lives--;

        if (this.lives > 0){
            ResetLevel();
        } else {
            GameOver();
        }
    }
}
