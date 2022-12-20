import matplotlib.pyplot as plt
import pymongo
import datetime 
 
fig = plt.figure()
ax = fig.add_subplot(projection='3d')

client = pymongo.MongoClient("mongodb+srv://SDEBigData:SDEBigDataR25!@cluster0.mqllnbn.mongodb.net")
mydb = client["H4_Opgave"]

pipeline = [
   {
      "$lookup": 
       {
         "from": "SensorData",
         "localField": "Id",
         "foreignField": "DataPackageId",
         "as": "datapackage"
       }
   }
]
results = mydb["DataPackage"].aggregate(pipeline)
for x in results:
    if(len(x["datapackage"])>0):
        if(x["HubId"] == 1):
            temp = 0 
            light = 0
            for y in x["datapackage"]:
                if(y["SensorId"] == 1):
                    temp = y["Data"]
                if(y["SensorId"] == 3):
                    light = y["Data"]
            ax.scatter(x["Id"], temp , light)    
                

ax.set_xlabel('Id')
ax.set_ylabel('Temperture')
ax.set_zlabel('Light')

plt.show()

