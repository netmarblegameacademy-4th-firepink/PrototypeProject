using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;
public class GunCtrl : MonoBehaviour
{
    public Transform firePoint;
    public GameObject laserPrefab;

    SteamVR_TrackedObject controller;
    SteamVR_Controller.Device device;

    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<SteamVR_TrackedObject>();

    }

    // public SteamVR_Action_Boolean spawn = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");
    // Update is called once per frame
    void Update()
    {
        device = SteamVR_Controller.Input((int)controller.index);

        if(device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("work!");
        }

    }


}
