using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] Transform cameraPosition = null;


    // Start is called before the first frame update

    void Update()
    {
        transform.position = cameraPosition.position;
    }
}
