using System;
using System.Reflection;
using System.Windows;

namespace krnl_bootstrapper.Utils
{
	// Token: 0x02000007 RID: 7
	internal class _7z
	{
		// Token: 0x06000025 RID: 37 RVA: 0x00002AB4 File Offset: 0x00000CB4
		public static void extract(string a, string b)
		{
			try
			{
				Assembly assembly = null;
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				for (int i = 0; i < assemblies.Length; i++)
				{
					if (assemblies[i].FullName.IndexOf("7z.NET") != -1)
					{
						assembly = assemblies[i];
						break;
					}
				}
				Type type = assembly.GetType("SevenZipNET.SevenZipExtractor");
				object obj = Activator.CreateInstance(type, new object[]
				{
					a
				});
				type.GetMethod("ExtractAll").Invoke(obj, new object[]
				{
					b,
					true,
					true
				});
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.StackTrace);
			}
		}
	}
}
