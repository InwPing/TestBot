using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class MoveToward : Action
{
    public float speed = 0;
    public SharedTransform target;

    public override TaskStatus OnUpdate()
    {
        if (Vector3.SqrMagnitude(transform.position + target.Value.position) < 0.1f)
        {
            return TaskStatus.Success;
        }
        transform.position = Vector3.MoveTowards(transform.position, target.Value.position, speed * Time.deltaTime);
        transform.LookAt(target.Value);
        return TaskStatus.Running;
    }

}
