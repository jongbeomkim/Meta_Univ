using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public CharacterController character;
    public Animator animator;
    public Rigidbody rb;

    float mouseX = 0;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMove();

        // 마우스 움직임에 따라 카메라 + 캐릭터를 회전시킨다.
        mouseX += Input.GetAxis("Mouse X") * 10; // 마우스 수평
        transform.eulerAngles = new Vector3(0, mouseX, 0); // 플레이어 회전 값 조정
    }

    void FixedUpdate() {
        // RigidBody를 다룰 때엔 매 프레임 마다 갱신되는 Update() 대신 고정된 프레임율로 갱신되는 FixedUpdate()를 사용해야 한다.
    }

    void playerMove() // 키 입력에 따라 플레이어를 이동시킨다.
    {
        float moveX = Input.GetAxis("Horizontal"); // 좌, 우
        float moveZ = Input.GetAxis("Vertical"); // 전, 후

        Vector3 move = new Vector3(moveX, 0, moveZ);
        Vector3 jump = new Vector3(0, 1, 0);

        animator.SetFloat("moveX", moveX);
        animator.SetFloat("moveZ", moveZ);

        // transform.TransformDirection() : 로컬 좌표 -> 월드 좌표 기준으로 변경
        // 이렇게 하면 마우스가 움직인 방향으로 캐릭터가 움직인다.
        // https://makerejoicegames.tistory.com/131
        character.Move(transform.TransformDirection(move) * Time.deltaTime * 10f);

        if (Input.GetButtonDown("Jump"))
        {
            // character.Move(transform.TransformDirection(jump) * Time.deltaTime * 8);
            // animator.Play("애니메이션", 레이어, 시간차);
            // animator.Play("JUMP00", -1, 0);
            animator.SetTrigger("Jump");
        }

        if (Input.GetButtonUp("Jump"))
        {
            animator.ResetTrigger("Jump");
        }
    }
}
