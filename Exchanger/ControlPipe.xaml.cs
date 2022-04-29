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
	/// Interaction logic for ControlPipe.xaml
	/// </summary>
	/// 

	public partial class ControlPipe : UserControl , IBaseWaterControl
	{
		public ControlPipe()
		{
			this.InitializeComponent();
		}
		public void ActivateState(int NewState)
		{
			switch(NewState)
			{
				case 0:
					if(CurentControlState == 1){ CurentControlState = 0; VisualStateManager.GoToState(this,"VisualMainStateFastCloseCasing",true);}
					break;	
				case 1:
					if(CurentControlState == 0){ CurentControlState = 1; VisualStateManager.GoToState(this,"VisualMainStateFastOpenCasing",true);}
					break;
			}
		}
		public void ActivateWaterState(int NewState)
		{
			switch(NewState)
			{
				case 0:
					if(CurentControlWaterState == 1)
					{ 
						CurentControlWaterState = 0;
						//VisualStateManager.GoToState(this.PipeWave,"VisualStateTurnOff",true);
					}
					break;	
				case 1:
					if(CurentControlWaterState == 0)
					{
						CurentControlWaterState = 1;
						//VisualStateManager.GoToState(this.PipeWave,"VisualStateTurnOn",true);
					}
					break;
			}
		}
		//**********************************************************************************************************
		//*Стандартный блок , включающий  функции реализующие возможность лавинооразного выключения воды в системе.*
		//**********************************************************************************************************
		private byte CurentControlState = 1;
		private byte CurentControlWaterState = 1;
		public const int CountOfNextWaterControls = 1;
		private IBaseWaterControl[] NextWaterControl = new IBaseWaterControl[CountOfNextWaterControls];
		
		public IBaseWaterControl GetNextWaterControl(int NumOfWaterControl)
		{
			if(NumOfWaterControl > CountOfNextWaterControls || NumOfWaterControl < 1)
				return null; 
			else return NextWaterControl[NumOfWaterControl - 1];
		}
		
		public bool SetNextWaterControl(int NumOfWaterControl , IBaseWaterControl LinkToWaterControl)
		{
			if(NumOfWaterControl > CountOfNextWaterControls || NumOfWaterControl < 1)
				return false; 
			else 
			{
				NextWaterControl[NumOfWaterControl - 1] = LinkToWaterControl;
			    return true;
			}
		}
		   
		public int StopWaterSteam()
		{ 
		   ActivateWaterState(0);
		   ActivateState(0);
		   for(int i = 0;i<CountOfNextWaterControls;i++)
		   if(NextWaterControl[i] != null)
		   {
			  NextWaterControl[i].StopWaterSteam();
		   }
		   return 0;
		}
		
		public int RunWaterSteam()
		{ 
		   ActivateWaterState(1);
		   ActivateState(1);
		   for(int i = 0;i<CountOfNextWaterControls;i++)
		   if(NextWaterControl[i] != null)
		   {
			  NextWaterControl[i].RunWaterSteam();
		   }
		   return 1;
		}
		//**********************************************************************************************************
	}
	
}