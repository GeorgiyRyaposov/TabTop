using Assets.Game.Scripts.Core.Tools;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Game.Scripts.Domain.Components
{
    public class TableObject : MonoBehaviour, IPoolable<Vector3, IMemoryPool>
    {
#pragma warning disable 0649
        [Header("Components")]
        [SerializeField] private Rigidbody _rigidBody;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private MeshFilter _meshFilter;
        [SerializeField] private BoxCollider _collider;
#pragma warning restore 0649

        public Rigidbody Rigidbody => _rigidBody;
        public MeshRenderer MeshRenderer => _meshRenderer;
        public MeshFilter MeshFilter => _meshFilter;
        public BoxCollider Collider => _collider;

        public readonly List<InteractionTool> InteractionTools = new List<InteractionTool>();

        private IMemoryPool _pool;

        public void Install(List<InstallObjectTool> installObjectTools)
        {
            for (int i = 0; i < installObjectTools.Count; i++)
            {
                installObjectTools[i].Install(this);
            }
        }

        public void OnDespawned()
        {
            _pool = null;
        }

        public void OnSpawned(Vector3 position, IMemoryPool pool)
        {
            _rigidBody.position = position;
            _pool = pool;
        }

        public class Factory : PlaceholderFactory<Vector3, TableObject>
        {
        }
    }
}