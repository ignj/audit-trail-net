# Audit Trail

## Summary
The application exposes a REST endpoint to store new Audit Logs. It can be accessed through HTTP Post
```
POST http://localhost:5256/log

{
    "date": "2020-01-01",
    "application": "animals",
    "data": "{\"username\": \"bonni\", \"delta\": { \"age\": 2, \"kind\": \"perro\" } }"
}
```
Or using Dapr topics.

The logs are stored as Documents in a MongoDB database. E.g.
```
{
    "Data": {
        "username": "indi",
        "info": {
            "type": "dog",
            "age": 3,
            "weight_kg": 4,
            "color": ["orange", "white"]
        },
        "date": new Date(962872611000),
        "application": "animals"
    }
}
```

There is a Blazor UI to build generic Filter and Order expressions to manipulate the stored Audit Logs
Simple gneric expressions can be built and composed between them to compose complex expressions for search criteria.

## How to run
In the root folder run
```
docker compose up
```
There is a seed file to populate the database with testing values

![application screenshot](assets/screenshot.jpeg?raw=true "Application screenshot")

