using Feature.ItemSpawner;
using Feature.ItemSpawner.Factory;
using Feature.Player.Nickname;
using Mirror;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Infrastructure
{
	public sealed class SceneInstaller : MonoInstaller
	{
		public const string NickNameCanvasId = "NickNameCanvasId";

		[SerializeField] Canvas _nickNameCanvas;

		public override void InstallBindings()
		{
			BindCubeFactory();
			BindNickNameCanvas();
			BindNicknameProvider();
			BindNetworkManagerHUD();
		}

		void BindCubeFactory()
		{
			Container
				.Bind<ICubeFactory>()
				.To<CubeFactory>()
				.AsSingle();
		}

		void BindNickNameCanvas()
		{
			Assert.IsNotNull(_nickNameCanvas);
			Container
				.Bind<Canvas>()
				.WithId(NickNameCanvasId)
				.FromInstance(_nickNameCanvas)
				.AsSingle();
		}

		void BindNetworkManagerHUD()
		{
			Container
				.Bind<NetworkManagerHUD>()
				.FromComponentInHierarchy()
				.AsSingle();
		}

		void BindNicknameProvider()
		{
			Container
				.Bind<INicknameProvider>()
				.FromComponentInHierarchy()
				.AsSingle();
		}
	}
}