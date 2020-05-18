using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(Wait());
    }

   IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(1);
        gameObject.SetActive(false);
    }
}
