## CarPooling API Documentation

Décris toutes les requêtes possibles pour l'API

### Authentication [/Auth]
#### Register a new user [POST]
**[POST]** `api/Auth/register`

- Body
```json
{
  "firstName": "Name",
  "lastName": "Name",
  "email": "test@test.com",
  "password": "Test123!"
}
```
- Response 201 (application/json)
```json
{
  "token": "TOKEN",
  "userId": 0
}
```

#### Login to account [POST]
**[POST]** `api/Auth/login`

- Body
```json
{
  "email": "ooddccj@go.com",
  "password": "String123!"
}
```
- Response 201 (application/json)
```json
{
  "token": "TOKEN",
  "userId": 0
}
```


### Users [/User]

#### Get a User profile [GET]
**[GET]** `api/User/{id}`
- Response 200 (application/json)
```json
{
  WIP
}
```

#### Delete a User [DELETE]
**[DELETE]** `api/User/{id}`
- Response 200 (application/json)

#### Search Users [GET]
**[GET]** `api/User/Search`
- Response 200 (application/json)
- Query Params :
  - 'max' : maximum number of users to return (default = 25)
```json
[
  {
    //USER 1 CONTENT
  },
  {
    //USER 2 CONTENT 
  }
]
```