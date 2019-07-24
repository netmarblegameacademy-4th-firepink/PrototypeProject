using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public SkinnedMeshRenderer meshRender;
    public Collider hitBox;
    public GameObject diePrefab;
    public bool isHit = false;
    [SerializeField]float showTime;
    [SerializeField]float changeTime;
    [SerializeField]float deleteTime;
    //[SerializeField] bool guard = false;

    public Material EnemyNormal;
    //public GameObject bodyModel;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.timer>=showTime)
        {
            if(GameManager.timer>=changeTime+showTime)
            {
                meshRender.material = EnemyNormal;
                hitBox.enabled = true;
                Debug.Log("DeleteTime : " + (deleteTime + showTime + changeTime));

                if(isHit==true)
                {
                    hitBox.enabled = false;
                    meshRender.enabled = false;
                    diePrefab.SetActive(true);
                    Invoke("exit", 0.2f);
                }

                if(GameManager.timer >= (showTime+deleteTime + changeTime)&&isHit==false)
                {
                    Debug.Log("*****타임놓침*****");
                    Destroy(this.gameObject);
                }


            }

            meshRender.enabled = true;
        }


    }


    void exit()
    {
        Destroy(this.gameObject);
    }
}

/* if(guard == true)
        {
            bodyModel.GetComponent<MeshRenderer>().material = EnemyGuard;
        }
        else
        {
            bodyModel.GetComponent<MeshRenderer>().material = EnemyNormal;
        }


    */
