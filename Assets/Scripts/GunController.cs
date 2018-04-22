using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform bulletSpawn;

    [SerializeField]
    int bulletSpeed = 5;

    [SerializeField]
    float startFiring = 1.0f;

    [SerializeField]
    float firingFrequency = 1.0f;

    [SerializeField]
    float bulletLife = 5.0f;

	void Start () {
        InvokeRepeating("Fire", startFiring, firingFrequency);
    }

    void Fire () {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * bulletSpeed;

        Destroy(bullet, bulletLife);
    }
}
