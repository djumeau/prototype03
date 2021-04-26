using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] _prefabs = null;

    private int _prefabIndex = 0;

    private Vector3 _spawnPos;

    private float _startDelay;
    private float _spawnInterval;

    private PlayerController _playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        _prefabIndex = 0;
        _startDelay = 2.0f;
        _spawnInterval = 5.0f;
        _spawnPos = new Vector3(20, .15f, 0);

        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        Invoke("SpawnObstacle", _startDelay);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SpawnObstacle()
    {

        if (!_playerControllerScript.gameOver)
        {
            Instantiate(_prefabs[_prefabIndex], _spawnPos, _prefabs[_prefabIndex].transform.rotation);
            Invoke("SpawnObstacle", Random.Range(1.5f, _spawnInterval));
        }
     
    }

}
