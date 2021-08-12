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
            var rotation = tableObject.MeshRenderer.transform.localRotation.eulerAngles + _rotation;
            tableObject.MeshRenderer.transform.DOLocalRotate(rotation, _duration).SetEase(Ease.InOutSine);
        }
    }
}
