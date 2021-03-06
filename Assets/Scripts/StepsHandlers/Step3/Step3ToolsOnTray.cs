using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step3ToolsOnTray : SubStep
{
    [Header("Audio queues")]
    [SerializeField] private AudioClip correctItem;
    [SerializeField] private AudioClip wrongItem;
    [SerializeField] private AudioClip allItems;
    [SerializeField] private AudioClip tvHoist;
    [SerializeField] public QuestionHandler questionStep2;
    [Space]
    [SerializeField]
    List<GameObject> requiredItems;
    List<GameObject> addedItems;

    [SerializeField] public Animator tvAnimator;

    bool firstItem = true;

    public void Start()
    {
        InstantiateSubStep();
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

            //If it didn't find the right place for the Item
            WrongItem(other.gameObject);
        }
    }

    void CorrectItem(SnapToLocation pSnapLocation)
    {
        //Snap the Item to the new position and activate it in case it's interactable 
        pSnapLocation.SetSnapLocation();
        pSnapLocation.SnapToSetLocation();
        pSnapLocation.EnableInteractivity();

        PlayAudioClip(correctItem);

        Debug.Log("Placed a correct item on the tray.");

        //For the first correct item, play an audio queue
        if (firstItem)
        {
            firstItem = false;
        }

        if (requiredItems.Count == 0)
        {
            AllItems();
        }
    }

    void WrongItem(GameObject pOther)
    {
        PlayAudioClip(wrongItem);
        Debug.Log("Placed a wrong item on the tray.");
        pOther.GetComponent<Item>().SnapToSetLocation();
    }

    void AllItems()
    {
        Debug.Log("Placed all correct items, moving onto next question step.");
        PlayAudioClip(allItems);

        CompleteSubStep();
        Debug.Log("Completed first substep of Step 2.");

        ActivateQuestion(questionStep2);
        Debug.Log("Activated Question2.1U.");

        Debug.Log("Lowering the TV mount.");
        tvAnimator.SetTrigger("QuestionAsked");
        PlayAudioClip(tvHoist);
    }
}
