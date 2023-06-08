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
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }

    void Update()
    {
        remainingCooldown -= Time.deltaTime;
    }

    public void FireBeam()
    {
        if(remainingCooldown < 0)
        {
            Instantiate
            (
                beam, 
                new Vector3(
                    Mathf.Sin(this.transform.rotation.y) * (beam.transform.localScale.z / 2) * -1, 
                    1.5f, 
                    Mathf.Cos(this.transform.rotation.y) * (beam.transform.localScale.z / 2)),
                this.transform.rotation
            );
            remainingCooldown = cooldown;
            levelVar.energy -= cost;
        }
    }
}