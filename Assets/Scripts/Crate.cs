using UnityEngine;

public class Crate : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 5f)
        {
            GetComponent<AudioSource>().Play();
        }
        else
        {   
            Debug.Log("Collission Insufficient" + collision.relativeVelocity.magnitude);
        }
    }
}
