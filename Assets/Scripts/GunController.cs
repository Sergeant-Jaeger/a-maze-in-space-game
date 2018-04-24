using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private Transform bulletSpawn;

    [SerializeField]
    private int bulletSpeed = 5;

    [SerializeField]
    private float startFiring = 1.0f;

    [SerializeField]
    private float firingFrequency = 1.0f;

    [SerializeField]
    private float bulletLife = 5.0f;

	void Start () {
        InvokeRepeating("Fire", startFiring, firingFrequency);
    }

    private void Fire () {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * bulletSpeed;

        Destroy(bullet, bulletLife);
    }
}
