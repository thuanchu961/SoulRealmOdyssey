﻿using UnityEngine;

public class Minotaur_Attack : StateMachineBehaviour {   
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        SoundManager.Instant.PlaySound(Constant.SFX.Minotaur);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.SetBool("Attacking", false);
    }
}
