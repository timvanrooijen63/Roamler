Location search tool

The location search tool consists of the following main components:

1. Elasticsearch. 
   This is the database of the application. It can be accessed on: http://elastic:changeme@localhost:9200

2. Logstash. 
   On startup logstash imports all entries from the csv file to Elasticsearch. 

3. Kibana. 
   Added Kibana the have a tool to interact with Elasticsearch 
   user: elastic
   password: changeme

4. .net core web application that enables users to search through the locations provided in the csv file.
   The ui is made with vue.js. When running from docker it can be accessed on: http://localhost:9001/
    
You can startup the whole application by running:
docker-compose up --build