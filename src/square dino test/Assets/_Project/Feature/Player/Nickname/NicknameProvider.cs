using Infrastructure;
using Mirror;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Feature.Player.Nickname
{
	public sealed class NicknameProvider : MonoBehaviour, INicknameProvider
	{
		[SerializeField] Button _confirmButton;
		[SerializeField] TMP_InputField _inputField;

		[Inject] NetworkManagerHUD _networkManagerHUD;
		[Inject(Id = SceneInstaller.NickNameCanvasId)]
		Canvas _nickNameCanvas;

		public string Nickname => _inputField.text;

		void Awake()
		{
			_confirmButton
				.OnClickAsObservable()
				.Subscribe(OnConfirmButtonClick)
				.AddTo(this);
		}

		void OnConfirmButtonClick(Unit _)
		{
			if (string.IsNullOrEmpty(Nickname))
			{
				Debug.LogWarning("The nickname is empty.");
				return;
			}

			_nickNameCanvas.enabled = false;
			_networkManagerHUD.enabled = true;
		}
	}
}