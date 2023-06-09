using Assets.Scripts.Attributes;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyGeneration : MonoBehaviour
    {

        #region 面向Unity面板的参数

        /// <summary>
        /// 生成的敌人数量
        /// </summary>
        [Name("生成敌人的数量")]
        public int GenerationCount;

        /// <summary>
        /// 是否随机生成敌人
        /// </summary>
        [Name("是否随机生成敌人")]
        public bool RandomGeneration;

        /// <summary>
        /// 敌人的模板
        /// </summary>
        [Name("敌人的模板")]
        public GameObject[] EnemyTypes;
        #endregion

        #region 私有字段
        /// <summary>
        /// 等待出击的敌人列表
        /// </summary>
        private readonly List<GameObject> __Enemys = new();
        #endregion

        #region Unity 消息
        private void Start()
        {
            // 复制敌人模板，生成敌人实例（敌人可以是：猫，狗，昆虫）
            System.Random random = new(Guid.NewGuid().GetHashCode());
            if (EnemyTypes.Length > 0)
                for (int i = 0; i < GenerationCount; i++)
                {
                    GameObject enemy;
                    int index = 0;
                    if (RandomGeneration)
                    {
                        index = random.Next(0, EnemyTypes.Length);
                        enemy = Instantiate(EnemyTypes[index]);
                    }
                    else
                    {
                        index++;
                        if (index >= EnemyTypes.Length)
                            index = 0;
                        enemy = Instantiate(EnemyTypes[index]);
                    }
                    __Enemys.Add(enemy);
                }
        }

        private void Update()
        {

        }
        #endregion
    }

}
