using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckList : MonoBehaviour
{
    public List<CheckListItem> CheckListItems;
    public GameObject clipBoard;
    private int index = 0;

    public void UpdateCheckList(string _text)
    {
        CheckListItems[index].Text.text = _text;
        CheckListItems[index].CheckMark.SetActive(true);
        index++;

        //Update the clipboard as well
        if (clipBoard != null)
        {
            clipBoard.GetComponentInChildren<CheckList>().UpdateCheckList(_text);
        }
    }
}
