using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace krnl_bootstrapper.Properties
{
	// Token: 0x02000008 RID: 8
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	public class Resources
	{
		// Token: 0x06000027 RID: 39 RVA: 0x00002B70 File Offset: 0x00000D70
		internal Resources()
		{
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00002B78 File Offset: 0x00000D78
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00002BA4 File Offset: 0x00000DA4
		// (set) Token: 0x0600002A RID: 42 RVA: 0x00002BAB File Offset: 0x00000DAB
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00002BB3 File Offset: 0x00000DB3
		public static byte[] _7z_NET
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("_7z_NET", Resources.resourceCulture);
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600002C RID: 44 RVA: 0x00002BCE File Offset: 0x00000DCE
		public static byte[] _7za
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("_7za", Resources.resourceCulture);
			}
		}

		// Token: 0x0400001C RID: 28
		private static ResourceManager resourceMan;

		// Token: 0x0400001D RID: 29
		private static CultureInfo resourceCulture;
	}
}
