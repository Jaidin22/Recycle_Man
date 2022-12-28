using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterUI : MonoBehaviour
{
    public Text collected;
    public int itemsCollected;
    // Start is called before the first frame update
    void Start()
    {
        itemsCollected = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        collected.text = "Items Collected\n" + itemsCollected + "/50";
    }
}
