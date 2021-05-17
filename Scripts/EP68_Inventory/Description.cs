using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Description : MonoBehaviour
{
    [SerializeField]
    private GameObject currentSlot;
    [SerializeField]
    private GameObject textArea;
    private Text itemDescription;

    // 文本
    private string tempStr;

    private void Start()
    {
        itemDescription = textArea.transform.GetChild(0).GetComponent<Text>();
        textArea.transform.GetChild(0).GetComponent<Text>().color = new Color(0, 0, 0, 0);
    }

    public void DisplayItemDescription()
    {
        textArea.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        textArea.transform.GetChild(0).GetComponent<Text>().color = new Color(0, 0, 0, 1);
        itemDescription.text = currentSlot.transform.GetChild(3).GetComponent<Text>().text;
        if ("New Text".Equals(itemDescription.text) || "NulllluN".Equals(itemDescription.text))
        {
            textArea.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            textArea.transform.GetChild(0).GetComponent<Text>().color = new Color(0, 0, 0, 0);
        }
        
    }

}
