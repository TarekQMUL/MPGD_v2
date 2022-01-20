using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleFloat : MonoBehaviour
{
    public float bounceSpeed = 8;
    public float bounceHeight = 0.05f;
    public float spinSpeed = 90;

    public float startingHeight;
    public float timeOffset;
    // Start is called before the first frame update
    void Start()
    {
        startingHeight = transform.localRotation.x;
        timeOffset = Random.value * Mathf.PI * 2;
    }

    // Update is called once per frame
    void Update()
    {
        float finalHeight = startingHeight + Mathf.Sin(Time.time * bounceSpeed + timeOffset * 0.4f) * bounceHeight;
        var position = transform.localRotation;
        position.x = finalHeight;
        transform.localRotation = position;

        //Vector3 rotation = transform.localRotation.eulerAngles;
        //rotation.x += spinSpeed * Time.deltaTime;
        //transform.localRotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
    }
}
