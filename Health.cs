using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using EnemyAttack.Movement;

public class Health : MonoBehaviourPunCallbacks, Photon.Pun.IPunObservable
{
    
    public float health = 100;
    private Animator animator;
     bool isDead;
    
    
    
    
void Awake()
    {
     animator = GetComponent<Animator>();

         
 }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(health);
        }
        else
        {
            health = (float)stream.ReceiveNext();

        }
    }


    public void TakeDamage(float damage)
    {
    	
        
        health -= damage;
       
        
 
        
        	if (health <=0 && !isDead)
        {
        	Death();
        }

    }
     
    void Death()
{
	isDead=true;
	animator.SetTrigger("Die");

}


    IEnumerator Respawn()
    {
    	isDead=false;

        health = 100;
        GetComponent<Movement>().enabled = false;
        transform.position = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(5);
        GetComponent<Movement>().enabled = true;
        
    }

    
    

    void Update()
    {
        
         
        if (health<=0)
        {
        	StartCoroutine(Respawn());
        }

    }
}

