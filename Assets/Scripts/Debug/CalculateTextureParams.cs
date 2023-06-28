using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateTextureParams : MonoBehaviour
{
#if UNITY_EDITOR
	public SpriteRenderer mask;
	public bool calculate;
	public bool drawDebug;

	public string textureScalePropertyName = "_AlphaMask";
	public string textureOffsetPropertyName = "_AlphaMask";

	private void OnDrawGizmosSelected( )
	{
		if( calculate )
		{
			calculate = false;
			Bounds maskBounds = mask.sprite.bounds;
			SpriteRenderer targetSprite = GetComponent<SpriteRenderer>();
			Bounds targetBounds = targetSprite.sprite.bounds;

			Vector2 targetPos = targetSprite.transform.position;
			Vector3 targetScale = targetSprite.transform.lossyScale;

			Vector2 maskPos = mask.transform.position;

			Vector2 textureScale = new Vector2( ( targetBounds.extents.x * targetScale.x ) / maskBounds.extents.x, ( targetBounds.extents.y * targetScale.y ) / maskBounds.extents.y );

			Material material =	targetSprite.sharedMaterial;
			material.SetTextureScale( textureScalePropertyName, textureScale );

			Vector2 offset = ( targetPos + ( Vector2 ) ( targetBounds.min.MultiplyVector3( targetScale ) ) ) - ( maskPos + (Vector2) maskBounds.min );
			offset.x /= ( maskBounds.extents.x * 2f );
			offset.y /= ( maskBounds.extents.y * 2f );

			material.SetTextureOffset( textureScalePropertyName, offset );
		}
		if( drawDebug )
		{
			Gizmos.color = Color.green;
			Bounds maskBounds = mask.sprite.bounds;
			SpriteRenderer targetSprite = GetComponent<SpriteRenderer>();
			Bounds targetBounds = targetSprite.sprite.bounds;

			Vector3 targetPos = targetSprite.transform.position;
			Vector3 maskPos = mask.transform.position;
			Vector3 targetScale = targetSprite.transform.lossyScale;

			Gizmos.DrawLine( targetPos + targetBounds.min.MultiplyVector3( targetScale ), maskPos + maskBounds.min );

			Gizmos.color = Color.blue;
			Gizmos.DrawWireCube( maskPos + maskBounds.center, maskBounds.extents * 2f );
			Gizmos.color = Color.red;
			Gizmos.DrawWireCube( targetPos + targetBounds.center, ( targetBounds.extents.MultiplyVector3( targetScale )  ) * 2f  );
		}
	}
#endif
}
