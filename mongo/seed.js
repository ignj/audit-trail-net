db.logs.drop();
db.logs.insertMany([
    {
        "Data": {
            "username": "nicasia",
            "spec": {
                "winery": "catena zapata",
                "alcohol": 13.4,
                "country": "argentina",
                "aging_months": 12
            },
            "date": new Date(3576870278000),
            "application": "wine"
        }
    },
    {
        "Data": {
            "username": "trumpeter",
            "spec": {
                "winery": "rutini",
                "alcohol": 13.2,
                "country": "argentina",
                "aging_months": 7
            },
            "date": new Date(1525978696000),
            "application": "wine"
        }
    },
    {
        "Data": {
            "username": "quesito",
            "info": {
                "type": "cat",
                "age": 6,
                "weight_kg": 6,
                "color": ["orange"]
            },
            "date": new Date(3212435087000),
            "application": "animals"
        }
    },
    {
        "Data": {
            "username": "bonnie",
            "info": {
                "type": "dog",
                "age": 3,
                "weight_kg": 4,
                "color": ["black"]
            },
            "date": new Date(3934699954000),
            "application": "animals"
        }
    },
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
    },
    {
        "Data": {
            "username": "argentina",
            "info": {
                "population": 45.8,
                "fwc": 3
            },
            "date": new Date(3561925830000),
            "application": "countries"
        }
    },
    {
        "Data": {
            "username": "spain",
            "info": {
                "population": 47.4,
                "fwc": 1
            },
            "date": new Date(2125794217000),
            "application": "countries"
        }
    },
    {
        "Data": {
            "username": "brazil",
            "info": {
                "population": 214.3,
                "fwc": 5
            },
            "date": new Date(3376695600000),
            "application": "countries"
        }
    },
    {
        "Data": {
            "username": "uruguay",
            "info": {
                "population": 3.4,
                "fwc": 2
            },
            "date": new Date(3491331533000),
            "application": "countries"
        }
    }
])
