using UnityEngine;

public class Gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    private float nextTimeToFire = 0f;

    public AudioSource gunShotSound;
    public AudioSource enemyHit;

    private void Awake()
    {
        gunShotSound = GetComponent<AudioSource>();

    }


        // Update is called once per frame
        void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        
    }

    void Shoot ()
    {
        muzzleFlash.Play();
        gunShotSound.Play();
        enemyHit.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) 
        {
            Debug.Log(hit.transform.name);

           MutantScript enemy = hit.transform.GetComponent<MutantScript>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
           
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(hit.normal * impactForce);
            }
        }
        
    }
}
