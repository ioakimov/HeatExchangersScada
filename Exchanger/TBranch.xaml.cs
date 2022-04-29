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
	/// Interaction logic for TBranch.xaml
	/// </summary>
	public partial class TBranch : UserControl , IBaseWaterControl
	{
		public TBranch()
		{
			this.InitializeComponent();
		}
		
		public byte CountOfWaterInputs
		{
			get
			{
				return MaxCountOfInputs;
			}
			set
			{
			  if(value <= 2 && value > 0)
			  {
			    CountOfInputs = value;
		        MaxCountOfInputs = value;
			  }
			}
		
		}
			
		private byte CountOfInputs = 1;
		private byte MaxCountOfInputs = 1;
		
		public void ActivateState(int NewState)
		{
			/*switch(NewState)
			{
				case 0:
					if(CurentControlState == 1){ CurentControlState = 0; }
					break;	
				case 1:
					if(CurentControlState == 0){ CurentControlState = 1; }
					break;
			}
			*/
		}
		public void ActivateWaterState(int NewState)
		{
			switch(NewState)
			{
				case 0:
					if(CountOfInputs > 0)CountOfInputs--;
					if(CurentControlWaterState == 1 && CountOfInputs == 0){ CurentControlWaterState = 0; StopWaterSteamInNextControls();}
					break;	
				case 1:
					if(CountOfInputs < MaxCountOfInputs)CountOfInputs++;
					if(CurentControlWaterState == 0 && CountOfInputs > 0){ CurentControlWaterState = 1; RunWaterSteamInNextControls(); }
					break;
			}
		}
		//**********************************************************************************************************
		//*Стандартный блок , включающий  функции реализующие возможность лавинооразного выключения воды в системе.*
		//**********************************************************************************************************
		//private byte CurentControlState = 1;
		private byte CurentControlWaterState = 1;
		private byte CountOfNextWaterControls = 0;
		private IBaseWaterControl[] NextWaterControl = new IBaseWaterControl[2];
		
		public IBaseWaterControl GetNextWaterControl(int NumOfWaterControl)
		{
			if(NumOfWaterControl > CountOfNextWaterControls || NumOfWaterControl < 1)
				return null; 
			else return NextWaterControl[NumOfWaterControl - 1];
		}
		
		public bool SetNextWaterControl(int NumOfWaterControl , IBaseWaterControl LinkToWaterControl)
		{
			if(NumOfWaterControl > 2 || NumOfWaterControl < 1)
				return false; 
			else 
			{
				if(NextWaterControl[NumOfWaterControl - 1] == null && LinkToWaterControl != null)
				{
					CountOfNextWaterControls++;		
				}
				else
				if(NextWaterControl[NumOfWaterControl - 1] != null && LinkToWaterControl == null)
				{
					CountOfNextWaterControls--;
				}
				NextWaterControl[NumOfWaterControl - 1] = LinkToWaterControl;
			    return true;
			}
		}
		   
		public int StopWaterSteam()
		{ 
		   ActivateWaterState(0);
		   return 0;
		}
		
		public int RunWaterSteam()
		{ 
		   ActivateWaterState(1);
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