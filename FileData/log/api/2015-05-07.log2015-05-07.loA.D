2015-05-07 19:32:38,569 INFO  File: Research.Api started
2015-05-07 19:32:38,585 INFO  File: DBSessionStorage.Purge
2015-05-07 19:32:38,596 INFO  File: db.config setting connection-string-regex is empty. Using default: (?:(?<engine>[^|]+?)\|)?(?<conn>[^|]+)
2015-05-07 19:32:38,602 INFO  File: iConnectionStringPreparer IS NULL, using StandardConnectionStringPreparer.Instance
2015-05-07 19:32:38,606 INFO  File: Decrypting connection string dbId=default
2015-05-07 19:32:38,628 INFO  File: Config section 'encrypting' not found. Check web.config!
2015-05-07 19:32:38,685 INFO  File: System.Exception: Error 'Failed to load direct softAES dbAccess encrypting profile.' in method DevReactor.Toolbox.BO.Database.ConnectionInfo+StandardConnectionStringPreparer.decryptPwd ---> System.Exception: Failed to load direct softAES dbAccess encrypting profile. ---> System.NullReferenceException: Object reference not set to an instance of an object.
   at DevReactor.Toolbox.BO.Database.ConnectionInfo.StandardConnectionStringPreparer.decryptPwd(String pwdSrc)
   --- End of inner exception stack trace ---
   --- End of inner exception stack trace ---
2015-05-07 19:32:38,706 INFO  File: System.Exception: Error 'Object reference not set to an instance of an object.' in method DevReactor.Toolbox.BO.Database.ConnectionInfo+StandardConnectionStringPreparer.decryptPwd ---> System.NullReferenceException: Object reference not set to an instance of an object.
   at DevReactor.Toolbox.BO.Database.ConnectionInfo.StandardConnectionStringPreparer.decryptPwd(String pwdSrc)
   --- End of inner exception stack trace ---
2015-05-07 19:32:38,710 INFO  File: Error decrypting db password. Using password as is.
2015-05-07 19:32:38,716 INFO  File: m_connectionStringsPrepared.Add(Server=.\SQL2012;User ID=sa;password=scauser1991;Database=ndr;Persist Security Info=True, Data Source=.\SQL2012;Initial Catalog=ndr;Persist Security Info=True;User ID=sa;Password=scauser1991)
2015-05-07 19:32:38,774 INFO  File: toolbox-command-timeout=30
2015-05-07 19:32:38,899 INFO  File: 
--Connection Open #21653700 MSSQL|default|Data Source=.\SQL2012;Initial Catalog=ndr;Persist Security Info=True;User ID=sa;Password=scauser1991
--Execution result: Failure
EXEC websession_purge

2015-05-07 19:32:38,909 ERROR File: Error 'Direct.Exec: websession_purge' in method DevReactor.Toolbox.BO.Database.Direct.Exec
System.Exception: Direct.Exec: websession_purge ---> System.Data.SqlClient.SqlException: Could not find stored procedure 'websession_purge'.
   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   at System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   at System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean asyncWrite)
   at System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean asyncWrite)
   at System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   at DevReactor.Toolbox.BO.Database.MSSQL.Connection.ExecuteNonQuery(Command cmd)
   at DevReactor.Toolbox.BO.Database.Command.ExecuteNonQuery()
   at DevReactor.Toolbox.BO.Database.Direct.Exec(String dbId, IConnectionStringPreparer iConnectionStringPreparer, String query, PrepareCmd _prepareCmd, SPResultType resultType, CallingConvention callingConvention)
   --- End of inner exception stack trace ---
2015-05-07 19:32:38,926 ERROR File: Error 'Could not find stored procedure 'websession_purge'.' in method DevReactor.Toolbox.API.Sessions.DBSessionStorage.Purge
System.Data.SqlClient.SqlException (0x80131904): Could not find stored procedure 'websession_purge'.
   at DevReactor.Toolbox.BO.Database.Direct.Exec(String dbId, IConnectionStringPreparer iConnectionStringPreparer, String query, PrepareCmd _prepareCmd, SPResultType resultType, CallingConvention callingConvention)
   at DevReactor.Toolbox.BO.Database.Direct.Sp(String dbId, IConnectionStringPreparer iConnectionStringPreparer, String sp, PrepareCmd _prepareCmd, SPResultType resultType, CallingConvention callingConvention)
   at DevReactor.Toolbox.API.Sessions.DB.Websession.Purge()
   at DevReactor.Toolbox.API.Sessions.DBSessionStorage.Purge()
ClientConnectionId:234fb021-2198-47e2-b569-ce3a856b5027
2015-05-07 19:35:38,694 INFO  File: Research.Api started
2015-05-07 19:35:38,709 INFO  File: DBSessionStorage.Purge
2015-05-07 19:35:38,719 INFO  File: db.config setting connection-string-regex is empty. Using default: (?:(?<engine>[^|]+?)\|)?(?<conn>[^|]+)
2015-05-07 19:35:38,725 INFO  File: iConnectionStringPreparer IS NULL, using StandardConnectionStringPreparer.Instance
2015-05-07 19:35:38,730 INFO  File: Decrypting connection string dbId=default
2015-05-07 19:35:38,741 INFO  File: Config section 'encrypting' not found. Check web.config!
2015-05-07 19:35:38,772 INFO  File: System.Exception: Error 'Failed to load direct softAES dbAccess encrypting profile.' in method DevReactor.Toolbox.BO.Database.ConnectionInfo+StandardConnectionStringPreparer.decryptPwd ---> System.Exception: Failed to load direct softAES dbAccess encrypting profile. ---> System.NullReferenceException: Object reference not set to an instance of an object.
   at DevReactor.Toolbox.BO.Database.ConnectionInfo.StandardConnectionStringPreparer.decryptPwd(String pwdSrc)
   --- End of inner exception stack trace ---
   --- End of inner exception stack trace ---
2015-05-07 19:35:38,795 INFO  File: System.Exception: Error 'Object reference not set to an instance of an object.' in method DevReactor.Toolbox.BO.Database.ConnectionInfo+StandardConnectionStringPreparer.decryptPwd ---> System.NullReferenceException: Object reference not set to an instance of an object.
   at DevReactor.Toolbox.BO.Database.ConnectionInfo.StandardConnectionStringPreparer.decryptPwd(String pwdSrc)
   --- End of inner exception stack trace ---
2015-05-07 19:35:38,800 INFO  File: Error decrypting db password. Using password as is.
2015-05-07 19:35:38,805 INFO  File: m_connectionStringsPrepared.Add(Server=.\SQL2012;User ID=sa;password=scauser1991;Database=ndr;Persist Security Info=True, Data Source=.\SQL2012;Initial Catalog=ndr;Persist Security Info=True;User ID=sa;Password=scauser1991)
2015-05-07 19:35:38,828 INFO  File: toolbox-command-timeout=30
2015-05-07 19:35:38,911 INFO  File: 
--Connection Open #21653700 MSSQL|default|Data Source=.\SQL2012;Initial Catalog=ndr;Persist Security Info=True;User ID=sa;Password=scauser1991
--Execution result: Failure
EXEC websession_purge

2015-05-07 19:35:38,917 ERROR File: Error 'Direct.Exec: websession_purge' in method DevReactor.Toolbox.BO.Database.Direct.Exec
System.Exception: Direct.Exec: websession_purge ---> System.Data.SqlClient.SqlException: Could not find stored procedure 'websession_purge'.
   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   at System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   at System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean asyncWrite)
   at System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean asyncWrite)
   at System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   at DevReactor.Toolbox.BO.Database.MSSQL.Connection.ExecuteNonQuery(Command cmd)
   at DevReactor.Toolbox.BO.Database.Command.ExecuteNonQuery()
   at DevReactor.Toolbox.BO.Database.Direct.Exec(String dbId, IConnectionStringPreparer iConnectionStringPreparer, String query, PrepareCmd _prepareCmd, SPResultType resultType, CallingConvention callingConvention)
   --- End of inner exception stack trace ---
2015-05-07 19:35:38,933 ERROR File: Error 'Could not find stored procedure 'websession_purge'.' in method DevReactor.Toolbox.API.Sessions.DBSessionStorage.Purge
System.Data.SqlClient.SqlException (0x80131904): Could not find stored procedure 'websession_purge'.
   at DevReactor.Toolbox.BO.Database.Direct.Exec(String dbId, IConnectionStringPreparer iConnectionStringPreparer, String query, PrepareCmd _prepareCmd, SPResultType resultType, CallingConvention callingConvention)
   at DevReactor.Toolbox.BO.Database.Direct.Sp(String dbId, IConnectionStringPreparer iConnectionStringPreparer, String sp, PrepareCmd _prepareCmd, SPResultType resultType, CallingConvention callingConvention)
   at DevReactor.Toolbox.API.Sessions.DB.Websession.Purge()
   at DevReactor.Toolbox.API.Sessions.DBSessionStorage.Purge()
ClientConnectionId:e20af184-7384-4494-b011-80973df75147
2015-05-07 19:37:12,615 INFO  File: Research.Api started
2015-05-07 19:37:12,654 INFO  File: DBSessionStorage.Purge
2015-05-07 19:37:12,669 INFO  File: db.config setting connection-string-regex is empty. Using default: (?:(?<engine>[^|]+?)\|)?(?<conn>[^|]+)
2015-05-07 19:37:12,676 INFO  File: iConnectionStringPreparer IS NULL, using StandardConnectionStringPreparer.Instance
2015-05-07 19:37:12,683 INFO  File: Decrypting connection string dbId=default
2015-05-07 19:37:12,838 INFO  File: Config section 'encrypting' not found. Check web.config!
2015-05-07 19:37:12,875 INFO  File: System.Exception: Error 'Failed to load direct softAES dbAccess encrypting profile.' in method DevReactor.Toolbox.BO.Database.ConnectionInfo+StandardConnectionStringPreparer.decryptPwd ---> System.Exception: Failed to load direct softAES dbAccess encrypting profile. ---> System.NullReferenceException: Object reference not set to an instance of an object.
   at DevReactor.Toolbox.BO.Database.ConnectionInfo.StandardConnectionStringPreparer.decryptPwd(String pwdSrc)
   --- End of inner exception stack trace ---
   --- End of inner exception stack trace ---
2015-05-07 19:37:12,894 INFO  File: System.Exception: Error 'Object reference not set to an instance of an object.' in method DevReactor.Toolbox.BO.Database.ConnectionInfo+StandardConnectionStringPreparer.decryptPwd ---> System.NullReferenceException: Object reference not set to an instance of an object.
   at DevReactor.Toolbox.BO.Database.ConnectionInfo.StandardConnectionStringPreparer.decryptPwd(String pwdSrc)
   --- End of inner exception stack trace ---
2015-05-07 19:37:12,900 INFO  File: Error decrypting db password. Using password as is.
2015-05-07 19:37:12,906 INFO  File: m_connectionStringsPrepared.Add(Server=.\SQL2012;User ID=sa;password=scauser1991;Database=ndr;Persist Security Info=True, Data Source=.\SQL2012;Initial Catalog=ndr;Persist Security Info=True;User ID=sa;Password=scauser1991)
2015-05-07 19:37:12,939 INFO  File: toolbox-command-timeout=30
2015-05-07 19:37:13,024 INFO  File: 
--Connection Open #47501665 MSSQL|default|Data Source=.\SQL2012;Initial Catalog=ndr;Persist Security Info=True;User ID=sa;Password=scauser1991
--Execution result: Failure
EXEC websession_purge

2015-05-07 19:37:13,030 ERROR File: Error 'Direct.Exec: websession_purge' in method DevReactor.Toolbox.BO.Database.Direct.Exec
System.Exception: Direct.Exec: websession_purge ---> System.Data.SqlClient.SqlException: Could not find stored procedure 'websession_purge'.
   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   at System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   at System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean asyncWrite)
   at System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean asyncWrite)
   at System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   at DevReactor.Toolbox.BO.Database.MSSQL.Connection.ExecuteNonQuery(Command cmd)
   at DevReactor.Toolbox.BO.Database.Command.ExecuteNonQuery()
   at DevReactor.Toolbox.BO.Database.Direct.Exec(String dbId, IConnectionStringPreparer iConnectionStringPreparer, String query, PrepareCmd _prepareCmd, SPResultType resultType, CallingConvention callingConvention)
   --- End of inner exception stack trace ---
2015-05-07 19:37:13,046 ERROR File: Error 'Could not find stored procedure 'websession_purge'.' in method DevReactor.Toolbox.API.Sessions.DBSessionStorage.Purge
System.Data.SqlClient.SqlException (0x80131904): Could not find stored procedure 'websession_purge'.
   at DevReactor.Toolbox.BO.Database.Direct.Exec(String dbId, IConnectionStringPreparer iConnectionStringPreparer, String query, PrepareCmd _prepareCmd, SPResultType resultType, CallingConvention callingConvention)
   at DevReactor.Toolbox.BO.Database.Direct.Sp(String dbId, IConnectionStringPreparer iConnectionStringPreparer, String sp, PrepareCmd _prepareCmd, SPResultType resultType, CallingConvention callingConvention)
   at DevReactor.Toolbox.API.Sessions.DB.Websession.Purge()
   at DevReactor.Toolbox.API.Sessions.DBSessionStorage.Purge()
ClientConnectionId:58789dcb-e895-4d35-a7da-74ff04aeac80
2015-05-07 19:38:20,489 INFO  File: Research.Api started
2015-05-07 19:38:20,531 INFO  File: DBSessionStorage.Purge
2015-05-07 19:38:20,541 INFO  File: db.config setting connection-string-regex is empty. Using default: (?:(?<engine>[^|]+?)\|)?(?<conn>[^|]+)
2015-05-07 19:38:20,549 INFO  File: iConnectionStringPreparer IS NULL, using StandardConnectionStringPreparer.Instance
2015-05-07 19:38:20,554 INFO  File: Decrypting connection string dbId=default
2015-05-07 19:38:20,733 INFO  File: Config section 'encrypting' not found. Check web.config!
2015-05-07 19:38:20,786 INFO  File: System.Exception: Error 'Failed to load direct softAES dbAccess encrypting profile.' in method DevReactor.Toolbox.BO.Database.ConnectionInfo+StandardConnectionStringPreparer.decryptPwd ---> System.Exception: Failed to load direct softAES dbAccess encrypting profile. ---> System.NullReferenceException: Object reference not set to an instance of an object.
   at DevReactor.Toolbox.BO.Database.ConnectionInfo.StandardConnectionStringPreparer.decryptPwd(String pwdSrc)
   --- End of inner exception stack trace ---
   --- End of inner exception stack trace ---
2015-05-07 19:38:20,816 INFO  File: System.Exception: Error 'Object reference not set to an instance of an object.' in method DevReactor.Toolbox.BO.Database.ConnectionInfo+StandardConnectionStringPreparer.decryptPwd ---> System.NullReferenceException: Object reference not set to an instance of an object.
   at DevReactor.Toolbox.BO.Database.ConnectionInfo.StandardConnectionStringPreparer.decryptPwd(String pwdSrc)
   --- End of inner exception stack trace ---
2015-05-07 19:38:20,822 INFO  File: Error decrypting db password. Using password as is.
2015-05-07 19:38:20,830 INFO  File: m_connectionStringsPrepared.Add(Server=.\SQL2012;User ID=sa;password=scauser1991;Database=ndr;Persist Security Info=True, Data Source=.\SQL2012;Initial Catalog=ndr;Persist Security Info=True;User ID=sa;Password=scauser1991)
2015-05-07 19:38:20,877 INFO  File: toolbox-command-timeout=30
2015-05-07 19:38:20,988 INFO  File: 
--Connection Open #47501665 MSSQL|default|Data Source=.\SQL2012;Initial Catalog=ndr;Persist Security Info=True;User ID=sa;Password=scauser1991
--Execution result: Failure
EXEC websession_purge

2015-05-07 19:38:21,002 ERROR File: Error 'Direct.Exec: websession_purge' in method DevReactor.Toolbox.BO.Database.Direct.Exec
System.Exception: Direct.Exec: websession_purge ---> System.Data.SqlClient.SqlException: Could not find stored procedure 'websession_purge'.
   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   at System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   at System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean asyncWrite)
   at System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean asyncWrite)
   at System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   at DevReactor.Toolbox.BO.Database.MSSQL.Connection.ExecuteNonQuery(Command cmd)
   at DevReactor.Toolbox.BO.Database.Command.ExecuteNonQuery()
   at DevReactor.Toolbox.BO.Database.Direct.Exec(String dbId, IConnectionStringPreparer iConnectionStringPreparer, String query, PrepareCmd _prepareCmd, SPResultType resultType, CallingConvention callingConvention)
   --- End of inner exception stack trace ---
2015-05-07 19:38:21,047 ERROR File: Error 'Could not find stored procedure 'websession_purge'.' in method DevReactor.Toolbox.API.Sessions.DBSessionStorage.Purge
System.Data.SqlClient.SqlException (0x80131904): Could not find stored procedure 'websession_purge'.
   at DevReactor.Toolbox.BO.Database.Direct.Exec(String dbId, IConnectionStringPreparer iConnectionStringPreparer, String query, PrepareCmd _prepareCmd, SPResultType resultType, CallingConvention callingConvention)
   at DevReactor.Toolbox.BO.Database.Direct.Sp(String dbId, IConnectionStringPreparer iConnectionStringPreparer, String sp, PrepareCmd _prepareCmd, SPResultType resultType, CallingConvention callingConvention)
   at DevReactor.Toolbox.API.Sessions.DB.Websession.Purge()
   at DevReactor.Toolbox.API.Sessions.DBSessionStorage.Purge()
ClientConnectionId:e9c5373a-fb3b-4f2d-9b97-bdd387041b5d
