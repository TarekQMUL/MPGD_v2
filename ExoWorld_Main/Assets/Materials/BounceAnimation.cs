using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceAnimation : MonoBehaviour
{
    public float bounceSpeed = 8;
    public float bounceHeight = 0.05f;
    public float spinSpeed = 90;

    public float startingHeight;
    public float timeOffset;


    // Start is called before the first frame update
    void Start()
    {
        startingHeight = transform.localPosition.y + 1f;
        timeOffset = Random.value * Mathf.PI * 2;

    }

    // Update is called once per frame
    void Update()
    {
        float finalHeight = startingHeight + Mathf.Sin(Time.time * bounceSpeed + timeOffset) * bounceHeight;
        var position = transform.localPosition;
        position.y = finalHeight;
        transform.localPosition = position;

        Vector3 rotation = transform.localRotation.eulerAngles;
        rotation.y += spinSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
    }
}
