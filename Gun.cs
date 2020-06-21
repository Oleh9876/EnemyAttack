using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Gun : MonoBehaviourPunCallbacks
{
    
    [SerializeField]
    [Range(0.1f, 1.5f)]
    private float fireRate = 0.3f;

    public int scoreValue = 1;

    [SerializeField]
    [Range(1, 25)]
    private int damage = 25;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private ParticleSystem muzzleParticle;

    [SerializeField]
    private AudioSource gunFireSource;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (photonView.IsMine)
        {
            if (timer >= fireRate)
            {
                if (Input.GetButton("Fire1"))
                {
                    timer = 0f;
                    photonView.RPC("FireGun",RpcTarget.All);
                }
            }
        }
    }
    [PunRPC]
    void FireGun()
    {
        
        Debug.DrawRay(firePoint.position, firePoint.forward * 100, Color.red, 2f);

        muzzleParticle.Play();
        gunFireSource.Play();
        
        Ray ray = new Ray(firePoint.position, firePoint.forward);
        
       
        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            
            
            var enemyHealth = hit.collider.GetComponent<Health>();
      
            if (enemyHealth)
            {
                enemyHealth.TakeDamage(damage);
                ScoreScript.score += scoreValue;
                

            }
            
              
          


        }
    }
}