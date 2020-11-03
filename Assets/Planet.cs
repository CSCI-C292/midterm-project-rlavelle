using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Planet : MonoBehaviour
{

    [SerializeField] RuntimeData _runtimeData;
    [SerializeField] float _shrinkScale = 0.75f;
    [SerializeField] GameObject _asteroidPrefab;
    [SerializeField] GameObject _craterPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAsteroid", 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnAsteroid(){
        Instantiate(_asteroidPrefab, Random.onUnitSphere*_runtimeData.sphereDiameter, Quaternion.identity);
    }

    void OnTriggerEnter(Collider collider){
        if(collider.name == "Asteroid(Clone)"){
            // spawn crater
            Instantiate(_craterPrefab, collider.transform.position, Quaternion.identity);
            Destroy(collider.gameObject);
        }
    }
}
