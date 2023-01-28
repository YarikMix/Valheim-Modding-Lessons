using System.IO;
using System.Reflection;
using UnityEngine;

namespace JumpForcePatch
{
    class Helpers
    {
		public static Sprite CreateSprite(string fileName)
		{
			return Sprite.Create(LoadTexture(fileName), new Rect(0f, 0f, 64f, 64f), Vector2.zero);
		}

		public static Texture2D LoadTexture(string fileName)
		{
			Texture2D result;

			Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("JumpForcePatch.Assets." + fileName);
			byte[] array = new byte[manifestResourceStream.Length];
			manifestResourceStream.Read(array, 0, array.Length);
			Texture2D texture2D = new Texture2D(0, 0);
			ImageConversion.LoadImage(texture2D, array);
			result = texture2D;

			return result;
		}
	}
}
