using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMove : MonoBehaviour
{
    [Header("딜레이 / 이동")]
    public int delay; //이동에 대한 딜레이 시간
    public int time;  //이동에 대한 시간
    #region 비공개정보
    float X; //x축에 대한 이동 속도
    float Y; //y축에 대한 이동 속도
    public bool isMoving; //코루틴용
    public bool isWalking; // 애니메이션 조건
    #endregion
    #region ComponentSetting
    GameObject lt;
    GameObject rb;
    public SpriteRenderer spriteRenderer;
    Animator animator;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        lt = GameObject.Find("lt").gameObject;
        rb = GameObject.Find("rb").gameObject;
        isWalking = false;
        isMoving = false;
    }

    private void FixedUpdate()
    {
        if (!isMoving)
            StartCoroutine(Moving());
        else if (isWalking)
            Move();
        MoveBanned();
        #region 이동범위처리
        //X, Y 좌표 설정
        float posX = transform.position.x;
        float posY = transform.position.y;

        //지정해놓은 위치의 X 좌표 범위를 벗어날 경우 X 이동 변경
        if (posX < lt.transform.position.x || posX > rb.transform.position.x)
            X = -X;
        //지정해놓은 위치의 Y 좌표 범위를 벗어날 경우 X 이동 변경
        if (posY < lt.transform.position.y || posY > rb.transform.position.y)
            Y = -Y;
        #endregion
    }

    public void Move()
    {
        if (X != 0)
            spriteRenderer.flipX = X < 0; //X축 기준으로 Sprite의 x를 flip(뒤짚기)합니다.
                                          //flip은 bool 타입이기에 공식에 대한 초기화가 가능하다.

        transform.Translate(X, Y, 0);
    }

    IEnumerator Moving()
    {
        //이동과 딜레이 값을 적당히 설계합니다.

        //X와 Y에 대한 값 설정
        X = Random.Range(-1.5f, 1.5f) * Time.deltaTime;
        Y = Random.Range(-1f, 1f) * Time.deltaTime;

        //특정 좌표에 도달할 시 위치 변경



        isMoving = true; //무빙 활성화
        yield return new WaitForSeconds(delay);//딜레이만큼 탈출

        isWalking = true;//모션 활성화
        animator.SetBool("isWalk", true); //이동 애니메이션 작동

        yield return new WaitForSeconds(time); //움직임 시간만큼 탈출
        //바깥의 Move가 실행됨.

        isWalking = false;//모션 비활성화
        animator.SetBool("isWalk", false); //이동 애니메이션 종료

        isMoving = false;//무빙 비활성화
    }

    public void MoveBanned()
    {
        if (gameObject.transform.position.x <= -8.4f)
            gameObject.transform.position = new Vector3(-8.4f, gameObject.transform.position.y, gameObject.transform.position.z);
        else if (gameObject.transform.position.x >= 8.4f)
            gameObject.transform.position = new Vector3(8.4f, gameObject.transform.position.y, gameObject.transform.position.z);
        else if (gameObject.transform.position.y <= -2.5f)
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -2.5f, gameObject.transform.position.z);
        else if (gameObject.transform.position.y >= 2.5f) 
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 2.5f, gameObject.transform.position.z);
    }
}
