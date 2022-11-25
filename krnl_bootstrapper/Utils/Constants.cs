using System;
using System.Collections.Generic;
using System.IO;

namespace krnl_bootstrapper.Utils
{
	// Token: 0x02000004 RID: 4
	internal class Constants
	{
		// Token: 0x0600001D RID: 29 RVA: 0x000028D7 File Offset: 0x00000AD7
		public static string pathJoin(string[] args)
		{
			return Path.Combine(Environment.CurrentDirectory, string.Join(Convert.ToString(Path.DirectorySeparatorChar), args));
		}

		// Token: 0x0400000B RID: 11
		private static readonly string mainDomain = "https://krnl.place";

		// Token: 0x0400000C RID: 12
		private static readonly string keySysDomain = "https://cdn.krnl.place";

		// Token: 0x0400000D RID: 13
		private static readonly string bootstrapperDomain = "https://k-storage.com";

		// Token: 0x0400000E RID: 14
		public static readonly string inviteUrl = Constants.mainDomain + "/invite";

		// Token: 0x0400000F RID: 15
		public static readonly string Title = "Krnl Console Bootstrapper - Rewrite Edition";

		// Token: 0x04000010 RID: 16
		public static readonly string versionUrl = Constants.keySysDomain + "/version.txt";

		// Token: 0x04000011 RID: 17
		public static readonly string baseUrl = Constants.bootstrapperDomain + "/bootstrapper/files";

		// Token: 0x04000012 RID: 18
		public static readonly string bootstrapperUrl = Constants.bootstrapperDomain + "/krnl_console_bootstrapper.exe";

		// Token: 0x04000013 RID: 19
		public static readonly string bootstrapperUrl2 = Constants.bootstrapperDomain + "/krnl_bootstrapper.exe";

		// Token: 0x04000014 RID: 20
		public static readonly string checksumUrl = Constants.bootstrapperDomain + "/bootstrapperChecksum.txt";

		// Token: 0x04000015 RID: 21
		public static readonly string hashUrl = Constants.baseUrl + "/hashes.txt";

		// Token: 0x04000016 RID: 22
		public static readonly string injectorUrl = Constants.bootstrapperDomain + "/bootstrapper/injector.dll";

		// Token: 0x04000017 RID: 23
		public static readonly string injectorChecksumUrl = Constants.bootstrapperDomain + "/bootstrapper/injector.checksum";

		// Token: 0x04000018 RID: 24
		public static Dictionary<string, string> Hashes = new Dictionary<string, string>();
	}
}
