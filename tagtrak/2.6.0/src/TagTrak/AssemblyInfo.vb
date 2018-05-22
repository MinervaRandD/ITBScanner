' Copyright (c) 2003-2004 Aviation Software, Inc.,
' All Rights Reserved. 
' Reproduction of this document in whole or in part without written permission of   
' Aviation Software, Inc. is strictly prohibited.
'
' Aviation Software, Inc., Confidential - Restricted Access
'
' This document contains proprietary information that shall be
' distributed or routed only within Aviation Software, Inc.,
' and its authorized clients, except with written permission of
' Aviation Software, Inc. 

' --------------------------------------------------------------------
' FILENAME: AssemblyInfo.vb
'
' Copyright(c) 2002 Symbol Technologies Inc. All rights reserved.
'
' DESCRIPTION:
'
' NOTES:
'
' 
'--------------------------------------------------------------------
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("")> 
<Assembly: AssemblyProduct("")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(True)> 

' Version information for an assembly consists of the following four values:
'
'      Major Version
'      Minor Version 
'      Build Number - Defaults to the number of days since Jan 1 2000.
'      Revision - Defaults to the number of seconds since midnight.
'
' You can specify all the values or you can default the Build and Revision Numbers 
' by using the '*' as shown below:

' Use the following to modify the Major and Minor version. Use TagTrakBaseConfigParms.vb to modify Revision.
<Assembly: AssemblyVersion("2.6.*")> 
' NOTE: TagTrak versions will be displayed as [Major].[Minor].[Revision].[Build]
'       The [Build] will be omitted in most places in the UI
'       for public distros, every public distribution should have a unique [Major].[Minor].[Revision] so the build will be irrelevant.
'       The [Build] is used to distinguish internal copies only, it is a calculated value based on the time of the compile.