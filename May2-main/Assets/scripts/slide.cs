﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slide : SceneLinkedSMB<Charactercontrolelr>
{

    int m_HashAirborneMeleeAttackState = Animator.StringToHash("slide");
    float timer;

    public override void OnSLStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        m_MonoBehaviour.skeletonAnimation.timeScale = 1.4f;
        //m_MonoBehaviour.skeletonAnimation.AnimationState.SetAnimation(0, "slide", false);
        m_MonoBehaviour.slideset();
        timer = 0f;

    }
    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


        timer += Time.deltaTime;
        //m_MonoBehaviour.GroundedHorizontalMovement(false);

        if (timer > 0.1f)            //攻撃ごとに設定
            m_MonoBehaviour.Locomotionchange();



        //  useeffect.isplaying();
    }

    public override void OnSLStatePreExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0f;
        m_MonoBehaviour.skeletonAnimation.timeScale = 1f;
        //  m_MonoBehaviour.DisableMeleeAttack();
        //m_MonoBehaviour.spineAnimation.AnimationState.SetAnimation(0, "nurt", true);


    }





}
