using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]
    public class AgentFollowV2 : Action
    {
        [Tooltip("Tag for target objects")]
        public SharedString tag;
        [Tooltip("The speed of the agent")]
        public SharedFloat speed;
        [Tooltip("Search area")]
        public SharedFloat search;
        [Tooltip("Touched distance")]
        public SharedFloat touchedDist;



        private GameObject[] targetObjects;
        private Vector3 prevDir;



        public override void OnStart()
        {
            base.OnStart();

            targetObjects = GameObject.FindGameObjectsWithTag(tag.Value);
        }

        // Follow the target. The task will never return success as the agent should continue to follow the target even after arriving at the destination.
        public override TaskStatus OnUpdate()
        {
            GameObject closest = null;
            Vector3 closestVec = Vector3.zero;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject targetObject in targetObjects)
            {
                Vector3 diff = targetObject.transform.position - position;
                float curDistance = diff.sqrMagnitude;
               /* if (curDistance < touchedDist.Value)
                {
                    //Debug.Log("Success");

                    return TaskStatus.Success;
                }*/

                if (curDistance < distance)
                {
                    //Debug.Log("curDistance < distance");
                    closest = targetObject;
                    distance = curDistance;
                }

                
                Debug.Log(closest);

                if (diff.magnitude <= search.Value)
                {

                    closestVec += diff;
                    // Debug.Log("diff < search");
                }
            }
            //Vector3 closestVec = closest.transform.position; line 35
            

            Debug.Log(("out loop") + closest);

            closestVec.Normalize();

            closestVec = closestVec * speed.Value * Time.deltaTime;

            closestVec = Vector3.Lerp(prevDir, closestVec, 0.2f);

            transform.position += closestVec;

            prevDir = closestVec;



            return TaskStatus.Running;
        }

        public override void OnReset()
        {
            base.OnReset();

        }
    }
}