<h1>Roamler Location search tool</h1>

The location search tool consists of the following components:

* Elasticsearch. 
   This is the database of the application. It can be accessed on: http://elastic:changeme@localhost:9200

*  Logstash. 
   On startup logstash imports all locations from the csv into Elasticsearch. 

* Kibana. 
   Just for editing elastic <br />
   user: elastic <br />
   password: changeme

* .net5 web application. With this application users can search locations
   The ui is made with vue.js. When running from docker it can be accessed on: http://localhost:9001/
    
You can startup the whole application by running:
docker-compose up --build
