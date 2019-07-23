using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;
public class GunCtrl : MonoBehaviour
{
    public Transform firePoint;
    public GameObject laserPrefab;

    public static SteamVR_TrackedObject controller;
    public static SteamVR_Controller.Device device;

    public static RaycastHit hit;

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

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {

            Debug.Log("Trigger Down : R");
            if(Physics.Raycast(   new Ray(firePoint.transform.position, transform.TransformDirection(new Vector3(0, -1, 1))) , out hit , 1000     ))
            {
                Debug.Log("Hit OBJ : " + hit.transform.gameObject.name);

                
            }
        }
        Debug.DrawRay(firePoint.transform.position, transform.TransformDirection(new Vector3(0,-1,1)), Color.blue);
        
    }


}
