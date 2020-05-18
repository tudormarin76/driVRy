using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatureBinarOption : MonoBehaviour
{
    IEnumerator coroutine = null;
    public GameObject obj1;
    public GameObject obj2;

    public void PointerEnter(GameObject objType)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        coroutine = WaitForOption(objType);
        StartCoroutine(coroutine);
    }

    public void PointerExit()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }

    public void Activate(GameObject objType)
    {
        if (objType == obj1)
        {
            obj1.SetActive(true);
            obj2.SetActive(false);

        }
        else
        {
            obj1.SetActive(false);
            obj2.SetActive(true);
        }
    }

    private IEnumerator WaitForOption(GameObject objType)
    {
        yield return new WaitForSecondsRealtime(1);
        Activate(objType);
    }
}
