using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUI : MonoBehaviour
{
    public int factNumber;
    
    public string[] factList;
    private bool canInteract;

    public Canvas dialogue;
    public Canvas overlay;
    public Text factText;
    public Text learnText;


    private void Start()
    {
        dialogue.gameObject.SetActive(false);
        learnText.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (canInteract == true)
        {
            learnText.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                //if(factNumber)
                
                dialogue.gameObject.SetActive(true);
                overlay.gameObject.SetActive(false);
                factText.text = gameObject.name +"\n" + factList[factNumber];
                //Debug.Log(factList[factNumber]);
            }

        }
    }
    private void OnTriggerEnter(Collider player)
    {
        //if(.gameObject.tag == "Player")
        if(player.gameObject.tag == "Player")
        {
            learnText.gameObject.SetActive(true);
            canInteract = true;
        }
    }
    private void OnTriggerExit(Collider player)
    {
        //if(.gameObject.tag == "Player")
        if (player.gameObject.tag == "Player")
        {
            canInteract = false;
            dialogue.gameObject.SetActive(false);
            learnText.gameObject.SetActive(false);
            overlay.gameObject.SetActive(true) ;
        }
    }


    /*
    void OnGUI()
    {
        
            GUI.Box(new Rect(textX_Axis, textY_Axis, textWidth, textHeight), factList[0]);
        
    }
    void OnMouseDown()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, 3, FactsLayerMask))
        {
            OnGUI();
        }
    }
    */

}
