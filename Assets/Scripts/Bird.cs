using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour
{
    [SerializeField]  float _launchForce = 500;
    [SerializeField]  float maxdragDistance = 5;
    
     Vector2 startPosition;



    /// this stupid tutorial keeps breaking my code, might want to delete this later
    // Rigidbody2D  _rigidbody2D;

   // void awake
   // {
    //    _rigidbody2D = GetComponent<Rigidbody2D>();
    //}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
        startPosition = GetComponent<Rigidbody2D>().position;
    }


    void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    void OnMouseUp()
    {


        GetComponent<Rigidbody2D>().isKinematic = false;

        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 currentPosition = GetComponent<Rigidbody2D>().position;
        Vector2 direction = startPosition - currentPosition;
        direction.Normalize();

        GetComponent<Rigidbody2D>().AddForce(direction * _launchForce);
        var audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 desiredPosition = mousePosition;
    
        float distance = Vector2.Distance(desiredPosition, startPosition);
        if (distance > maxdragDistance)
        {
            Vector2 direction = desiredPosition - startPosition;
            direction.Normalize();
            desiredPosition = startPosition + (direction * maxdragDistance);
        }
        if(desiredPosition.x > startPosition.x)
            desiredPosition.x = startPosition.x;

      
        //transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        GetComponent<Rigidbody2D>().position = desiredPosition;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay());


    }

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(5);
        GetComponent<Rigidbody2D>().position = startPosition;
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
    }
}


    // Update is called once per frame