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

    private Vector3 center;

    public Movement(string name, string type, string target, float speed, float orbitDistance, float startSpeed, PositionData orbitStartTranslation)
    {
        this.name = name;
        this.type = type;
        this.target = target;
        this.speed = speed;
        this.orbitDistance = orbitDistance;
        this.startSpeed = startSpeed;
        this.orbitStartTranslation = orbitStartTranslation;
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
            two.orbitStartTranslation == null ? one.orbitStartTranslation : PositionData.Override(one.orbitStartTranslation, two.orbitStartTranslation)
        );
    }

    public void Start(Enemy enemy, Character character)
    {
        center = enemy.GetPosition();
        if (target.Equals("origin")) center = enemy.GetOrigin();
        if (target.Equals("player")) center = character.transform.position;
        if (target.Equals("mouse")) center = MouseUtil.GetMouseWorldPos();
    }

    public void Run(Entity entity, Character character)
    {
        switch (EnumUtil.Parse<MovementType>(type))
        {
            case MovementType.Wander:
                RunWander(entity, center);
                return;
            case MovementType.Orbit:
                RunOrbit(entity, center);
                return;
        }
    }

    void RunWander(Entity entity, Vector3 center)
    {
        switch (target)
        {
            case "self":
                return;
            case "player":
                return;
            case "origin":
                return;
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
}
