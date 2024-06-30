using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UIElements;

namespace UICoinFX
{
    [Serializable]
    public class MagnetData 
    {
        // ParticleSystem Pool
        public ObjectPoolBehaviour FXPool;

        //forcefield target
        public ParticleSystemForceField ForceField;
    }

    public class CoinMagnet : MonoBehaviour {
        [Header("UI Elements")]
        [Tooltip("UI 요소의 screen space position을 가져오기 위한 UI Document")]
        [SerializeField] UIDocument m_Document;
        [SerializeField] List<MagnetData> m_MagnetData;

        [Header("Camera")]
        [Tooltip("World Space Positions를 구하기 위해 Camera와 Depth를 사용")]
        [SerializeField] Camera m_Camera;
        [SerializeField] float m_ZDepth = 10f;
        [Tooltip("3D offset to the particle emission")]
        [SerializeField] Vector3 m_SourceOffset = new Vector3(0f, 0.1f, 0f);

        // start and end corrdinates for effect
        void OnEnable() {
            // 이벤트 + 메소드 연결 예정
        }

        void OnDisable() {
            // 이벤트 + 메소드 연결 예정
        }

        void PlayPooledFX(Vector2 screenPos) {
            Vector3 worldPos = screenPos.ScreenPosToWorldPos(m_Camera, m_ZDepth) + m_SourceOffset;
            
        }
    }
}
