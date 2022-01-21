using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    public GameObject photonObject;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = PhotonNetwork.Instantiate(
            photonObject.name,
            new Vector3(-35f, 5f, -250f),
            Quaternion.identity,
            0
        );

        CharacterController controller = player.GetComponent<CharacterController>();
        controller.enabled = true;
        // Camera camera = player.GetComponent<Ch>();
        // camera.enabled = true;

        // GameObject mainCamera = GameObject.FindWithTag("MainCamera");
		// mainCamera.GetComponent<Camera>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
