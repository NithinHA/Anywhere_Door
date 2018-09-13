using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_portal_teleporter : MonoBehaviour {

    //public GameObject player;
    public GameObject other_portal;
    //public int position_direction;

    //public bool portal_enable = false;
    //public float dot_product;

    //private void Update()
    //{
    //    Vector3 portal_to_player = player.transform.position - transform.position;
    //    dot_product = Vector3.Dot(transform.up, portal_to_player);

    //    if(portal_enable)
    //    {
    //        player.transform.position = other_portal.transform.position + new Vector3(0, 0, 0.5f) * position_direction;
    //        player.transform.rotation = Quaternion.Euler(0, 180, 0);
    //        portal_enable = false;
    //    }

    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player" && dot_product > 0)
    //    {
    //        portal_enable = true;
    //    }
    //}

    [HideInInspector] public bool portal_enable = true;

    void Update()
    {
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

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && portal_enable)
        {
            other.transform.position = other_portal.transform.position;
            other.transform.rotation = Quaternion.Euler(0, 180, 0);
            other_portal.GetComponent<door_portal_teleporter>().portal_enable = false;
        }
    }

}
