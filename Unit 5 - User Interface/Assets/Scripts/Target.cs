using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float minTorque = -10;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;
    private GameManager gameManager;
    [SerializeField] int pointValue;
    [SerializeField] ParticleSystem explosionParticle;
    private int lifeValue = -1;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(Vector3.up * Random.Range(minSpeed, maxSpeed), ForceMode.Impulse);
        targetRb.AddTorque(Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque), ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (gameManager.GetIsGameActive() && !gameManager.GetIsGamePaused())
        {
            gameManager.UpdateScore(pointValue);
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (gameObject.CompareTag("Good"))
        {
            gameManager.UpdateLives(lifeValue);
        }
    }
}
