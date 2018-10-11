using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

/* * * * * * * * * * * 
 * don't forget to add simple JSON!
 * get the c# code from here:
 * http://wiki.unity3d.com/index.php/SimpleJSON#CSharp
 * paste it in a c# file, make sure you save the file with the name of the class (SimpleJSON) 
 * import the file to /Assets/PlugIns/SimpleJSON
*/
using SimpleJSON;


public class restGET : MonoBehaviour {

	string location;
	string weather;

	// bool to make sure we only add one object
	bool bObject = false;

	// public array for us to add our weather object prefabs
	public GameObject[] weatherObjects;
	GameObject myWeather;

	void Start(){

		StartCoroutine (GETAnswer ());
	}


	IEnumerator GETAnswer(){
	
		// using some web API that uses REST and spits out JSON
		// example using http://openweathermap.org/api 

        UnityWebRequest request = UnityWebRequest.Get("http://api.openweathermap.org/data/2.5/weather?lat=35&lon=139&APPID=d82e2317544a9c95081abb6c89be6cb5");
		yield return request.SendWebRequest ();

		if (request.isNetworkError) {
			Debug.Log (request.error);		
		} else {

			// we got something so lets show the results
			var resultTxt = request.downloadHandler.text;
			Debug.Log(resultTxt);

			// now let's parse this 
			var result = JSON.Parse(request.downloadHandler.text);

			// and lets look for the attributes/values pairs that we want, in this case location and weather type

		 	location = result ["name"].Value;
			weather = result ["weather"][0]["main"].Value;

			// lets look at the data parse and make sure we got anything and the right things
			Debug.Log ("it's " + weather + " in " + location);
		}
	}


	void Update(){

		// lets use the data to make something
		// literally

		if (!bObject) {
			if (weather == "Clear") {

				// create an instance of our prefab to add to the scene
				// more about prefabs and instantiating : https://docs.unity3d.com/Manual/InstantiatingPrefabs.html

				myWeather = Instantiate<GameObject> (weatherObjects [0]);
                Debug.Log("got sun");

				bObject = true;
			} else if (weather == "Rain"){

				myWeather = Instantiate<GameObject> (weatherObjects [0]);
                Debug.Log("got rain");
   				bObject = true;

			}

		}
			
	}

}



