using UnityEngine;

public class OrbitCamera : MonoBehaviour 
{
	public Vector3 center = new Vector3(0,0,0);
	public float xSpeed = 10.0f;
	public float ySpeed = 10.0f;
	public float scrollSpeed = 50.0f;
	
	void Start () 
	{
	}
	
	void LateUpdate () 
	{
		float thetax = 0;
		float thetay = 0;
		if (Input.GetMouseButton(0)) 
		{
			thetax += Input.GetAxis("Mouse X") * xSpeed;
			thetay -= Input.GetAxis("Mouse Y") * ySpeed; 		

			Quaternion rotation = Quaternion.Euler(thetay, thetax, 0);
			transform.rotation = rotation * transform.rotation;
			transform.position = rotation*(transform.position - center) + center; 
		} 

 		float delta = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        Vector3 direction = delta * transform.TransformDirection(Vector3.forward);
        transform.position += direction;	    
	}
}


