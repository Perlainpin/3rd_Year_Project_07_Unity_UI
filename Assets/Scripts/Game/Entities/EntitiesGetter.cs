using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EntitiesGetter : MonoBehaviour
{
    private int _cowNumber;
    private int _farmNumber;
    private int _factoryNumber;

    [SerializeField] TextMeshProUGUI _cowsNumber;
    [SerializeField] TextMeshProUGUI _farmsNumber;
    [SerializeField] TextMeshProUGUI _factoriesNumber;


    private void Awake()
    {
        GameObject[] Cows = GameObject.FindGameObjectsWithTag("Cow");
        GameObject[] Farms = GameObject.FindGameObjectsWithTag("Farm");
        GameObject[] Factories = GameObject.FindGameObjectsWithTag("Factory");
        _cowNumber = Cows.Length;
        _farmNumber = Farms.Length;
        _factoryNumber = Factories.Length;
    }

    private void Start()
    {
        InvokeRepeating("UpdateStats", 0.0f, 1.0f);

    }
    private void UpdateStats()
    {
        _cowsNumber.text = _cowNumber.ToString();
        _farmsNumber.text = _farmNumber.ToString();
        _factoriesNumber.text = _factoryNumber.ToString();
    }
}
