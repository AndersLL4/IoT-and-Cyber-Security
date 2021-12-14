import numpy as np
import matplotlib.pyplot as plt
from opcua import Server
from time import sleep
import matplotlib.animation as animation
from matplotlib import style
import datetime

server = Server()
server_url = "opc.tcp://localhost:4840" # define opc server url //"opc.tcp://127.0.0.1:4840"
server.set_endpoint(server_url) #create server endpoint

name ="Local_OPC_Server"
add_namespace = server.register_namespace(name) #define servers namespace

node = server.get_objects_node() #get root node

param = node.add_object(add_namespace, "Parameters")

#define nodes
Temp = param.add_variable(add_namespace, "Temperature",0)
Time = param.add_variable(add_namespace, "Time", 0)


#set nodes to writable
Temp.set_writable()
Time.set_writable()

#start server
server.start()


#simultation parameters
style.use("fivethirtyeight")
Ts = 1 # Sampling Time
Tstop = 120 #simulation stop time
uk = 1 #step response
N = int(Tstop/Ts) #sim lenght
Tout = np.zeros(N+2) #Tout vector
Tout[0] = 0 #initial value

#controller parameters
r = 23 #setpoint/refrence value
Kp = 0.8 #gain
Ti = 20 #integraiton time
e = np.zeros(N+2) # Init
u = np.zeros(N+2) # Init


#Air heater model
Kh = 3.5
theta_t =22
theta_d = 2
Tenv = 22

t = np.arange(0,Tstop+2*Ts,Ts) #Create the Time Series for x axis
ul = [] #list for controll signal
templ =[] #list for temperature 
tl = [] #list for timestep

#simulation
for k in range(N+1):
    TIME = datetime.datetime.now()
    
    e[k] = r - Tout[k]
    u[k] = u[k-1] + Kp*(e[k] - e[k-1]) + (Kp/Ti)*e[k]
    
    if u[k]>5: #u between 0-5
        u[k] = 5
    if u[k]<0:
        u[k] = 0
    
    Tout[k+1] = Tout[k] + (Ts/theta_t) * (-Tout[k] + Kh*uk + Tenv)

    
    Temp.set_value(Tout[k])
    Time.set_value(TIME)
    print(Tout[k], TIME)
    sleep(1)

server.stop()