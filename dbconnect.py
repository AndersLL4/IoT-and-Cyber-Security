def GetConnectionString():
    sql_driver = "{ODBC Driver 17 for SQL Server}"
    sql_server = "DESKTOP-NUQR2FV"
    sql_database = "AirHeater"
    sql_username = "xxx"
    sql_password = "xxx"
    connectionString =  "Driver=" + sql_driver + ";SERVER=" + "tcp:airheaterserverlab3.database.windows.net,1433" + ";DATABASE=" + "AIRHEATERDB" + ";UID=" + "ALL" + ";PWD=" + "HiJk1234"

    return connectionString
