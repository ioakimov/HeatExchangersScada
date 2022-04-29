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
	/// Interaction logic for Valve.xaml
	/// </summary>
	public partial class Valve : UserControl, IBaseWaterControl
	{
		public Valve()
		{
			this.InitializeComponent();
		}

		private void UserControl_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			int Temp = CurentControlState;
			//ActivateWaterState((Temp == 1)?0:1);
			ActivateState((Temp == 1)?0:1);
		}

		public double GetState
		{
		   get{ return CurentControlState;}
		}
		
		public void ActivateState(int NewState)
		{
			switch(NewState)
			{
				case 0:
					if(CurentControlState == 1)
					{ 
						CurentControlState = 0;
						VisualStateManager.GoToState(this,"VisualStateTurnOff",true);
						if(CurentControlWaterState == 1)
					    StopWaterSteamInNextControls();
					}
					break;	
				case 1:
					if(CurentControlState == 0)
					{
						CurentControlState = 1;
						VisualStateManager.GoToState(this,"VisualStateTurnOn",true);
						if(CurentControlWaterState == 1)
					    RunWaterSteamInNextControls();
					}
					break;
			}
		}
		public void ActivateWaterState(int NewState)
		{
			switch(NewState)
			{
				case 0:
					if(CurentControlWaterState == 1){ CurentControlWaterState = 0; }
					break;	
				case 1:
					if(CurentControlWaterState == 0){ CurentControlWaterState = 1; }
					break;
			}
		}
		//**********************************************************************************************************
		//*Стандартный блок , включающий  функции реализующие возможность лавинооразного выключения воды в системе.*
		//**********************************************************************************************************
		private int CurentControlState = 1;
		private int CurentControlWaterState = 1;
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
		   //ActivateState(0);
		   if(CurentControlState == 1)
		   StopWaterSteamInNextControls();
		   return 0;
		}
		
		public int RunWaterSteam()
		{ 
		   ActivateWaterState(1);
		   //ActivateState(1);
			if(CurentControlState == 1)
			RunWaterSteamInNextControls();
			return 1;
		  
		}
		//**********************************************************************************************************		
	    public int StopWaterSteamInNextControls()
		{
		   for(int i = 0;i<CountOfNextWaterControls;i++)
		   if(NextWaterControl[i] != null)
		   {
			  NextWaterControl[i].StopWaterSteam();
		   }	
		   return 0;
		}
		public int RunWaterSteamInNextControls()
		{
		   for(int i = 0;i<CountOfNextWaterControls;i++)
		   if(NextWaterControl[i] != null)
		   {
			  NextWaterControl[i].RunWaterSteam();
		   }
		   return 1;		
		}
	}
}