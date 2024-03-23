using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItems : MonoBehaviour
{
    public GameObject subject_info;
    Text subject_text;
    // Start is called before the first frame update
    void Start()
    {
        subject_text = subject_info.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AddLetter(string value)
    {
        subject_text.text = subject_text.text + value;
    }
}
