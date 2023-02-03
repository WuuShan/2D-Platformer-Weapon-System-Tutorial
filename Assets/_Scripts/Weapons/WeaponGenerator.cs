using Bardent.Weapons.Components;
using System;
using System.Collections;
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
        [SerializeField] private Weapon weapon;
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

        private void Start()
        {
            GenerateWeapon(data);
        }

        [ContextMenu("Test Generate")]
        private void TestGeneration()
        {
            GenerateWeapon(data);
        }

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
        }
    }
}
