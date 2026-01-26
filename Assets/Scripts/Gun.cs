using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject BulletPrefab;
    public float BulletSpeed;
    public AudioSource ShotSound;

    public float ShotPeriod = 0.15f;

    private float _timer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        _timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (_timer > ShotPeriod)
            {
                _timer = 0;
                CreateBullet();
            }

        }
    }

    void CreateBullet()
    {
        GameObject newBullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = transform.forward * BulletSpeed;
        ShotSound.pitch = Random.Range(0.9f, 1.1f);
        ShotSound.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

}
