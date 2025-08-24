using Feature.Player.Factory;
using Infrastructure.AssetProvider;
using Mirror;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
	public sealed class CustomNetWorkManager : NetworkManager
	{
		[Inject] IAssetProvider _assetProvider;
		[Inject] IPlayerFactory _playerFactory;

		public override void OnStartServer()
		{
			NetworkServer.RegisterHandler<AddPlayerMessage>(OnCreateCharacter);
		}

		public override void OnStartClient()
		{
			NetworkClient.RegisterPrefab(_assetProvider.Player);
		}

		public override void OnClientConnect()
		{
			base.OnClientConnect();
			NetworkClient.Send(new AddPlayerMessage());
		}
		
		void OnCreateCharacter(NetworkConnectionToClient conn,
			AddPlayerMessage message)
		{
			Transform startPos = GetStartPosition();
			var player = _playerFactory.Create(startPos.position);
			player.name = $"{_assetProvider.Player} [connId={conn.connectionId}]";
			NetworkServer.AddPlayerForConnection(conn, player);
		}
	}
}