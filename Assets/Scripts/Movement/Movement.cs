using System;
using UnityEngine;

[Serializable]
public class Movement
{
    public string name;
    public string type;
    public string target = "self";
    public float speed;
    public float orbitDistance;
    public float startSpeed;
    public PositionData orbitStartTranslation;
    public float wanderRange;
    public float minChangeThreshold;
    public float maxChangeThreshold;

    private Vector3 targetPos;
    private Vector3 wanderTarget;
    private bool atTarget = true;

    public Movement(string name, string type, string target, float speed, float orbitDistance, float startSpeed, PositionData orbitStartTranslation, float wanderRange, float minChangeThreshold, float maxChangeThreshold)
    {
        this.name = name;
        this.type = type;
        this.target = target;
        this.speed = speed;
        this.orbitDistance = orbitDistance;
        this.startSpeed = startSpeed;
        this.orbitStartTranslation = orbitStartTranslation;
        this.wanderRange = wanderRange;
        this.minChangeThreshold = minChangeThreshold;
        this.maxChangeThreshold = maxChangeThreshold;
    }

    public static Movement Override(Movement one, Movement two)
    {
        return new Movement(
            two.name == null ? one.name : two.name,
            two.type == null ? one.type : two.type,
            two.target == null ? one.target : two.target,
            two.speed == 0 ? one.speed : two.speed,
            two.orbitDistance == 0 ? one.orbitDistance : two.orbitDistance,
            two.startSpeed == 0 ? one.startSpeed : two.startSpeed,
            two.orbitStartTranslation == null ? one.orbitStartTranslation : PositionData.Override(one.orbitStartTranslation, two.orbitStartTranslation),
            two.wanderRange == 0 ? one.wanderRange : two.wanderRange,
            two.minChangeThreshold == 0 ? one.minChangeThreshold : two.minChangeThreshold,
            two.maxChangeThreshold == 0 ? one.maxChangeThreshold : two.maxChangeThreshold
        );
    }

    public void Start(Enemy enemy, Character character)
    {
        targetPos = enemy.GetPosition();
        if (target.Equals("origin")) targetPos = enemy.GetOrigin();
        else if (target.Equals("player")) targetPos = character.transform.position;
        else if (target.Equals("mouse")) targetPos = MouseUtil.GetMouseWorldPos();
    }

    public void Run(Entity entity, Character character)
    {
        switch (EnumUtil.Parse<MovementType>(type))
        {
            case MovementType.Wander:
                RunWander(entity, targetPos);
                return;
            case MovementType.Orbit:
                RunOrbit(entity, targetPos);
                return;
            case MovementType.Follow:
                RunFollow(entity, character);
                return;
        }
    }

    void RunWander(Entity entity, Vector3 center)
    {
        if (atTarget)
        {
            wanderTarget = VectorUtil.GetRandomPosition(new Vector3(center.x - wanderRange, center.y - wanderRange), new Vector3(center.x + wanderRange, center.y + wanderRange));
            atTarget = false;
        }
        else
        {
            if (Vector3.Distance(entity.transform.position, wanderTarget) >= UnityEngine.Random.Range(minChangeThreshold, maxChangeThreshold))
            {
                entity.transform.position = Vector3.MoveTowards(entity.transform.position, wanderTarget, speed * Time.deltaTime);
            }
            else atTarget = true;
        }
    }

    void RunOrbit(Entity entity, Vector3 center)
    {
        if (Vector3.Distance(entity.transform.position, orbitStartTranslation.GetAsVector3() * orbitDistance) >= orbitDistance)
        {
            entity.transform.position = Vector3.MoveTowards(entity.transform.position, orbitStartTranslation.GetAsVector3() * orbitDistance, startSpeed * Time.deltaTime);
        }
        //else entity.transform.RotateAround(center, -Vector3.forward, speed * Time.deltaTime);
    }

    void RunFollow(Entity entity, Character target)
    {
        if (Vector3.Distance(entity.transform.position, target.transform.position) >= UnityEngine.Random.Range(minChangeThreshold, maxChangeThreshold))
        {
            entity.transform.position = Vector3.MoveTowards(entity.transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }
}
