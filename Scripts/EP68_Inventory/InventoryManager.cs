using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public List<Item> items = new List<Item>();
    public List<int> itemNumbers = new List<int>();
    public GameObject[] slots;

    public Item temp_addItem;
    public Item temp_removeItem;

    //description
    private Description description;

    //temp
    private Image originImage;
    private Color originColor;
    private GameObject currentSlot;

    // 单例
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        originImage = slots[0].transform.GetChild(0).GetComponent<Image>();
        originColor = slots[0].transform.GetChild(0).GetComponent<Image>().color;
        _DisplayItems();
    }

    // 增加物品
    public void AddItem()
    {
        _AddItem(temp_addItem);
    }

    // 删除物品
    public void RemoveItem()
    {
        _RemoveItem(temp_removeItem);
    }


    // private 展示、增加、移除物品
    private void _DisplayItems()
    {
        for (int i = 0; i < items.Count; i++)
        {
            //Update slots Item Image
            slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1,1,1,1);
            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;

            //Update slots Item count text
            slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1,1,1,1);
            slots[i].transform.GetChild(1).GetComponent<Text>().text = itemNumbers[i].ToString();

            slots[i].transform.GetChild(3).GetComponent<Text>().text = items[i].itemDescription;

            //Update close/throw button
            //slots[i].transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    private void _AddItem(Item _item)
    {

        if (!items.Contains(_item))//inventory里没有该物品
        {
            items.Add(_item);
            itemNumbers.Add(1);
        }
        else //inventory里有该物品
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] == _item)
                {
                    itemNumbers[i]++;
                }
            }
        }

        _DisplayItems();
    }

    private void _RemoveItem(Item _item)
    {
        if (items.Contains(_item))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (_item == items[i])
                {
                    itemNumbers[i]--;
                    if (itemNumbers[i] == 0)
                    {
                        items.Remove(_item);
                        itemNumbers.Remove(itemNumbers[i]);
                        slots[i].transform.GetChild(0).GetComponent<Image>().color = originColor;
                        slots[i].transform.GetChild(0).GetComponent<Image>().sprite = originImage.sprite;

                        slots[i].transform.GetChild(1).GetComponent<Text>().color = originColor;

                        slots[i].transform.GetChild(3).GetComponent<Text>().text = "NulllluN";
                    }
                    
                }
            }
        }
        else
        {
            Debug.Log("You dont have it!");
        }

        
        _DisplayItems();
    }

}
