using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    float _score = 0;
    bool _isGameOver = false;
    [SerializeField] GameObject _scoreText;
    [SerializeField] GameObject _gameOverText;
    public static GameState Instance;

    void Awake(){
        Instance = this;
    }

    void Update(){
        if(Input.GetButtonDown("Submit") && _isGameOver){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(!_isGameOver){
            _score += 1f*Time.deltaTime;
        }

        _scoreText.GetComponent<Text>().text = _score.ToString("F2");

    }

    public void InitiateGameOver(){
        _isGameOver = true;
        //_gameOverText.SetActive(true);
    }
}