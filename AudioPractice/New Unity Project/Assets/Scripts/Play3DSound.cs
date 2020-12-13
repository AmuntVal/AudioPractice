using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play3DSound : MonoBehaviour
{
    private GameObject mainCamera = null;
    public GameObject cubeObject = null;

    private void Awake()
    {
        //初始化坐标
        mainCamera = GameObject.Find("Main Camera");
        cubeObject = GameObject.Find("Cube");
        Vector3 tempPos = mainCamera.transform.position;
        tempPos.x = -100;
        transform.position = tempPos;
    }

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        //右侧移动
        direction.x = 1; direction.y = 0; direction.z = 0;
        //添加音频发声对象
        this.gameObject.AddComponent<AkGameObj>();
    }

    private uint palyingID = 0;
    // Update is called once per frame
    void Update()
    {
        if(palyingID == 0)
        {
            palyingID = AkSoundEngine.PostEvent("Play_Shortgun", this.gameObject);
        }
        float distance = Vector3.Distance(transform.position, mainCamera.transform.position);
        if(distance > 100)
        {
            //超过衰减距离反向移动
            direction = -direction;
        }
        transform.Translate(direction * 10 * Time.deltaTime, Space.World);
    }

    public void SpaceOn()
    {
        palyingID = 0;
    }

    public  void SpaceOff()
    {
        palyingID = 2;
        //AkSoundEngine.StopMIDIOnEvent("Play_Shotgun", this.gameObject);
        AkSoundEngine.StopAll(this.gameObject);
    }
}
