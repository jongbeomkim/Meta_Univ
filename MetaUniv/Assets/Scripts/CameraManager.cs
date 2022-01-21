using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    float mouseSpeed = 10;
    float mouseY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseY += Input.GetAxis("Mouse Y") * mouseSpeed; // 마우스 상하
        
        // 회전 값에 제한을 두지 않으면 카메라가 360도 이상 회전할 수 있음
        // Mathf.Clamp(변수, 최대 값, 최소 값)
        // mouseY = Mathf.Clamp(mouseY, -55.0f, 55.0f);
        mouseY = Mathf.Clamp(mouseY, -15.0f, 20.0f);

        // 로컬 회전 값 조정
        // mouseY += 를 할 때 무조건 값이 +가 나오기 때문에 -mouseY를 넣어야 위아래가 정상적으로 작동
        transform.localEulerAngles = new Vector3(-mouseY, 0, 0);
    }
}
