using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{
    public Transform redoDestination;
    public CounterUI counter;
    public ScoreUI ui;
    public Text displayText;
    public AudioSource correctSound;
    public AudioSource wrongSound;
    
    

    void RightSpot()
    {
        counter.itemsCollected += 1;
        correctSound.Play();
        Destroy(gameObject);
        ui.points += 100;
    }
    
    void WrongSpot()
    {
        wrongSound.Play();
        ui.points -= 50;    
        this.transform.position = redoDestination.position;
        this.transform.parent = GameObject.Find("RedoTransform").transform;
    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (gameObject.tag == "Recyclable")
        {
            if (collision.collider.tag == "Recycle Bin")
            {
                RightSpot();
                displayText.text = gameObject.name + " was recycled!";
                //Destroy(displayText, time);
            }
            else if (collision.collider.tag == "Trash Bin")
            {
                WrongSpot();
                displayText.text = gameObject.name + " can be recycled. Try Again.";
            }
            else if(collision.collider.tag == "Compost Bin")
            {
                if(gameObject.name == "Paper" || gameObject.name == "Cardboard Box" || gameObject.name == "Drink Tray")
                {
                    RightSpot();
                    displayText.text = gameObject.name + " can also be composted. Good Job!";
                }
                else
                {
                    WrongSpot();
                    displayText.text = gameObject.name + " can't be composted. Try Again!";
                }
            }
        }

        if (gameObject.tag == "Trashable")
        {
            if (collision.collider.tag == "Trash Bin")
            {
                RightSpot();                
                displayText.text = gameObject.name + " was put in the trash!";
                //Destroy(displayText, time);
            }
            else if (collision.collider.tag == "Recycle Bin")
            {
                WrongSpot();
                displayText.text = gameObject.name + " can't be recycled. Try Again.";
            }
            else if(collision.collider.tag == "Compost Bin")
            {
                if(gameObject.name == "Soiled Paper")
                {
                    RightSpot();
                    displayText.text = gameObject.name + " can also be composted. Good Job!";
                }
                else
                {
                    WrongSpot();
                    displayText.text = gameObject.name + " can't be composted. Try Again!";
                }
            }
        }


        if (gameObject.tag == "Compostable")
        {
            if (collision.collider.tag == "Compost Bin")
            {
                RightSpot();
                displayText.text = gameObject.name + " was composted!";
                //Destroy(displayText, time);
            }
            else if (collision.collider.tag == "Trash Bin")
            {
                Debug.Log(counter.itemsCollected += 1);
                ui.points += 50;
                //collected.text = "Items Collected\n" + itemsCollected + "/50";
                Destroy(gameObject);
                displayText.text = gameObject.name + " was thrown away but can be composted!";
                //Destroy(displayText, time);
            }
            else if (collision.collider.tag == "Recycle Bin")
            {
                WrongSpot();
                displayText.text = gameObject.name + " can't be recycled! Try Again!"; 
            }
        }


        if (ui.points < 0)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        
       
        if (counter.itemsCollected == 50)
        {
            FindObjectOfType<GameManager>().GameWon();
            
        }
        
        
    }

}
