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
	/// Interaction logic for AutomaticControlPoint_SmokeGases.xaml
	/// </summary>
	public partial class AutomaticControlPoint_SmokeGases : UserControl
	{
		public AutomaticControlPoint_SmokeGases()
		{
			this.InitializeComponent();
			this.HotExchengerControl1.MainExchanger.SetBrushMode(1);
			//**********************************************************************************************************
			//*                              Источник воды №1 (нижний, слева)                                           *
			//**********************************************************************************************************
			this.WaterSource1_Valve1.SetNextWaterControl(1,this.WaterSource1_Pipe1);
			this.WaterSource1_Pipe1.SetNextWaterControl(1,this.WaterSource1_TBranch1);
			this.WaterSource1_TBranch1.SetNextWaterControl(1,this.WaterSource1_Pipe2);
			this.WaterSource1_TBranch1.SetNextWaterControl(2,this.WaterSource1_Pipe4);
			
			this.WaterSource1_Pipe2.SetNextWaterControl(1,this.WaterSource1_Valve2);
			this.WaterSource1_Valve2.SetNextWaterControl(1,this.WaterSource1_Corner2);
			this.WaterSource1_Corner2.ActivateState(0);
			this.WaterSource1_Corner2.SetNextWaterControl(1,this.WaterSource1_Pipe3);
			
			
			this.WaterSource1_Pipe4.SetNextWaterControl(1,this.WaterSource1_Corner1);
			this.WaterSource1_Corner1.SetNextWaterControl(1,this.WaterSource1_Valve3);
			this.WaterSource1_Valve3.SetNextWaterControl(1,this.WaterSource1_Pump1);
			this.WaterSource1_Pump1.SetNextWaterControl(1,this.WaterSource1_Pipe5);
			this.WaterSource1_Pipe5.SetNextWaterControl(1,this.WaterSource1_Valve4);
			
			this.WaterSource1_Pipe3.SetNextWaterControl(1,this.WaterSource1_TBranch2);
			this.WaterSource1_Valve4.SetNextWaterControl(1,this.WaterSource1_TBranch2);
			this.WaterSource1_TBranch2.CountOfWaterInputs = 2;
			this.WaterSource1_TBranch2.SetNextWaterControl(1,this.WaterSource1_Pipe6);
			
			this.WaterSource1_Pipe1.PipeWave.SetColorMode(3);
			this.WaterSource1_Pipe2.PipeWave.SetColorMode(3);
			this.WaterSource1_Pipe3.PipeWave.SetColorMode(3);
			this.WaterSource1_Pipe4.PipeWave.SetColorMode(3);
			this.WaterSource1_Pipe5.PipeWave.SetColorMode(3);
			this.WaterSource1_Pipe6.PipeWave.SetColorMode(3);
			this.WaterSource1_Pump1.ButtomPart.PipeWave.SetColorMode(3);	
			
			this.WaterSource1_Pipe6.SetNextWaterControl(1,this.HotExchengerControl2.ValveColdIn);		
			
			//**********************************************************************************************************
			//*                              Поток дымовых газов №1 (верхний)                                          *
			//**********************************************************************************************************
			this.HotChanel1_Valve1.SetNextWaterControl(1,this.HotChanel1_TBranch1);
			this.HotChanel1_TBranch1.SetNextWaterControl(1,this.HotChanel1_Valve2);
			this.HotChanel1_TBranch1.SetNextWaterControl(2,this.HotChanel1_PipeInExchanger1);
			this.HotChanel1_PipeInExchanger1.SetNextWaterControl(1,this.HotChanel1_CornerInExchanger1);
			this.HotChanel1_Valve2.SetNextWaterControl(1,this.HotChanel1_Pipe1);
			this.HotChanel1_Pipe1.PipeWave.SetColorMode(2);
			this.HotChanel1_Pipe1.PipeWave.SetRightToLeftMode();
			this.HotChanel1_Pipe1.SetNextWaterControl(1,this.HotChanel1_TBranch2);
			this.HotChanel1_CornerOutExchanger1.SetNextWaterControl(1,this.HotChanel1_PipeOutExchanger1);
			this.HotChanel1_PipeOutExchanger1.SetNextWaterControl(1,this.HotChanel1_TBranch2);
			this.HotChanel1_TBranch2.CountOfWaterInputs = 2;
			this.HotChanel1_TBranch2.SetNextWaterControl(1,this.HotChanel1_Pipe2);
			this.HotChanel1_Pipe2.PipeWave.SetColorMode(2);
			this.HotChanel1_Pipe2.PipeWave.SetRightToLeftMode();
			this.HotChanel1_Pipe2.SetNextWaterControl(1,this.HotChanel1_Pipe3);
			this.HotChanel1_Pipe3.PipeWave.SetColorMode(2);
			this.HotChanel1_Pipe3.PipeWave.SetRightToLeftMode();
			this.HotChanel1_Pipe3.SetNextWaterControl(1,this.HotChanel1_Valve3);
			
			this.HotChanel1_PipeInExchanger1.PipeWave.SetColorMode(2);
			this.HotChanel1_PipeOutExchanger1.PipeWave.SetColorMode(2);
			this.HotChanel1_PipeOutExchanger1.PipeWave.SetRightToLeftMode();
			
			this.HotChanel1_CornerInExchanger1.SetNextWaterControl(1,this.HotExchengerControl1.ValveHotIn);
			this.HotExchengerControl1.ValveHotOut.SetNextWaterControl(1,this.HotChanel1_CornerOutExchanger1);
			//**********************************************************************************************************
			//*                              Поток дымовых газов №2 (нижний)                                           *
			//**********************************************************************************************************
			this.HotChanel2_Valve1.SetNextWaterControl(1,this.HotChanel2_Pipe1);
			this.HotChanel2_Pipe1.PipeWave.SetColorMode(2);
			this.HotChanel2_Pipe1.SetNextWaterControl(1,this.HotChanel2_TBranch1);
			this.HotChanel2_TBranch1.SetNextWaterControl(1,this.HotChanel2_Valve2);
			this.HotChanel2_TBranch1.SetNextWaterControl(2,this.HotChanel2_PipeInExchanger1);
			this.HotChanel2_PipeInExchanger1.SetNextWaterControl(1,this.HotChanel2_CornerInExchanger1);
			this.HotChanel2_Valve2.SetNextWaterControl(1,this.HotChanel2_Pipe2);
			this.HotChanel2_Pipe2.PipeWave.SetColorMode(2);
			this.HotChanel2_Pipe2.SetNextWaterControl(1,this.HotChanel2_TBranch2);
			this.HotChanel2_CornerOutExchanger1.SetNextWaterControl(1,this.HotChanel2_PipeOutExchanger1);//!
			this.HotChanel2_PipeOutExchanger1.SetNextWaterControl(1,this.HotChanel2_TBranch2);
			this.HotChanel2_TBranch2.CountOfWaterInputs = 2;
			this.HotChanel2_TBranch2.SetNextWaterControl(1,this.HotChanel2_Pipe3);
			this.HotChanel2_Pipe3.PipeWave.SetColorMode(2);
			this.HotChanel2_Pipe3.SetNextWaterControl(1,this.HotChanel2_Valve3);
		
			this.HotChanel2_PipeInExchanger1.PipeWave.SetColorMode(2);
			this.HotChanel2_PipeOutExchanger1.PipeWave.SetColorMode(2);
			this.HotChanel2_PipeOutExchanger1.PipeWave.SetRightToLeftMode();
			
			this.HotChanel2_CornerInExchanger1.SetNextWaterControl(1,this.HotExchengerControl2.ValveHotIn);
			this.HotExchengerControl2.ValveHotOut.SetNextWaterControl(1,this.HotChanel2_CornerOutExchanger1);
			//**********************************************************************************************************
			//*                              Источник воды №2 (верхний, слева)                                         *
			//**********************************************************************************************************
			this.WaterSource2_Valve1.SetNextWaterControl(1,this.WaterSource2_TBranch1);
			this.WaterSource2_TBranch1.SetNextWaterControl(1,this.WaterSource2_Valve2);
			this.WaterSource2_TBranch1.SetNextWaterControl(2,this.WaterSource2_Pipe3);
			this.WaterSource2_Valve2.SetNextWaterControl(1,this.WaterSource2_Pump1);
			this.WaterSource2_Pump1.SetNextWaterControl(1,this.WaterSource2_Pipe1);
			this.WaterSource2_Pipe1.SetNextWaterControl(1,this.WaterSource2_Valve3);
			this.WaterSource2_Valve3.SetNextWaterControl(1,this.WaterSource2_Corner1);
			this.WaterSource2_Corner1.SetNextWaterControl(1,this.WaterSource2_Pipe2);
			this.WaterSource2_Pipe2.SetNextWaterControl(1,this.WaterSource2_TBranch3);//!
			
			this.WaterSource2_Pipe3.SetNextWaterControl(1,this.WaterSource2_TBranch2);
			this.WaterSource2_TBranch2.SetNextWaterControl(1,this.WaterSource2_Valve4);
			this.WaterSource2_TBranch2.SetNextWaterControl(2,this.WaterSource2_Pipe6);
			this.WaterSource2_Valve4.SetNextWaterControl(1,this.WaterSource2_Pump2);
			this.WaterSource2_Pump2.SetNextWaterControl(1,this.WaterSource2_Pipe4);
			this.WaterSource2_Pipe4.SetNextWaterControl(1,this.WaterSource2_Valve5);
			this.WaterSource2_Valve5.SetNextWaterControl(1,this.WaterSource2_TBranch3);//!
			this.WaterSource2_TBranch3.CountOfWaterInputs = 2;
			
			this.WaterSource2_TBranch3.SetNextWaterControl(1,this.WaterSource2_Pipe5);
			this.WaterSource2_Pipe5.SetNextWaterControl(1,this.WaterSource2_TBranch4);//!
			this.WaterSource2_Pipe6.SetNextWaterControl(1,this.WaterSource2_Corner2);
			this.WaterSource2_Corner2.SetNextWaterControl(1,this.WaterSource2_Valve6);
			this.WaterSource2_Valve6.SetNextWaterControl(1,this.WaterSource2_Pump3);
			this.WaterSource2_Pump3.SetNextWaterControl(1,this.WaterSource2_Pipe7);
			this.WaterSource2_Pipe7.SetNextWaterControl(1,this.WaterSource2_Valve7);
			this.WaterSource2_Valve7.SetNextWaterControl(1,this.WaterSource2_TBranch4);//!
			this.WaterSource2_TBranch4.CountOfWaterInputs = 2;
			
			this.WaterSource2_TBranch4.SetNextWaterControl(1,this.WaterSource2_Valve8);
			this.WaterSource2_Valve8.SetNextWaterControl(1,this.WaterSource2_Pipe8);
			this.WaterSource2_Pipe8.SetNextWaterControl(1,this.WaterSource2_TBranch5);
			this.WaterSource2_TBranch5.SetNextWaterControl(1,this.WaterSource2_Pipe9);
			this.WaterSource2_Pipe9.SetNextWaterControl(1,this.WaterSource2_Corner3);
			this.WaterSource2_Corner3.SetNextWaterControl(1,this.WaterSource2_Pipe10);
			this.WaterSource2_Pipe10.SetNextWaterControl(1,this.WaterSource2_Corner4);
			this.WaterSource2_Corner4.SetNextWaterControl(1,this.WaterSource2_Pipe11);
			this.WaterSource2_Pipe11.SetNextWaterControl(1,this.WaterSource2_Corner5);
			
			this.WaterSource2_Corner5.SetNextWaterControl(1,this.HotExchengerControl1.ValveColdIn);
			
			this.WaterSource2_TBranch5.CountOfWaterInputs = 2;
			this.HotExchengerControl2.ValveColdOut.SetNextWaterControl(1,this.WaterSource2_TBranch5);
			
			
			    this.WaterSource2_Pipe1.PipeWave.SetColorMode(1);
				this.WaterSource2_Pipe2.PipeWave.SetColorMode(1);
				this.WaterSource2_Pipe3.PipeWave.SetColorMode(1);
				this.WaterSource2_Pipe4.PipeWave.SetColorMode(1);
				this.WaterSource2_Pipe5.PipeWave.SetColorMode(1);
				this.WaterSource2_Pipe6.PipeWave.SetColorMode(1);
				this.WaterSource2_Pipe7.PipeWave.SetColorMode(1);
				this.WaterSource2_Pipe8.PipeWave.SetColorMode(1);
				this.WaterSource2_Pipe9.PipeWave.SetColorMode(1);
				this.WaterSource2_Pipe10.PipeWave.SetColorMode(1);
				this.WaterSource2_Pipe11.PipeWave.SetColorMode(1);
                this.WaterSource2_Pump1.ButtomPart.PipeWave.SetColorMode(1);
				this.WaterSource2_Pump2.ButtomPart.PipeWave.SetColorMode(1);
			    this.WaterSource2_Pump3.ButtomPart.PipeWave.SetColorMode(1);
			    this.HotExchengerControl1.MainExchanger.PipeWave1.Wave.SetColorMode(1);
				this.HotExchengerControl1.MainExchanger.PipeWave2.Wave.SetColorMode(1);
			    this.HotExchengerControl1.MainExchanger.PipeWave3.Wave.SetColorMode(1);
			    this.HotExchengerControl1.MainExchanger.PipeWave4.Wave.SetColorMode(1);
			    this.HotExchengerControl1.MainExchanger.PipeWave5.Wave.SetColorMode(1);
			    this.HotExchengerControl2.MainExchanger.PipeWave1.Wave.SetColorMode(1);
				this.HotExchengerControl2.MainExchanger.PipeWave2.Wave.SetColorMode(1);
			    this.HotExchengerControl2.MainExchanger.PipeWave3.Wave.SetColorMode(1);
			    this.HotExchengerControl2.MainExchanger.PipeWave4.Wave.SetColorMode(1);
			    this.HotExchengerControl2.MainExchanger.PipeWave5.Wave.SetColorMode(1);
			
			//**********************************************************************************************************
			//*         Исходящий источник гарячей воды, на который и работает вся схема (верхний, справа)             *
			//**********************************************************************************************************
			this.HotExchengerControl1.ValveColdOut.SetNextWaterControl(1,this.OutgoingSource_Corner1);
			this.OutgoingSource_Corner1.SetNextWaterControl(1,this.OutgoingSource_Pipe1);
			this.OutgoingSource_Pipe1.SetNextWaterControl(1,this.OutgoingSource_Valve1);
            
			this.OutgoingSource_Pipe1.PipeWave.SetColorMode(1);
			
		}
	}
}