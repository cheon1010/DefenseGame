using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMove : MonoBehaviour
{
    [Header("������ / �̵�")]
    public int delay; //�̵��� ���� ������ �ð�
    public int time;  //�̵��� ���� �ð�
    #region ���������
    float X; //x�࿡ ���� �̵� �ӵ�
    float Y; //y�࿡ ���� �̵� �ӵ�
    public bool isMoving; //�ڷ�ƾ��
    public bool isWalking; // �ִϸ��̼� ����
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
        #region �̵�����ó��
        //X, Y ��ǥ ����
        float posX = transform.position.x;
        float posY = transform.position.y;

        //�����س��� ��ġ�� X ��ǥ ������ ��� ��� X �̵� ����
        if (posX < lt.transform.position.x || posX > rb.transform.position.x)
            X = -X;
        //�����س��� ��ġ�� Y ��ǥ ������ ��� ��� X �̵� ����
        if (posY < lt.transform.position.y || posY > rb.transform.position.y)
            Y = -Y;
        #endregion
    }

    public void Move()
    {
        if (X != 0)
            spriteRenderer.flipX = X < 0; //X�� �������� Sprite�� x�� flip(��¤��)�մϴ�.
                                          //flip�� bool Ÿ���̱⿡ ���Ŀ� ���� �ʱ�ȭ�� �����ϴ�.

        transform.Translate(X, Y, 0);
    }

    IEnumerator Moving()
    {
        //�̵��� ������ ���� ������ �����մϴ�.

        //X�� Y�� ���� �� ����
        X = Random.Range(-1.5f, 1.5f) * Time.deltaTime;
        Y = Random.Range(-1f, 1f) * Time.deltaTime;

        //Ư�� ��ǥ�� ������ �� ��ġ ����



        isMoving = true; //���� Ȱ��ȭ
        yield return new WaitForSeconds(delay);//�����̸�ŭ Ż��

        isWalking = true;//��� Ȱ��ȭ
        animator.SetBool("isWalk", true); //�̵� �ִϸ��̼� �۵�

        yield return new WaitForSeconds(time); //������ �ð���ŭ Ż��
        //�ٱ��� Move�� �����.

        isWalking = false;//��� ��Ȱ��ȭ
        animator.SetBool("isWalk", false); //�̵� �ִϸ��̼� ����

        isMoving = false;//���� ��Ȱ��ȭ
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
