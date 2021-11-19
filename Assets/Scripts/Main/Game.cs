using UnityEngine;

public class Game : MonoBehaviour
{
    public static GameSettings settings;
    public StatusEffectBuilder statusEffectBuilder = new StatusEffectBuilder();
    public AttackBuilder attackBuilder = new AttackBuilder();
    public ItemBuilder itemBuilder = new ItemBuilder();
    public TransitionBuilder transitionBuilder = new TransitionBuilder();
    public MovementBuilder movementBuilder = new MovementBuilder();
    public PhaseBuilder phaseBuilder = new PhaseBuilder();
    public EnemyBuilder enemyBuilder = new EnemyBuilder();

    void Awake()
    {
        settings = new GameSettings();
        statusEffectBuilder.readAndStoreData();
        attackBuilder.readAndStoreData();
        itemBuilder.readAndStoreData();
        transitionBuilder.readAndStoreData();
        movementBuilder.readAndStoreData();
        phaseBuilder.readAndStoreData();
        enemyBuilder.readAndStoreData();
    }
}
