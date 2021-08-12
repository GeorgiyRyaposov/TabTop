using Assets.Game.Scripts.Core.Tools;
using Assets.Game.Scripts.Domain.Components;
using Assets.Game.Scripts.Domain.Contexts;
using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Scripts.Domain.Views
{
    public class InteractionToolView : MonoBehaviour, IDisposable
    {
#pragma warning disable 0649
        [SerializeField] private Transform _buttonsRoot;
        [SerializeField] private Button _buttonPrefab;
#pragma warning restore 0649

        private CompositeDisposable _disposables = new CompositeDisposable();

        public void Attach(GameContext gameContext)
        {
            gameContext.SelectedObject.ObserveEveryValueChanged(x => x.Value)
                                    .Where(x => x != null)
                                    .Subscribe(OnObjChanged)
                                    .AddTo(_disposables);
        }

        private void OnObjChanged(TableObject obj)
        {
            ClearButtons();

            foreach (var tool in obj.InteractionTools)
            {
                AddButton(obj, tool);
            }
        }

        private void AddButton(TableObject obj, InteractionTool tool)
        {
            foreach (var buttonModel in tool.GetButtons())
            {
                var button = Instantiate(_buttonPrefab, _buttonsRoot);
                button.onClick.AddListener(() => buttonModel.OnClick(obj));
                button.GetComponentInChildren<TMP_Text>().text = buttonModel.Name;
            }
        }

        private void ClearButtons()
        {
            for (int i = _buttonsRoot.childCount-1; i >= 0; i--)
            {
                var child = _buttonsRoot.GetChild(i);
                Destroy(child.gameObject);
            }
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
