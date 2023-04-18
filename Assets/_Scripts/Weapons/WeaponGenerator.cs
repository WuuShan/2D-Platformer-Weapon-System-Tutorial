using Bardent.Weapons.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Bardent.Weapons
{
    /// <summary>
    /// 负责添加、删除武器组件
    /// </summary>
    public class WeaponGenerator : MonoBehaviour
    {
        /// <summary>
        /// 要生成的武器
        /// </summary>
        [SerializeField] private Weapon weapon;
        /// <summary>
        /// 对应的武器数据
        /// </summary>
        [SerializeField] private WeaponDataSO data;

        /// <summary>
        /// 当前武器上的武器组件列表
        /// </summary>
        private List<WeaponComponent> componentAlreadyOnWeapon = new List<WeaponComponent>();

        /// <summary>
        /// 已经添加到武器的武器组件列表
        /// </summary>
        private List<WeaponComponent> componentsAddedToWeapon = new List<WeaponComponent>();

        /// <summary>
        /// 武器组件的依赖项
        /// </summary>
        private List<Type> componentDependencies = new List<Type>();

        /// <summary>
        /// 动画器
        /// </summary>
        private Animator anim;

        private void Start()
        {
            anim = GetComponentInChildren<Animator>();
            GenerateWeapon(data);
        }

        [ContextMenu("Test Generate")]
        private void TestGeneration()
        {
            GenerateWeapon(data);
        }

        /// <summary>
        /// 根据武器数据生成武器的各种组件
        /// </summary>
        /// <param name="data">数据</param>
        public void GenerateWeapon(WeaponDataSO data)
        {
            weapon.SetData(data);

            componentAlreadyOnWeapon.Clear();
            componentsAddedToWeapon.Clear();
            componentDependencies.Clear();

            componentAlreadyOnWeapon = GetComponents<WeaponComponent>().ToList();

            componentDependencies = data.GetAllDependencies();

            foreach (var dependency in componentDependencies)
            {
                if (componentsAddedToWeapon.FirstOrDefault(component => component.GetType() == dependency)) continue;

                var weaponComponent = componentAlreadyOnWeapon.FirstOrDefault(component => component.GetType() == dependency);

                if (weaponComponent == null)
                {
                    weaponComponent = gameObject.AddComponent(dependency) as WeaponComponent;
                }

                weaponComponent.Init();

                componentsAddedToWeapon.Add(weaponComponent);
            }

            var componentsToRemove = componentAlreadyOnWeapon.Except(componentsAddedToWeapon);

            foreach (var weaponComponent in componentsToRemove)
            {
                Destroy(weaponComponent);
            }

            anim.runtimeAnimatorController = data.AnimatorController;
        }
    }
}