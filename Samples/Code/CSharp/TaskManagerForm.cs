using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cappta.Gp.Api.Com.Sample
{
	public class TaskManagerForm
	{
		public static void Start(Action action) => Task.Factory.StartNew(action);

		public static void InvokeControlAction<T>(T control, Action<T> action) where T : Control
		{
			if (control.InvokeRequired == false) { action(control); return; }

			control.Invoke(new Action<T, Action<T>>(InvokeControlAction), new object[] { control, action });
		}
	}
}
