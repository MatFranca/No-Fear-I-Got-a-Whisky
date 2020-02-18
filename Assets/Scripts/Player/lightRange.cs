using UnityEngine;
using System.Collections;

public class lightRange : MonoBehaviour {
    public Light light;
	// Use this for initialization
	void Start () 
    {
        light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        Ray lightRange = new Ray(transform.position, transform.forward);
        RaycastHit lightRangeHit;
        if(Physics.Raycast(lightRange, out lightRangeHit) && lightRangeHit.collider.tag.Equals("Wall"))
        {
            light.range = lightRangeHit.distance + 1;
            Debug.DrawRay(transform.position, transform.forward * lightRangeHit.distance, Color.yellow);
        }
        
        
	}
}
