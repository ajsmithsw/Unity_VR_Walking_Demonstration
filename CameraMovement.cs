using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public float WalkingSpeed = 1.0f;
	public bool WalkEnabled = false;

	GameObject cam;

	NavMeshAgent agent;
	NavMeshPath path;
	
	void Start () {
		cam = GameObject.FindWithTag("CCHead");
		agent = GetComponent<NavMeshAgent> ();
		path = new NavMeshPath ();
	}


	void Update () {
		if (WalkEnabled) {
			walk ();
		}

		int view_x = 2;
		int view_z = 2;
		if (cam.transform.forward.x < 0) {
			view_x = -2;
		} else {
			view_x = 2;
		}
		if (cam.transform.forward.z < 0) {
			view_z = -2;
		} else {
			view_z = 2;
		}


		Debug.Log ("x: " + cam.transform.forward.x * WalkingSpeed * Time.deltaTime
		           + ", z: " + cam.transform.forward.z * WalkingSpeed * Time.deltaTime);

		Vector3 viewDirection = 
			new Vector3 (cam.transform.forward.x * WalkingSpeed * Time.deltaTime + view_x,
			             0f, cam.transform.forward.z * WalkingSpeed * Time.deltaTime + view_z);
		
		Vector3 targetPosition = transform.position + viewDirection;
		//Debug.Log (transform.position + ", " + targetPosition);

		checkPath (targetPosition);

	}

	void checkPath(Vector3 targetPos) {
		path = new NavMeshPath ();
		agent.CalculatePath(targetPos, path);
		NavMeshHit hit = new NavMeshHit ();

		if (NavMesh.FindClosestEdge(transform.position, out hit, NavMesh.AllAreas)) {
			Debug.DrawRay(hit.position, Vector3.up, Color.red);
		}

		Debug.Log ("hit position: " + hit.position 
		           + ", camera position: " + transform.position 
		           + ", target position: " + targetPos
		           + ", path status: " + path.status);
		
		if (path.status == NavMeshPathStatus.PathPartial) {
			WalkEnabled = false;
		} else {
			WalkEnabled = true;
		}
	}

	void walk() {
		Vector3 viewDirection = 
			new Vector3 (cam.transform.forward.x * WalkingSpeed * Time.deltaTime,
		                0, cam.transform.forward.z * WalkingSpeed * Time.deltaTime);
		Vector3 targetPosition = transform.position + viewDirection;
		transform.position = targetPosition;
	}

}
