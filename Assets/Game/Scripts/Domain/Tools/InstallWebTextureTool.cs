using Assets.Game.Scripts.Core.Tools;
using Assets.Game.Scripts.Domain.Components;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Game.Scripts.Domain.Tools
{
    [CreateAssetMenu(fileName = "InstallWebTextureTool", menuName = "Tools/InstallWebTextureTool")]
    public class InstallWebTextureTool : InstallObjectTool
    {
#pragma warning disable 0649
        [SerializeField] private string _textureUrl;
#pragma warning restore 0649

        public override void Install(TableObject tableObject)
        {
            SetTexture(tableObject).Forget();
        }

        private async UniTask SetTexture(TableObject tableObject)
        {
            using (var uwr = UnityWebRequestTexture.GetTexture(_textureUrl))
            {
                await uwr.SendWebRequest().ToUniTask();

                if (uwr.isNetworkError || uwr.isHttpError)
                {
                    UnityEngine.Debug.LogError($"<color=red>{uwr.error}</color>");
                }
                else
                {
                    var texture = DownloadHandlerTexture.GetContent(uwr);
                    tableObject.MeshRenderer.material.SetTexture("_MainTex", texture);
                }
            }
        }
    }
}
