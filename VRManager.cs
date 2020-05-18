using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class VRManager : MonoBehaviour {

    public void Start()
    {
       
        StartCoroutine(LoadDevice());
    }

    IEnumerator LoadDevice()
    {
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;


        // Wait for landscape left / right orientation.
        while (Screen.orientation != ScreenOrientation.LandscapeLeft && Screen.orientation != ScreenOrientation.LandscapeRight)
        {
           
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            yield return null;
        }

        
        XRSettings.LoadDeviceByName("cardboard");
        yield return null;
        XRSettings.enabled = true;

    }
 
}
