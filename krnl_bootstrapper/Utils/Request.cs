using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace krnl_bootstrapper.Utils
{
	// Token: 0x02000006 RID: 6
	public static class Request
	{
		// Token: 0x06000022 RID: 34 RVA: 0x00002A20 File Offset: 0x00000C20
		public static Task<string> Create(string URL)
		{
			Request.<Create>d__1 <Create>d__;
			<Create>d__.<>t__builder = AsyncTaskMethodBuilder<string>.Create();
			<Create>d__.URL = URL;
			<Create>d__.<>1__state = -1;
			<Create>d__.<>t__builder.Start<Request.<Create>d__1>(ref <Create>d__);
			return <Create>d__.<>t__builder.Task;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002A64 File Offset: 0x00000C64
		public static Task<byte[]> CreateByteArray(string URL)
		{
			Request.<CreateByteArray>d__2 <CreateByteArray>d__;
			<CreateByteArray>d__.<>t__builder = AsyncTaskMethodBuilder<byte[]>.Create();
			<CreateByteArray>d__.URL = URL;
			<CreateByteArray>d__.<>1__state = -1;
			<CreateByteArray>d__.<>t__builder.Start<Request.<CreateByteArray>d__2>(ref <CreateByteArray>d__);
			return <CreateByteArray>d__.<>t__builder.Task;
		}

		// Token: 0x0400001B RID: 27
		public static WebClient client = new WebClient();
	}
}
