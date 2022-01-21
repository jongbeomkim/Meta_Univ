using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class LookCam : MonoBehaviourPunCallbacks
{
    public GameObject Camera;
    public TextMesh Text;

    // Start is called before the first frame update
    void Start()
    {
        // Text.text = PhotonView.Owner.NickName;
    }

    // Update is called once per frame
    void Update()
    {
        // text mesh가 카메라를 똑바로 보게 만든다.
        // https://itadventure.tistory.com/401
        transform.rotation = Camera.transform.rotation;
    }
}
