using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace krnl_bootstrapper.Utils
{
	// Token: 0x02000005 RID: 5
	internal class OtherTasks
	{
		// Token: 0x04000019 RID: 25
		public static DateTime start = DateTime.Now;

		// Token: 0x0400001A RID: 26
		public static Task t0 = new Task(delegate()
		{
			OtherTasks.<>c.<<-cctor>b__3_0>d <<-cctor>b__3_0>d;
			<<-cctor>b__3_0>d.<>t__builder = AsyncVoidMethodBuilder.Create();
			<<-cctor>b__3_0>d.<>1__state = -1;
			<<-cctor>b__3_0>d.<>t__builder.Start<OtherTasks.<>c.<<-cctor>b__3_0>d>(ref <<-cctor>b__3_0>d);
		});
	}
}
