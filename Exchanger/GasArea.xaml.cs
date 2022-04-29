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
	/// Interaction logic for GasArea.xaml
	/// </summary>
	public partial class GasArea : UserControl, IBaseWaterControl
	{
		public GasArea()
		{
			this.InitializeComponent();
		}
		public void ActivateState(int NewState)
		{
			
			switch(NewState)
			{
				case 0:
					if(CurentControlState != 0){ CurentControlState = 0;VisualStateManager.GoToState(this,"VisualStateTurnOffTheCombustionGases",true);}
					break;	
				case 1:
					if(CurentControlState != 1){ CurentControlState = 1;VisualStateManager.GoToState(this,"VisualStateTurnOnTheCombustionGases",true);}
					break;
				case 2:
					if(CurentControlState != 2){ CurentControlState = 2;VisualStateManager.GoToState(this,"VisualStateSaturationOfTheCombustionGasesOff",true);}
					break;	
				case 3:
					if(CurentControlState != 3){ CurentControlState = 3;VisualStateManager.GoToState(this,"VisualStateSaturationOfTheCombustionGasesOn",true);}
					break;
				case 4:
					if(CurentControlState != 4){ CurentControlState = 4;VisualStateManager.GoToState(this,"VisualStateTurnOffTheCombustionGasesWithSaturation",true);}
					break;
				case 5:
					if(CurentControlState != 5){ CurentControlState = 5;VisualStateManager.GoToState(this,"VisualStateTurnOnTheCombustionGasesWithSaturation",true);}
					break;
			}
			
		}
		public void ActivateWaterState(int NewState)
		{
			switch(NewState)
			{
				case 0:
					if(CurentControlWaterState != 0){ CurentControlWaterState = 0; }
					break;	
				case 1:
					if(CurentControlWaterState != 1){ CurentControlWaterState = 1; 	}
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
			if(CurentControlState == 1 || CurentControlState == 2)ActivateState(0);
			if(CurentControlState == 3 || CurentControlState == 5)ActivateState(4);
			
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
		   //ActivateState(1);
		   if(CurentControlState == 1 || CurentControlState == 2)ActivateState(1);
		   if(CurentControlState == 3 || CurentControlState == 5)ActivateState(5);
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