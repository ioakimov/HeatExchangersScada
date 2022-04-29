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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Exchanger
{
	/// <summary>
	/// Interaction logic for HotExchanger.xaml
	/// </summary>
	public partial class HotExchanger : UserControl
	{
		public HotExchanger()
		{
			this.InitializeComponent();
		}
		public void StopWaterAnimation()
		{
		    this.PipeWave1.Wave.HideWaveAnimation();
			this.PipeWave2.Wave.HideWaveAnimation();
			this.PipeWave3.Wave.HideWaveAnimation();
			this.PipeWave4.Wave.HideWaveAnimation();
			this.PipeWave5.Wave.HideWaveAnimation();
		}
		public void StartWaterAnimation()
		{
			this.PipeWave1.Wave.ShowWaveAnimation();
			this.PipeWave2.Wave.ShowWaveAnimation();
			this.PipeWave3.Wave.ShowWaveAnimation();
			this.PipeWave4.Wave.ShowWaveAnimation();
			this.PipeWave5.Wave.ShowWaveAnimation();		
		}
		public void SetCasingMode(int ModeNum)
		{
			if(ModeNum == 0)this.Casing.Opacity = 0;
			else
			if(ModeNum == 1)this.Casing.Opacity = 100;
			
		}
		public void SetBrushMode(int ModeNum)
		{
			if(ModeNum == 0)VisualStateManager.GoToState(this,"VisualStateBase",true);
			else
			if(ModeNum == 1)VisualStateManager.GoToState(this,"VisualStateAlternative",true);
			
		}
	}
}