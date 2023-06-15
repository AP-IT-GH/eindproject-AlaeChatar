using UnityEngine;
using UnityEngine.XR;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]

public class PlayerBeam : MonoBehaviour
{
    [SerializeField]
    private LevelVariables levelVar;
    [SerializeField] 
    private GameObject beam;
    [SerializeField]
    private float cooldown;
    [SerializeField]
    private int cost;
    private InputDevice targetDevice;
    private float remainingCooldown;
    LineRenderer line;
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
        line.enabled = false;

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }

    void Update()
    {
        remainingCooldown -= Time.deltaTime;
        if(line.enabled)
        {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.forward * 20 + transform.position);
        }
    }

    public void FireBeam()
    {   
        line.enabled = false;
        if(levelVar.energy >= 10){
            
            if(remainingCooldown < 0)
            {
                Instantiate
                (
                    beam,
                    new Vector3(
                        this.transform.position.x, 
                        1f, 
                        this.transform.position.z
                    ),
                    this.transform.rotation
                );
                remainingCooldown = cooldown;
                levelVar.energy -= cost;
            }  
        }
    }

    public void PreviewBeam() {
        if(levelVar.energy >= 10){
            line.enabled = true;
        }
    }
}