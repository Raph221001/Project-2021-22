using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;

    [SerializeField, Range(0, 35)] private float TimeOfDay;
    
    private void Update()
    {
        //Checks if preset is assigned
        if(Preset == null)
            return;
        
        if(Application.isPlaying)
        {
            //Time will be updated and then lighting
            //TimeOfDay is equal to 35 as range is set from 0 - 35 
            TimeOfDay += Time.deltaTime;
            TimeOfDay %= 35;
            UpdateLighting(TimeOfDay / 35f);
        }
    }
    private void UpdateLighting(float timePercent)
    {
        //Evaluates all of the different gradients in preset script
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        //First checks if Directional is set
        if (DirectionalLight != null)
        {
            //Changes Directional Light colour
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);

            //Changes rotation
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }
    }
    
}
