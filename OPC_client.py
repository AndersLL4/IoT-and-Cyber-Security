from opcua import Client
import time
import pyodbc as db
import dbconnect

connectionString = dbconnect.GetConnectionString()
connString = str(connectionString)
sql_connect = db.connect(connString)
cursor =sql_connect.cursor()
query = "INSERT INTO AIRHEATER1 (Temperature, timestamp) VALUES (?,?)"

url = "opc.tcp://localhost:4840"
client = Client(url)

client.connect()
print("Client Connected")

try:
    while True:
        Temp = client.get_node("ns=2;i=2")
        Time = client.get_node("ns=2;i=3")
        Temp_value = Temp.get_value()
        TIME = Time.get_value()
        print(Temp_value, TIME)
        #print(Time)
   
        #insert data into database
        parameters = Temp_value, TIME
        cursor.execute(query, parameters)
        cursor.commit()
   
        time.sleep(1)

except KeyboardInterrupt:
    print("Press Ctrl-C to terminate while statement")
    client.disconnect()
    pass
    






























"""    
while True:
   Temp = client.get_node("ns=2;i=2")
   Time = client.get_node("ns=2;i=3")
   Temp_value = Temp.get_value()
   TIME = Time.get_value()
   print(Temp_value, TIME)
   #print(Time)
   
   #insert data into database
   parameters = Temp_value, TIME
   cursor
   
   time.sleep(1)
"""