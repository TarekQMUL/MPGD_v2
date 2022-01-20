using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public int pickupID;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("printitscolliding");
            Destroy(gameObject);

            if (pickupID == 0)
            {
                collision.GetComponentInParent<PlayerMovement>().oxygenLevel += 0.2f;
                if (collision.GetComponentInParent<PlayerMovement>().oxygenLevel > 1)
                {
                    collision.GetComponentInParent<PlayerMovement>().oxygenLevel = 1;
                }
            }
            if (pickupID == 1)
            {
                collision.GetComponentInParent<PlayerMovement>().spaceshipHealth += 1;
                if (collision.GetComponentInParent<PlayerMovement>().spaceshipHealth > 9)
                {
                    collision.GetComponentInParent<PlayerMovement>().spaceshipHealth = 9;
                }
            }
        }
        
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
