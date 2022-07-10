using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float jumpForce = 20;
    private float gravityModifier = 4;
    private bool isOnGround = true;
    private float speed = 10;
    private float xLeftRange = 0;
    private float xRightRange = 15;
    private bool gameOver = false;
    private Animator playerAnim;
    [SerializeField] ParticleSystem explosionParticle;
    [SerializeField] ParticleSystem dirtParticle;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < xLeftRange)
        {
            transform.position = new Vector3(xLeftRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRightRange)
        {
            transform.position = new Vector3(xRightRange, transform.position.y, transform.position.z);
        }

        if (!gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                playerAnim.SetTrigger("Jump_trig");
                dirtParticle.Stop();
                playerAudio.PlayOneShot(jumpSound, 2.0f);
            }
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            transform.Translate(Vector3.forward * horizontalInput * speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 2.0f);
        }
    }

    public bool getGameOver()
    {
        return gameOver;
    }
}