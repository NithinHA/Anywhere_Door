using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_portal_camera : MonoBehaviour {

	public Transform player_camera;
	public Transform portal;
	public Transform other_portal;

	void Start () {
		
	}
	
	void Update () {
		Vector3 player_offset_from_portal = player_camera.position - other_portal.position;
		transform.position = portal.position + player_offset_from_portal;

		float angular_difference_between_portal_rotations = Quaternion.Angle(portal.rotation, other_portal.rotation);
		Quaternion portal_rotational_difference = Quaternion.AngleAxis(angular_difference_between_portal_rotations, Vector3.up);
		Vector3 new_camera_direction = portal_rotational_difference * player_camera.forward;
		transform.rotation = Quaternion.LookRotation(new_camera_direction, Vector3.up);
	}
}
