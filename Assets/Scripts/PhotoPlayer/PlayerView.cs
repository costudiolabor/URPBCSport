using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : View {
    [SerializeField] private Animator animator;
    //private const string kickBall = "KickBall";
    private const string posX = "PosX";
    private const string posY = "PosY";
    
    public void Idle() {
        //SetAnimator(kickBall, false);
        SetAnimator(posX, 0);
        SetAnimator(posY, 1);
    }

    public void KickBall() {
        //SetAnimator(kickBall, true);
        SetAnimator(posX, 1);
        SetAnimator(posY, 1);
    }

    public void LegOnBall() {
        //Debug.Log("LegOnBall anim ");
        SetAnimator(posX, 0);
        SetAnimator(posY, 0);
    }

    public void FingerInUp() {
        //Debug.Log("FingerInUp anim ");
        SetAnimator(posX, 1);
        SetAnimator(posY, 0);
    }

    private void SetAnimator(string param, float value) {
        //animator.SetBool(param, value);
        animator.SetFloat(param, value);
    }
}
