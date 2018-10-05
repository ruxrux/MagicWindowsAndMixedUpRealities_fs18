using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beGreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	private void OnCollisionEnter(Collision col)
	{
        Debug.Log("collided with : " + col.gameObject.name);
        Renderer rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Standard");
        rend.material.SetColor("_Color", Color.green);

        if (col.gameObject.name == "yellow"){
            // do something!
        }
	}
}
