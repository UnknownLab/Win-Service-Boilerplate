strComputer = "."

Set objWMIService = GetObject("winmgmts:" _
    & "{impersonationLevel=impersonate}!\\" & strComputer & "\root\cimv2")

Set colListOfServices = objWMIService.ExecQuery _
    ("Select * from Win32_Service Where Name = 'ExampleService'")

For Each objService in colListOfServices
    objService.StopService()
    objService.Delete()
Next
	