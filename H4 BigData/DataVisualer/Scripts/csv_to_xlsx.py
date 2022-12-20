import csv
from csv import reader

with open('DataVisualer\Alldata.csv', 'w', newline='') as file:
    writer = csv.writer(file)
    writer.writerow(["Temperature", "Light", "Humidity","Sound"])
    with open('DataVisualer\SensorData.csv', 'r') as read_obj:
        csv_reader = reader(read_obj)
        row_id = 0
        prev_id = 0
        temp = 0 
        light = 0
        hum = 0
        sound = 0
        for row in csv_reader:
            if(row[1] != prev_id):
                writer.writerow([temp,light,hum,sound])
                prev_id = row[1]

            row_id = row[1]

            if(row[2] == str(1)):
                temp = row[3]
            if(row[2] == str(3)):
                light = row[3]
            if(row[2] == str(2)):
                hum = row[3]
            if(row[2] == str(4)):
                sound = row[3]



                