using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCollision : MonoBehaviour
{
    //충돌에 진입 할 때
    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.tag == "Player")
        //{
        //    int cHP = collision.gameObject.GetComponent<PlayerCollsion>().Hp;
        //    Debug.Log("Collision HP : " + cHP);
        //}
        Debug.Log("NAME ENTER : " + collision.gameObject.name);   //충돌체의 오브젝트 이름을 가져온다.
        //Debug.Log("TAG : " + collision.gameObject.tag);   //충돌체의 오브젝트 Tag를 가져온다.
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("NAME STAY : " + collision.gameObject.name);   //충돌체의 오브젝트 이름을 가져온다.
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("NAME EXIT : " + collision.gameObject.name);   //충돌체의 오브젝트 이름을 가져온다.
    }
}
