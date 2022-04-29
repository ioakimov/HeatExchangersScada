using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Exchanger
{
	public interface IBaseWaterControl
	{
		void ActivateState(int NewState);
		void ActivateWaterState(int NewState);
		int StopWaterSteam();
		int RunWaterSteam();
		IBaseWaterControl GetNextWaterControl(int NumOfWaterControl);
		bool SetNextWaterControl(int NumOfWaterControl , IBaseWaterControl LinkToWaterControl);		
	}
}