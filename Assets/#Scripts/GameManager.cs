using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject StartButton;
    public GameObject HmdSoundPrefab;
    bool startCheck =false;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GunCtrl.device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            if(GunCtrl.hit.transform.gameObject.name== StartButton.transform.gameObject.name)
            {
                StartButton.SetActive(false);
                HmdSoundPrefab.SetActive(true);
                startCheck = true;
            }
        }


        if (startCheck == true)
        {
            timer += Time.deltaTime;
            Debug.Log("Timer : " + timer);
        }
    }





    void GameStart()
    {

    }

}
