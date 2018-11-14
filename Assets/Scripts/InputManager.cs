using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    public PlayerController pc1;
    public PlayerController pc2;
    public PlayerController pc3;
	// Update is called once per frame
	void FixedUpdate () {
        //movement for player 1
        if (pc1 != null) {
            Vector3 P1Movement = Vector3.zero;
            if (Input.GetAxis("L_YAxis_1") > 0.0f) P1Movement.z = 1f;
            if (Input.GetAxis("L_YAxis_1") < 0.0f) P1Movement.z = -1f;
            if (Input.GetAxis("L_XAxis_1") > 0.0f) P1Movement.x = 1f;
            if (Input.GetAxis("L_XAxis_1") < 0.0f) P1Movement.x = -1f;
            Vector3 aimDirection = new Vector3(Input.GetAxis("R_XAxis_1"), 0, -Input.GetAxis("R_YAxis_1"));
            if (aimDirection != Vector3.zero)
            {
                pc1.RotateSelf(aimDirection);
            }

            pc1.MoveSelf(P1Movement);
            if (Input.GetButton("LB_1")) { pc1.ButtonDown(); } else { pc1.ButtonUp(); }
        }

        //movement for player 2
        if (pc2 != null) {
            Vector3 P2Movement = Vector3.zero;
            if (Input.GetAxis("L_YAxis_2") > 0.0f) P2Movement.z = 1f;
            if (Input.GetAxis("L_YAxis_2") < 0.0f) P2Movement.z = -1f;
            if (Input.GetAxis("L_XAxis_2") > 0.0f) P2Movement.x = 1f;
            if (Input.GetAxis("L_XAxis_2") < 0.0f) P2Movement.x = -1f;
            pc2.MoveSelf(P2Movement);
            if (Input.GetButton("LB_2")) { pc2.ButtonDown(); } else { pc2.ButtonUp(); }
            Vector3 aimDirection2 = new Vector3(Input.GetAxis("R_XAxis_2"), 0, -Input.GetAxis("R_YAxis_2"));
            if (aimDirection2 != Vector3.zero)
            {
                pc2.RotateSelf(aimDirection2);
            }
            pc2.MoveSelf(P2Movement);
        }

        //movement for player 3
        if (pc3 != null) {
            Vector3 P3Movement = Vector3.zero;
            if (Input.GetAxis("L_YAxis_3") > 0.0f) P3Movement.z = 1f;
            if (Input.GetAxis("L_YAxis_3") < 0.0f) P3Movement.z = -1f;
            if (Input.GetAxis("L_XAxis_3") > 0.0f) P3Movement.x = 1f;
            if (Input.GetAxis("L_XAxis_3") < 0.0f) P3Movement.x = -1f;
            pc3.MoveSelf(P3Movement);
            if (Input.GetButton("LB_3")) { pc3.ButtonDown(); } else { pc3.ButtonUp(); }
            Vector3 aimDirection3 = new Vector3(Input.GetAxis("R_XAxis_3"), 0, -Input.GetAxis("R_YAxis_3"));
            if (aimDirection3 != Vector3.zero)
            {
                pc3.RotateSelf(aimDirection3);
            }
            pc3.MoveSelf(P3Movement);
        }
    }
}
