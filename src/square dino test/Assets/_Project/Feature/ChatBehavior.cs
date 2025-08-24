using System;
using Feature.Movement;
using Feature.Player.Nickname;
using Mirror;
using UniRx;
using UnityEngine;
using Zenject;

namespace Feature
{
	public class ChatBehavior : NetworkBehaviour
	{
		[Inject] INicknameProvider _nicknameProvider;
		[Inject] IInputController _inputController;

		string Nickname => _nicknameProvider.Nickname;

		static event Action<string> OnMessage;

		void Awake()
		{
			_inputController.SendMsg
				.Subscribe(Send)
				.AddTo(this);
		}

		public override void OnStartLocalPlayer()
		{
			OnMessage += HandleNewMessage;
		}

		public override void OnStopLocalPlayer()
		{
			OnMessage -= HandleNewMessage;
		}

		[Client]
		void Send(Unit unit)
		{
			CmdSendMessage("Hello from " + Nickname);
		}

		void HandleNewMessage(string message)
		{
			Debug.Log(message);
		}

		[Command]
		void CmdSendMessage(string message)
		{
			RpcHandleMessage($"[{connectionToClient.connectionId}]: {message}");
		}

		[ClientRpc]
		void RpcHandleMessage(string message)
		{
			OnMessage?.Invoke($"\n{message}");
		}
	}
}