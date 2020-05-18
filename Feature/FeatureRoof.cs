using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeatureRoof : MonoBehaviour
{
    IEnumerator coroutine = null;
    public GameObject roof;

    public void PointerEnter(GameObject roofType)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        coroutine = WaitForOption(roofType);
        StartCoroutine(coroutine);
    }

    public void PointerExit()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }

    public void Activate(GameObject roofType)
    {
        if(roofType == roof)
        {
            roof.SetActive(true);
           
        }
        else
        {
            roof.SetActive(false);
        }
    }

    private IEnumerator WaitForOption(GameObject roofType)
    {
        yield return new WaitForSecondsRealtime(1);
        Activate(roofType);
    }
}
