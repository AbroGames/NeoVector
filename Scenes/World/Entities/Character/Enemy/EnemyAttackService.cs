using Godot;
using KludgeBox;
using KludgeBox.Events;

namespace NeoVector.World;

[GameService]
public class EnemyAttackService
{
    
    [EventListener]
    public void OnEnemyProcessEvent(EnemyProcessEvent enemyProcessEvent)
    {
        var (enemy, delta) = enemyProcessEvent;
        
        enemy.SecToNextAttack -= delta;
        if (enemy.SecToNextAttack > 0) return;
        if (CanSeePlayer(enemy))
        {
            EventBus.Publish(new EnemyAttackEvent(enemy));
        }
    }
    
    [EventListener]
    public void OnEnemyAttackEvent(EnemyAttackEvent enemyAttackEvent)
    {
        Enemy enemy = enemyAttackEvent.Enemy;
        
        enemy.SecToNextAttack = 1.0 / enemy.AttackSpeed;
		
        // Создание снаряда
        Bullet bullet = Root.Instance.PackedScenes.World.Bullet.Instantiate() as Bullet;
        // Установка начальной позиции снаряда
        bullet.GlobalPosition = enemy.GlobalPosition;
        // Установка направления движения снаряда
        bullet.Rotation = enemy.Rotation;
        bullet.Author = Bullet.AuthorEnum.ENEMY;
        bullet.Source = enemy;
        bullet.RemainingDamage = enemy.Damage;
        if (enemy.Damage > 1000)
        {
            bullet.Transform = bullet.Transform.ScaledLocal(Vec(Mathf.Log(enemy.Damage/1000)));
        }
		
        Audio2D.PlaySoundAt(Sfx.SmallLaserShot, enemy.Position, 0.7f);
        enemy.GetParent().AddChild(bullet); //TODO refactor (и поискать все другие места, где используется GetParent().AddChild и просто GetParent
    }
    
    private bool CanSeePlayer(Enemy enemy)
    {
        var collider = enemy.RayCast.GetCollider();
        return collider is Player;
    }
    
}