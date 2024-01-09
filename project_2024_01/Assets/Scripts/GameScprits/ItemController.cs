using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public int amount = 10;                             //기본 값 설정

    public enum ITEMTYPE : int                          //enum 값으로 아이템 Type을 설정
    {
        HP_ITEM,
        EXP_ITEM
    }

    public ITEMTYPE itemtype = ITEMTYPE.HP_ITEM;        //기본적으로 HP 아이템으로 선언
}
