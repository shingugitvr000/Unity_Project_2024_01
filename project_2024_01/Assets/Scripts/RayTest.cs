using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour
{
    public GameObject Temp;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))        //���� ���콺�� ������ �� 
        {
            Ray cast = Camera.main.ScreenPointToRay(Input.mousePosition);   //Ray�� Casting �Ѵ�.
            RaycastHit hit;                         //Hit �ɽ�Ʈ ����
            if (Physics.Raycast(cast, out hit))     //Hit �Ȱ��� ���� ��
            {
                GameObject temp = Instantiate(Temp);    //������Ʈ�� ����
                temp.transform.position = hit.point;    //Hit �� ����Ʈ��ġ�� ���´�. 
            }
        }

        if (Input.GetMouseButtonDown(1))        //������ ���콺�� ������ �� 
        {
            Ray cast = Camera.main.ScreenPointToRay(Input.mousePosition);   //Ray�� Casting �Ѵ�. 

            RaycastHit hit;                         //Hit �ɽ�Ʈ ����

            if (Physics.Raycast(cast, out hit))     //Hit �Ȱ��� ���� ��
            {
                Debug.Log(hit.collider.gameObject.name);                //hit �� ������Ʈ �̸�
                Debug.DrawLine(cast.origin, hit.point, Color.red, 2.0f);        //������ Line�� �׷��ش�. 
                Destroy(hit.collider.gameObject);
            }
        }

    }
}
