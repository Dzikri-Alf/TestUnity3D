using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RaycastGun : MonoBehaviour
{
    public Camera playerCamera;
    public Transform laserOrigin;
    public LayerMask shootableLayer;
    public float gunRange = 50f;
    public float fireRate = 0.2f;
    public float laserDuration = 0.05f;
 
    LineRenderer laserLine;
    float fireTimer;
    AudioSource shootSound;

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        shootSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
        if(Input.GetButtonDown("Fire1") && fireTimer > fireRate)
        {
            fireTimer = 0;
            laserLine.SetPosition(0, laserOrigin.position);
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if(Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange, shootableLayer))
            {
                laserLine.SetPosition(1, hit.point);
                Destroy(hit.transform.gameObject);
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
            }
            shootSound.Play();
            StartCoroutine(ShootLaser());
        }
    }
    
    IEnumerator ShootLaser()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
    }
}
