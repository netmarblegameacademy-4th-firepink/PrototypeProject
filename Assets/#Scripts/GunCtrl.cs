using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;
public class GunCtrl : MonoBehaviour
{
    public Transform firePoint;
    public GameObject laserPrefab;
    public AudioSource ShootSound;
    public Material laserColor1;
    public Material laserColor2;
    public GameObject Muzzle;
    public static SteamVR_TrackedObject controller;
    public static SteamVR_Controller.Device device;

    public static RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<SteamVR_TrackedObject>();
        GameObject.Find("laser").GetComponent<MeshRenderer>().material = laserColor1;
    }

    // public SteamVR_Action_Boolean spawn = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");
    // Update is called once per frame
    void Update()
    {
        device = SteamVR_Controller.Input((int)controller.index);

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Muzzle.SetActive(true);

            Invoke("MuzzleHide", 0.2f);
            GameObject.Find("laser").GetComponent<MeshRenderer>().material = laserColor2; //트리거 발동시 색 변경
            ShootSound.Play();
            Debug.Log("Trigger Down : R");
            if (Physics.Raycast(new Ray(firePoint.transform.position, transform.TransformDirection(new Vector3(0, -1, 1))), out hit, 1000))
            {
                Debug.Log("Hit OBJ : " + hit.transform.gameObject.name);
                if (hit.transform.gameObject.tag == "Enemy") hit.transform.GetComponent<EnemyStatus>().isHit=true;  //Tag에 적이면 제거
            }
        }
        if(device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            GameObject.Find("laser").GetComponent<MeshRenderer>().material = laserColor1;
        }
            Debug.DrawRay(firePoint.transform.position, transform.TransformDirection(new Vector3(0, -1, 1)), Color.blue);
    }


    void MuzzleHide()
    {

        Muzzle.SetActive(false);
    }


}


