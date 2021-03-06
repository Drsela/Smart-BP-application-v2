﻿using System.Runtime.InteropServices;

namespace Mock_up_GUI
{
    internal class Taskbar
    {
        private const int SW_HIDE = 0;
        private const int SW_SHOW = 1;

        private Taskbar()
        {
            // hide ctor
        }

        protected static int Handle => FindWindow("Shell_TrayWnd", "");

        protected static int HandleOfStartButton
        {
            get
            {
                var handleOfDesktop = GetDesktopWindow();
                var handleOfStartButton = FindWindowEx(handleOfDesktop, 0, "button", 0);
                return handleOfStartButton;
            }
        }

        [DllImport("user32.dll")]
        private static extern int FindWindow(string className, string windowText);

        [DllImport("user32.dll")]
        private static extern int ShowWindow(int hwnd, int command);

        [DllImport("user32.dll")]
        public static extern int FindWindowEx(int parentHandle, int childAfter, string className, int windowTitle);

        [DllImport("user32.dll")]
        private static extern int GetDesktopWindow();

        public static void Show()
        {
            ShowWindow(Handle, SW_SHOW);
            ShowWindow(HandleOfStartButton, SW_SHOW);
        }

        public static void Hide()
        {
            ShowWindow(Handle, SW_HIDE);
            ShowWindow(HandleOfStartButton, SW_HIDE);
        }
    }
}