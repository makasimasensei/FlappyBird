using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land_Control : MonoBehaviour
{
    //陆地移动速度
    readonly float speed = 0.6f;
    //陆地图片的宽度
    readonly float distance = 6.72f;
    float record_distance;
    public Transform background1, background2;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        foreach (Transform t in transform)
        {
            //移动背景
            Vector3 v = t.localPosition;
            v.x -= Time.deltaTime * speed;
            t.localPosition = v;
        }

        //将两张背景图片交替移动
        record_distance += Time.deltaTime * speed;
        if (record_distance >= distance)
        {
            if (background1.localPosition.x < background2.localPosition.x)
            {
                Vector3 background1_pos = background1.localPosition;
                background1_pos.x = background2.localPosition.x + 6.72f;
                background1.localPosition = background1_pos;
                record_distance = 0f;
            }
            else
            {
                Vector3 background2_pos = background2.localPosition;
                background2_pos.x = background1.localPosition.x + 6.72f;
                background2.localPosition = background2_pos;
                record_distance = 0f;
            }
        }
    }
}
