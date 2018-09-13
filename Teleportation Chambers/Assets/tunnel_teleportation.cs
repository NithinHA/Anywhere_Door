using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tunnel_teleportation : MonoBehaviour {

	public tunnel_teleportation other_portal;
	public bool portal_enable = true;

	void Start () {

	}
	
	void Update () {
		if (!portal_enable)
		{
			StartCoroutine("portal_control");
		}
	}

	IEnumerator portal_control()
	{
		yield return new WaitForSeconds(3);
		portal_enable = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "FPSController" && portal_enable)
		{
			other.transform.position = other_portal.transform.position + new Vector3(0, 2, 0);
			other_portal.portal_enable = false;
		}
	}
}
