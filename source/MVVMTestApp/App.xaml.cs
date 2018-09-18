﻿/************************************************************************

   AvalonDock

   Copyright (C) 2007-2013 Xceed Software Inc.

   This program is provided to you under the terms of the New BSD
   License (BSD) as published at http://avalondock.codeplex.com/license 

   For more features, controls, and fast professional support,
   pick up AvalonDock in Extended WPF Toolkit Plus at http://xceed.com/wpf_toolkit

   Stay informed: follow @datagrid on Twitter or Like facebook.com/datagrids

  **********************************************************************/

using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace AvalonDock.MVVMTestApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected static ILog Logger; // Enable debugging via Log4Net

        static App()
        {
            XmlConfigurator.Configure();   // Read Log4Net config from App.config file
            Logger = LogManager.GetLogger("default");
        }
    }
    
   protected override void OnStartup(StartupEventArgs e)
   {
      Application.Current.DispatcherUnhandledException +=
         new DispatcherUnhandledExceptionEventHandler(DispatcherUnhandledExceptionHandler);

      base.OnStartup(e);
   }

   void DispatcherUnhandledExceptionHandler(object sender, DispatcherUnhandledExceptionEventArgs args)
   {
      Logger.Error(args.Exception);
      
      args.Handled = true;
      // implement recovery
      // execution will now continue...
   }
}
