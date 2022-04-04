using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtRotate : MonoBehaviour
{


    [SerializeField] private float _rotationSpeed;

    [SerializeField] private Vector3 _rotation;


    // Update is called once per frame
    void Update()
    {

        transform.Rotate(_rotation * _rotationSpeed * Time.deltaTime);
    }
}