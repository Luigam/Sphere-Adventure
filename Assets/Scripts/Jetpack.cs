using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jetpack : MonoBehaviour
{
    [SerializeField] private Slider jetpackSlider;
    [SerializeField] private PlayerController playerController;

    [SerializeField] private float rechargeRate;
    private float drainRate = 2f;
    [SerializeField] private float fuelAmount;
    private float maxFuelAmount;
    [SerializeField] private float boostStrength;
    public float BoostStrength { get => boostStrength; private set => boostStrength = value; }

    private void Awake()
    {
        SetMaxFuel();
    }

    private void Update()
    {
        FuelLoad();
        FuelDrain();
        UpdateJetpackUI();
    }

    private void SetMaxFuel()
    {
        maxFuelAmount = fuelAmount;
    }

    private void FuelLoad()
    {
        if (playerController.SphereState == SphereState.IS_ON_GROUND)
            fuelAmount += rechargeRate * Time.deltaTime;
    }

    private void FuelDrain()
    {
        if (playerController.SphereState == SphereState.IS_IN_AIR)
            fuelAmount -= drainRate * Time.deltaTime;
    }

    private void UpdateJetpackUI()
    {
        float fuelPercentage = fuelAmount / maxFuelAmount;
        if (fuelPercentage >= 0f && fuelPercentage <= 1f)
            jetpackSlider.value = fuelPercentage;
    }
}
