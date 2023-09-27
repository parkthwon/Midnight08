using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconMove : MonoBehaviour
{
    // ������ġ
    public Transform startPos;
    // �ǵ��ư� ��ġ
    public Transform backPos;

    // �̵� �ӵ�
    public float speed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ��� ������ (x ������) �̵��ϰ� �ʹ�
        transform.position += transform.right * speed * Time.deltaTime;

        // ���� ������ ������ �Ÿ��� ����Ѵ�
        float dist = Vector3.Distance(backPos.position, transform.position);

        // ���� ���� ���� ��ġ�� backPos���� �Ÿ��� 1���� �۴ٸ�
        if (dist < 1)
        {
            // ���� ��ġ�� ó�� ��ġ�� �Ѵ�
            transform.position = startPos.position;
        }
    }
}
