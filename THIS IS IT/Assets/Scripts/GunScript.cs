using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    
    public float damage = 10f;
    public float range = 100f;

    public GameObject shrinkUI;
    public GameObject growUI;
    public Camera fpsCam;
    public GameObject impactEffect;
    public float impactForce = 30f;
    public float fireRate = 15;
    public ParticleSystem particleOne;
    public ParticleSystem particleTwo;
    private float nextTimeToFire = 0f;
    public GameObject textUI;

    public int BulletType = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hoi");
        shrinkUI.SetActive(false);
        growUI.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(BulletType == 1)
            {
                BulletType = 0;
                shrinkUI.SetActive(true);
                growUI.SetActive(false);



            }
            else if (BulletType == 0)
            {
                BulletType = 1;
                shrinkUI.SetActive(false);
                growUI.SetActive(true);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        
        


    }


    void Shoot()
    {
        Debug.Log("Hoi");
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            if (BulletType == 0)
            {
                StartCoroutine(ShowParticle(particleOne.gameObject));
            }
            else
            {
                StartCoroutine(ShowParticle(particleTwo.gameObject));
            }

            // instantiate particle effect

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

           /* if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }*/ // impact force was een beetje gek bij mijn shrink en enlarge mechanic, want de blokken schoten omhoog

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);

        }
    }

    IEnumerator ShowParticle(GameObject particle)
    {
        particle.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        particle.SetActive(false);


    }
}