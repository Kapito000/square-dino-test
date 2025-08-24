using UnityEngine;

namespace Infrastructure.AssetProvider
{
	public interface IAssetProvider
	{
		GameObject Player { get; }
		GameObject Cube { get; }
	}
}