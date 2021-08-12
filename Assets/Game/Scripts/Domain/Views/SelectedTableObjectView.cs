using Assets.Game.Scripts.Domain.Components;
using Assets.Game.Scripts.Domain.Contexts;
using System;
using UniRx;
using UnityEngine;

namespace Assets.Game.Scripts.Domain.Views
{
    public class SelectedTableObjectView : MonoBehaviour, IDisposable
    {
#pragma warning disable 0649
        [SerializeField] private Color _selectedColor;
#pragma warning restore 0649

        private TableObject _prevObject;
        private CompositeDisposable _disposables = new CompositeDisposable();

        private int _colorProperty;

        public void Attach(GameContext gameContext)
        {
            _colorProperty = Shader.PropertyToID("_Color");

            gameContext.SelectedObject.ObserveEveryValueChanged(x => x.Value)
                                    .Subscribe(OnObjChanged)
                                    .AddTo(_disposables);
        }

        private void OnObjChanged(TableObject obj)
        {
            if (_prevObject != null)
            {
                SetColor(_prevObject, Color.white);
            }

            _prevObject = obj;

            if (obj != null)
            {
                SetColor(obj, _selectedColor);
            }
        }

        private void SetColor(TableObject obj, Color color)
        {
            obj.MeshRenderer.material.SetColor(_colorProperty, color);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
