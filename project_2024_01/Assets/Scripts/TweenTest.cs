using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;                      //DoTween을 사용하기위해서 가져온다. 

public class TweenTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //====================================================================================================
        // 기본 사용
        //====================================================================================================

        //transform.DOMoveX(5, 2);      //X가  5까지 2초안에 이동
        //transform.DORotate(new Vector3(0, 0, 180), 2);      //오브젝트가 Z축을 중심으로 180도 회전 시킨다. 
        //transform.DOScale(new Vector3(2, 2, 2), 2);           //오브젝트가 x,y,z 축으로 각각 2배씩 확대 

        //====================================================================================================
        // 시퀀스 사용 
        //====================================================================================================

        //Sequence sequence = DOTween.Sequence();             //DoTween 시퀀스를 선언 

        //sequence.Append(transform.DOMoveX(5, 2));                           //Append 는 순서대로 실행 하게 해준다. 
        //sequence.Append(transform.DORotate(new Vector3(0, 0, 180), 2));
        //sequence.Append(transform.DOScale(new Vector3(2, 2, 2), 2));

        //====================================================================================================
        // 옵션 사용 
        //====================================================================================================

        //transform.DOMoveX(5, 2).SetEase(Ease.OutBounce);
        //transform.DOShakeRotation(2, new Vector3(0, 0, 120), 10, 90); //오브젝트를 이동하면서 동시에 회전하는 효과를 적용 

        //====================================================================================================
        // 트윈이 완료 되었을 때 처리 
        //====================================================================================================

        transform.DOMoveX(5, 2).OnComplete(ObjectDone);
    }

    void ObjectDone()
    {
        Destroy(gameObject);
    }


}
