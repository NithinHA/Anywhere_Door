using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_portal_texture_setup : MonoBehaviour {

    public Camera cameraB;
    public Camera cameraA;
    public Material cam_matB;
    public Material cam_matA;

	void Start () {
		if(cameraB.targetTexture != null)
        {
            cameraB.targetTexture.Release();
        }
        cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cam_matB.mainTexture = cameraB.targetTexture;

        if (cameraA.targetTexture != null)
        {
            cameraA.targetTexture.Release();
        }
        cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cam_matA.mainTexture = cameraA.targetTexture;
    }
	
}
