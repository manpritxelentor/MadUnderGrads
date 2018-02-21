# README #

API for MadUnderGrads

### Which are the api calls? ###

# ProductTextbook #
* Get: http://localhost:55428/api/ProductTextbook
* Get: http://localhost:55428/api/ProductTextbook/1
* Post: http://localhost:55428/api/ProductTextbook
   Parameter: 
   {
		"id": 0,
        "categoryId": 1,
        "description": "Second Desc",
        "email": "abc@xyz.com",
        "phoneNumber": "12123123",
        "isNegotiable": true,
        "price": 22,
        "isbn": "NNHHJH",
        "title": "Second Book",
        "notesIncluded": true,
        "condition": "New"
	}
* PUT: http://localhost:55428/api/ProductTextbook/1
	Parameter: 
    {
		"id": 0,
        "categoryId": 1,
        "description": "Second Desc",
        "email": "abc@xyz.com",
        "phoneNumber": "12123123",
        "isNegotiable": true,
        "price": 22,
        "isbn": "NNHHJH",
        "title": "Second Book",
        "notesIncluded": true,
        "condition": "New"
	}
* Delete: http://localhost:55428/api/ProductTextbook/2