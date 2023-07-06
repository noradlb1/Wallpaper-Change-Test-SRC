Imports System
Imports System.Runtime.InteropServices

Namespace VideoWallpaper
    Public Class PowerStatusMonitor
        Private registrationHandle As IntPtr
        Private recipient As DEVICE_NOTIFY_SUBSCRIBE_PARAMETERS
        Private pRecipient As IntPtr
        Public callback As DeviceNotifyCallbackRoutine

        Public Sub New(ByVal callback As DeviceNotifyCallbackRoutine)
            Me.callback = callback
        End Sub

        Public Function Register() As Boolean
            registrationHandle = New IntPtr()
            recipient = New DEVICE_NOTIFY_SUBSCRIBE_PARAMETERS With {
                .Callback = callback,
                .Context = IntPtr.Zero
            }
            pRecipient = Marshal.AllocHGlobal(Marshal.SizeOf(recipient))
            Marshal.StructureToPtr(recipient, pRecipient, False)
            Dim result As UInteger = PowerRegisterSuspendResumeNotification(DEVICE_NOTIFY_CALLBACK, recipient, registrationHandle)
            Return result <> 0
        End Function

        Public Function UnRegister() As Boolean
            Dim result As UInteger = PowerUnregisterSuspendResumeNotification(registrationHandle)
            Marshal.FreeHGlobal(pRecipient)
            Return result <> 0
        End Function

        Public Const WM_POWERBROADCAST As Integer = 536
        Public Const PBT_APMPOWERSTATUSCHANGE As Integer = 10
        Public Const PBT_APMRESUMEAUTOMATIC As Integer = 18
        Public Const PBT_APMRESUMESUSPEND As Integer = 7
        Public Const PBT_APMSUSPEND As Integer = 4
        Public Const PBT_POWERSETTINGCHANGE As Integer = 32787
        Public Const DEVICE_NOTIFY_CALLBACK As Integer = 2
        Public Delegate Function DeviceNotifyCallbackRoutine(ByVal context As IntPtr, ByVal type As Integer, ByVal setting As IntPtr) As Integer

        <StructLayout(LayoutKind.Sequential)>
        Public Structure DEVICE_NOTIFY_SUBSCRIBE_PARAMETERS
            Public Callback As DeviceNotifyCallbackRoutine
            Public Context As IntPtr
        End Structure

        <DllImport("Powrprof.dll", SetLastError:=True)>
        Public Shared Function PowerRegisterSuspendResumeNotification(ByVal flags As UInteger, ByRef receipient As DEVICE_NOTIFY_SUBSCRIBE_PARAMETERS, ByRef registrationHandle As IntPtr) As UInteger
        End Function
        <DllImport("Powrprof.dll", SetLastError:=True)>
        Public Shared Function PowerUnregisterSuspendResumeNotification(ByRef registrationHandle As IntPtr) As UInteger
        End Function
    End Class
End Namespace
