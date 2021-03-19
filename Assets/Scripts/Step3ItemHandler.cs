using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step3ItemHandler : MonoBehaviour
{
    public List<GameObject> requiredItems;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            for (int i = 0; i < transform.childCount; i++) //Go through all the snap zones and find the corresponding location for the Item
            {
                if (transform.GetChild(i).TryGetComponent<SnapToLocation>(out SnapToLocation snapToLocation)) //In case there a objects that don't have SnapToLocation 
                {                    
                    if (snapToLocation.Item.name == other.name)
                    {
                        CorrectItem(snapToLocation);

                        return;
                    }
                }
            }
       
            //If didn't find the right place for the Item
            WrongItem(other.gameObject);
        }
    }

    void CorrectItem(SnapToLocation pSnapLocation)
    {
        //Snap the Item to the new position and activate it in case it's interactable 
        pSnapLocation.SetSnapLocation();
        pSnapLocation.SnapToSetLocation();
        pSnapLocation.EnableInteractivity();
        
    }

    void WrongItem(GameObject pOther)
    {
        //Snap to the old position (without setting the new one) if wrong Item
        pOther.GetComponent<Item>().SnapToSetLocation();

    }

}
