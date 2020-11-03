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
    [SerializeField] GameObject _canvas;
    [SerializeField] GameObject _mainCam;
    public static GameState Instance;
    public static GameObject _canvasInstance;
    bool flag = true;

    public static GameObject _mainCamInstance;

    void Awake(){
        if(Instance){
            Destroy(gameObject);
        }else{
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        if(_canvasInstance){
            Destroy(_canvas);
        }else{
            _canvasInstance = _canvas;
            DontDestroyOnLoad(_canvas);
        }

        if(_mainCamInstance){
            Destroy(_mainCam);
        }else{
            _mainCamInstance = _mainCam;
            DontDestroyOnLoad(_mainCam);
        }
    }

    void Update(){
        if(Input.GetButtonDown("Submit") && _isGameOver){
            SceneManager.UnloadSceneAsync("GameOver");
            SceneManager.LoadScene("SampleScene");
            flag = true;
            _isGameOver = false;
            _score = 0;
        }

        if(!_isGameOver){
            _score += 1f*Time.deltaTime;
        }

        if(_isGameOver && flag){
            SceneManager.LoadScene("GameOver");
            //SceneManager.UnloadSceneAsync("SampleScene");
            flag = false;
        }

        _scoreText.GetComponent<Text>().text = _score.ToString("F2");

    }

    public void InitiateGameOver(){
        _isGameOver = true;
        //_gameOverText.SetActive(true);
    }
}