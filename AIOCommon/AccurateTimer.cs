using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Threading;

/**
 * Code Project reference
 * High-Performance Timer in C# By Daniel Strigl - songuke edited
 * A C# class to provide exact time measurement in your applications. 
 * */
namespace AIOCommon
{
	/// <summary>
	/// Summary description for AccurateTimer.
	/// </summary>
	public class AccurateTimer
	{
		[DllImport("Kernel32.dll")]
		private static extern bool QueryPerformanceCounter(
			out long lpPerformanceCount);

		[DllImport("Kernel32.dll")]
		private static extern bool QueryPerformanceFrequency(
			out long lpFrequency);

		private long startTime, stopTime;
		private long freq;

		// Constructor
		public AccurateTimer()
		{
			startTime = 0;
			stopTime  = 0;

			if (QueryPerformanceFrequency(out freq) == false)
			{
				// high-performance counter not supported
				throw new Win32Exception();
			}
		}

		// Start the timer
		public void Start()
		{
			// lets do the waiting threads there work
			Thread.Sleep(0);

			QueryPerformanceCounter(out startTime);
		}

		// Stop the timer
		public void Stop()
		{
			QueryPerformanceCounter(out stopTime);
		}

		// Returns the duration of the timer (in seconds)
		public double Duration
		{
			get
			{
				return (double)(stopTime - startTime) / (double) freq;
			}
		}	
	}	
}
