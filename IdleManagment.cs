using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using TimeSheetControl.Object;
using TimeSheetControl.Repository;


namespace TimeSheetControl
{
    public sealed class IdleManagment
    {
        private static IdleManagment instance = null; 
        private static readonly object myLock = new object();
        private Boolean isInPause = false;
        private Double currentIdleTime = 0;
        private Sheet lastSheet; 

        private IdleManagment() { }
        public static IdleManagment getInstance() 
        { 
            lock (myLock) 
            {
                if (instance == null) instance = new IdleManagment();
                return instance; 
            } 
        }


        [DllImport("User32.dll")]
            private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        internal struct LASTINPUTINFO 
        {
            public uint cbSize;
            public uint dwTime;
        }


        public Double tmrIdle_Tick(object sender, EventArgs e)
        {

            // Get the system uptime
            int systemUptime = Environment.TickCount;
            // The tick at which the last input was recorded
            int LastInputTicks = 0;

            // The number of ticks that passed since last input
            int IdleTicks = 0;

            // Set the struct
            LASTINPUTINFO LastInputInfo = new LASTINPUTINFO();
            LastInputInfo.cbSize = (uint)Marshal.SizeOf(LastInputInfo);
            LastInputInfo.dwTime = 0;

            // If we have a value from the function
            if (GetLastInputInfo(ref LastInputInfo))
            {
                // Get the number of ticks at the point when the last activity was seen
                LastInputTicks = (int)LastInputInfo.dwTime;

                // Number of idle ticks = system uptime ticks - number of ticks at last input
                IdleTicks = systemUptime - LastInputTicks;

            }

            return (IdleTicks / 1000);
            // Set the labels; divide by 1000 to transform the milliseconds to seconds

            //lblSystemUptime.Text = Convert.ToString(systemUptime / 1000) + " seconds";
            //lblIdleTime.Text = Convert.ToString(IdleTicks / 1000) + " seconds";
            //lblLastInput.Text = "At second " + Convert.ToString(LastInputTicks / 1000);
        }

        public void idleManage(object sender, EventArgs e, Form1 form)
        {
            if (form.isCurrentlySheetActive() || isInPause)
            {
                Double idle = this.tmrIdle_Tick(sender, e);
                
                int paramIdleTime = Properties.Settings.Default.idelTime;

                //900000 = 15 min
                if (idle >= (paramIdleTime * 60) && isInPause == false)
                {
                    isInPause = true;
                    form.setDebutMessage("in pause now");
                    
                    //Save current sheet to restart it
                    this.lastSheet = ProjectRepository.getInstance().actualSheet;
                    
                    //Stop current sheet
                    form.stopCurrentSheet(paramIdleTime);
                }

                if (isInPause)
                {
                    if (idle > currentIdleTime)
                    {
                        currentIdleTime = idle;
                        form.setDebutMessage("in pause: currentIdle = " + currentIdleTime.ToString());
                    }
                    else {
                        DateTime startActive = new DateTime();
                        startActive = DateTime.Today.Add(Properties.Settings.Default.activeTimeFrom);

                        DateTime stopActive = new DateTime();
                        stopActive = DateTime.Today.Add(Properties.Settings.Default.activeTimeTo);

                        currentIdleTime = 0;

                        if (DateTime.Now.CompareTo(startActive) >= 0 && DateTime.Now.CompareTo(stopActive) <= 0)
                        {

                            isInPause = false;
                            form.setDebutMessage("out of pause");
                            //Restart last sheet
                            Sheet actualSheet = new Sheet();
                            actualSheet.start = DateTime.Now;
                            actualSheet.job = lastSheet.job;
                            actualSheet.job.task = lastSheet.job.task;
                            
                            form.startSheet(actualSheet);
                        }
                        else
                        {
                            isInPause = false;
                        }
                    }
                }
            }

        }
    }
}
