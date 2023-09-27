using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconMove : MonoBehaviour
{
    // 시작위치
    public Transform startPos;
    // 되돌아갈 위치
    public Transform backPos;

    // 이동 속도
    public float speed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 계속 옆으로 (x 축으로) 이동하고 싶다
        transform.position += transform.right * speed * Time.deltaTime;

        // 나와 목적지 까지의 거리를 계산한다
        float dist = Vector3.Distance(backPos.position, transform.position);

        // 만약 현재 나의 위치가 backPos와의 거리가 1보다 작다면
        if (dist < 1)
        {
            // 나의 위치를 처음 위치로 한다
            transform.position = startPos.position;
        }
    }
}
