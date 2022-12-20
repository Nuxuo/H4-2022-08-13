var jsondata;
const options = { headers: new Headers({'ApiKey': '9881dbd4-b457-48e1-b75f-7a0c4ed00598'}) };

const get_building = async () => {
    const response = await fetch('http://192.168.1.100:44344/Location/buildings', options);
    const myJson = await response.json();

    var x = document.getElementById("buildings");

    for (var buildings of myJson) 
    {
        var option = document.createElement("option");
        option.text = buildings.name + " | " + buildings.address;
        option.value = buildings.id;
        x.add(option);
    }

    get_RoomHubs()
}


const get_RoomHubs = async () => {
    var e = document.getElementById("buildings");
    var value = e.value;

    const response = await fetch('http://192.168.1.100:44344/Location/Building/'+value+'/Hubs',options);
    const myJson = await response.json();

    var x = document.getElementById("RoomHubs");
    x.innerHTML = "";

    for (var roomHubs of myJson) 
    {
        var option = document.createElement("option");
        option.text = roomHubs.room + " | Hub : " + roomHubs.id;
        option.value = roomHubs.id;
        x.add(option);
    }
}


const get_data = async () => {
    var e = document.getElementById("RoomHubs");
    var _days = document.getElementById("days");
    var _days_value = _days.value;
    var value = e.value;

    const response = await fetch('http://192.168.1.100:44344/Data/'+value+'/Chart/Days/'+_days_value,options);
    const myJson = await response.json();
    jsondata = myJson;
    
    google.charts.setOnLoadCallback(drawChart);
}

get_building();


google.charts.load('current', {'packages':['line']});
function drawChart() {
    var clientWidth = document.getElementById('centerdiv').clientWidth;
    var e = document.getElementById("RoomHubs");
    var text = e.options[e.selectedIndex].text;
        
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Time of data');
    
    for (var x of jsondata.sensor) 
    {
        data.addColumn('number', x);
    }

    for (var x of jsondata.sensorData) 
    {
        data.addRows([x]);
    }

    var options = {
      chart: {
        title: 'Room : '+text,
        subtitle: 'Sensor data'
      }, 
      vAxis: {
         title: 'data',        
      }, 
      width: clientWidth,
      height: 600,
      axes: {
        x: {
          0: {side: 'top'}
        }
      }
    };

    var chart = new google.charts.Line(document.getElementById('line_top_x'));

    chart.draw(data, google.charts.Line.convertOptions(options));
}