using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPropellerX : MonoBehaviour
{
    [SerializeField] GameObject propeller;
    private float speed = 720;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        propeller.transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
