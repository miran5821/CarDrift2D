using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketController : Singleton<MarketController>
{
    public List<Items> items;
    public Image shopCharacter;
    public int money;
    int currentCarIndex;
    void Start()
    {
        Shop();
    }
    void Shop()
    {
        for (int i = 0; i < items.Count; i++)
        {
            GameObject car = items[i].car.gameObject;
            car.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = items[i].price.ToString();
            int index = i;
            items[i].car.GetComponentInChildren<Button>().onClick.AddListener(() => Buy(index, car));
        }
    }
    public void Buy(int id,GameObject carObject)
    {
        if (money >= items[id].price && !items[id].isTaken)
        {
            shopCharacter.sprite = items[id].car.GetComponent<Image>().sprite;
            shopCharacter.GetComponent<Image>().SetNativeSize();
            carObject.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Purchased";
            money -= items[id].price;
            items[id].isTaken = true;
        }
            
        else
            Debug.Log("Yetersiz para");

        if (items[id].isTaken)
        {
            shopCharacter.sprite = items[id].car.GetComponent<Image>().sprite;
            shopCharacter.GetComponent<Image>().SetNativeSize();
        }
    }
    
}
[System.Serializable]
public class Items
{
    public GameObject car;
    public int price;
    public bool isTaken;
    public Items(GameObject _car, Sprite _image,int _price,bool _isTaken)
    {
        car = _car;
        price = _price;
        isTaken = _isTaken;
    }

}
