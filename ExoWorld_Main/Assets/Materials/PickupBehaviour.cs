using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public int pickupID;

    public Material mat1;
    public Material mat2;

    public AudioSource pickupsound1;
    //public AudioSource pickupsound2;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            /*
            Debug.Log("printitscolliding");
            pickupsound1.Play();

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

            Destroy(gameObject);
            */
        }
        
    }
    void Start()
    {
        if (pickupID == 0)
        {
            transform.GetComponent<MeshRenderer>().material = mat1;
        }
        if (pickupID == 1)
        {
            transform.GetComponent<MeshRenderer>().material = mat2;
        }
        //pickupsound1 = GetComponent<AudioSource>();
        //pickupsound2 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
