using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckList : MonoBehaviour
{
    public List<GameObject> CheckListItems;
    private TMP_Text clipboardStepText;

    public void UpdateCheckList(int index)
    {
        Debug.Log("Updating checklist");
        clipboardStepText = CheckListItems[index].GetComponent<TextMeshProUGUI>();
        clipboardStepText.fontStyle = FontStyles.Strikethrough;
    }
}
