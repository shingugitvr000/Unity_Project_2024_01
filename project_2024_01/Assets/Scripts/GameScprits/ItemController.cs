using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemController : MonoBehaviour
{
    public int amount = 10;                             //�⺻ �� ����
    Sequence sequence;
    public enum ITEMTYPE : int                          //enum ������ ������ Type�� ����
    {
        HP_ITEM,
        EXP_ITEM
    }
    public ITEMTYPE itemtype = ITEMTYPE.HP_ITEM;        //�⺻������ HP ���������� ����

    public void Start()
    {
        sequence = DOTween.Sequence();             //DoTween ������ ����
        sequence.Append(transform.DOMoveY(0.1f, 1));        //�ٴڸ鿡�� 0.1f ���� ��ġ�� �̵�
        sequence.Join(transform.DORotate(new Vector3(0, 180, 0), 1));   //������ �߰� ������Ʈ�� 180�� �� Y�� �������� ȸ��
        sequence.SetLoops(-1, LoopType.Yoyo);               //������Ʈ�� �ִµ��� ��� ������ ����
    }
    public void OnDestroy()
    {
        sequence.Kill();                            //���� ������Ʈ�� ������������ ������ ������ ���� ��Ŵ
    }
}
