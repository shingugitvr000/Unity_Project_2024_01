using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;                      //DoTween�� ����ϱ����ؼ� �����´�. 

public class TweenTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //====================================================================================================
        // �⺻ ���
        //====================================================================================================

        //transform.DOMoveX(5, 2);      //X��  5���� 2�ʾȿ� �̵�
        //transform.DORotate(new Vector3(0, 0, 180), 2);      //������Ʈ�� Z���� �߽����� 180�� ȸ�� ��Ų��. 
        //transform.DOScale(new Vector3(2, 2, 2), 2);           //������Ʈ�� x,y,z ������ ���� 2�辿 Ȯ�� 

        //====================================================================================================
        // ������ ��� 
        //====================================================================================================

        //Sequence sequence = DOTween.Sequence();             //DoTween �������� ���� 

        //sequence.Append(transform.DOMoveX(5, 2));                           //Append �� ������� ���� �ϰ� ���ش�. 
        //sequence.Append(transform.DORotate(new Vector3(0, 0, 180), 2));
        //sequence.Append(transform.DOScale(new Vector3(2, 2, 2), 2));

        //====================================================================================================
        // �ɼ� ��� 
        //====================================================================================================

        //transform.DOMoveX(5, 2).SetEase(Ease.OutBounce);
        //transform.DOShakeRotation(2, new Vector3(0, 0, 120), 10, 90); //������Ʈ�� �̵��ϸ鼭 ���ÿ� ȸ���ϴ� ȿ���� ���� 

        //====================================================================================================
        // Ʈ���� �Ϸ� �Ǿ��� �� ó�� 
        //====================================================================================================

        transform.DOMoveX(5, 2).OnComplete(ObjectDone);
    }

    void ObjectDone()
    {
        Destroy(gameObject);
    }


}
