using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Windows")]
    [SerializeField] GameObject chooseBrand;
    [SerializeField] GameObject chooseModel;
    [SerializeField] GameObject configurator;
    [SerializeField] GameObject myConfigurations;
    public GameObject qrCode;
    public GameObject emailPopup;

    [HideInInspector]
    public List<MyConfiguration> myConfigs;
    [HideInInspector]
    public string configData;



    private void Start()
    {
       myConfigs = ItemSaveIO.LoadItems("configurations");
        if (myConfigs == null)
        {
            myConfigs = new List<MyConfiguration>();
        }
    }

    public void Back(GameObject windowToClose)
    {
        windowToClose.SetActive(false);
    }

    public void Open(GameObject windowToOpen)
    {
        windowToOpen.SetActive(true);
    }

    //Load scene with VR showroom
    public void OpenVR()
    {
        SceneManager.LoadScene(1);
    }

   
}
