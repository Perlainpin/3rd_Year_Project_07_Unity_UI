using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Augments : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _titleText;
    [SerializeField] TextMeshProUGUI _priceText;

    [SerializeField] Counter _counter;
    [SerializeField]GlobalUpgradeModifier _modifier;

    [SerializeField] private float _price, _priceMultiplier, _modifierAmount;
    public enum UpgradeTarget { All, Cow, Farm, Factory};
    [SerializeField] private UpgradeTarget _upgradeTarget;

    private void Update()
    {
        DynamicQuantity(_priceMultiplier, $"{_upgradeTarget.ToString()}", _titleText);
        DynamicQuantity(_price, "", _priceText);
    }

    public void Buy()
    {
        if (_counter.GetMilk() >= _price)
        {
            _counter.SellMilk(_price);
            switch (_upgradeTarget)
            {
                case UpgradeTarget.Cow:
                    _modifier.SetGlobalCowMultiplier(_modifierAmount);
                    break;
                case UpgradeTarget.Farm:
                    _modifier.SetGlobalFarmMultiplier(_modifierAmount);
                    break;
                case UpgradeTarget.Factory:
                    _modifier.SetGlobalFactoryMultiplier(_modifierAmount);
                    break;
                default:
                    _modifier.SetGlobalMultiplier(_modifierAmount);
                    break;
            }
            _price *= _priceMultiplier; 
        }
    }

    private void DynamicQuantity(double milkamount, string textToAdd, TextMeshProUGUI ui)
    {
        string text = milkamount.ToString() + textToAdd;
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
