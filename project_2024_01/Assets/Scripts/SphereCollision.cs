using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCollision : MonoBehaviour
{
    //�浹�� ���� �� ��
    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.tag == "Player")
        //{
        //    int cHP = collision.gameObject.GetComponent<PlayerCollsion>().Hp;
        //    Debug.Log("Collision HP : " + cHP);
        //}
        Debug.Log("NAME ENTER : " + collision.gameObject.name);   //�浹ü�� ������Ʈ �̸��� �����´�.
        //Debug.Log("TAG : " + collision.gameObject.tag);   //�浹ü�� ������Ʈ Tag�� �����´�.
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("NAME STAY : " + collision.gameObject.name);   //�浹ü�� ������Ʈ �̸��� �����´�.
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("NAME EXIT : " + collision.gameObject.name);   //�浹ü�� ������Ʈ �̸��� �����´�.
    }
}
