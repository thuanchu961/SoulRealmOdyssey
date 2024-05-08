using UnityEngine;

public class CameraMovement : MonoBehaviour {
    private GameObject player;
    private Vector3 playerPosition;

    void Start() {
        player = GameObject.Find("Player");
    }

    void LateUpdate() {
        playerPosition = player.transform.position;
        playerPosition.z = -10;
        transform.position = playerPosition;
    }
}
