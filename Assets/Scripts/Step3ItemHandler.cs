using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step3ItemHandler : MonoBehaviour
{
    [SerializeField]
    List<GameObject> requiredItems;
    List<GameObject> addedItems;

    [SerializeField]
    GameObject button;
    [SerializeField]
    public CheckList checkList;

    [Header("Audio queues")]
    [SerializeField]
    AudioClip correctItem;
    [SerializeField]
    AudioClip wrongItem;
    [SerializeField]
    AudioClip allItems;

    AudioSource audioSource;
    
    bool firstItem = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        addedItems = new List<GameObject>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item" && !addedItems.Contains(other.gameObject))
        {
            for (int i = 0; i < transform.childCount; i++) //Go through all the snap zones and find the corresponding location for the Item
            {
                if (transform.GetChild(i).TryGetComponent<SnapToLocation>(out SnapToLocation snapToLocation)) //In case there a objects that don't have SnapToLocation 
                {
                    if (snapToLocation.Item.name == other.name)
                    {
                        requiredItems.Remove(other.gameObject);
                        addedItems.Add(other.gameObject);
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

        //For the first correct item, play an audio queue
        if (firstItem)
        {
            audioSource.PlayOneShot(correctItem);
            firstItem = false;
        }

        if (requiredItems.Count == 0)
        {
            AllItems();
        }
    }

    void WrongItem(GameObject pOther)
    {
        //Snap to the old position (without setting the new one) if wrong Item
        pOther.GetComponent<Item>().SnapToSetLocation();
        audioSource.PlayOneShot(wrongItem);
    }

    void AllItems()
    {
        audioSource.PlayOneShot(allItems);
        audioSource.Play(); //Success sound

        button.SetActive(true);
        checkList.UpdateCheckList("Select and place items");
    }
}
