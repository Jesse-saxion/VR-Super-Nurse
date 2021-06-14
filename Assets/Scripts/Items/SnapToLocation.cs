using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class communicates with the specified Item and calls its methods.
public class SnapToLocation : MonoBehaviour
{
    public GameObject Item;
    public GameObject ItemNameCanvas;
    private PreventUnpackaging PreventUnpackaging;

    //In case you want to use this class separetly from the Handler, you can add a collider to the game object
    //Otherwise the handler will call the snap 
    void OnTriggerEnter(Collider other)
    {
        if (other == Item)
        {
            SetSnapLocation();
            Snap();
        }
        else if (other.tag == "Item") //This is in case you want to use this class for other items other than the specified one
        {
            other.GetComponent<Item>().SetSnapLocation(transform.position);
            other.GetComponent<Item>().SnapToSetLocation();
        }
    }

    public void Snap()
    {
        Item.GetComponent<Item>().Snap(transform.position);
        PreventUnpackaging.setReadyToUnpack();
    }

    public void SnapToSetLocation()
    {
        Item.GetComponent<Item>().SnapToSetLocation();
    }

    public void SetSnapLocation()
    {
        Item.GetComponent<Item>().SetSnapLocation(transform.position);

        //Rotate the UI name
        if (ItemNameCanvas != null)
        {
            ItemNameCanvas.gameObject.transform.Rotate(new Vector3(0, 90, 0), Space.Self);
            ItemNameCanvas.gameObject.transform.Translate(new Vector3(0.1f, 0, 0), Space.Self);
        }
    }


    public void EnableInteractivity()
    {
        Item.GetComponent<Item>().EnableInteractivity();
    }
}
