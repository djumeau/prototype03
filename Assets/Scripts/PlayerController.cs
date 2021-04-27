using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    private Animator playerAnimator;

    private AudioSource playerAudio;

    [SerializeField]
    private ParticleSystem explosion = null;

    [SerializeField]
    private ParticleSystem dirt = null;

    [SerializeField]
    private float _forceValue = 20.0f;

    [SerializeField]
    private float _gravityModifier = 1.0f;

    private bool _isOnGround = true;

    public bool gameOver = false;

    [SerializeField]
    private AudioClip _crashSound;

    [SerializeField]
    private AudioClip _jumpSound;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= _gravityModifier;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround && !gameOver)
        {
            _isOnGround = false;
            playerRb.AddForce(Vector3.up * _forceValue, ForceMode.Impulse);
            playerAnimator.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(_jumpSound, 1.0f);

        }

        if (!_isOnGround) { 
            dirt.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isOnGround = true;
        dirt.Play();

        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Game Over!");
            
            Die();
            gameOver = true;
        }
    }

    private void Die()
    {
        transform.position -= new Vector3(-.05f, 0, 0);
        playerAnimator.SetBool("Death_b", true);
        playerAnimator.SetInteger("DeathType_int", 1);
        explosion.Play();
        dirt.Stop();
        playerAudio.PlayOneShot(_crashSound, 1.0f);
    }

}
