using Infrastructure.AssetProvider;
using UnityEngine;
using Zenject;

namespace Feature.Player.Factory
{
	public sealed class PlayerFactory : IPlayerFactory
	{
		[Inject] IAssetProvider _assetProvider;

		public GameObject Create(Vector3 pos)
		{
			return Object.Instantiate(_assetProvider.Player, pos,
				Quaternion.identity);
		}
	}
}