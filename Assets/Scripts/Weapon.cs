using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    public Camera fpsCam;
    public ParticleSystem muzzelFlash;
    public GameObject impactEffect;

    public AudioSource ShootSound;

    private float nextTime = 0;
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTime)
        {
            ShootSound.Play();
            nextTime = Time.time + 1f / fireRate;
            Shoot();
        }
        
    }
    void Shoot()
    {
        muzzelFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {

            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 0.5f);
        }

    }
}
