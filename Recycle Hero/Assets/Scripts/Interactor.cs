using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    public LayerMask InteractableLayerMask;
    public Image interactImage;
    public Sprite defaultIcon;
    public Sprite interactIcon;

    void Update()
    {

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, 3, InteractableLayerMask))
        {
            interactImage.sprite = interactIcon;
        }
        else
        {
            interactImage.sprite = defaultIcon;
        }


    }
}
