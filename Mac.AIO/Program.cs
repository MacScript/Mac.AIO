﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using EnsoulSharp.SDK;
using Mac.AIO.Properties;

namespace Mac.AIO
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEvent.OnGameLoad += OnGameLoad;
        }
        [PermissionSet(SecurityAction.Assert, Unrestricted = true)]
        private static void OnGameLoad()
        {
            LoadDll(Resources.Mac_AIO, "Mac.AIO.Program");
        }

        private static void LoadDll(byte[] dll, string namespacePlusClass)
        {
            try
            {
                var a = Assembly.Load(dll);
                var myType = a.GetType(namespacePlusClass);
                var methon = myType.GetMethod("Main", BindingFlags.Public | BindingFlags.Static);

                if (methon != null)
                {
                    methon.Invoke(null, null);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
