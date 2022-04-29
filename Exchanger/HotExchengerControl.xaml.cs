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
	/// Interaction logic for HotExchengerControl.xaml
	/// </summary>
	public partial class HotExchengerControl : UserControl
	{
		public HotExchengerControl()
		{
			this.InitializeComponent();
			this.ValveColdIn.SetNextWaterControl(1,this.MainExchanger.PipeWave1);
			this.MainExchanger.PipeWave1.SetNextWaterControl(1,this.MainExchanger.PipeWave2);
			this.MainExchanger.PipeWave2.SetNextWaterControl(1,this.MainExchanger.PipeWave3);
			this.MainExchanger.PipeWave3.SetNextWaterControl(1,this.MainExchanger.PipeWave4);
			this.MainExchanger.PipeWave4.SetNextWaterControl(1,this.MainExchanger.PipeWave5);
			this.MainExchanger.PipeWave5.SetNextWaterControl(1,this.ValveColdOut);
			
			this.ValveHotIn.SetNextWaterControl(1,this.MainExchanger.GasZone);
			this.MainExchanger.GasZone.SetNextWaterControl(1,this.ValveHotOut);
		}

		private void ValveHotOut_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			// TODO: Add event handler implementation here.
			if(this.ValveHotOut.GetState ==0)
			{
				if(this.ValveHotIn.GetState == 1)this.MainExchanger.GasZone.ActivateState(3);	
			}	
			else
			if(this.ValveHotOut.GetState ==1)
			{
				if(this.ValveHotIn.GetState == 1) this.MainExchanger.GasZone.ActivateState(2);
			}
		}

		private void ValveHotIn_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			// TODO: Add event handler implementation here.
			if(this.ValveHotIn.GetState ==0 && this.ValveColdIn.GetState ==0)this.MainExchanger.SetCasingMode(1); 
			if(this.ValveHotIn.GetState ==0)
			{
				if(this.ValveHotOut.GetState == 1) this.MainExchanger.GasZone.ActivateState(0);	
                if(this.ValveHotOut.GetState == 0) 
			    {
			        this.MainExchanger.GasZone.ActivateState(4);	
					
			    }
			}	
			else
			if(this.ValveHotIn.GetState ==1)
			{
				if(this.ValveColdIn.GetState ==0)this.MainExchanger.SetCasingMode(0); 
				if(this.ValveHotOut.GetState == 0)  this.MainExchanger.GasZone.ActivateState(5);	
                if(this.ValveHotOut.GetState == 1) 
			    {
				    this.MainExchanger.GasZone.ActivateState(1);						
		        }
			}
				
		}

		private void ValveColdOut_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			// TODO: Add event handler implementation here.
			if(this.ValveColdOut.GetState ==0)
			{
				this.MainExchanger.StopWaterAnimation();
			}	
			else
			if(this.ValveColdOut.GetState ==1)
			{
				this.MainExchanger.StartWaterAnimation();				
			}
		}

		private void ValveColdIn_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			// TODO: Add event handler implementation here.
			if(this.ValveHotIn.GetState == 0 && this.ValveColdIn.GetState == 0)this.MainExchanger.SetCasingMode(1);
			if(this.ValveHotIn.GetState == 0 &&this.ValveColdIn.GetState == 1)this.MainExchanger.SetCasingMode(0); 
	
			
		}
	}
}