using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jama : MonoBehaviour
{
    public Vector3 initialPosition = new Vector3(0.0f, 0.0f, 0.0f); // 初期位置
    public float speed = 2.0f;  // オブジェクトの速度
    public float rangeX = 1.6f; // オブジェクトがX軸方向に動く範囲の半分
    public float rangeY = 1.0f; // オブジェクトがY軸方向に動く範囲の半分
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = initialPosition; // 初期位置を設定
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float elapsedTime = Time.time - startTime;
        float phase = Mathf.PingPong(elapsedTime * speed, 2);

        float posX = 0.0f;
        float posY = 0.0f;

        if (phase < 1.0f)
        {
            posX = Mathf.Lerp(initialPosition.x - rangeX, initialPosition.x, phase);
            posY = Mathf.Lerp(initialPosition.y, initialPosition.y + rangeY, phase);
        }
        else
        {
            posX = Mathf.Lerp(initialPosition.x, initialPosition.x + rangeX, phase - 1.0f);
            posY = Mathf.Lerp(initialPosition.y + rangeY, initialPosition.y, phase - 1.0f);
        }

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}