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

//using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Pipe
{
	/// <summary>
	/// Interaction logic for WaterWave.xaml
	/// </summary>
	public partial class WaterWave : UserControl
	{
		public WaterWave()
		{

			
			this.InitializeComponent();
			//Storyboard MainAnimation = (Storyboard)this.Resources["WaterWaveAnimation"];
            //MainAnimation.RepeatBehavior = new RepeatBehavior(0);
			
			//Storyboard MainAnimation = (Storyboard)this.Resources["ReverseWaterWaveAnimation"];
            //MainAnimation.RepeatBehavior = new RepeatBehavior(0);
			//MainAnimation.Pause();
			//((Storyboard)this.Resources["WaterWaveAnimation"]).Begin();
		//	Storyboard MainAnimation = (Storyboard)this.Resources["WaterWaveAnimation"];
			//MainAnimation.RepeatBehavior = new RepeatBehavior(12);
			//this.BeginStoryboard(MainAnimation);
		//	MainAnimation.Begin(this);
			
            //MainAnimation.RepeatBehavior = new RepeatBehavior(0);
			//xStart.RepeatBehavior = new RepeatBehavior(7);
            //  path.BeginStoryboard(xStart);

			//ReversWaterWaveAnimation.Begin(this,true);
		}
		public void HideWaveAnimation()
		{
			this.EllipseWhiteWave.Opacity = 0;
		}
		public void ShowWaveAnimation()
		{
			this.EllipseWhiteWave.Opacity = 100;
		}
		public void SetRightToLeftMode()
		{
			Storyboard MainAnimation = (Storyboard)this.Resources["WaterWaveAnimation"];
            MainAnimation.Begin(this);
		}
		public void SetColorMode(int ColorNum)
		{
		switch(ColorNum)
			{
			case 1:
				VisualStateManager.GoToState(this.BackgroundRect,"VisualStateRed",true);
				break;
			case 2:
				VisualStateManager.GoToState(this.BackgroundRect,"VisualStateGreen",true);
				break;
			case 3:
				VisualStateManager.GoToState(this.BackgroundRect,"VisualStateDarkBlue",true);
				break;
			default:
				VisualStateManager.GoToState(this.BackgroundRect,"VisualStateBlue",true);
				break;
			}
		}
	}
}