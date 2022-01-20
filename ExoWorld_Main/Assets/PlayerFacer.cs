using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFacer : MonoBehaviour
{
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(2 * transform.position - playerTransform.position);
        var desiredRot = new Vector3(0, transform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Euler(desiredRot);
    }
}
