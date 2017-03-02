using UnityEngine;
using System.Collections;

public class SpinLogo : MonoBehaviour {

	public float rotationSpeed = 100.0f;
	
	public bool rotateX = false;
	public bool rotateY = false;
	public bool rotateZ = false;
	
	// CHANGE TO ROTATE IN OPPOSITE DIRECTION
	private bool positiveRotation = false;
	
	private int posOrNeg = 1;
	
	// Use this for initialization
	void Start ()
	{
		/*
		GetComponent<Collider>().isTrigger = true;
		if(positiveRotation == false)
		{
			posOrNeg = -1;
		}
		*/
	}

	// Update is called once per frame
	void Update ()
	{
		//  Toggles X Rotation
		if(rotateX)
		{
			transform.Rotate(rotationSpeed * Time.deltaTime * posOrNeg, 0, 0);//rotates coin on X axis
			//Debug.Log("You are rotating on the X axis");	
		}
		//  Toggles Y Rotation
		if(rotateY)
		{
			transform.Rotate(0, rotationSpeed * Time.deltaTime * posOrNeg, 0);//rotates coin on Y axis
			//Debug.Log("You are rotating on the Y axis");
		}
		//  Toggles Z Rotation
		if(rotateZ)
		{
			transform.Rotate(0, 0, rotationSpeed * Time.deltaTime * posOrNeg);//rotates coin on Z axis
			//Debug.Log("You are rotating on the Z axis");
		}
		
	}

}
