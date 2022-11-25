using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using krnl_bootstrapper.Files;
using krnl_bootstrapper.Utils;

namespace krnl_bootstrapper
{
	// Token: 0x02000003 RID: 3
	[DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
	public partial class MainWindow : Window
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000004 RID: 4 RVA: 0x0000207E File Offset: 0x0000027E
		// (set) Token: 0x06000005 RID: 5 RVA: 0x00002085 File Offset: 0x00000285
		public static Dispatcher dispatcher { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000006 RID: 6 RVA: 0x0000208D File Offset: 0x0000028D
		// (set) Token: 0x06000007 RID: 7 RVA: 0x00002094 File Offset: 0x00000294
		public static Label ET { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000008 RID: 8 RVA: 0x0000209C File Offset: 0x0000029C
		// (set) Token: 0x06000009 RID: 9 RVA: 0x000020A3 File Offset: 0x000002A3
		public static Grid L { get; set; }

		// Token: 0x0600000A RID: 10 RVA: 0x000020AC File Offset: 0x000002AC
		public static void killProcess(string name)
		{
			Process[] processesByName = Process.GetProcessesByName(name);
			bool flag = false;
			for (int i = 0; i < processesByName.Length; i++)
			{
				if (processesByName[i].Id != Process.GetCurrentProcess().Id)
				{
					try
					{
						if (!flag && name != "krnl_bootstrapper")
						{
							MessageBox.Show(name + " will be closed to ensure the bootstrapper successfully works.", "KRNL Bootstrapper", MessageBoxButton.OK, MessageBoxImage.Exclamation);
							flag = true;
						}
						processesByName[i].Kill();
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002130 File Offset: 0x00000330
		public MainWindow()
		{
			this.InitializeComponent();
			MainWindow.ET = this.ElapsedTime;
			MainWindow.L = this.Line;
			MainWindow.killProcess("krnl_bootstrapper");
			if (File.Exists("krnl_bootstrapper.bak"))
			{
				try
				{
					File.Delete("krnl_bootstrapper.bak");
				}
				catch
				{
				}
			}
			if (Process.GetCurrentProcess().MainModule.FileName.EndsWith("krnl_console_bootstrapper.exe"))
			{
				try
				{
					File.Move("krnl_console_bootstrapper.exe", "krnl_bootstrapper.exe");
				}
				catch
				{
				}
			}
			base.Closing += this.MainWindow_Closing;
			try
			{
				string currentDirectory = Environment.CurrentDirectory;
				if (Path.GetTempPath().IndexOf(currentDirectory) == 0)
				{
					throw new Exception();
				}
				if (Environment.GetFolderPath(Environment.SpecialFolder.SystemX86).IndexOf(currentDirectory) == 0)
				{
					throw new Exception();
				}
				if (Environment.GetFolderPath(Environment.SpecialFolder.System).IndexOf(currentDirectory) == 0)
				{
					throw new Exception();
				}
				if (Environment.GetFolderPath(Environment.SpecialFolder.Windows).IndexOf(currentDirectory) == 0)
				{
					throw new Exception();
				}
			}
			catch
			{
				Environment.CurrentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			}
			this.Status.Content = "Checking if KRNL is up-to-date...";
			new Task(delegate()
			{
				MainWindow.dispatcher = base.Dispatcher;
				OtherTasks.t0.Start();
				MainWindow.dispatcher.Invoke<Task>(delegate()
				{
					MainWindow.<<-ctor>b__16_1>d <<-ctor>b__16_1>d;
					<<-ctor>b__16_1>d.<>t__builder = AsyncTaskMethodBuilder.Create();
					<<-ctor>b__16_1>d.<>4__this = this;
					<<-ctor>b__16_1>d.<>1__state = -1;
					<<-ctor>b__16_1>d.<>t__builder.Start<MainWindow.<<-ctor>b__16_1>d>(ref <<-ctor>b__16_1>d);
					return <<-ctor>b__16_1>d.<>t__builder.Task;
				});
			}).Start();
		}

		// Token: 0x0600000C RID: 12 RVA: 0x0000227C File Offset: 0x0000047C
		public bool UpdateBootstrapper()
		{
			this.Status.Content = "Checking for bootstrapper update...";
			string result = Request.Create(Constants.checksumUrl).GetAwaiter().GetResult();
			if (result.IndexOf("cloudflare") == -1 && result != Checksum.GetMD5(Constants.pathJoin(new string[]
			{
				"krnl_bootstrapper.exe"
			})))
			{
				this.Status.Content = "Updating...";
				try
				{
					byte[] bytes = Request.client.DownloadData(Constants.bootstrapperUrl2);
					File.Move("krnl_bootstrapper.exe", "krnl_bootstrapper.bak");
					File.WriteAllBytes("krnl_bootstrapper.exe", bytes);
					Process.Start("krnl_bootstrapper.exe");
					return true;
				}
				catch
				{
				}
				return false;
			}
			return false;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002340 File Offset: 0x00000540
		public void UpdateFiles()
		{
			string[] array = Request.Create(Constants.hashUrl).GetAwaiter().GetResult().Split(new char[]
			{
				'\n'
			});
			string text;
			for (int j = 0; j < array.Length; j++)
			{
				string[] array2 = array[j].Split(new char[]
				{
					'='
				});
				text = array2[0];
				string value = array2[1];
				if (text.IndexOf("KrnlAPI") == -1)
				{
					Constants.Hashes[text] = value;
					MainWindow.tasks_total++;
				}
			}
			if (Constants.Hashes.Count == 0)
			{
				this.Status.Content = "Unable to fetch checksums of KRNL files...";
				MainWindow.running = false;
				return;
			}
			MainWindow.killProcess("krnlss");
			MainWindow.killProcess("RobloxPlayerBeta");
			try
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = Environment.CurrentDirectory,
					UseShellExecute = true,
					Verb = "open"
				});
			}
			catch
			{
			}
			Parallel.For(0, Constants.Hashes.Count, delegate(int i)
			{
				string url = Constants.baseUrl + "/" + Constants.Hashes.Keys.ToList<string>()[i];
				string path = Constants.pathJoin(Constants.Hashes.Keys.ToList<string>()[i].Split(new char[]
				{
					'/'
				}));
				string text = Constants.Hashes[Constants.Hashes.Keys.ToList<string>()[i]];
				Action action = delegate()
				{
					this.Status.Content = string.Format("Completed Files: {0}/{1}", MainWindow.tasks, MainWindow.tasks_total);
				};
				new Thread(delegate()
				{
					this.Dispatcher.Invoke(action);
					if (!File.Exists(path) || !(Checksum.GetMD5(path) == text))
					{
						byte[] bytes = new WebClient
						{
							Proxy = null,
							Headers = 
							{
								{
									"User-Agent",
									"krnl_bootstrapper - Krnl"
								}
							}
						}.DownloadData(url);
						File.WriteAllBytes(path, bytes);
						if (url.EndsWith(".zip") || url.EndsWith(".7z"))
						{
							_7z.extract(path, Constants.pathJoin(new string[]
							{
								Constants.Hashes.Keys.ToList<string>()[i].Split(new char[]
								{
									'/'
								})[0]
							}));
						}
					}
					MainWindow.tasks++;
					this.Dispatcher.Invoke(action);
					this.Dispatcher.Invoke(delegate()
					{
						if (MainWindow.tasks == MainWindow.tasks_total)
						{
							WebClient webClient = new WebClient();
							webClient.Proxy = null;
							string text2 = Constants.pathJoin(new string[]
							{
								"injector.dll"
							});
							if (!File.Exists(text2) || !(Checksum.GetMD5(text2).ToUpperInvariant() == webClient.DownloadString(Constants.injectorChecksumUrl)))
							{
								byte[] bytes2 = webClient.DownloadData(Constants.injectorUrl);
								File.WriteAllBytes(text2, bytes2);
							}
							MainWindow.running = false;
							base.Close();
						}
					});
				}).Start();
			});
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002458 File Offset: 0x00000658
		private void MainWindow_Closing(object sender, CancelEventArgs e)
		{
			if (base.Opacity != 0.0)
			{
				e.Cancel = true;
				MainWindow.running = false;
			}
			if (base.Opacity == 1.0)
			{
				new Task(delegate()
				{
					base.Dispatcher.Invoke<Task>(delegate()
					{
						MainWindow.<<MainWindow_Closing>b__19_1>d <<MainWindow_Closing>b__19_1>d;
						<<MainWindow_Closing>b__19_1>d.<>t__builder = AsyncTaskMethodBuilder.Create();
						<<MainWindow_Closing>b__19_1>d.<>4__this = this;
						<<MainWindow_Closing>b__19_1>d.<>1__state = -1;
						<<MainWindow_Closing>b__19_1>d.<>t__builder.Start<MainWindow.<<MainWindow_Closing>b__19_1>d>(ref <<MainWindow_Closing>b__19_1>d);
						return <<MainWindow_Closing>b__19_1>d.<>t__builder.Task;
					});
				}).Start();
			}
			if (base.Opacity != 0.0)
			{
				return;
			}
			base.Hide();
			if (MainWindow.tasks == MainWindow.tasks_total && MainWindow.tasks != 0 && MainWindow.tasks_total != 0)
			{
				try
				{
					Process.Start("krnlss.exe");
				}
				catch (Exception)
				{
					MessageBox.Show("Unable to run krnlss.exe, make sure your anti-virus is turned off or ensure that the krnl folder is added to the exclusion folder to avoid this from happening.", "KRNL Bootstrapper - Exception", MessageBoxButton.OK, MessageBoxImage.Hand);
				}
			}
			try
			{
				File.Move("7z.NET.dll", "7z");
				File.Delete("7z");
			}
			catch
			{
			}
			try
			{
				File.Move("7za.exe", "7z");
				File.Delete("7z");
			}
			catch
			{
			}
			Process.GetCurrentProcess().Kill();
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002570 File Offset: 0x00000770
		private void Window_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (Mouse.LeftButton == MouseButtonState.Pressed)
			{
				base.DragMove();
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002580 File Offset: 0x00000780
		private void Close_Click(object sender, RoutedEventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002588 File Offset: 0x00000788
		private void Minimize_Click(object sender, RoutedEventArgs e)
		{
			base.WindowState = WindowState.Minimized;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002591 File Offset: 0x00000791
		private string GetDebuggerDisplay()
		{
			return this.ToString();
		}

		// Token: 0x04000001 RID: 1
		private static int tasks = 0;

		// Token: 0x04000002 RID: 2
		private static int tasks_total = 0;

		// Token: 0x04000003 RID: 3
		public static bool running = true;
	}
}
