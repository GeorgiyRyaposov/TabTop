using Assets.Game.Scripts.Core.Tools;
using Assets.Game.Scripts.Domain.Components;
using UnityEngine;

namespace Assets.Game.Scripts.Domain.Tools
{
    [CreateAssetMenu(fileName = "InstallMeshTool", menuName = "Tools/InstallMeshTool")]
    public class InstallMeshTool : InstallObjectTool
    {
#pragma warning disable 0649
        [SerializeField] private Mesh _mesh;
        [SerializeField] private Vector3 _rotation;
#pragma warning restore 0649

        public override void Install(TableObject tableObject)
        {
            tableObject.MeshFilter.mesh = _mesh;

            tableObject.Collider.size = _mesh.bounds.size;
            tableObject.Collider.center = _mesh.bounds.center;

            tableObject.Rigidbody.rotation = Quaternion.Euler(_rotation.x, _rotation.y, _rotation.z);
        }
    }
}