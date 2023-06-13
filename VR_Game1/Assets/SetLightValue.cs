using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLightValue : MonoBehaviour
{
    public Light directionalLight;
    
    public void SetLightFromValue(float lightValue)
    {
        directionalLight.intensity = lightValue;
    }
}
