using Assets.Game.Scripts.Domain.Components;
using Assets.Game.Scripts.Domain.Contexts;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Game.Scripts.Domain.Controllers
{
    public class GameInputController : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] private Camera _camera;
        [SerializeField] private float _forceAmount = 500;
#pragma warning restore 0649

        private bool _isDrag;

        private TableObject SelectedTableObject
        {
            get { return GameContext.Current.SelectedObject.Value; }
            set { GameContext.Current.SelectedObject.Value = value; }
        }

        private Vector3 _originalScreenTargetPosition;
        private Vector3 _originalPosition;
        private float _selectionDistance;

        private void Update()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (TryGetTableObject(out var selectedTableObject))
                {
                    SelectedTableObject = selectedTableObject;
                    SelectedTableObject.Rigidbody.freezeRotation = true;
                }
                else
                {
                    SelectedTableObject = null;
                    StopDrag();
                }
            }

            if (Input.GetMouseButtonUp(0) && _isDrag)
            {
                StopDrag();
            }
        }

        private void StopDrag()
        {
            _isDrag = false;

            if (SelectedTableObject != null)
            {
                SelectedTableObject.Rigidbody.freezeRotation = false;
            }
        }

        private void FixedUpdate()
        {
            if (_isDrag)
            {
                var screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _selectionDistance);
                var mousePositionOffset = _camera.ScreenToWorldPoint(screenPos) - _originalScreenTargetPosition;
                SelectedTableObject.Rigidbody.velocity = (_originalPosition + mousePositionOffset - SelectedTableObject.transform.position) * _forceAmount * Time.deltaTime;
            }
        }

        private bool TryGetTableObject(out TableObject tableObject)
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out RaycastHit hitInfo) &&
                hitInfo.collider.gameObject.transform.parent.TryGetComponent<TableObject>(out tableObject))
            {
                _selectionDistance = Vector3.Distance(ray.origin, hitInfo.point);
                _originalScreenTargetPosition = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _selectionDistance));
                _originalPosition = hitInfo.collider.transform.position;

                _isDrag = true;
                return true;
            }

            tableObject = null;
            return false;
        }
    }
}
