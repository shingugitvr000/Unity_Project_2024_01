using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemController : MonoBehaviour
{
    public int amount = 10;                             //기본 값 설정
    Sequence sequence;
    public enum ITEMTYPE : int                          //enum 값으로 아이템 Type을 설정
    {
        HP_ITEM,
        EXP_ITEM
    }
    public ITEMTYPE itemtype = ITEMTYPE.HP_ITEM;        //기본적으로 HP 아이템으로 선언

    public void Start()
    {
        sequence = DOTween.Sequence();             //DoTween 시퀀스 생성
        sequence.Append(transform.DOMoveY(0.1f, 1));        //바닥면에서 0.1f 정도 위치로 이동
        sequence.Join(transform.DORotate(new Vector3(0, 180, 0), 1));   //시퀀스 추가 오브젝트가 180도 씩 Y축 기준으로 회전
        sequence.SetLoops(-1, LoopType.Yoyo);               //오브젝트가 있는동안 계속 시퀀스 수행
    }
    public void OnDestroy()
    {
        sequence.Kill();                            //게임 오브젝트가 없어지때문에 시퀀스 실행을 종료 시킴
    }
}
