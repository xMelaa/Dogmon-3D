using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public Transform firePoint;
    public Rigidbody projectilePrefab;
    public float launchForce = 300f;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            LaunchProjectile();
        }
    }

    private void LaunchProjectile()
    {
        var projectileInstance = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        projectileInstance.AddForce(firePoint.forward * launchForce);
    }
}