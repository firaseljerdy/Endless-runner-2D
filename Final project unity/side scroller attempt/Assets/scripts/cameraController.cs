using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

    public playerController player;

    private Vector3 lastPlayerPos;

    private float distance2_move;

	// Use this for initialization
	void Start () {

        player = FindObjectOfType<playerController>();

        lastPlayerPos = player.transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        distance2_move = player.transform.position.x - lastPlayerPos.x;

        transform.position = new Vector3(transform.position.x + distance2_move, transform.position.y, transform.position.z);

        lastPlayerPos = player.transform.position;

    }
}
