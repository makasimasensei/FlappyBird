using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackGround_Control : MonoBehaviour
{
    //±³¾°ÒÆ¶¯ËÙ¶È
    readonly float speed = 0.2f;
    //±³¾°Í¼Æ¬µÄ¿í¶È
    readonly float distance = 2.88f;
    float record_distance;
    public Transform background1, background2;

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Transform t in transform)
        {
            //ÒÆ¶¯±³¾°
            Vector3 v = t.localPosition;
            v.x -= Time.deltaTime * speed;
            t.localPosition = v;
        }

        //½«Á½ÕÅ±³¾°Í¼Æ¬½»ÌæÒÆ¶¯
        record_distance += Time.deltaTime * speed;
        if (record_distance >= distance)
        {
            if (background1.localPosition.x < background2.localPosition.x)
            {
                Vector3 background1_pos = background1.localPosition;
                background1_pos.x = background2.localPosition.x + 2.88f;
                background1.localPosition = background1_pos;
                record_distance = 0f;
            }
            else
            {
                Vector3 background2_pos = background2.localPosition;
                background2_pos.x = background1.localPosition.x + 2.88f;
                background2.localPosition = background2_pos;
                record_distance = 0f;
            }
        }
    }
}
