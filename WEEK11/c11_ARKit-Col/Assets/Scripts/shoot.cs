using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

    public GameObject ball; //reference to the ball prefab, set in editor    
    private GameObject ballClone; //we don't use the original prefab
    private AudioSource sample;

   	void Start () {
        sample = GetComponent<AudioSource>();
	}
	
	void Update () {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Shoot();
            }
        }

        // lets delete the ball is it's close to the ground
        if (ballClone != null && ballClone.transform.position.y < -5.0f)
        {
            Destroy(ballClone);
        }
	}

    void Shoot (){

        ballClone = Instantiate(ball, transform.position, transform.rotation);
        ballClone.GetComponent<Rigidbody>().velocity = transform.forward * 5.0f;
        sample.Play();

    }
}