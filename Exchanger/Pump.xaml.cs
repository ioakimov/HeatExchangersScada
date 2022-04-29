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
	/// Interaction logic for Pump.xaml
	/// </summary>
	public partial class Pump : UserControl , IBaseWaterControl
	{
		public Pump()
		{
			this.InitializeComponent();
		}
		
		private void UserControl_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			int Temp = CurentControlState;
			            //ActivateWaterState((Temp == 1)?0:1);
			ActivateState((Temp == 1 || Temp == 2)?0:1);
		}
		public void ActivateState(int NewState)
		{
			switch(NewState)
			{
				case 0:
					if(CurentControlState != 0)
					{
						CurentControlState = 0;
						VisualStateManager.GoToState(this.ButtomPart,"VisualMainStateCloseCasing",true);				
					    VisualStateManager.GoToState(this.TopPart,"VisualStateGrey",true);
					}
					break;	
				case 1:
					if(CurentControlState != 1)
					{ 
						if(CurentControlState == 0 || CurentControlState == 3)VisualStateManager.GoToState(this.ButtomPart,"VisualMainStateOpenCasing",true);
						CurentControlState = 1;
						VisualStateManager.GoToState(this.TopPart,"VisualStateBlue",true);
					}
					break;
				case 2:
					if(CurentControlState != 2)
					{ 
						if(CurentControlState == 0)VisualStateManager.GoToState(this.ButtomPart,"VisualMainStateOpenCasing",true);
						CurentControlState = 2; 
						VisualStateManager.GoToState(this.TopPart,"VisualStateRed",true);
					}
					break;
				case 3:
					if(CurentControlState != 3)
					{
						if(CurentControlState == 0)VisualStateManager.GoToState(this.ButtomPart,"VisualStateStopWarning",true);
						CurentControlState = 3;
						VisualStateManager.GoToState(this.TopPart,"VisualStateRed",true);
					}
					break;
			}
		}
		public void ActivateWaterState(int NewState)
		{
			switch(NewState)
			{
				case 0:
					if(CurentControlWaterState == 1){ CurentControlWaterState = 0; VisualStateManager.GoToState(this.ButtomPart.PipeWave,"VisualStateTurnOff",true); }
					break;	
				case 1:
					if(CurentControlWaterState == 0){ CurentControlWaterState = 1; VisualStateManager.GoToState(this.ButtomPart.PipeWave,"VisualStateTurnOn",true);}
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
		   if( CurentControlState == 3) ActivateState(0);
		   if( CurentControlState == 1) ActivateState(2);
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
		   if( CurentControlState == 2 ) ActivateState(1);
		   if( CurentControlState == 0) ActivateState(3);
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