using Assets.Game.Scripts.Core.Tools;
using Assets.Game.Scripts.Domain.Components;
using Assets.Game.Scripts.Domain.Models;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Domain.Tools
{
    [CreateAssetMenu(fileName = "RotationTool", menuName = "Tools/Interaction/RotationTool")]
    public class RotationTool : InteractionTool
    {
#pragma warning disable 0649
        [SerializeField] private Vector3 _rotation;
        [SerializeField] private float _duration = 1f;
#pragma warning restore 0649

        public override List<ToolButtonModel> GetButtons()
        {
            return new List<ToolButtonModel>()
            {
                new ToolButtonModel()
                {
                    Name = "Rotate left",
                    OnClick = RotateLeft
                },
                new ToolButtonModel()
                {
                    Name = "Rotate right",
                    OnClick = RotateRight
                },
            };
        }

        private void RotateLeft(TableObject tableObject)
        {
            Rotate(tableObject, true);
        }
        private void RotateRight(TableObject tableObject)
        {
            Rotate(tableObject, false);
        }
        private void Rotate(TableObject tableObject, bool left)
        {
            var sign = left ? 1 : -1;
            var rotation = tableObject.MeshRenderer.transform.localRotation.eulerAngles + _rotation * sign;
            tableObject.MeshRenderer.transform.DOLocalRotate(rotation, _duration).SetEase(Ease.InOutSine);
        }
    }
}
