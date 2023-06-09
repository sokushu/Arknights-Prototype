using Assets.Scripts.Args;
using Assets.Scripts.Attributes;
using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Camera
{
    public class CameraController : MonoBehaviour
    {
        #region 公开字段
        /// <summary>
        /// 虚拟相机
        /// </summary>
        [Name("要控制的相机")]
        public CinemachineVirtualCamera VirtualCamera;

        /// <summary>
        /// 相机向左偏移的量
        /// </summary>
        [Name("向左偏移的量")]
        [Tooltip("相机向左面偏移的量")]
        public Vector3 Left;

        /// <summary>
        /// 向右偏移的量
        /// </summary>
        [Name("向右偏移的量")]
        [Tooltip("相机向右面偏移的量")]
        public Vector3 Right;

        /// <summary>
        /// 相机移动速度
        /// </summary>
        [Name("移动速度")]
        [Tooltip("相机的移动速度，不过超过一定值效果就不明显了")]
        public float Speed;
        #endregion

        #region 私有字段
        /// <summary>
        /// 中心位置
        /// </summary>
        private Vector3 __Center;

        /// <summary>
        /// 相机设置
        /// </summary>
        private CinemachineComposer __CinemachineComposer;

        /// <summary>
        /// 相机方向枚举
        /// </summary>
        private CameraTiltEnum __CameraTiltEnum;

        /// <summary>
        /// 正在执行的协程
        /// </summary>
        private Coroutine __RuningCoroutine;
        #endregion

        #region Unity消息
        private void Start()
        {
            __CinemachineComposer = VirtualCamera.GetCinemachineComponent<CinemachineComposer>();
            __Center = __CinemachineComposer.m_TrackedObjectOffset;

            // 相机居中，不要倾斜
            CameraTilt(CameraTiltEnum.Center);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                CameraTilt(CameraTiltEnum.Left);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                CameraTilt(CameraTiltEnum.Center);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                CameraTilt(CameraTiltEnum.Right);
            }
        }
        #endregion

        /// <summary>
        /// 相机倾斜
        /// </summary>
        /// <param name="cameraTiltEnum"></param>
        public void CameraTilt(CameraTiltEnum cameraTiltEnum)
        {
            // 停止正在执行的
            if (__RuningCoroutine != null)
                StopCoroutine(__RuningCoroutine);
            // 开一个新的
            __CameraTiltEnum = cameraTiltEnum;
            __RuningCoroutine = StartCoroutine(CameraTilt());
        }

        /// <summary>
        /// 执行相机倾斜的协程
        /// </summary>
        /// <returns></returns>
        private IEnumerator CameraTilt()
        {
            Vector3 targetPosition = Vector3.zero;
            switch (__CameraTiltEnum)
            {
                case CameraTiltEnum.Left:
                    targetPosition = Left;
                    break;
                case CameraTiltEnum.Center:
                    targetPosition = __Center;
                    break;
                case CameraTiltEnum.Right:
                    targetPosition = Right;
                    break;
            }
            while (__CinemachineComposer.m_TrackedObjectOffset != targetPosition)
            {
                // 计算当前位置到目标位置的插值
                Vector3 newPosition = Vector3.Lerp(__CinemachineComposer.m_TrackedObjectOffset, targetPosition, Speed * Time.deltaTime);

                // 更新物体位置
                __CinemachineComposer.m_TrackedObjectOffset = newPosition;
                yield return null;
            }
        }
    }
}
