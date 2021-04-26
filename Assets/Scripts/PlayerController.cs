using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    [SerializeField]
    private float _forceValue = 20.0f;

    [SerializeField]
    private float _gravityModifier = 1.0f;

    private bool _isOnGround = true;

    public bool gameOver = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= _gravityModifier;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround)
        {
            _isOnGround = false;
            playerRb.AddForce(Vector3.up * _forceValue, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isOnGround = true;

        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Game Over!");
            gameOver = true;
        }
    }

   
}
