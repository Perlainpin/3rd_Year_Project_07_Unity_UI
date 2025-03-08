using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class NumberDisplay : MonoBehaviour
{
    [SerializeField] Counter _counter;
    [SerializeField]private TextMeshProUGUI m_UIQuantity;
    [SerializeField]private TextMeshProUGUI m_UIQuantityPerSec; 

    private double m_Index;
    private double m_IndexPerSec;

    void Start()
    {
        m_Index = _counter.GetMilk();
        m_IndexPerSec = _counter.GetMilkPerSec();
    }

    void Update()
    {
        m_Index = _counter.GetMilk();
        m_IndexPerSec = _counter.GetMilkPerSec();
        UpdateMilk(m_Index);
        UpdateMilkPerSec(m_IndexPerSec);  
    }

    private void UpdateMilk(double milkamount)
    {
        DynamicQuantity(milkamount, m_UIQuantity);
    }
    private void UpdateMilkPerSec(double milkamount)
    {
        DynamicQuantity(milkamount, m_UIQuantityPerSec);
    }

    private void DynamicQuantity(double milkamount, TextMeshProUGUI ui)
    {
        string text = milkamount.ToString();
        int milkLength = milkamount.ToString().Length;
        if (milkamount.ToString().Length <= 6)
        {
            text = milkamount.ToString() + ".L";
        }
        if (milkamount.ToString().Length > 6 && milkamount.ToString().Length <= 9)
        {
            text = milkamount.ToString()[0] + "," + milkamount.ToString()[1] + milkamount.ToString()[2] + ".ML";
        }
        if (milkamount.ToString().Length > 9 & milkamount.ToString().Length <= 12)
        {
            text = milkamount.ToString()[0] + "," + milkamount.ToString()[1] + milkamount.ToString()[2] + ".GL";
        }
        if (milkamount.ToString().Length > 12 & milkamount.ToString().Length <= 15)
        {
            text = milkamount.ToString()[0] + "," + milkamount.ToString()[1] + milkamount.ToString()[2] + ".TL";
        }
        if (milkamount.ToString().Length > 15 & milkamount.ToString().Length <= 18)
        {
            text = milkamount.ToString()[0] + "," + milkamount.ToString()[1] + milkamount.ToString()[2] + ".PL";
        }
        if (milkamount.ToString().Length > 18 & milkamount.ToString().Length <= 21)
        {
            text = milkamount.ToString()[0] + "," + milkamount.ToString()[1] + milkamount.ToString()[2] + ".EL";
        }
        if (milkamount.ToString().Length > 21 & milkamount.ToString().Length <= 24)
        {
            text = milkamount.ToString()[0] + "," + milkamount.ToString()[1] + milkamount.ToString()[2] + ".ZL";
        }
        if (milkamount.ToString().Length > 24)
        {
            text = milkamount.ToString()[0] + "," + milkamount.ToString()[1] + milkamount.ToString()[2] + ".YL";
        }

        ui.SetText(text);
    }
}
