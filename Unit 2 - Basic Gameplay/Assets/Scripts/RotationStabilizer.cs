using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationStabilizer : MonoBehaviour
{
    void Awake()
    {
        transform.rotation = Quaternion.Euler(-90, 0, 0);
    }
}
