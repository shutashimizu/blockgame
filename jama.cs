using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jama : MonoBehaviour
{
    float posY;
    public float speed = 2.0f;  // オブジェクトが左右に動く速度
    public float range = 1.6f;  // オブジェクトが動く範囲の半分

    // Start is called before the first frame update
    void Start()
    {
        posY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float posX = Mathf.PingPong(Time.time * speed, range * 2) - range; 
        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
