import csv
import pymongo
 
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
with open('DataVisualer\data.csv', 'w', newline='') as file:
    writer = csv.writer(file)
    writer.writerow(["Temperature", "Light"])
    results = mydb["DataPackage"].aggregate(pipeline)
    for x in results:
        if(len(x["datapackage"])>0):
            if(x["HubId"] == 1):
                temp = 0 
                light = 0
                for y in x["datapackage"]:
                    if(y["SensorId"] == 1):
                        temp = round(y["Data"],2)
                    if(y["SensorId"] == 3):
                        light = round(y["Data"],2)
                writer.writerow([temp,light])
            