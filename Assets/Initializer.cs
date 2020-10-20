using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Initializer : MonoBehaviour
{

    [SerializeField] RuntimeData _runtimeData;

    // Start is called before the first frame update
    void Awake()
    {
        _runtimeData.sphereDiameter = 60.0f;
    }
}
