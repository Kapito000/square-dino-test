using Infrastructure.AssetProvider;
using UnityEngine;
using Zenject;

namespace Feature.ItemSpawner.Factory
{
	public sealed class CubeFactory : ICubeFactory
	{
		[Inject] IAssetProvider _assetProvider;

		public GameObject Create(Vector3 pos)
		{
			return Object.Instantiate(_assetProvider.Cube, pos, Quaternion.identity);
		}
	}
}