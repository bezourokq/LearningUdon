using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public bool showController;
    public InputDeviceCharacteristics controllerCharacteristic;
    public List<GameObject> controllerPrefabs;
    private InputDevice targetDevice;
    private Text t;
    private GameObject temp;
    private bool estadoHold;
    private Transform buffer;
    private GameObject objectGR;

    public bool grabMode;
    private List<InputDevice> devices;


    void Start()
    {
        estadoHold = false;

        showController = true;

        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristic, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item);
        }

        Debug.Log("o numero de devices é " + devices.Count);
        if (devices.Count > 0)
        {
            targetDevice = devices[0];

        }
    }
    void Update()
    {

        targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue);
        if (primary2DAxisValue != Vector2.zero)
        {
            //t.text = "ccc " + primary2DAxisValue;
            targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
            if (primaryButtonValue && objectGR != null)
            {
                //
                //objectGR.GetComponent<Rigidbody>().isKinematic = false;
            }
        }

        if (estadoHold)
        {
            targetDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool gripValue);
            if (grabMode)
            {

            }
           
            if (!gripValue)
            {
                objectGR.GetComponent<Rigidbody>().isKinematic = false;
                objectGR.transform.parent = null;
                estadoHold = false;
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Table" && collision.gameObject.name != "Room")
        {
           
            if (collision.gameObject.name.Equals("Stick 1"))
            {
                buffer = transform;
            }
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name != "Table" && collision.gameObject.name != "Room")
        {
            targetDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool gripValue);
            if (gripValue)
            {
                if (collision.gameObject.name.Equals("Stick 1"))
                {
                    //SoundController tt = GameObject.Find("SoundController").GetComponent<SoundController>();
                    //tt.PlaySound(6);
                    if (!grabMode)
                    {
                        collision.transform.parent = transform;
                    }
                    estadoHold = true;
                    collision.rigidbody.isKinematic = true;
                    objectGR = collision.gameObject;

                }
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {

    }

    public void setMode()
    {
        grabMode = !grabMode;
    }

    public void vibrate()
    {
        targetDevice.SendHapticImpulse(0, 1, 0.5f);
    }

    
}
