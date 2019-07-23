using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCreate : MonoBehaviour
{

    public GameObject EnemyPrefab;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(GameManager.startCheck == true)
        {

            if(Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(EnemyPrefab,GunCtrl.hit.point , Quaternion.identity);
            }
            

            if(GunCtrl.device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {

                Instantiate(EnemyPrefab, GunCtrl.hit.point, Quaternion.identity);

            }


        }
    }
}
