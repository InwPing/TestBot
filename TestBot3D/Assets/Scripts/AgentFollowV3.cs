using UnityEngine;
using System.Collections;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]
    public class AgentFollowV3 : Action
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
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag(tag.Value);
            GameObject closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject go in gos)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }                               
            }
            //Vector3 closestVec = closest.transform.position;
            Debug.Log(closest);
            //Debug.Log(closestVec);

            Vector3 dir = Vector3.zero;
            if (closest != null) 
            {
                Vector3 targetPos = closest.transform.position;
                Vector3 currentPos = transform.position;

                Vector3 toward = targetPos - currentPos;
                if (toward.magnitude < touchedDist.Value)
                {
                    
                    return TaskStatus.Success;
                }

                if (toward.magnitude < search.Value)
                {
                    dir += toward;
                }
            }
            /* Vector3 dir = Vector3.zero;
             Vector3 closestVec = closest.transform.position;

             foreach (Vector3 targetPos in closestVec)
             {

                 Vector3 targetPos = targetObject.transform.position;
                 Vector3 currentPos = transform.position;

                 Vector3 toward = targetPos - currentPos;
                 if (toward.magnitude < touchedDist.Value)
                 {
                     return TaskStatus.Success;
                 }

                 if (toward.magnitude < search.Value)
                 {
                     dir += toward;
                 }
             }*/
             dir.Normalize();

             dir = dir * speed.Value * Time.deltaTime;

             dir = Vector3.Lerp(prevDir, dir, 0.2f);

             transform.position += dir;

             prevDir = dir;


            return TaskStatus.Running;

        }

        public override void OnReset()
        {
            base.OnReset();

        }

        
    }
}