using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum JetpackState
{
    JETPACK_ON, JETPACK_OFF
}

public class Jetpack : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private JetpackState jetpackState;
    public JetpackState JetpackState { private get => jetpackState; set => jetpackState = value; }

    [SerializeField] private Slider jetpackSlider;
    
    [SerializeField] private float rechargeRate;
    private float drainRate = 10f;
    private float maxFuelAmount;
    [SerializeField] private float fuelAmount;
    public float FuelAmount { get => fuelAmount; set => fuelAmount = value; }
    [SerializeField] private float boostStrength;
    public float BoostStrength { get => boostStrength; private set => boostStrength = value; }
    

    private void Awake()
    {
        SetMaxFuel();
        JetpackState = JetpackState.JETPACK_OFF;
    }

    private void Update()
    {
        FuelLoad();
        FuelDrain();
        UpdateJetpackUI();
    }

    private void SetMaxFuel()
    {
        maxFuelAmount = FuelAmount;
    }

    private void FuelLoad()
    {
        if (playerController.SphereState == SphereState.IS_ON_GROUND && FuelAmount < maxFuelAmount)
            FuelAmount += rechargeRate * Time.deltaTime;
    }

    private void FuelDrain()
    {
        if (JetpackState == JetpackState.JETPACK_ON && FuelAmount > 0f)
            FuelAmount -= drainRate * Time.deltaTime;
    }

    private void UpdateJetpackUI()
    {
        float fuelPercentage = FuelAmount / maxFuelAmount;
        if (fuelPercentage >= 0f && fuelPercentage <= 1f)
            jetpackSlider.value = fuelPercentage;
    }

    public bool IsFuelTankFull()
    {
        if (FuelAmount >= maxFuelAmount)
            return true;
        return false;
    }
}
