﻿using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.UI.Xaml;

namespace HachodromoMobile.WinUI
{
	public partial class App : MauiWinUIApplication
	{
		public App()
		{
			this.InitializeComponent();
		}

		protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
	}
}
