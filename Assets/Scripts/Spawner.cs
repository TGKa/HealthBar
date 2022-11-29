using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _spawner;
    [SerializeField] private Bullet _healingBullet;
    [SerializeField] private Bullet _damageBullet;

    public void SpawnHealingBullet()
    {
        Spawn(_healingBullet);
    }

    public void SpawnDamageBullet()
    {
        Spawn(_damageBullet);
    }

    private void Spawn(Bullet bullet)
    {
        Instantiate(bullet, _spawner.position, Quaternion.identity);
    }
}
