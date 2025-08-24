using Infrastructure;
using UnityEngine;

namespace Feature.Player.Factory
{
	public interface IPlayerFactory : IFactory
	{
		GameObject Create(Vector3 pos);
	}
}