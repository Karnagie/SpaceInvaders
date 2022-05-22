using Extensions;
using PickUpEssence;
using UnityEngine;

namespace AliveObjects.EnemyEssence
{
    public class EnemyDrop : MonoBehaviour
    {
        [SerializeField]
        [Range(0,1)] private float _dropChance;
        [SerializeField] private BulletPickUp[] _drop;

        public BulletPickUp Drop(Transform parent, Vector3 position)
        {
            if(Random.Range(0f, 1f) > _dropChance) return null;
            return Instantiate(_drop.Random(), position, Quaternion.identity, parent);
        }
    }
}