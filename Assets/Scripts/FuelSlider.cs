using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelSlider : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Jetpack jetpack;

    [SerializeField] private Image fuelSliderBackground;
    [SerializeField] private Image fuelSliderFill;

    private void Update()
    {
        SetVisibilityOnScreen();
    }

    bool SetVisibilityOnScreen()
    {
        if (playerController.SphereState == SphereState.IS_ON_GROUND && jetpack.IsFuelTankFull())
        {
            SetImageTransparency(fuelSliderBackground, 0);
            SetImageTransparency(fuelSliderFill, 0);
            return true;
        }
        if (playerController.SphereState == SphereState.IS_ON_GROUND && !jetpack.IsFuelTankFull())
        {
            SetImageTransparency(fuelSliderBackground, 1);
            SetImageTransparency(fuelSliderFill, 1);
            return true;
        }
        if (playerController.SphereState == SphereState.IS_IN_AIR)
        {
            SetImageTransparency(fuelSliderBackground, 1);
            SetImageTransparency(fuelSliderFill, 1);
            return true;
        }

        return false;
    }

    void SetImageTransparency(Image image, int transparency)
    {
        Color color = image.color;
        color.a = transparency;
        image.color = color;
    }
}
