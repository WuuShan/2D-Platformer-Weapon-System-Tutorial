using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bardent.Weapons
{
    /// <summary>
    /// 武器
    /// </summary>
    public class Weapon : MonoBehaviour
    {
        /// <summary>
        /// 武器完成攻击事件
        /// </summary>
        public event Action OnExit;

        /// <summary>
        /// 玩家攻击动画机
        /// </summary>
        private Animator anim;
        /// <summary>
        /// 用于显示玩家攻击动画的物体
        /// </summary>
        private GameObject baseGameObject;

        /// <summary>
        /// 动画事件处理
        /// </summary>
        private AnimationEventHandler eventHandler;

        /// <summary>
        /// 使用武器攻击时，执行一次
        /// </summary>
        public void Enter()
        {
            print($"{transform.name} enter");

            anim.SetBool("active", true);
        }

        /// <summary>
        /// 广播武器完成攻击事件
        /// </summary>
        private void Exit()
        {
            anim.SetBool("active", false);

            OnExit?.Invoke();
        }

        private void Awake()
        {
            baseGameObject = transform.Find("Base").gameObject;
            anim = baseGameObject.GetComponent<Animator>();

            eventHandler = baseGameObject.GetComponent<AnimationEventHandler>();
        }

        private void OnEnable()
        {
            // 订阅事件
            eventHandler.OnFinish += Exit;    
        }

        private void OnDisable()
        {
            // 注销事件
            eventHandler.OnFinish -= Exit;
        }
    }
}

