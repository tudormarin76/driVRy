using System;
using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine;
using UnityEngine.UI;

public class Configurator : MonoBehaviour
{
    public Text model;

    [Header("Colors")]
    public ConfigColor[] colors;
    public Toggle[] colorToggles;
    

    [Header("Upholstery")]
    [Space(40)]
    public ConfigColor[] upholstery;
    public Toggle[] upholsteryToggles;
    

    [Header("Ornaments")]
    [Space(40)]
    public ConfigColor[] ornaments;
    public Toggle[] ornamentsToggles;

    [Header("Features")]
    [Space(40)]
    public Feature[] features;
    public GameObject featureParent;

    [Space(40)]
    public Toggle[] gearbox;
    public Text total;


    public MenuManager menuManager;
    public PersistentConfigurator persistenObject;
    public GameObject toast;
    private List<string> fts = new List<string>();

    private void Start()
    {
        //Only used by unity editor
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://drivry-70d9a.firebaseio.com");
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        Debug.Log(Application.persistentDataPath);
        #region init default config
        persistenObject.selectedColor = colors[0];
        persistenObject.selectedOrnaments = ornaments[0];
        persistenObject.selectedUpholstery = upholstery[0];
        #endregion

        foreach (Feature f in features)
        {
            
            Toggle obj = Instantiate(f.toggle, featureParent.transform);
            obj.GetComponentInChildren<Text>().text = f.text;

            obj.onValueChanged.AddListener((value) => {
                if(value)
                {
                    AddToTotal(f.price);
                    persistenObject.selectedFeatures.Add(f);
                    fts.Add(f.name);
                }
                else
                {
                    AddToTotal(-f.price);
                    persistenObject.selectedFeatures.Remove(f);
                    fts.Remove(f.name);
                }
            }
       );
        }
    }

    public void SelectGearBox(int index)
    {
        if (gearbox[index].isOn)
        {
            gearbox[1 - index].isOn = false;
        }
    }

    public void SelectColor(int index)
    {
        if (colorToggles[index].isOn)
        {
            foreach(Toggle t in colorToggles)
            {
                if (t.isOn && t != colorToggles[index])
                {
                    t.isOn = false;
                }
            }
            persistenObject.selectedColor = colors[index];
        }
    }

    public void SelectOrnamets(int index)
    {
        if (ornamentsToggles[index].isOn)
        {
            foreach (Toggle t in ornamentsToggles)
            {
                if (t.isOn && t != ornamentsToggles[index])
                {
                    t.isOn = false;
                }
            }
            persistenObject.selectedOrnaments = ornaments[index];
        }
    }

    public void SelectUpholstery(int index)
    {
        if (upholsteryToggles[index].isOn)
        {
            foreach (Toggle t in upholsteryToggles)
            {
                if (t.isOn && t != upholsteryToggles[index])
                {
                    t.isOn = false;
                }
            }
            persistenObject.selectedUpholstery = upholstery[index];
        }
    }

    public void AddToTotal(int price)
    {

        total.text = string.Format("Total: {0} euro ",((int.Parse(total.text.Split(' ')[1])) + price).ToString());
    }

    public void AddItemToList()
    {
        
        
        DateTime now = DateTime.Now.Date;
        System.Random r = new System.Random();
        int rInt = r.Next(0, 100); 
        

        MyConfiguration myConfiguration = new MyConfiguration(now.ToShortDateString(), model.text, rInt.ToString());
        menuManager.myConfigs.Add(myConfiguration);
        ItemSaveIO.SaveItems(menuManager.myConfigs, "configurations");

        WriteData(rInt);
    }

    public async void WriteData(int rInt)
    {
        await FirebaseDatabase.DefaultInstance.GetReference("configs").SetValueAsync(rInt.ToString());
        await FirebaseDatabase.DefaultInstance.GetReference("configs").Child(rInt.ToString()).Child("Color").SetValueAsync(persistenObject.selectedColor.ToString());
        await FirebaseDatabase.DefaultInstance.GetReference("configs").Child(rInt.ToString()).Child("Ornaments").SetValueAsync(persistenObject.selectedOrnaments.ToString());
        await FirebaseDatabase.DefaultInstance.GetReference("configs").Child(rInt.ToString()).Child("Upholstery").SetValueAsync(persistenObject.selectedUpholstery.ToString());
        await FirebaseDatabase.DefaultInstance.GetReference("configs").Child(rInt.ToString()).Child("Features").SetValueAsync((String.Join(", ", fts.ToArray())).ToString());
    }

    
}
