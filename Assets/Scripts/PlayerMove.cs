using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // �̵��ӵ�
    public float speed = 5f;

    public float rotateSpeed = 10f;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        if (!(h == 0 && v == 0))
        {
            // �̵��� ȸ���� �Բ� ó��
            transform.position += dir * speed * Time.deltaTime;
            // ȸ���ϴ� �κ�. Point 1.
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotateSpeed);
            anim.SetBool("Idle", false);
            anim.SetBool("Move", true);
        }

        else if (h == 0 && v == 0)
        {
            anim.SetBool("Move", false);
            anim.SetBool("Idle", true);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            anim.SetTrigger("Wave");
        }
    }
}
