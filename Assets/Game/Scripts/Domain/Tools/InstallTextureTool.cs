using Assets.Game.Scripts.Core.Tools;
using Assets.Game.Scripts.Domain.Components;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Networking;

namespace Assets.Game.Scripts.Domain.Tools
{
    [CreateAssetMenu(fileName = "InstallTextureTool", menuName = "Tools/InstallTextureTool")]
    public class InstallTextureTool : InstallObjectTool
    {
#pragma warning disable 0649
        [SerializeField] private string[] _texturesNames;
#pragma warning restore 0649

        public override void Install(TableObject tableObject)
        {
            SetTexture(tableObject, 0).Forget();
        }

        public void Install(TableObject tableObject, int index)
        {
            Assert.IsTrue(index < _texturesNames.Length, "Wrong index!");

            SetTexture(tableObject, index).Forget();
        }

        private async UniTask SetTexture(TableObject tableObject, int index)
        {
            var texturePath = $"file://{Application.streamingAssetsPath}/Textures/{_texturesNames[index]}.png";

            using (var uwr = UnityWebRequestTexture.GetTexture(texturePath))
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
