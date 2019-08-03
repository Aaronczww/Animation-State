﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIK : MonoBehaviour {

    protected Animator avatar;

    public bool ikActive = false;
    public Transform bodyObj = null;
    public Transform leftFootObj = null;
    public Transform rightFootObj = null;
    public Transform leftHandObj = null;
    public Transform rightHandObj = null;
    public Transform lookAtObj = null;


    public float leftFootWeightPosition = 1;
    public float leftFootWeightRotation = 1;

    public float rightFootWeightPosition = 1;
    public float rightFootWeightRotation = 1;

    public float leftHandWeightPosition = 1;
    public float leftHandWeightRotation = 1;

    public float rightHandWeightPosition = 1;
    public float rightHandWeightRotation = 1;

    public float lookAtWeight = 1.0f;


    void Start () {
        avatar = GetComponent<Animator>();
        ikActive = GetComponent<PlayerController>().ikActive;
	}

    void OnAnimatorIK(int layerIndex)
    { 
        if(avatar)
        {
            if(ikActive)
            {

                Debug.LogWarning("开启IK动画");

                avatar.SetIKPositionWeight(AvatarIKGoal.LeftFoot, leftFootWeightPosition);
                avatar.SetIKRotationWeight(AvatarIKGoal.LeftFoot, leftFootWeightRotation);

                avatar.SetIKPositionWeight(AvatarIKGoal.RightFoot, rightFootWeightPosition);
                avatar.SetIKRotationWeight(AvatarIKGoal.RightFoot, rightFootWeightRotation);

                avatar.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHandWeightPosition);
                avatar.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftHandWeightRotation);

                avatar.SetIKPositionWeight(AvatarIKGoal.RightHand, rightHandWeightPosition);
                avatar.SetIKRotationWeight(AvatarIKGoal.RightHand, rightHandWeightRotation);

                avatar.SetLookAtWeight(lookAtWeight, 0.3f, 0.6f, 1.0f, 0.5f);

                if (bodyObj != null)
                {
                    avatar.bodyPosition = bodyObj.position;
                    avatar.bodyRotation = bodyObj.rotation;
                }

                if (leftFootObj != null)
                {
                    avatar.SetIKPosition(AvatarIKGoal.LeftFoot, leftFootObj.position);
                    avatar.SetIKRotation(AvatarIKGoal.LeftFoot, leftFootObj.rotation);
                }

                if (rightFootObj != null)
                {
                    avatar.SetIKPosition(AvatarIKGoal.RightFoot, rightFootObj.position);
                    avatar.SetIKRotation(AvatarIKGoal.RightFoot, rightFootObj.rotation);
                }

                if (leftHandObj != null)
                {
                    avatar.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.position);
                    avatar.SetIKRotation(AvatarIKGoal.LeftHand, leftHandObj.rotation);
                }

                if (rightHandObj != null)
                {
                    avatar.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                    avatar.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
                }

                if (lookAtObj != null)
                {
                    avatar.SetLookAtPosition(lookAtObj.position);
                }
            }
            else
            {
                avatar.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0);
                avatar.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 0);

                avatar.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0);
                avatar.SetIKRotationWeight(AvatarIKGoal.RightFoot, 0);

                avatar.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                avatar.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);

                avatar.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                avatar.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);

                avatar.SetLookAtWeight(0.0f);

                if (bodyObj != null)
                {
                    bodyObj.position = avatar.bodyPosition;
                    bodyObj.rotation = avatar.bodyRotation;
                }

                if (leftFootObj != null)
                {
                    leftFootObj.position = avatar.GetIKPosition(AvatarIKGoal.LeftFoot);
                    leftFootObj.rotation = avatar.GetIKRotation(AvatarIKGoal.LeftFoot);
                }

                if (rightFootObj != null)
                {
                    rightFootObj.position = avatar.GetIKPosition(AvatarIKGoal.RightFoot);
                    rightFootObj.rotation = avatar.GetIKRotation(AvatarIKGoal.RightFoot);
                }

                if (leftHandObj != null)
                {
                    leftHandObj.position = avatar.GetIKPosition(AvatarIKGoal.LeftHand);
                    leftHandObj.rotation = avatar.GetIKRotation(AvatarIKGoal.LeftHand);
                }

                if (rightHandObj != null)
                {
                    rightHandObj.position = avatar.GetIKPosition(AvatarIKGoal.RightHand);
                    rightHandObj.rotation = avatar.GetIKRotation(AvatarIKGoal.RightHand);
                }


                if (lookAtObj != null)
                {
                    lookAtObj.position = avatar.bodyPosition + avatar.bodyRotation * new Vector3(0, 0.5f, 1);
                }
            }
        }
    }
}