using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HoverPickupObject : MonoBehaviour
{
    public Camera camera;
    public float rayDistance;
    public float distance;

    public GameObject target;

    CursorLockMode cursorLock;

    public AudioSource pickupsfx;

    void Start()
    {
        //cursorLock = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Pickup();
        }

        if (Input.GetKeyDown("escape"))
        {
            //cursorLock = CursorLockMode.None;
        }
    }//End Update

    void Pickup()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.tag == "Pickup")
            {
                pickupsfx.Play();
                if (hit.transform.GetComponent<PickupBehaviour>().pickupID == 0)
                {
                    transform.GetComponentInParent<PlayerMovement>().oxygenLevel += 0.2f;
                    if (transform.GetComponentInParent<PlayerMovement>().oxygenLevel > 1)
                    {
                        transform.GetComponentInParent<PlayerMovement>().oxygenLevel = 1;
                    }
                }
                if (hit.transform.GetComponent<PickupBehaviour>().pickupID == 1)    
                {
                    transform.GetComponentInParent<PlayerMovement>().spaceshipHealth += 1;
                    if (transform.GetComponentInParent<PlayerMovement>().spaceshipHealth > 9)
                    {
                        transform.GetComponentInParent<PlayerMovement>().spaceshipHealth = 9;
                        SceneManager.LoadScene("WinScreen");
                    }
                }
                Destroy(hit.transform.gameObject);
            }
        }
    }//End Pickup
}//End Script