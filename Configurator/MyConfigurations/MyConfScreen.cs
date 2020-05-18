using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyConfScreen : MonoBehaviour
{

    public GameObject prefab;
    public GameObject parent;
    public MenuManager menuManager;

    private void OnEnable()
    {
        if (menuManager.myConfigs!=null)
        {
            foreach(Transform g in parent.transform)
            {
                Destroy(g.gameObject);
            }
            foreach(MyConfiguration m in menuManager.myConfigs)
            {
               GameObject obj = Instantiate(prefab, parent.transform);
                obj.GetComponentInChildren<Text>().text = string.Format("{0} - {1}",m.model, m.data);

                obj.GetComponent<Button>().onClick.AddListener(() =>
                {
                    menuManager.Open(menuManager.qrCode);
                    menuManager.qrCode.GetComponent<ConfigCodeScreen>().code.text = m.code;
                    menuManager.qrCode.GetComponent<ConfigCodeScreen>().description.text = string.Format("{0} - {1}", m.model, m.data);
                });
            }
        }
    }
}
