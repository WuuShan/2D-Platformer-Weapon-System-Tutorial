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
        /// 玩家攻击动画机
        /// </summary>
        private Animator anim;
        /// <summary>
        /// 用于显示玩家攻击动画的物体
        /// </summary>
        private GameObject baseGameObject;

        /// <summary>
        /// 使用武器时，执行一次
        /// </summary>
        public void Enter()
        {
            print($"{transform.name} enter");

            anim.SetBool("active", true);
        }

        private void Awake()
        {
            baseGameObject = transform.Find("Base").gameObject;
            anim = baseGameObject.GetComponent<Animator>();
        }
    }
}

