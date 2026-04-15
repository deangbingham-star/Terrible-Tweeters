using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Monster : MonoBehaviour
{

   [SerializeField] ParticleSystem _particleSystem;

    bool _hasDied;
  
   void OnCollisionEnter2D(Collision2D collision)
   {

      if (ShouldDieFromCollision(collision))
      {
         StartCoroutine(Die());
      }
      
   }

   private bool ShouldDieFromCollision(Collision2D collision)
   {
     
      if (_hasDied)
      {
         return false;
      }
 
      
      Bird bird = collision.gameObject.GetComponent<Bird>();
      if (bird != null)
      {
         return true;
      }

      if (collision.contacts[0].normal.y < -0.5)
      {
         return true;
      }
         
      return false;
   }

   IEnumerator Die()
   {
      _hasDied = true;
      _particleSystem.Play();
      yield return new WaitForSeconds(1);
   
      gameObject.SetActive(false);
   }
}
