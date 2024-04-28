using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProjectileGun : MonoBehaviour
{   
      public GameObject bullet;
    public float shootForce, upwardForce;
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowBulletHold;

    int bulletsLeft, bulletsShot;

    bool shooting, readyToShoot, reloading;

    public Camera fpsCam;
    public Transform attackPoint;

    //Graphics
    public GameObject muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;
     

    public bool allowInvoke = true;

    public void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;

    }

    private void Update()
    {
        MyInput();
        if (ammunitionDisplay != null)
            ammunitionDisplay.SetText(bulletsLeft / bulletsPerTap + "/ " + magazineSize / bulletsPerTap);
    }
    private void MyInput()
    {
        //Check Hold Button to shoot
        if (allowBulletHold) shooting = Input.GetKey(KeyCode.Space);
        else shooting = Input.GetKeyDown(KeyCode.Space);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();

        //shooting 
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            //set bullets to zero
            bulletsShot = 0;
            Shoot();
        }
    }  
    
    private void Shoot()
    {
        readyToShoot = false;
        //find hit point position

        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        currentBullet.transform.forward = directionWithSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);
        if (muzzleFlash != null)
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);
        bulletsLeft--;
        bulletsShot++;

        if(allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }

        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;

    }



}
