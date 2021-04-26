using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2.0f;

    private Vector3 _startingPos;
    private float _repeatWidth;

    private PlayerController playerControllerScript;


    // Start is called before the first frame update
    void Start()
    {
        _startingPos = transform.position;
        _repeatWidth = GetComponent<BoxCollider>().size.x / 2;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * _speed);
        }

        if (transform.position.x < _startingPos.x - _repeatWidth)
        {
            transform.position = _startingPos;
        }
    }
}
