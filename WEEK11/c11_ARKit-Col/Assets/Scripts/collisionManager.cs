using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionManager : MonoBehaviour {
    AudioSource sample;
	// Use this for initialization
	void Start () {
        sample = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision collision)
	{
        Debug.Log("col with " + collision.collider.name);
        sample.Play();
	}
}
