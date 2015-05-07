﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Zza.Services;

namespace Zza.SelfHost
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				ServiceHost host = new ServiceHost(typeof(ZzaService));

				host.Open();
				Console.WriteLine("Hit any key to exit");
				Console.ReadKey();
				host.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}
