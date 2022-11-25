using System;
using System.IO;
using System.Security.Cryptography;
using krnl_bootstrapper.Utils;

namespace krnl_bootstrapper.Files
{
	// Token: 0x02000009 RID: 9
	internal class Checksum
	{
		// Token: 0x0600002D RID: 45 RVA: 0x00002BEC File Offset: 0x00000DEC
		public static string GetMD5(string filename)
		{
			string result;
			try
			{
				using (FileStream fileStream = File.OpenRead(filename))
				{
					string text = BitConverter.ToString(MD5.Create().ComputeHash(fileStream)).Replace("-", "").ToLowerInvariant();
					fileStream.Close();
					result = text;
				}
			}
			catch (IOException)
			{
				result = "";
			}
			return result;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002C60 File Offset: 0x00000E60
		public static bool CompareFile(string filename)
		{
			return File.Exists(filename) && Checksum.GetMD5(filename) == Constants.Hashes[filename];
		}
	}
}
