using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

[System.Serializable]
public class MenuButtonEvent : UnityEvent<bool>
{

}

public class MenuButtonWatcher : MonoBehaviour
{

    public MenuButtonEvent menuButtonPress;

    private bool lastButtonState = false;
    private bool appState = true;

    private List<InputDevice> devicesWithMenuButton;

    private void InputDevices_deviceConnected(InputDevice device)
    {
        bool discardedValue;
        if (device.TryGetFeatureValue(CommonUsages.menuButton, out discardedValue))
            devicesWithMenuButton.Add(device);
    }


    private void InputDevices_deviceDisconnected(InputDevice device)
    {
        if (devicesWithMenuButton.Contains(device))
            devicesWithMenuButton.Remove(device);
    }

    void Start()
    {
        devicesWithMenuButton = new List<InputDevice>();
        RegisterDevices();
    }

    void Update()
    {
        bool tempState = false;
        foreach (var device in devicesWithMenuButton)
        {
            bool primaryButtonState = false;
            tempState = device.TryGetFeatureValue(CommonUsages.menuButton, out primaryButtonState) && primaryButtonState || tempState;
        }
        if (tempState != lastButtonState)
        {
            if (tempState)
            {
                appState = !appState;
                menuButtonPress.Invoke(appState);
            }
            lastButtonState = tempState;
        }
    }

    private void OnEnable()
    {
        RegisterDevices();
    }

    private void OnDisable()
    {
        InputDevices.deviceConnected -= InputDevices_deviceConnected;
        InputDevices.deviceDisconnected -= InputDevices_deviceDisconnected;
        devicesWithMenuButton.Clear();
    }

    private void RegisterDevices()
    {
        List<InputDevice> allDevices = new List<InputDevice>();
        InputDevices.GetDevices(allDevices);
        foreach (InputDevice device in allDevices)
            InputDevices_deviceConnected(device);
        InputDevices.deviceConnected += InputDevices_deviceConnected;
        InputDevices.deviceDisconnected += InputDevices_deviceDisconnected;
    }
}
