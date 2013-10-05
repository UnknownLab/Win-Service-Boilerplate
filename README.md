Version 0.5

Services for Windows OS.

Boilerplate that helps create services.


For start example:
- Change "Const PATH_TO_SERVICE_EXE" in /install.vbs on your path
- execute install.vbs (only Admin access)
- Run service "ExampleService" in Control Panel -> Services
- See logs in Control Panel -> Event Viewer -> Application and Services Logs -> ExampleServiceLog

About solution:
- Service: abstract services. Usually they implement some type of activity (Now only scheduler).Have abstract settings
- Jobs: Actions for services. Usually they execute one task (for example: sending HTTP requests).Have abstract settings
- Solutions: Сoncrete services that executing concrete jobs. Implement abstact settings of Service and Jobs.
- MultiService: wrapper. Use if you what run many services in one real service.
- install.vbs & delete.vbs - create and delete Services in OS.
