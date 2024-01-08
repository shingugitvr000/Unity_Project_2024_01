using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public GameObject pivot;
    public Camera viewCamera;           //메인 카메라를 받아오는 Camera 오브젝트
    public Vector3 velocity;            //이동 값
    public Rigidbody body;              //물리 효과를 주는 강체 값을 가져온다. 
   
    void Start()
    {
        viewCamera = Camera.main;           //스트립트가 시작될때 카메라를 받아온다.
    }    
    void Update()
    {
        //방향키를 통해서 이동 벡터값을 생성한다. 
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * moveSpeed;

        //화면에서 -> 게임 3D 공간 좌표를 변환해서 Vector3에 넣는다. 
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, viewCamera.transform.position.y));

        //공간좌표가 캐릭터보다 위에 있을 경우 위를 처다 보기때문에 같은 y축 값을 맞춰준다. 
        Vector3 targetPosition = new Vector3(mousePos.x, pivot.transform.position.y,mousePos.z);

        //피봇이 해당 타겟을 바라보게 한다. 
        pivot.transform.LookAt(targetPosition, Vector3.up);
    }
    private void FixedUpdate()
    {
        body.MovePosition(body.position + velocity * Time.fixedDeltaTime);
    }
}
