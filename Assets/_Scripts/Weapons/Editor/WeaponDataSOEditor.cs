using Bardent.Weapons.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace Bardent.Weapons
{
    [CustomEditor(typeof(WeaponDataSO))]
    public class WeaponDataSOEditor : Editor
    {
        // 可添加到 WeaponDataSO 对象的 ComponentData 类型的列表
        private static List<Type> dataCompTypes = new List<Type>();

        private WeaponDataSO dataSO;

        private void OnEnable()
        {
            // 获取正在编辑的 WeaponDataSO 对象
            dataSO = target as WeaponDataSO;
        }

        public override void OnInspectorGUI()
        {
            // 为 WeaponDataSO 对象绘制默认的 Inspector 视图
            base.OnInspectorGUI();

            // 对 dataCompTypes 列表中的每个 ComponentData 类型，在 Inspector 视图中添加一个按钮
            foreach (var dataCompType in dataCompTypes)
            {
                if (GUILayout.Button(dataCompType.Name))
                {
                    // 创建 ComponentData 类型的实例
                    var comp = Activator.CreateInstance(dataCompType) as ComponentData;

                    if (comp == null) return;

                    // 将 ComponentData 添加到 WeaponDataSO 对象中
                    dataSO.AddData(comp);
                }
            }
        }

        // 当编辑器重新编译时调用此函数
        [DidReloadScripts]
        private static void OnRecompile()
        {
            // 获取当前应用程序域中的所有程序集
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            // 获取程序集中的所有类型
            var types = assemblies.SelectMany(assembly => assembly.GetTypes());

            // 筛选出所有 ComponentData 子类，并确保它们是类而不是通用参数
            var filteredTypes = types.Where(
                type => type.IsSubclassOf(typeof(ComponentData)) && !type.ContainsGenericParameters && type.IsClass
                );

            // 将筛选后的类型转换为 List 并将其赋值给 dataCompTypes 变量
            dataCompTypes = filteredTypes.ToList();
        }
    }
}