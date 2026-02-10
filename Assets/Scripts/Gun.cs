using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Camera MainCamera;
    public Transform spawnbullet;

    public float shootForce;
    public float spread;
    public float distance;
    public float ShootPeriod = 0.15f;
    private float _timer;

    public AudioSource SoundShoot;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            if (_timer > ShootPeriod)
            {
                _timer = 0f;
                Shoot();
            }

        }
    }

    private void Shoot()
    {
        Ray ray = MainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;    
        }
        else
        {
            targetPoint = ray.GetPoint(distance);
        }

        Vector3 dirWithoutSpread = targetPoint - spawnbullet.position;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 dirWithSpread = dirWithoutSpread + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(bullet, spawnbullet.position, Quaternion.identity);

        currentBullet.transform.forward = dirWithoutSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootForce, ForceMode.Impulse);

        SoundShoot.Play();
    }

}
