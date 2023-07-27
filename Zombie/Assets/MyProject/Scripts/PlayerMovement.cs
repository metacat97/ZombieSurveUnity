using UnityEngine;

// 플레이어 캐릭터를 사용자 입력에 따라 움직이는 스크립트
public class PlayerMovement : MonoBehaviour {
    public float moveSpeed = 5f; // 앞뒤 움직임의 속도
    public float rotateSpeed = 180f; // 좌우 회전 속도
   

    private PlayerInput playerInput; // 플레이어 입력을 알려주는 컴포넌트
    private Rigidbody playerRigidbody; // 플레이어 캐릭터의 리지드바디
    private Animator playerAnimator; // 플레이어 캐릭터의 애니메이터

    Camera characterCamera;
    private void Start() {
        // 사용할 컴포넌트들의 참조를 가져오기

        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // FixedUpdate는 물리 갱신 주기에 맞춰 실행됨
    private void FixedUpdate() {
        //회전 실행
        //Rotate();
        // 움직임 실행
        Move();
        MoveLR();
        // 입력값에 따라 애니메이터의 Move 파라미터값 변경
        playerAnimator.SetFloat("Move", playerInput.move);
        // 물리 갱신 주기마다 움직임, 회전, 애니메이션 처리 실행
    }

    private void Update()
    {
        ////LookMouseCursor();
        ////먼저 계산을 위해 마우스와 게임 오브젝트의 현재의 좌표를 임시로 저장합니다.
        //Vector3 mPosition = Input.mousePosition; //마우스 좌표 저장
        //Vector3 oPosition = transform.position; //게임 오브젝트 좌표 저장
        //Debug.Log(mPosition);


        ////카메라가 앞면에서 뒤로 보고 있기 때문에, 마우스 position의 z축 정보에 
        ////게임 오브젝트와 카메라와의 z축의 차이를 입력시켜줘야 합니다.
        //mPosition.y = oPosition.y - Camera.main.transform.position.y;
        //Debug.Log(mPosition.y);
        ////화면의 픽셀별로 변화되는 마우스의 좌표를 유니티의 좌표로 변화해 줘야 합니다.
        ////그래야, 위치를 찾아갈 수 있겠습니다.
        //Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);

        ////다음은 아크탄젠트(arctan, 역탄젠트)로 게임 오브젝트의 좌표와 마우스 포인트의 좌표를
        ////이용하여 각도를 구한 후, 오일러(Euler)회전 함수를 사용하여 게임 오브젝트를 회전시키기
        ////위해, 각 축의 거리차를 구한 후 오일러 회전함수에 적용시킵니다.

        ////우선 각 축의 거리를 계산하여, dy, dx에 저장해 둡니다.
        //float dy = target.y - oPosition.y;
        //float dx = target.x - oPosition.x;

        ////오릴러 회전 함수를 0에서 180 또는 0에서 -180의 각도를 입력 받는데 반하여
        ////(물론 270과 같은 값의 입력도 전혀 문제없습니다.) 아크탄젠트 Atan2()함수의 결과 값은 
        ////라디안 값(180도가 파이(3.141592654...)로)으로 출력되므로
        ////라디안 값을 각도로 변화하기 위해 Rad2Deg를 곱해주어야 각도가 됩니다.
        //float rotateDegree = Mathf.Atan2(dy, dx)*Mathf.Rad2Deg;

        ////구해진 각도를 오일러 회전 함수에 적용하여 z축을 기준으로 게임 오브젝트를 회전시킵니다.
        //transform.rotation = Quaternion.Euler(0f, rotateDegree, 0f );

        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Plane GroupPlane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;

        if (GroupPlane.Raycast(cameraRay, out rayLength))

        {

            Vector3 pointTolook = cameraRay.GetPoint(rayLength);

            transform.LookAt(new Vector3(pointTolook.x, transform.position.y, pointTolook.z));

        }

        //float Horizontal = Input.GetAxis("Horizontal");
        //Vector3 Position = transform.position;
        //Position.x = Horizontal * moveSpeed * Time.deltaTime;
        
        //transform.position = Position;
    }

    // 입력값에 따라 캐릭터를 앞뒤로 움직임
    private void Move() {
        // 상대적으로 이동할 거리 계산
        Vector3 moveDistance =
            playerInput.move * transform.forward * moveSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
    }

    private void MoveLR()
    {
        Vector3 moveDistance = playerInput.moveLR * transform.right * moveSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
       
        

    }

    // 입력값에 따라 캐릭터를 좌우로 회전
    private void Rotate() {
        //상대적으로 회전할 수치 계산
        float turn = playerInput.rotate * rotateSpeed * Time.deltaTime;
        //리지드 바디를 이용해 게임 오브젝트 회전 변경
        playerRigidbody.rotation =
            playerRigidbody.rotation * Quaternion.Euler(0, turn, 0.0f);

    }

    //public void LookMouseCursor() 
    //{
    //    Ray ray = characterCamera.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hitResult;
    //    if (Physics.Raycast(ray, out hitResult)) 
    //    {
    //        Vector3 mouseDir = new Vector3(hitResult.point.x, transform.position.y, hitResult.point.z) - transform.position;
    //        playerAnimator.transform.forward = mouseDir;
    //    }
    //}

}