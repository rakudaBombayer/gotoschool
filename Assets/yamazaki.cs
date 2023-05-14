using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yamazaki : MonoBehaviour
{   
    // public float time;死ぬまでの時間
    float Timer;
    public float ChangeTime;
    public float EnemySpeed;

    GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        // Destroy(this.gameObject, time);
    }

    // Update is called once per frame
    void Update()
    {
        var speed = Vector3.zero;
        speed.z = EnemySpeed;
        var rot = transform.eulerAngles;

        if (Target)
        {
            transform.LookAt(Target.transform);
            rot = transform.eulerAngles;
            this.transform.Translate(speed);
            // 上にこれがあれば追いかけやめ スイッチ アクション動画#10 12:00ごろ
        }
        else
        {
            Timer += Time.deltaTime;
            if (ChangeTime <= Timer)
            {
                float rand = Random.Range(0, 120);
                rot.y = rand;
                Timer = 0;
            }
        }

        
        rot.x = 0;
        rot.z = 0;
        transform.eulerAngles = rot;

        // this.transform.Translate(speed);
        // 上にこれがあれば常に走る スイッチ
    }

    private void OnTriggerEnter(Collider other) 
        {
            if(other.tag=="Player")
            {
                Target = other.gameObject;
            }
        }

    private void OnTriggerExit(Collider other) 
        {
            if(other.tag=="Player")
            {
                Target = null;
            }
        }

}


