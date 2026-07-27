using UnityEngine;
using ithappy.Animals_FREE;

namespace ithappy.Animals_FREE
{
    [RequireComponent(typeof(CreatureMover))]
    public class AnimalRoam : MonoBehaviour
    {
        private CreatureMover m_Mover;
        
        [Header("Roam Settings")]
        public float roamRadius = 10f;
        public float waitTimeMin = 1f;
        public float waitTimeMax = 4f;
        
        private Vector3 m_StartPos;
        private Vector3 m_TargetPos;
        private float m_WaitTimer;
        private bool m_IsWaiting;
        
        private void Awake()
        {
            m_Mover = GetComponent<CreatureMover>();
            m_StartPos = transform.position;
            PickNewTarget();
        }

        private void Update()
        {
            if (m_IsWaiting)
            {
                m_WaitTimer -= Time.deltaTime;
                if (m_WaitTimer <= 0f)
                {
                    m_IsWaiting = false;
                    PickNewTarget();
                }
                else
                {
                    // Stand still, look forward
                    m_Mover.SetInput(Vector2.zero, transform.position + transform.forward, false, false);
                }
            }
            else
            {
                // Calculate distance to target (ignoring height differences)
                Vector3 diff = m_TargetPos - transform.position;
                diff.y = 0;
                
                if (diff.magnitude < 0.5f)
                {
                    // We arrived at the target point
                    m_IsWaiting = true;
                    m_WaitTimer = Random.Range(waitTimeMin, waitTimeMax);
                }
                else
                {
                    // Move forward. The CreatureMover (in Space.Self) uses the target position 
                    // to determine which way is forward.
                    m_Mover.SetInput(new Vector2(0f, 1f), m_TargetPos, false, false);
                }
            }
        }
        
        private void PickNewTarget()
        {
            Vector2 randomCircle = Random.insideUnitCircle * roamRadius;
            m_TargetPos = m_StartPos + new Vector3(randomCircle.x, 0f, randomCircle.y);
        }
    }
}
