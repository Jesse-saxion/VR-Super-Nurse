using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckList : MonoBehaviour
{
    public List<CheckListItem> CheckListItems;
    private int index = 0;
    public void UpdateCheckList(string _text)
    {
        CheckListItems[index].Text.text = _text;
        CheckListItems[index].CheckMark.SetActive(true);
        index++;
    }
}
