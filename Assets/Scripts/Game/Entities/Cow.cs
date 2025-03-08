using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour, IInteractive
{
    [SerializeField] private Counter _counter;
    [SerializeField] private GlobalUpgradeModifier _globalUpgrade;
    [SerializeField] private double _production;
    [SerializeField] private double _productionMultiplier;


    public void OnClick()
    {
        Produce();
    }

    public void Interact()
    {

    }

    public void Produce()
    {
        double amount = _production * _productionMultiplier * _globalUpgrade.GetGlobalCowMultiplier() * _globalUpgrade.GetGlobalMultiplier();
        _counter.AddMilk(amount);
        Debug.Log(amount);
    }

    public double GetProduction()
    {
        return _production;
    }


}
