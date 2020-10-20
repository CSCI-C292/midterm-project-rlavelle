using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Planet : MonoBehaviour
{

    [SerializeField] RuntimeData _runtimeData;
    [SerializeField] float _shrinkScale = 0.75f;
    [SerializeField] GameObject _diameterText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // shrink the sphere
        transform.localScale -= new Vector3(_shrinkScale,_shrinkScale,_shrinkScale)*Time.deltaTime;
        _runtimeData.sphereDiameter -= _shrinkScale*Time.deltaTime;
        _diameterText.GetComponent<Text>().text = _runtimeData.sphereDiameter.ToString("F2");
    }
}
