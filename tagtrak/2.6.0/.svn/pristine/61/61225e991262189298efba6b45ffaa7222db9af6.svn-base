Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.InAttribute
Imports System.Runtime.InteropServices.OutAttribute
Imports System.Runtime.InteropServices.DllImportAttribute

' Declares a class member for each structure element.
<StructLayout(LayoutKind.Sequential)> _
Public Class SystemTime

    Public Year As Short
    Public Month As Short
    Public DayOfWeek As Short
    Public Day As Short
    Public Hour As Short
    Public Minute As Short
    Public Second As Short
    Public Milliseconds As Short

End Class 'SystemTime

Public Class LibWrap
    ' Declares a managed prototype for the unmanaged function.
    Declare Sub GetSystemTime Lib "CoreDll.dll" (<[In](), Out()> ByVal st _
       As SystemTime)
    Declare Sub SetSystemTime Lib "CoreDll.dll" (<[In](), Out()> ByVal st _
      As SystemTime)
End Class 'LibWrap
