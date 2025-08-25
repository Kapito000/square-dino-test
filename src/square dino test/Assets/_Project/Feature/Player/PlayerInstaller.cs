using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Feature.Player
{
	public sealed class PlayerInstaller : MonoInstaller
	{
		public const string CharacterAnimatorId = "CharacterAnimator";
		
		[SerializeField] Animator _characterAnimator;
		
		public override void InstallBindings()
		{
			BindPlayerAnimator();
			BindCharacterAnimator();
		}

		void BindCharacterAnimator()
		{
			Assert.IsNotNull(_characterAnimator);
			Container
				.Bind<Animator>()
				.WithId(CharacterAnimatorId)
				.FromInstance(_characterAnimator)
				.AsSingle();
		}

		void BindPlayerAnimator()
		{
			Container
				.Bind<PlayerAnimator>()
				.FromComponentInHierarchy()
				.AsSingle()
				.NonLazy();
		}
	}
}