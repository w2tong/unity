using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float jumpForce = 15;
    private float gravityModifier = 4;
    private int currJumps = 0;
    private int maxJumps = 2;
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
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -9.8f, 0) * gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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
            if (Input.GetKeyDown(KeyCode.Space) && currJumps < maxJumps)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                currJumps++;
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
            currJumps = 0;
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
            gameManager.GameOver();
        }
    }

    public bool getGameOver()
    {
        return gameOver;
    }
}