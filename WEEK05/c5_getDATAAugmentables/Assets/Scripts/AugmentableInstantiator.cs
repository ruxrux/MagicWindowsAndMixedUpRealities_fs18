using UnityEngine;
using System.Collections;
using Vuforia;
	
public class AugmentableInstantiator : MonoBehaviour, ITrackableEventHandler {
 
    private TrackableBehaviour mTrackableBehaviour;
 
    public Transform [] myPrefabs;
    int selectedPrefab = 0;
 
    // Use this for initialization
    void Start ()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
 
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }               
 
    // Update is called once per frame
    void Update ()
    {
    }
 
    public void OnTrackableStateChanged(
              TrackableBehaviour.Status previousStatus,
              TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED)
        {
            OnTrackingFound();
        }
    }
    private void OnTrackingFound()
    {
        if (myPrefabs != null)
        {
            Transform myModelTrf = GameObject.Instantiate(myPrefabs[selectedPrefab]) as Transform;
 
             myModelTrf.parent = mTrackableBehaviour.transform;             
             myModelTrf.localPosition = new Vector3(0f, 0f, 0f);
             myModelTrf.localRotation = Quaternion.identity;
             myModelTrf.localScale = new Vector3(1f, 1f, 1f);
 
             myModelTrf.gameObject.active = true;
         }
     }

    public void SetPrefab(int _i)
    {
        selectedPrefab = _i;
        Debug.Log("selectedPrefab = " + _i);
    }
}