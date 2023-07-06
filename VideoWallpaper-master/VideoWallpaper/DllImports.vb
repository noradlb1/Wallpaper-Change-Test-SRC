Imports System
Imports System.Runtime.InteropServices
Imports System.Text

Namespace VideoWallpaper
    Module DllImports
        <DllImport("user32.dll")>
        Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
        End Function
        <DllImport("user32.dll")>
        Function FindWindowEx(ByVal parentHandle As IntPtr, ByVal childAfter As IntPtr, ByVal className As String, ByVal windowTitle As String) As IntPtr
        End Function
        <DllImport("user32.dll")>
        Function SendMessageTimeout(ByVal hWnd As IntPtr, ByVal uMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer, ByVal fuFlags As Integer, ByVal uTimeout As Integer, <Out> ByRef lpdwResult As StringBuilder) As IntPtr
        End Function
        <DllImport("user32.dll")>
        Function EnumWindows(ByVal ewp As EnumWindowsProc, ByVal lParam As Integer) As Integer
        End Function
        Public Delegate Function EnumWindowsProc(ByVal hwnd As IntPtr, ByVal lParam As IntPtr) As Boolean

        <DllImport("user32.dll")>
        Function ShowWindow(ByVal hWnd As IntPtr, ByVal nCmdShow As UInteger) As Boolean
        End Function
        <DllImport("user32.dll")>
        Function SetParent(ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As IntPtr
        End Function
    End Module
End Namespace
