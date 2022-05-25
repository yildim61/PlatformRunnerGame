using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    void Update()
    {
         transform.Rotate(0, 0, 0.1f * rotateSpeed);
    }
}
