Const OWN_PROCESS = 16
Const NOT_INTERACTIVE = False
Const NORMAL_ERROR_CONTROL = 2
Const PATH_TO_SERVICE_EXE = "D:\Projects\Scheduler-Boilerplate\UnknownScheduler\bin\Debug\UnknownScheduler.exe"
Const ServiceName = "ExampleService"
Const RunType = "Manual"
strComputer = "."

Set objWMIService = GetObject("winmgmts:" _
    & "{impersonationLevel=impersonate}!\\" & strComputer & "\root\cimv2")
Set objService = objWMIService.Get("Win32_BaseService")

errReturn = objService.Create(ServiceName , ServiceName , _
    PATH_TO_SERVICE_EXE , OWN_PROCESS, NORMAL_ERROR_CONTROL,_
        RunType , NOT_INTERACTIVE, null, null  )

Select Case errReturn
Case 0
	WScript.Echo "The request was accepted."
Case 1
	WScript.Echo "The request is not supported."
Case 2  
   	WScript.Echo "The user did not have the necessary access."
Case 3
	WScript.Echo "The service cannot be stopped because other services that are running are dependent on it."
Case 4
	WScript.Echo "The requested control code is not valid, or it is unacceptable to the service."
Case 5  
   	WScript.Echo "The requested control code cannot be sent to the service because the state of the service (Win32_BaseServiceState property) is equal to 0, 1, or 2."
Case 6
	WScript.Echo "The service has not been started."
Case 7
	WScript.Echo "The service did not respond to the start request in a timely fashion."
Case 8  
   	WScript.Echo "Interactive process."
Case 9
	WScript.Echo "The directory path to the service executable file was not found."
Case 10
	WScript.Echo "The service is already running."
Case 11  
   	WScript.Echo "The database to add a new service is locked."
Case 12
	WScript.Echo "A dependency on which this service relies has been removed from the system."
Case 13
	WScript.Echo "The service failed to find the service needed from a dependent service."
Case 14  
   	WScript.Echo "The service has been disabled from the system."
Case 15
	WScript.Echo "The service does not have the correct authentication to run on the system."
Case 16
	WScript.Echo "This service is being removed from the system."
Case 17  
   	WScript.Echo "There is no execution thread for the service."
Case 18
	WScript.Echo "There are circular dependencies when starting the service."
Case 19
	WScript.Echo "There is a service running under the same name."
Case 20  
   	WScript.Echo "There are invalid characters in the name of the service."
Case 21
	WScript.Echo "Invalid parameters have been passed to the service."
Case 22
	WScript.Echo "The account which this service is to run under is either invalid or lacks the permissions to run the service."
Case 23  
   	WScript.Echo "The service exists in the database of services available from the system."
Case 24
	WScript.Echo "The service is currently paused in the system."

End Select