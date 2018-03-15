using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour {

	public Transform player;
	public Transform receiver;

	private bool playerIsOverlapping = false;

	void Update () {
		if (playerIsOverlapping)
		{
			Vector3 portalToPlayer = player.position - transform.position;
			//Debug.Log(portalToPlayer);
			float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
			
			if(dotProduct < 0f)				//If this is true, player has moved across the portal
			{
				//Debug.Log(dotProduct);
				//Teleport
				float rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
				rotationDiff += 180;
				player.Rotate(Vector3.up, rotationDiff);

				Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
				player.position = receiver.position + positionOffset;

				playerIsOverlapping = false;
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			playerIsOverlapping = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
		{
			playerIsOverlapping = false;
		}
	}
}
