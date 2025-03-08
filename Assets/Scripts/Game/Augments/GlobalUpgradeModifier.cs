using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalUpgradeModifier : MonoBehaviour
{
    [SerializeField] private float _globalUpgrade;
    [SerializeField] private float _globalCowUpgrade;
    [SerializeField] private float _globalFarmUpgrade;
    [SerializeField] private float _globalFactoryUpgrade;

    public void SetGlobalMultiplier(float add)
    {
        _globalUpgrade += add;
    }

    public void SetGlobalCowMultiplier(float add)
    {
        _globalCowUpgrade += add;
    }    

    public void SetGlobalFarmMultiplier(float add)
    {
        _globalFarmUpgrade += add;
    }    

    public void SetGlobalFactoryMultiplier(float add)
    {
        _globalFactoryUpgrade += add;
    }

    public float GetGlobalMultiplier()
    {
        return _globalUpgrade;
    } 

    public float GetGlobalCowMultiplier()
    {
        return _globalCowUpgrade;
    }

    public float GetGlobalFarmMultiplier()
    {
        return _globalFarmUpgrade;
    }

    public float GetGlobalFactoryMultiplier()
    {
        return _globalFactoryUpgrade;
    }

}

    
