using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusScoreText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(transform.parent.gameObject,1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.0f,1.5f * Time.deltaTime,0.0f);
        Color color = GetComponent<Text>().color;
        color.a = Mathf.Lerp(color.a,0.0f,0.025f);
        GetComponent<Text>().color = color;
    }
}
