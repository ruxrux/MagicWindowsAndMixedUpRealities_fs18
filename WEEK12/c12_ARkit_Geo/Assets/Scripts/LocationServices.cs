﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationServices : MonoBehaviour
{
	float lat, lon, alt;
	double time;
	public Text _debug;

	bool bHasData = false;

	private void Start(){

		StartCoroutine (StartLocationServices ());
	
	}


 	private IEnumerator StartLocationServices()
	{
		// First, check if user has location service enabled
		if (!Input.location.isEnabledByUser) {
			_debug.text = "Location disabled by user";
			yield break;
		}
		// Start service before querying location
		// Input.location.Start(float desiredAccuracyInMeters, float updateDistanceInMeters);
		// https://docs.unity3d.com/ScriptReference/LocationService.Start.html
		Input.location.Start(.1f, .1f);
		_debug.text = "start Location request";

		// Wait until service initializes
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
		{
			yield return new WaitForSeconds(1);
			maxWait--;
		}

		// Service didn't initialize in 20 seconds
		if (maxWait < 1)
		{
			_debug.text = "Timed out";
			yield break;
		}

		// Connection has failed
		if (Input.location.status == LocationServiceStatus.Failed)
		{
			_debug.text = "Unable to determine device location";
			yield break;
		}
		else
		{
			// Access granted and location value could be retrieved
			_debug.text = "Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp;
            lat = Input.location.lastData.latitude;
			lon = Input.location.lastData.longitude;
			time = Input.location.lastData.timestamp;
            GameObject.Find("3dText").GetComponent<TextMesh>().text = "lat " + lat + " \nlon " + lon;

			bHasData = true;
		}
	}

}