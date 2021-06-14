using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckList : MonoBehaviour
{
    public List<GameObject> CheckListItems;
    private int index = 0;
    private TMP_Text clipboardStepText;

    public void UpdateCheckList()
    {
        Debug.Log("Updating checklist");
        clipboardStepText = CheckListItems[index].GetComponent<TextMeshProUGUI>();
        clipboardStepText.fontStyle = FontStyles.Strikethrough;
        index++;
        Debug.Log(index);
    }
}
