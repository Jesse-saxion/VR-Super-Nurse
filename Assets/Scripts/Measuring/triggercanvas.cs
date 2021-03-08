using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class triggercanvas : MonoBehaviour
{
    [SerializeField] private List<int> number;
    [SerializeField] private TMP_Text numbertxt;
    public int selectednumber = 0;
    private int index = 0;

    private void Start()
    {
        selectednumber = number[0];
    }

    private void Update()
    {
        numbertxt.text = selectednumber.ToString();
    }


    public void Addnumber()
    {
        index++;
        selectednumber = number[index % number.Count];

    }

    public void Minusnumber()
    {
        index--;
        selectednumber = number[index % number.Count];
    }


}
