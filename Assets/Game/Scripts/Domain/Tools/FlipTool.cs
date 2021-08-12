using Assets.Game.Scripts.Core.Tools;
using Assets.Game.Scripts.Domain.Components;
using Assets.Game.Scripts.Domain.Models;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Domain.Tools
{
    [CreateAssetMenu(fileName = "FlipTool", menuName = "Tools/Interaction/FlipTool")]
    public class FlipTool : InteractionTool
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
                    Name = "Flip",
                    OnClick = Flip
                }
            };
        }

        private void Flip(TableObject tableObject)
        {
            var originalY = tableObject.MeshRenderer.transform.position.y;
            var targetY = tableObject.Collider.center.y + GetMaxSize(tableObject.Collider.bounds);
            var targetRotation = tableObject.MeshRenderer.transform.localRotation.eulerAngles + _rotation;

            var seq = DOTween.Sequence();
            seq.Append(tableObject.MeshRenderer.transform.DOMoveY(targetY, _duration * 0.2f));
            seq.Append(tableObject.MeshRenderer.transform.DOLocalRotate(targetRotation, _duration * 0.6f).SetEase(Ease.InOutSine));
            seq.Append(tableObject.MeshRenderer.transform.DOMoveY(originalY, _duration * 0.2f));
        }

        private float GetMaxSize(Bounds bounds)
        {
            return Mathf.Max(bounds.size.x, bounds.size.y, bounds.size.z);
        }
    }
}
