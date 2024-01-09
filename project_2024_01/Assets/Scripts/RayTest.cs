using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour
{
    public GameObject Temp;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))        //왼쪽 마우스가 눌렸을 때 
        {
            Ray cast = Camera.main.ScreenPointToRay(Input.mousePosition);   //Ray를 Casting 한다.
            RaycastHit hit;                         //Hit 케스트 선언
            if (Physics.Raycast(cast, out hit))     //Hit 된것이 있을 때
            {
                GameObject temp = Instantiate(Temp);    //오브젝트를 생성
                temp.transform.position = hit.point;    //Hit 된 포인트위치에 놓는다. 
            }
        }

        if (Input.GetMouseButtonDown(1))        //오른쪽 마우스가 눌렸을 때 
        {
            Ray cast = Camera.main.ScreenPointToRay(Input.mousePosition);   //Ray를 Casting 한다. 

            RaycastHit hit;                         //Hit 케스트 선언

            if (Physics.Raycast(cast, out hit))     //Hit 된것이 있을 때
            {
                Debug.Log(hit.collider.gameObject.name);                //hit 된 오브젝트 이름
                Debug.DrawLine(cast.origin, hit.point, Color.red, 2.0f);        //가상의 Line을 그려준다. 
                Destroy(hit.collider.gameObject);
            }
        }

    }
}
