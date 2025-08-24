using Feature.Player.Factory;
using Infrastructure.AssetProvider;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
	public sealed class ProjectInstaller : MonoInstaller
	{
		[SerializeField] AssetProvider.AssetProvider _assetProvider;

		public override void InstallBindings()
		{
			BindAssetProvider();
			BindPlayerFactory();
		}

		void BindPlayerFactory()
		{
			Container
				.Bind<IPlayerFactory>()
				.To<PlayerFactory>()
				.AsSingle();
		}

		void BindAssetProvider()
		{
			Container
				.Bind<IAssetProvider>()
				.FromInstance(_assetProvider)
				.AsSingle();
		}
	}
}