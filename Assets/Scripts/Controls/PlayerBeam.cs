using UnityEngine;
using UnityEngine.XR;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]

public class PlayerBeam : MonoBehaviour
{
    [SerializeField] 
    private GameObject beam;
    private InputDevice targetDevice;

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

    public void FireBeam()
    {
        Instantiate
        (
            beam, 
            new Vector3(
                Mathf.Sin(this.transform.rotation.y) * (beam.transform.localScale.z / 2) * -1, 
                this.transform.position.y, 
                Mathf.Cos(this.transform.rotation.y) * (beam.transform.localScale.z / 2)),
            this.transform.rotation
        );
    }
}