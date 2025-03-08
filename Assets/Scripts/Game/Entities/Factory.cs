using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour, IInteractive
{
    [SerializeField] private Counter _counter;
    [SerializeField] private GlobalUpgradeModifier _globalUpgrade;

    [SerializeField] private double _AGProduction;
    [SerializeField] private double _AGMultiplier;
    [SerializeField] private double _companyInfluence;

    public List<Farm> agriculturalCooperative = new List<Farm>();


    private void Start()
    {
        InvokeRepeating("AGProduction", 0.0f, 1.0f);
    }

    public void OnClick()
    {

    }

    public void Interact()
    {

    }

    private void AGProduction()
    {
        _AGProduction = 0;
        for (int i = 0; i < agriculturalCooperative.Count; i++)
        {
            if (agriculturalCooperative[i] == null) continue;
            double produceAmount = agriculturalCooperative[i].GetFarmProduction() * CalculateAGProductivity() * _globalUpgrade.GetGlobalCowMultiplier() * _globalUpgrade.GetGlobalMultiplier(); ;
            _counter.AddMilk(produceAmount);
            _AGProduction += produceAmount;
        }
        _counter.AddMilkPerSec(_AGProduction);
    }

    private double CalculateAGProductivity()
    {
        return  _companyInfluence * _AGMultiplier;
    }

    public double GetAGProduction()
    {
        return _AGProduction;
    }

}

[Serializable]
public class AgriculturalCooperative
{
    public Farm farm;
}